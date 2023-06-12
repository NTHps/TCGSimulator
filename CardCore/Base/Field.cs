using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Base
{

    public class Field
    {

        #region - - - - - - Fields - - - - - -

        private EventBus m_EventBus;

        #endregion Fields

        #region - - - - - - Properties - - - - - -
        public Zone<MonsterCard>[] MonsterCardZones { get; } = new Zone<MonsterCard>[5];
        public Zone<SpellCard>[] SpellAndTrapCardZones { get; } = new Zone<SpellCard>[5];
        public Zone<SpellCard> FieldSpellZone { get; } = new Zone<SpellCard>();
        public Zone<MonsterCard>[] ExtraDeckZones { get; } = new Zone<MonsterCard>[2];

        #endregion Properties

        #region - - - - - - Constructor - - - - - -
        public Field(EventBus eventBus)
        {
            m_EventBus = eventBus;

            // Initialise zones, do something better later
            for (int i = 0; i < MonsterCardZones.Length; i++)
            {
                MonsterCardZones[i] = new Zone<MonsterCard>();
            }

            for (int i = 0; i < SpellAndTrapCardZones.Length; i++)
            {
                SpellAndTrapCardZones[i] = new Zone<SpellCard>();
            }

            for (int i = 0; i < ExtraDeckZones.Length; i++)
            {
                ExtraDeckZones[i] = new Zone<MonsterCard>();
            }
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public void SpecialSummon(MonsterCard card, Player player, int position)
        {
            if (position < 0 || position >= MonsterCardZones.Count())
            {
                throw new ArgumentException("Invalid position for special summon.");
            }

            if (MonsterCardZones[position].OccupyingCard != null)
            {
                throw new ArgumentException("The selected monster zone is already occupied.");
            }

            // Remove card from original position
            // TO DO: Create more generic means of removing and placing cards
            if (card.ExtraDeckType.HasValue)
                player.ExtraDeck.Remove(card);
            else if (player.Hand.Any(c => c.ID == card.ID))
                player.Hand.Remove(card);
            else if (player.Graveyard.Any(c => c.ID == card.ID))
                player.Graveyard.Remove(card);

            // Place the card in the chosen monster zone
            Console.WriteLine("Special summoning: " + card.Name);
            this.MonsterCardZones[position].OccupyingCard = card;

            // Register
            // TO DO: Might just register every card in the game start. This way cards in the hand or graveyard can have effects triggered. 
            m_EventBus.Register(EventTypeEnum.SpecialSummon, (sender, eventArgs) => card.HandleEvent(EventTypeEnum.SpecialSummon, eventArgs, player, this, m_EventBus));

            // Raise event to indicate a monster has been special summoned.
            m_EventBus.RaiseEvent(EventTypeEnum.SpecialSummon, this, new SpecialSummonedEventArgs { Player = player, SummonedMonster = card });
        }

        public void ActivateSpellCard(SpellCard spellCard, Player player)
        {
            Console.WriteLine("Activating spell: " + spellCard.Name);
            // Register
            // TO DO: Might just register every card in the game start. This way cards in the hand or graveyard can have effects triggered. 
            m_EventBus.Register(EventTypeEnum.SpellCardActivated, (sender, eventArgs) => spellCard.HandleEvent(EventTypeEnum.SpellCardActivated, eventArgs, player, this, m_EventBus));

            m_EventBus.AddToChain(spellCard, () =>
            {
                // Raise the event to notify that the Spell card has been activated.
                m_EventBus.RaiseEvent(EventTypeEnum.SpellCardActivated, this, new SpellCardActivatedEventArgs { Player = player, ActivatedSpell = spellCard });

                // Optionally can unregister the card after it has been activated.I don't think I ever want to do this, as the card could have interaction in the graveyard
                //m_EventBus.Unregister(EventTypeEnum.SpellCardActivated, (sender, eventArgs) => spellCard.HandleEvent(EventTypeEnum.SpellCardActivated, eventArgs, player, this, m_EventBus));
            });
        }

        #endregion Methods

    }

}
