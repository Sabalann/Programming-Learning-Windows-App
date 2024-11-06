
namespace Programming_Learning_Windows_App
{
    public class Grid
    {
        public int Width;
        public int Height;
        private List<(int X, int Y)> walls;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            walls = new List<(int X, int Y)>();
            AddWall((5, 0));
        }

        public void AddWall((int, int) position)
        {
            walls.Add(position);
        }

        public bool IsWall((int, int) position)
        {
            return walls.Contains(position);
        }

        public bool IsEdge((int, int) position)
        {
            return position.Item1 < 0 || position.Item1 >= Width - 1 || position.Item2 < 0 || position.Item2 >= Height - 1;
        }
    }

}