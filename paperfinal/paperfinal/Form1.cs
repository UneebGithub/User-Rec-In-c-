using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paperfinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TailorMsDataContext db;


        private void button1_Click(object sender, EventArgs e)
        {
            //insert data 
            db = new TailorMsDataContext();

            loginnn ld = new loginnn();

            ld.username = textBox1.Text;
            ld.pass = textBox2.Text;

            db.loginnns.InsertOnSubmit(ld);
            db.SubmitChanges();
            MessageBox.Show("Submit successfully");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete data
            string user = textBox1.Text;
            var del = db.loginnns.FirstOrDefault(u => u.username == user);
            db.loginnns.DeleteOnSubmit(del);
            db.SubmitChanges();
            MessageBox.Show("dATA DEL");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update data;

            var user = textBox1.Text;

            loginnn lg = db.loginnns.FirstOrDefault(s => s.username == user);
            lg.username = textBox1.Text;
            lg.pass = textBox2.Text;


            db.loginnns.InsertOnSubmit(lg);
            db.SubmitChanges();
            MessageBox.Show("Data update  successfully");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            db=new TailorMsDataContext();   
            try
            {
                var display = from d in db.loginnns
                              select d;


              
                    dataGridView1.DataSource = display;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
    

