using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAPPY_PETS
{
    public partial class FrmHappyPets : Form
    {
        public FrmHappyPets()
        {
            InitializeComponent();
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            VIEW_DOCTOR obj = new VIEW_DOCTOR();
            obj.Show();
            this.Hide();
        }

        private void btn_pet_Click(object sender, EventArgs e)
        {
            VIEW_PETS obj = new VIEW_PETS();
            obj.ShowDialog();
            this.Hide();
        }

        private void btn_medical_Click(object sender, EventArgs e)
        {
            MEDICAL obj = new MEDICAL();
            obj.ShowDialog();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTimeDate.Text = DateTime.Now.ToString();
        }

        private void report_open_click(object sender, EventArgs e)
        {
            /* Report report = new Report();
             report.Show();
             this.Hide();*/
            rpt obj = new rpt();
            obj.Show();
            this.Hide();
        }

        private void HAPPY_PETS_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
