using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Cards.Spells
{

    public class ArcanautAstralCompass : SpellCard
    {

        #region - - - - - - Constructor - - - - - -

        public ArcanautAstralCompass()
        {
            Name = "Arcanaut's Astral Compass";
            SpellType = SpellTypeEnum.QuickPlay;
        }

        #endregion Constructor

        #region - - - - - - Methods - - - - - -

        public override void HandleEvent(EventTypeEnum eventType, EventArgs eventArgs, Player player, Field field, EventBus eventBus)
        {
            // This ensures that the card responds only to its own activation.
            if (eventType == EventTypeEnum.SpellCardActivated && eventArgs is SpellCardActivatedEventArgs args && args.ActivatedSpell == this)
            {
                // Search the player's extra deck for fusion monsters with "Arcanaut" in their name.
                List<Card> _ArcanautMonsters = player.ExtraDeck
                    .Where(card => card.Name.Contains("Arcanaut") && card is MonsterCard monsterCard && monsterCard.ExtraDeckType == ExtraDeckTypeEnum.Fusion)
                    .Cast<Card>()
                    .ToList();

                if (_ArcanautMonsters.Count > 0)
                {
                    var _ChosenCardID = player.UserInteraction.ChooseCardFromList(_ArcanautMonsters, "Choose an Arcanaut monster to summon:");
                    var _ArcanautMonster = player.ExtraDeck.SingleOrDefault(ed => ed.ID == _ChosenCardID);
                    // If a Arcanaut monster is chosen and found in the Extra Deck, Special Summon it.
                    if (_ArcanautMonster != null)
                    {
                        // User can select an empty zone
                        var _EmptyMonsterZones = field.GetEmptyMonsterZones();
                        int _SelectedZone = player.UserInteraction.ChooseMonsterZone(_EmptyMonsterZones, $"Choose a zone to summon {Name} monster to:");

                        // Special Summon the monster to the position if a position is found.
                        if (_SelectedZone >= 0)
                        {
                            Console.WriteLine($"Runick {Name}");
                            player.Field.SpecialSummon(_ArcanautMonster, player, _SelectedZone);
                        }
                    }

                }
            }
        }

        #endregion Methods

    }

}
