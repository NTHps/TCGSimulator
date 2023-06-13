using CardCore.Cards.Monsters.Fusion;
using CardCore.Cards.Spells;
using CardCore.Enums;
using CardCore.Interfaces;

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

        public Game(IUserInteraction userInteraction)
        {
            EventBus = new EventBus();
            Player1 = new Player("Player 1", EventBus, userInteraction);
            Player2 = new Player("Player 2", EventBus, userInteraction);
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        /// <summary>
        /// Currenlty being used to test out situations in the game
        /// Right now we setup the players deck, extra deck, and hand
        /// </summary>
        public void Start()
        {
            // Setup Player 1

            Player1.ExtraDeck.Add(new ArcanautGolemn() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });
            Player1.ExtraDeck.Add(new ArcanautGolemn() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });
            Player1.ExtraDeck.Add(new ArcanautGolemn() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });
            Player1.ExtraDeck.Add(new ArcanautGoddess() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });
            Player1.ExtraDeck.Add(new ArcanautGoddess() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });
            Player1.ExtraDeck.Add(new ArcanautGoddess() { Owner = Player1, Position = CardPositionEnum.ExtraDeck });

            Player1.Hand.Add(new ArcanautAstralCompass() { Owner = Player1, Position = CardPositionEnum.Hand });
            Player1.Hand.Add(new ArcanautNewWorld() { Owner = Player1, Position = CardPositionEnum.Hand });

            Player1.Deck.Add(new ArcanautNewWorld() { Owner = Player1, Position = CardPositionEnum.Deck });
            Player1.Deck.Add(new ArcanautNewWorld() { Owner = Player1, Position = CardPositionEnum.Deck });
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
            => Player1.Field.ActivateSpellCard(new ArcanautAstralCompass(), Player1);

        public string GetCurrentChainLink()
            => this.EventBus.GetChainLink();

        #endregion Methods

    }

}
