using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAPPY_PETS
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection("Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select Count (*) From LOGIN where USER_NAME='" + txt_user.Text + "' and PASSWORD='" + txt_pass.Text + "'", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (txt_user.Text == "Admin")
            {
                MessageBox.Show("Please Check the USERNAME and PASSWORD!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                FrmHappyPets obj = new FrmHappyPets();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Check the USERNAME and PASSWORD!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
