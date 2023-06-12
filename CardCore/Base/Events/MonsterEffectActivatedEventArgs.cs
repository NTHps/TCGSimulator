using CardCore.Base.Cards;

namespace CardCore.Base.Events
{

    public class MonsterEffectActivatedEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public MonsterCard ActivatedMonster { get; set; }
    }

}
