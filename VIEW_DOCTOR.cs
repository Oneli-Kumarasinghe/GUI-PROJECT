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
    public partial class VIEW_DOCTOR : Form
    {
        public VIEW_DOCTOR()
        {
            InitializeComponent();
        }

        String connectionString;
        SqlConnection con;

        public SqlConnection dbConnection()
        {
            connectionString = @"Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            con = new SqlConnection(connectionString);

            con.Open();
            /*MessageBox.Show("SUCCESS");*/
            return con;
        }

        private void VIEW_DOCTOR_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            /*SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
             cmd.Connection = con;

            cmd.CommandText = "Select * from DOCTOR";*/


            String sql = "Select * from DOCTOR";

            SqlDataAdapter da = new SqlDataAdapter(sql, dbConnection());

            DataSet ds = new DataSet();
            da.Fill(ds, "Doctor");
            combobox_doc.DisplayMember = "FIRST_NAME";
            combobox_doc.ValueMember = "DOC_ID";
            combobox_doc.DataSource = ds.Tables["Doctor"];
            /*dataGridView1.DataSource = ds.Tables[0];*/

        }

        int DOCTOR_ID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DOCTOR_ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }*/
            panel1.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = ("Select * from DOCTOR where DOC_ID='" + txt_dr.Text + "'");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            /*txt_dr.Text = dataGridView1.CurrentRow.Cells["DOC_ID"].Value.ToString();
            txt_first.Text = dataGridView1.CurrentRow.Cells["FIRST_Name"].Value.ToString();
            txt_last.Text = dataGridView1.CurrentRow.Cells["LAST_Name"].Value.ToString();
            txt_nic.Text = dataGridView1.CurrentRow.Cells["NIC"].Value.ToString();
            txt_address1.Text = dataGridView1.CurrentRow.Cells["ADDRS1"].Value.ToString();
            txt_address2.Text = dataGridView1.CurrentRow.Cells["ADDRS2"].Value.ToString();
            txt_no.Text = dataGridView1.CurrentRow.Cells["CONTACT_NO"].Value.ToString();*/
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Data Will Be Updated! Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    /* SqlConnection con = new SqlConnection();
                     con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = con;*/

                   /* dbConnection()*/;

                    SqlCommand command;

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    String sql = "Update DOCTOR set FIRST_NAME = '" + txt_first.Text + "', LAST_NAME = '" + txt_last.Text + "', NIC = '" + txt_nic.Text + "'," +
                                       "ADDRS1='" + txt_address1.Text + "',ADDRS2='" + txt_address2.Text + "',CONTACT_NO='" + txt_no.Text + "' where DOC_ID= '" + txt_dr.Text + "'";

                    command = new SqlCommand(sql, dbConnection());
                    adapter.UpdateCommand = new SqlCommand(sql, con);
                    adapter.UpdateCommand.ExecuteNonQuery();


                    /*cmd.CommandText = ("Update DOCTOR set FIRST_NAME='" + txt_first.Text + "',LAST_NAME='" + txt_last.Text + "',NIC='" + txt_nic.Text + "'," +
                                       "ADDRS1='" + txt_address1.Text + "',ADDRS2='" + txt_address2.Text + "',CONTACT_NO='" + txt_no.Text + "' where DOC_ID= '" + txt_dr.Text + "'");*/
                    /*SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);*/
                }
                else
                    MessageBox.Show("Data cannot be Updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    cmd.CommandText = ("Delete from DOCTOR where DOC_ID ='" + txt_dr.Text + "'");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                }
                else
                    MessageBox.Show("Data cannot Deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmDoctorDetails obj = new frmDoctorDetails();
            obj.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }




        private void combobox_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            EDIT_BTN.Visible = true;
            txt_first.ReadOnly = true;
            txt_last.ReadOnly = true;
            txt_nic.ReadOnly = true;
            txt_address1.ReadOnly = true;
            txt_address2.ReadOnly = true;
            txt_no.ReadOnly = true;

            if (combobox_doc.SelectedItem != null)
            {
                DataRowView drv = combobox_doc.SelectedItem as DataRowView;

                /*txt_dr.Text = dataGridView1.CurrentRow.Cells["DOC_ID"].Value.ToString();*/
                txt_dr.Text = drv.Row["DOC_ID"].ToString();
                txt_first.Text = drv.Row["FIRST_NAME"].ToString();
                txt_last.Text = drv.Row["LAST_NAME"].ToString();
                txt_nic.Text = drv.Row["NIC"].ToString();
                txt_address1.Text = drv.Row["ADDRS1"].ToString();
                txt_address2.Text = drv.Row["ADDRS2"].ToString();
                txt_no.Text = drv.Row["CONTACT_NO"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EDIT_BTN.Visible = false;
            txt_first.ReadOnly = false;
            txt_last.ReadOnly = false;
            txt_nic.ReadOnly = false;
            txt_address1.ReadOnly = false;
            txt_address2.ReadOnly = false;
            txt_no.ReadOnly = false;
        }

        private void txt_first_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

