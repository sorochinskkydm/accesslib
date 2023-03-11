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
    public partial class removeUser : Form
    {
        public removeUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string request = $"DELETE FROM `userstable` WHERE `userstable`.`id` = {textBox1.Text}";
            database db = new database();
            MySqlCommand command = new MySqlCommand(request, db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);

            this.Hide();
        }
    }
}
