using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI
{
    public partial class EmployeesGUI : Form
    {
        private EmployeesBUS _employeesContext = new EmployeesBUS();
        public EmployeesGUI()
        {
            InitializeComponent();
            // Lấy danh sách đặt tên cho Columns theo thứ tự bên DTO
            dgvEmployees.DataSource = _employeesContext.GetList();
            dgvEmployees.Columns[0].HeaderText = "Mã NV";
            dgvEmployees.Columns[1].HeaderText = "Tên";
            dgvEmployees.Columns[2].HeaderText = "Ngày sinh";
            dgvEmployees.Columns[3].HeaderText = "Giới tính";
            dgvEmployees.Columns[4].HeaderText = "CMND";
            dgvEmployees.Columns[5].HeaderText = "Điện thoại";
            dgvEmployees.Columns[6].HeaderText = "Địa chỉ";
            dgvEmployees.Columns[7].HeaderText = "Chức vụ";
            cbxJobTitle.DataSource = _employeesContext.ListJob;
            cbxJobTitle.DisplayMember = "DisplayName";
            cbxJobTitle.ValueMember = "Title"; 
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetOkButtonEnable(bool value)
        {
            // Tắt button trong lúc thay đổi dữ liệu
            btnAdd.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
            btnOK.Enabled = value;
            btnCancel.Enabled = value;
            btnExit.Enabled = !value;
            // Mở khóa nhập liệu
            txtID.ReadOnly = !value;
            txtName.ReadOnly = !value;
            txtPhoneNumber.ReadOnly = !value;
            txtAddress.ReadOnly = !value;
            txtPhoneNumber.ReadOnly = !value;
            cbxJobTitle.Enabled = value;
            dtpBirthDate.Enabled = value;
            rdbFemale.Enabled = value;
            rdbMale.Enabled = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txtEmloyeeID.Text = "";
            txtID.Text = "";
            cbxJobTitle.SelectedItem = null;
            txtName.Text = "";
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            rdbMale.Checked = true;
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            _isAddButtonClicked = true;
            grbButton.Text = "Chức Năng - Thêm";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            _isAddButtonClicked = false;
            grbButton.Text = "Chức Năng - Sửa";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            grbButton.Text = "Chức Năng - Xóa";
            if (!string.IsNullOrWhiteSpace(txtEmloyeeID.Text))
            {
                string message = "Bạn có thực sự muốn xóa nhân viên tên: " + txtName.Text + ", ID: " + txtEmloyeeID.Text + " không?";
                if (MessageBox.Show(message, "Xóa nhân viên.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_employeesContext.DeleteEmployee(_selectedID, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvEmployees.DataSource = _employeesContext.GetList();
                    }
                    else
                    {
                        message = "Có lỗi xảy ra trong quá trình xóa nhân viên.\nXem chi tiết?";
                        if (MessageBox.Show(message, "Không thể xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MessageBox.Show(serverMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên cần xóa");
            }
            grbButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtID.Text))
                message += "Nhập số CMND.\n";
            else if (!Regex.IsMatch(txtID.Text, @"^\d{9}|d{11,12}$"))
                message += "Số CMND: " + txtID.Text + " không hợp lệ.\n";
            if (string.IsNullOrWhiteSpace(txtName.Text))
                message += "Nhập tên nhân viên.\n";
            if (dtpBirthDate.Value > DateTime.Now.AddYears(-18))
                message += "Tuổi không hợp lệ, nhân viên phải lớn hơn 18 tuổi.";
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                message += "Nhập địa chỉ.\n";
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                message += "Nhập số điện thoại.\n";
            else if (!Regex.IsMatch(txtPhoneNumber.Text, @"^0(3[3-9]|7[06789]|8[1-5]|5[689])\d{7}$"))
                message += "Số điện thoại: " + txtPhoneNumber.Text + " không hợp lệ.\n";
            return message == "" ? true : false;
        }
        private bool _isAddButtonClicked = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            string serverMessage;
            if (!Check(out serverMessage))
            {
                MessageBox.Show(serverMessage, "Thiếu dữ kiện.");
                return;
            }
            EmployeeDTO employeeFormat = new EmployeeDTO
            {
                Name = string.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = rdbMale.Checked ? "Nam" : "Nữ",
                ID = string.IsNullOrWhiteSpace(txtID.Text) ? null : txtID.Text,
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                PhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? null : txtPhoneNumber.Text,
                JobTitle = _employeesContext.ListJob.SingleOrDefault(o => o.Title == cbxJobTitle.SelectedValue.ToString())?.DisplayName ?? "Vô công"
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                if (_employeesContext.AddEmployee(employeeFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công nhân viên tên: " + txtName.Text + ", ID: " + txtEmloyeeID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình thêm nhân viên.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể thêm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            else
            {
                employeeFormat.EmployeeID = int.Parse(txtEmloyeeID.Text);
                if (_employeesContext.EditEmployee(employeeFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công nhân viên tên: " + txtName.Text + ", ID: " + txtEmloyeeID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình sửa nhân viên.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể sửa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            if (completed)
            {
                SetOkButtonEnable(false);
                grbButton.Text = "Chức Năng";
                dgvEmployees.DataSource = _employeesContext.GetList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            try
            {
                var selectedItem = dgvEmployees.Rows.Cast<EmployeeDTO>().Single(o => o.EmployeeID == _selectedID);
                txtEmloyeeID.Text = selectedItem.EmployeeID.ToString();
                txtID.Text = selectedItem.ID;
                cbxJobTitle.SelectedValue = _employeesContext.ListJob.SingleOrDefault(o => o.DisplayName == selectedItem.JobTitle).Title ?? "VC";
                txtName.Text = selectedItem.Name;
                dtpBirthDate.Value = selectedItem.BirthDate;
                if (selectedItem.Gender == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txtAddress.Text = selectedItem.Address;
                txtPhoneNumber.Text = selectedItem.PhoneNumber;
            }
            catch
            {
                MessageBox.Show("Có vấn đề trong việc truy xuất tới máy chủ.", "Lỗi.");
            }
            grbButton.Text = "Chức Năng";
        }
        private int _selectedID;
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedCells.Count > 0)
            {
                int rowIndex = dgvEmployees.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmployees.Rows[rowIndex];
                //Thứ tự gán theo bên file DTO
                txtEmloyeeID.Text = selectedRow.Cells[0].Value?.ToString(); 
                txtName.Text = selectedRow.Cells[1].Value?.ToString();
                dtpBirthDate.Value = DateTime.Parse(selectedRow.Cells[2].Value?.ToString());
                if (selectedRow.Cells[3].Value?.ToString() == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txtID.Text = selectedRow.Cells[4].Value?.ToString();
                txtPhoneNumber.Text = selectedRow.Cells[5].Value?.ToString();
                txtAddress.Text = selectedRow.Cells[6].Value?.ToString();
                cbxJobTitle.SelectedValue = _employeesContext.ListJob.SingleOrDefault(o => o.DisplayName == selectedRow.Cells[7].Value?.ToString()).Title ?? "VC";
                //gán ID ngầm để truy xuất ngược khi hủy
                _selectedID = int.Parse(txtEmloyeeID.Text);
            }
        }
    }
}
