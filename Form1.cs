namespace calc
{
    public partial class Form1 : Form
    {
        public bool New = true;
        public double Save = 0;
        public string Operator = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }
        //각 숫자버튼 클릭 시 이벤트
        public void Numbers(string num)
        {
            if (New || Calc.Text == "0")
            {
                Calc.Text = num;
                New = false;
            }
            else
            {
                Calc.Text += num;
            }
        }
        //각 숫자버튼
        private void Buttons (object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int num = int.Parse(btn.Text);
            
            if (New || Calc.Text == "0")
            {
                Calc.Text = num.ToString();
                New = false;
            }
            else
            {
                Calc.Text += num;
            }
        }
        //소수점 버튼
        private void Dot (object sender, EventArgs e)
        {
            if (Calc.Text.Contains("."))
                return;
            else
                Calc.Text += ".";
        }
        //+- 변경 버튼
        private void PlusMinus (object sender, EventArgs e)
        {
            int pmchange = int.Parse(Calc.Text);
            pmchange = -pmchange;
            Calc.Text = pmchange.ToString();
        }
        //사칙연산 기호 버튼
        private void Calculate (object sender, EventArgs e)
        {
            New = true;
            Save = double.Parse(Calc.Text);

            Button btn = (Button)sender;
            Operator = btn.Text;
            Label.Text = Calc.Text + Operator;
        }
        // = 버튼
        private void Equal (object sender, EventArgs e)
        {
            double equation = double.Parse(Calc.Text);
            switch (Operator)
            {
                case "+":
                    Calc.Text = (Save + equation).ToString();
                    break;
                case "-":
                    Calc.Text = (Save - equation).ToString();
                    break;
                case "*":
                    Calc.Text = (Save * equation).ToString();
                    break;
                case "/":
                    Calc.Text = (Save / equation).ToString();
                    break;
            }
            Label.Text = Save + Operator + equation + " =";;
        }
        //CE 버튼
        private void LineClear (object sender, EventArgs e)
        {
            Calc.Text = "0";
        }
        //전체 삭제 C 버튼
        private void Clear (object sender, EventArgs e)
        {
            New = true;
            Save = 0;
            Operator = "";
            Label.Text = "";
            Calc.Text = "0";
        }
        //뒷자리부터 한 글자씩 삭제 버튼
        private void Delete (object sender, EventArgs e)
        {
            Calc.Text = Calc.Text.Remove(Calc.Text.Length - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}