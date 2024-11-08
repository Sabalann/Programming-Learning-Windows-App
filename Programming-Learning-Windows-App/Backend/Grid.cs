namespace Programming_Learning_Windows_App;

public class Grid
{
    public int Height;
    public int Width;

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        AddWall((5, 0));
    }

    public List<(int X, int Y)> Walls { get; } = new();

    public void AddWall((int, int) position)
    {
        Walls.Add(position);
    }

    public bool IsWall((int, int) position)
    {
        return Walls.Contains(position);
    }

    public bool IsEdge((int, int) position)
    {
        return position.Item1 < 0 || position.Item1 >= Width || position.Item2 < 0 || position.Item2 >= Height;
    }
}