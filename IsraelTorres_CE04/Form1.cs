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
    public partial class MainWindow : Form
    {
        UserInputWindow userInputWindow;
        ListViewForm lvf;

        public EventHandler ClearMeAndListView;

        private List<Characters> new_characters = null;

        public MainWindow()
        {
            InitializeComponent();

            new_characters = Characters.CharactersList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ObjectAddedHandler(object sender, EventArgs e)
        {
            userInputWindow = sender as UserInputWindow;
            Characters c = userInputWindow.Data;

            if (!String.IsNullOrEmpty(c.ToString()))
            {
                new_characters.Add(c);
            }
        }

        public void DisplayObjectsStoredHandler(object sender, EventArgs e)
        {
            userInputWindow = sender as UserInputWindow;

            int count = 0;

            for (int i = 0; i < new_characters.Count; i++)
            {
                count ++;
            }

            textBoxObjetsStoredInListView.Text = count.ToString();
        }

        public void DisplayInputFormExistHandler(object sender, EventArgs e)
        {
            userInputWindow = sender as UserInputWindow;

            int count = 0;
            for (int i = 0; i < Application.OpenForms.Count - 1; i++)
            {
                if (Application.OpenForms[i].Visible == true)
                {
                    count++;
                }
            }
            textBoxUserImputWindowsExist.Text = count.ToString(); 
        }

        public void buttonNewInputWindow_Click(object sender, EventArgs e)
        {
            userInputWindow = new UserInputWindow();
            lvf = new ListViewForm();

            userInputWindow.ObjectAdded += ObjectAddedHandler;

            userInputWindow.DisplayObjectsStored += DisplayObjectsStoredHandler;

            userInputWindow.DisplayInputFormExist += DisplayInputFormExistHandler;

            userInputWindow.Show();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInputWindow = new UserInputWindow();
            lvf = new ListViewForm();

            bool open = false;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "ListViewForm")
                {
                    open = true;
                    frm.Select();
                    break;
                }
            }
            if (open == false)
            {
                lvf.Show();

                displayToolStripMenuItem.Checked = true;  // TODO: Re-size checked icon
            }

            lvf.UncheckToolStripMenuItem += UncheckToolStripMenuItemHandle;

            ClearMeAndListView += lvf.ClearMeAndListViewHandler;

            lvf.ClearMeAndTextBox += ClearMeAndTextBoxHandler;

            lvf.DisplayInputFormExistSecond += DisplayInputFormExistHandler;
        }

        public void UncheckToolStripMenuItemHandle(object sender, EventArgs e)
        {
           lvf = new ListViewForm();

            bool open = true;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "ListViewForm")
                {
                    open = false;
                    frm.Select();
                    break;
                }
            }
            if (open == true)
            {
                lvf.Close();

                displayToolStripMenuItem.Checked = false;
            }
        }

        public void ClearMeAndTextBoxHandler(object sender, EventArgs e)
        {
            lvf = sender as ListViewForm;

            textBoxObjetsStoredInListView.Text = "0";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxObjetsStoredInListView.Text = "0";
            new_characters.Clear();

            if(ClearMeAndListView != null)
            {
                ClearMeAndListView(this, new EventArgs());
            }
        }
    }
}
