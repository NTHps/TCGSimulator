using CardCore.Base.Cards;
using CardCore.Enums;

namespace CardCore.Base.Events
{

    public class SpecialSummonedEventArgs : EventArgs
    {

        #region - - - - - - Properties - - - - - -

        public CardPositionEnum From { get; set; }
        public Player Player { get; set; }
        public MonsterCard SummonedMonster { get; set; }

        #endregion Properties

    }

}
