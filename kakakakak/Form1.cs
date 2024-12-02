using System.Data;
using System.Data.SqlClient;
namespace kakakakak
{
    public partial class Form1 : Form
    {
        private SqlConnection connect;
        public Form1()
        {
            InitializeComponent();
            connect = new("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nadyb\\source\\repos\\kakakakak\\kakakakak\\Database1.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect.Open();
            SqlDataAdapter sqlDataAdapter = new(
                "select * from Customers",
                connect
                );
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new(
                $"insert into Territories (TerritoryID,TerritoryDescription,RegionID) values(N'{textBox1.Text}',N'{textBox2.Text}',{int.Parse(textBox3.Text)})",
                connect
                );
            command.ExecuteNonQuery();
        }
    }
}
