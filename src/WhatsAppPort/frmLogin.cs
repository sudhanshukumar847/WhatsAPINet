﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhatsAppPort
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.CheckLogin(this.textBoxPhone.Text, this.textBoxPass.Text))
            {
                MessageBox.Show(this, "Login fehlgeschlagen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var frm = new frmForm(this.textBoxPhone.Text, this.textBoxPass.Text, this.textBoxNick.Text))
            {
                this.Visible = false;
                frm.ShowDialog();

                this.Visible = true;
                this.BringToFront();
            }
        }

        private bool CheckLogin(string user, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                    return false;

                string cc = user.Substring(0, 2);
                string phone = user.Remove(0, 2).TrimStart('0');
                return WhatsAppApi.Register.WhatsRegister.ExistsAndDelete(cc, phone, pass);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
