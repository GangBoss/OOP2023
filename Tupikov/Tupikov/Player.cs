namespace Tupikov
{
    public class Player
    {
        public int Gold { get; private set; }
        public bool Dead { get; private set; }
        private List<Building> _buildings = new ();

        public bool CanBeat(Army army)
        {
            return army.Power < 5;
        }
            
        public int Id { get; set; }

        public void Consume(Treasure treasure)
        {
            Gold += treasure.Amount;
        }

        public void Obtain(Building build)
        {
            if (_buildings.Contains(build))
                return;
            _buildings.Add(build);
        }

        public void Die()
        {
            Dead = true;
        }
    }
}