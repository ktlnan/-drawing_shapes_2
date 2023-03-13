namespace оаип_лаба9
{
    public partial class Form1 : Form
    {
        Rectangle rectangle;
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
            textBoxInputString.Text = "R(name,x,y,w,h)";
        }
        private bool IsNotOperation(char item) //Функция проверки символов операций
        {
            if (!(item == 'R' ||  item == 'M' || item == 'D' || item == ',' || item == '(' || item == ')'))
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
                    else if (textBoxInputString.Text[i] == 'R')
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
                    listBox1.Items.Add("Введена ошибочная команда");
                }
            }
        }
        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'R')
            {
                Figure rectangle = new Rectangle(Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToString(operands.Pop().value));
                op = new Operator(rectangle.Draw, 'R');
                ShapeContainer.AddFigure(rectangle);
                listBox1.Items.Add(rectangle.name);
                op.operatorMethod();
                rectangle.Draw();
            }
            if (op.symbolOperator == 'M')
            {
                try
                {
                    int y = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int x = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int w = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int h = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    name = Convert.ToString(operands.Pop().value);
                    string movename = "Прямоугольник " + name + " переместился";
                    if (ShapeContainer.FindFigure(name) == null)
                    {
                        MessageBox.Show("Возникла какая-то ошибка.");
                        listBox1.Items.Add("Введена ошибочная команда");
                    }
                    else
                    {
                        ShapeContainer.FindFigure(name).MoveTo(x, y);
                        if (listBox1.Items.Contains(movename))
                        {
                            listBox1.Items.Remove(movename);
                        }
                        listBox1.Items.Add(movename);
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла какая-то ошибка.");
                    listBox1.Items.Add("Введена ошибочная команда");
                }
            }
            if (op.symbolOperator == 'D')
            {
                try
                {
                    name = Convert.ToString(operands.Pop().value);
                    string deletename = "Прямоугольник " + name + " удалился";
                    if (ShapeContainer.FindFigure(name) == null)
                    {
                        MessageBox.Show("Возникла какая-то ошибка.");
                        listBox1.Items.Add("Введена ошибочная команда");
                    }
                    else
                    {
                        ShapeContainer.FindFigure(name).DeleteF(ShapeContainer.FindFigure(name), true);
                        listBox1.Items.Add(ShapeContainer.FindFigure(name) + deletename);
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла какая-то ошибка.");
                    listBox1.Items.Add("Введена ошибочная команда");
                }
            }
        }
    }
 }
