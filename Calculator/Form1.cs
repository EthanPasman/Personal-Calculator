using System;
using System.Windows.Forms;

//Note: Requires .NET 5.0 or more recent for FMA Function to work

namespace Calculator
{
    public partial class CalcForm : Form
    {
        private const string BASECHARLIST = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private string entry;
        private string prevEntry;
        private string oper;
        private bool fma;
        private string accumulator;
        private int res;
        private int res2;
        private string retval;
        private string rem;

        public CalcForm()
        {
            InitializeComponent();

            entry = "";
            prevEntry = "";
            oper = "";
            accumulator = "";
            fma = false;
            res = 0;
            res2 = 0;
            retval = "";
            rem = "";

            EntryTextBox.Text = "";

            //KeyPressed gives warning about nullability of sender, sender = EntryTextBox and will not be null
            EntryTextBox.KeyPress += new KeyPressEventHandler(KeyPressed);
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    ZeroBtn_Click(sender, e);
                    break;
                case '1':
                    OneBtn_Click(sender, e);
                    break;
                case '2':
                    TwoBtn_Click(sender, e);
                    break;
                case '3':
                    ThreeBtn_Click(sender, e);
                    break;
                case '4':
                    FourBtn_Click(sender, e);
                    break;
                case '5':
                    FiveBtn_Click(sender, e);
                    break;
                case '6':
                    SixBtn_Click(sender, e);
                    break;
                case '7':
                    SevenBtn_Click(sender, e);
                    break;
                case '8':
                    EightBtn_Click(sender, e);
                    break;
                case '9':
                    NineBtn_Click(sender, e);
                    break;
                case '.':
                    DecBtn_Click(sender, e);
                    break;
                case '+':
                    PlusBtn_Click(sender, e);
                    break;
                case '-':
                    MinusBtn_Click(sender, e);
                    break;
                case '*':
                    MultiplyBtn_Click(sender, e);
                    break;
                case '/':
                    DivideBtn_Click(sender, e);
                    break;
                case '%':
                    PercentBtn_Click(sender, e);
                    break;
                case (char)8:
                    BackspaceBtn_Click(sender, e);
                    break;
                case '=':
                    EqualsBtn_Click(sender, e);
                    break;
            }
            e.Handled = true;
        }

        private void ZeroBtn_Click(object sender, EventArgs e)
        {
            entry += "0";
            EntryTextBox.Text = entry;
        }

        private void OneBtn_Click(object sender, EventArgs e)
        {
            entry += "1";
            EntryTextBox.Text = entry;
        }

        private void TwoBtn_Click(object sender, EventArgs e)
        {
            entry += "2";
            EntryTextBox.Text = entry;
        }

        private void ThreeBtn_Click(object sender, EventArgs e)
        {
            entry += "3";
            EntryTextBox.Text = entry;
        }

        private void FourBtn_Click(object sender, EventArgs e)
        {
            entry += "4";
            EntryTextBox.Text = entry;
        }

        private void FiveBtn_Click(object sender, EventArgs e)
        {
            entry += "5";
            EntryTextBox.Text = entry;
        }

        private void SixBtn_Click(object sender, EventArgs e)
        {
            entry += "6";
            EntryTextBox.Text = entry;
        }

        private void SevenBtn_Click(object sender, EventArgs e)
        {
            entry += "7";
            EntryTextBox.Text = entry;
        }

        private void EightBtn_Click(object sender, EventArgs e)
        {
            entry += "8";
            EntryTextBox.Text = entry;
        }

        private void NineBtn_Click(object sender, EventArgs e)
        {
            entry += "9";
            EntryTextBox.Text = entry;
        }

        private void SignBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = (0 - double.Parse(entry)).ToString();
                EntryTextBox.Text = entry;
            }
            else
            {
                entry += "-";
            }
        }

        private void DecBtn_Click(object sender, EventArgs e)
        {
            if (!entry.Contains("."))
            {
                entry += ".";
                EntryTextBox.Text = entry;
            }
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "+";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "-";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private void MultiplyBtn_Click(object sender, EventArgs e)
        {
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "*";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "/";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private void ModBtn_Click(object sender, EventArgs e)
        {
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "Mod";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private void SqrtBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = Math.Sqrt(double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private void SqareBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = (double.Parse(entry) * double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private void InverseBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = (1 / double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private void ExpBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = Math.Pow(2, double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = Math.Log10(double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private void FactBtn_Click(object sender, EventArgs e)
        {
            if (entry != "")
            {
                entry = Fact(Double.Parse(entry)).ToString();
            }
            EntryTextBox.Text = entry;
        }

        private double Fact(double x)
        {
            //Recursive factorial
            if (x > 1)
            {
                return (x * Fact(x - 1));
            }
            else
            {
                return 1;
            }
        }

        private void NaNBtn_Click(object sender, EventArgs e)
        {
            //Floating point quiet Not a Number
            entry = "NaN";
            EntryTextBox.Text = entry;
        }

        private void InfBtn_Click(object sender, EventArgs e)
        {
            //Floating point Infinity
            entry = "∞";
            EntryTextBox.Text = entry;
        }

        private void BaseBtn_Click(object sender, EventArgs e)
        {
            //Convert prevEntry to Base(Entry)
            if (oper == "")
            {
                prevEntry = entry;
            }
            oper = "Base";
            entry = "";
            EntryTextBox.Text = entry;
        }

        private string Base10ToBaseN(int num, int b)
        {
            //num is decimal number to convert, b is base to convert to
            retval = "";
            rem = "";

            if (b < 0 || b > BASECHARLIST.Length)
            {
                return "";
            }
            string chars = BASECHARLIST.Substring(0, b);
            if (num == 0)
            {
                return "0";
            }

            while (num > 0)
            {
                rem += BASECHARLIST[num % b];
                num = num / b;
            }

            retval = new String(rem.ToCharArray().Reverse().ToArray());
            return retval;
        }

        private void BaseHover(object sender, EventArgs e)
        {
            BaseToolTip.SetToolTip(BaseBtn, "Convert decimal entry (Integer) to base n (Integer)\nCan only convert to base 0-62\n" +
                "0-9 A-Z a-z\nWill return blank if invalid entry\nWill convert back to decimal upon using another button");
        }

        private void FMABtn_Click(object sender, EventArgs e)
        {
            //Fused Multiply Add with 1 rounding for high precision (a += b*c)
            if (entry != "")
            {
                if (fma)
                {
                    prevEntry = entry;
                    entry = "";
                    EntryTextBox.Text = entry;
                    oper = "FMA";
                    fma = false;
                }
                else
                {
                    accumulator = entry;
                    entry = "";
                    EntryTextBox.Text = entry;
                    fma = true;
                }
            }
        }

        private void FMAHover(object sender, EventArgs e)
        {
            FMAToolTip.SetToolTip(FMABtn, "Fused Multiply-Add:\nx → FMA → y → FMA → z → =\nx is accumulator, y and z are multiplicands");
        }

        private void PercentBtn_Click(object sender, EventArgs e)
        {
            //Use current entry as percent of prev entry
            if (!(entry == "" || prevEntry == ""))
            {
                switch (oper)
                {
                    case "+":
                        entry = (double.Parse(prevEntry) + (double.Parse(prevEntry) * (0.01 * double.Parse(entry)))).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "-":
                        entry = (double.Parse(prevEntry) - (double.Parse(prevEntry) * (0.01 * double.Parse(entry)))).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "*":
                        entry = (double.Parse(prevEntry) * (0.01 * double.Parse(entry))).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "/":
                        entry = (double.Parse(prevEntry) / (0.01 * double.Parse(entry))).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "Mod":
                        entry = (double.Parse(prevEntry) % (0.01 * double.Parse(entry))).ToString();
                        EntryTextBox.Text = entry;
                        break;
                }
            }
            prevEntry = entry;
            oper = "";
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            if (!(entry == "" || prevEntry == ""))
            {
                switch (oper)
                {
                    case "+":
                        entry = (double.Parse(prevEntry) + double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "-":
                        entry = (double.Parse(prevEntry) - double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "*":
                        entry = (double.Parse(prevEntry) * double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "/":
                        entry = (double.Parse(prevEntry) / double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "Mod":
                        entry = (double.Parse(prevEntry) % double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        break;
                    case "FMA":
                        entry = Math.FusedMultiplyAdd(Double.Parse(accumulator), Double.Parse(prevEntry), Double.Parse(entry)).ToString();
                        EntryTextBox.Text = entry;
                        accumulator = "";
                        break;
                    case "Base":
                        if (Int32.TryParse(entry, out res) && Int32.TryParse(prevEntry, out res2))
                        {
                            entry = prevEntry;
                            EntryTextBox.Text = Base10ToBaseN(res2, res);
                        } else
                        {
                            entry = "";
                            EntryTextBox.Text = entry;
                        }
                        break;
                }
            }
            prevEntry = entry;
            oper = "";
        }

        private void BackspaceBtn_Click(object sender, EventArgs e)
        {
            //Clear last digit entered
            //NaN and negative single digit numbers count as a single digit
            if (entry != "NaN" && entry != "")
            {
                entry = entry.Remove(entry.Length - 1);
                if (entry == "-")
                {
                    entry = "";
                }
            }
            else
            {
                entry = "";
            }
            EntryTextBox.Text = entry;
        }

        private void CBtn_Click(object sender, EventArgs e)
        {
            //Clear both current and previous entry, and operation used
            entry = "";
            prevEntry = "";
            oper = "";
            EntryTextBox.Text = entry;
        }

        private void CEBtn_Click(object sender, EventArgs e)
        {
            //Clear current entry
            entry = "";
            EntryTextBox.Text = entry;
        }
    }
}
