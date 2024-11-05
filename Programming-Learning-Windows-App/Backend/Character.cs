namespace Programming_Learning_Windows_App
{
    public class Character
    {
        public Facing Facing { get; set; }
        public (int X, int Y) Position { get; set; }
        public List<(int X, int Y)> Path { get; private set; }
        private Grid grid;

        private PictureBox imgNorth;
        private PictureBox imgEast;
        private PictureBox imgSouth;
        private PictureBox imgWest;

        public Character(Grid grid, PictureBox imgNorth, PictureBox imgEast, PictureBox imgSouth, PictureBox imgWest)
        {
            this.grid = grid;
            this.imgNorth = imgNorth;
            this.imgEast = imgEast;
            this.imgSouth = imgSouth;
            this.imgWest = imgWest;

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

                if (isValidPosition((x, y)))
                {
                    Position = (x, y);
                    Path.Add(Position);
                    UpdateCharacterImage();

                }
                else break;

            }


        }

        private bool isValidPosition((int, int) futurePos)
        {
            if (grid.IsWall(futurePos) || grid.IsEdge(futurePos)) return false;

            return true;
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

        private void UpdateCharacterImage()
        {
            // Hide all images
            imgNorth.Visible = false;
            imgEast.Visible = false;
            imgSouth.Visible = false;
            imgWest.Visible = false;

            // Show the image corresponding to the current facing direction
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

            // Update the position of the visible PictureBox to match the character's position
            PictureBox currentImage = GetCurrentImage();
            if (currentImage != null)
            {
                currentImage.Location = new Point((Position.X * currentImage.Width) + 100, Position.Y * currentImage.Height);
            }
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
    }
}
