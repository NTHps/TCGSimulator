﻿using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Cards.Monsters.Fusion
{

    public class RunickHugin : MonsterCard
    {

        #region - - - - - - Constructor - - - - - -

        public RunickHugin()
        {
            Name = "Runick Hugin";
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
                if (args != null && args.SummonedMonster == this)
                {
                    // Check if the player has at least one card in hand to discard.
                    if (player.Hand.Count > 0)
                    {
                        Console.WriteLine("Adding Runick Hugin effect to chain");
                        // Trigger effect
                        eventBus.AddToChain(this, () =>
                        {
                            Console.WriteLine("Resolving Runick Hugin");
                            // Discard the first card in hand.
                            var discardedCard = player.Hand[0];
                            player.Hand.RemoveAt(0);
                            player.Graveyard.Add(discardedCard);

                            // Search for 'Runick Fountain' in the deck.
                            var runickFountain = player.Deck.FirstOrDefault(card => card.Name == "Runick Fountain");
                            if (runickFountain != null)
                            {
                                // Remove from deck and add to hand.
                                player.Deck.Remove(runickFountain);
                                player.Hand.Add(runickFountain);
                            }
                        });
                    }
                }
            }
        }

        #endregion Methods

    }

}
