using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Enums;

namespace CardCore.Cards.Spells
{

    public class ArcanautNewWorld : SpellCard
    {

        #region - - - - - - Constructor - - - - - -

        public ArcanautNewWorld()
        {
            Name = "Arcanaut New World";
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
