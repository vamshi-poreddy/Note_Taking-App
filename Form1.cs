using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notetaking
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing=  false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Message");

            SavedNotes.DataSource = notes;
            SavedNotes.Columns["Message"].Visible = false;
            SavedNotes.Columns["Title"].Width = 210;
        }


        private void btNew_Click(object sender, EventArgs e)
        {
            textTitle.Text = "";
            textMsg.Text = "";
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[SavedNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Select a Valid Entry");
            }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            textTitle.Text = notes.Rows[SavedNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            textMsg.Text = notes.Rows[SavedNotes.CurrentCell.RowIndex].ItemArray[1].ToString();

            editing = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[SavedNotes.CurrentCell.RowIndex]["Title"] = textTitle.Text;
                notes.Rows[SavedNotes.CurrentCell.RowIndex]["Message"] = textMsg.Text;
            }
            else
            {
                Console.WriteLine(textTitle.Text.ToString());
                Console.WriteLine(textMsg.Text.ToString());
                var f = textTitle.Text.ToString() != "" ? textTitle.Text.ToString() : "No Title";
                notes.Rows.Add(f, textMsg.Text);
            }
            textTitle.Text="";
            textMsg.Text="";
            editing= false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SavedNotes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textTitle.Text = notes.Rows[SavedNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            textMsg.Text = notes.Rows[SavedNotes.CurrentCell.RowIndex].ItemArray[1].ToString();

            editing = true;
        }
    }
}
