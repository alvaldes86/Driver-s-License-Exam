using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;



namespace Driver_s_License_Exam
{
    public partial class Form1 : Form
    {

        
        private int pageIndex = 0;
        private List<string> questions = new List<string>
    {
        "Question 1",
        "Question 2",
        "Question 3",
        "Question 4",
        "Question 5",
        "Question 6",
        "Question 7",
        "Question 8",
        "Question 9",
        "Question 10"
        
    };
        private List<string[]> answers = new List<string[]>
    {
        new string[] { "Answer 1a", "Answer 1b", "Answer 1c", "Answer 1d" },
        new string[] { "Answer 2a", "Answer 2b", "Answer 2c", "Answer 2d" },
        new string[] { "Answer 3a", "Answer 3b", "Answer 3c", "Answer 3d" },
        new string[] { "Answer 4a", "Answer 4b", "Answer 4c", "Answer 4d" },
        new string[] { "Answer 5a", "Answer 5b", "Answer 5c", "Answer 5d" },
        new string[] { "Answer 6a", "Answer 6b", "Answer 6c", "Answer 6d" },
        new string[] { "Answer 7a", "Answer 7b", "Answer 7c", "Answer 7d" },
        new string[] { "Answer 8a", "Answer 8b", "Answer 8c", "Answer 8d" },
        new string[] { "Answer 9a", "Answer 9b", "Answer 9c", "Answer 9d" },
        new string[] { "Answer 10a", "Answer 10b", "Answer 10c", "Answer 10d" },
    };

        const int ROWS = 10;
        const int COLUMNS = 4;
        int[,] selectedAnsweres = new int[ROWS,COLUMNS];

        private List<bool> selectedQuestions = new List<bool>();

        public Form1()
        {
            InitializeComponent();

            

        }
        
        //displays the question and answers base on the pageIndex value
        private void DisplayQuestion()
        {
            lblOutputQuestion.Text = questions[pageIndex];
            lblOptionA.Text = answers[pageIndex][0];
            lblOptionB.Text = answers[pageIndex][1];
            lblOptionC.Text = answers[pageIndex][2];
            lblOptionD.Text = answers[pageIndex][3];          
        }


        private void ClearCheckBoxes()
        {
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;
        }

        private void SelectedQuestions()
        {
            if (checkBoxA.Checked)
            {
                selectedAnsweres[pageIndex, 0] = 1;                
            }
            else if (checkBoxB.Checked)
            {
                selectedAnsweres[pageIndex,1] = 2;
            }
            else if (checkBoxC.Checked)
            {
                selectedAnsweres[pageIndex,2] = 3;
            }
            else if (checkBoxD.Checked)
            {
                selectedAnsweres[pageIndex,3] = 4;
            }
        }

        private int SequentialSearch()
        {
            int A = 1;
            int B = 2;

            bool found = false; //flag for search results

            int index = 0;  //step through array

            int position = -1;  //position of value if found


            while (!found && index < selectedAnsweres.Length)
            {
                if (selectedAnsweres[pageIndex,0] == A)
                {
                    found = true;
                    position = index;
                    
                }
                index++;
            }



            return position;
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayQuestion(); 
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(selectedAnsweres[pageIndex,0] == 1)
            {
                checkBoxA.Checked = true;
            }
            else if(selectedAnsweres[pageIndex, 1] == 2)
            {
                checkBoxB.Checked = true;
            }
            else if (selectedAnsweres[pageIndex, 1] == 3)
            {
                checkBoxC.Checked = true;
            }
            else if (selectedAnsweres[pageIndex, 1] == 4)
            {
                checkBoxD.Checked = true;
            }


            pageIndex--;


            if (pageIndex == -1)
            {
                pageIndex = 9;

            }

            
            DisplayQuestion();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            

            if (!checkBoxA.Checked && !checkBoxB.Checked && !checkBoxC.Checked && !checkBoxD.Checked)
            {
                MessageBox.Show("Please select a box");
            }
            else
            {
                pageIndex++;


                if (pageIndex == 10)
                {
                    pageIndex = 0;

                }

                DisplayQuestion();

                SelectedQuestions();

                ClearCheckBoxes();
            }

        }
    }
}