using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using devDept.Geometry;

namespace devDept.Serialization;

public sealed class FileHeader
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyBRP4053wGoTJUgRTg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly serializationType _0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly fileType _0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly contentType _0023_003DzJbRvCIbvl65qygMHuA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzk8C_bfHJFWZCm58EBmp8bQHi3F3R;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DateTime _0023_003DzUU2IiRnxinoAmJHENg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzByiKipanA57T02a4Ng_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzD_dwQLiFZbeZkVYHuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003Dz4Xm4mt_0024I0cX4;

	public linearUnitsType Units
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;
		}
	}

	public string Author
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzthm2Q35IG0_e_DHakg_003D_003D = value;
		}
	}

	public string Organization
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyBRP4053wGoTJUgRTg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzyBRP4053wGoTJUgRTg_003D_003D = value;
		}
	}

	public string OriginatingSystem
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D = value;
		}
	}

	public int Version
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D;
		}
	}

	public serializationType SerializationMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D;
		}
	}

	public fileType FileMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D;
		}
	}

	public contentType Content
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJbRvCIbvl65qygMHuA_003D_003D;
		}
	}

	public string EyeshotBuild
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzk8C_bfHJFWZCm58EBmp8bQHi3F3R;
		}
	}

	public DateTime Timestamp
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUU2IiRnxinoAmJHENg_003D_003D;
		}
	}

	public string Tag
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzByiKipanA57T02a4Ng_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzByiKipanA57T02a4Ng_003D_003D = value;
		}
	}

	public byte[] Thumbnail
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzD_dwQLiFZbeZkVYHuQ_003D_003D;
		}
	}

	public string FileName => Path.GetFileName(_0023_003Dz4Xm4mt_0024I0cX4);

	public FileHeader(contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, fileType fileType = fileType.Standard, linearUnitsType units = linearUnitsType.Meters)
		: this(Serializer.LastVersion, contentType, serializationType, fileType, units)
	{
	}

	internal FileHeader(int _0023_003DzQ3hPewo_003D, contentType _0023_003DzB5M5dYA_003D = contentType.GeometryAndTessellation, serializationType _0023_003DzISThhDg_003D = serializationType.Uncompressed, fileType _0023_003Dz_0024QaoO_A_003D = fileType.Standard, linearUnitsType _0023_003DzsAi4oSk_003D = linearUnitsType.Meters)
	{
		_0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D = _0023_003DzQ3hPewo_003D;
		_0023_003Dz8sHpP7nYkasn(_0023_003DzsAi4oSk_003D);
		_0023_003DzJbRvCIbvl65qygMHuA_003D_003D = _0023_003DzB5M5dYA_003D;
		_0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D = _0023_003DzISThhDg_003D;
		_0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D = _0023_003Dz_0024QaoO_A_003D;
		_0023_003Dza6autTNkd0_Wm70TtQ_003D_003D();
	}

	private void _0023_003Dza6autTNkd0_Wm70TtQ_003D_003D()
	{
		LicenseManager._0023_003DzNrvBEfk_003D(out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _0023_003DzQ8YZULhVjvRB, out var _);
		_0023_003DzmNWLvYCqfoy6snwXiw_003D_003D(_0023_003DzQ8YZULhVjvRB + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzQ3hPewo_003D.ToString());
	}

	internal void _0023_003Dz8sHpP7nYkasn(linearUnitsType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzmNWLvYCqfoy6snwXiw_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzk8C_bfHJFWZCm58EBmp8bQHi3F3R = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzrqzVY_0024yjCIPY(DateTime _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzUU2IiRnxinoAmJHENg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dz9TTXsLAw_0024c31(byte[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzD_dwQLiFZbeZkVYHuQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public FileHeaderSurrogate ConvertToSurrogate()
	{
		return new FileHeaderSurrogate(this);
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670383) + Timestamp.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670344) + Version);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670590) + EyeshotBuild);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670547) + Content);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670537) + Units);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670522) + SerializationMode);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670486) + FileMode);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671221) + FileName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671185) + Author);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671169) + Organization);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671159) + OriginatingSystem);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955800) + Tag);
		return stringBuilder.ToString();
	}
}
