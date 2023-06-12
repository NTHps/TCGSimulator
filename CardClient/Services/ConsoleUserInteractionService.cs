using CardCore.Interfaces;

namespace CardClient.Services
{

    public class ConsoleUserInteraction : IUserInteraction
    {

        public Guid ChooseCardFromList(List<Card> options, string promptMessage)
        {
            Console.WriteLine(promptMessage);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {options[i].Name}");
            }

            int choice = int.Parse(Console.ReadLine());
            var _ChosenCard = options[choice-1];
            return _ChosenCard.ID;
        }

        public int ChooseMonsterZone(List<int> emptyMonsterZones, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < emptyMonsterZones.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Zone {emptyMonsterZones[i] + 1}");
            }

            int _SelectedOption = 0;
            while (!int.TryParse(Console.ReadLine(), out _SelectedOption) || _SelectedOption < 1 || _SelectedOption > emptyMonsterZones.Count)
            {
                Console.WriteLine("Invalid choice, please choose again.");
            }

            return emptyMonsterZones[_SelectedOption - 1];
        }

    }

}
