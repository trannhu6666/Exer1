using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class ReportForm : Form
    {
        private ReportService _reportService = new ReportService();
        private System.Collections.IList _orderData;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtOrderID.Text, out int id))
            {
                // Nếu đúng là số, tiến hành lấy dữ liệu
                var data = _reportService.GetOrderDetailsForPrinting(id);

                if (data != null && data.Count > 0)
                {
                    _orderData = data;
                    dgvDetails.DataSource = data;
                }
                else
                {
                    MessageBox.Show("No order found with this ID!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetails.DataSource = null;
                }
            }
            else
            {
                // Nếu nhập chữ hoặc để trống, hiện thông báo nhắc nhở
                MessageBox.Show("Please enter a valid numeric Order ID!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderID.Focus(); // Đặt con trỏ chuột lại vào ô nhập để người dùng sửa
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_orderData == null)
            {
                MessageBox.Show("Please load an order first before printing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ppd.Document = printDoc;
            ppd.ShowDialog();

        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);

            // Vẽ tiêu đề
            g.DrawString("ORDER REPORT", titleFont, Brushes.Black, new Point(300, 50));

            // Lấy dòng dữ liệu đầu tiên để in thông tin khách hàng
            var firstRow = (DAL.OrderReportItem)_orderData[0];
            int yPos = 120; // Tọa độ Y (chiều dọc) bắt đầu in

            g.DrawString("Agent Name: " + firstRow.AgentName, headerFont, Brushes.Black, new Point(50, yPos));
            yPos += 30; // Nhảy xuống dòng
            g.DrawString("Order Date: " + firstRow.OrderDate?.ToString("dd/MM/yyyy"), headerFont, Brushes.Black, new Point(50, yPos));
            yPos += 50;

            // Vẽ tiêu đề của các cột bảng
            g.DrawString("Item Name", headerFont, Brushes.Black, new Point(50, yPos));
            g.DrawString("Quantity", headerFont, Brushes.Black, new Point(350, yPos));
            g.DrawString("Price", headerFont, Brushes.Black, new Point(500, yPos));
            g.DrawString("Total", headerFont, Brushes.Black, new Point(650, yPos));
            yPos += 30;
            g.DrawString("------------------------------------------------------------------------------------------------", regularFont, Brushes.Black, new Point(50, yPos));
            yPos += 30;

            // Vòng lặp: Duyệt qua từng món hàng để vẽ
            decimal grandTotal = 0;
            foreach (DAL.OrderReportItem item in _orderData)
            {
                g.DrawString(item.ItemName.ToString(), regularFont, Brushes.Black, new Point(50, yPos));
                g.DrawString(item.Quantity.ToString(), regularFont, Brushes.Black, new Point(350, yPos));
                g.DrawString(item.Price?.ToString("N0"), regularFont, Brushes.Black, new Point(500, yPos));
                g.DrawString(item.Total?.ToString("N0"), regularFont, Brushes.Black, new Point(650, yPos));

                grandTotal += (decimal)item.Total;
                yPos += 30; // Mỗi món in xong lại nhảy dòng
            }

            // Vẽ dòng gạch chân và Tổng cộng
            yPos += 20;
            g.DrawString("------------------------------------------------------------------------------------------------", regularFont, Brushes.Black, new Point(50, yPos));
            yPos += 30;
            Font totalFont = new Font("Arial", 14, FontStyle.Bold);
            g.DrawString("GRAND TOTAL: " + grandTotal.ToString("N0") + " VNĐ", totalFont, Brushes.Red, new Point(450, yPos));
        }

        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
