﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCWS_Situation_room
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "아빠안잔다" && tb_password.Text == "hanium")
            {
                MessageBox.Show("Successfully Login");
                this.Visible = false;
                GUI gui = new GUI();
                gui.Show();
            }

            else if (tb_username.Text == "")
            {
                MessageBox.Show("Invalid User Name");
                tb_username.Focus();
                return;
            }

            else if (tb_password.Text == "")
            {
                MessageBox.Show("Invalid Password");
                tb_password.Focus();
                return;
            }

            else
                MessageBox.Show("Invalid User Name or Password");
            //this.Visible = false;
            //GUI gui = new GUI();
            //gui.Show();
        }
    }
}
