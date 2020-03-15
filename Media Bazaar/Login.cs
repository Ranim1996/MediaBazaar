using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Media_Bazaar.Classes;
using MySql.Data;

namespace Media_Bazaar
{
    public partial class Login : Form
    {
        DataAccess db;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //closes login form and exits the app
        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize login form
        private void btnLoginMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        
        private string user;
        private string pass;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = tbUsername.Text;
            pass = tbPassword.Text;
            MySqlConnection conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi428501;Database=dbi428501;Pwd=1234;");

            MySqlCommand cmdAdmin = new MySqlCommand($"SELECT Username, Password FROM Employee WHERE Username = '{user}' AND Password = '{pass}' AND Position='ADMINISTRATOR';", conn);
            MySqlCommand cmdManager = new MySqlCommand($"SELECT Username, Password FROM Employee WHERE Username = '{user}' AND Password = '{pass}' AND Position='MANAGER';", conn);
            MySqlCommand cmdDepot = new MySqlCommand($"SELECT Username, Password FROM Employee WHERE Username = '{user}' AND Password = '{pass}' AND Position='DEPOT';", conn);
            conn.Open();

            MySqlDataAdapter sdaAdmin = new MySqlDataAdapter(cmdAdmin);
            DataTable dtAdmin = new DataTable();
            sdaAdmin.Fill(dtAdmin);

            MySqlDataAdapter sdaManager = new MySqlDataAdapter(cmdManager);
            DataTable dtManager = new DataTable();
            sdaManager.Fill(dtManager);

            MySqlDataAdapter sdaDepot = new MySqlDataAdapter(cmdDepot);
            DataTable dtDepot = new DataTable();
            sdaDepot.Fill(dtDepot);

            if (dtAdmin.Rows.Count > 0 || (user == "Admin" && pass == "1234"))
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                MainAdmin MainAdmin = new MainAdmin();
                MainAdmin.Show();
                this.Visible = false;
                conn.Close();
            }
            else if (dtManager.Rows.Count > 0 || (user == "Manager" && pass == "1234"))
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                MainManager MainManager = new MainManager();
                MainManager.Show();
                this.Visible = false;
                conn.Close();
            }
            else if (dtDepot.Rows.Count > 0 || (user == "Depot" && pass == "1234"))
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                MainDepot MainDepot = new MainDepot();
                MainDepot.Show();
                this.Visible = false;
                conn.Close();
            }
            else
            {
                
                MessageBox.Show("Wrong Username/Password");
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                conn.Close();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

