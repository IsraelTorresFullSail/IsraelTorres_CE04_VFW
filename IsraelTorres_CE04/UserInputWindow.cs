using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Name: Israel Torres
 * Class: Visual Frameworks - Online (MDV1830-O)
 * Term: C201905 01
 * Code Exercise: ListViews
 * Number: CE04
 */

namespace IsraelTorres_CE04
{
    public partial class UserInputWindow : Form
    {
        public EventHandler ObjectAdded;
        public EventHandler DisplayObjectsStored;
        public EventHandler DisplayInputFormExist;

        public Characters Data
        {
            get
            {
                Characters c = new Characters();
                c.Age = numericUpDownAge.Value;
                c.FirstName = textBoxFirstName.Text;
                c.LastName = textBoxLastName.Text;
                c.Gender = comboBoxGender.Text;
                c.Immortal = checkBoxImmortal.Checked;
                c.Class = comboBoxClass.Text;
                c.ImageIndex = comboBoxClass.SelectedIndex;
                return c;
            }
            set
            {
                numericUpDownAge.Value = value.Age;
                textBoxFirstName.Text = value.FirstName;
                textBoxLastName.Text = value.LastName;
                comboBoxGender.Text = value.Gender;
                checkBoxImmortal.Checked = value.Immortal;
                comboBoxClass.Text = value.Class;
            }
        }

        private List<Characters> new_characters = null;

        public UserInputWindow()
        {
            InitializeComponent();

            new_characters = Characters.CharactersList;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Data = new Characters();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (ObjectAdded != null)
            {
                ObjectAdded(this, new EventArgs());
            }

            if (DisplayObjectsStored != null)
            {
                DisplayObjectsStored(this, new EventArgs());
            }

            Data = new Characters();
        }
        
        private void UserInputWindow_Load(object sender, EventArgs e)
        {
            if (DisplayInputFormExist != null)
            {
                DisplayInputFormExist(this, new EventArgs());
            }

        }

        private void UserInputWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DisplayInputFormExist != null)
            {
                DisplayInputFormExist(this, new EventArgs());
            }
        }
    }
}
