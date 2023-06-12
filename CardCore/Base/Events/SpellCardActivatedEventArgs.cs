using CardCore.Base.Cards;

namespace CardCore.Base.Events
{

    public class SpellCardActivatedEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public SpellCard ActivatedSpell { get; set; }
    }

}
