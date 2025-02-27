using System;
using System.Collections.Generic;
using System.Drawing;

namespace Maze
{
    public class Maze
    {
        private int[,] grid;
        public int Width { get; }
        public int Height { get; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new int[width, height];
        }

        public bool IsWall(int x, int y)
        {
            return grid[x, y] == 1;
        }

        public void ToggleWall(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                grid[x, y] = grid[x, y] == 1 ? 0 : 1; // Переключаем стену на проход и наоборот
            }
        }

        public List<List<Point>> FindPaths(Point start, Point end)
        {
            var paths = new List<List<Point>>();
            DFS(start, end, new List<Point>(), paths);
            return paths;
        }

        private void DFS(Point current, Point end, List<Point> path, List<List<Point>> paths)
        {
            if (current.X < 0 || current.X >= Width || current.Y < 0 || current.Y >= Height || IsWall(current.X, current.Y))
                return;

            if (current == end)
            {
                path.Add(current);
                paths.Add(new List<Point>(path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            path.Add(current);
            grid[current.X, current.Y] = 1; // Помечаем как посещенную

            DFS(new Point(current.X + 1, current.Y), end, path, paths); // Вправо
            DFS(new Point(current.X - 1, current.Y), end, path, paths); // Влево
            DFS(new Point(current.X, current.Y + 1), end, path, paths); // Вниз
            DFS(new Point(current.X, current.Y - 1), end, path, paths); // Вверх

            path.RemoveAt(path.Count - 1);
            grid[current.X, current.Y] = 0; // Снимаем пометку
        }
    }
}