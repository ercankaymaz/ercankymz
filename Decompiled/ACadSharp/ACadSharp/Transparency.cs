using System;

namespace ACadSharp;

public struct Transparency
{
	private short _value = -1;

	public static Transparency ByLayer => new Transparency(-1);

	public static Transparency ByBlock => new Transparency(100);

	public static Transparency Opaque => new Transparency(0);

	public bool IsByLayer => _value == -1;

	public bool IsByBlock => _value == 100;

	public short Value
	{
		get
		{
			return _value;
		}
		set
		{
			switch (value)
			{
			case -1:
				_value = value;
				break;
			case 100:
				_value = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("value", value, "Transparency must be in range from 0 to 90.");
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				_value = value;
				break;
			}
		}
	}

	public Transparency(short value)
	{
		Value = value;
	}

	public static int ToAlphaValue(Transparency transparency)
	{
		byte b = (byte)((double)(255 * (100 - transparency.Value)) / 100.0);
		return BitConverter.ToInt32((!transparency.IsByBlock) ? new byte[4] { b, 0, 0, 2 } : new byte[4] { 0, 0, 0, 1 }, 0);
	}

	public static Transparency FromAlphaValue(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		short num = (short)(100.0 - (double)(int)bytes[0] / 255.0 * 100.0);
		if (num == -1)
		{
			return ByLayer;
		}
		if (num == 100)
		{
			return ByBlock;
		}
		if (num < 0)
		{
			return new Transparency(0);
		}
		if (num > 90)
		{
			return new Transparency(90);
		}
		return new Transparency(num);
	}
}
