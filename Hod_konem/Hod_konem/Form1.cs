using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Hod_konem
{
    public partial class Form1 : Form
    {
        private int[,] board; // �����
        private int size; // ������ �����
        private int startX, startY; // ��������� �������
        private int cellSize = 40; // ������ ������

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // �������� ������ ����� � ��������� ����������
            if (!int.TryParse(textBox1.Text, out size) || size <= 0)
            {
                MessageBox.Show("������� ���������� ������ �����.");
                return;
            }
            if (!int.TryParse(textBox2.Text, out startX) || startX < 0 || startX >= size)
            {
                MessageBox.Show("������� ���������� ��������� ���������� X.");
                return;
            }
            if (!int.TryParse(textBox3.Text, out startY) || startY < 0 || startY >= size)
            {
                MessageBox.Show("������� ���������� ��������� ���������� Y.");
                return;
            }

            // ������������� �����
            board = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = -1;

            // ��������� �������
            board[startX, startY] = 0;

            // ������ �������
            if (!SolveKnightTour(startX, startY, 1))
            {
                label1.Text = "������� �� �������.";
            }
            else
            {
                label1.Text = "������� �������!";
            }

            // ��������� �����
            panel1.Invalidate();
        }
        private bool SolveKnightTour(int x, int y, int moveCount)
        {
            // ��� ������ ��������
            if (moveCount == size * size)
                return true;

            // ��������� ���� ����
            int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

            var moves = new (int x, int y, int degree)[8];
            for (int k = 0; k < 8; k++)
            {
                int nextX = x + xMove[k];
                int nextY = y + yMove[k];

                if (IsSafe(nextX, nextY))
                {
                    moves[k] = (nextX, nextY, GetDegree(nextX, nextY));
                }
                else
                {
                    moves[k] = (nextX, nextY, int.MaxValue); // ������������ ���
                }
            }

            Array.Sort(moves, (a, b) => a.degree.CompareTo(b.degree));

            foreach (var move in moves)
            {
                if (move.degree == int.MaxValue) continue; // ���������� ������������ ����

                board[move.x, move.y] = moveCount;
                if (SolveKnightTour(move.x, move.y, moveCount + 1))
                    return true;
                board[move.x, move.y] = -1; // �����
            }


            return false;
        }
        private int GetDegree(int x, int y)
        {
            int count = 0;
            int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int k = 0; k < 8; k++)
            {
                int nextX = x + xMove[k];
                int nextY = y + yMove[k];
                if (IsSafe(nextX, nextY))
                    count++;
            }

            return count;
        }

        private bool IsSafe(int x, int y)
        {
            return (x >= 0 && x < size && y >= 0 && y < size && board[x, y] == -1);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (board == null) return;

            Graphics g = e.Graphics;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // ��������� ������
                    Brush brush = (i + j) % 2 == 0 ? Brushes.White : Brushes.LightGray;
                    g.FillRectangle(brush, j * cellSize, i * cellSize, cellSize, cellSize);

                    // ��������� ������ ����
                    if (board[i, j] != -1)
                    {
                        g.DrawString(board[i, j].ToString(), Font, Brushes.Black,
                            j * cellSize + cellSize / 3, i * cellSize + cellSize / 3);
                    }
                }
            }
        }
    }
}
