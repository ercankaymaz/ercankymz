using System;

namespace ACadSharp.IO;

public class NotificationEventArgs : EventArgs
{
	public string Message { get; }

	public NotificationType NotificationType { get; }

	public Exception Exception { get; }

	public NotificationEventArgs(string message, NotificationType notificationType = NotificationType.None, Exception exception = null)
	{
		Message = message;
		NotificationType = notificationType;
		Exception = exception;
	}
}
