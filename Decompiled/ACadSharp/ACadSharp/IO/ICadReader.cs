using System;
using ACadSharp.Header;

namespace ACadSharp.IO;

public interface ICadReader : IDisposable
{
	event NotificationEventHandler OnNotification;

	CadHeader ReadHeader();

	CadDocument Read();
}
