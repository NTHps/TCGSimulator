using CardCore.Enums;

namespace CardCore.Base.Cards
{

    public abstract class SpellCard : Card
    {

        #region - - - - - - Properties - - - - - -

        public SpellTypeEnum SpellType { get; set; }

        #endregion Properties

    }
}