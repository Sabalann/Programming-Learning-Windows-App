namespace Programming_Learning_Windows_App
{
    public class Character
    {
        public Facing Facing { get; set; }
        public (int X, int Y) Position { get; set; }

        public Character()
        {
            Facing = Facing.East;
            Position = (0, 0);
        }

        public void Move(int steps)
        {
            var (x, y) = Position;

            switch (Facing)
            {
                case Facing.North: 
                    y -= steps;
                    break;
                case Facing.East:
                    x += steps;
                    break;
                case Facing.South:
                    y += steps;
                    break;
                case Facing.West:
                    x -= steps;
                    break;

            }

            Position = (x, y);
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
