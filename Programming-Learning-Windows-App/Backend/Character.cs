namespace Programming_Learning_Windows_App
{
    public class Character
    {
        public Facing Facing { get; set; }
        public (int X, int Y) Position { get; set; }
        public List<(int X, int Y)> Path { get; private set; } // List to store the path coordinates


        public Character()
        {
            Facing = Facing.East;
            Position = (0, 0);
            Path = new List<(int X, int Y)> { Position }; // Initialize with starting position
        }

        public void Move(int steps)
        {
            var (x, y) = Position;

            for (int i = 0; i < steps; i++)
            {
                // Update position based on facing direction
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
                Path.Add(Position); // Add each new position to the path
            }
        }

        public string GetPathString()
        {
            return string.Join(" -> ", Path.Select(p => $"({p.X}, {p.Y})"));
        }
        /*
            value of Facing turned into a number after incrementing (decrementing) 
            if value was the last (first) enum value 
            vv
        */

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
    }

}
