namespace CardCore.Base
{

    public class Zone<T> where T : Card
    {
        public T OccupyingCard { get; set; }
    }

}
