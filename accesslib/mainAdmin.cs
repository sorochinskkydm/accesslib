using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accesslib
{
    public partial class mainAdmin : Form
    {
        public mainAdmin()
        {
            InitializeComponent();
        }

        private void mainAdmin_Load(object sender, EventArgs e)
        {
            database db = new database();
            adminData adminData = new adminData();
            MySqlCommand command = new MySqlCommand("SELECT `id`, `surname`, `name`, `email`, `access` FROM `userstable` WHERE `access` = 0", db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;

            label2.Text = $"Добро пожаловать, {adminData.nameOfAdmin}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainAdmin mainAdminForm = new mainAdmin();
            this.Hide();
            mainAdminForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registration registrationForm = new registration();
            registrationForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            removeUser removeUserForm = new removeUser();
            removeUserForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            auth authForm = new auth();
            authForm.Show();
            this.Hide();
        }
    }
}
