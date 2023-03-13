namespace оаип_лаба9
{
    public partial class Form1 : Form
    {

        private Stack<Operator> operators = new Stack<Operator>(); //Цикл обработки входной строки
        private Stack<Operand> operands = new Stack<Operand>(); //Цикл обработки входной строки
        bool flag = true;
        string name;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height); //компоненты для прорисовки
            Init.bitmap = bitmap;
            Pen pen = new Pen(Color.Black, 2);
            Init.pen = pen;
            Init.pictureBox = pictureBox1;
            textBoxInputString.Text = "S(x,200,100,150)";
        }
        private bool IsNotOperation(char item) //Функция проверки символов операций
        {
            if (!(item == 'S' || item == 'C' || item == 'M' || item == 'D' || item == ',' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ConvertCharToInt(object item)
        {
            return Convert.ToInt32(Convert.ToString(item));
        }

        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            //    for (int i = 0; i < textBoxInputString.Text.Length; i++)
            //    {
            //        if (IsNotOperation(textBoxInputString.Text[i]))
            //        {
            //            private bool IsNotOperation(char item)
            //            {
            //                if (!(item == 'R' || item == 'M' || item == 'E' || item == 'C' || item == 'S' || item == ',' || item == '(' || item == ')'))
            //                {
            //                    return true;
            //                }
            //                else
            //                {
            //                    return false;
            //                }
            //            }
            //            if (!(Char.IsDigit(textBoxInputString.Text[i])))
            //            {
            //                this.operands.Push(new Operand(textBoxInputString.Text[i]));
            //                continue;
            //            }
            //            else if (Char.IsDigit(textBoxInputString.Text[i]))
            //            {
            //                if (Char.IsDigit(textBoxInputString.Text[i + 1]))
            //                {
            //                    if (flag)
            //                    {
            //                        this.operands.Push(new Operand(textBoxInputString.Text[i]));
            //                    }
            //                    this.operands.Push(new Operand(ConvertCharToInt(this.operands.Pop().value) * 10 + ConvertCharToInt(textBoxInputString.Text[i + 1])));
            //                    flag = false;
            //                    continue;
            //                }
            //                else if ((textBoxInputString.Text[i + 1] == ','|| textBoxInputString.Text[i + 1] == ')')&& !(Char.IsDigit(textBoxInputString.Text[i - 1])))
            //                {
            //                    this.operands.Push(new Operand(ConvertCharToInt(textBoxInputString.Text[i])));
            //                    continue;

            //                }

            //            }
            //            else if (textBoxInputString.Text[i] == 'R')
            //            {
            //                if (this.operators.Count == 0)
            //                {
            //                    this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));

            //                }
            //            }
            //            else if (textBoxInputString.Text[i] == '(')
            //            {
            //                this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));

            //            }
            //            else if (textBoxInputString.Text[i] == ')')
            //            {
            //                do
            //                {
            //                    if (operators.Peek().symbolOperator == '(')
            //                    {
            //                        operators.Pop();
            //                        break;

            //                    }
            //                    if (operators.Count == 0)
            //                    {
            //                        break;
            //                    }

            //                }
            //                while (operators.Peek().symbolOperator != '(');
            //            }
            //        }
            //        if (operators.Peek() != null)
            //        {
            //            this.SelectingPerformingOperation(operators.Peek());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Введенной операции не существует");
            //        }
            //    }
            //}

            //private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
            //{

            //}
            if (e.KeyCode == Keys.Enter)
            {
                operators = new Stack<Operator>();
                operands = new Stack<Operand>();
                for (int i = 0; i < textBoxInputString.Text.Length; i++)
                {
                    if (IsNotOperation(textBoxInputString.Text[i]))
                    {
                        if (!(Char.IsDigit(textBoxInputString.Text[i])))
                        {
                            this.operands.Push(new Operand(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (Char.IsDigit(textBoxInputString.Text[i]))
                        {
                            if (flag)
                            {
                                this.operands.Push(new Operand(textBoxInputString.Text[i]));
                            }
                            else
                            {
                                if (!(Char.IsDigit(textBoxInputString.Text[i - 1])))
                                {
                                    this.operands.Push(new Operand(ConvertCharToInt(textBoxInputString.Text[i])));
                                    continue;
                                }
                                this.operands.Push(new Operand(ConvertCharToInt(this.operands.Pop().value) * 10 + ConvertCharToInt(textBoxInputString.Text[i])));
                            }
                            flag = false;
                            continue;
                        }
                    }
                    else if (textBoxInputString.Text[i] == ',')
                    {
                        flag = true;
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'S')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'C')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'M')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == 'D')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        continue;
                    }
                    else if (textBoxInputString.Text[i] == '(')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                    }
                    else if (textBoxInputString.Text[i] == ')')
                    {
                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }
                try
                {
                    this.SelectingPerformingOperation(operators.Peek());
                }
                catch
                {
                    MessageBox.Show("Введенной операции не существует");
                    
                }
            }
        }
        private void SelectingPerformingOperation(Operator op)
        {
//            if (op.symbolOperator == 'R')
//            {
//                Figure figure = new Rectangle (Convert.ToInt32
//(Convert.ToString(operands.Pop().value)), Convert.ToInt32
//(Convert.ToString(operands.Pop().value)), Convert.ToInt32
//(Convert.ToString(operands.Pop().value)), Convert.ToInt32
//(Convert.ToString(operands.Pop().value)), Convert.ToString
//(operands.Pop().value));
//                op = new Operator(Figure.figure.Draw, 'R');
//                ShapeContainer.AddFigure(figure);
//                listBox1.Items.Add(figure.name);
//                op.operatorMethod();
//            }
        }
    }
 }
