using System.Windows.Forms;

namespace WFA_exam___Pádár_Zsolt
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();

        public Form1()
        {

            InitializeComponent();

            btnCheck.Enabled = false;

            btnNew.Click += BtnNew_Click;
            btnExit.Click += BtnExit_Click;
            btnCheck.Click += BtnCheck_Click;

            nud1.Minimum = int.MinValue;
            nud1.Maximum = int.MaxValue;

            nud2.Minimum = int.MinValue;
            nud2.Maximum = int.MaxValue;

            nud3.Minimum = int.MinValue;
            nud3.Maximum = int.MaxValue;

            nud4.Minimum = int.MinValue;
            nud4.Maximum = int.MaxValue;

            nud5.Minimum = int.MinValue;
            nud5.Maximum = int.MaxValue;

        }
        private void BtnCheck_Click(object? sender, EventArgs e)
        {

            btnCheck.Enabled = false;
            int correctAnswers = 0;

            CheckAnswer(nud1, lbl1, ref correctAnswers);
            CheckAnswer(nud2, lbl2, ref correctAnswers);
            CheckAnswer(nud3, lbl3, ref correctAnswers);
            CheckAnswer(nud4, lbl4, ref correctAnswers);
            CheckAnswer(nud5, lbl5, ref correctAnswers);

            richTxtBox1.Text = $"Helyes válaszok száma: {correctAnswers}";

        }

        private void CheckAnswer(NumericUpDown numericUpDown, Label label, ref int correctAnswers)
        {

            string[] expression = label.Text.Split(' ');

            if (decimal.TryParse(expression[0], out decimal operand1) &&
                decimal.TryParse(expression[2], out decimal operand2))
            {
                decimal expressionResult = expression[1] == "+" ? operand1 + operand2 : operand1 - operand2;

                if (numericUpDown.Value == expressionResult)
                {
                    correctAnswers++;   
                    label.ForeColor = Color.Green;
                }
                else
                {
                    label.ForeColor = Color.Red;
                }
            }
        }

        private void BtnExit_Click(object? sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                caption: "Warning! ",
                text: "You are exiting the app. ",
                icon: MessageBoxIcon.Warning,
                buttons: MessageBoxButtons.OKCancel
            );

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {

            btnCheck.Enabled = true;

            lbl1.Text = rnd.Next(10, 100).ToString() + (rnd.Next(2) == 1 ? " + " : " - ") + rnd.Next(10, 100) + " = ";
            lbl2.Text = rnd.Next(10, 100).ToString() + (rnd.Next(2) == 1 ? " + " : " - ") + rnd.Next(10, 100) + " = ";
            lbl3.Text = rnd.Next(10, 100).ToString() + (rnd.Next(2) == 1 ? " + " : " - ") + rnd.Next(10, 100) + " = ";
            lbl4.Text = rnd.Next(10, 100).ToString() + (rnd.Next(2) == 1 ? " + " : " - ") + rnd.Next(10, 100) + " = ";
            lbl5.Text = rnd.Next(10, 100).ToString() + (rnd.Next(2) == 1 ? " + " : " - ") + rnd.Next(10, 100) + " = ";

            nud1.Text = "0";
            nud2.Text = "0";
            nud3.Text = "0";
            nud4.Text = "0";
            nud5.Text = "0";

            lbl1.ForeColor = Color.Black;
            lbl2.ForeColor = Color.Black;
            lbl3.ForeColor = Color.Black;
            lbl4.ForeColor = Color.Black;
            lbl5.ForeColor = Color.Black;

            richTxtBox1.Text = $"Írd be a számításaid, ha végeztél kattints az \"ellenőrzés\" gombra.";

        }

    }
}
