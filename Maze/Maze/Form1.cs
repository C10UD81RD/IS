using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        private Maze maze;
        private List<List<Point>> paths;
        private Point startPoint = new Point(-1, -1);
        private Point endPoint = new Point(-1, -1);
        private int cellSize = 20;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnCreateMaze_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMazeSize.Text, out int size) && size > 0)
            {
                maze = new Maze(size, size);
                pictureBox.Width = size * cellSize;
                pictureBox.Height = size * cellSize;
                DrawMaze();
            }
            else
            {
                MessageBox.Show("Введите корректный размер лабиринта.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maze == null)
            {
                MessageBox.Show("Сначала создайте лабиринт.");
                return;
            }

            if (startPoint.X == -1 || endPoint.X == -1)
            {
                MessageBox.Show("Укажите начальную и конечную точки.");
                return;
            }

            paths = maze.FindPaths(startPoint, endPoint);
            lblTotalPaths.Text = $"Всего путей: {paths.Count}";
            MessageBox.Show($"Найдено {paths.Count} путей.");
            DrawMaze();
        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            if (maze == null) return;

            int x = e.X / cellSize;
            int y = e.Y / cellSize;

            if (e.Button == MouseButtons.Left)
            {
                maze.ToggleWall(x, y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (startPoint.X == -1)
                {
                    startPoint = new Point(x, y);
                }
                else if (endPoint.X == -1)
                {
                    endPoint = new Point(x, y);
                }
                else
                {
                    MessageBox.Show("Начальная и конечная точки уже заданы.");
                }
            }
            DrawMaze();
        }

        private void DrawMaze()
        {
            if (maze == null) return;

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Отрисовка лабиринта
                for (int x = 0; x < maze.Width; x++)
                {
                    for (int y = 0; y < maze.Height; y++)
                    {
                        if (maze.IsWall(x, y))
                        {
                            g.FillRectangle(Brushes.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                        }
                        else
                        {
                            g.FillRectangle(Brushes.White, x * cellSize, y * cellSize, cellSize, cellSize);
                        }
                    }
                }

                // Отрисовка начальной и конечной точек
                if (startPoint.X != -1)
                {
                    g.FillEllipse(Brushes.Blue, startPoint.X * cellSize, startPoint.Y * cellSize, cellSize, cellSize);
                }
                if (endPoint.X != -1)
                {
                    g.FillEllipse(Brushes.Red, endPoint.X * cellSize, endPoint.Y * cellSize, cellSize, cellSize);
                }

                // Отрисовка всех маршрутов
                if (paths != null && paths.Count > 0)
                {
                    // Находим кратчайший маршрут
                    var shortestPath = paths[0];
                    foreach (var path in paths)
                    {
                        if (path.Count < shortestPath.Count)
                            shortestPath = path;
                    }

                    // Отрисовка всех маршрутов разными цветами
                    Random rnd = new Random();
                    foreach (var path in paths)
                    {
                        Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        if (path == shortestPath)
                            color = Color.Green; // Кратчайший маршрут всегда зеленый

                        for (int i = 0; i < path.Count - 1; i++)
                        {
                            g.DrawLine(new Pen(color, 2), path[i].X * cellSize + cellSize / 2, path[i].Y * cellSize + cellSize / 2,
                                path[i + 1].X * cellSize + cellSize / 2, path[i + 1].Y * cellSize + cellSize / 2);
                        }
                    }
                }
            }
            pictureBox.Image = bmp;
        }
    }
}
