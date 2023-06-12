using CardCore.Base.Cards;

namespace CardCore.Interfaces
{

    public interface IUserInteraction
    {
        Guid ChooseCardFromList(List<Card> options, string promptMessage);
        int ChooseMonsterZone(List<int> emptyMonsterZones, string message);
    }

}
