using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace Refran_Machine
{
    public partial class frmGame : Form
    {
        private List<string> sayings = new List<string>();
        private Random random = new Random();
        
        //Current saying index
        private int curSayingIndex = -1;
        //Storing the correct answer for a given saying
        private string strAnswer = "";
        //To keep track of the original list
        private List<string> lstOriginalSay;
        //To keep track of minimum word count
        private int minimumWordCount = int.MaxValue;


        public frmGame()
        {
            InitializeComponent();
            
            //Calling the load saying function
            LoadSayings();
            //Copy sayings list for reset
            lstOriginalSay = new List<string>(sayings);

            //Calling the display random saying function
            DisplayRandomSaying();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            //To hold the user answer, while also ignoring periods, accents and comas for the comparison
            string strUserAnswer = Grammar(txtAnswer.Text.Replace(".", "").Replace(",", "").Trim());
            //To hold the correct answer and ignore periods, accents and comas when comparing
            string strCorrect = Grammar(strAnswer.Replace(".", "").Replace(",", "").Trim());

            //If user answer equals correct answer (while ignoring case sensitivity) then the answer is correct
            if(strUserAnswer.Equals(strCorrect, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Correct!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Remove the current saying
                sayings.RemoveAt(curSayingIndex);
                //Show next saying 
                DisplayRandomSaying();
                //Clear textbox
                txtAnswer.Clear();
                //Shift focus to textbox
                txtAnswer.Select();
            }
            else //If the user answer is incorrect, display error and show correct answer.
            {
                MessageBox.Show($"Incorrect. The correct answer is: '{strAnswer}'", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Shift focus to textbox
                txtAnswer.Select();
            }
        }

        //To change the saying
        private void btnNext_Click(object sender, EventArgs e)
        {
            DisplayRandomSaying();
            //Select the textbox to answer
            txtAnswer.Select();
        }

        //Resets the game
        private void btnStartOver_Click(object sender, EventArgs e)
        {
            ResetGame();
            //Shift focus back to the textbox
            txtAnswer.Select();
        }

        //For loading the sayings text file
        private void LoadSayings()
        {
            // Get the current assembly where the resources are embedded
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Refran_Machine.Refranes.txt";

            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    sayings.Clear(); // Clear existing sayings
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sayings.Add(line);
                        int wordCount = line.Split(' ').Length;
                        if (wordCount < minimumWordCount)
                        {
                            minimumWordCount = wordCount; // Update minimum word count
                        }
                    }
                }
                // Optionally, you can log the minimum word count after loading
                Console.WriteLine($"Minimum word count in sayings: {minimumWordCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sayings from embedded resource: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayRandomSaying()
        {
            //If sayings are available...
            if(sayings.Count > 0)
            {
                do
                {
                    //Randomizer to select sayings
                    int index = random.Next(sayings.Count);

                    //If the saying index is not equal to the current saying index being displayed...
                    if (index != curSayingIndex)
                    {
                        //Registers the current saying being used
                        curSayingIndex = index;

                        //Choosing random saying
                        string saying = sayings[index];
                        //Splits saying
                        string[] words = saying.Split(' ');
                        int midpoint = GetSplitIndex(words);

                        //First half of the saying for display
                        string firstHalf = string.Join(" ", words, 0, midpoint) + "...";
                        //Second half of the saying for answer
                        strAnswer = string.Join(" ", words, midpoint, words.Length - midpoint).Trim();
                        //Display first half of the saying
                        lblRefran.Text = firstHalf;
                        break;
                    }
                    
                } while (true);
            }
            else //No more sayings available
            {
                lblRefran.Text = "There are no more Refranes. You are a sociopath";
            }
        }

        //For determening the appropriate split index on a given saying 
        private int GetSplitIndex(string[] words)
        {
            //Ensure at least half of the shortest phrase is shown
            int minWordsToShow = Math.Max(3, minimumWordCount / 2);
            int splitPercent = 50;
            int calcIndex = words.Length * splitPercent / 100;

            return Math.Max(minWordsToShow, calcIndex);
        }

        //Getting rid of accents and the letter ñ 
        private static string Grammar(string text)
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

        //Will reset the game
        private void ResetGame()
        {
            //Reset sayings list
            sayings = new List<string>(lstOriginalSay);
            //Reset the current saying index
            curSayingIndex = -1;
            //Display new saying
            DisplayRandomSaying();
        }

        //To change to the Help window
        private void mnuHelp_Click(object sender, EventArgs e)
        {
            frmHelp frmHelp = new frmHelp();

            frmHelp.ShowDialog();
        }

        //To change to the answers window
        private void mnuAnswers_Click(object sender, EventArgs e)
        {
            frmAnswers frmAnswers = new frmAnswers();

            frmAnswers.ShowDialog();
        }

        //Closes the app
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
