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

        public Stack<float?> valueStack = new Stack<float?>();
        public Stack<char?> operationStack = new Stack<char?>();


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
            operatorButton('=');
            resetCalc(currentValue.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            addCharacter('.');
        }

        private void button15_Click(object sender, EventArgs e)
        {
            addCharacter('0');
        }

        private void button16_Click(object sender, EventArgs e)
        {
            addCharacter('-');
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
            addCharacter(')');
            closeParenthesis();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            addCharacter('(');
            openParenthesis();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (formula != "") {changeFormula(eliminateLastCharacter(formula)); }
            if (newFormula != "") { newFormula = eliminateLastCharacter(newFormula); }
        }

        public void openParenthesis()
        {
            valueStack.Push(currentValue);
            operationStack.Push(currentOperation);
            resetHiddenValues();

        }
        public void closeParenthesis()
        {
            newFormula = currentValue.ToString();
            currentValue = valueStack.Pop();
            currentOperation = operationStack.Pop();
            operatorButton(currentOperation);
        }

        public void addCharacter(char c)
        {
            changeFormula(formula += c);
            newFormula += c;

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
            resetHiddenValues();
        }

        public void resetHiddenValues()
        {
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
                if (nOperator != '=') { tempString = eliminateLastCharacter(newFormula); }//get rid of operation
                else { tempString = newFormula; }
                newValue = float.Parse(tempString);

                currentValue = applyOperation(currentValue, newValue);
                currentOperation = nOperator;

                changeFormula(currentValue.ToString()+nOperator);

                newFormula = "";
                newValue = 0.0f;
            }
            catch (FormatException)
            {
                resetCalc("Format Error");
            }
            catch (ArgumentNullException)
            {
                resetCalc("Null Argument Error");
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

        public string eliminateLastCharacter(string toChange)
        {
            return toChange.Substring(0, toChange.Length - 1);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
