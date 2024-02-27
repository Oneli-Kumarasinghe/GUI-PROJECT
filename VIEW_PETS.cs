using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAPPY_PETS
{
    public partial class VIEW_PETS : Form
    {
        public VIEW_PETS()
        {
            InitializeComponent();
        }

        private void VIEW_PETS_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from PETS";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }
        int PET_ID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                PET_ID= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
           
            panel1.Visible = true;
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = ("Select * from PETS where PET_ID='" + txt_pet.Text + "'");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            txt_pet.Text = dataGridView1.CurrentRow.Cells["PET_ID"].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
            cmb_type.Text = dataGridView1.CurrentRow.Cells["TYPE"].Value.ToString();
            txt_breed.Text = dataGridView1.CurrentRow.Cells["BREED"].Value.ToString();
            txt_color.Text = dataGridView1.CurrentRow.Cells["COLOR"].Value.ToString();
            cmb_gender.Text= dataGridView1.CurrentRow.Cells["GENDER"].Value.ToString();
            DOBPicker.Text = dataGridView1.CurrentRow.Cells["DATE_OF_BIRTH"].Value.ToString();
            txt_age.Text = dataGridView1.CurrentRow.Cells["AGE"].Value.ToString();
            txt_owner.Text = dataGridView1.CurrentRow.Cells["OWNER_ID"].Value.ToString();
            txt_first.Text = dataGridView1.CurrentRow.Cells["FIRST_Name"].Value.ToString();
            txt_last.Text = dataGridView1.CurrentRow.Cells["LAST_Name"].Value.ToString();
            txt_address1.Text = dataGridView1.CurrentRow.Cells["ADDRS1"].Value.ToString();
            txt_address2.Text = dataGridView1.CurrentRow.Cells["ADDRS2"].Value.ToString();
            txt_no.Text = dataGridView1.CurrentRow.Cells["CONTACT_NO"].Value.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Year <= DOBPicker.Value.Year)
            {
                MessageBox.Show("please enter valid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    if (MessageBox.Show("Data Will Be Updated! Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = ("Update PETS set NAME='" + txt_name.Text + "',TYPE='" + cmb_type.SelectedItem.ToString() + "',BREED='" + txt_breed.Text + "',COLOR='" + txt_color.Text + "',GENDER='" + cmb_gender.SelectedItem.ToString() + "',DATE_OF_BIRTH='" + DOBPicker.Value + "',AGE='" + txt_age.Text + "',OWNER_ID='" + txt_owner.Text + "',FIRST_NAME='" + txt_first.Text + "',LAST_NAME='" + txt_last.Text + "',ADDRS1 = '" + txt_address1.Text + "',ADDRS2 = '" + txt_address2.Text + "',CONTACT_NO = '" + txt_no.Text + "' where PET_ID ='" + txt_pet.Text + "'");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                    }
                    else
                        MessageBox.Show("Data cannot be Updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (SqlException)
                {
                    MessageBox.Show("Database Connection Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Data Will Be Deleted! Confirm?", "Confimation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = ("Delete from PETS where PET_ID ='" + txt_pet.Text + "'");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                }
                else
                    MessageBox.Show("Data cannot Deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Database Connection Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            FrmHappyPets report = new FrmHappyPets();
            report.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnAddPetDetails_Click(object sender, EventArgs e)
        {
            PET_REGISTRATION obj = new PET_REGISTRATION();
            obj.ShowDialog();
        }

        private void txt_pet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_breed_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_color_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DOBPicker_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - DOBPicker.Value.Year;

            //txt_age.Text = age.ToString();
            if (DateTime.Now.Year <= DOBPicker.Value.Year)
            {
                MessageBox.Show("please input valid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                txt_age.Text = age.ToString();
            }
        }
    }
}
