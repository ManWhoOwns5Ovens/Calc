using System.Diagnostics;
using System.Reflection.Metadata;

namespace Calc
{
    public partial class Form1 : Form
    {
        public string formula = "";
        public float? currentValue = 0.0f;

        public String newFormula = "";
        public float newValue = 0.0f;
        public char? currentOperation = '+';
        public Stack<int> stack = new Stack<int>();

        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCharacter('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addCharacter('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCharacter('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addCharacter('+');
            operatorButton('+');

        }

        private void button5_Click(object sender, EventArgs e)
        {
            addCharacter('*');
            operatorButton('*');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addCharacter('9');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addCharacter('8');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addCharacter('7');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addCharacter('-');
            operatorButton('-');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addCharacter('6');
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addCharacter('5');
        }

        private void button12_Click(object sender, EventArgs e)
        {
            addCharacter('4');
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operatorButton(null);
            resetCalc(currentValue.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            addCharacter('0');
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            addCharacter('/');
            operatorButton('/');
        }

        private void button18_Click(object sender, EventArgs e)
        {
            resetCalc("");
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }
        private void button21_Click(object sender, EventArgs e)
        {

        }

        public void addCharacter(char c)
        {
            formula += c;
            newFormula = newFormula + c;
            display();

        }

        public void changeFormula(string message)
        {
            formula = message;
            display();
        }
        public void resetCalc(string message)
        {
            changeFormula(message);
            formula = "";
            currentValue = 0;
            newFormula = "";
            newValue = 0;
            currentOperation = '+';

        }

        public void operatorButton(char? nOperator)
        {
            string tempString = "0";
            try
            {
                if (nOperator != null) { tempString = newFormula.Substring(0, newFormula.Length - 1); }//get rid of operation
                newValue = float.Parse(tempString);

                currentValue = applyOperation(currentValue, newValue);
                currentOperation = nOperator;

                newFormula = "";
                newValue = 0.0f;
            }
            catch (FormatException)
            {
                resetCalc("Format Error");
            }
            catch (ArgumentNullException)
            {
                resetCalc("Format Error");
            }
            catch (OverflowException)
            {
                resetCalc("Overflow Error");
            }
        }
        public void display()
        {
            textBox1.Text = formula;
        }
        public void displayResult()
        {
            textBox1.Text = formula;
        }

        public float? applyOperation(float? a, float b)
        {
            switch (currentOperation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }
            return null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
