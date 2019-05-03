using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static WindowsFormsApplication3.ProjectBDataSet;

namespace WindowsFormsApplication3
{
    public partial class manage_clos : Form
      
    {
        int Id;
        public string cons = "Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True";
        public manage_clos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");  
            string query = "INSERT INTO Clo VALUES (@Name,@DateCreated,@DateUpdated)";
            SqlCommand command = new SqlCommand(query, cons);
          
            command.Parameters.AddWithValue("@Name", txtname.Text.ToString());
            command.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("MM/dd/yyy  hh:mm tt"));
            command.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString("MM/dd/yyy  hh:mm tt"));
            cons.Open();
            int q = command.ExecuteNonQuery();
 
            if (q  != 0)
            {
                MessageBox.Show(q  + "Data Saved");
            }
            cons.Close();
        }
        private void manage_clos_Load(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
            cons.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Clo", cons);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            // TODO: This line of code loads data into the 'projectBDataSet.Clo' table. You can move, or remove it, as needed.
            cons.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
 


           

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
           
            try
            {
                cons.Open();
                if (txtname.Text != "" && DateTime.Now.ToString("MM/dd/yyy  hh:mm tt") != "" && DateTime.Now.ToString("MM/dd/yyy  hh:mm tt") !="")
                {

                    SqlCommand cmd = new SqlCommand("update Clo set Name=@name,DateCreated=@datecreated,DateUpdated=@dateupdated", cons);

                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("MM/dd/yyy  hh:mm tt"));
                    cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString("MM/dd/yyy  hh:mm tt"));

       

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


        private void btn_deleteclo_Click(object sender, EventArgs e)
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
        
    }
}