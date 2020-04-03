using Microsoft.VisualBasic.CompilerServices;

namespace textBasedGame
{
    public class Door
    {
        public enum Directions
        {
            Undefined, North, South, East, West
        };

        public static string[] shortendDirections = {"Null", "N", "S", "E", "W"};

        private Room _leadsTo;
        private Directions _direction;

        public Door()
        {
            _direction = Directions.Undefined;
            _leadsTo = null;
        }

        public Door(Directions direction, Room newLeadsTo)
        {
            _direction = direction;
            _leadsTo = newLeadsTo;
        }

        public override string ToString()
        {
            return _direction.ToString();
        }

        public void SetDirection(Directions direction)
        {
            _direction = direction;
        }

        public Directions GetDirections()
        {
            return _direction;
        }
        
        public string GetShortDirection()
        {
            return shortendDirections[(int)_direction].ToLower();
        }

        public void SetLeadsTo(Room leadsTo)
        {
            _leadsTo = leadsTo;
        }

        public Room GetLeadsTo()
        {
            return _leadsTo;
        }
    }
}