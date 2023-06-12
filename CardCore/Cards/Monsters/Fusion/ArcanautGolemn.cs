using CardCore.Base;
using CardCore.Base.Cards;
using CardCore.Base.Events;
using CardCore.Enums;

namespace CardCore.Cards.Monsters.Fusion
{

    public class ArcanautGolemn : MonsterCard
    {

        #region - - - - - - Constructor - - - - - -

        public ArcanautGolemn()
        {
            Name = "Arcanaut's Golemn";
            Level = 5;
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
                if (args != null && args.SummonedMonster.Name.Contains("Arcanaut") && args.SummonedMonster != this && field.MonsterCardZones.Any(zone => zone.OccupyingCard == this))
                {
                    Console.WriteLine($"Adding {Name} effect to chain");
                    eventBus.AddToChain(this, () =>
                    {
                        Console.WriteLine($"Resolving {Name}");
                        player.DrawCard();
                    });
                }
            }
        }

        #endregion Methods

    }

}
