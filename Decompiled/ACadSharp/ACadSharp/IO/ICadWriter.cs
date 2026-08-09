using System;

namespace ACadSharp.IO;

public interface ICadWriter : IDisposable
{
	event NotificationEventHandler OnNotification;

	void Write();
}
