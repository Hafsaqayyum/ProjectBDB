using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication3
{
    public partial class manage_rubrics : Form
    {
        int Id;
        public string cons = "Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True";
        public manage_rubrics()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_addrubric_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
            string query = "INSERT INTO Rubric VALUES (@CloId, @Details)";
            SqlCommand command = new SqlCommand(query, cons);
            command.Parameters.AddWithValue("@CloId", Convert.ToInt32 (txtcloid.Text));
            command.Parameters.AddWithValue("@Details", txtdetailrubric.Text.ToString());
            cons.Open();
            int i = command.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show(i + "Data Saved");
            }
            cons.Close();

        }


        private void txtdetailrubric_TextChanged(object sender, EventArgs e)
        {

        }

        private void manage_rubrics_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet.Rubric);

        }

        private void txtcloid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_deleterubric_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
            if (Id != 0)
            {
                SqlCommand cmd = new SqlCommand("delete Student where Id=@id", cons);
                cons.Open();
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                cons.Close();
                MessageBox.Show("Record Deleted Successfully!");

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void btn_updaterubric_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");

            try
            {
                cons.Open();
                if (txtcloid.Text != "" && txtdetailrubric.Text != "")
                {

                    SqlCommand cmd = new SqlCommand("update Rubric set CloId=@CloId,Details=@Details", cons);

                    cmd.Parameters.AddWithValue("@CloId", txtcloid.Text);
                    cmd.Parameters.AddWithValue("@Details", txtdetailrubric.Text);



                    cmd.Parameters.AddWithValue("@id", this.Id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Updated Successfully");


                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
                cons.Close();

            }


            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                cons.Open();
            }

            finally
            {
                cons.Close();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
            try
            {



                cons.Open();

                SqlCommand cmd = new SqlCommand("select * from Rubric", cons);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                dataGridView1.DataSource = ds.Tables["ss"]; ;
                cons.Close();

                // dataGridView1.DataBind();

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }
    }
}
    
 