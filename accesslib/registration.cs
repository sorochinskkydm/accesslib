using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accesslib
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String surname = textBox1.Text;
            String name = textBox2.Text;
            String Email = textBox3.Text;
            String userLogin = textBox4.Text;
            String userPassword = textBox5.Text;

            database db = new database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand registerCommand = new MySqlCommand(
                "INSERT INTO `userstable` (`login`, `password`, `surname`, `name`, `email`)" +
                " VALUES (@ul, @up, @sn, @n, @mail)", db.getConnection());

            registerCommand.Parameters.Add("@ul", MySqlDbType.VarChar).Value = userLogin;
            registerCommand.Parameters.Add("@up", MySqlDbType.VarChar).Value = userPassword;
            registerCommand.Parameters.Add("@sn", MySqlDbType.VarChar).Value = surname;
            registerCommand.Parameters.Add("@n", MySqlDbType.VarChar).Value = name;
            registerCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Email;

            adapter.SelectCommand = registerCommand;
            adapter.Fill(dt);

            this.Hide();
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
