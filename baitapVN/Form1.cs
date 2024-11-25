using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace baitapVN
{
    public partial class from : Form
    {
        public from()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(txtLast.Text);
            lvi.SubItems.Add(txtFist.Text);
            lvi.SubItems.Add(txtPhone.Text);    
            // đưa dòng dữ liệu lên listview
            lvStudent.Items.Add(lvi);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          
            if (lvStudent.SelectedItems.Count > 0) // Kiểm tra có mục nào được chọn không
                {
            lvStudent.Items.Remove(lvStudent.SelectedItems[0]); // Xóa mục được chọn
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvStudent.SelectedItems.Count > 0) // Kiểm tra có mục nào được chọn không
            {
                ListViewItem selectedItem = lvStudent.SelectedItems[0];
                selectedItem.Text = txtLast.Text; // Cập nhật cột Last Name
                selectedItem.SubItems[1].Text = txtFist.Text; // Cập nhật cột First Name
                selectedItem.SubItems[2].Text = txtPhone.Text; // Cập nhật cột Phone
                MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudent.SelectedItems.Count > 0) // Kiểm tra có mục nào được chọn không
            {
                ListViewItem selected = lvStudent.SelectedItems[0];
                txtLast.Text = selected.Text; // Hiển thị Last Name
                txtFist.Text = selected.SubItems[1].Text; // Hiển thị First Name
                txtPhone.Text = selected.SubItems[2].Text; // Hiển thị Phone
            }
        }

        private void from_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát?", " Tiêu đề thông báo ",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
