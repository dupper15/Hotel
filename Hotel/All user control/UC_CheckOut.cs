﻿using System;
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
    public partial class UC_CheckOut : UserControl
    {
        function fn = new function();
        string query;
        public UC_CheckOut()
        {
            InitializeComponent();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout ='NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '"+txtName.Text +"%' and checkout = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
            if(txtCName.Text != "")
            {
                if(MessageBox.Show("Bạn có chắc chắn không?","Xác Nhận",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckOutDate.Text;
                    query = "update customer set checkout = 'YES', checkout ='" + cdate + "'where cid = " + id + "update rooms set booked ='NO' where roomNo = '" + txtRoom.Text + "'";
                    fn.setData(query, "Thanh Toán Thành Công");
                    UC_CheckOut_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Không có khách hàng để lựa chọn", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtCName.Clear();
            txtRoom.Clear();
            txtName.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
