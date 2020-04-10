using System;
using FluentSecurity.Diagnostics.Events;

namespace FluentSecurity.Diagnostics
{
	public class AnonymousSecurityEventListener : ISecurityEventListener
	{
		public Action<ISecurityEvent> EventListener { get; private set; }

		public AnonymousSecurityEventListener(Action<ISecurityEvent> eventListener)
		{
            EventListener = eventListener ?? throw new ArgumentNullException(nameof(eventListener));
		}

		public void Handle(ISecurityEvent securityEvent)
		{
			try
			{
				EventListener.Invoke(securityEvent);
			}
            catch
            {
                // ignored
            }
        }
	}
}