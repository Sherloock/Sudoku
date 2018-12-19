using System;
using System.Drawing;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form : System.Windows.Forms.Form
    {
        private TextBox inputTextBox;
        private Panel gamePanel;
        private Button[,] cellBtns = new Button[9, 9];
        private int fieldSize = 58;

        public Form()
        {
            InitializeComponent();
            CenterToScreen();
            BackColor = Color.Azure;
        }

        //ini
        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Algos_Panel_Paint(object sender, PaintEventArgs e)
        {
            String[] algoString = {
                "   Easy:",
                "Check for solved squares",
                "Show Possibles",
                "Hidden Singles",
                "Naked Pairs / Triples",
                "Hidden Pairs / Triples",
                "Quads",
                "Killer Combinations(easy)",
                "Innies and Outies(1 cell)",
                "Pointing Pairs",
                "Box / Line Reduction",
                "\n   Tough:",
                "Cage Splitting",
                "X - Wing",
                "Simple Colouring",
                "Y - Wing",
                "Innies / Outies(2 + cells)",
                "Killer Combo's (hard)",
                "Cage / Unit Overlap",
                "Cage Compare",
                "Swordfish",
                "XYZ Wing",
                "\n   Diabolical:",
                "X - Cycles",
                "XY - Chain",
                "3D Medusa",
                "Jellyfish",
                "WXYZ Wing",
                "Aligned Pair Exclusion",
                "\n   Extreme:",
                "Grouped X - Cycles",
                "Finned X - Wing",
                "Finned Swordfish",
                "Altern.Inference Chains",
                "Sue - de - Coq",
                "Digit Forcing Chains",
                "Nishio Forcing Chains",
                "Cell Forcing Chains",
                "Unit Forcing Chains",
                "Almost Locked Sets",
                "Death Blossom",
                "Pattern Overlay Method",
                "Quad Forcing Chains",
                "Bowman Bingo"
            };

            Label algoPanel = new Label()
            {
                Location = new Point(5, 35),
                Size = new Size(200, 650),
                Text = string.Join("\n", algoString),
                Font = new Font(Font.FontFamily, 8, FontStyle.Bold),
            };

            Algos.Controls.Add(algoPanel);
        }

        private void Game_Panel_Paint(object sender, PaintEventArgs e)
        {
            inputTextBox = new TextBox()
            {
                Size = new Size(fieldSize, fieldSize / 2),
                Font = new Font(Font.FontFamily, 7.0f, FontStyle.Regular),
                Visible = false,
                
            };
            inputTextBox.KeyDown += new KeyEventHandler(InputTB_KeyDown);


            gamePanel = new Panel()
            {
                Location = new Point(15, 10 ), 
                Size = new Size(9 * fieldSize, 9 * fieldSize),
            };
            Game.Controls.Add(gamePanel);


            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    //buttons
                    cellBtns[x, y] = new Button()
                    {
                        Location = new Point(fieldSize * x, fieldSize * y),
                        Size = new Size(fieldSize, fieldSize),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(FontFamily.GenericMonospace, 9.0f, FontStyle.Bold),
                        Text = Program.ksdk.GetCell(x, y).CandidatesToBtn(),
                        //Text = (char)(x + 'A') + "" + (y+1),
                        BackColor = Program.ksdk.GetCage(x, y).Color,
                        FlatStyle = FlatStyle.Flat,
                    };

                    int a = x, b = y;
                    cellBtns[x, y].Click += (Sender, EventArgs) => { CellBtn_Clicked(Sender, EventArgs, a, b); };
                    cellBtns[x, y].Paint += new PaintEventHandler((Sender, EventArgs) => PaintButtonBorder(Sender, EventArgs, a, b));

                    gamePanel.Controls.Add(cellBtns[x, y]);


                    //sum labels
                    if (Program.ksdk.GetCage(x, y).Cells[0].Equals(Program.ksdk.GetCell(x, y)))
                    {
                        Label tempLabel = new Label()
                        {
                            Text = Program.ksdk.GetCage(x, y).Sum + "",
                            Font = new Font(Font.FontFamily, 7.0f, FontStyle.Bold),

                            Location = new Point(-3, -3),
                            AutoSize = true,

                        };

                        cellBtns[x, y].Controls.Add(tempLabel);
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                Label nums = new Label()
                {
                    Text = (i + 1) + "",
                    Font = new Font(Font.FontFamily, 7.0f, FontStyle.Regular),

                    Location = new Point((int)(fieldSize *  (i + 0.6f)) , -3),
                    AutoSize = true,

                };

                Game.Controls.Add(nums);

                Label letters = new Label()
                {
                    Text = (char)(i + 'A') + "",
                    Font = new Font(Font.FontFamily, 7.0f, FontStyle.Regular),

                    Location = new Point(0, (int)(fieldSize * (i + 0.6f))),
                    AutoSize = true,

                };

                Game.Controls.Add(letters);
            }
        }

        private void PaintButtonBorder(object sender, PaintEventArgs e, int x, int y)
        {
            Button button;
            if(sender is Button &&x<9&&y<9)
            {
                button = (Button)sender;

                int solid = 2;

                bool top =    y % 3 == 0;
                bool bottom = y == 8;
                bool left =   x % 3 == 0;
                bool right =  x == 8;

                Rectangle borderRectangle = button.ClientRectangle;

                ControlPaint.DrawBorder(
                    e.Graphics, button.ClientRectangle,
                    Color.Black, left   ? solid : 0, ButtonBorderStyle.Solid,
                    Color.Black, top    ? solid : 0, ButtonBorderStyle.Solid,
                    Color.Black, right  ? solid : 0, ButtonBorderStyle.Solid,
                    Color.Black, bottom ? solid : 0, ButtonBorderStyle.Solid
                );
                ///////////////////////////////
                int dashed = 1;
                
                borderRectangle.Inflate(-3, -3);

                top =    y == 0 || !Program.ksdk.GetCage(x, y).Equals(Program.ksdk.GetCage(x, y - 1));
                bottom = y == 8 || !Program.ksdk.GetCage(x, y).Equals(Program.ksdk.GetCage(x, y + 1));
                left =   x == 0 || !Program.ksdk.GetCage(x, y).Equals(Program.ksdk.GetCage(x - 1, y));
                right =  x == 8 || !Program.ksdk.GetCage(x, y).Equals(Program.ksdk.GetCage(x + 1, y));

                ControlPaint.DrawBorder(
                    e.Graphics, borderRectangle,
                    Color.Black, left ? dashed : 0, ButtonBorderStyle.Dashed,
                    Color.Black, top ? dashed : 0, ButtonBorderStyle.Dashed,
                    Color.Black, right ? dashed : 0, ButtonBorderStyle.Dashed,
                    Color.Black, bottom ? dashed : 0, ButtonBorderStyle.Dashed
                );
            }
        }

        private void Log_Paint(object sender, PaintEventArgs e)
        {

        }
       
        ///////////////////////////////////////////////////////////

        public void RefreshCandidates(int x, int y)
        {
            Button cell = cellBtns[x, y];

            cell.Text = Program.ksdk.GetCell(x, y).CandidatesToBtn();
            if (cell.Text.Length == 1)
            {
                cell.Font = new Font(Font.FontFamily, 25.0f, FontStyle.Bold);
            }

            else
            {
                cell.Font = new Font(FontFamily.GenericMonospace, 9.0f, FontStyle.Bold);
            }
        }

        private void InputTB_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetCellBtnCandidates(sender);
            }
        }

        private void SetCellBtnCandidates(Object sender)
        {
            if (sender is TextBox textBox)
            {
                textBox.Visible = false;

                if (textBox.Parent is Button cellBtn)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        for (int y = 0; y < 9; y++)
                        {
                            if (cellBtns[x, y].Equals(cellBtn))
                            {
                                Program.ksdk.SetCandidates(x, y, textBox.Text);
                            }
                        }
                    }
                }
            }
        }


        //Buttons
        private void CellBtn_Clicked(object sender, EventArgs eventArgs, int x, int y)
        {
            SetCellBtnCandidates(inputTextBox);

            inputTextBox.Visible = true;
            inputTextBox.Text = Program.ksdk.GetCell(x, y).CandidatesToTF();
            inputTextBox.Location = new Point(0, (fieldSize - inputTextBox.Height) / 2);
   
            cellBtns[x, y].Controls.Add(inputTextBox);
            inputTextBox.Focus();

        }

        private void TakeStepBtn_Clicked(object sender, EventArgs e)
        {
            Program.solver.TakeStep();
        }

        private void SolveBtn_Clicked(object sender, EventArgs e)
        {
            Program.solver.Solve();
        }
        public void SetLogBox(string s)
        {
            logBox.Text = "";
            AppendLogBox(s);
        }

        public void AppendLogBox(string s)
        {
            logBox.Text += s.Replace("\n", "\r\n");
        }
    }
}
