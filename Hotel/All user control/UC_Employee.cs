using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.All_user_control
{
   

    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        string query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString()!="")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text= (num+1).ToString();
            }
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void btnRegistation_Click(object sender, EventArgs e)
        {
            if(txtName.Text!=""&&txtMobile.Text!=""&&txtGender.Text!=""&&txtEmail.Text!=""&&txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text; 
                String password = txtPassword.Text; 

                query = "insert into employee (ename, mobile, gender, emailid, username, pass) values ('"+name+"',"+mobile +",'"+gender+"','"+email+"','"+username+"','"+password+"')";
                fn.setData(query, "Đăng Ký Nhân Viên Thành Công!");
                clearAll();
                getMaxID();
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtUsername.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2);
            }
        }
        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                // Kiểm tra xem eid có tồn tại không
                if (IsEmployeeExists(int.Parse(txtID.Text)))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        query = "delete from employee where eid = " + txtID.Text + "";
                        fn.setData(query, "Thông Tin Nhân Viên Đã Được Xóa!!");
                        tabControl1_SelectedIndexChanged(this, null);
                        txtID.Clear();
                        txtID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Clear();
                    txtID.Focus();
                }
            }
        }

        // Hàm kiểm tra sự tồn tại của nhân viên
        private bool IsEmployeeExists(int employeeId)
        {
            query = "SELECT COUNT(*) FROM employee WHERE eid = " + employeeId;
            int count = Convert.ToInt32(fn.getData(query).Tables[0].Rows[0][0]);

            return count > 0;
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
