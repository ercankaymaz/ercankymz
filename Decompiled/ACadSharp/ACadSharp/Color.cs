using System;
using CSUtilities.Converters;

namespace ACadSharp;

public readonly struct Color : IEquatable<Color>
{
	private const int _maxTrueColor = 16777216;

	private const int _trueColorFlag = 1073741824;

	private static readonly byte[][] _indexRgb = new byte[256][]
	{
		new byte[3],
		new byte[3] { 255, 0, 0 },
		new byte[3] { 255, 255, 0 },
		new byte[3] { 0, 255, 0 },
		new byte[3] { 0, 255, 255 },
		new byte[3] { 0, 0, 255 },
		new byte[3] { 255, 0, 255 },
		new byte[3] { 255, 255, 255 },
		new byte[3] { 128, 128, 128 },
		new byte[3] { 192, 192, 192 },
		new byte[3] { 255, 0, 0 },
		new byte[3] { 255, 127, 127 },
		new byte[3] { 165, 0, 0 },
		new byte[3] { 165, 82, 82 },
		new byte[3] { 127, 0, 0 },
		new byte[3] { 127, 63, 63 },
		new byte[3] { 76, 0, 0 },
		new byte[3] { 76, 38, 38 },
		new byte[3] { 38, 0, 0 },
		new byte[3] { 38, 19, 19 },
		new byte[3] { 255, 63, 0 },
		new byte[3] { 255, 159, 127 },
		new byte[3] { 165, 41, 0 },
		new byte[3] { 165, 103, 82 },
		new byte[3] { 127, 31, 0 },
		new byte[3] { 127, 79, 63 },
		new byte[3] { 76, 19, 0 },
		new byte[3] { 76, 47, 38 },
		new byte[3] { 38, 9, 0 },
		new byte[3] { 38, 28, 19 },
		new byte[3] { 255, 127, 0 },
		new byte[3] { 255, 191, 127 },
		new byte[3] { 165, 82, 0 },
		new byte[3] { 165, 124, 82 },
		new byte[3] { 127, 63, 0 },
		new byte[3] { 127, 95, 63 },
		new byte[3] { 76, 38, 0 },
		new byte[3] { 76, 57, 38 },
		new byte[3] { 38, 19, 0 },
		new byte[3] { 38, 28, 19 },
		new byte[3] { 255, 191, 0 },
		new byte[3] { 255, 223, 127 },
		new byte[3] { 165, 124, 0 },
		new byte[3] { 165, 145, 82 },
		new byte[3] { 127, 95, 0 },
		new byte[3] { 127, 111, 63 },
		new byte[3] { 76, 57, 0 },
		new byte[3] { 76, 66, 38 },
		new byte[3] { 38, 28, 0 },
		new byte[3] { 38, 33, 19 },
		new byte[3] { 255, 255, 0 },
		new byte[3] { 255, 255, 127 },
		new byte[3] { 165, 165, 0 },
		new byte[3] { 165, 165, 82 },
		new byte[3] { 127, 127, 0 },
		new byte[3] { 127, 127, 63 },
		new byte[3] { 76, 76, 0 },
		new byte[3] { 76, 76, 38 },
		new byte[3] { 38, 38, 0 },
		new byte[3] { 38, 38, 19 },
		new byte[3] { 191, 255, 0 },
		new byte[3] { 223, 255, 127 },
		new byte[3] { 124, 165, 0 },
		new byte[3] { 145, 165, 82 },
		new byte[3] { 95, 127, 0 },
		new byte[3] { 111, 127, 63 },
		new byte[3] { 57, 76, 0 },
		new byte[3] { 66, 76, 38 },
		new byte[3] { 28, 38, 0 },
		new byte[3] { 33, 38, 19 },
		new byte[3] { 127, 255, 0 },
		new byte[3] { 191, 255, 127 },
		new byte[3] { 82, 165, 0 },
		new byte[3] { 124, 165, 82 },
		new byte[3] { 63, 127, 0 },
		new byte[3] { 95, 127, 63 },
		new byte[3] { 38, 76, 0 },
		new byte[3] { 57, 76, 38 },
		new byte[3] { 19, 38, 0 },
		new byte[3] { 28, 38, 19 },
		new byte[3] { 63, 255, 0 },
		new byte[3] { 159, 255, 127 },
		new byte[3] { 41, 165, 0 },
		new byte[3] { 103, 165, 82 },
		new byte[3] { 31, 127, 0 },
		new byte[3] { 79, 127, 63 },
		new byte[3] { 19, 76, 0 },
		new byte[3] { 47, 76, 38 },
		new byte[3] { 9, 38, 0 },
		new byte[3] { 23, 38, 19 },
		new byte[3] { 0, 255, 0 },
		new byte[3] { 125, 255, 127 },
		new byte[3] { 0, 165, 0 },
		new byte[3] { 82, 165, 82 },
		new byte[3] { 0, 127, 0 },
		new byte[3] { 63, 127, 63 },
		new byte[3] { 0, 76, 0 },
		new byte[3] { 38, 76, 38 },
		new byte[3] { 0, 38, 0 },
		new byte[3] { 19, 38, 19 },
		new byte[3] { 0, 255, 63 },
		new byte[3] { 127, 255, 159 },
		new byte[3] { 0, 165, 41 },
		new byte[3] { 82, 165, 103 },
		new byte[3] { 0, 127, 31 },
		new byte[3] { 63, 127, 79 },
		new byte[3] { 0, 76, 19 },
		new byte[3] { 38, 76, 47 },
		new byte[3] { 0, 38, 9 },
		new byte[3] { 19, 88, 23 },
		new byte[3] { 0, 255, 127 },
		new byte[3] { 127, 255, 191 },
		new byte[3] { 0, 165, 82 },
		new byte[3] { 82, 165, 124 },
		new byte[3] { 0, 127, 63 },
		new byte[3] { 63, 127, 95 },
		new byte[3] { 0, 76, 38 },
		new byte[3] { 38, 76, 57 },
		new byte[3] { 0, 38, 19 },
		new byte[3] { 19, 88, 28 },
		new byte[3] { 0, 255, 191 },
		new byte[3] { 127, 255, 223 },
		new byte[3] { 0, 165, 124 },
		new byte[3] { 82, 165, 145 },
		new byte[3] { 0, 127, 95 },
		new byte[3] { 63, 127, 111 },
		new byte[3] { 0, 76, 57 },
		new byte[3] { 38, 76, 66 },
		new byte[3] { 0, 38, 28 },
		new byte[3] { 19, 88, 88 },
		new byte[3] { 0, 255, 255 },
		new byte[3] { 127, 255, 255 },
		new byte[3] { 0, 165, 165 },
		new byte[3] { 82, 165, 165 },
		new byte[3] { 0, 127, 127 },
		new byte[3] { 63, 127, 127 },
		new byte[3] { 0, 76, 76 },
		new byte[3] { 38, 76, 76 },
		new byte[3] { 0, 38, 38 },
		new byte[3] { 19, 88, 88 },
		new byte[3] { 0, 191, 255 },
		new byte[3] { 127, 223, 255 },
		new byte[3] { 0, 124, 165 },
		new byte[3] { 82, 145, 165 },
		new byte[3] { 0, 95, 127 },
		new byte[3] { 63, 111, 217 },
		new byte[3] { 0, 57, 76 },
		new byte[3] { 38, 66, 126 },
		new byte[3] { 0, 28, 38 },
		new byte[3] { 19, 88, 88 },
		new byte[3] { 0, 127, 255 },
		new byte[3] { 127, 191, 255 },
		new byte[3] { 0, 82, 165 },
		new byte[3] { 82, 124, 165 },
		new byte[3] { 0, 63, 127 },
		new byte[3] { 63, 95, 127 },
		new byte[3] { 0, 38, 76 },
		new byte[3] { 38, 57, 126 },
		new byte[3] { 0, 19, 38 },
		new byte[3] { 19, 28, 88 },
		new byte[3] { 0, 63, 255 },
		new byte[3] { 127, 159, 255 },
		new byte[3] { 0, 41, 165 },
		new byte[3] { 82, 103, 165 },
		new byte[3] { 0, 31, 127 },
		new byte[3] { 63, 79, 127 },
		new byte[3] { 0, 19, 76 },
		new byte[3] { 38, 47, 126 },
		new byte[3] { 0, 9, 38 },
		new byte[3] { 19, 23, 88 },
		new byte[3] { 0, 0, 255 },
		new byte[3] { 127, 127, 255 },
		new byte[3] { 0, 0, 165 },
		new byte[3] { 82, 82, 165 },
		new byte[3] { 0, 0, 127 },
		new byte[3] { 63, 63, 127 },
		new byte[3] { 0, 0, 76 },
		new byte[3] { 38, 38, 126 },
		new byte[3] { 0, 0, 38 },
		new byte[3] { 19, 19, 88 },
		new byte[3] { 63, 0, 255 },
		new byte[3] { 159, 127, 255 },
		new byte[3] { 41, 0, 165 },
		new byte[3] { 103, 82, 165 },
		new byte[3] { 31, 0, 127 },
		new byte[3] { 79, 63, 127 },
		new byte[3] { 19, 0, 76 },
		new byte[3] { 47, 38, 126 },
		new byte[3] { 9, 0, 38 },
		new byte[3] { 23, 19, 88 },
		new byte[3] { 127, 0, 255 },
		new byte[3] { 191, 127, 255 },
		new byte[3] { 165, 0, 82 },
		new byte[3] { 124, 82, 165 },
		new byte[3] { 63, 0, 127 },
		new byte[3] { 95, 63, 127 },
		new byte[3] { 38, 0, 76 },
		new byte[3] { 57, 38, 126 },
		new byte[3] { 19, 0, 38 },
		new byte[3] { 28, 19, 88 },
		new byte[3] { 191, 0, 255 },
		new byte[3] { 223, 127, 255 },
		new byte[3] { 124, 0, 165 },
		new byte[3] { 142, 82, 165 },
		new byte[3] { 95, 0, 127 },
		new byte[3] { 111, 63, 127 },
		new byte[3] { 57, 0, 76 },
		new byte[3] { 66, 38, 76 },
		new byte[3] { 28, 0, 38 },
		new byte[3] { 88, 19, 88 },
		new byte[3] { 255, 0, 255 },
		new byte[3] { 255, 127, 255 },
		new byte[3] { 165, 0, 165 },
		new byte[3] { 165, 82, 165 },
		new byte[3] { 127, 0, 127 },
		new byte[3] { 127, 63, 127 },
		new byte[3] { 76, 0, 76 },
		new byte[3] { 76, 38, 76 },
		new byte[3] { 38, 0, 38 },
		new byte[3] { 88, 19, 88 },
		new byte[3] { 255, 0, 191 },
		new byte[3] { 255, 127, 223 },
		new byte[3] { 165, 0, 124 },
		new byte[3] { 165, 82, 145 },
		new byte[3] { 127, 0, 95 },
		new byte[3] { 127, 63, 111 },
		new byte[3] { 76, 0, 57 },
		new byte[3] { 76, 38, 66 },
		new byte[3] { 38, 0, 28 },
		new byte[3] { 88, 19, 88 },
		new byte[3] { 255, 0, 127 },
		new byte[3] { 255, 127, 191 },
		new byte[3] { 165, 0, 82 },
		new byte[3] { 165, 82, 124 },
		new byte[3] { 127, 0, 63 },
		new byte[3] { 127, 63, 95 },
		new byte[3] { 76, 0, 38 },
		new byte[3] { 76, 38, 57 },
		new byte[3] { 38, 0, 19 },
		new byte[3] { 88, 19, 28 },
		new byte[3] { 255, 0, 63 },
		new byte[3] { 255, 127, 159 },
		new byte[3] { 165, 0, 41 },
		new byte[3] { 165, 82, 103 },
		new byte[3] { 127, 0, 31 },
		new byte[3] { 127, 63, 79 },
		new byte[3] { 76, 0, 19 },
		new byte[3] { 76, 38, 47 },
		new byte[3] { 38, 0, 9 },
		new byte[3] { 88, 19, 23 },
		new byte[3],
		new byte[3] { 101, 101, 101 },
		new byte[3] { 102, 102, 102 },
		new byte[3] { 153, 153, 153 },
		new byte[3] { 204, 204, 204 },
		new byte[3] { 255, 255, 255 }
	};

	private readonly uint _color;

	public static Color Black => new Color(250);

	public static Color Blue => new Color(5);

	public static Color ByBlock => new Color(0);

	public static Color ByEntity => new Color(257);

	public static Color ByLayer => new Color(256);

	public static Color Cyan => new Color(4);

	public static Color DarkGray => new Color(8);

	public static Color Default => new Color(7);

	public static Color Green => new Color(3);

	public static Color LightGray => new Color(9);

	public static Color Magenta => new Color(6);

	public static Color Red => new Color(1);

	public static Color Yellow => new Color(2);

	public byte B => GetRgb()[2];

	public byte G => GetRgb()[1];

	public short Index
	{
		get
		{
			if (!IsTrueColor)
			{
				return (short)_color;
			}
			return -1;
		}
	}

	public bool IsByBlock => Index == 0;

	public bool IsByLayer => Index == 256;

	public bool IsTrueColor
	{
		get
		{
			if (_color <= 257)
			{
				return _color < 0;
			}
			return true;
		}
	}

	public byte R => GetRgb()[0];

	public int TrueColor
	{
		get
		{
			if (!IsTrueColor)
			{
				return -1;
			}
			return (int)(_color ^ 0x40000000);
		}
	}

	public Color(short index)
	{
		if (index < 0 || index > 257)
		{
			throw new ArgumentOutOfRangeException("index", "True index must be a value between 0 and 257.");
		}
		_color = (uint)index;
	}

	public Color(byte r, byte g, byte b)
		: this(new byte[3] { r, g, b })
	{
	}

	public Color(byte[] rgb)
		: this(getInt24(rgb))
	{
	}

	private Color(uint trueColor)
	{
		if (trueColor < 0 || trueColor > 16777216)
		{
			throw new ArgumentOutOfRangeException("trueColor", "True color must be a 24 bit color.");
		}
		_color = trueColor | 0x40000000;
	}

	public static byte ApproxIndex(byte r, byte g, byte b)
	{
		int num = -1;
		for (int i = 0; i < _indexRgb.Length; i++)
		{
			int num2 = r - _indexRgb[i][0] + (g - _indexRgb[i][1]) + (b - _indexRgb[i][2]);
			if (num2 == 0)
			{
				return (byte)i;
			}
			if (num2 < num)
			{
				num = num2;
				return (byte)i;
			}
		}
		return 0;
	}

	public static Color FromTrueColor(uint color)
	{
		return new Color(color);
	}

	public static ReadOnlySpan<byte> GetIndexRGB(byte index)
	{
		return _indexRgb[index].AsSpan();
	}

	public bool Equals(Color other)
	{
		return _color == other._color;
	}

	public override bool Equals(object obj)
	{
		if (obj is Color other)
		{
			return Equals(other);
		}
		return false;
	}

	public byte GetApproxIndex()
	{
		if (IsTrueColor)
		{
			return ApproxIndex(R, G, B);
		}
		return (byte)Index;
	}

	public override int GetHashCode()
	{
		return (int)_color;
	}

	public ReadOnlySpan<byte> GetRgb()
	{
		if (IsTrueColor)
		{
			return GetTrueColorRgb();
		}
		return GetIndexRGB((byte)_color);
	}

	public ReadOnlySpan<byte> GetTrueColorRgb()
	{
		if (IsTrueColor)
		{
			return getRGBfromTrueColor(_color);
		}
		return default(ReadOnlySpan<byte>);
	}

	public override string ToString()
	{
		if (_color == 0)
		{
			return "ByBlock";
		}
		if (_color == 256)
		{
			return "ByLayer";
		}
		if (IsTrueColor)
		{
			ReadOnlySpan<byte> trueColorRgb = GetTrueColorRgb();
			return $"True Color RGB:{trueColorRgb[0]},{trueColorRgb[1]},{trueColorRgb[2]}";
		}
		return $"Indexed Color:{Index}";
	}

	private static uint getInt24(byte[] array)
	{
		if (BitConverter.IsLittleEndian)
		{
			return (uint)(array[0] | (array[1] << 8) | (array[2] << 16));
		}
		return (uint)((array[0] << 16) | (array[1] << 8) | array[2]);
	}

	private static ReadOnlySpan<byte> getRGBfromTrueColor(uint color)
	{
		return new ReadOnlySpan<byte>(LittleEndianConverter.Instance.GetBytes(color), 0, 3);
	}
}
