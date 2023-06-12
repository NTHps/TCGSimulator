using CardCore.Enums;

namespace CardCore.Base
{

    public class GameEvent
    {

        #region - - - - - - Properties - - - - - -

        public EventTypeEnum EventType { get; set; }
        public Card AffectedCard { get; set; }

        #endregion Properties

    }

}
