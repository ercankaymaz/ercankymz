using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class EventNotifiers
{
	public const byte None = 0;

	public const byte SubscribeToEvents = 1;

	public const byte HistoryRead = 4;

	public const byte HistoryWrite = 8;
}
