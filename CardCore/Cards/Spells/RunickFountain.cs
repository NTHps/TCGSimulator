using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Enums;

namespace CardCore.Cards.Spells
{

    public class RunickFountain : SpellCard
    {

        #region - - - - - - Constructor - - - - - -

        public RunickFountain()
        {
            Name = "Runick Fountain";
            SpellType = SpellTypeEnum.Field;
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public override void HandleEvent(EventTypeEnum eventType, EventArgs eventArgs, Player player, Field field, EventBus eventBus)
        {
            // Add conditional effect here
        }

        #endregion Methods

    }

}
