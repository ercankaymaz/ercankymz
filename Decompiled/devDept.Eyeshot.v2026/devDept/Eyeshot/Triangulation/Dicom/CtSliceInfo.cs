using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class CtSliceInfo : ICloneable
{
	private sealed class _0023_003DzzLhUVRya0DcX9yJhBkpRHtg_003D
	{
		public string _0023_003DzglxwfnCu1T0v;

		internal bool _0023_003DzhtxtgiBUu03eo29l_0024A_003D_003D(XElement _0023_003Dz9j4kMjs_003D)
		{
			return _0023_003Dz9j4kMjs_003D.Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008330)).Value.Equals(_0023_003DzglxwfnCu1T0v);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly XDocument _0023_003DzjbpLdgY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzZK7It3UlVYw4 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016364);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzZzfkCezK6Leu = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz_YB1RkM0gVf3 = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzWfs1lzV4GS24 = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzFR_G8A8Ed_OD = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzTN7ut6NLAlW4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzfgplQQ8tC657 = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzaiOxV_J1oQuB = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[,] _0023_003Dz8uGCM0BwsIFQLjEq7M_fCHxXP0QntWxsuA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzhiCHGnkJaluE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzENd1U6OuE30h = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DztHnYQdk_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzcrYuyRw_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzDjtIMs6rcCDfFcaxuw_003D_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzIAPjVKEzaemxALhnbA_003D_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzHBJPn303iRMbZSAU6g_003D_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DzZduld_0024BKirPWbWk50cBqNwM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DzdkGt_0024u7Ky0YPKVz2FQZRUKg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _0023_003Dzc9ZWdVHDqz2w = -1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _0023_003DztHReFaba_00244wt = -1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzpy4gKeABF8pB;

	internal int lastWindowCenter;

	internal int lastWindowWidth;

	internal Bitmap bitmap;

	public string TransferSyntax => _0023_003DzZK7It3UlVYw4;

	public int PixelRepresentation => _0023_003DzZzfkCezK6Leu;

	public int WindowCenter => _0023_003Dz_YB1RkM0gVf3;

	public int WindowWidth => _0023_003DzWfs1lzV4GS24;

	public int PixelPaddingValue => _0023_003DzFR_G8A8Ed_OD;

	public string FilePath => _0023_003DzTN7ut6NLAlW4;

	public int SamplePerPixel => _0023_003DzfgplQQ8tC657;

	public int BitsAllocated => _0023_003DzaiOxV_J1oQuB;

	public string PhotometricInterpretation => _0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D;

	public double RescaleIntercept => _0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D;

	public double RescaleSlope => _0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D;

	protected int[,] HounsfieldPixelBuffer
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz8uGCM0BwsIFQLjEq7M_fCHxXP0QntWxsuA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz8uGCM0BwsIFQLjEq7M_fCHxXP0QntWxsuA_003D_003D = value;
		}
	}

	protected byte[] FrameData
	{
		get
		{
			return _0023_003DzhiCHGnkJaluE;
		}
		set
		{
			_0023_003DzhiCHGnkJaluE = value;
		}
	}

	public int InstanceNumber => _0023_003DzENd1U6OuE30h;

	public int Columns => _0023_003DztHnYQdk_003D;

	public int Rows => _0023_003DzcrYuyRw_003D;

	public double ImageUpperLeftX => _0023_003DzDjtIMs6rcCDfFcaxuw_003D_003D;

	public double ImageUpperLeftY => _0023_003DzIAPjVKEzaemxALhnbA_003D_003D;

	public double ImageUpperLeftZ => _0023_003DzHBJPn303iRMbZSAU6g_003D_003D;

	public Vector3D ImageRowDirection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZduld_0024BKirPWbWk50cBqNwM_003D;
		}
	}

	public Vector3D ImageColumnDirection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzdkGt_0024u7Ky0YPKVz2FQZRUKg_003D;
		}
	}

	public float PixelSpacingRow => _0023_003Dzc9ZWdVHDqz2w;

	public float PixelSpacingColumn => _0023_003DztHReFaba_00244wt;

	public float SliceThickness => _0023_003Dzpy4gKeABF8pB;

	protected CtSliceInfo(CtSliceInfo another)
		: this(another._0023_003DzjbpLdgY_003D, another._0023_003DzTN7ut6NLAlW4)
	{
		HounsfieldPixelBuffer = another.HounsfieldPixelBuffer;
	}

	public CtSliceInfo(XDocument xDocument, string filePath)
	{
		HounsfieldPixelBuffer = null;
		_0023_003DzjbpLdgY_003D = xDocument;
		_0023_003DzTN7ut6NLAlW4 = filePath;
		_0023_003DzZK7It3UlVYw4 = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(xDocument, 131088u);
		_0023_003DzcrYuyRw_003D = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621456u, -1);
		_0023_003DztHnYQdk_003D = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621457u, -1);
		string text = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(xDocument, 2097202u);
		if (!text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016364)))
		{
			string[] array = text.Split('\\');
			_0023_003DzDjtIMs6rcCDfFcaxuw_003D_003D = Convert.ToDouble(array[0], CultureInfo.InvariantCulture);
			_0023_003DzIAPjVKEzaemxALhnbA_003D_003D = Convert.ToDouble(array[1], CultureInfo.InvariantCulture);
			_0023_003DzHBJPn303iRMbZSAU6g_003D_003D = Convert.ToDouble(array[2], CultureInfo.InvariantCulture);
		}
		string text2 = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(xDocument, 2097207u);
		if (!text2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016364)))
		{
			string[] array2 = text2.Split('\\');
			double x = Convert.ToDouble(array2[0], CultureInfo.InvariantCulture);
			double y = Convert.ToDouble(array2[1], CultureInfo.InvariantCulture);
			double z = Convert.ToDouble(array2[2], CultureInfo.InvariantCulture);
			double x2 = Convert.ToDouble(array2[3], CultureInfo.InvariantCulture);
			double y2 = Convert.ToDouble(array2[4], CultureInfo.InvariantCulture);
			double z2 = Convert.ToDouble(array2[5], CultureInfo.InvariantCulture);
			_0023_003Dzln_0024QnlCyHuDS(new Vector3D(x, y, z));
			_0023_003DzSupcHzVPTquU(new Vector3D(x2, y2, z2));
		}
		string text3 = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(xDocument, 2621488u);
		if (!text3.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016364)))
		{
			string[] array3 = text3.Split('\\');
			_0023_003Dzc9ZWdVHDqz2w = Convert.ToSingle(array3[0], CultureInfo.InvariantCulture);
			_0023_003DztHReFaba_00244wt = Convert.ToSingle(array3[1], CultureInfo.InvariantCulture);
		}
		_0023_003Dzpy4gKeABF8pB = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003Dz2OFiXHtgfP5LwoQP4w_003D_003D(_0023_003DzjbpLdgY_003D, 1572944u, 0f);
		_0023_003DzZzfkCezK6Leu = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621699u, -1);
		_0023_003Dz_YB1RkM0gVf3 = (int)_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzpCbgJ2XQpT_0024kCIb2cQ_003D_003D(xDocument, 2625616u, -1.0);
		_0023_003DzWfs1lzV4GS24 = (int)_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzpCbgJ2XQpT_0024kCIb2cQ_003D_003D(xDocument, 2625617u, -1.0);
		_0023_003DzFR_G8A8Ed_OD = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621728u, -1);
		_0023_003DzfgplQQ8tC657 = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621442u, -1);
		_0023_003DzaiOxV_J1oQuB = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(xDocument, 2621696u, -1);
		_0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(xDocument, 2621444u).Trim();
		_0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzpCbgJ2XQpT_0024kCIb2cQ_003D_003D(_0023_003DzjbpLdgY_003D, 2625618u, 0.0);
		_0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzpCbgJ2XQpT_0024kCIb2cQ_003D_003D(_0023_003DzjbpLdgY_003D, 2625619u, 1.0);
		_0023_003DzENd1U6OuE30h = _0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzfB70gn5wi3_EyB4Wpg_003D_003D(_0023_003DzjbpLdgY_003D, 2097171u, -1);
	}

	private void _0023_003Dzln_0024QnlCyHuDS(Vector3D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzZduld_0024BKirPWbWk50cBqNwM_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzSupcHzVPTquU(Vector3D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzdkGt_0024u7Ky0YPKVz2FQZRUKg_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual object Clone()
	{
		return new CtSliceInfo(this);
	}

	private bool _0023_003Dz5mWe77hrcg_7I24NvNgJurg_003D()
	{
		if (_0023_003DzZK7It3UlVYw4.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016342)) > -1 || _0023_003DzZK7It3UlVYw4.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016322)) > -1 || _0023_003DzZK7It3UlVYw4 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016364) || !_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzMWvb1nRiGOH1xFJPzQ_003D_003D(_0023_003DzjbpLdgY_003D, 2145386512u))
		{
			return false;
		}
		return true;
	}

	internal void _0023_003DzhbX985NquXluGVgI1mPXckGtNe4s(Point3D _0023_003DzByovJZS5rmTL)
	{
		_0023_003DzDjtIMs6rcCDfFcaxuw_003D_003D -= _0023_003DzByovJZS5rmTL.X;
		_0023_003DzIAPjVKEzaemxALhnbA_003D_003D -= _0023_003DzByovJZS5rmTL.Y;
		_0023_003DzHBJPn303iRMbZSAU6g_003D_003D -= _0023_003DzByovJZS5rmTL.Z;
	}

	public int GetHounsfieldPixelValue(int rowIndex, int columnIndex)
	{
		if (HounsfieldPixelBuffer == null)
		{
			_0023_003DzkPdbofaUuJsQbvACv96jZ_0024w_003D();
		}
		if (HounsfieldPixelBuffer == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016334));
		}
		return HounsfieldPixelBuffer[rowIndex, columnIndex];
	}

	internal int _0023_003Dzx8DVDTwkMTFPLX5gb_ZDv6Q7bCZ3()
	{
		if (HounsfieldPixelBuffer == null)
		{
			_0023_003DzkPdbofaUuJsQbvACv96jZ_0024w_003D();
		}
		if (HounsfieldPixelBuffer == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016334));
		}
		return HounsfieldPixelBuffer.Cast<int>().Max();
	}

	internal int _0023_003Dz5UK12ngL_jUSqp2fFBU9L6XxX36b()
	{
		if (HounsfieldPixelBuffer == null)
		{
			_0023_003DzkPdbofaUuJsQbvACv96jZ_0024w_003D();
		}
		if (HounsfieldPixelBuffer == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016334));
		}
		return HounsfieldPixelBuffer.Cast<int>().Min();
	}

	public virtual void SetPixelData()
	{
		_0023_003DzzLhUVRya0DcX9yJhBkpRHtg_003D CS_0024_003C_003E8__locals2 = new _0023_003DzzLhUVRya0DcX9yJhBkpRHtg_003D();
		if (!_0023_003Dz5mWe77hrcg_7I24NvNgJurg_003D())
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016001), _0023_003DzZK7It3UlVYw4, Environment.NewLine));
		}
		HounsfieldPixelBuffer = new int[_0023_003DzcrYuyRw_003D, _0023_003DztHnYQdk_003D];
		CS_0024_003C_003E8__locals2._0023_003DzglxwfnCu1T0v = DicomDictionary._0023_003DzBmBvgEOj4Iim(2145386512u);
		long position = Convert.ToInt64((from _0023_003Dz9j4kMjs_003D in _0023_003DzjbpLdgY_003D.Descendants(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016184))
			where _0023_003Dz9j4kMjs_003D.Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008330)).Value.Equals(CS_0024_003C_003E8__locals2._0023_003DzglxwfnCu1T0v)
			select _0023_003Dz9j4kMjs_003D).Last().Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016170)).Value);
		BinaryReader binaryReader = new BinaryReader(File.Open(_0023_003DzTN7ut6NLAlW4, FileMode.Open, FileAccess.Read, FileShare.Read));
		binaryReader.BaseStream.Position = position;
		if (_0023_003DzfgplQQ8tC657 == 1 && _0023_003DzaiOxV_J1oQuB == 8)
		{
			int num = _0023_003DztHnYQdk_003D * _0023_003DzcrYuyRw_003D;
			FrameData = new byte[num];
			binaryReader.Read(FrameData, 0, num);
		}
		if (_0023_003DzfgplQQ8tC657 == 3 && _0023_003DzaiOxV_J1oQuB == 8)
		{
			int num2 = _0023_003DztHnYQdk_003D * _0023_003DzcrYuyRw_003D * _0023_003DzfgplQQ8tC657;
			FrameData = new byte[num2];
			binaryReader.Read(FrameData, 0, num2);
		}
		if (_0023_003DzfgplQQ8tC657 != 1 || _0023_003DzaiOxV_J1oQuB != 16)
		{
			return;
		}
		FrameData = new byte[_0023_003DzcrYuyRw_003D * _0023_003DztHnYQdk_003D * 2];
		int num3 = 0;
		long length = binaryReader.BaseStream.Length;
		long num4 = 0L;
		for (int num5 = 0; num5 < _0023_003DzcrYuyRw_003D; num5++)
		{
			for (int num6 = 0; num6 < _0023_003DztHnYQdk_003D; num6++)
			{
				if (num4 - 2 < length)
				{
					byte b = binaryReader.ReadByte();
					byte b2 = binaryReader.ReadByte();
					num4 += 2;
					FrameData[num3++] = b;
					FrameData[num3++] = b2;
				}
			}
		}
	}

	internal void _0023_003DzkPdbofaUuJsQbvACv96jZ_0024w_003D()
	{
		if (HounsfieldPixelBuffer != null)
		{
			return;
		}
		HounsfieldPixelBuffer = new int[_0023_003DzcrYuyRw_003D, _0023_003DztHnYQdk_003D];
		int num = 0;
		int num2 = 255;
		int num3 = 65535;
		int num4 = 0;
		SetPixelData();
		for (int i = 0; i < _0023_003DzcrYuyRw_003D; i++)
		{
			for (int j = 0; j < _0023_003DztHnYQdk_003D; j++)
			{
				int num5 = 0;
				if (_0023_003DzfgplQQ8tC657 == 1 && _0023_003DzaiOxV_J1oQuB == 8)
				{
					int num6 = Convert.ToInt32(FrameData[num4++] << 8);
					if (_0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016157))
					{
						num5 = num2 - num5;
					}
					if (_0023_003DzZzfkCezK6Leu == 0)
					{
						num5 -= num;
					}
					num5 = (int)((double)num6 * _0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D + _0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D);
				}
				if (_0023_003DzfgplQQ8tC657 == 1 && _0023_003DzaiOxV_J1oQuB == 16)
				{
					byte b = FrameData[num4++];
					byte b2 = FrameData[num4++];
					int num7 = Convert.ToInt32((b2 << 8) + b);
					if (_0023_003DzZzfkCezK6Leu == 0)
					{
						num5 = (int)((double)num7 * _0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D + _0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D);
						if (_0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016157))
						{
							num5 = num3 - num5;
						}
					}
					else
					{
						num5 = (int)((double)BitConverter.ToInt16(new byte[2] { b, b2 }, 0) * _0023_003DzzvyVMmf3xaZp0YQfs1Jrk24_003D + _0023_003DzkZvYqhxAb_0024f2UD_eMg_003D_003D);
						if (_0023_003DzyFjHLgJ0aNvRWZO9LP_0024it_0024M_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016157))
						{
							num5 = num3 - num5;
						}
					}
				}
				HounsfieldPixelBuffer[i, j] = num5;
			}
		}
	}

	internal byte[,] _0023_003DzUkUunQI_003D()
	{
		return GetPixels(0, 0);
	}

	internal byte[,] GetPixels(int _0023_003DzoVONsT_00247sIRL, int _0023_003Dzbw2wmweMbgyS)
	{
		byte[,] array = new byte[_0023_003DzcrYuyRw_003D, _0023_003DztHnYQdk_003D];
		_0023_003DzUkUunQI_003D(array, _0023_003DzoVONsT_00247sIRL, _0023_003Dzbw2wmweMbgyS);
		return array;
	}

	internal void _0023_003DzUkUunQI_003D(byte[,] _0023_003DzyICHo57SU_0024xQ)
	{
		_0023_003DzUkUunQI_003D(_0023_003DzyICHo57SU_0024xQ, _0023_003Dz_YB1RkM0gVf3, _0023_003DzWfs1lzV4GS24);
	}

	internal void _0023_003DzUkUunQI_003D(byte[,] _0023_003DzyICHo57SU_0024xQ, int _0023_003DzoVONsT_00247sIRL, int _0023_003Dzbw2wmweMbgyS)
	{
		if (_0023_003DzoVONsT_00247sIRL == 0 && _0023_003Dzbw2wmweMbgyS == 0)
		{
			_0023_003DzoVONsT_00247sIRL = _0023_003Dz_YB1RkM0gVf3;
			_0023_003Dzbw2wmweMbgyS = _0023_003DzWfs1lzV4GS24;
		}
		int _0023_003DzkWZCXcpI02At = _0023_003DzoVONsT_00247sIRL - _0023_003Dzbw2wmweMbgyS / 2;
		for (int i = 0; i < _0023_003DzcrYuyRw_003D; i++)
		{
			for (int j = 0; j < _0023_003DztHnYQdk_003D; j++)
			{
				_0023_003DzyICHo57SU_0024xQ[i, j] = _0023_003DzHk27_vMmOuhO(GetHounsfieldPixelValue(i, j), _0023_003DzkWZCXcpI02At, _0023_003Dzbw2wmweMbgyS);
			}
		}
	}

	internal static byte _0023_003DzHk27_vMmOuhO(int _0023_003Dzzrj7kadYynba, int _0023_003DzkWZCXcpI02At, int _0023_003Dzbw2wmweMbgyS)
	{
		int num = 255 * (_0023_003Dzzrj7kadYynba - _0023_003DzkWZCXcpI02At) / _0023_003Dzbw2wmweMbgyS;
		if (num <= 0)
		{
			return 0;
		}
		if (num >= 255)
		{
			return byte.MaxValue;
		}
		return Convert.ToByte(num);
	}
}
