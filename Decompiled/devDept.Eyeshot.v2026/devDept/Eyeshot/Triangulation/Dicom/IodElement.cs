using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class IodElement : DicomElement
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Iod _0023_003DzByiKipanA57T02a4Ng_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CtSliceInfo _0023_003DzhIN2arAjpzFx;

	public Iod Tag
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

	public override List<DicomElement> Elements
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public CtSliceInfo SliceInfo
	{
		get
		{
			return _0023_003DzhIN2arAjpzFx;
		}
		set
		{
			_0023_003DzhIN2arAjpzFx = value;
		}
	}

	public IodElement(string header, Iod tag, DicomElement parent = null)
		: base(header, dicomNodeType.Instance, parent)
	{
		Tag = tag;
		_0023_003DzhIN2arAjpzFx = new CtSliceInfo(Tag.XDocument, Tag.FilePath);
	}

	public DicomVersion GetDicomVersion()
	{
		return Tag._0023_003Dz8mKCrvnmRs_00243pxn8uw_003D_003D();
	}

	public bool IsSupportedDicomFile()
	{
		if (GetDicomVersion() == DicomVersion.NotDicom || GetDicomVersion() == DicomVersion.DicomUnknownTransferSyntax)
		{
			return false;
		}
		return true;
	}

	public string GetTransferSyntax()
	{
		return _0023_003DzhIN2arAjpzFx.TransferSyntax;
	}

	public int GetWindowWidth()
	{
		return _0023_003DzhIN2arAjpzFx.WindowWidth;
	}

	public int GetWindowCenter()
	{
		return _0023_003DzhIN2arAjpzFx.WindowCenter;
	}

	public int GetPixelPaddingValue()
	{
		return _0023_003DzhIN2arAjpzFx.PixelPaddingValue;
	}

	public void GetPixelSpacing(out float rowSpace, out float columnSpace)
	{
		rowSpace = _0023_003DzhIN2arAjpzFx.PixelSpacingRow;
		columnSpace = _0023_003DzhIN2arAjpzFx.PixelSpacingColumn;
	}

	public float GetSliceThickness()
	{
		return _0023_003DzhIN2arAjpzFx.SliceThickness;
	}

	public int GetColumns()
	{
		return _0023_003DzhIN2arAjpzFx.Columns;
	}

	public int GetRows()
	{
		return _0023_003DzhIN2arAjpzFx.Rows;
	}

	public void BuildHounsfieldValues()
	{
		_0023_003DzhIN2arAjpzFx._0023_003DzkPdbofaUuJsQbvACv96jZ_0024w_003D();
	}

	public int GetHounsfieldPixelValue(int rowIndex, int columnIndex)
	{
		return _0023_003DzhIN2arAjpzFx.GetHounsfieldPixelValue(rowIndex, columnIndex);
	}

	internal int _0023_003Dz5UK12ngL_jUSqp2fFBU9L6XxX36b()
	{
		return _0023_003DzhIN2arAjpzFx._0023_003Dz5UK12ngL_jUSqp2fFBU9L6XxX36b();
	}

	internal int _0023_003Dzx8DVDTwkMTFPLX5gb_ZDv6Q7bCZ3()
	{
		return _0023_003DzhIN2arAjpzFx._0023_003Dzx8DVDTwkMTFPLX5gb_ZDv6Q7bCZ3();
	}

	internal PictureData<byte> _0023_003DzdRw237_VBwCQ()
	{
		int rows = GetRows();
		int columns = GetColumns();
		PictureData<byte> pictureData = new PictureData<byte>(rows, columns);
		_0023_003DzUkUunQI_003D(pictureData.Pixels);
		return pictureData;
	}

	internal void _0023_003DzUkUunQI_003D(byte[,] _0023_003Dzzu7EYTqTUzCw)
	{
		_0023_003DzhIN2arAjpzFx = new CtSliceInfo(Tag.XDocument, Tag.FilePath);
		_0023_003DzhIN2arAjpzFx._0023_003DzUkUunQI_003D(_0023_003Dzzu7EYTqTUzCw);
	}

	internal void _0023_003DzUkUunQI_003D(byte[,] _0023_003Dzzu7EYTqTUzCw, int _0023_003DzoVONsT_00247sIRL, int _0023_003Dzbw2wmweMbgyS)
	{
		_0023_003DzhIN2arAjpzFx = new CtSliceInfo(Tag.XDocument, Tag.FilePath);
		_0023_003DzhIN2arAjpzFx._0023_003DzUkUunQI_003D(_0023_003Dzzu7EYTqTUzCw, _0023_003DzoVONsT_00247sIRL, _0023_003Dzbw2wmweMbgyS);
	}

	private DicomElement _0023_003DzEt7rVh0_003D()
	{
		string arg = Tag.FilePath.Split('\\')[^1];
		DicomElement dicomElement = new DicomElement(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902690), arg));
		foreach (XElement item in Tag.XDocument.Descendants(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902266)).First().Elements(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016184)))
		{
			_0023_003DzcwIFKraRHrvVo95qqA_003D_003D(dicomElement, item);
		}
		return dicomElement;
	}

	private void _0023_003DzcwIFKraRHrvVo95qqA_003D_003D(DicomElement _0023_003Dz5kIxngk_003D, XElement _0023_003DzbToXAQk_003D)
	{
		string value = _0023_003DzbToXAQk_003D.Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008330)).Value;
		string value2 = _0023_003DzbToXAQk_003D.Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902184)).Value;
		string text = _0023_003DzbToXAQk_003D.Attribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902152)).Value;
		if (value.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303017600)))
		{
			text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902674), text, TransferSyntaxDictionary.GetTransferSyntaxName(text));
		}
		if (value.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303019233)))
		{
			text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902674), text, SopClassDictionary.GetSopClassName(text));
		}
		string text2 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908656), value, value2);
		text2 = string.Format(arg0: (text2.Length <= 50) ? text2.PadRight(50) : text2.Remove(50), format: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908656), arg1: text);
		DicomElement dicomElement = new DicomElement(text2, dicomNodeType.Tag, _0023_003Dz5kIxngk_003D);
		_0023_003Dz5kIxngk_003D.Elements.Add(dicomElement);
		if (!_0023_003DzbToXAQk_003D.HasElements)
		{
			return;
		}
		foreach (XElement item in _0023_003DzbToXAQk_003D.Elements(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016184)))
		{
			_0023_003DzcwIFKraRHrvVo95qqA_003D_003D(dicomElement, item);
		}
	}
}
