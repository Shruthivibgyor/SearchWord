using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampleFindWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// get the filepath when clicked btnbrowse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string tempath = string.Empty;
           {
                

                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                try
                {
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        tempath = folderDlg.SelectedPath;
                    }

                    textBox1.Text = tempath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }  

        }
        /// <summary>
        /// to search a word when clicked btnsearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string filepath = textBox1.Text;
            btnSearch.Enabled = false;
            BtnBrowse.Enabled = false;
            try
            {
                string searchword = textBox2.Text;
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please Enter a Word to Search");
                }
                else
                {
                    GetTotalWordCountAsync(filepath, searchword);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        /// <summary>
        /// to get the totalcount of the word and time taken to search
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="SearchWord"></param>
        /// <returns></returns>
        public async Task GetTotalWordCountAsync(string Path, string SearchWord)
        {
            Stopwatch watch = new Stopwatch();
            int totalcount = 0;
            try
            {
                SearchForwordAsync objSearch = new SearchForwordAsync();
                watch.Start();
                 totalcount = await Task.Run(() => objSearch.SearchWord(Path, SearchWord));
                watch.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            txtOutput.Text = "Elapsed time" + watch.Elapsed.ToString()  + "Word Count :" + totalcount.ToString();

            btnSearch.Enabled = true;

            BtnBrowse.Enabled = true;
        }

       
    }
}
