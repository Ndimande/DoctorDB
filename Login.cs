using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoctorDB.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using DoctorDBLibrary;

namespace DoctorDB
{
    public partial class LoginForm : Form
    {
        //Global Variable for when the button is clicked - By default the value is set to False
        public bool BtnClick;

        public LoginForm()
        {
            InitializeComponent();
            txtUsername.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;
        }
        
        private void EnterUTextBox(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.ForeColor = Color.Black;
        }

        private void EnterPTextBox(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.ForeColor = Color.Black;
        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void Clear(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        private void focus(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void ViewPassword(object sender, EventArgs e)
        {
            // If button is clicked
            if(!BtnClick)
            {
                BtnClick = true;

                // This changes the password to Plain Text
                txtPassword.PasswordChar = '\0';
                txtPassword.Focus();
            }
        }

        private void ViewPassword2(object sender, EventArgs e)
        {
            
            BtnClick = false;
            txtPassword.PasswordChar = '*';
            txtPassword.Focus();
        }
       
        /*
            - This method activates once you click on the LOGIN BUTTON and takes you to the DASHBOARD FORM  
        */
        private void Login(object sender, EventArgs e)
        {
            GlobalConfig.ClickEvents.LoginClicks(sender, e, txtUsername, txtPassword, btnLogin, forgotLabel, out string result);

            switch (result)
            {
                case "Success":
                    Task t = new Task(() =>
                    {
                        //Hides the current Form
                        this.Hide();
                        // Creating a DashboardForm Object (This is another FORM we created)
                        var newForm = new DashboardForm(txtUsername.Text);

                        // Clear the login FORMS information so that no data from that form comes through on this one
                        Clear();
                        // Shows the form object we just created
                        newForm.Show();

                        // When you click on Login Button it takes you to the Next Form - (Dashboard Form)
                        newForm.FormClosing += (s, EventArgs) => this.Show();
                    });
                    t.RunSynchronously();
                    t.Wait();
                    break;

                case "Username or Password is Incorrect":
                    MessageBox.Show(GlobalConfig.CheckQueries.Result);
                    GlobalConfig.ClearEvents.LoginForm(txtUsername, txtPassword);
                    break;

                case "User Does Not Exist":
                    MessageBox.Show(GlobalConfig.CheckQueries.Result);
                    GlobalConfig.ClearEvents.LoginForm(txtUsername, txtPassword);
                    break;

                default:
                    break;

            }

        }

        private void ChangeFocus(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtUsername.ContainsFocus)
                    {
                        txtPassword.Focus();
                        // Keeps the in the text field
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else if (txtPassword.Focus())
                    {
                        btnLogin.Focus();
                        // Keeps the in the text field
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private bool hasTextBeenChanged;
        private bool hasTextBeenChanged2;

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            hasTextBeenChanged = !String.IsNullOrEmpty(txtUsername.Text);

            if (hasTextBeenChanged)
            {
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            hasTextBeenChanged2 = !String.IsNullOrEmpty(txtPassword.Text);

            if (hasTextBeenChanged2)
            {
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (!hasTextBeenChanged)
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (!hasTextBeenChanged2)
            {
                txtPassword.Text = "";
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasTextBeenChanged = true;
        }
            
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasTextBeenChanged2 = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pbLoginImage;
        }

        private void forgotLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
