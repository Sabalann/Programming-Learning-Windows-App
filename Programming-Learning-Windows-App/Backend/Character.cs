namespace Programming_Learning_Windows_App
{
    public class Character
    {
        public Facing Facing { get; set; }
        public (int X, int Y) Position { get; set; }
        public List<(int X, int Y)> Path { get; private set; }
        private Grid grid;

        public Character(Grid grid)
        {
            this.grid = grid;
            Facing = Facing.East;
            Position = (0, 0);
            Path = new List<(int X, int Y)>();
            Path.Add((0, 0));

        }

        public void Move(int steps)
        {
            var (x, y) = Position;


            for (int i = 0; i < steps; i++)
            {
                if (IsAtGridEdge() || IsWallAhead()) break;

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

                Position = (x, y);
                Path.Add(Position);
            }


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
        }

        public bool IsAtGridEdge()
        {
            switch (Facing)
            {
                case Facing.North:
                    return Position.Y <= 0;
                case Facing.South:
                    return Position.Y >= grid.Height - 1;
                case Facing.East:
                    return Position.X >= grid.Width - 1;
                case Facing.West:
                    return Position.X <= 0;
                default:
                    return false;
            }
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
    }


}
