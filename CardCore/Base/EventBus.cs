using CardCore.Enums;
using System.Text;

namespace CardCore.Base
{

    public class EventBus
    {

        #region - - - - - - Fields - - - - - -

        private Stack<ChainLink> m_ChainLinks = new Stack<ChainLink>();
        private Dictionary<EventTypeEnum, Action<object, EventArgs>> m_EventHandlers = new Dictionary<EventTypeEnum, Action<object, EventArgs>>();
        private bool m_IsResolvingChain = false;
        private List<(EventTypeEnum eventType, object sender, EventArgs eventArgs)> m_PendingActivations = new List<(EventTypeEnum, object, EventArgs)>();

        #endregion Fields

        #region - - - - - - Methods - - - - - -

        /// <summary>
        /// Add a an action to the currently building chain link
        /// </summary>
        /// <param name="card"></param>
        /// <param name="action"></param>
        public void AddToChain(Card card, Action action)
        {
            if (m_IsResolvingChain)
            {
                // Don't allow new chain links to be added while the chain is resolving
                return;
            }
            m_ChainLinks.Push(new ChainLink { Card = card, Action = action });
        }

        public string GetChainLink()
        {
            StringBuilder _StringBuilder = new();
            foreach (var (_ChainLink, _Index) in this.m_ChainLinks.Select((value, index) => (value, index)).OrderByDescending(c => c.index))
                _StringBuilder.AppendLine($"Chain Link {this.m_ChainLinks.Count() - (_Index + 1) + 1}: {_ChainLink.Card.Name}");
            return _StringBuilder.ToString();
        }

        /// <summary>
        /// This will resolve the collection of chained effects activated.
        /// During the resolving of the chain link, more effects or triggers may occur, we'll delay that using Pending Activities
        /// </summary>
        public void ResolveChain()
        {
            m_IsResolvingChain = true;
            Console.WriteLine("Resolving chain");

            // First, resolve the current chain.
            while (m_ChainLinks.Count > 0)
            {
                ChainLink chainLink = m_ChainLinks.Pop();
                chainLink.Action();
            }

            // Now, process the pending activations
            m_IsResolvingChain = false;
            while (m_PendingActivations.Count > 0)
            {
                var (eventType, sender, eventArgs) = m_PendingActivations[0];
                m_PendingActivations.RemoveAt(0);

                if (m_EventHandlers.ContainsKey(eventType))
                {
                    m_EventHandlers[eventType]?.Invoke(sender, eventArgs);
                }
            }
        }

        /// <summary>
        /// Registers a card so that it can listen to the event bus
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        public void Register(EventTypeEnum eventType, Action<object, EventArgs> handler)
        {
            Console.WriteLine("Register card");
            if (m_EventHandlers.ContainsKey(eventType))
            {
                m_EventHandlers[eventType] += handler;
            }
            else
            {
                m_EventHandlers[eventType] = handler;
            }
        }

        /// <summary>
        /// Unregister, may not be required as all cards could be listening for events regardless where they are
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        public void Unregister(EventTypeEnum eventType, Action<object, EventArgs> handler)
        {
            Console.WriteLine("Unregister card");
            if (m_EventHandlers.ContainsKey(eventType))
            {
                m_EventHandlers[eventType] -= handler;

                if (m_EventHandlers[eventType] == null)
                {
                    m_EventHandlers.Remove(eventType);
                }
            }
        }

        /// <summary>
        /// Raise an event
        /// For example, if a special summon is to occur we will let everything listening to the event bus be aware of it for triggers
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void RaiseEvent(EventTypeEnum eventType, object sender, EventArgs eventArgs)
        {
            if (m_IsResolvingChain)
            {
                Console.WriteLine("Pending event event" + eventType.ToString());
                m_PendingActivations.Add((eventType, sender, eventArgs));
            }
            else if (m_EventHandlers.ContainsKey(eventType))
            {
                Console.WriteLine("Raising event" + eventType.ToString());
                m_EventHandlers[eventType]?.Invoke(sender, eventArgs);
            }
        }

        #endregion Methods

    }

}
