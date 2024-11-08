namespace Programming_Learning_Windows_App;

public class Character
{
    private readonly Grid grid;
    private readonly PictureBox imgEast;

    private readonly PictureBox imgNorth;
    private readonly PictureBox imgSouth;
    private readonly PictureBox imgWest;

    public Character(Grid grid, PictureBox imgNorth, PictureBox imgEast, PictureBox imgSouth, PictureBox imgWest)
    {
        this.grid = grid;
        this.imgNorth = imgNorth;
        this.imgEast = imgEast;
        this.imgSouth = imgSouth;
        this.imgWest = imgWest;

        Facing = Facing.East;
        Position = (0, 0);
        UpdateCharacterImage();
    }

    public Facing Facing { get; set; }
    public (int X, int Y) Position { get; set; }
    public List<(int X, int Y)> Path { get; } = new();

    public void Move(int steps)
    {
        var (x, y) = Position;
        Path.Add((0, 0));

        for (var i = 0; i < steps; i++)
        {
            switch (Facing)
            {
                case Facing.North:
                    y -= 1;
                    break;
                case Facing.East:
                    x += 1;
                    break;
                case Facing.South:
                    y += 1;
                    break;
                case Facing.West:
                    x -= 1;
                    break;
            }

            Form1.Instance.DisplayErrorMessage(CheckPosition((x, y)));
            Position = (x, y);
            Path.Add(Position);
            UpdateCharacterImage();
        }
    }

    private string CheckPosition((int, int) futurePos)
    {
        string message = string.Empty;

        if (grid.IsEdge(futurePos)) message =  "Byte left the grid";

        if (grid.IsWall(futurePos)) message = "Byte hit a wall";

        if (message == string.Empty) message = "Success";

        return message;
    }

    public string GetPathString()
    {
        return string.Join(" -> ", Path.Select(p => $"({p.X}, {p.Y})"));
    }

    public void Turn(Direction direction)
    {
        if (direction == Direction.Left)
        {
            if (Facing == Facing.North)
            {
                Facing = Facing.West;
                return;
            }

            Facing--;
        }
        else
        {
            if (Facing == Facing.West)
            {
                Facing = Facing.North;
                return;
            }

            Facing++;
        }

        UpdateCharacterImage();
    }

    public bool IsAtGridEdge()
    {
        (int X, int Y) ahead = Facing switch
        {
            Facing.North => (Position.X, Position.Y - 1),
            Facing.South => (Position.X, Position.Y + 1),
            Facing.East => (Position.X + 1, Position.Y),
            Facing.West => (Position.X - 1, Position.Y),
            _ => Position
        };

        return grid.IsEdge(ahead);
    }

    public bool IsWallAhead()
    {
        (int X, int Y) ahead = Facing switch
        {
            Facing.North => (Position.X, Position.Y - 1),
            Facing.South => (Position.X, Position.Y + 1),
            Facing.East => (Position.X + 1, Position.Y),
            Facing.West => (Position.X - 1, Position.Y),
            _ => Position
        };

        return grid.IsWall(ahead);
    }

    private void UpdateCharacterImage()
    {
        imgNorth.Visible = false;
        imgEast.Visible = false;
        imgSouth.Visible = false;
        imgWest.Visible = false;

        switch (Facing)
        {
            case Facing.North:
                imgNorth.Visible = true;
                break;
            case Facing.East:
                imgEast.Visible = true;
                break;
            case Facing.South:
                imgSouth.Visible = true;
                break;
            case Facing.West:
                imgWest.Visible = true;
                break;
        }

        var currentImage = GetCurrentImage();
        if (currentImage != null)
            currentImage.Location =
                new Point(Position.X * currentImage.Width + 718, Position.Y * currentImage.Height + 62);
    }

    private PictureBox GetCurrentImage()
    {
        switch (Facing)
        {
            case Facing.North:
                return imgNorth;
            case Facing.East:
                return imgEast;
            case Facing.South:
                return imgSouth;
            case Facing.West:
                return imgWest;
            default:
                return null;
        }
    }

    public void Reset()
    {
        Position = (0, 0);
        Facing = Facing.East;
        UpdateCharacterImage();
        Path.Clear();
    }
}