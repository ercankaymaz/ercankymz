using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public static class TcpMessageType
{
	public const uint Final = 1174405120u;

	public const uint Intermediate = 1124073472u;

	public const uint Abort = 1090519040u;

	public const uint MessageTypeMask = 16777215u;

	public const uint ChunkTypeMask = 4278190080u;

	public const uint MessageIntermediate = 1128747853u;

	public const uint MessageFinal = 1179079501u;

	public const uint Message = 4674381u;

	public const uint Open = 5132367u;

	public const uint Close = 5196867u;

	public const uint Hello = 1179403592u;

	public const uint ReverseHello = 1178945618u;

	public const uint Acknowledge = 1179337537u;

	public const uint Error = 1179800133u;

	public static bool IsType(uint actualType, uint expectedType)
	{
		return (actualType & 0xFFFFFF) == expectedType;
	}

	public static bool IsFinal(uint messageType)
	{
		return (messageType & 0xFF000000u) == 1174405120;
	}

	public static bool IsAbort(uint messageType)
	{
		return (messageType & 0xFF000000u) == 1090519040;
	}

	public static bool IsValid(uint messageType)
	{
		switch (messageType)
		{
		case 1178945618u:
		case 1179337537u:
		case 1179403592u:
		case 1179800133u:
			return true;
		default:
		{
			if ((messageType & 0xFF000000u) != 1174405120 && (messageType & 0xFF000000u) != 1124073472)
			{
				return false;
			}
			uint num = messageType & 0xFFFFFF;
			if (num != 4674381 && num != 5132367 && num != 5196867)
			{
				return false;
			}
			return true;
		}
		}
	}
}
