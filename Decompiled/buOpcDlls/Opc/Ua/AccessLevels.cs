using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class AccessLevels
{
	public const byte None = 0;

	public const byte CurrentRead = 1;

	public const byte CurrentWrite = 2;

	public const byte CurrentReadOrWrite = 3;

	public const byte HistoryRead = 4;

	public const byte HistoryWrite = 8;

	public const byte HistoryReadOrWrite = 12;

	public const byte SemanticChange = 16;

	public const byte StatusWrite = 32;

	public const byte TimestampWrite = 64;
}
