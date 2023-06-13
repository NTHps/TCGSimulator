using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Cards.Monsters.Fusion
{

    public class ArcanautGoddess : MonsterCard
    {

        #region - - - - - - Constructor - - - - - -

        public ArcanautGoddess()
        {
            Name = "Arcanaut's Goddess";
            Level = 2;
            ExtraDeckType = ExtraDeckTypeEnum.Fusion;
            AttackPoints = 0;
            DefensePoints = 0;
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public override void HandleEvent(EventTypeEnum eventType, EventArgs eventArgs, Player player, Field field, EventBus eventBus)
        {
            if (eventType == EventTypeEnum.SpecialSummon)
            {
                var args = eventArgs as SpecialSummonedEventArgs;
                if (args != null && args.SummonedMonster == this && args.From == CardPositionEnum.ExtraDeck)
                {
                    // Check if the player has at least one card in hand to discard.
                    if (player.Hand.Count > 0 && player.Deck.Any(c => c.Name == "Arcanaut New World"))
                    {
                        Console.WriteLine($"Adding {Name} effect to chain");
                        // Trigger effect
                        eventBus.AddToChain(this, () =>
                        {
                            Console.WriteLine($"Resolving {Name}");
                            // Player can choose card to discard
                            List<Card> _CardsInHand = player.Hand
                                .Cast<Card>()
                                .ToList();
                            var _ChosenCardID = player.UserInteraction.ChooseCardFromList(_CardsInHand, "Choose a card to discard:");
                            var _ChosenCard = player.Hand.SingleOrDefault(c => c.ID == _ChosenCardID);
                            player.Hand.Remove(_ChosenCard);
                            player.Graveyard.Add(_ChosenCard);
                            _ChosenCard.Position = CardPositionEnum.Graveyard;

                            // Search for 'Runick Fountain' in the deck.
                            var runickFountain = player.Deck.FirstOrDefault(card => card.Name == "Arcanaut New World");
                            if (runickFountain != null)
                            {
                                // Remove from deck and add to hand.
                                player.Deck.Remove(runickFountain);
                                player.Hand.Add(runickFountain);
                                runickFountain.Position = CardPositionEnum.Hand;
                            }
                        });
                    }
                }
            }
        }

        #endregion Methods

    }

}
