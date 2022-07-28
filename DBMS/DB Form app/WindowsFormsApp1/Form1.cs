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
using System.Configuration;
using System.Collections;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlDataAdapter daFirst, daSecond;
        DataSet ds;
        SqlCommandBuilder cbFirst, cbSecond;
        BindingSource bsFirst, bsSecond;


        private string getSqlConnection()
        {
            return ConfigurationManager.ConnectionStrings["connection"].ConnectionString.ToString();
        }

        private string getFirstTable()
        {
            return ConfigurationManager.AppSettings.Get("first_table");
        }

        private string getSecondTable()
        {
            return ConfigurationManager.AppSettings["second_table"];
        }

        private string getFirstTableQuery()
        {
            return ConfigurationManager.AppSettings["first_table_query"];
        }

        private string getSecondTableQuery()
        {
            return ConfigurationManager.AppSettings["second_table_query"];
        }

        private string getPK()
        {
            return ConfigurationManager.AppSettings["primary_key"];
        }

        private string getFK()
        {
            return ConfigurationManager.AppSettings["foreign_key"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            daSecond.InsertCommand = new SqlCommand("INSERT INTO Posts(PoDate, PoText, NoOfShares, Uid) VALUES(@d, @t, @n, @c)", connection);
            daSecond.InsertCommand.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Parse(textBox1.Text);
            daSecond.InsertCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = textBox2.Text;
            daSecond.InsertCommand.Parameters.Add("@n", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
            daSecond.InsertCommand.Parameters.Add("@c", SqlDbType.Int).Value = Int32.Parse(textBox4.Text);
            connection.Open();
            daSecond.InsertCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Added succesfully!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRowP = Int32.Parse(GridDepartment.SelectedRows[0].Cells[0].Value.ToString());
            daSecond.UpdateCommand = new SqlCommand("UPDATE Posts SET PoDate=@d, PoText=@t,NoOfShares = @n, Uid = @c WHERE Poid = @pid", connection);
            daSecond.UpdateCommand.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Parse(textBox1.Text);
            daSecond.UpdateCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = textBox2.Text;
            daSecond.UpdateCommand.Parameters.Add("@n", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
            daSecond.UpdateCommand.Parameters.Add("@c", SqlDbType.Int).Value = Int32.Parse(textBox4.Text);
            daSecond.UpdateCommand.Parameters.Add("@pid", SqlDbType.Int).Value = selectedRowP;
            connection.Open();
            daSecond.UpdateCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Updated succesfully!");
        }

        private void GridDeveloper_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedRowP = Int32.Parse(GridDeveloper.SelectedRows[0].Cells[0].Value.ToString());
            daSecond.DeleteCommand = new SqlCommand("DELETE FROM Posts WHERE Poid=@pid", connection);
            daSecond.DeleteCommand.Parameters.Add("@pid", SqlDbType.Int).Value = selectedRowP;
            connection.Open();
            daSecond.DeleteCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Deleted succesfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.daFirst.Update(ds, getFirstTable());
            this.daSecond.Update(ds, getSecondTable());

        }

        private void GridDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(getSqlConnection());
            ds = new DataSet();
            daFirst = new SqlDataAdapter(getFirstTableQuery(), connection);
            daSecond = new SqlDataAdapter(getSecondTableQuery(), connection);
            cbFirst = new SqlCommandBuilder(daFirst);
            cbSecond = new SqlCommandBuilder(daSecond);


            daFirst.Fill(ds, getFirstTable());
            daSecond.Fill(ds, getSecondTable());

            DataRelation dr = new DataRelation("FK_Department_GameDeveloper", ds.Tables[getFirstTable()].Columns[getPK()], ds.Tables[getSecondTable()].Columns[getFK()]);
            ds.Relations.Add(dr);

            bsFirst = new BindingSource();
            bsSecond = new BindingSource();

            bsFirst.DataSource = ds;
            bsFirst.DataMember = getFirstTable();

            bsSecond.DataSource = bsFirst;
            bsSecond.DataMember = "FK_Department_GameDeveloper";

            GridDepartment.DataSource = bsFirst;
            GridDeveloper.DataSource = bsSecond;
        }

     
    }
}
