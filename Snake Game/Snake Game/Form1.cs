using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Snake_Game
{
    public partial class Snake : Form
    {
        int cols = 50, rows = 25, canvasSize = 20, score = 0, dx = 0, dy = 0, front = 0, back = 0;
        Piece[] snake;
        List<int> available = new List<int>();
        bool[,] visit;
        Random rand = new Random();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        public Snake()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowIcon = false;
            this.Size = Size = new Size(1000, 500);
            this.Font = new Font("Courier New", 14);
            this.WindowState = FormWindowState.Normal;
            this.VerticalScroll.Visible = false;
            InitializeComponent();
            InitializeGame();
            LaunchGameTimer();
        }

        private void InitializeGame()
        {
            visit = new bool[rows, cols];
            snake = new Piece[rows * cols];
            Piece head = new Piece((rand.Next() % cols) * canvasSize, (rand.Next() % rows) * canvasSize, canvasSize);
            lblFood.Location = new Point((rand.Next() % cols) * canvasSize, (rand.Next() % rows) * canvasSize);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    visit[i, j] = false;
                    available.Add(i * cols + j);
                }

                visit[head.Location.Y / canvasSize, head.Location.X / canvasSize] = true;
                available.Remove(head.Location.Y / canvasSize * cols + head.Location.X / canvasSize);
                Controls.Add(head);
                snake[front] = head;
            }
        }

        private void LaunchGameTimer()
        {
            timer.Interval = 50;
            timer.Tick += MoveSnake;
            timer.Start();
        }

        private void MoveSnake(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0) return;

            if (GameIsOver(x + dx, y + dy) || SnakeHitsOwnBody((y + dy) / canvasSize, (x + dx) / canvasSize))
            {
                return;
            }

            if (CollisionWithFood(x + dx, y + dy))
            {
                score += 1;
                lblScore.Text = "Score: " + score.ToString();
                if (SnakeHitsOwnBody((y + dy) / canvasSize, (x + dx) / canvasSize)) return;
                Piece newHead = new Piece(x + dx, y + dy, canvasSize);
                front = (front - 1 + rows * cols) % (rows * cols);
                snake[front] = newHead;
                visit[newHead.Location.Y / canvasSize, newHead.Location.X / canvasSize] = true;
                Controls.Add(newHead);
                RandomizeFoodPosition();
            }
            else
            {
                if (SnakeHitsOwnBody((y + dy) / canvasSize, (x + dx) / canvasSize)) return;
                visit[snake[back].Location.Y / canvasSize, snake[back].Location.X / canvasSize] = false;
                front = (front - 1 + rows * cols) % (rows * cols);
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + rows * cols) % (rows * cols);
                visit[(y + dy) / canvasSize, (x + dx) / canvasSize] = true;
            }
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    dx = canvasSize;
                    break;
                case Keys.Left:
                    dx = -canvasSize;
                    break;
                case Keys.Up:
                    dy = -canvasSize;
                    break;
                case Keys.Down:
                    dy = canvasSize;
                    break;
                case Keys.Enter:
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Space:
                    MessageBox.Show("Snake Game Info");
                    break;
                default:
                    break;
            }
        }

        // Checks whether the snake head hits its own body.
        // If there is a collision, stops the game timer, displays a message, and returns true; otherwise, returns false.
        private bool SnakeHitsOwnBody(int x, int y)
        {
            if (visit[x, y])
            {
                timer.Stop();
                MessageBox.Show("Snake hit its own body!");
                return true;
            }
            return false;
        }


        // Checks whether the snake head collides with the food.
        // If there is a collision, returns true; otherwise, returns false.
        private bool CollisionWithFood(int x, int y)
        {
            return x == lblFood.Location.X && y == lblFood.Location.Y;
        }
        private bool GameIsOver(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        // Randomly selects an available position on the canvas to place the food.
        // The available positions are determined by the 'visit' array.
        // If there are available positions, selects one randomly and updates the food's location.
        private void RandomizeFoodPosition()
        {
            available.Clear();

            // Iterate over the canvas to find available positions
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visit[i, j])
                    {
                        available.Add(i * cols + j);
                    }
                }
            }

            // If there are available positions, randomly select one and update the food's location
            if (available.Count > 0)
            {
                int idx = rand.Next(available.Count);
                int foodIndex = available[idx];
                int foodX = foodIndex % cols;
                int foodY = foodIndex / cols;

                lblFood.Left = foodX * 20;
                lblFood.Top = foodY * 20;
            }
        }
      




    }
}
