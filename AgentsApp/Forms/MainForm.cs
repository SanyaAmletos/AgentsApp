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
    public partial class MainForm : Form
    {
        public ModelDB db = new ModelDB();
            
        public Agents ag { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm();
            //addform.Show();
            addform.db = db;
            if(addform.ShowDialog() ==  DialogResult.OK)
            {
                agentsBindingSource.DataSource = db.Agents.ToList();
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            Agents ag = (Agents)agentsBindingSource.Current;
            DialogResult dr = MessageBox.Show(
                "Вы действительно хотите удалить агента - " + ag.ID.ToString(),
                "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Agents.Remove(ag);
            }
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            agentsBindingSource.DataSource = db.Agents.ToList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            agentsBindingSource.DataSource = db.Agents.ToList();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            Agents agents = (Agents)agentsBindingSource.Current;
            AddForm addform = new AddForm();
            addform.db = db;
            addform.agents = agents;
            if(addform.ShowDialog() == DialogResult.OK)
            {
                agentsBindingSource.DataSource = db.Agents.ToList();
            }
        }
    }
}
