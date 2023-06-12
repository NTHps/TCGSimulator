using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Cards.Spells
{

    public class RunickCalling : SpellCard
    {

        #region - - - - - - Constructor - - - - - -

        public RunickCalling()
        {
            Name = "Runick Calling";
            SpellType = SpellTypeEnum.Normal;
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public override void HandleEvent(EventTypeEnum eventType, EventArgs eventArgs, Player player, Field field, EventBus eventBus)
        {
            // This ensures that the card responds only to its own activation.
            if (eventType == EventTypeEnum.SpellCardActivated && eventArgs is SpellCardActivatedEventArgs args && args.ActivatedSpell == this)
            {
                // Search the player's extra deck for the first fusion monster with "Runick" in its name, we'll have to figure out a way to select with the client later
                MonsterCard runickMonster = player.ExtraDeck.FirstOrDefault(card => card.Name.Contains("Runick") && card.ExtraDeckType == ExtraDeckTypeEnum.Fusion);

                // If a Runick monster is found in the Extra Deck, Special Summon it.
                if (runickMonster != null)
                {
                    // Get the position of the first empty Monster Zone.
                    int position = 0;

                    // Special Summon the monster to the position if a position is found.
                    if (position >= 0)
                    {
                        Console.WriteLine("Runick calling resolution");
                        player.Field.SpecialSummon(runickMonster, player, position);
                    }
                }
            }
        }

        #endregion Methods

    }

}
