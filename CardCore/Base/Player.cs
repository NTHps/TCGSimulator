using CardCore.Base.Cards;
using CardCore.Interfaces;

namespace CardCore.Base
{

    public class Player
    {

        #region - - - - - - Properties - - - - - -

        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Card> Deck { get; set; } = new List<Card>();
        public List<Card> Graveyard { get; set; } = new List<Card>();
        public List<MonsterCard> ExtraDeck { get; set; } = new List<MonsterCard>();
        public Field Field { get; set; }
        public IUserInteraction UserInteraction;

        #endregion Properties

        #region - - - - - - Constructor - - - - - -

        public Player(string name, EventBus eventBus, IUserInteraction userInteraction)
        {
            Name = name;
            Field = new(eventBus);
            UserInteraction = userInteraction;
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public void DrawCard()
        {
            Console.WriteLine($"{Name} draw a card");
            if (Deck.Count > 0)
            {
                Hand.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
            else
            {
                // Game should end with this players loss
            }
        }

        #endregion Methods

    }

}
