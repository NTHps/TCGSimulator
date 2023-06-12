using CardCore.Enums;

namespace CardCore.Base.Cards
{

    public class MonsterCard : Card
    {

        #region - - - - - - Properties - - - - - -

        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }
        public ExtraDeckTypeEnum? ExtraDeckType { get; set; }
        public int Level { get; set; }

        #endregion Properties

    }

}
