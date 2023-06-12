using CardCore.Base.Cards;

namespace CardCore.Base.Events
{

    public class SpecialSummonedEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public MonsterCard SummonedMonster { get; set; }
    }

}
