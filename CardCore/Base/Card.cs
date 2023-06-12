using CardCore.Base;
using CardCore.Enums;

public abstract class Card
{

    #region - - - - - - Properties - - - - - -

    public Guid ID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Player Owner { get; set; }

    #endregion Properties

    #region - - - - - - Methods - - -

    public virtual void HandleEvent(EventTypeEnum eventType, EventArgs eventArgs, Player player, Field field, EventBus eventBus)
    {
        // This base implementation does nothing.
        // Derived classes can override this method to implement specific behavior in response to game events.
    }

    #endregion Methods

}
