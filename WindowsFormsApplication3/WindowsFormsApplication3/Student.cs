using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using static WindowsFormsApplication3.ProjectBDataSet;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int Id;
        SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_addstudent_Click(object sender, EventArgs e)
        {
            SqlConnection cons = new SqlConnection("Data Source=MAZHAR;Initial Catalog=ProjectB;Integrated Security=True");
            string query = "INSERT INTO Student VALUES (@FirstName, @LastName, @Contact, @Email,@RegistrationNumber,@Status)";
            SqlCommand command = new SqlCommand(query, cons);
            command.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
            command.Parameters.AddWithValue("@LastName", txtlastname.Text);
            command.Parameters.AddWithValue("@Contact", txtcontact.Text);
            command.Parameters.AddWithValue("@Email", txtemail.Text);

            command.Parameters.AddWithValue("@RegistrationNumber", txtregistrationnumber.Text);
            string status = comboBox1.Text;
            if (status == "Active")
            {
                command.Parameters.AddWithValue("@Status", 5);
            }
            else
            {
                command.Parameters.AddWithValue("@Status", 6);
            }
            cons.Open();
            int i = command.ExecuteNonQuery();

            

            if (i != 0)
            {
                MessageBox.Show(i + "Data Saved");
            }
            cons.Close();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_updatestudent_Click(object sender, EventArgs e)
        {
            
            try
            {
                cons.Open();
                if (txtfirstname.Text != "" && txtlastname.Text != "" && txtcontact.Text != "" && txtemail.Text != "" && txtregistrationnumber.Text != "")
                {
                    
                    SqlCommand cmd = new SqlCommand("update Student set FirstName=@firstname,LastName=@lastname,Contact=@contact,Email=@email,RegistrationNumber=@registrationnumber,Status=@status where Id=@id", cons);

                    cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@contact", txtcontact.Text);

                    cmd.Parameters.AddWithValue("@email", txtemail.Text);

                    cmd.Parameters.AddWithValue("@registrationnumber", txtregistrationnumber.Text);
                    string status = comboBox1.Text;
                    if (status == "Active")
                    {
                        cmd.Parameters.AddWithValue("@Status", 5);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", 6);
                    }

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
            catch(Exception ex)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

               
     
                cons.Open();

                SqlCommand cmd = new SqlCommand("select * from Student", cons);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtfirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            txtcontact.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtregistrationnumber.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btn_deletestudent_Click(object sender, EventArgs e)
        {
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
   

