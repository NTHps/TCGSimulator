using CardCore.Base;

namespace CardCore.Base.Events
{

    public class CardActivatedEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public Card ActivatedCard { get; set; }
    }


}
