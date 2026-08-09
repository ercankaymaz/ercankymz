using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Header;

public class CadHeader
{
	private static readonly PropertyExpression<CadHeader, CadSystemVariableAttribute> _propertyCache;

	private short _angularUnitPrecision;

	private Layer _currentLayer = Layer.Default;

	private LineType _currentLineType = LineType.ByLayer;

	private MLineStyle _currentMLineStyle = MLineStyle.Default;

	private TextStyle _currentTextStyle = TextStyle.Default;

	private DimensionStyle _dimensionStyleOverrides = new DimensionStyle("override");

	private DimensionStyle _currentDimensionStyle = DimensionStyle.Default;

	private TextStyle _dimensionTextStyle = TextStyle.Default;

	private double _facetResolution = 0.5;

	private short _linearUnitPrecision = 4;

	private double _stepsPerSecond = 2.0;

	private short _surfaceIsolineCount = 4;

	private short _textQuality = 50;

	private ACadVersion _version = ACadVersion.AC1032;

	[CadSystemVariable("$ANGBASE", new int[] { 50 })]
	public double AngleBase { get; set; }

	[CadSystemVariable("$ANGDIR", new int[] { 70 })]
	public AngularDirection AngularDirection { get; set; } = AngularDirection.ClockWise;

	[CadSystemVariable("$AUNITS", new int[] { 70 })]
	public AngularUnitFormat AngularUnit { get; set; }

	[CadSystemVariable("$AUPREC", new int[] { 70 })]
	public short AngularUnitPrecision
	{
		get
		{
			return _angularUnitPrecision;
		}
		set
		{
			ObjectExtensions.InRange(value, 0, 8, "AUPREC valid values are from 0 to 8", inclusive: true, "AngularUnitPrecision");
			_angularUnitPrecision = value;
		}
	}

	[CadSystemVariable("$DIMLDRBLK", new int[] { 1 })]
	public string ArrowBlockName { get; set; } = string.Empty;

	[CadSystemVariable("$DIMASO", new int[] { 70 })]
	public bool AssociatedDimensions { get; set; } = true;

	[CadSystemVariable("$ATTMODE", new int[] { 70 })]
	public AttributeVisibilityMode AttributeVisibility { get; set; } = AttributeVisibilityMode.Normal;

	[CadSystemVariable("$BLIPMODE", new int[] { 70 })]
	public bool BlipMode { get; set; }

	[CadSystemVariable("$CAMERADISPLAY", new int[] { 290 })]
	public bool CameraDisplayObjects { get; set; }

	[CadSystemVariable("$CAMERAHEIGHT", new int[] { 40 })]
	public double CameraHeight { get; set; }

	[CadSystemVariable("$CHAMFERD", new int[] { 40 })]
	public double ChamferAngle { get; set; }

	[CadSystemVariable("$CHAMFERA", new int[] { 40 })]
	public double ChamferDistance1 { get; set; }

	[CadSystemVariable("$CHAMFERB", new int[] { 40 })]
	public double ChamferDistance2 { get; set; }

	[CadSystemVariable("$CHAMFERC", new int[] { 40 })]
	public double ChamferLength { get; set; }

	[CadSystemVariable("$DWGCODEPAGE", new int[] { 3 })]
	public string CodePage { get; set; } = "ANSI_1252";

	[CadSystemVariable("$TDCREATE", new int[] { 40 })]
	public DateTime CreateDateTime { get; set; } = DateTime.Now;

	[CadSystemVariable("$PELLIPSE", new int[] { 70 })]
	public bool CreateEllipseAsPolyline { get; set; }

	[CadSystemVariable("$CECOLOR", new int[] { 62 })]
	public Color CurrentEntityColor { get; set; } = Color.ByLayer;

	[CadSystemVariable("$CELTSCALE", new int[] { 40 })]
	public double CurrentEntityLinetypeScale { get; set; } = 1.0;

	[CadSystemVariable("$CELWEIGHT", new int[] { 370 })]
	public LineWeightType CurrentEntityLineWeight { get; set; } = LineWeightType.ByLayer;

	[CadSystemVariable("$CEPSNTYPE", new int[] { 380 })]
	public EntityPlotStyleType CurrentEntityPlotStyle { get; set; }

	public Layer CurrentLayer
	{
		get
		{
			if (Document == null)
			{
				return _currentLayer;
			}
			return Document.Layers[CurrentLayerName];
		}
		private set
		{
			_currentLayer = value;
		}
	}

	[CadSystemVariable("$CLAYER", true, new int[] { 8 })]
	public string CurrentLayerName
	{
		get
		{
			return _currentLayer.Name;
		}
		set
		{
			if (Document != null)
			{
				_currentLayer = Document.Layers[value];
			}
			else
			{
				_currentLayer = new Layer(value);
			}
		}
	}

	public LineType CurrentLineType
	{
		get
		{
			if (Document == null)
			{
				return _currentLineType;
			}
			return Document.LineTypes[CurrentLineTypeName];
		}
		private set
		{
			_currentLineType = value;
		}
	}

	[CadSystemVariable("$CELTYPE", true, new int[] { 6 })]
	public string CurrentLineTypeName
	{
		get
		{
			return _currentLineType.Name;
		}
		set
		{
			if (Document != null)
			{
				_currentLineType = Document.LineTypes[value];
			}
			else
			{
				_currentLineType = new LineType(value);
			}
		}
	}

	public MLineStyle CurrentMLineStyle
	{
		get
		{
			if (Document == null)
			{
				return _currentMLineStyle;
			}
			return Document.MLineStyles[CurrentMLineStyleName];
		}
		private set
		{
			_currentMLineStyle = value;
		}
	}

	[CadSystemVariable("$CMLJUST", new int[] { 70 })]
	public VerticalAlignmentType CurrentMultiLineJustification { get; set; }

	[CadSystemVariable("$CMLSCALE", new int[] { 40 })]
	public double CurrentMultilineScale { get; set; } = 20.0;

	[CadSystemVariable("$CMLSTYLE", true, new int[] { 2 })]
	public string CurrentMLineStyleName
	{
		get
		{
			return _currentMLineStyle.Name;
		}
		set
		{
			if (Document != null)
			{
				_currentMLineStyle = Document.MLineStyles[value];
			}
			else
			{
				_currentMLineStyle = new MLineStyle(value);
			}
		}
	}

	public TextStyle CurrentTextStyle
	{
		get
		{
			if (Document == null)
			{
				return _currentTextStyle;
			}
			return Document.TextStyles[CurrentTextStyleName];
		}
		private set
		{
			_currentTextStyle = value;
		}
	}

	[CadSystemVariable("$DGNFRAME", new int[] { 280 })]
	public char DgnUnderlayFramesVisibility { get; set; }

	[CadSystemVariable("$DIMAPOST", new int[] { 1 })]
	public string DimensionAlternateDimensioningSuffix
	{
		get
		{
			return _dimensionStyleOverrides.AlternateDimensioningSuffix;
		}
		set
		{
			_dimensionStyleOverrides.AlternateDimensioningSuffix = value;
		}
	}

	[CadSystemVariable("$DIMALTD", new int[] { 70 })]
	public short DimensionAlternateUnitDecimalPlaces
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitDecimalPlaces;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitDecimalPlaces = value;
		}
	}

	[CadSystemVariable("$DIMALT", new int[] { 70 })]
	public bool DimensionAlternateUnitDimensioning
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitDimensioning;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitDimensioning = value;
		}
	}

	[CadSystemVariable("$DIMALTU", new int[] { 70 })]
	public LinearUnitFormat DimensionAlternateUnitFormat
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitFormat;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitFormat = value;
		}
	}

	[CadSystemVariable("$DIMALTRND", new int[] { 40 })]
	public double DimensionAlternateUnitRounding
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitRounding;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitRounding = value;
		}
	}

	[CadSystemVariable("$DIMALTF", new int[] { 40 })]
	public double DimensionAlternateUnitScaleFactor
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitScaleFactor;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitScaleFactor = value;
		}
	}

	[CadSystemVariable("$DIMALTTD", new int[] { 70 })]
	public short DimensionAlternateUnitToleranceDecimalPlaces
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitToleranceDecimalPlaces = value;
		}
	}

	[CadSystemVariable("$DIMALTTZ", new int[] { 70 })]
	public ZeroHandling DimensionAlternateUnitToleranceZeroHandling
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitToleranceZeroHandling;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitToleranceZeroHandling = value;
		}
	}

	[CadSystemVariable("$DIMALTZ", new int[] { 70 })]
	public ZeroHandling DimensionAlternateUnitZeroHandling
	{
		get
		{
			return _dimensionStyleOverrides.AlternateUnitZeroHandling;
		}
		set
		{
			_dimensionStyleOverrides.AlternateUnitZeroHandling = value;
		}
	}

	[CadSystemVariable("$DIMALTMZF", new int[] { 40 })]
	public double DimensionAltMzf
	{
		get
		{
			return _dimensionStyleOverrides.AltMzf;
		}
		set
		{
			_dimensionStyleOverrides.AltMzf = value;
		}
	}

	[CadSystemVariable("$DIMALTMZS", new int[] { 6 })]
	public string DimensionAltMzs
	{
		get
		{
			return _dimensionStyleOverrides.AltMzs;
		}
		set
		{
			_dimensionStyleOverrides.AltMzs = value;
		}
	}

	[CadSystemVariable("$DIMADEC", new int[] { 70 })]
	public short DimensionAngularDimensionDecimalPlaces
	{
		get
		{
			return _dimensionStyleOverrides.AngularDecimalPlaces;
		}
		set
		{
			_dimensionStyleOverrides.AngularDecimalPlaces = value;
		}
	}

	[CadSystemVariable("$DIMAUNIT", new int[] { 70 })]
	public AngularUnitFormat DimensionAngularUnit
	{
		get
		{
			return _dimensionStyleOverrides.AngularUnit;
		}
		set
		{
			_dimensionStyleOverrides.AngularUnit = value;
		}
	}

	[CadSystemVariable("$DIMAZIN", new int[] { 70 })]
	public ZeroHandling DimensionAngularZeroHandling
	{
		get
		{
			return _dimensionStyleOverrides.AngularZeroHandling;
		}
		set
		{
			_dimensionStyleOverrides.AngularZeroHandling = value;
		}
	}

	[CadSystemVariable("$DIMARCSYM", new int[] { 70 })]
	public ArcLengthSymbolPosition DimensionArcLengthSymbolPosition
	{
		get
		{
			return _dimensionStyleOverrides.ArcLengthSymbolPosition;
		}
		set
		{
			_dimensionStyleOverrides.ArcLengthSymbolPosition = value;
		}
	}

	[CadSystemVariable("$DIMASZ", new int[] { 40 })]
	public double DimensionArrowSize
	{
		get
		{
			return _dimensionStyleOverrides.ArrowSize;
		}
		set
		{
			_dimensionStyleOverrides.ArrowSize = value;
		}
	}

	[CadSystemVariable("$DIMASSOC", new int[] { 280 })]
	public DimensionAssociation DimensionAssociativity { get; set; } = DimensionAssociation.CreateAssociativeDimensions;

	[CadSystemVariable("$DIMBLK", new int[] { 1 })]
	public string DimensionBlockName { get; set; } = string.Empty;

	[CadSystemVariable("$DIMBLK1", new int[] { 1 })]
	public string DimensionBlockNameFirst { get; set; }

	[CadSystemVariable("$DIMBLK2", new int[] { 1 })]
	public string DimensionBlockNameSecond { get; set; }

	[CadSystemVariable("$DIMCEN", new int[] { 40 })]
	public double DimensionCenterMarkSize
	{
		get
		{
			return _dimensionStyleOverrides.CenterMarkSize;
		}
		set
		{
			_dimensionStyleOverrides.CenterMarkSize = value;
		}
	}

	[CadSystemVariable("$DIMUPT", new int[] { 70 })]
	public bool DimensionCursorUpdate
	{
		get
		{
			return _dimensionStyleOverrides.CursorUpdate;
		}
		set
		{
			_dimensionStyleOverrides.CursorUpdate = value;
		}
	}

	[CadSystemVariable("$DIMDEC", new int[] { 70 })]
	public short DimensionDecimalPlaces
	{
		get
		{
			return _dimensionStyleOverrides.DecimalPlaces;
		}
		set
		{
			_dimensionStyleOverrides.DecimalPlaces = value;
		}
	}

	[CadSystemVariable("$DIMDSEP", new int[] { 70 })]
	public char DimensionDecimalSeparator
	{
		get
		{
			return _dimensionStyleOverrides.DecimalSeparator;
		}
		set
		{
			_dimensionStyleOverrides.DecimalSeparator = value;
		}
	}

	[CadSystemVariable("$DIMATFIT", new int[] { 70 })]
	public TextArrowFitType DimensionDimensionTextArrowFit
	{
		get
		{
			return _dimensionStyleOverrides.DimensionTextArrowFit;
		}
		set
		{
			_dimensionStyleOverrides.DimensionTextArrowFit = value;
		}
	}

	[CadSystemVariable("$DIMCLRE", new int[] { 70 })]
	public Color DimensionExtensionLineColor
	{
		get
		{
			return _dimensionStyleOverrides.ExtensionLineColor;
		}
		set
		{
			_dimensionStyleOverrides.ExtensionLineColor = value;
		}
	}

	[CadSystemVariable("$DIMEXE", new int[] { 40 })]
	public double DimensionExtensionLineExtension
	{
		get
		{
			return _dimensionStyleOverrides.ExtensionLineExtension;
		}
		set
		{
			_dimensionStyleOverrides.ExtensionLineExtension = value;
		}
	}

	[CadSystemVariable("$DIMEXO", new int[] { 40 })]
	public double DimensionExtensionLineOffset
	{
		get
		{
			return _dimensionStyleOverrides.ExtensionLineOffset;
		}
		set
		{
			_dimensionStyleOverrides.ExtensionLineOffset = value;
		}
	}

	[CadSystemVariable("$DIMFIT", new int[] { 70 })]
	public short DimensionFit
	{
		get
		{
			return _dimensionStyleOverrides.DimensionFit;
		}
		set
		{
			_dimensionStyleOverrides.DimensionFit = value;
		}
	}

	[CadSystemVariable("$DIMFXL", new int[] { 40 })]
	public double DimensionFixedExtensionLineLength
	{
		get
		{
			return _dimensionStyleOverrides.FixedExtensionLineLength;
		}
		set
		{
			_dimensionStyleOverrides.FixedExtensionLineLength = value;
		}
	}

	[CadSystemVariable("$DIMFRAC", new int[] { 70 })]
	public FractionFormat DimensionFractionFormat
	{
		get
		{
			return _dimensionStyleOverrides.FractionFormat;
		}
		set
		{
			_dimensionStyleOverrides.FractionFormat = value;
		}
	}

	[CadSystemVariable("$DIMTOL", new int[] { 70 })]
	public bool DimensionGenerateTolerances
	{
		get
		{
			return _dimensionStyleOverrides.GenerateTolerances;
		}
		set
		{
			_dimensionStyleOverrides.GenerateTolerances = value;
		}
	}

	[CadSystemVariable("$DIMFXLON", new int[] { 70 })]
	public bool DimensionIsExtensionLineLengthFixed
	{
		get
		{
			return _dimensionStyleOverrides.IsExtensionLineLengthFixed;
		}
		set
		{
			_dimensionStyleOverrides.IsExtensionLineLengthFixed = value;
		}
	}

	[CadSystemVariable("$DIMJOGANG", new int[] { 40 })]
	public double DimensionJoggedRadiusDimensionTransverseSegmentAngle
	{
		get
		{
			return _dimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle;
		}
		set
		{
			_dimensionStyleOverrides.JoggedRadiusDimensionTransverseSegmentAngle = value;
		}
	}

	[CadSystemVariable("$DIMLIM", new int[] { 70 })]
	public bool DimensionLimitsGeneration
	{
		get
		{
			return _dimensionStyleOverrides.LimitsGeneration;
		}
		set
		{
			_dimensionStyleOverrides.LimitsGeneration = value;
		}
	}

	[CadSystemVariable("$DIMLFAC", new int[] { 40 })]
	public double DimensionLinearScaleFactor
	{
		get
		{
			return _dimensionStyleOverrides.LinearScaleFactor;
		}
		set
		{
			_dimensionStyleOverrides.LinearScaleFactor = value;
		}
	}

	[CadSystemVariable("$DIMLUNIT", new int[] { 70 })]
	public LinearUnitFormat DimensionLinearUnitFormat
	{
		get
		{
			return _dimensionStyleOverrides.LinearUnitFormat;
		}
		set
		{
			_dimensionStyleOverrides.LinearUnitFormat = value;
		}
	}

	[CadSystemVariable("$DIMCLRD", new int[] { 70 })]
	public Color DimensionLineColor
	{
		get
		{
			return _dimensionStyleOverrides.DimensionLineColor;
		}
		set
		{
			_dimensionStyleOverrides.DimensionLineColor = value;
		}
	}

	[CadSystemVariable("$DIMDLE", new int[] { 40 })]
	public double DimensionLineExtension
	{
		get
		{
			return _dimensionStyleOverrides.DimensionLineExtension;
		}
		set
		{
			_dimensionStyleOverrides.DimensionLineExtension = value;
		}
	}

	[CadSystemVariable("$DIMGAP", new int[] { 40 })]
	public double DimensionLineGap
	{
		get
		{
			return _dimensionStyleOverrides.DimensionLineGap;
		}
		set
		{
			_dimensionStyleOverrides.DimensionLineGap = value;
		}
	}

	[CadSystemVariable("$DIMDLI", new int[] { 40 })]
	public double DimensionLineIncrement
	{
		get
		{
			return _dimensionStyleOverrides.DimensionLineIncrement;
		}
		set
		{
			_dimensionStyleOverrides.DimensionLineIncrement = value;
		}
	}

	[CadSystemVariable("$DIMLTYPE", new int[] { 6 })]
	public string DimensionLineType { get; set; } = "ByBlock";

	[CadSystemVariable("$DIMLWD", new int[] { 70 })]
	public LineWeightType DimensionLineWeight
	{
		get
		{
			return _dimensionStyleOverrides.DimensionLineWeight;
		}
		set
		{
			_dimensionStyleOverrides.DimensionLineWeight = value;
		}
	}

	[CadSystemVariable("$DIMTM", new int[] { 40 })]
	public double DimensionMinusTolerance
	{
		get
		{
			return _dimensionStyleOverrides.MinusTolerance;
		}
		set
		{
			_dimensionStyleOverrides.MinusTolerance = value;
		}
	}

	[CadSystemVariable("$DIMMZF", new int[] { 40 })]
	public double DimensionMzf
	{
		get
		{
			return _dimensionStyleOverrides.Mzf;
		}
		set
		{
			_dimensionStyleOverrides.Mzf = value;
		}
	}

	[CadSystemVariable("$DIMMZS", new int[] { 6 })]
	public string DimensionMzs
	{
		get
		{
			return _dimensionStyleOverrides.Mzs;
		}
		set
		{
			_dimensionStyleOverrides.Mzs = value;
		}
	}

	[CadSystemVariable("$DIMTP", new int[] { 40 })]
	public double DimensionPlusTolerance
	{
		get
		{
			return _dimensionStyleOverrides.PlusTolerance;
		}
		set
		{
			_dimensionStyleOverrides.PlusTolerance = value;
		}
	}

	[CadSystemVariable("$DIMPOST", new int[] { 1 })]
	public string DimensionPostFix
	{
		get
		{
			return _dimensionStyleOverrides.PostFix;
		}
		set
		{
			_dimensionStyleOverrides.PostFix = value;
		}
	}

	[CadSystemVariable("$DIMRND", new int[] { 40 })]
	public double DimensionRounding
	{
		get
		{
			return _dimensionStyleOverrides.Rounding;
		}
		set
		{
			_dimensionStyleOverrides.Rounding = value;
		}
	}

	[CadSystemVariable("$DIMSCALE", new int[] { 40 })]
	public double DimensionScaleFactor
	{
		get
		{
			return _dimensionStyleOverrides.ScaleFactor;
		}
		set
		{
			_dimensionStyleOverrides.ScaleFactor = value;
		}
	}

	[CadSystemVariable("$DIMSAH", new int[] { 70 })]
	public bool DimensionSeparateArrowBlocks
	{
		get
		{
			return _dimensionStyleOverrides.SeparateArrowBlocks;
		}
		set
		{
			_dimensionStyleOverrides.SeparateArrowBlocks = value;
		}
	}

	public DimensionStyle CurrentDimensionStyle
	{
		get
		{
			if (Document == null)
			{
				return _currentDimensionStyle;
			}
			return Document.DimensionStyles[CurrentDimensionStyleName];
		}
		private set
		{
			_currentDimensionStyle = value;
		}
	}

	[CadSystemVariable("$DIMSTYLE", true, new int[] { 2 })]
	public string CurrentDimensionStyleName
	{
		get
		{
			return _currentDimensionStyle.Name;
		}
		set
		{
			if (Document != null)
			{
				_currentDimensionStyle = Document.DimensionStyles[value];
			}
			else
			{
				_currentDimensionStyle = new DimensionStyle(value);
			}
		}
	}

	[CadSystemVariable("$DIMSD1", new int[] { 70 })]
	public bool DimensionSuppressFirstDimensionLine
	{
		get
		{
			return _dimensionStyleOverrides.SuppressFirstDimensionLine;
		}
		set
		{
			_dimensionStyleOverrides.SuppressFirstDimensionLine = value;
		}
	}

	[CadSystemVariable("$DIMSE1", new int[] { 70 })]
	public bool DimensionSuppressFirstExtensionLine
	{
		get
		{
			return _dimensionStyleOverrides.SuppressFirstExtensionLine;
		}
		set
		{
			_dimensionStyleOverrides.SuppressFirstExtensionLine = value;
		}
	}

	[CadSystemVariable("$DIMSOXD", new int[] { 70 })]
	public bool DimensionSuppressOutsideExtensions
	{
		get
		{
			return _dimensionStyleOverrides.SuppressOutsideExtensions;
		}
		set
		{
			_dimensionStyleOverrides.SuppressOutsideExtensions = value;
		}
	}

	[CadSystemVariable("$DIMSD2", new int[] { 70 })]
	public bool DimensionSuppressSecondDimensionLine
	{
		get
		{
			return _dimensionStyleOverrides.SuppressSecondDimensionLine;
		}
		set
		{
			_dimensionStyleOverrides.SuppressSecondDimensionLine = value;
		}
	}

	[CadSystemVariable("$DIMSE2", new int[] { 70 })]
	public bool DimensionSuppressSecondExtensionLine
	{
		get
		{
			return _dimensionStyleOverrides.SuppressSecondExtensionLine;
		}
		set
		{
			_dimensionStyleOverrides.SuppressSecondExtensionLine = value;
		}
	}

	[CadSystemVariable("$DIMLTEX1", new int[] { 6 })]
	public string DimensionTex1 { get; set; } = "ByBlock";

	[CadSystemVariable("$DIMLTEX2", new int[] { 6 })]
	public string DimensionTex2 { get; set; } = "ByBlock";

	[CadSystemVariable(DxfReferenceType.Ignored, "$DIMTFILLCLR", new int[] { 62 })]
	public Color DimensionTextBackgroundColor
	{
		get
		{
			return _dimensionStyleOverrides.TextBackgroundColor;
		}
		set
		{
			_dimensionStyleOverrides.TextBackgroundColor = value;
		}
	}

	[CadSystemVariable("$DIMTFILL", new int[] { 70 })]
	public DimensionTextBackgroundFillMode DimensionTextBackgroundFillMode
	{
		get
		{
			return _dimensionStyleOverrides.TextBackgroundFillMode;
		}
		set
		{
			_dimensionStyleOverrides.TextBackgroundFillMode = value;
		}
	}

	[CadSystemVariable("$DIMCLRT", new int[] { 70 })]
	public Color DimensionTextColor
	{
		get
		{
			return _dimensionStyleOverrides.TextColor;
		}
		set
		{
			_dimensionStyleOverrides.TextColor = value;
		}
	}

	[CadSystemVariable("$DIMTXTDIRECTION", new int[] { 70 })]
	public TextDirection DimensionTextDirection
	{
		get
		{
			return _dimensionStyleOverrides.TextDirection;
		}
		set
		{
			_dimensionStyleOverrides.TextDirection = value;
		}
	}

	[CadSystemVariable("$DIMTXT", new int[] { 40 })]
	public double DimensionTextHeight
	{
		get
		{
			return _dimensionStyleOverrides.TextHeight;
		}
		set
		{
			_dimensionStyleOverrides.TextHeight = value;
		}
	}

	[CadSystemVariable("$DIMJUST", new int[] { 70 })]
	public DimensionTextHorizontalAlignment DimensionTextHorizontalAlignment
	{
		get
		{
			return _dimensionStyleOverrides.TextHorizontalAlignment;
		}
		set
		{
			_dimensionStyleOverrides.TextHorizontalAlignment = value;
		}
	}

	[CadSystemVariable("$DIMTIX", new int[] { 70 })]
	public bool DimensionTextInsideExtensions
	{
		get
		{
			return _dimensionStyleOverrides.TextInsideExtensions;
		}
		set
		{
			_dimensionStyleOverrides.TextInsideExtensions = value;
		}
	}

	[CadSystemVariable("$DIMTIH", new int[] { 70 })]
	public bool DimensionTextInsideHorizontal
	{
		get
		{
			return _dimensionStyleOverrides.TextInsideHorizontal;
		}
		set
		{
			_dimensionStyleOverrides.TextInsideHorizontal = value;
		}
	}

	[CadSystemVariable("$DIMTMOVE", new int[] { 70 })]
	public TextMovement DimensionTextMovement
	{
		get
		{
			return _dimensionStyleOverrides.TextMovement;
		}
		set
		{
			_dimensionStyleOverrides.TextMovement = value;
		}
	}

	[CadSystemVariable("$DIMTOFL", new int[] { 70 })]
	public bool DimensionTextOutsideExtensions
	{
		get
		{
			return _dimensionStyleOverrides.TextOutsideExtensions;
		}
		set
		{
			_dimensionStyleOverrides.TextOutsideExtensions = value;
		}
	}

	[CadSystemVariable("$DIMTOH", new int[] { 70 })]
	public bool DimensionTextOutsideHorizontal
	{
		get
		{
			return _dimensionStyleOverrides.TextOutsideHorizontal;
		}
		set
		{
			_dimensionStyleOverrides.TextOutsideHorizontal = value;
		}
	}

	public TextStyle DimensionTextStyle
	{
		get
		{
			if (Document == null)
			{
				return _dimensionTextStyle;
			}
			return Document.TextStyles[DimensionTextStyleName];
		}
		private set
		{
			_dimensionTextStyle = value;
		}
	}

	[CadSystemVariable("$DIMTXSTY", true, new int[] { 7 })]
	public string DimensionTextStyleName
	{
		get
		{
			return _dimensionTextStyle.Name;
		}
		set
		{
			if (Document != null)
			{
				_dimensionTextStyle = Document.TextStyles[value];
			}
			else
			{
				_dimensionTextStyle = new TextStyle(value);
			}
		}
	}

	[CadSystemVariable("$DIMTAD", new int[] { 70 })]
	public DimensionTextVerticalAlignment DimensionTextVerticalAlignment
	{
		get
		{
			return _dimensionStyleOverrides.TextVerticalAlignment;
		}
		set
		{
			_dimensionStyleOverrides.TextVerticalAlignment = value;
		}
	}

	[CadSystemVariable("$DIMTVP", new int[] { 40 })]
	public double DimensionTextVerticalPosition
	{
		get
		{
			return _dimensionStyleOverrides.TextVerticalPosition;
		}
		set
		{
			_dimensionStyleOverrides.TextVerticalPosition = value;
		}
	}

	[CadSystemVariable("$DIMTSZ", new int[] { 40 })]
	public double DimensionTickSize
	{
		get
		{
			return _dimensionStyleOverrides.TickSize;
		}
		set
		{
			_dimensionStyleOverrides.TickSize = value;
		}
	}

	[CadSystemVariable("$DIMTOLJ", new int[] { 70 })]
	public ToleranceAlignment DimensionToleranceAlignment
	{
		get
		{
			return _dimensionStyleOverrides.ToleranceAlignment;
		}
		set
		{
			_dimensionStyleOverrides.ToleranceAlignment = value;
		}
	}

	[CadSystemVariable("$DIMTDEC", new int[] { 70 })]
	public short DimensionToleranceDecimalPlaces
	{
		get
		{
			return _dimensionStyleOverrides.ToleranceDecimalPlaces;
		}
		set
		{
			_dimensionStyleOverrides.ToleranceDecimalPlaces = value;
		}
	}

	[CadSystemVariable("$DIMTFAC", new int[] { 40 })]
	public double DimensionToleranceScaleFactor
	{
		get
		{
			return _dimensionStyleOverrides.ToleranceScaleFactor;
		}
		set
		{
			_dimensionStyleOverrides.ToleranceScaleFactor = value;
		}
	}

	[CadSystemVariable("$DIMTZIN", new int[] { 70 })]
	public ZeroHandling DimensionToleranceZeroHandling
	{
		get
		{
			return _dimensionStyleOverrides.ToleranceZeroHandling;
		}
		set
		{
			_dimensionStyleOverrides.ToleranceZeroHandling = value;
		}
	}

	[CadSystemVariable("$DIMUNIT", new int[] { 70 })]
	public short DimensionUnit
	{
		get
		{
			return _dimensionStyleOverrides.DimensionUnit;
		}
		set
		{
			_dimensionStyleOverrides.DimensionUnit = value;
		}
	}

	[CadSystemVariable("$DIMZIN", new int[] { 70 })]
	public ZeroHandling DimensionZeroHandling
	{
		get
		{
			return _dimensionStyleOverrides.ZeroHandling;
		}
		set
		{
			_dimensionStyleOverrides.ZeroHandling = value;
		}
	}

	public DimensionStyle DimensionstyleOverrides => _dimensionStyleOverrides;

	[CadSystemVariable("$LIGHTGLYPHDISPLAY", new int[] { 280 })]
	public char DisplayLightGlyphs { get; set; }

	[CadSystemVariable("$LWDISPLAY", new int[] { 290 })]
	public bool DisplayLineWeight { get; set; }

	[CadSystemVariable("$DISPSILH", new int[] { 70 })]
	public bool DisplaySilhouetteCurves { get; set; }

	public CadDocument Document { get; internal set; }

	[CadSystemVariable("$LOFTANG1", new int[] { 40 })]
	public double DraftAngleFirstCrossSection { get; set; }

	[CadSystemVariable("$LOFTANG2", new int[] { 40 })]
	public double DraftAngleSecondCrossSection { get; set; }

	[CadSystemVariable("$LOFTMAG1", new int[] { 40 })]
	public double DraftMagnitudeFirstCrossSection { get; set; }

	[CadSystemVariable("$LOFTMAG2", new int[] { 40 })]
	public double DraftMagnitudeSecondCrossSection { get; set; }

	[CadSystemVariable("$3DDWFPREC", new int[] { 40 })]
	public double Dw3DPrecision { get; set; }

	[CadSystemVariable("$DWFFRAME", new int[] { 280 })]
	public char DwgUnderlayFramesVisibility { get; set; }

	[CadSystemVariable("$ELEVATION", new int[] { 40 })]
	public double Elevation
	{
		get
		{
			return ModelSpaceUcs.Elevation;
		}
		set
		{
			ModelSpaceUcs.Elevation = value;
		}
	}

	[CadSystemVariable("$ENDCAPS", new int[] { 280 })]
	public short EndCaps { get; set; }

	[CadSystemVariable("$SORTENTS", new int[] { 280 })]
	public ObjectSortingFlags EntitySortingFlags { get; set; }

	[CadSystemVariable("$EXTNAMES", new int[] { 290 })]
	public bool ExtendedNames { get; set; } = true;

	[CadSystemVariable("$DIMLWE", new int[] { 70 })]
	public LineWeightType ExtensionLineWeight
	{
		get
		{
			return _dimensionStyleOverrides.ExtensionLineWeight;
		}
		set
		{
			_dimensionStyleOverrides.ExtensionLineWeight = value;
		}
	}

	[CadSystemVariable("$XCLIPFRAME", new int[] { 280 })]
	public XClipFrameType ExternalReferenceClippingBoundaryType { get; set; } = XClipFrameType.DisplayNotPlot;

	[CadSystemVariable("$FACETRES", new int[] { 40 })]
	public double FacetResolution
	{
		get
		{
			return _facetResolution;
		}
		set
		{
			value.InRange(0.01, 10.0, "FACETRES valid values are from 0.01 to 10.0", inclusive: true, "FacetResolution");
			_facetResolution = value;
		}
	}

	[CadSystemVariable("$FILLETRAD", new int[] { 40 })]
	public double FilletRadius { get; set; }

	[CadSystemVariable("$FILLMODE", new int[] { 70 })]
	public bool FillMode { get; set; } = true;

	[CadSystemVariable("$FINGERPRINTGUID", new int[] { 2 })]
	public string FingerPrintGuid { get; internal set; } = Guid.NewGuid().ToString();

	[CadSystemVariable("$HALOGAP", new int[] { 280 })]
	public byte HaloGapPercentage { get; set; }

	[CadSystemVariable("$HANDSEED", new int[] { 5 })]
	public ulong HandleSeed { get; internal set; } = 1uL;

	[CadSystemVariable("$HIDETEXT", new int[] { 280 })]
	public byte HideText { get; set; }

	[CadSystemVariable("$HYPERLINKBASE", new int[] { 1 })]
	public string HyperLinkBase { get; set; }

	[CadSystemVariable("$INDEXCTL", new int[] { 280 })]
	public IndexCreationFlags IndexCreationFlags { get; set; }

	[CadSystemVariable("$INSUNITS", new int[] { 70 })]
	public UnitsType InsUnits { get; set; }

	[CadSystemVariable("$INTERFERECOLOR", new int[] { 62 })]
	public Color InterfereColor { get; set; } = new Color(1);

	public byte IntersectionDisplay { get; set; }

	[CadSystemVariable("$JOINSTYLE", new int[] { 280 })]
	public short JoinStyle { get; set; }

	[CadSystemVariable(DxfReferenceType.Ignored, "$LASTSAVEDBY", new int[] { 3 })]
	public string LastSavedBy { get; set; } = "ACadSharp";

	[CadSystemVariable("$LATITUDE", new int[] { 40 })]
	public double Latitude { get; set; } = 37.795;

	[CadSystemVariable("$LENSLENGTH", new int[] { 40 })]
	public double LensLength { get; set; }

	[CadSystemVariable("$LIMCHECK", new int[] { 70 })]
	public bool LimitCheckingOn { get; set; }

	[CadSystemVariable("$LUNITS", new int[] { 70 })]
	public LinearUnitFormat LinearUnitFormat { get; set; } = LinearUnitFormat.Decimal;

	[CadSystemVariable("$LUPREC", new int[] { 70 })]
	public short LinearUnitPrecision
	{
		get
		{
			return _linearUnitPrecision;
		}
		set
		{
			ObjectExtensions.InRange(value, 0, 8, "LUPREC valid values are from 0 to 8", inclusive: true, "LinearUnitPrecision");
			_linearUnitPrecision = value;
		}
	}

	[CadSystemVariable("$LTSCALE", new int[] { 40 })]
	public double LineTypeScale { get; set; } = 1.0;

	public bool LoadOLEObject { get; set; }

	[CadSystemVariable("$LOFTNORMALS", new int[] { 280 })]
	public char LoftedObjectNormals { get; set; }

	[CadSystemVariable("$LONGITUDE", new int[] { 40 })]
	public double Longitude { get; set; } = -122.394;

	[CadSystemVariable(DxfReferenceType.Ignored, "$ACADMAINTVER", new int[] { 70 })]
	public short MaintenanceVersion { get; internal set; }

	[CadSystemVariable("$MAXACTVP", new int[] { 70 })]
	public short MaxViewportCount { get; set; } = 64;

	[CadSystemVariable("$MEASUREMENT", new int[] { 70 })]
	public MeasurementUnits MeasurementUnits { get; set; } = MeasurementUnits.Metric;

	[CadSystemVariable("$MENU", new int[] { 1 })]
	public string MenuFileName { get; set; } = ".";

	[CadSystemVariable("$MIRRTEXT", new int[] { 70 })]
	public bool MirrorText { get; set; }

	[CadSystemVariable("$EXTMAX", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceExtMax { get; set; }

	[CadSystemVariable("$EXTMIN", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceExtMin { get; set; }

	[CadSystemVariable("$INSBASE", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceInsertionBase { get; set; } = XYZ.Zero;

	[CadSystemVariable("$LIMMAX", new int[] { 10, 20 })]
	public XY ModelSpaceLimitsMax { get; set; }

	[CadSystemVariable("$LIMMIN", new int[] { 10, 20 })]
	public XY ModelSpaceLimitsMin { get; set; }

	[CadSystemVariable("$UCSORG", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrigin
	{
		get
		{
			return ModelSpaceUcs.Origin;
		}
		set
		{
			ModelSpaceUcs.Origin = value;
		}
	}

	[CadSystemVariable("$UCSORGBACK", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicBackDOrigin { get; set; }

	[CadSystemVariable("$UCSORGBOTTOM", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicBottomDOrigin { get; set; }

	[CadSystemVariable("$UCSORGFRONT", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicFrontDOrigin { get; set; }

	[CadSystemVariable("$UCSORGLEFT", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicLeftDOrigin { get; set; }

	[CadSystemVariable("$UCSORGRIGHT", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicRightDOrigin { get; set; }

	[CadSystemVariable("$UCSORGTOP", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceOrthographicTopDOrigin { get; set; }

	public UCS ModelSpaceUcs { get; private set; } = new UCS();

	public UCS ModelSpaceUcsBase { get; private set; } = new UCS();

	[CadSystemVariable("$UCSXDIR", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceXAxis
	{
		get
		{
			return ModelSpaceUcs.XAxis;
		}
		set
		{
			ModelSpaceUcs.XAxis = value;
		}
	}

	[CadSystemVariable("$UCSYDIR", new int[] { 10, 20, 30 })]
	public XYZ ModelSpaceYAxis
	{
		get
		{
			return ModelSpaceUcs.YAxis;
		}
		set
		{
			ModelSpaceUcs.YAxis = value;
		}
	}

	[CadSystemVariable("$NORTHDIRECTION", new int[] { 40 })]
	public double NorthDirection { get; set; }

	[CadSystemVariable("$SPLINESEGS", new int[] { 70 })]
	public short NumberOfSplineSegments { get; set; } = 8;

	[CadSystemVariable("$OSMODE", new int[] { 70 })]
	public ObjectSnapMode ObjectSnapMode { get; set; } = ObjectSnapMode.EndPoint | ObjectSnapMode.Center | ObjectSnapMode.Intersection | ObjectSnapMode.Extension;

	public Color ObscuredColor { get; set; }

	public byte ObscuredType { get; set; }

	[CadSystemVariable("$ORTHOMODE", new int[] { 70 })]
	public bool OrthoMode { get; set; }

	[CadSystemVariable("$PUCSBASE", true, new int[] { 2 })]
	public string PaperSpaceBaseName
	{
		get
		{
			return PaperSpaceUcsBase.Name;
		}
		set
		{
			PaperSpaceUcsBase.Name = value;
		}
	}

	[CadSystemVariable("$PELEVATION", new int[] { 40 })]
	public double PaperSpaceElevation
	{
		get
		{
			return PaperSpaceUcs.Elevation;
		}
		set
		{
			PaperSpaceUcs.Elevation = value;
		}
	}

	[CadSystemVariable("$PEXTMAX", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceExtMax { get; set; } = XYZ.Zero;

	[CadSystemVariable("$PEXTMIN", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceExtMin { get; set; } = XYZ.Zero;

	[CadSystemVariable("$PINSBASE", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceInsertionBase { get; set; } = XYZ.Zero;

	[CadSystemVariable("$PLIMCHECK", new int[] { 70 })]
	public bool PaperSpaceLimitsChecking { get; set; }

	[CadSystemVariable("$PLIMMAX", new int[] { 10, 20 })]
	public XY PaperSpaceLimitsMax { get; set; } = XY.Zero;

	[CadSystemVariable("$PLIMMIN", new int[] { 10, 20 })]
	public XY PaperSpaceLimitsMin { get; set; } = XY.Zero;

	[CadSystemVariable("$PSLTSCALE", new int[] { 70 })]
	public SpaceLineTypeScaling PaperSpaceLineTypeScaling { get; set; } = SpaceLineTypeScaling.Normal;

	[CadSystemVariable("$PUCSNAME", true, new int[] { 2 })]
	public string PaperSpaceName
	{
		get
		{
			return PaperSpaceUcs.Name;
		}
		set
		{
			PaperSpaceUcs.Name = value;
		}
	}

	[CadSystemVariable("$PUCSORGBACK", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicBackDOrigin { get; set; }

	[CadSystemVariable("$PUCSORGBOTTOM", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicBottomDOrigin { get; set; }

	[CadSystemVariable("$PUCSORGFRONT", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicFrontDOrigin { get; set; }

	[CadSystemVariable("$PUCSORGLEFT", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicLeftDOrigin { get; set; }

	[CadSystemVariable("$PUCSORGRIGHT", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicRightDOrigin { get; set; }

	[CadSystemVariable("$PUCSORGTOP", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceOrthographicTopDOrigin { get; set; }

	public UCS PaperSpaceUcs { get; private set; } = new UCS();

	public UCS PaperSpaceUcsBase { get; private set; } = new UCS();

	[CadSystemVariable("$PUCSORG", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceUcsOrigin
	{
		get
		{
			return PaperSpaceUcs.Origin;
		}
		set
		{
			PaperSpaceUcs.Origin = value;
		}
	}

	[CadSystemVariable("$PUCSXDIR", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceUcsXAxis
	{
		get
		{
			return PaperSpaceUcs.XAxis;
		}
		set
		{
			PaperSpaceUcs.XAxis = value;
		}
	}

	[CadSystemVariable("$PUCSYDIR", new int[] { 10, 20, 30 })]
	public XYZ PaperSpaceUcsYAxis
	{
		get
		{
			return PaperSpaceUcs.YAxis;
		}
		set
		{
			PaperSpaceUcs.YAxis = value;
		}
	}

	[CadSystemVariable("$PSTYLEMODE", new int[] { 290 })]
	public short PlotStyleMode { get; set; }

	[CadSystemVariable("$PDMODE", new int[] { 70 })]
	public short PointDisplayMode { get; set; }

	[CadSystemVariable("$PDSIZE", new int[] { 40 })]
	public double PointDisplaySize { get; set; }

	[CadSystemVariable("$PLINEGEN", new int[] { 70 })]
	public bool PolylineLineTypeGeneration { get; set; }

	[CadSystemVariable("$PLINEWID", new int[] { 40 })]
	public double PolylineWidthDefault { get; set; }

	[CadSystemVariable("$PROJECTNAME", new int[] { 1 })]
	public string ProjectName { get; set; }

	[CadSystemVariable("$PROXYGRAPHICS", new int[] { 70 })]
	public bool ProxyGraphics { get; set; } = true;

	[CadSystemVariable("$QTEXTMODE", new int[] { 70 })]
	public bool QuickTextMode { get; set; }

	[CadSystemVariable("$REGENMODE", new int[] { 70 })]
	public bool RegenerationMode { get; set; } = true;

	[CadSystemVariable(DxfReferenceType.Ignored, "$REQUIREDVERSIONS", new int[] { 70 })]
	public long RequiredVersions { get; set; }

	[CadSystemVariable("$VISRETAIN", new int[] { 70 })]
	public bool RetainXRefDependentVisibilitySettings { get; set; } = true;

	[CadSystemVariable("$SHADEDIF", new int[] { 70 })]
	public short ShadeDiffuseToAmbientPercentage { get; set; } = 70;

	[CadSystemVariable("$SHADEDGE", new int[] { 70 })]
	public ShadeEdgeType ShadeEdge { get; set; } = ShadeEdgeType.FacesInEntityColorEdgesInBlack;

	[CadSystemVariable("$CSHADOW", new int[] { 280 })]
	public ShadowMode ShadowMode { get; set; }

	[CadSystemVariable("$SHADOWPLANELOCATION", new int[] { 40 })]
	public double ShadowPlaneLocation { get; set; }

	[CadSystemVariable("$TILEMODE", new int[] { 70 })]
	public bool ShowModelSpace { get; set; } = true;

	[CadSystemVariable("$SHOWHIST", new int[] { 280 })]
	public char ShowSolidsHistory { get; set; }

	[CadSystemVariable("$SPLFRAME", new int[] { 70 })]
	public bool ShowSplineControlPoints { get; set; }

	[CadSystemVariable("$SKETCHINC", new int[] { 40 })]
	public double SketchIncrement { get; set; } = 1.0;

	[CadSystemVariable("$SKPOLY", new int[] { 70 })]
	public bool SketchPolylines { get; set; }

	[CadSystemVariable("$LOFTPARAM", new int[] { 70 })]
	public short SolidLoftedShape { get; set; }

	[CadSystemVariable("$SOLIDHIST", new int[] { 280 })]
	public char SolidsRetainHistory { get; set; }

	[CadSystemVariable("$TREEDEPTH", new int[] { 70 })]
	public short SpatialIndexMaxTreeDepth { get; set; } = 3020;

	[CadSystemVariable("$SPLINETYPE", new int[] { 70 })]
	public SplineType SplineType { get; set; } = SplineType.CubicBSpline;

	public short StackedTextAlignment { get; internal set; } = 1;

	public short StackedTextSizePercentage { get; internal set; } = 70;

	[CadSystemVariable("$STEPSIZE", new int[] { 40 })]
	public double StepSize { get; set; } = 6.0;

	[CadSystemVariable("$STEPSPERSEC", new int[] { 40 })]
	public double StepsPerSecond
	{
		get
		{
			return _stepsPerSecond;
		}
		set
		{
			value.InRange(1.0, 30.0, "STEPSPERSEC valid values are from 1 to 30", inclusive: true, "StepsPerSecond");
			_stepsPerSecond = value;
		}
	}

	[CadSystemVariable("$STYLESHEET", new int[] { 1 })]
	public string StyleSheetName { get; set; }

	[CadSystemVariable("$SURFU", new int[] { 70 })]
	public short SurfaceDensityU { get; set; } = 6;

	[CadSystemVariable("$SURFV", new int[] { 70 })]
	public short SurfaceDensityV { get; set; } = 6;

	public short SurfaceIsolineCount
	{
		get
		{
			return _surfaceIsolineCount;
		}
		set
		{
			ObjectExtensions.InRange(value, 0, 2047, "ISOLINES valid values are from 0 to 2047", inclusive: true, "SurfaceIsolineCount");
			_surfaceIsolineCount = value;
		}
	}

	[CadSystemVariable("$SURFTAB1", new int[] { 70 })]
	public short SurfaceMeshTabulationCount1 { get; set; } = 6;

	[CadSystemVariable("$SURFTAB2", new int[] { 70 })]
	public short SurfaceMeshTabulationCount2 { get; set; } = 6;

	[CadSystemVariable("$SURFTYPE", new int[] { 70 })]
	public short SurfaceType { get; set; } = 6;

	[CadSystemVariable("$PSOLHEIGHT", new int[] { 40 })]
	public double SweptSolidHeight { get; set; }

	[CadSystemVariable("$PSOLWIDTH", new int[] { 40 })]
	public double SweptSolidWidth { get; set; }

	[CadSystemVariable("$TEXTSIZE", new int[] { 40 })]
	public double TextHeightDefault { get; set; } = 2.5;

	public short TextQuality
	{
		get
		{
			return _textQuality;
		}
		set
		{
			ObjectExtensions.InRange(value, 0, 100, "TEXTQLTY valid values are from 0 to 100", inclusive: true, "TextQuality");
			_textQuality = value;
		}
	}

	[CadSystemVariable("$TEXTSTYLE", true, new int[] { 7 })]
	public string CurrentTextStyleName
	{
		get
		{
			return _currentTextStyle.Name;
		}
		set
		{
			if (Document != null)
			{
				_currentTextStyle = Document.TextStyles[value];
			}
			else
			{
				_currentTextStyle = new TextStyle(value);
			}
		}
	}

	[CadSystemVariable("$THICKNESS", new int[] { 40 })]
	public double ThicknessDefault { get; set; }

	[CadSystemVariable("$TIMEZONE", new int[] { 70 })]
	public int TimeZone { get; set; }

	[CadSystemVariable("$TDINDWG", new int[] { 40 })]
	public TimeSpan TotalEditingTime { get; set; }

	[CadSystemVariable("$TRACEWID", new int[] { 40 })]
	public double TraceWidthDefault { get; set; }

	[CadSystemVariable("$UCSBASE", true, new int[] { 2 })]
	public string UcsBaseName
	{
		get
		{
			return ModelSpaceUcsBase.Name;
		}
		set
		{
			ModelSpaceUcsBase.Name = value;
		}
	}

	[CadSystemVariable("$UCSNAME", true, new int[] { 2 })]
	public string UcsName
	{
		get
		{
			return ModelSpaceUcs.Name;
		}
		set
		{
			ModelSpaceUcs.Name = value;
		}
	}

	[CadSystemVariable("$UNITMODE", new int[] { 70 })]
	public short UnitMode { get; set; }

	[CadSystemVariable("$TDUCREATE", new int[] { 40 })]
	public DateTime UniversalCreateDateTime { get; set; } = DateTime.UtcNow;

	[CadSystemVariable("$TDUUPDATE", new int[] { 40 })]
	public DateTime UniversalUpdateDateTime { get; set; } = DateTime.UtcNow;

	[CadSystemVariable("$TDUPDATE", new int[] { 40 })]
	public DateTime UpdateDateTime { get; set; } = DateTime.Now;

	[CadSystemVariable("$DIMSHO", new int[] { 70 })]
	public bool UpdateDimensionsWhileDragging { get; set; } = true;

	[CadSystemVariable("$USERR1", new int[] { 40 })]
	public double UserDouble1 { get; set; }

	[CadSystemVariable("$USERR2", new int[] { 40 })]
	public double UserDouble2 { get; set; }

	[CadSystemVariable("$USERR3", new int[] { 40 })]
	public double UserDouble3 { get; set; }

	[CadSystemVariable("$USERR4", new int[] { 40 })]
	public double UserDouble4 { get; set; }

	[CadSystemVariable("$USERR5", new int[] { 40 })]
	public double UserDouble5 { get; set; }

	[CadSystemVariable("$TDUSRTIMER", new int[] { 40 })]
	public TimeSpan UserElapsedTimeSpan { get; set; }

	[CadSystemVariable("$USERI1", new int[] { 70 })]
	public short UserShort1 { get; set; }

	[CadSystemVariable("$USERI2", new int[] { 70 })]
	public short UserShort2 { get; set; }

	[CadSystemVariable("$USERI3", new int[] { 70 })]
	public short UserShort3 { get; set; }

	[CadSystemVariable("$USERI4", new int[] { 70 })]
	public short UserShort4 { get; set; }

	[CadSystemVariable("$USERI5", new int[] { 70 })]
	public short UserShort5 { get; set; }

	[CadSystemVariable("$USRTIMER", new int[] { 70 })]
	public bool UserTimer { get; set; }

	public ACadVersion Version
	{
		get
		{
			return _version;
		}
		set
		{
			_version = value;
			switch (value)
			{
			case ACadVersion.AC1015:
				MaintenanceVersion = 20;
				break;
			case ACadVersion.AC1018:
				MaintenanceVersion = 104;
				break;
			case ACadVersion.AC1021:
				MaintenanceVersion = 50;
				break;
			case ACadVersion.AC1024:
				MaintenanceVersion = 226;
				break;
			case ACadVersion.AC1027:
				MaintenanceVersion = 125;
				break;
			case ACadVersion.AC1032:
				MaintenanceVersion = 228;
				break;
			default:
				MaintenanceVersion = 0;
				break;
			}
		}
	}

	[CadSystemVariable("$VERSIONGUID", new int[] { 2 })]
	public string VersionGuid { get; internal set; } = Guid.NewGuid().ToString();

	[CadSystemVariable("$ACADVER", new DxfCode[] { DxfCode.Text })]
	public string VersionString
	{
		get
		{
			return Version.ToString();
		}
		set
		{
			Version = CadUtils.GetVersionFromName(value);
		}
	}

	[CadSystemVariable("$PSVPSCALE", new int[] { 40 })]
	public double ViewportDefaultViewScaleFactor { get; set; }

	[CadSystemVariable("$WORLDVIEW", new int[] { 70 })]
	public bool WorldView { get; set; } = true;

	[CadSystemVariable("$XEDIT", new int[] { 290 })]
	public bool XEdit { get; set; }

	internal bool DIMSAV { get; set; }

	static CadHeader()
	{
		_propertyCache = new PropertyExpression<CadHeader, CadSystemVariableAttribute>((PropertyInfo info, CadSystemVariableAttribute attribute) => attribute.Name);
	}

	public CadHeader()
		: this(ACadVersion.AC1032)
	{
	}

	public CadHeader(CadDocument document)
		: this(ACadVersion.AC1032)
	{
		Document = document;
	}

	public CadHeader(ACadVersion version)
	{
		Version = version;
	}

	public static Dictionary<string, CadSystemVariable> GetHeaderMap()
	{
		Dictionary<string, CadSystemVariable> dictionary = new Dictionary<string, CadSystemVariable>();
		PropertyInfo[] properties = typeof(CadHeader).GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			CadSystemVariableAttribute customAttribute = propertyInfo.GetCustomAttribute<CadSystemVariableAttribute>();
			if (customAttribute != null)
			{
				dictionary.Add(customAttribute.Name, new CadSystemVariable(propertyInfo));
			}
		}
		return dictionary;
	}

	public object GetValue(string systemvar)
	{
		return _propertyCache.GetProperty(systemvar).Getter(this);
	}

	public Dictionary<DxfCode, object> GetValues(string systemvar)
	{
		Dictionary<DxfCode, object> dictionary = null;
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			CadSystemVariableAttribute customAttribute = propertyInfo.GetCustomAttribute<CadSystemVariableAttribute>();
			if (customAttribute == null || !(customAttribute.Name == systemvar))
			{
				continue;
			}
			dictionary = new Dictionary<DxfCode, object>();
			if (customAttribute.ValueCodes.Length == 1)
			{
				dictionary.Add(customAttribute.ValueCodes[0], propertyInfo.GetValue(this));
				break;
			}
			IVector vector = (IVector)propertyInfo.GetValue(this);
			for (int j = 0; j < vector.Dimension; j++)
			{
				dictionary.Add(customAttribute.ValueCodes[j], vector[j]);
			}
			break;
		}
		return dictionary;
	}

	public void SetValue(string systemvar, params object[] values)
	{
		PropertyExpression<CadHeader, CadSystemVariableAttribute>.Prop property = _propertyCache.GetProperty(systemvar);
		ConstructorInfo constructor = property.Property.PropertyType.GetConstructor(values.Select((object o) => o.GetType()).ToArray());
		if (property.Property.PropertyType.IsEnum)
		{
			int value = Convert.ToInt32(values.First());
			property.Setter(this, Enum.ToObject(property.Property.PropertyType, value));
		}
		else if (property.Property.PropertyType.IsEquivalentTo(typeof(DateTime)))
		{
			_ = (double)values.First();
			property.Setter(this, CadUtils.FromJulianCalendar((double)values.First()));
		}
		else if (property.Property.PropertyType.IsEquivalentTo(typeof(TimeSpan)))
		{
			_ = (double)values.First();
			property.Setter(this, CadUtils.EditingTime((double)values.First()));
		}
		else if (constructor == null)
		{
			if (property.Attribute.IsName && values.First() is string str)
			{
				if (!str.IsNullOrEmpty())
				{
					property.Setter(this, Convert.ChangeType(values.First(), property.Property.PropertyType));
				}
			}
			else
			{
				property.Setter(this, Convert.ChangeType(values.First(), property.Property.PropertyType));
			}
		}
		else
		{
			property.Setter(this, Activator.CreateInstance(property.Property.PropertyType, values));
		}
	}

	public override string ToString()
	{
		return $"{Version}";
	}
}
