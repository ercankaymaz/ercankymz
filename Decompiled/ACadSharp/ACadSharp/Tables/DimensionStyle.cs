using System;
using ACadSharp.Attributes;
using ACadSharp.Types.Units;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("DIMSTYLE")]
[DxfSubClass("AcDbDimStyleTableRecord")]
public class DimensionStyle : TableEntry
{
	public const string DefaultName = "Standard";

	public const string StyleOverrideEntryName = "DSTYLE";

	private double _arrowSize = 0.18;

	private BlockRecord _dimArrow1;

	private BlockRecord _dimArrow2;

	private BlockRecord _dimArrowBlock;

	private double _joggedRadiusDimensionTransverseSegmentAngle = Math.PI / 4.0;

	private BlockRecord _leaderArrow;

	private LineType _lineType;

	private LineType _lineTypeExt1;

	private LineType _lineTypeExt2;

	private double _scaleFactor = 1.0;

	private TextStyle _style = TextStyle.Default;

	private double _textHeight = 0.18;

	public static DimensionStyle Default => new DimensionStyle("Standard");

	[DxfCodeValue(new int[] { 4 })]
	public string AlternateDimensioningSuffix { get; set; } = "[]";

	[DxfCodeValue(new int[] { 171 })]
	public short AlternateUnitDecimalPlaces { get; set; } = 3;

	[DxfCodeValue(new int[] { 170 })]
	public bool AlternateUnitDimensioning { get; set; }

	[DxfCodeValue(new int[] { 273 })]
	public LinearUnitFormat AlternateUnitFormat { get; set; } = LinearUnitFormat.Decimal;

	[DxfCodeValue(new int[] { 148 })]
	public double AlternateUnitRounding { get; set; }

	[DxfCodeValue(new int[] { 143 })]
	public double AlternateUnitScaleFactor { get; set; } = 25.4;

	[DxfCodeValue(new int[] { 274 })]
	public short AlternateUnitToleranceDecimalPlaces { get; set; } = 3;

	[DxfCodeValue(new int[] { 286 })]
	public ZeroHandling AlternateUnitToleranceZeroHandling { get; set; }

	[DxfCodeValue(new int[] { 285 })]
	public ZeroHandling AlternateUnitZeroHandling { get; set; }

	[DxfCodeValue(new int[] { 179 })]
	public short AngularDecimalPlaces { get; set; }

	[DxfCodeValue(new int[] { 275 })]
	public AngularUnitFormat AngularUnit { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public ZeroHandling AngularZeroHandling { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public ArcLengthSymbolPosition ArcLengthSymbolPosition { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 342 })]
	public BlockRecord ArrowBlock
	{
		get
		{
			return _dimArrowBlock;
		}
		set
		{
			_dimArrowBlock = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 41 })]
	public double ArrowSize
	{
		get
		{
			return _arrowSize;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The ArrowSize must be equals or greater than zero.");
			}
			_arrowSize = value;
		}
	}

	[DxfCodeValue(new int[] { 141 })]
	public double CenterMarkSize { get; set; } = 0.09;

	[DxfCodeValue(new int[] { 288 })]
	public bool CursorUpdate { get; set; }

	[DxfCodeValue(new int[] { 271 })]
	public short DecimalPlaces { get; set; } = 2;

	[DxfCodeValue(new int[] { 278 })]
	public char DecimalSeparator { get; set; } = '.';

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 343 })]
	public BlockRecord DimArrow1
	{
		get
		{
			return _dimArrow1;
		}
		set
		{
			_dimArrow1 = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 344 })]
	public BlockRecord DimArrow2
	{
		get
		{
			return _dimArrow2;
		}
		set
		{
			_dimArrow2 = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 287 })]
	public short DimensionFit { get; set; }

	[DxfCodeValue(new int[] { 176 })]
	public Color DimensionLineColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 46 })]
	public double DimensionLineExtension { get; set; }

	[DxfCodeValue(new int[] { 147 })]
	public double DimensionLineGap { get; set; } = 0.625;

	[DxfCodeValue(new int[] { 43 })]
	public double DimensionLineIncrement { get; set; } = 3.75;

	[DxfCodeValue(new int[] { 371 })]
	public LineWeightType DimensionLineWeight { get; set; } = LineWeightType.ByBlock;

	[DxfCodeValue(new int[] { 289 })]
	public TextArrowFitType DimensionTextArrowFit { get; set; } = TextArrowFitType.BestFit;

	[DxfCodeValue(new int[] { 270 })]
	public short DimensionUnit { get; set; } = 2;

	[DxfCodeValue(new int[] { 177 })]
	public Color ExtensionLineColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 44 })]
	public double ExtensionLineExtension { get; set; } = 1.25;

	[DxfCodeValue(new int[] { 42 })]
	public double ExtensionLineOffset { get; set; } = 0.625;

	[DxfCodeValue(new int[] { 372 })]
	public LineWeightType ExtensionLineWeight { get; set; } = LineWeightType.ByBlock;

	[DxfCodeValue(new int[] { 49 })]
	public double FixedExtensionLineLength { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 276 })]
	public FractionFormat FractionFormat { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public bool GenerateTolerances { get; set; }

	[DxfCodeValue(new int[] { 290 })]
	public bool IsExtensionLineLengthFixed { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double JoggedRadiusDimensionTransverseSegmentAngle
	{
		get
		{
			return _joggedRadiusDimensionTransverseSegmentAngle;
		}
		set
		{
			double num = Math.Round(value, 6);
			if (num <= MathHelper.DegToRad(5.0) || num >= Math.PI / 2.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The JoggedRadiusDimensionTransverseSegmentAngle must be in range of 5 to 90 degrees.");
			}
			_joggedRadiusDimensionTransverseSegmentAngle = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 341 })]
	public BlockRecord LeaderArrow
	{
		get
		{
			return _leaderArrow;
		}
		set
		{
			_leaderArrow = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 72 })]
	public bool LimitsGeneration { get; set; }

	[DxfCodeValue(new int[] { 144 })]
	public double LinearScaleFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 277 })]
	public LinearUnitFormat LinearUnitFormat { get; set; } = LinearUnitFormat.Decimal;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 345 })]
	public LineType LineType
	{
		get
		{
			return _lineType;
		}
		set
		{
			_lineType = CadObject.updateCollection(value, base.Document?.LineTypes);
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 346 })]
	public LineType LineTypeExt1
	{
		get
		{
			return _lineTypeExt1;
		}
		set
		{
			_lineTypeExt1 = CadObject.updateCollection(value, base.Document?.LineTypes);
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 347 })]
	public LineType LineTypeExt2
	{
		get
		{
			return _lineTypeExt2;
		}
		set
		{
			_lineTypeExt2 = CadObject.updateCollection(value, base.Document?.LineTypes);
		}
	}

	[DxfCodeValue(new int[] { 48 })]
	public double MinusTolerance { get; set; }

	public override string ObjectName => "DIMSTYLE";

	public override ObjectType ObjectType => ObjectType.DIMSTYLE;

	[DxfCodeValue(new int[] { 47 })]
	public double PlusTolerance { get; set; }

	[DxfCodeValue(new int[] { 3 })]
	public string PostFix { get; set; } = "<>";

	public string Prefix
	{
		get
		{
			getDimStylePrefixAndSuffix(PostFix, '<', '>', out var prefix, out var _);
			return prefix;
		}
		set
		{
			getDimStylePrefixAndSuffix(PostFix, '<', '>', out var _, out var suffix);
			PostFix = value + PostFix + suffix;
		}
	}

	[DxfCodeValue(new int[] { 45 })]
	public double Rounding { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double ScaleFactor
	{
		get
		{
			return _scaleFactor;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The ScaleFactor must be equals or greater than zero.");
			}
			_scaleFactor = value;
		}
	}

	[DxfCodeValue(new int[] { 173 })]
	public bool SeparateArrowBlocks { get; set; } = true;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public TextStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_style = CadObject.updateCollection(value, base.Document?.TextStyles);
		}
	}

	public override string SubclassMarker => "AcDbDimStyleTableRecord";

	public string Suffix
	{
		get
		{
			getDimStylePrefixAndSuffix(PostFix, '<', '>', out var _, out var suffix);
			return suffix;
		}
		set
		{
			getDimStylePrefixAndSuffix(PostFix, '<', '>', out var prefix, out var _);
			PostFix = prefix + PostFix + value;
		}
	}

	[DxfCodeValue(new int[] { 281 })]
	public bool SuppressFirstDimensionLine { get; set; }

	[DxfCodeValue(new int[] { 75 })]
	public bool SuppressFirstExtensionLine { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public bool SuppressOutsideExtensions { get; set; }

	[DxfCodeValue(new int[] { 282 })]
	public bool SuppressSecondDimensionLine { get; set; }

	[DxfCodeValue(new int[] { 76 })]
	public bool SuppressSecondExtensionLine { get; set; }

	public Color TextBackgroundColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 69 })]
	public DimensionTextBackgroundFillMode TextBackgroundFillMode { get; set; }

	[DxfCodeValue(new int[] { 178 })]
	public Color TextColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 295 })]
	public TextDirection TextDirection { get; set; }

	[DxfCodeValue(new int[] { 140 })]
	public double TextHeight
	{
		get
		{
			return _textHeight;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The TextHeight must be greater than zero.");
			}
			_textHeight = value;
		}
	}

	[DxfCodeValue(new int[] { 280 })]
	public DimensionTextHorizontalAlignment TextHorizontalAlignment { get; set; }

	[DxfCodeValue(new int[] { 174 })]
	public bool TextInsideExtensions { get; set; }

	[DxfCodeValue(new int[] { 73 })]
	public bool TextInsideHorizontal { get; set; }

	[DxfCodeValue(new int[] { 279 })]
	public TextMovement TextMovement { get; set; }

	[DxfCodeValue(new int[] { 172 })]
	public bool TextOutsideExtensions { get; set; }

	[DxfCodeValue(new int[] { 74 })]
	public bool TextOutsideHorizontal { get; set; }

	[DxfCodeValue(new int[] { 77 })]
	public DimensionTextVerticalAlignment TextVerticalAlignment { get; set; } = DimensionTextVerticalAlignment.Above;

	[DxfCodeValue(new int[] { 145 })]
	public double TextVerticalPosition { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double TickSize { get; set; }

	[DxfCodeValue(new int[] { 283 })]
	public ToleranceAlignment ToleranceAlignment { get; set; }

	[DxfCodeValue(new int[] { 272 })]
	public short ToleranceDecimalPlaces { get; set; } = 2;

	[DxfCodeValue(new int[] { 146 })]
	public double ToleranceScaleFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 284 })]
	public ZeroHandling ToleranceZeroHandling { get; set; } = ZeroHandling.SuppressDecimalTrailingZeroes;

	[DxfCodeValue(new int[] { 78 })]
	public ZeroHandling ZeroHandling { get; set; } = ZeroHandling.SuppressDecimalTrailingZeroes;

	internal double AltMzf { get; set; }

	internal string AltMzs { get; set; }

	internal double Mzf { get; set; }

	internal string Mzs { get; set; }

	public DimensionStyle(string name)
		: base(name)
	{
	}

	internal DimensionStyle()
	{
	}

	public double ApplyRounding(double value, bool isAlternate = false)
	{
		double num = (isAlternate ? AlternateUnitRounding : Rounding);
		if (num != 0.0)
		{
			value = num * Math.Round(value / num);
		}
		return value;
	}

	public override CadObject Clone()
	{
		DimensionStyle obj = (DimensionStyle)base.Clone();
		obj.Style = (TextStyle)(Style?.Clone());
		obj.LeaderArrow = (BlockRecord)(LeaderArrow?.Clone());
		obj.ArrowBlock = (BlockRecord)(ArrowBlock?.Clone());
		obj.DimArrow1 = (BlockRecord)(DimArrow1?.Clone());
		obj.DimArrow2 = (BlockRecord)(DimArrow2?.Clone());
		obj.LineType = (LineType)(LineType?.Clone());
		obj.LineTypeExt1 = (LineType)(LineTypeExt1?.Clone());
		obj.LineTypeExt2 = (LineType)(LineTypeExt2?.Clone());
		return obj;
	}

	public UnitStyleFormat GetAlternateUnitStyleFormat()
	{
		return new UnitStyleFormat
		{
			LinearDecimalPlaces = AlternateUnitDecimalPlaces,
			AngularDecimalPlaces = AlternateUnitDecimalPlaces,
			DecimalSeparator = DecimalSeparator.ToString(),
			FractionHeightScale = ToleranceScaleFactor,
			FractionType = FractionFormat,
			LinearZeroHandling = AlternateUnitZeroHandling,
			AngularZeroHandling = AlternateUnitZeroHandling
		};
	}

	public UnitStyleFormat GetUnitStyleFormat()
	{
		return new UnitStyleFormat
		{
			LinearDecimalPlaces = DecimalPlaces,
			AngularDecimalPlaces = ((AngularDecimalPlaces == -1) ? DecimalPlaces : AngularDecimalPlaces),
			DecimalSeparator = DecimalSeparator.ToString(),
			FractionHeightScale = ToleranceScaleFactor,
			FractionType = FractionFormat,
			LinearZeroHandling = ZeroHandling,
			AngularZeroHandling = AngularZeroHandling
		};
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(Style, doc.TextStyles);
		_lineType = CadObject.updateCollection(LineType, doc.LineTypes);
		_lineTypeExt1 = CadObject.updateCollection(LineTypeExt1, doc.LineTypes);
		_lineTypeExt2 = CadObject.updateCollection(LineTypeExt2, doc.LineTypes);
		_leaderArrow = CadObject.updateCollection(LeaderArrow, doc.BlockRecords);
		_dimArrow1 = CadObject.updateCollection(DimArrow1, doc.BlockRecords);
		_dimArrow2 = CadObject.updateCollection(DimArrow2, doc.BlockRecords);
		_dimArrowBlock = CadObject.updateCollection(ArrowBlock, doc.BlockRecords);
		doc.DimensionStyles.OnRemove += tableOnRemove;
		doc.LineTypes.OnRemove += tableOnRemove;
		doc.BlockRecords.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.DimensionStyles.OnRemove -= tableOnRemove;
		base.Document.LineTypes.OnRemove -= tableOnRemove;
		base.Document.BlockRecords.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		Style = (TextStyle)Style.Clone();
		LineType = (LineType)(LineType?.Clone());
		LineTypeExt1 = (LineType)(LineTypeExt1?.Clone());
		LineTypeExt2 = (LineType)(LineTypeExt2?.Clone());
		LeaderArrow = (BlockRecord)(LeaderArrow?.Clone());
		DimArrow1 = (BlockRecord)(DimArrow1?.Clone());
		DimArrow2 = (BlockRecord)(DimArrow2?.Clone());
		ArrowBlock = (BlockRecord)(ArrowBlock?.Clone());
	}

	protected void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Style))
		{
			Style = base.Document.TextStyles["Standard"];
		}
		if (e.Item is LineType entry)
		{
			LineType = checkRemovedEntry(entry, LineType);
			LineTypeExt1 = checkRemovedEntry(entry, LineTypeExt1);
			LineTypeExt2 = checkRemovedEntry(entry, LineTypeExt2);
		}
		else if (e.Item is BlockRecord entry2)
		{
			LeaderArrow = checkRemovedEntry(entry2, LeaderArrow);
			DimArrow1 = checkRemovedEntry(entry2, DimArrow1);
			DimArrow2 = checkRemovedEntry(entry2, DimArrow2);
			ArrowBlock = checkRemovedEntry(entry2, ArrowBlock);
		}
	}

	private T checkRemovedEntry<T>(T entry, T original)
	{
		if (entry.Equals(original))
		{
			return default(T);
		}
		return original;
	}

	private string[] getDimStylePrefixAndSuffix(string text, char start, char end, out string prefix, out string suffix)
	{
		int num = -1;
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == start && i + 1 < text.Length && text[i + 1] == end)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			prefix = string.Empty;
			suffix = text;
		}
		else
		{
			prefix = text.Substring(0, num);
			suffix = text.Substring(num + 2, text.Length - (num + 2));
		}
		return new string[2] { prefix, suffix };
	}
}
