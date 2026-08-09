using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public abstract class Dimension : Text
{
	public enum horizontalAlignmentType : byte
	{
		Centered,
		FirstExtensionLine,
		SecondExtensionLine
	}

	public enum verticalAlignmentType : byte
	{
		Centered,
		Above,
		Below
	}

	private Point3D _dimLinePos;

	private string _textPrefix;

	private string _textOverride;

	private string _textSuffix;

	protected string _formatString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965335);

	private double _linearScale = 1.0;

	private string _dimStyle;

	private toleranceType _toleranceMode;

	private double _upperValue;

	private double _lowerValue;

	private double _scalingForHeight = 1.0;

	private bool _toleranceSuppressLeadingZeros;

	private bool _toleranceSuppressTrailingZeros = true;

	private int _tolerancePrecision = 3;

	private double _prevHeight;

	protected double prevExt;

	protected double prevOffset;

	protected double prevTextGap;

	protected double prevArrowedSize;

	private double _scaleOverall = 1.0;

	internal string textUpperValue;

	internal string textLowerValue;

	internal string textPrefixFormatted = string.Empty;

	internal string textSuffixFormatted = string.Empty;

	private string[] _textUpperValueTokens;

	private string[] _textLowerValueTokens;

	private string[] _textPrefixTokens;

	private string[] _textSuffixTokens;

	internal double prefixWidth;

	internal double textWidth;

	internal double toleranceMaxWidth;

	internal double toleranceUpWidth;

	internal double toleranceLowWidth;

	internal double suffixWidth;

	internal double exactTextHeight;

	internal double dimLineY;

	internal List<string> textLines;

	private bool _overrideAllText;

	private elementPositionType _textLocation;

	private elementPositionType _arrowsLocation;

	private horizontalAlignmentType _textHorizontalPosition;

	private verticalAlignmentType _textVerticalPosition = verticalAlignmentType.Above;

	private bool _useDefaultTextPosition;

	private protected bool _textIsInside;

	private protected bool _arrowsIsInside;

	private protected Point2D _textBottomLeft2D;

	private linearDimensionUnitsType _linearDimensionUnits = linearDimensionUnitsType.Decimal;

	private int _precision = 3;

	private bool _suppressLeadingZeros;

	private bool _suppressTrailingZeros = true;

	private double _textGap;

	private double _arrowheadSize;

	internal bool textFlipped;

	internal int firstVertexIndexForTexts;

	private protected Point3D[] _dimLineInterruptionPoints;

	private protected Point3D[] _basicToleranceBoxVertices;

	public Color TextColor { get; set; }

	public colorMethodType TextColorMethod { get; set; } = colorMethodType.byParent;

	public string DimStyle
	{
		get
		{
			return _dimStyle;
		}
		set
		{
			_dimStyle = value;
		}
	}

	public double TextGap
	{
		get
		{
			return _textGap;
		}
		set
		{
			_textGap = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ArrowheadSize
	{
		get
		{
			return _arrowheadSize;
		}
		set
		{
			_arrowheadSize = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double LinearScale
	{
		get
		{
			return _linearScale;
		}
		set
		{
			_linearScale = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public toleranceType ToleranceMode
	{
		get
		{
			return _toleranceMode;
		}
		set
		{
			_toleranceMode = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double UpperValue
	{
		get
		{
			return _upperValue;
		}
		set
		{
			_upperValue = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double LowerValue
	{
		get
		{
			return _lowerValue;
		}
		set
		{
			_lowerValue = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double ScalingForHeight
	{
		get
		{
			return _scalingForHeight;
		}
		set
		{
			_scalingForHeight = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool ToleranceSuppressLeadingZeros
	{
		get
		{
			return _toleranceSuppressLeadingZeros;
		}
		set
		{
			_toleranceSuppressLeadingZeros = value;
			DimSetup();
		}
	}

	public bool ToleranceSuppressTralingZeros
	{
		get
		{
			return _toleranceSuppressTrailingZeros;
		}
		set
		{
			_toleranceSuppressTrailingZeros = value;
			DimSetup();
		}
	}

	public int TolerancePrecision
	{
		get
		{
			return _tolerancePrecision;
		}
		set
		{
			_tolerancePrecision = value;
			DimSetup();
		}
	}

	public virtual double ScaleOverall
	{
		get
		{
			return _scaleOverall;
		}
		set
		{
			_scaleOverall = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public override bool Backward
	{
		get
		{
			return false;
		}
		set
		{
			base.Backward = value;
		}
	}

	public override bool UpsideDown
	{
		get
		{
			return false;
		}
		set
		{
			base.UpsideDown = value;
		}
	}

	public elementPositionType ArrowsLocation
	{
		get
		{
			return _arrowsLocation;
		}
		set
		{
			_arrowsLocation = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public elementPositionType TextLocation
	{
		get
		{
			return _textLocation;
		}
		set
		{
			_textLocation = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public horizontalAlignmentType TextHorizontalPosition
	{
		get
		{
			return _textHorizontalPosition;
		}
		set
		{
			_textHorizontalPosition = value;
			DimSetup();
		}
	}

	public verticalAlignmentType TextVerticalPosition
	{
		get
		{
			return _textVerticalPosition;
		}
		set
		{
			_textVerticalPosition = value;
			DimSetup();
		}
	}

	public bool UseDefaultTextPosition
	{
		get
		{
			return _useDefaultTextPosition;
		}
		set
		{
			_useDefaultTextPosition = value;
			DimSetup();
		}
	}

	public Point3D DimLinePosition
	{
		get
		{
			return _dimLinePos;
		}
		set
		{
			_dimLinePos = value;
			DimSetup();
		}
	}

	public double Distance { get; protected internal set; }

	[Browsable(false)]
	public new Point3D InsertionPoint => base.Plane.Origin;

	public string TextPrefix
	{
		get
		{
			return _textPrefix;
		}
		set
		{
			_textPrefix = value;
			DimSetup();
		}
	}

	public override string TextString
	{
		get
		{
			return base.TextString;
		}
		set
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966012));
		}
	}

	public string TextOverride
	{
		get
		{
			return _textOverride;
		}
		set
		{
			_textOverride = value;
			DimSetup();
		}
	}

	public string TextSuffix
	{
		get
		{
			return _textSuffix;
		}
		set
		{
			_textSuffix = value;
			DimSetup();
		}
	}

	public linearDimensionUnitsType LinearDimensionUnits
	{
		get
		{
			return _linearDimensionUnits;
		}
		set
		{
			_linearDimensionUnits = value;
			DimSetup();
		}
	}

	public int Precision
	{
		get
		{
			return _precision;
		}
		set
		{
			_precision = value;
			DimSetup();
		}
	}

	public bool SuppressLeadingZeros
	{
		get
		{
			return _suppressLeadingZeros;
		}
		set
		{
			_suppressLeadingZeros = value;
			DimSetup();
		}
	}

	public bool SuppressTrailingZeros
	{
		get
		{
			return _suppressTrailingZeros;
		}
		set
		{
			_suppressTrailingZeros = value;
			DimSetup();
		}
	}

	public bool ToleranceAlignment { get; set; }

	protected Dimension(Plane dimPlane, Point3D insPoint, double textHeight)
		: base(dimPlane, insPoint, textHeight, alignmentType.BaselineCenter)
	{
		_0023_003DztGdcVOA_003D(textHeight);
	}

	protected Dimension(Dimension another)
		: base(another)
	{
		ArrowheadSize = another.ArrowheadSize;
		ArrowsLocation = another._arrowsLocation;
		_dimLinePos = (Point3D)another._dimLinePos.Clone();
		_precision = another.Precision;
		_suppressLeadingZeros = another.SuppressLeadingZeros;
		_suppressTrailingZeros = another.SuppressTrailingZeros;
		TextGap = another.TextGap;
		TextLocation = another._textLocation;
		_textOverride = another._textOverride;
		_textPrefix = another._textPrefix;
		_textSuffix = another._textSuffix;
		_linearScale = another._linearScale;
		_scaleOverall = another._scaleOverall;
		_formatString = another._formatString;
		_linearDimensionUnits = another._linearDimensionUnits;
		_toleranceMode = another._toleranceMode;
		_upperValue = another._upperValue;
		_lowerValue = another._lowerValue;
		_scalingForHeight = another._scalingForHeight;
		_toleranceSuppressLeadingZeros = another._toleranceSuppressLeadingZeros;
		_toleranceSuppressTrailingZeros = another._toleranceSuppressTrailingZeros;
		_tolerancePrecision = another._tolerancePrecision;
		ToleranceAlignment = another.ToleranceAlignment;
		TextColorMethod = another.TextColorMethod;
		TextColor = another.TextColor;
		_textHorizontalPosition = another.TextHorizontalPosition;
		_textVerticalPosition = another.TextVerticalPosition;
		_useDefaultTextPosition = another.UseDefaultTextPosition;
	}

	protected Dimension(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_dimLinePos = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965319), typeof(Point3D));
		_textPrefix = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965285));
		_textOverride = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965271));
		_textSuffix = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965259));
		_textGap = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965501));
		_textLocation = (elementPositionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965486), typeof(elementPositionType));
		_arrowheadSize = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360));
		_precision = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912396));
		_suppressLeadingZeros = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965471));
		_suppressTrailingZeros = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965438));
		_linearScale = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965404));
		_scaleOverall = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965389));
		_linearDimensionUnits = (linearDimensionUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966113), typeof(linearDimensionUnitsType));
		_toleranceMode = (toleranceType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966112), typeof(toleranceType));
		_upperValue = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966067));
		_lowerValue = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966053));
		_scalingForHeight = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966039));
		_toleranceSuppressLeadingZeros = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966258));
		_toleranceSuppressTrailingZeros = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966231));
		_tolerancePrecision = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966207));
		ToleranceAlignment = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966169));
		TextColorMethod = (colorMethodType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965875), typeof(colorMethodType));
		TextColor = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965867), typeof(Color));
		_textHorizontalPosition = (horizontalAlignmentType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965854), typeof(horizontalAlignmentType));
		_textVerticalPosition = (verticalAlignmentType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965817), typeof(verticalAlignmentType));
		_useDefaultTextPosition = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965782));
	}

	internal double _0023_003DzkoDk7tMbLySb()
	{
		return height * 0.25;
	}

	internal double _0023_003DzljmTG744AIjo()
	{
		return TextGap * ScaleOverall;
	}

	private double _0023_003DzBS03wHrqjNoA()
	{
		return _0023_003DzkoDk7tMbLySb() * ScaleOverall;
	}

	private double _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D()
	{
		return ArrowheadSize * ScaleOverall;
	}

	private protected double _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(arrowheadType _0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D)
	{
		if (_0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D != arrowheadType.Arrow)
		{
			return _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D() / 2.0;
		}
		return _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D();
	}

	private protected double _0023_003Dzj7tHTdhKrBCooLH_X2X9_bA_003D(arrowheadType _0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D)
	{
		return _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(_0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D) * 1.2;
	}

	private protected double _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(arrowheadType _0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D)
	{
		double num = ((_arrowsIsInside || _0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D != arrowheadType.Arrow) ? 1.2 : 0.2);
		return _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(_0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D) * num;
	}

	private protected double _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(arrowheadType _0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D)
	{
		return _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(_0023_003Dzz2WVRwOZ6STxgPhgxw_003D_003D) * (_arrowsIsInside ? 0.2 : 1.2);
	}

	private double _0023_003Dz0qtbSfrFDXVBk7tnxfkcmtc_003D(double _0023_003DzdPdtTCPv8PA_0024, double _0023_003DzL62rfYNGWQ4bPWKZyw_003D_003D, bool _0023_003DzeMBeuAQ_003D)
	{
		if (TextVerticalPosition == verticalAlignmentType.Centered)
		{
			if (!_0023_003DzeMBeuAQ_003D)
			{
				return _0023_003DzdPdtTCPv8PA_0024 - _0023_003DzL62rfYNGWQ4bPWKZyw_003D_003D;
			}
			return _0023_003DzdPdtTCPv8PA_0024 + _0023_003DzL62rfYNGWQ4bPWKZyw_003D_003D;
		}
		if (!_0023_003DzeMBeuAQ_003D)
		{
			return _0023_003DzdPdtTCPv8PA_0024 + _0023_003DzL62rfYNGWQ4bPWKZyw_003D_003D;
		}
		return _0023_003DzdPdtTCPv8PA_0024 - _0023_003DzL62rfYNGWQ4bPWKZyw_003D_003D;
	}

	internal override double _0023_003DzcAXPBc8_003D()
	{
		return height * _scaleOverall;
	}

	protected internal override void PrepareText(RegenParams data, ref double widthFactor, out double width, out double descend, out Point3D boxMin, out Point3D boxMax)
	{
		_overrideAllText = !string.IsNullOrEmpty(_textOverride) && !_textOverride.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001));
		myWidthFactor = WidthFactor;
		FormatText();
		_0023_003DzhnnXav8_003D(_overrideAllText ? string.Empty : textPrefixFormatted, data, ref widthFactor, out prefixWidth, out descend, out boxMin, out boxMax, out _textPrefixTokens);
		if (ToleranceMode != toleranceType.Limits || _overrideAllText)
		{
			_0023_003DzhnnXav8_003D(text, data, ref widthFactor, out textWidth, out descend, out boxMin, out boxMax, out _textTokens);
		}
		_0023_003DzhnnXav8_003D(_overrideAllText ? string.Empty : textSuffixFormatted, data, ref widthFactor, out suffixWidth, out descend, out boxMin, out boxMax, out _textSuffixTokens);
		toleranceMaxWidth = 0.0;
		toleranceLowWidth = 0.0;
		toleranceUpWidth = 0.0;
		if (ToleranceMode != toleranceType.None && ToleranceMode != toleranceType.Basic && !_overrideAllText)
		{
			Point3D _0023_003DzDPcjoBJLcqli = null;
			Point3D _0023_003Dz_0024N_0024yKptW9BoC = null;
			_0023_003DzhnnXav8_003D(_overrideAllText ? string.Empty : textUpperValue, data, ref widthFactor, out toleranceUpWidth, out var _0023_003DzzZ7ER_0024M_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, out _textUpperValueTokens);
			_0023_003DzhnnXav8_003D(_overrideAllText ? string.Empty : textLowerValue, data, ref widthFactor, out toleranceLowWidth, out _0023_003DzzZ7ER_0024M_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, out _textLowerValueTokens);
			toleranceUpWidth *= ScalingForHeight;
			toleranceLowWidth *= ScalingForHeight;
			toleranceMaxWidth = Math.Max(toleranceUpWidth, toleranceLowWidth);
		}
		if (ToleranceMode == toleranceType.Limits)
		{
			width = prefixWidth + Math.Max(textWidth, toleranceMaxWidth) + suffixWidth;
		}
		else
		{
			width = prefixWidth + textWidth + toleranceMaxWidth + suffixWidth;
		}
		exactTextHeight = _0023_003DzcAXPBc8_003D();
		if (ToleranceMode != toleranceType.None && ToleranceMode != toleranceType.Basic && !_overrideAllText)
		{
			double num = _0023_003DzcAXPBc8_003D() * ScalingForHeight;
			if (ToleranceMode != toleranceType.Symmetrical)
			{
				num += (_0023_003DzcAXPBc8_003D() + _0023_003DzBS03wHrqjNoA()) * ScalingForHeight;
			}
			if (num > exactTextHeight)
			{
				exactTextHeight = num;
			}
		}
	}

	private protected virtual double _0023_003DzJ7p5EJnvP7td()
	{
		double num = exactWidth;
		if (ToleranceMode == toleranceType.Basic || TextVerticalPosition == verticalAlignmentType.Centered)
		{
			num += _0023_003DzljmTG744AIjo() * 2.0;
		}
		return num;
	}

	internal virtual void _0023_003DzbC_0024QQAMwgTKD(DrawParams _0023_003DzELu0Pss_003D)
	{
		_prevHeight = height;
		prevArrowedSize = _arrowheadSize;
		height = (double)_0023_003DzELu0Pss_003D.ScreenToWorld * _0023_003DzELu0Pss_003D._0023_003DzSabNiMHUjaJJ;
		prevTextGap = TextGap;
		prevArrowedSize = ArrowheadSize;
		_textGap = height * 0.25;
		_arrowheadSize = height * 1.2;
	}

	internal virtual void _0023_003DzWFT5K6qE53AJ()
	{
		height = _prevHeight;
		_arrowheadSize = prevArrowedSize;
		_arrowheadSize = prevTextGap;
	}

	internal void _0023_003Dz5ewp99yrAV_P(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003DzDe1zwkzs_Ob1)
	{
		_0023_003DzbC_0024QQAMwgTKD(_0023_003DzELu0Pss_003D);
		RegenParams visualRefinement = _0023_003DzELu0Pss_003D.viewportInternal.parent.Document.GetVisualRefinement();
		Regen(new RegenParams(visualRefinement.Deviation, visualRefinement.Angle, _0023_003DzELu0Pss_003D.viewportInternal.parent.Document));
		regenMode = regenType.NotNeeded;
		DrawDimension(_0023_003DzELu0Pss_003D, _0023_003DzDe1zwkzs_Ob1, invariant: true);
		_0023_003DzWFT5K6qE53AJ();
	}

	protected Point3D[] InitVerticesOnPlane(ref int verticesLength)
	{
		if (!_overrideAllText)
		{
			if (!string.IsNullOrEmpty(textPrefixFormatted))
			{
				verticesLength += 4;
			}
			if (!string.IsNullOrEmpty(textUpperValue))
			{
				verticesLength += 4;
			}
			if (!string.IsNullOrEmpty(textSuffixFormatted))
			{
				verticesLength += 4;
			}
			if (ToleranceMode == toleranceType.Deviation)
			{
				verticesLength += 4;
			}
		}
		return new Point3D[verticesLength];
	}

	private protected void _0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzSZwFxLJvX2_ZPNJXqg_003D_003D)
	{
		Transformation transformation = Transformation.CreateAlignment(base.Plane, Plane.XY);
		for (int i = 0; i < _0023_003DzSZwFxLJvX2_ZPNJXqg_003D_003D; i++)
		{
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] != null)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			}
		}
	}

	private protected void _0023_003Dz0nJAUFysbna4boWQhQ_003D_003D(Point3D[] _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D)
	{
		Transformation transformation = Transformation.CreateAlignment(Plane.XY, base.Plane);
		_vertices = new Point3D[_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = transformation * _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[i];
		}
		for (int j = 0; j < _basicToleranceBoxVertices.Length; j++)
		{
			_basicToleranceBoxVertices[j] = transformation * _basicToleranceBoxVertices[j];
		}
		if (_dimLineInterruptionPoints != null)
		{
			for (int k = 0; k < _dimLineInterruptionPoints.Length; k++)
			{
				_dimLineInterruptionPoints[k] = transformation * _dimLineInterruptionPoints[k];
			}
		}
	}

	private void _0023_003DztGdcVOA_003D(double _0023_003Dzx0bH0r8MZhkE)
	{
		TextGap = _0023_003Dzx0bH0r8MZhkE * 0.25;
		ArrowheadSize = _0023_003Dzx0bH0r8MZhkE * 1.2;
	}

	protected void DimSetup()
	{
		UpdateDistance();
		RegenMode = regenType.RegenAndCompile;
	}

	private int _0023_003DzfxFaUJOgD8OA8QtBGCqq5gk_003D()
	{
		return Convert.ToInt32(Math.Pow(2.0, Precision));
	}

	protected virtual void UpdateDistance()
	{
		Distance = 0.0;
	}

	private string _0023_003Dz_0024zUHEPKywYuH(string _0023_003Dz0EsKsC8_003D, string _0023_003DzAqOpw0w_003D, string _0023_003Dzk64JNOo_003D, string _0023_003Dz2hWShFc_003D)
	{
		string text = _0023_003Dz0EsKsC8_003D;
		foreach (string item in Utility._0023_003DzZPEv7WT7EohsW_mPuw_003D_003D(text, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, RegexOptions.None))
		{
			text = text.Replace(_0023_003DzAqOpw0w_003D + item + _0023_003Dzk64JNOo_003D, _0023_003Dz2hWShFc_003D);
		}
		return text;
	}

	private string _0023_003Dz_0024zUHEPKywYuH(string _0023_003Dz0EsKsC8_003D, string _0023_003DzAqOpw0w_003D, string _0023_003Dzk64JNOo_003D, string _0023_003Dz2hWShFc_003D, StringComparison _0023_003DzZw5LunE_003D)
	{
		string text = _0023_003Dz0EsKsC8_003D;
		RegexOptions _0023_003DzdNx9MH0_003D = RegexOptions.None;
		if (_0023_003DzZw5LunE_003D == StringComparison.InvariantCultureIgnoreCase || _0023_003DzZw5LunE_003D == StringComparison.CurrentCultureIgnoreCase || _0023_003DzZw5LunE_003D == StringComparison.OrdinalIgnoreCase)
		{
			_0023_003DzdNx9MH0_003D = RegexOptions.IgnoreCase;
		}
		foreach (string item in Utility._0023_003DzZPEv7WT7EohsW_mPuw_003D_003D(text, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, _0023_003DzdNx9MH0_003D))
		{
			text = Utility._0023_003DzqlrZfOA_003D(text, _0023_003DzAqOpw0w_003D + item + _0023_003Dzk64JNOo_003D, _0023_003Dz2hWShFc_003D, _0023_003DzZw5LunE_003D);
		}
		return text;
	}

	private string _0023_003DzAyN8cyl7iRzDqmTwlA_003D_003D()
	{
		string text = _textOverride;
		if (_textOverride.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001)) && _textOverride.Length > 2)
		{
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965927), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965906), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965913), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965892), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965899), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966646), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966653), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966634), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966609), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966620), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966595));
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966606), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966589), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966568), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			if (text.ToUpper().Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966575)))
			{
				int num = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966555), StringComparison.InvariantCultureIgnoreCase);
				string text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966555) + Utility._0023_003DzZPEv7WT7EohsW_mPuw_003D_003D(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966555), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), RegexOptions.IgnoreCase).First() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581);
				int startIndex = num + text2.Length;
				string text3 = text.Substring(startIndex, 1);
				text = _0023_003Dz_0024zUHEPKywYuH((!(text3 != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934509))) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581) : (_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581) + text3), text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966555), string.Empty, StringComparison.InvariantCultureIgnoreCase);
			}
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966535), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty, StringComparison.InvariantCultureIgnoreCase);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966770), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966777), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966756), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = _0023_003Dz_0024zUHEPKywYuH(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966763), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941671), string.Empty);
			text = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679), string.Empty);
		}
		return text;
	}

	protected void FormatText()
	{
		if (_overrideAllText)
		{
			textPrefixFormatted = string.Empty;
			textSuffixFormatted = string.Empty;
		}
		else
		{
			textPrefixFormatted = (string.IsNullOrEmpty(_textPrefix) ? string.Empty : _textPrefix);
			textSuffixFormatted = (string.IsNullOrEmpty(_textSuffix) ? string.Empty : _textSuffix);
		}
		textUpperValue = string.Empty;
		textLowerValue = string.Empty;
		if (_textOverride == null || _textOverride.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001)))
		{
			_formatString = _0023_003DziK7Z2_0024gxUEmL();
			text = GetFormattedValue(GetScaledDistance());
			_formatString = _0023_003Dzx7i2rNhHhXH8();
			switch (ToleranceMode)
			{
			case toleranceType.Symmetrical:
				textUpperValue = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966742) + GetFormattedValue(Math.Abs(UpperValue));
				break;
			case toleranceType.Deviation:
				if (UpperValue >= 0.0)
				{
					textUpperValue = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302929243);
				}
				textUpperValue += GetFormattedValue(UpperValue);
				if (LowerValue < 0.0)
				{
					textLowerValue = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302929243);
				}
				else
				{
					textLowerValue = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752);
				}
				textLowerValue += GetFormattedValue(Math.Abs(LowerValue));
				break;
			case toleranceType.Limits:
			{
				double scaledDistance = GetScaledDistance();
				double value = scaledDistance + UpperValue;
				double value2 = scaledDistance - LowerValue;
				textUpperValue = GetFormattedValue(value);
				textLowerValue = GetFormattedValue(value2);
				break;
			}
			}
		}
		else
		{
			text = _textOverride;
		}
		if (_textOverride != null && _textOverride.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001)))
		{
			string[] array = _0023_003DzAyN8cyl7iRzDqmTwlA_003D_003D().Split(new string[1] { _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001) }, 2, StringSplitOptions.None);
			textPrefixFormatted = array[0] + textPrefixFormatted;
			textSuffixFormatted += array[1];
		}
	}

	protected virtual string GetFormattedValue(double value)
	{
		string text = string.Empty;
		switch (LinearDimensionUnits)
		{
		case linearDimensionUnitsType.Scientific:
		case linearDimensionUnitsType.Decimal:
		case linearDimensionUnitsType.Engineering:
			text = string.Format(_formatString, value);
			break;
		case linearDimensionUnitsType.WindowsDesktop:
			text = string.Format(CultureInfo.InvariantCulture, _formatString, value);
			break;
		case linearDimensionUnitsType.Architectural:
		case linearDimensionUnitsType.Fractional:
			text = _0023_003Dzj3T1bS4ahZLu(value, _0023_003DzfxFaUJOgD8OA8QtBGCqq5gk_003D());
			break;
		}
		if (LinearDimensionUnits == linearDimensionUnitsType.Engineering || LinearDimensionUnits == linearDimensionUnitsType.Architectural)
		{
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930888);
		}
		return text;
	}

	protected virtual double GetScaledDistance()
	{
		return Distance * LinearScale;
	}

	private string _0023_003DziK7Z2_0024gxUEmL()
	{
		string empty = string.Empty;
		if (LinearDimensionUnits == linearDimensionUnitsType.WindowsDesktop)
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966750), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941671), Precision, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679));
		}
		empty = ((!SuppressLeadingZeros) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966716) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966735));
		string text = (SuppressTrailingZeros ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746));
		for (int i = 0; i < Precision; i++)
		{
			empty += text;
		}
		if (LinearDimensionUnits == linearDimensionUnitsType.Scientific)
		{
			empty += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966696);
		}
		return empty + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679);
	}

	private string _0023_003Dzx7i2rNhHhXH8()
	{
		string empty = string.Empty;
		if (LinearDimensionUnits == linearDimensionUnitsType.WindowsDesktop)
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966750), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941671), TolerancePrecision, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679));
		}
		empty = ((!ToleranceSuppressLeadingZeros) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966716) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966735));
		string text = (ToleranceSuppressTralingZeros ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746));
		for (int i = 0; i < TolerancePrecision; i++)
		{
			empty += text;
		}
		if (LinearDimensionUnits == linearDimensionUnitsType.Scientific)
		{
			empty += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966696);
		}
		return empty + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679);
	}

	private static string _0023_003Dzj3T1bS4ahZLu(double _0023_003DzPzO_0024GUk_003D, int _0023_003DzW77M6aVd_LDF_00245knig_003D_003D)
	{
		string text = string.Empty;
		int num = (int)_0023_003DzPzO_0024GUk_003D;
		string text2 = _0023_003Dz0vYHfSXx3JvZ((int)Math.Round((_0023_003DzPzO_0024GUk_003D - (double)num) * (double)_0023_003DzW77M6aVd_LDF_00245knig_003D_003D, MidpointRounding.AwayFromZero), _0023_003DzW77M6aVd_LDF_00245knig_003D_003D);
		if (text2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966673)))
		{
			num++;
			text2 = string.Empty;
		}
		else if (text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966683)))
		{
			text2 = string.Empty;
		}
		if (num > 0)
		{
			text = num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382);
		}
		if (!string.IsNullOrEmpty(text2))
		{
			text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966662), text, text2);
		}
		return text.TrimEnd();
	}

	private static string _0023_003Dz0vYHfSXx3JvZ(int _0023_003Dz8lc6uO0_003D, int _0023_003DzAzQhqk0_003D)
	{
		int num = ((_0023_003Dz8lc6uO0_003D <= _0023_003DzAzQhqk0_003D) ? _0023_003Dz8lc6uO0_003D : _0023_003DzAzQhqk0_003D);
		for (int i = 2; i <= num; i++)
		{
			if (_0023_003Dz8lc6uO0_003D % i == 0 && _0023_003DzAzQhqk0_003D % i == 0)
			{
				_0023_003Dz8lc6uO0_003D /= i;
				_0023_003DzAzQhqk0_003D /= i;
				i--;
			}
		}
		return _0023_003Dz8lc6uO0_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + _0023_003DzAzQhqk0_003D;
	}

	private protected void _0023_003Dz_GuEQ6Cz_DBs(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003Dzfsn580w_003D)
	{
		Point3D[] array = _0023_003DzUEBRkxU84I1gwC6S0Q_003D_003D();
		if (array.Length != 0)
		{
			Point3D[] array2 = new Point3D[_0023_003Dzfsn580w_003D + array.Length];
			Array.Copy(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array2, _0023_003Dzfsn580w_003D);
			Array.Copy(array, 0, array2, _0023_003Dzfsn580w_003D, array.Length);
			_0023_003DzB8iS0QA_003D.DrawLines(array2);
		}
		else
		{
			_0023_003DzB8iS0QA_003D.DrawLines(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, 0, _0023_003Dzfsn580w_003D);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		if (data._0023_003Dzsj3MdDYCLW3m)
		{
			_0023_003Dz5ewp99yrAV_P(data, _0023_003DzDe1zwkzs_Ob1: false);
		}
		else
		{
			DrawDimension(data, drawingForSelection: false);
		}
	}

	protected internal override void Render(RenderParams data)
	{
		Transformation blockRefTransform = null;
		if (data.RenderContext.Shaders != null)
		{
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			Transformation transform = base.Transform;
			data.ShaderParams.BlockRefTransform = data.ShaderParams.BlockRefTransform * transform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
		base.Render(data);
		if (data.RenderContext.Shaders != null)
		{
			data.ShaderParams.BlockRefTransform = blockRefTransform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
	}

	internal void _0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth > 1f)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PushShader();
			_0023_003DzELu0Pss_003D.RenderContext.EnableThickLines();
		}
	}

	internal void _0023_003DzJRtNwJRRVQc52IQRig_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth > 1f)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PopShader();
		}
	}

	protected virtual void DrawExtraGeometry(DrawParams data)
	{
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		if (data._0023_003Dzsj3MdDYCLW3m)
		{
			_0023_003Dz5ewp99yrAV_P(data, _0023_003DzDe1zwkzs_Ob1: true);
		}
		else
		{
			DrawDimension(data, drawingForSelection: true);
		}
	}

	protected internal override void DrawWireframeSelected(DrawParams data)
	{
		if (data._0023_003Dzsj3MdDYCLW3m)
		{
			_0023_003Dz5ewp99yrAV_P(data, _0023_003DzDe1zwkzs_Ob1: true);
		}
		else
		{
			DrawDimension(data, drawingForSelection: true);
		}
	}

	private double _0023_003DzsTatdRsKUoAupnCKbBWDRvw_003D(FontStyleData _0023_003DzdDwkYPc_003D, string _0023_003DzwyYng5o_003D)
	{
		double num = 0.0;
		for (int i = 0; i < _0023_003DzwyYng5o_003D.Length; i++)
		{
			char c = _0023_003DzwyYng5o_003D[i];
			if (c == '.')
			{
				break;
			}
			if (_0023_003DzdDwkYPc_003D.TryGetValue(c.ToString(), out var value))
			{
				num += value.Width;
			}
		}
		return num;
	}

	private void _0023_003DzjC1_0024J2TrnzYtu0BYLQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D, out double _0023_003DzfugAqlZVPR7o, out double _0023_003Dz_N_0024uJIeAUpyP, out bool _0023_003Dz9grTfOz3koUSqD_gHA_003D_003D, out bool _0023_003DztJehyLvNgQhAKG1KLg_003D_003D)
	{
		_0023_003DzfugAqlZVPR7o = 0.0;
		_0023_003Dz_N_0024uJIeAUpyP = 0.0;
		_0023_003Dz9grTfOz3koUSqD_gHA_003D_003D = false;
		_0023_003DztJehyLvNgQhAKG1KLg_003D_003D = false;
		if (ToleranceAlignment)
		{
			TextStyle textStyle = _0023_003DzELu0Pss_003D.TextStyles[base.StyleName];
			FontStyleData _0023_003DzdDwkYPc_003D = _0023_003DzELu0Pss_003D.FontDefs[textStyle.FontFamilyName][textStyle.Style];
			double num = _0023_003DzsTatdRsKUoAupnCKbBWDRvw_003D(_0023_003DzdDwkYPc_003D, textUpperValue);
			double num2 = _0023_003DzsTatdRsKUoAupnCKbBWDRvw_003D(_0023_003DzdDwkYPc_003D, textLowerValue);
			double num3 = Math.Abs(num - num2);
			if (num > num2)
			{
				_0023_003Dz9grTfOz3koUSqD_gHA_003D_003D = true;
				_0023_003DzfugAqlZVPR7o = num3;
			}
			else if (num < num2)
			{
				_0023_003DztJehyLvNgQhAKG1KLg_003D_003D = true;
				_0023_003Dz_N_0024uJIeAUpyP = num3;
			}
		}
	}

	public override void Regen(RegenParams data)
	{
		if (CheckRegenParams(data))
		{
			RegenInternal(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	internal abstract void RegenInternal(RegenParams _0023_003DzELu0Pss_003D);

	private protected void _0023_003DzgFzRnM_0024C_rz3(double _0023_003Dz2AZWQ2NrfVgE, double _0023_003Dz_3DEhPv2yFOK, arrowheadType _0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D, arrowheadType _0023_003DzKrrwUVqL5KgJlVpolA_003D_003D, out double _0023_003DzS_jd4PN2HwcY, out double _0023_003DzKRo7zbbg_dT6, out double _0023_003Dz93dT3hmUKg0E)
	{
		_0023_003DzS_jd4PN2HwcY = _0023_003Dz2AZWQ2NrfVgE;
		double num = _0023_003DzJ7p5EJnvP7td();
		double num2 = num / 2.0;
		switch (TextLocation)
		{
		case elementPositionType.Auto:
			_textIsInside = num < _0023_003Dz_3DEhPv2yFOK;
			if (!UseDefaultTextPosition)
			{
				_textIsInside &= _0023_003DzS_jd4PN2HwcY > 0.0 && _0023_003DzS_jd4PN2HwcY < _0023_003Dz_3DEhPv2yFOK;
			}
			break;
		case elementPositionType.Inside:
			_textIsInside = true;
			break;
		case elementPositionType.Outside:
			_textIsInside = false;
			break;
		}
		double _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D = _0023_003DzS_jd4PN2HwcY;
		double value = Math.Abs(_0023_003Dz_3DEhPv2yFOK - _0023_003DzS_jd4PN2HwcY);
		_0023_003DzL3Hw_0024qWYdWdp_0024JA5XQ_003D_003D(_0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D, _0023_003DzKrrwUVqL5KgJlVpolA_003D_003D, num, _0023_003Dz_3DEhPv2yFOK, _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D, value, UseDefaultTextPosition);
		if (_arrowsIsInside)
		{
			_0023_003DzKRo7zbbg_dT6 = 0.0;
			_0023_003Dz93dT3hmUKg0E = _0023_003Dz_3DEhPv2yFOK;
		}
		else
		{
			_0023_003DzKRo7zbbg_dT6 = 0.0 - _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(_0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D);
			_0023_003Dz93dT3hmUKg0E = _0023_003Dz_3DEhPv2yFOK + _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(_0023_003DzKrrwUVqL5KgJlVpolA_003D_003D);
		}
		double num3 = _0023_003DzS_jd4PN2HwcY;
		double num4 = _0023_003Dz_3DEhPv2yFOK - _0023_003DzS_jd4PN2HwcY;
		if (_textIsInside)
		{
			double num5 = _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(_0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D);
			double num6 = _0023_003Dz9ACJTcDlsOrBkRMssrasU3Y_003D(_0023_003DzKrrwUVqL5KgJlVpolA_003D_003D);
			if (_0023_003Dz_3DEhPv2yFOK < num + num5 + num6)
			{
				_0023_003DzS_jd4PN2HwcY = _0023_003Dz_3DEhPv2yFOK / 2.0;
			}
			else if (UseDefaultTextPosition)
			{
				switch (TextHorizontalPosition)
				{
				case horizontalAlignmentType.Centered:
					_0023_003DzS_jd4PN2HwcY = _0023_003Dz_3DEhPv2yFOK / 2.0;
					break;
				case horizontalAlignmentType.FirstExtensionLine:
					_0023_003DzS_jd4PN2HwcY = num5 + num2;
					break;
				case horizontalAlignmentType.SecondExtensionLine:
					_0023_003DzS_jd4PN2HwcY = _0023_003Dz_3DEhPv2yFOK - num6 - num2;
					break;
				}
			}
			else if (num3 > num4)
			{
				double num7 = num2 + num6;
				if (num4 < num7)
				{
					_0023_003DzS_jd4PN2HwcY = _0023_003Dz_3DEhPv2yFOK - num7;
				}
			}
			else
			{
				double num7 = num2 + num5;
				if (num3 < num7)
				{
					_0023_003DzS_jd4PN2HwcY = num7;
				}
			}
		}
		else if (num3 > num4)
		{
			double num8 = _0023_003Dz_3DEhPv2yFOK + (num2 + _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(_0023_003DzKrrwUVqL5KgJlVpolA_003D_003D));
			if (_0023_003DzS_jd4PN2HwcY < num8)
			{
				_0023_003DzS_jd4PN2HwcY = num8;
			}
			_0023_003Dz93dT3hmUKg0E = _0023_003Dz0qtbSfrFDXVBk7tnxfkcmtc_003D(_0023_003DzS_jd4PN2HwcY, num2, _0023_003DzeMBeuAQ_003D: false);
		}
		else
		{
			double num9 = 0.0 - (num2 + _0023_003DzyH_0024xWtf1YBY_7n7_Rd54RUs_003D(_0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D));
			if (_0023_003DzS_jd4PN2HwcY > num9)
			{
				_0023_003DzS_jd4PN2HwcY = num9;
			}
			_0023_003DzKRo7zbbg_dT6 = _0023_003Dz0qtbSfrFDXVBk7tnxfkcmtc_003D(_0023_003DzS_jd4PN2HwcY, num2, _0023_003DzeMBeuAQ_003D: true);
		}
	}

	private protected void _0023_003DzL3Hw_0024qWYdWdp_0024JA5XQ_003D_003D(arrowheadType _0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D, arrowheadType? _0023_003DzKrrwUVqL5KgJlVpolA_003D_003D, double _0023_003Dz23lOhZzvq8fZ, double _0023_003DzYUMqwZQ_003D, double _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D, double? _0023_003Dzff0MDHHzyHNWtDnNOQ_003D_003D, bool _0023_003DzL2lT7qyADIGH)
	{
		_arrowsIsInside = false;
		arrowheadType? arrowheadType2 = _0023_003DzKrrwUVqL5KgJlVpolA_003D_003D;
		if (!((arrowheadType2.GetValueOrDefault() == arrowheadType.Arrow) & arrowheadType2.HasValue) && _0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D != arrowheadType.Arrow)
		{
			return;
		}
		switch (ArrowsLocation)
		{
		case elementPositionType.Auto:
		{
			double num = _0023_003Dzj7tHTdhKrBCooLH_X2X9_bA_003D(_0023_003Dzzw5mfQSWgyJ2_WRV_0024g_003D_003D);
			double num2 = (_0023_003DzKrrwUVqL5KgJlVpolA_003D_003D.HasValue ? _0023_003Dzj7tHTdhKrBCooLH_X2X9_bA_003D(_0023_003DzKrrwUVqL5KgJlVpolA_003D_003D.Value) : 0.0);
			if (_textIsInside)
			{
				_arrowsIsInside = _0023_003DzYUMqwZQ_003D > num + num2 + _0023_003Dz23lOhZzvq8fZ;
				if (!_0023_003DzL2lT7qyADIGH)
				{
					_arrowsIsInside &= _0023_003DzvORz4YPOFZGESlbQcQ_003D_003D > _0023_003Dz23lOhZzvq8fZ / 2.0 + num;
					if (_0023_003Dzff0MDHHzyHNWtDnNOQ_003D_003D.HasValue)
					{
						_arrowsIsInside &= _0023_003Dzff0MDHHzyHNWtDnNOQ_003D_003D.Value > _0023_003Dz23lOhZzvq8fZ / 2.0 + num2;
					}
				}
			}
			else
			{
				_arrowsIsInside = _0023_003DzYUMqwZQ_003D > num + num2;
			}
			break;
		}
		case elementPositionType.Inside:
			_arrowsIsInside = true;
			break;
		case elementPositionType.Outside:
			_arrowsIsInside = false;
			break;
		}
	}

	internal override void _0023_003Dz6_0024vKBtk_003D(CompileParams _0023_003DzELu0Pss_003D)
	{
		if (ToleranceMode != toleranceType.Limits)
		{
			CompileChars(_textTokens, _0023_003DzELu0Pss_003D);
		}
		CompileChars(_textPrefixTokens, _0023_003DzELu0Pss_003D);
		CompileChars(_textSuffixTokens, _0023_003DzELu0Pss_003D);
		CompileChars(_textUpperValueTokens, _0023_003DzELu0Pss_003D);
		CompileChars(_textLowerValueTokens, _0023_003DzELu0Pss_003D);
	}

	protected virtual void DrawDimension(DrawParams data, bool drawingForSelection, bool invariant = false)
	{
		PreDraw(data);
		DrawExtraGeometry(data);
		RenderContextBase renderContext = data.RenderContext;
		renderContext.PushModelView();
		Transformation textMatrix = GetTextMatrix();
		Color? color = null;
		if (base.Billboard)
		{
			Point3D point3D = new Point3D(exactWidth / (2.0 * base.ScaleX), 0.5, 0.0);
			point3D = textMatrix * point3D;
			renderContext.TranslateMatrixModelView(point3D.X, point3D.Y, point3D.Z);
			renderContext.MultMatrixModelView(GetBillboardTransformation(data, out var scaleX, out var scaleY, out var scaleZ).MatrixAsVectorByColumn);
			renderContext.ScaleMatrixModelView(scaleX, scaleY, scaleZ);
			renderContext.TranslateMatrixModelView(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
		}
		renderContext.MultMatrixModelView(textMatrix);
		Color currentWireColor = data.RenderContext.CurrentWireColor;
		if (data.Viewport.DisplayMode != displayType.HiddenLines && !drawingForSelection)
		{
			currentWireColor = data.RenderContext.CurrentWireColor;
			Color color2 = _0023_003Dz97vP_0024ZQ_003D(data.Layers, data.Attributes.Color);
			if (data.ForceGray)
			{
				color2 = data.viewportInternal.parent.ComputeNonCurrentEntityColor(this, color2, edge: false, data.shouldUseSeparateBuffers);
			}
			data.RenderContext.SetColorWireframe(color2);
			if (data.Viewport.DisplayMode == displayType.Flat && data.BackFaceColorMethod == backfaceColorMethodType.SingleColor && !IsSingleLineFont(data))
			{
				color = data.RenderContext.CurrentMaterial.Ambient;
				data.RenderContext.SetMaterialFrontAmbient(color2);
			}
		}
		bool flag = ShouldSimplify(data);
		if (_overrideAllText)
		{
			if (!flag)
			{
				DrawChars(_textTokens, data);
			}
			else
			{
				renderContext.PopModelView();
				DrawSimplified(data.RenderContext);
				renderContext.PushModelView();
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(textPrefixFormatted) && !flag)
			{
				DrawChars(_textPrefixTokens, data);
			}
			if (ToleranceMode != toleranceType.Limits)
			{
				if (!flag)
				{
					DrawChars(_textTokens, data);
				}
				else
				{
					renderContext.PopModelView();
					DrawSimplified(data.RenderContext);
					renderContext.PushModelView();
				}
			}
			if (ToleranceMode != toleranceType.None && ToleranceMode != toleranceType.Basic)
			{
				if (!flag)
				{
					renderContext.PushModelView();
					renderContext.MultMatrixModelView(new Scaling(ScalingForHeight));
					if (ToleranceMode == toleranceType.Symmetrical)
					{
						DrawChars(_textUpperValueTokens, data);
					}
					else
					{
						_0023_003DzjC1_0024J2TrnzYtu0BYLQ_003D_003D(data, out var _0023_003DzfugAqlZVPR7o, out var _0023_003Dz_N_0024uJIeAUpyP, out var _0023_003Dz9grTfOz3koUSqD_gHA_003D_003D, out var _);
						renderContext.PushModelView();
						if (_0023_003Dz9grTfOz3koUSqD_gHA_003D_003D)
						{
							renderContext.TranslateMatrixModelView(_0023_003DzfugAqlZVPR7o, 0.0, 0.0);
						}
						DrawChars(_textLowerValueTokens, data);
						renderContext.PopModelView();
						double y = (_0023_003DzcAXPBc8_003D() + _0023_003DzBS03wHrqjNoA()) / base.ScaleY;
						renderContext.TranslateMatrixModelView(_0023_003Dz_N_0024uJIeAUpyP, y, 0.0);
						DrawChars(_textUpperValueTokens, data);
					}
					renderContext.PopModelView();
				}
				else
				{
					renderContext.PopModelView();
					DrawSimplified(data.RenderContext);
					renderContext.PushModelView();
				}
			}
			if (!string.IsNullOrEmpty(textSuffixFormatted) && !flag)
			{
				double x = toleranceMaxWidth / base.ScaleX;
				renderContext.TranslateMatrixModelView(x, 0.0, 0.0);
				DrawChars(_textSuffixTokens, data);
			}
		}
		if (data.Viewport.DisplayMode != displayType.HiddenLines && !drawingForSelection)
		{
			data.RenderContext.SetColorWireframe(currentWireColor);
		}
		renderContext.PopModelView();
		renderContext.PushModelView();
		if (invariant)
		{
			base.Compiling = true;
		}
		if (color.HasValue)
		{
			data.RenderContext.SetMaterialFrontAmbient(color.Value);
		}
		Color? color3 = ((!drawingForSelection) ? new Color?(data.Attributes.Color) : (data.IsDrawingForHalo ? new Color?(RenderContextBase.selectionWithoutHaloColor) : ((Color?)null)));
		if (renderContext.IsDirect3D)
		{
			_0023_003DzDRltr_0024tq410iEbjI0g_003D_003D(data);
			DrawEntity(renderContext, color3);
			_0023_003DzJRtNwJRRVQc52IQRig_003D_003D(data);
		}
		else
		{
			DrawEntity(renderContext, color3);
		}
		if (invariant)
		{
			base.Compiling = false;
		}
		renderContext.PopModelView();
		PostDraw(data);
	}

	private Color _0023_003Dz97vP_0024ZQ_003D(LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, Color _0023_003Dzymp9v7A_003D)
	{
		return TextColorMethod switch
		{
			colorMethodType.byEntity => TextColor, 
			colorMethodType.byLayer => _0023_003DzeWJg3NJnk3WA[LayerName].Color, 
			_ => GetColor(_0023_003DzeWJg3NJnk3WA, _0023_003Dzymp9v7A_003D), 
		};
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		if (data._0023_003Dzsj3MdDYCLW3m)
		{
			_0023_003Dz5ewp99yrAV_P(data, _0023_003DzDe1zwkzs_Ob1: true);
		}
		else
		{
			DrawDimension(data, drawingForSelection: true);
		}
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity._0023_003Dzz3lsBX3i0Rg2(data, _vertices, _0023_003DzxSQq_z8UBHFBzDdKkA_003D_003D()))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_vertices, _0023_003DzxSQq_z8UBHFBzDdKkA_003D_003D(), data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected override void DrawSimplified(RenderContextBase context)
	{
		int num;
		for (num = firstVertexIndexForTexts; num < _vertices.Length; num++)
		{
			context.DrawLineLoop(_vertices, num, 4);
			num += 3;
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, _vertices, 6, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, _vertices, 6, 2))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public Entity[] Explode()
	{
		if (Vertices == null)
		{
			RegenInternal(new RegenParams(0.0, Utility._0023_003DzSNemwQo_003D / 24.0));
		}
		List<Entity> list = new List<Entity>();
		GetLines(0.0, null, _0023_003DzzGo2_Wb1L5us: true, out var _0023_003DzyIUKu5w_003D, out var _);
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Length; i++)
		{
			Line line = new Line(_0023_003DzyIUKu5w_003D[i++], _0023_003DzyIUKu5w_003D[i]);
			Entity.PropagateAttributes(this, line, force: true);
			list.Add(line);
		}
		Point3D[][] triangles = GetTriangles(0.0, null);
		for (int j = 0; j < triangles.Length; j++)
		{
			for (int k = 0; k < triangles[j].Length; k++)
			{
				Triangle triangle = new Triangle(triangles[j][k++], triangles[j][k++], triangles[j][k]);
				Entity.PropagateAttributes(this, triangle, force: true);
				list.Add(triangle);
			}
		}
		Point3D[] textRectangleVertices = GetTextRectangleVertices();
		int num = textRectangleVertices.Length / 4;
		for (int l = 0; l < num; l++)
		{
			string textString = textLines[l];
			Point3D point3D = textRectangleVertices[l * 4];
			Point3D point3D2 = textRectangleVertices[l * 4 + 1];
			Point3D b = textRectangleVertices[l * 4 + 3];
			Point3D p;
			Vector3D vector3D;
			if (!textFlipped)
			{
				p = point3D;
				vector3D = new Vector3D(point3D, point3D2);
			}
			else
			{
				p = point3D2;
				vector3D = new Vector3D(point3D2, point3D);
			}
			Plane textPlane = new Plane(p, vector3D, Vector3D.Cross(Vector3D.AxisZ, vector3D));
			double num2 = Point3D.Distance(point3D, b);
			Text text = new Text(textPlane, textString, num2, alignmentType.BaselineLeft, base.StyleName)
			{
				WidthFactor = WidthFactor,
				Backward = Backward,
				UpsideDown = UpsideDown
			};
			Entity.PropagateAttributes(this, text, force: true);
			list.Add(text);
		}
		return list.ToArray();
	}

	internal virtual void GetLines(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		_0023_003DzyIUKu5w_003D = _0023_003DzUEBRkxU84I1gwC6S0Q_003D_003D();
		if (_0023_003DzFM3KC0w_003D != null && (!_0023_003DzzGo2_Wb1L5us || _0023_003DzFM3KC0w_003D.TextStyles[base.StyleName].IsSHX()))
		{
			_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = GetOutlines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D);
		}
		else
		{
			_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = null;
		}
	}

	protected internal override Point3D[] GetTextRectangleVertices()
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = firstVertexIndexForTexts; i < _vertices.Length; i++)
		{
			list.Add(_vertices[i]);
		}
		return list.ToArray();
	}

	private IndexTriangle[] _0023_003DzxSQq_z8UBHFBzDdKkA_003D_003D()
	{
		List<IndexTriangle> list = new List<IndexTriangle>();
		int num;
		for (num = firstVertexIndexForTexts; num < _vertices.Length; num++)
		{
			list.Add(new IndexTriangle(num, num + 1, num + 2));
			list.Add(new IndexTriangle(num, num + 2, num + 3));
			num += 3;
		}
		return list.ToArray();
	}

	public override Mesh[] ConvertToMesh(IWorkspace workspace, bool skipNormals = false)
	{
		Point3D[][] triangles = GetTriangles(0.0, workspace);
		Mesh[] array = new Mesh[triangles.Length];
		for (int i = 0; i < triangles.Length; i++)
		{
			IndexTriangle[] array2 = new IndexTriangle[triangles[i].Length / 3];
			int num = 0;
			for (int j = 0; j < triangles[i].Length; j += 3)
			{
				array2[num++] = new IndexTriangle(j, j + 1, j + 2);
			}
			array[i] = new Mesh(triangles[i], array2);
		}
		return array;
	}

	protected override void GetTextOutlines(double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation transform, double fontScale, RenderContextBase renderContext, bool IsRightToLeft, out ICurve[] ptOuters, out ICurve[][] ptInners)
	{
		Transformation transformation = GetTextMatrix();
		if (transform != null && !transform.IsIdentity())
		{
			transformation = transform * transformation;
		}
		List<ICurve> list = new List<ICurve>();
		List<ICurve[]> list2 = new List<ICurve[]>();
		ICurve[] outers = new ICurve[0];
		GetTextOutlinesInternal(textPrefixFormatted, deviation, computeInners, toCurve, isShx, fsd, transformation, fontScale, renderContext, IsRightToLeft, out outers, out var inners);
		list.AddRange(outers);
		list2.AddRange(inners);
		transformation *= (Transformation)new Translation(prefixWidth / base.ScaleX, 0.0);
		if (ToleranceMode != toleranceType.Limits)
		{
			GetTextOutlinesInternal(text, deviation, computeInners, toCurve, isShx, fsd, transformation, fontScale, renderContext, IsRightToLeft, out outers, out inners);
			list.AddRange(outers);
			list2.AddRange(inners);
			transformation *= (Transformation)new Translation(textWidth / base.ScaleX, 0.0);
		}
		if (ToleranceMode != toleranceType.None && ToleranceMode != toleranceType.Basic)
		{
			Transformation transformation2 = transformation * new Scaling(ScalingForHeight);
			Transformation transformation3 = new Identity();
			if (ToleranceMode != toleranceType.Symmetrical)
			{
				transformation3 = new Translation(0.0, (_0023_003DzcAXPBc8_003D() + _0023_003DzBS03wHrqjNoA()) / base.ScaleY);
			}
			GetTextOutlinesInternal(textUpperValue, deviation, computeInners, toCurve, isShx, fsd, transformation2 * transformation3, fontScale, renderContext, IsRightToLeft, out outers, out inners);
			list.AddRange(outers);
			list2.AddRange(inners);
			GetTextOutlinesInternal(textLowerValue, deviation, computeInners, toCurve, isShx, fsd, transformation2, fontScale, renderContext, IsRightToLeft, out outers, out inners);
			list.AddRange(outers);
			list2.AddRange(inners);
			transformation *= (Transformation)new Translation(toleranceMaxWidth / base.ScaleX, 0.0);
		}
		GetTextOutlinesInternal(textSuffixFormatted, deviation, computeInners, toCurve, isShx, fsd, transformation, fontScale, renderContext, IsRightToLeft, out outers, out inners);
		list.AddRange(outers);
		list2.AddRange(inners);
		ptOuters = list.ToArray();
		ptInners = list2.ToArray();
	}

	protected override Point3D[][] GetTrianglesInternal(IWorkspace ws, Transformation myTransform, double accuracy)
	{
		List<Point3D[]> list = new List<Point3D[]>();
		if (base.Height == 0.0)
		{
			return list.ToArray();
		}
		if (_overrideAllText)
		{
			list.AddRange(GetTrianglesInternal(_textTokens, ws, myTransform, accuracy));
		}
		else
		{
			list.AddRange(GetTrianglesInternal(_textPrefixTokens, ws, myTransform, accuracy));
			myTransform *= (Transformation)new Translation(prefixWidth / base.ScaleX, 0.0);
			if (ToleranceMode != toleranceType.Limits)
			{
				list.AddRange(GetTrianglesInternal(_textTokens, ws, myTransform, accuracy));
				myTransform *= (Transformation)new Translation(textWidth / base.ScaleX, 0.0);
			}
			if (ToleranceMode != toleranceType.None && ToleranceMode != toleranceType.Basic)
			{
				Transformation transformation = myTransform * new Scaling(ScalingForHeight);
				Transformation transformation2 = new Identity();
				if (ToleranceMode != toleranceType.Symmetrical)
				{
					transformation2 = new Translation(0.0, (_0023_003DzcAXPBc8_003D() + _0023_003DzBS03wHrqjNoA()) / base.ScaleY);
				}
				list.AddRange(GetTrianglesInternal(_textUpperValueTokens, ws, transformation * transformation2, accuracy));
				list.AddRange(GetTrianglesInternal(_textLowerValueTokens, ws, transformation, accuracy));
				myTransform *= (Transformation)new Translation(toleranceMaxWidth / base.ScaleX, 0.0);
			}
			list.AddRange(GetTrianglesInternal(_textSuffixTokens, ws, myTransform, accuracy));
		}
		return list.ToArray();
	}

	protected Point3D[] GetTickLines(Transformation transf)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzAsickqGJmWyb(base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetObliqueLines(Transformation transf)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dz3G4PHFDwqBm63GjtmQ_003D_003D(base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetLinesFromVertices(Point3D[] points, bool addLast)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(points, addLast);
	}

	protected void DrawTick(RenderContextBase context)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzZl3uTZY2SDdp(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	private float[] _0023_003DzzCXLkSM73GwupUILb0KaXdM_003D()
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzzCXLkSM73GwupUILb0KaXdM_003D(_0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected void DrawOblique(RenderContextBase context)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	private float[] _0023_003DzdOiIMde42WZspPfFdJkjWOh1QOSS()
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzdOiIMde42WZspPfFdJkjWOh1QOSS(_0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetArrowPointingLeftLines(Transformation transf)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzlvD2fJo5d_yaFUbSOV7UWt4_003D(base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected void DrawArrowPointingLeft(RenderContextBase context)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzySK4JX4gwaSvQLZwafPBUrg_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	private float[] _0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D()
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D(_0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetArrowPointingRightLines(Transformation transf)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dzd7LiuW2xMrAeCjaaV_M04AQ_003D(base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected void DrawArrowPointingRight(RenderContextBase context)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzVzztx8bmo4zSS6PPA7so8sc_003D(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	private float[] _0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D()
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D(_0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetDotLines(Transformation transf)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzEDm2bXouvM6M(base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected void DrawDot(RenderContextBase context)
	{
		_0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzT2MIyACvYuZK(context, drawData, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), base.Compiling);
	}

	private float[] _0023_003DzL53m6xG6wGal3GveHSAv178_003D()
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzL53m6xG6wGal3GveHSAv178_003D(_0023_003DzgS34mQ6iHM79p4pdqg_003D_003D());
	}

	protected Point3D[] GetArrowHeadTriangles(arrowheadType arrowHead, Transformation transf, bool reverse)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(arrowHead, base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _arrowsIsInside, reverse);
	}

	protected Point3D[] GetArrowHeadPoints(arrowheadType arrowHead, Transformation transf, bool reverse)
	{
		return _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D._0023_003Dz7tEgWrFHxteq(arrowHead, base.Plane, transf, _0023_003DzgS34mQ6iHM79p4pdqg_003D_003D(), _arrowsIsInside, reverse);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966385) + _linearScale);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966375) + _scaleOverall);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966368) + _textLocation);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966325) + _arrowsLocation);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966320) + _textPrefix);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966275) + _textSuffix);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966522) + _textOverride);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966511) + _textGap);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956152) + _arrowheadSize);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966465) + _precision);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966454) + _suppressLeadingZeros);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966422) + _suppressTrailingZeros);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967157) + _toleranceMode);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967149) + _upperValue);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967108) + _lowerValue);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967095) + _scalingForHeight);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967059) + _toleranceSuppressLeadingZeros);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967293) + _toleranceSuppressTrailingZeros);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967242) + _tolerancePrecision);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967205) + _dimStyle);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967200) + Distance);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966898) + _linearDimensionUnits);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966868) + TextHorizontalPosition);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966838) + TextVerticalPosition);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return null;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965319), _dimLinePos);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965285), _textPrefix);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965271), _textOverride);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965259), _textSuffix);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965501), _textGap);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965486), _textLocation);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956360), _arrowheadSize);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912396), Precision);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965471), _suppressLeadingZeros);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965438), _suppressTrailingZeros);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965404), _linearScale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965389), _scaleOverall);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966113), _linearDimensionUnits);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966112), _toleranceMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966067), _upperValue);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966053), _lowerValue);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966039), _scalingForHeight);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966258), _toleranceSuppressLeadingZeros);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966231), _toleranceSuppressTrailingZeros);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966207), _tolerancePrecision);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966169), ToleranceAlignment);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965875), TextColorMethod);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965867), TextColor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965854), TextHorizontalPosition);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965817), TextVerticalPosition);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965782), UseDefaultTextPosition);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				base.Plane.Origin,
				_dimLinePos
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public override void TransformBy(Transformation xform)
	{
		if (xform.HasScaling)
		{
			ArrowheadSize *= xform.ScaleFactorX;
			TextGap *= xform.ScaleFactorY;
		}
		base.TransformBy(xform);
		if (xform.HasScaling)
		{
			DimSetup();
		}
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(_basicToleranceBoxVertices, _0023_003DzLS0sR0pzioXc);
		if (_dimLineInterruptionPoints != null)
		{
			Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(_dimLineInterruptionPoints, _0023_003DzLS0sR0pzioXc);
		}
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
	}

	protected void DrawHeads(RenderContextBase context, object myParams = null)
	{
		Transformation transform = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		context.PushShader();
		if (context.CurrentShader.ToString().Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966806)))
		{
			context.SetLinesShader(thick: false, context.CurrentShader);
		}
		context.PushModelView();
		context.MultMatrixModelView(transform);
		DrawHeadsInternal(context, myParams);
		context.PopModelView();
		context.PopShader();
	}

	protected virtual void DrawHeadsInternal(RenderContextBase context, object myParams)
	{
		throw new NotImplementedException();
	}

	protected void DrawArrowHead(RenderContextBase context, arrowheadType arrowhead, double myDistance, bool reverse, Color? arrowColor)
	{
		if (context.CurrentLineWidth > 1f)
		{
			context.SetLineSize(1f);
			if (arrowColor.HasValue)
			{
				context.SetColorWireframe(arrowColor.Value);
			}
		}
		switch (arrowhead)
		{
		case arrowheadType.Arrow:
			DrawArrow(context, myDistance, reverse);
			break;
		case arrowheadType.Tick:
			DrawTick(context, myDistance, reverse);
			break;
		case arrowheadType.Dot:
			DrawDot(context, myDistance, reverse);
			break;
		case arrowheadType.Oblique:
			DrawOblique(context, myDistance, reverse);
			break;
		}
	}

	protected virtual void DrawArrow(RenderContextBase context, double myDistance, bool reverse)
	{
		throw new NotImplementedException();
	}

	protected virtual void DrawTick(RenderContextBase context, double myDistance, bool reverse)
	{
		throw new NotImplementedException();
	}

	protected virtual void DrawDot(RenderContextBase context, double myDistance, bool reverse)
	{
		throw new NotImplementedException();
	}

	protected virtual void DrawOblique(RenderContextBase context, double myDistance, bool reverse)
	{
		throw new NotImplementedException();
	}

	private double _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D()
	{
		if (!textFlipped)
		{
			return _0023_003DzcAXPBc8_003D();
		}
		return 0.0 - _0023_003DzcAXPBc8_003D();
	}

	private double _0023_003DzmawtlUY9m7_0024MjRqQQ9sWqlk_003D()
	{
		if (!textFlipped)
		{
			return _0023_003DzBS03wHrqjNoA();
		}
		return 0.0 - _0023_003DzBS03wHrqjNoA();
	}

	private protected double _0023_003DzSKl3eSMXQFvZ()
	{
		return TextVerticalPosition switch
		{
			verticalAlignmentType.Above => _0023_003Dq5gB0KAFD5K4wIG3yZ3HYqaao7i4deM4Yu6OaAMKSF3JP3vE82kZ4wpAAanPIlwjVBKUa_X_0024rjdBs765FwlyQqg_003D_003D(), 
			verticalAlignmentType.Centered => (0.0 - exactTextHeight) / 2.0, 
			verticalAlignmentType.Below => 0.0 - (exactTextHeight + _0023_003Dq5gB0KAFD5K4wIG3yZ3HYqaao7i4deM4Yu6OaAMKSF3JP3vE82kZ4wpAAanPIlwjVBKUa_X_0024rjdBs765FwlyQqg_003D_003D()), 
			_ => 0.0, 
		};
	}

	private protected void _0023_003DzzCaChFUggCUnnuTszAfinDY_003D(Point3D[] _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D, bool _0023_003DzCpjsF78_003D, bool _0023_003DzjTr87nBCi_hO)
	{
		int num = firstVertexIndexForTexts;
		string item = text;
		double num2 = textWidth;
		bool flag = false;
		if (!_overrideAllText && ToleranceMode == toleranceType.Limits)
		{
			item = textLowerValue;
			num2 = toleranceLowWidth;
			flag = true;
		}
		textLines.Add(item);
		if (_0023_003DzCpjsF78_003D)
		{
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + num2);
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * (flag ? ScalingForHeight : 1.0), _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
		}
		else
		{
			if (textFlipped)
			{
				if (ToleranceMode == toleranceType.Limits)
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts].X + exactWidth - num2 - prefixWidth * 2.0, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts].Y);
				}
				else
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts].X - prefixWidth + suffixWidth + toleranceMaxWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[firstVertexIndexForTexts].Y);
				}
			}
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + num2, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * (flag ? ScalingForHeight : 1.0));
			_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
		}
		if (!_overrideAllText)
		{
			int num3 = num;
			int num4 = 0;
			num += 4;
			if (!string.IsNullOrEmpty(textPrefixFormatted))
			{
				textLines.Add(textPrefixFormatted);
				if (_0023_003DzCpjsF78_003D)
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 4].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 4].Y - prefixWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + prefixWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D(), _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
				}
				else
				{
					if (textFlipped)
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 3].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 4].Y);
					}
					else
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 4].X - prefixWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num - 4].Y);
					}
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + prefixWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D());
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
				}
				num += 4;
			}
			if (ToleranceMode == toleranceType.Deviation)
			{
				if (_0023_003DzCpjsF78_003D)
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y + textWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + toleranceLowWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
				}
				else
				{
					if (textFlipped)
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X - toleranceLowWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
					}
					else
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X + textWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
					}
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + toleranceLowWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
				}
				textLines.Add(textLowerValue);
				num3 = num;
				num += 4;
			}
			if (!string.IsNullOrEmpty(textUpperValue))
			{
				textLines.Add(textUpperValue);
				num4 = num;
				if (ToleranceMode == toleranceType.Symmetrical)
				{
					if (_0023_003DzCpjsF78_003D)
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y + textWidth);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + toleranceUpWidth);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					}
					else
					{
						if (textFlipped)
						{
							_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X - toleranceUpWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
						}
						else
						{
							_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X + textWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
						}
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + toleranceUpWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
					}
				}
				else if (_0023_003DzCpjsF78_003D)
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3 + 2].X - _0023_003DzmawtlUY9m7_0024MjRqQQ9sWqlk_003D() * ScalingForHeight, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + toleranceUpWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
				}
				else
				{
					if (textFlipped)
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X + toleranceLowWidth - toleranceUpWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3 + 2].Y + _0023_003DzmawtlUY9m7_0024MjRqQQ9sWqlk_003D() * ScalingForHeight);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + toleranceUpWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					}
					else
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3 + 2].Y + _0023_003DzmawtlUY9m7_0024MjRqQQ9sWqlk_003D() * ScalingForHeight);
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + toleranceUpWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					}
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D() * ScalingForHeight);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
				}
				num += 4;
			}
			if (!string.IsNullOrEmpty(textSuffixFormatted))
			{
				int num5 = ((toleranceUpWidth > toleranceLowWidth) ? num4 : num3);
				textLines.Add(textSuffixFormatted);
				if (_0023_003DzCpjsF78_003D)
				{
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num5 + 1].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y + suffixWidth);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X - _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D(), _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
				}
				else
				{
					if (textFlipped)
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num5].X - suffixWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
					}
					else
					{
						_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num5 + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num3].Y);
					}
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X + suffixWidth, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].Y);
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 1].Y + _0023_003DzEg0Pd0v5Zui6DITtTg_003D_003D());
					_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 3] = new Point3D(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num].X, _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[num + 2].Y);
				}
			}
		}
		_0023_003DzuVHgvyiVTFls2_3_vLycH1_n4Re1(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D, _0023_003DzjTr87nBCi_hO);
	}

	private protected void _0023_003DzuVHgvyiVTFls2_3_vLycH1_n4Re1(Point3D[] _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D, bool _0023_003DzEkR_P10_003D)
	{
		_basicToleranceBoxVertices = Array.Empty<Point3D>();
		if (ToleranceMode == toleranceType.Basic || _0023_003DzEkR_P10_003D)
		{
			Point3D[] array = new Point3D[_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D.Length - firstVertexIndexForTexts];
			Array.Copy(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D, firstVertexIndexForTexts, array, 0, array.Length);
			Utility.BoundingBox(array, out var min, out var max);
			double num = _0023_003DzljmTG744AIjo();
			min.X -= num;
			min.Y -= num;
			max.X += num;
			max.Y += num;
			Point3D point3D = new Point3D(max.X, min.Y);
			Point3D point3D2 = new Point3D(min.X, max.Y);
			_basicToleranceBoxVertices = new Point3D[4] { min, point3D, max, point3D2 };
		}
	}

	private void _0023_003Dzu6_0024Whg6Iwz__B0F4_0024Q_003D_003D(Point3D[] _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D, out Point3D _0023_003DzsS1C7vc9N_ri, out double _0023_003DzN_00244hHJTN8WML)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = firstVertexIndexForTexts; i < _0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D.Length; i++)
		{
			list.Add(_0023_003DzSO9A0vSBxeK9sCPlKmUegwY_003D[i]);
		}
		Utility.BoundingBox(list, out var min, out var max);
		_0023_003DzsS1C7vc9N_ri = new Point3D((min.X + max.X) / 2.0, (min.Y + max.Y) / 2.0);
		Vector2D u = new Vector2D(base.Plane.Origin, DimLinePosition);
		_0023_003DzN_00244hHJTN8WML = Vector2D.SignedAngleBetween(u, base.Plane.AxisX);
	}

	private Point3D[] _0023_003DzUEBRkxU84I1gwC6S0Q_003D_003D()
	{
		if (_basicToleranceBoxVertices.Length != 0)
		{
			return new Point3D[8]
			{
				_basicToleranceBoxVertices[0],
				_basicToleranceBoxVertices[1],
				_basicToleranceBoxVertices[2],
				_basicToleranceBoxVertices[3],
				_basicToleranceBoxVertices[1],
				_basicToleranceBoxVertices[2],
				_basicToleranceBoxVertices[3],
				_basicToleranceBoxVertices[0]
			};
		}
		return _basicToleranceBoxVertices;
	}

	internal static Point3D[][] _0023_003DzWK9zktX5UYDRYv8YQncuY5M_003D(Point3D[][] _0023_003DznTMMDLcTw5Mi, Point3D[] _0023_003DzODmzqhKgfV9FgRqr5pymjR475kPj)
	{
		Point3D[][] array = new Point3D[_0023_003DznTMMDLcTw5Mi.GetLength(0) + 1][];
		int i;
		for (i = 0; i < _0023_003DznTMMDLcTw5Mi.GetLength(0); i++)
		{
			array[i] = _0023_003DznTMMDLcTw5Mi[i];
		}
		array[i] = _0023_003DzODmzqhKgfV9FgRqr5pymjR475kPj;
		return array;
	}

	private double _0023_003Dq5gB0KAFD5K4wIG3yZ3HYqaao7i4deM4Yu6OaAMKSF3JP3vE82kZ4wpAAanPIlwjVBKUa_X_0024rjdBs765FwlyQqg_003D_003D()
	{
		double num = _0023_003DzljmTG744AIjo();
		if (ToleranceMode == toleranceType.Basic)
		{
			return num * 2.0;
		}
		return num;
	}
}
