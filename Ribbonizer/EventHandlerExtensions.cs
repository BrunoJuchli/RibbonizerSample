namespace Ribbonizer
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Helper class for events
    /// </summary>
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Invoke the specified event with null checking.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <extensiondoc category="Events" />
        public static void SafeInvoke(this EventHandler eventHandler, object sender, EventArgs e)
        {
            EventHandler handler = eventHandler;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void SafeInvoke(this EventHandler eventHandler, object sender)
        {
            eventHandler.SafeInvoke(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Invoke the specified event with null checking.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event args.</typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <extensiondoc category="Events" />
        public static void SafeInvoke<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e)
            where TEventArgs : EventArgs
        {
            EventHandler<TEventArgs> handler = eventHandler;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void SafeInvoke(this PropertyChangedEventHandler eventHandler, object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = eventHandler;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}