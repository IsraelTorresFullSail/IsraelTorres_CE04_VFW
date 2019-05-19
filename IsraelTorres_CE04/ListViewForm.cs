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
    public partial class ListViewForm : Form
    {
        UserInputWindow userInputWindow;
        MainWindow mw;
        
        public EventHandler ClearMeAndTextBox;
        public EventHandler UncheckToolStripMenuItem;
        public EventHandler DisplayInputFormExistSecond;

        private List<Characters> new_characters = null;

        public ListViewForm()
        {
            InitializeComponent();

            new_characters = Characters.CharactersList;
        }

        private void ListViewForm_Load(object sender, EventArgs e)
        {
            foreach (var item in new_characters)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ToString();
                lvi.ImageIndex = item.ImageIndex;
                lvi.Tag = item;

                listView1.Items.Add(lvi);
            }

        }

        public void ClearMeAndListViewHandler(object sender, EventArgs e)
        {
            mw = sender as MainWindow;

            listView1.Items.Clear();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            new_characters.Clear();

            if(ClearMeAndTextBox != null)
            {
                ClearMeAndTextBox(this, new EventArgs());
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Open and poputate input form

            userInputWindow = new UserInputWindow();

            foreach (var itemList in new_characters)
            {
                if (listView1.SelectedItems.Count > 0 && itemList == listView1.SelectedItems[0].Tag)
                {
                    userInputWindow.textBoxFirstName.Text = itemList.FirstName;
                    userInputWindow.textBoxLastName.Text = itemList.LastName;
                    userInputWindow.numericUpDownAge.Value = itemList.Age;
                    userInputWindow.comboBoxGender.Text = itemList.Gender;
                    userInputWindow.checkBoxImmortal.Checked = itemList.Immortal;
                    userInputWindow.comboBoxClass.Text = itemList.Class;
                }
            }

            if(DisplayInputFormExistSecond != null)
            {
                DisplayInputFormExistSecond(this, new EventArgs());
            }

            userInputWindow.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Large Icons":
                    listView1.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    listView1.View = View.SmallIcon;
                    break;
                default:
                    break;
            }
        }

        private void ListViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UncheckToolStripMenuItem != null)
            {
                UncheckToolStripMenuItem(this, new EventArgs());
            }
        }
    }
}
