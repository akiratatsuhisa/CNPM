using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System.Text.RegularExpressions;

namespace QuanLyBanHang.GUI
{
    public partial class EmployeesFormGUI : DevExpress.XtraEditors.XtraForm
    {
        private EmployeesBUS _employeesContext = new EmployeesBUS();
        private bool _isAddButtonClicked = false;
        private bool _isOkButtonEnabled = false;
        private int? _selectedID;
        public EmployeesFormGUI()
        {
            InitializeComponent();
            // Lấy danh sách
            dgvEmployee.DataSource = _employeesContext.GetList();
            cbxJobTitle.DataSource = _employeesContext.ListJob;
            cbxJobTitle.DisplayMember = "DisplayName";
            cbxJobTitle.ValueMember = "Title";
        }
        private void SetOkButtonEnable(bool value)
        {
            // Tắt button trong lúc thay đổi dữ liệu
            btnAdd.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
            btnOK.Enabled = value;
            btnCancel.Enabled = value;
            _isOkButtonEnabled = value;
            // Mở khóa nhập liệu
            txbID.ReadOnly = !value;
            txbName.ReadOnly = !value;
            txbPhoneNumber.ReadOnly = !value;
            txbAddress.ReadOnly = !value;
            txbPhoneNumber.ReadOnly = !value;
            cbxJobTitle.Enabled = value;
            dtpBirthDate.Enabled = value;
            rdbFemale.Enabled = value;
            rdbMale.Enabled = value;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txbEmployeeID.Text = "";
            txbID.Text = "";
            cbxJobTitle.SelectedItem = null;
            txbName.Text = "";
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            rdbMale.Checked = true;
            txbAddress.Text = "";
            txbPhoneNumber.Text = "";
            _isAddButtonClicked = true;
            lcgButton.Text = "Chức Năng - Thêm";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedID != null)
            {
                SetOkButtonEnable(true);
                _isAddButtonClicked = false;
                lcgButton.Text = "Chức Năng - Sửa";
            }
            else
            {
                MessageBox.Show("Chọn nhân viên cần sửa.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lcgButton.Text = "Chức Năng - Xóa";
            if (_selectedID != null)
            {
                string message = "Bạn có thực sự muốn xóa nhân viên tên: " + txbName.Text + ", ID: " + txbEmployeeID.Text + " không?";
                if (MessageBox.Show(message, "Xóa nhân viên.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_employeesContext.DeleteEmployee(_selectedID.Value, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvEmployee.DataSource = _employeesContext.GetList();
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
                MessageBox.Show("Chọn nhân viên cần xóa.");
            }
            lcgButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txbID.Text))
                message += "Nhập số CMND.\n";
            else if (!Regex.IsMatch(txbID.Text, @"^\d{9}|d{11,12}$"))
                message += "Số CMND: " + txbID.Text + " không hợp lệ.\n";
            if (string.IsNullOrWhiteSpace(txbName.Text))
                message += "Nhập tên nhân viên.\n";
            if (dtpBirthDate.Value > DateTime.Now.AddYears(-18))
                message += "Tuổi không hợp lệ, nhân viên phải lớn hơn 18 tuổi.";
            if (string.IsNullOrWhiteSpace(txbAddress.Text))
                message += "Nhập địa chỉ.\n";
            if (string.IsNullOrWhiteSpace(txbPhoneNumber.Text))
                message += "Nhập số điện thoại.\n";
            else if (!Regex.IsMatch(txbPhoneNumber.Text, @"^0(3[2-9]|5[689]|7[06789]|8[1-689]|9[0-46-9])\d{7}$"))
                message += "Số điện thoại: " + txbPhoneNumber.Text + " không hợp lệ.\n";
            return message == "" ? true : false;
        }
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
                ID = txbID.Text.Trim(),
                JobTitle = _employeesContext.ListJob.SingleOrDefault(o => o.Title == cbxJobTitle.SelectedValue.ToString())?.DisplayName ?? "Vô công",
                Name = string.IsNullOrWhiteSpace(txbName.Text) ? null : txbName.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = rdbMale.Checked ? "Nam" : "Nữ",
                Address = string.IsNullOrWhiteSpace(txbAddress.Text) ? null : txbAddress.Text.Trim(),
                PhoneNumber = string.IsNullOrWhiteSpace(txbPhoneNumber.Text) ? null : txbPhoneNumber.Text,
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                if (_employeesContext.AddEmployee(employeeFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công nhân viên tên: " + txbName.Text + ", ID: " + txbEmployeeID.Text + ".");
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
                employeeFormat.EmployeeID = int.Parse(txbEmployeeID.Text);
                if (_employeesContext.EditEmployee(employeeFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công nhân viên tên: " + txbName.Text + ", ID: " + txbEmployeeID.Text + ".");
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
                lcgButton.Text = "Chức Năng";
                dgvEmployee.DataSource = _employeesContext.GetList();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            lcgButton.Text = "Chức Năng";
            if (_selectedID != null)
            {
                try
                {
                    var selectedItem = dgvEmployee.Rows.Cast<DataGridViewRow>().Single(o => o.Cells[0].Value.ToString() == _selectedID.ToString());
                    txbEmployeeID.Text = _selectedID.ToString();
                    txbName.Text = selectedItem.Cells[1].Value?.ToString();
                    dtpBirthDate.Value = DateTime.Parse(selectedItem.Cells[2].Value?.ToString());
                    if (selectedItem.Cells[3].Value?.ToString() == "Nam")
                        rdbMale.Checked = true;
                    else
                        rdbFemale.Checked = true;
                    txbID.Text = selectedItem.Cells[4].Value?.ToString();
                    txbPhoneNumber.Text = selectedItem.Cells[5].Value?.ToString();
                    txbAddress.Text = selectedItem.Cells[6].Value?.ToString();
                    cbxJobTitle.SelectedValue = _employeesContext.ListJob.SingleOrDefault(o => o.DisplayName == selectedItem.Cells[7].Value?.ToString()).Title ?? "VC";
                }
                catch
                {
                    MessageBox.Show("Có vấn đề trong việc truy xuất dữ liệu.", "Lỗi.");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedCells.Count > 0 && !_isOkButtonEnabled)
            {
                int rowIndex = dgvEmployee.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmployee.Rows[rowIndex];

                txbEmployeeID.Text = selectedRow.Cells[0].Value?.ToString();
                txbName.Text = selectedRow.Cells[1].Value?.ToString();
                dtpBirthDate.Value = DateTime.Parse(selectedRow.Cells[2].Value?.ToString());
                if (selectedRow.Cells[3].Value?.ToString() == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txbID.Text = selectedRow.Cells[4].Value?.ToString();
                txbPhoneNumber.Text = selectedRow.Cells[5].Value?.ToString();
                txbAddress.Text = selectedRow.Cells[6].Value?.ToString();
                cbxJobTitle.SelectedValue = _employeesContext.ListJob.SingleOrDefault(o => o.DisplayName == selectedRow.Cells[7].Value?.ToString()).Title ?? "VC";

                _selectedID = int.Parse(txbEmployeeID.Text);
            }
            else if (dgvEmployee.SelectedCells.Count == 0 && !_isOkButtonEnabled)
            {
                _selectedID = null;
            }
        } 
    }
}