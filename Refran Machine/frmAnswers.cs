using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace Refran_Machine
{
    public partial class frmAnswers : Form
    {
        List<string> sayingsList = new List<string>();

        public frmAnswers()
        {
            InitializeComponent();
            LoadToList();

            List<string> OrigList = new List<string>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = Grammar2(txtSearch.Text.Replace(".", "").Replace(",", "").Trim().ToLower());

            lstSayings.Items.Clear();

            foreach (string saying in sayingsList)
            {
                string cleanSay = Grammar2(saying.Replace(".", "").Replace(",", "").Trim().ToLower());

                if (cleanSay.Contains(searchQuery))
                {
                    lstSayings.Items.Add(saying);
                }
            }

            txtSearch.Select();
        }

        private void LoadToList()
        {
            var resourceName = "Refran_Machine.Refranes.txt";
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                // Clear items from list
                lstSayings.Items.Clear();

                // Access the embedded resource stream
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Read and load lines from the embedded resource
                    sayingsList = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sayingsList.Add(line);
                        lstSayings.Items.Add(line);
                    }
                }
            }
            catch (Exception ex) // Error if load fails
            {
                MessageBox.Show($"Failed to load sayings from embedded resource: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Grammar2(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstSayings.Items.Clear();

            //Adding saying per item on list
            foreach (string saying in sayingsList)
            {
                lstSayings.Items.Add(saying);

            }

            txtSearch.Select();
        }
    }
}
