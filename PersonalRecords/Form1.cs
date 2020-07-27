using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Xml;
using System.Xml.Serialization;

namespace PersonalRecords
{
    public partial class Form1 : Form
    {
        private void SerializeDb()
        {
            var xmlSer = new XmlSerializer(typeof(List<Person>));
            string fileName = String.Format("PersonDB.xml");
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate);
            xmlSer.Serialize(fs, _theDb);
            fs.Close();
        }

        public void InsertPerson(Person person)
        {            
            _theDb.Add(person);
            listBox1.Items.Add(person);
            SerializeDb();
        }

        public void DeletePerson(int index)
        {
            _theDb.RemoveAt(index);
            SerializeDb();
        }

        public void DeletePerson(List<int> indices)
        {
            foreach(int idx in indices)
            {
                _theDb.RemoveAt(idx);
            }
           SerializeDb();
        }

        public void UpdatePerson(Person person, int index)
        {
            _theDb.RemoveAt(index);
            _theDb.Insert(index,person);
            SerializeDb();
        }

        private List<Person> _theDb = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void OnDelete_Click(object sender, EventArgs e)
        {
            var indices = this.listView1.SelectedIndices.Cast<int>();
            /*foreach (var idx in indices)
            {
                DeletePerson(idx);
            }*/
            DeletePerson(indices.ToList<int>());
            
            SerializeDb();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void onStore_Click(object sender, EventArgs e)
        {
            //var newPerson = new Person { FirstName = firstNameTb.Text, LastName = lastNameTb.Text, Age = this.ageTb.Text };
            InsertPerson(new Person { FirstName = firstNameTb.Text, LastName = lastNameTb.Text, Age = this.ageTb.Text });
        }
    }
}
