using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentsApp
{
    public partial class AddForm : Form
    {
        public Agents agents { get; set; } = null;
        public ModelDB db { get; set; }
        public AddForm()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (TypeAgent_ComboBox.Text == "" || Name_Box.Text == "" || Email_Box.Text == "" || Phone_Box.Text == "" ||
              Address_Box.Text == "" || Priority_Box.Text == "" || Director_Box.Text == "" || INN_Box.Text == "" ||
              KPP_Box.Text == "")
            {
                MessageBox.Show("Необходимо ввести все требуемые данные");
                return;
            }
            if (agents == null)
            {
                Agents agents = new Agents
                {
                    Type_Of_Agent = TypeAgent_ComboBox.Text,
                    Name = Name_Box.Text,
                    email = Email_Box.Text,
                    Phone = Phone_Box.Text,
                    Address = Address_Box.Text,
                    Priority = Priority_Box.Text,
                    Director = Director_Box.Text,
                    INN = INN_Box.Text,
                    KPP = KPP_Box.Text
                };
                db.Agents.Add(agents);
            }
            else
            {
                agents.ID = Convert.ToInt32(IDBox.Text);
                agents.Type_Of_Agent = TypeAgent_ComboBox.Text;
                agents.Name = Name_Box.Text;
                agents.email = Email_Box.Text;
                agents.Phone = Phone_Box.Text;
                agents.Address = Address_Box.Text;
                agents.Priority = Priority_Box.Text;
                agents.Director = Director_Box.Text;
                agents.INN = INN_Box.Text;
                agents.KPP = KPP_Box.Text;
            }
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            /* if (agents == null)
             {
                 this.Text = "Добавление пользователя";
             }
             else
             {
                 this.Text = "Изменение пользователя";
                 IDBox.Text = Convert.ToString(agents.ID);
                 TypeAgent_ComboBox.Text = agents.Type_Of_Agent;
                 Name_Box.Text = agents.Name;
                 Email_Box.Text = agents.email;
                 Phone_Box.Text = agents.Phone;
                 Address_Box.Text = agents.Address;
                 Priority_Box.Text = agents.Priority;
                 Director_Box.Text = agents.Director;
                 INN_Box.Text = agents.INN;
                 KPP_Box.Text = agents.KPP;
             }*/

        }
    }
}
