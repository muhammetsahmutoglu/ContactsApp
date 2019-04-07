using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telephone.DAL.ORM.Context;
using Telephone.DAL.ORM.Entity;
using Telephone.DAL.ORM.Enum;

namespace Telephone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAddFirstName.Text==""||txtAddLastName.Text==""||!txtaddphone.MaskFull)
            {
                MessageBox.Show("Please enter all needed info!");
            }
            else
            {
                AppUser user = new AppUser();
                user.FirstName = txtAddFirstName.Text;
                user.LastName = txtAddLastName.Text;
                user.PhoneNumber = txtaddphone.Text;
                db.AppUsers.Add(user);
                db.SaveChanges();
                txtAddFirstName.Clear();
                txtAddLastName.Clear();
                txtaddphone.Clear();
                MessageBox.Show("Contact added successfully!");
                dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Update).ToList();
            }      
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Update).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtDeleteUser.Text=="")
            {
                MessageBox.Show("please enter ID!");
            }
            else
            {
                int userID = Convert.ToInt32(txtDeleteUser.Text);
                AppUser user = new AppUser();
                user = db.AppUsers.FirstOrDefault(x => x.ID == userID);
                user.Status = Status.Delete;
                db.SaveChanges();
                txtDeleteUser.Clear();
                MessageBox.Show("Contact deleted successfully!");
                dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Update).ToList();
            }
            


        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please enter all needed info!");
            }
            else if (txtUpdateFirstName.Text == "" || txtUpdateLastName.Text == "" || !txtUpdatePhone.MaskFull)
            {
                MessageBox.Show("Please enter all needed info!");
            }
            else
            {
                int userID = Convert.ToInt32(textBox1.Text);
                AppUser user = new AppUser();
                user = db.AppUsers.FirstOrDefault(x => x.ID == userID);
                user.FirstName = txtUpdateFirstName.Text;
                user.LastName = txtUpdateLastName.Text;
                user.PhoneNumber = txtUpdatePhone.Text;
                user.Status = (Status)Enum.Parse(typeof(Status), " Update");
                db.SaveChanges();
                MessageBox.Show("Contact updated successfully!");
                dataGridView1.DataSource = db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Update).ToList();
                txtUpdateFirstName.Clear();
                txtUpdateLastName.Clear();
                txtUpdatePhone.Clear();
                textBox1.Clear();
            }
           


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("please enter ID!");
            }
            else
            {
                int userID = Convert.ToInt32(textBox1.Text);
                AppUser user = new AppUser();
                user = db.AppUsers.FirstOrDefault(x => x.ID == userID);
                txtUpdateFirstName.Text = user.FirstName;
                txtUpdateLastName.Text = user.LastName;
                txtUpdatePhone.Text = user.PhoneNumber;
            }
            

            

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}