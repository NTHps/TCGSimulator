using CardCore.Cards.Monsters.Fusion;
using CardCore.Cards.Spells;

namespace CardCore.Base
{

    public class Game
    {

        #region - - - - - - Properties - - - - - -

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public EventBus EventBus { get; private set; }

        #endregion Properties


        #region - - - - - - Constructor - - - - - -

        public Game()
        {
            EventBus = new EventBus();
            Player1 = new Player("Player 1", EventBus);
            Player2 = new Player("Player 2", EventBus);
        }

        #endregion Constructor


        #region - - - - - - Methods - - - - - -

        /// <summary>
        /// Currenlty being used to test out situations in the game
        /// Right now we setup the players deck, extra deck, and hand
        /// </summary>
        public void Start()
        {
            // You can include initial setup logic here, like shuffling decks, drawing starting hands, etc.

            var _RunickHugin = new RunickHugin();
            var _RunickCalling = new RunickCalling();

            Player1.ExtraDeck.Add(new RunickDog());
            Player1.ExtraDeck.Add(_RunickHugin);
            Player1.Hand.Add(_RunickCalling);
            Player1.Hand.Add(new RunickFountain());

            Player1.Deck.Add(new RunickFountain());
            Player1.Deck.Add(new RunickFountain());
            Player1.Deck.Add(new RunickFountain());
            Player1.Deck.Add(new RunickFountain());
        }

        /// <summary>
        /// Public method to resolve a chain link
        /// </summary>
        public void Resolve()
            => EventBus.ResolveChain();

        /// <summary>
        /// For testing purposes, active this spell card to test game logic
        /// </summary>
        public void ActivateRunickCalling()
            => Player1.Field.ActivateSpellCard(new RunickCalling(), Player1);

        #endregion Methods

    }

}
