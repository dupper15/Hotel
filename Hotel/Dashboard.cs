using Hotel.All_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Addroom1.Visible = false;
            uC_CustomerRes1.Visible = false;
            uC_CheckOut1.Visible=false;
            uC_CustomerDetail1.Visible = false;
            uC_Employee1.Visible = false;
            btAddroom.PerformClick();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btAddroom.Left + 50;
            uC_Addroom1.Visible = true;
            uC_Addroom1.BringToFront();
        }

        
        private void uC_Addroom1_Load(object sender, EventArgs e)
        {

        }

        private void btCustomerReg_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btCustomerReg.Left + 60;
            uC_CustomerRes1.Visible = true;
            uC_CustomerRes1.BringToFront();
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btCheckOut.Left + 50; 
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
        }

        private void btCustomerDetail_Click(object sender, EventArgs e)
        {
            panelMoving.Left=btCustomerDetail.Left + 50;
            uC_CustomerDetail1.Visible = true;
            uC_CustomerDetail1.BringToFront();         
        }

        private void btEmploy_Click(object sender, EventArgs e)
        {
            panelMoving.Left= btEmploy.Left + 50;
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }
    }
}
