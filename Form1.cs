using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace BalanceCheckerWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] alladdress = textBox1.Text.Split('\n');
                dataGridView1.Rows.Clear();
                int i=1;
                foreach (string address in alladdress)
                {
                    // query balance and load into grid
                    if (address.Trim() != "")
                    {
                        string url = "";
                        url = "https://blockchain.info/q/addressbalance/" + address.Trim();
                        var response = new WebClient().DownloadString(url);
                        //MessageBox.Show(response);                            
                        decimal g = Convert.ToDecimal(response) / 100000000;
                        //i++;
                        //if (g > 0)
                        //{
                        dataGridView1.Rows.Add(i++, address, g.ToString());

                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
