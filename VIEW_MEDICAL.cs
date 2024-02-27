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
    public partial class VIEW_MEDICAL : Form
    {
        public VIEW_MEDICAL()
        {
            InitializeComponent();
        }

        private void VIEW_MEDICAL_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from MEDICAL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String pet_id = txt_pet.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select NAME,TYPE From PETS Where PET_ID='" + pet_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_name.Text = ds.Tables[0].Rows[0][0].ToString();
                txt_type.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txt_name.Clear();
                txt_type.ResetText();
                MessageBox.Show("Invalid PET_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search1_Click(object sender, EventArgs e)
        {
            String doc_id = txt_doc.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select FIRST_NAME + LAST_NAME From DOCTOR Where DOC_ID='" + doc_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_dr.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {

                txt_dr.Clear();
                txt_doc.Clear();
                MessageBox.Show("Invalid DOC_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            double vaccine = Convert.ToDouble(txt_vaccine.Text);

            double other = Convert.ToDouble(txt_other.Text);

            txt_total.Text = (vaccine + other).ToString();
        }

        int MEDICAL_ID;
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MEDICAL_ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            panel1.Visible = true;
           
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = ("Select * from MEDICAL where MEDICAL_ID='" + txt_medical.Text + "'");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txt_medical.Text = dataGridView1.CurrentRow.Cells["MEDICAL_ID"].Value.ToString();
            DatePicker.Text = dataGridView1.CurrentRow.Cells["MEDICAL_DATE"].Value.ToString();
            txt_doc.Text = dataGridView1.CurrentRow.Cells["DOC_ID"].Value.ToString();
            txt_dr.Text = dataGridView1.CurrentRow.Cells["DOC_NAME"].Value.ToString();
            txt_pet.Text = dataGridView1.CurrentRow.Cells["PET_ID"].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
            txt_type.Text = dataGridView1.CurrentRow.Cells["TYPE"].Value.ToString();
            cmb_vaccine.Text = dataGridView1.CurrentRow.Cells["VACCINE"].Value.ToString();
            txt_vaccine.Text = dataGridView1.CurrentRow.Cells["VACCINE_COST"].Value.ToString();
            txt_other.Text = dataGridView1.CurrentRow.Cells["OTHER_COST"].Value.ToString();
            txt_total.Text = dataGridView1.CurrentRow.Cells["TOTAL_COST"].Value.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        { 
            try
            {
                if (MessageBox.Show("Data Will Be Updated! Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = ("Update MEDICAL set MEDICAL_DATE='" + DatePicker.Value + "',DOC_ID='" + txt_doc.Text + "',DOC_NAME='" + txt_dr.Text + "',PET_ID='" + txt_pet.Text + "',NAME='" + txt_name.Text + "',TYPE='" + txt_type.Text + "',VACCINE='" + cmb_vaccine.SelectedItem.ToString() + "',VACCINE_COST='" + txt_vaccine.Text + "',OTHER_COST='" + txt_other.Text + "',TOTAL_COST='" + txt_total.Text + "' where MEDICAL_ID ='" + txt_medical.Text + "'");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
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

                    cmd.CommandText = ("Delete from MEDICAL where MEDICAL_ID ='" + txt_medical.Text + "'");
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

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search1_Click_1(object sender, EventArgs e)
        {
            String doc_id = txt_doc.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select FIRST_NAME + LAST_NAME From DOCTOR Where DOC_ID='" + doc_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_dr.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {

                txt_dr.Clear();
                txt_doc.Clear();
                MessageBox.Show("Invalid DOC_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            String pet_id = txt_pet.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select NAME,TYPE,EMAIL From PETS Where PET_ID='" + pet_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_name.Text = ds.Tables[0].Rows[0][0].ToString();
                txt_type.Text = ds.Tables[0].Rows[0][1].ToString();
                
            }
            else
            {
                txt_name.Clear();
                txt_type.ResetText();
                MessageBox.Show("Invalid PET_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }    
}
