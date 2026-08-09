using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class MultilineText : Text
{
	internal List<string> textLines;

	private string[][] _linesTokens;

	internal Point2D[] positions;

	internal double[] exactWidths;

	internal double[] myWidthFactors;

	private bool _wordWrap = true;

	private double _rectWidth;

	private double _rectHeight;

	private double[] _widthFactors;

	public bool Wrap
	{
		get
		{
			return _wordWrap;
		}
		set
		{
			_wordWrap = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double LineSpaceDistance { get; set; }

	public double RectWidth
	{
		get
		{
			return _rectWidth;
		}
		set
		{
			_rectWidth = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	[Obsolete("Use RectWidth instead.")]
	public double Width
	{
		get
		{
			return RectWidth;
		}
		set
		{
			RectWidth = value;
		}
	}

	public double RectHeight
	{
		get
		{
			return _rectHeight;
		}
		set
		{
			_rectHeight = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public override double WidthFactor
	{
		set
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973537));
		}
	}

	public double[] WidthFactors
	{
		get
		{
			return _widthFactors;
		}
		set
		{
			_widthFactors = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public override alignmentType Alignment
	{
		get
		{
			return alignment;
		}
		set
		{
			if (alignment != value)
			{
				Point3D _0023_003Dzz710fPUHVlV = _0023_003DzFR_UvI_P_8hJ();
				alignment = value;
				_0023_003Dzvp3WRyUikWoH(_0023_003Dzz710fPUHVlV);
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	public override Point3D InsertionPoint
	{
		get
		{
			return base.Plane.Origin;
		}
		set
		{
			base.Plane.Origin = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public string Contents { get; set; }

	public MultilineText(double x, double y, string textString, double width, double height, double lineSpaceDistance)
		: this(x, y, 0.0, textString, width, height, lineSpaceDistance)
	{
	}

	public MultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance)
		: this(x, y, z, textString, width, height, lineSpaceDistance, _0023_003DzzzJE33Q87WgH())
	{
	}

	public MultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: this(x, y, z, textString, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public MultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName)
		: this(x, y, z, textString, width, height, lineSpaceDistance, alignment, styleName, simplify: true)
	{
	}

	public MultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		_0023_003DzDBrp9S8_003D(new Point3D(x, y, z), textString, width, height, lineSpaceDistance, alignment, styleName, simplify, wrap);
	}

	public MultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance)
		: this(insPoint, textString, width, height, lineSpaceDistance, _0023_003DzzzJE33Q87WgH())
	{
	}

	public MultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: this(insPoint, textString, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public MultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName)
		: this(insPoint, textString, width, height, lineSpaceDistance, alignment, styleName, simplify: true)
	{
	}

	public MultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		_0023_003DzDBrp9S8_003D(insPoint, textString, width, height, lineSpaceDistance, alignment, styleName, simplify, wrap);
	}

	public MultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance)
		: this(textPlane, textString, width, height, lineSpaceDistance, _0023_003DzzzJE33Q87WgH())
	{
	}

	public MultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: this(textPlane, textString, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public MultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName)
		: this(textPlane, textString, width, height, lineSpaceDistance, alignment, styleName, simplify: true)
	{
	}

	public MultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName, bool simplify, bool wrap = true)
		: base(textPlane)
	{
		_0023_003DzDBrp9S8_003D(textPlane.Origin, textString, width, height, lineSpaceDistance, alignment, styleName, simplify, wrap);
	}

	public MultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance)
		: this(textPlane, insPoint, textString, width, height, lineSpaceDistance, _0023_003DzzzJE33Q87WgH())
	{
	}

	public MultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: this(textPlane, insPoint, textString, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public MultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName)
		: this(textPlane, insPoint, textString, width, height, lineSpaceDistance, alignment, styleName, simplify: true)
	{
	}

	public MultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName, bool simplify, bool wrap = true)
		: base(textPlane)
	{
		_0023_003DzDBrp9S8_003D(insPoint, textString, width, height, lineSpaceDistance, alignment, styleName, simplify, wrap);
	}

	public MultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: this(sketchPlane, insPoint, textString, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public MultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName)
		: this(sketchPlane, insPoint, textString, width, height, lineSpaceDistance, alignment, styleName, simplify: true)
	{
	}

	public MultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, alignmentType alignment, string styleName, bool simplify, bool wrap = true)
		: base(sketchPlane)
	{
		_0023_003DzDBrp9S8_003D(sketchPlane.PointAt(insPoint), textString, width, height, lineSpaceDistance, alignment, styleName, simplify, wrap);
	}

	protected MultilineText(Plane textPlane, Point3D insPoint, double width, double height, double lineSpaceDistance, alignmentType alignment)
		: base(textPlane)
	{
		_0023_003DzDBrp9S8_003D(insPoint, string.Empty, width, height, lineSpaceDistance, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false, _0023_003DzPRvAsQk_003D: true);
	}

	public MultilineText(MultilineText another)
		: base(another)
	{
		LineSpaceDistance = another.LineSpaceDistance;
		RectWidth = another.RectWidth;
		RectHeight = another.RectHeight;
		Wrap = another.Wrap;
		Contents = another.Contents;
		WidthFactors = another.WidthFactors;
	}

	protected internal MultilineText(MultilineTextSurrogate surrogate)
		: this(surrogate.Plane, surrogate.TextString, surrogate.RectWidth, surrogate.Height, surrogate.LineSpaceDistance)
	{
	}

	protected MultilineText(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		LineSpaceDistance = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973719));
		RectWidth = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973711));
		RectHeight = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973951));
		Wrap = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973906));
		Contents = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973915));
		WidthFactors = (double[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973900), typeof(double[]));
	}

	private new static alignmentType _0023_003DzzzJE33Q87WgH()
	{
		return alignmentType.TopLeft;
	}

	private void _0023_003DzDBrp9S8_003D(Point3D _0023_003DzJPR4E5ZNOD6H, string _0023_003DzlUfsUzo_003D, double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D, double _0023_003Dzz8hUs7th6PvS, alignmentType _0023_003Dz1pzzCsQ_003D, string _0023_003DzMc5f1FY_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, bool _0023_003DzPRvAsQk_003D)
	{
		base.Plane.Origin = _0023_003DzJPR4E5ZNOD6H;
		text = _0023_003DzlUfsUzo_003D;
		height = _0023_003DzvAxV_0024Ic_003D;
		alignment = _0023_003Dz1pzzCsQ_003D;
		base.StyleName = _0023_003DzMc5f1FY_003D;
		base.Simplify = _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D;
		RectWidth = _0023_003Dz6tVBpdk_003D;
		LineSpaceDistance = _0023_003Dzz8hUs7th6PvS;
		Wrap = _0023_003DzPRvAsQk_003D;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new MultilineTextSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973719), LineSpaceDistance);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973711), RectWidth);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973951), RectHeight);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973906), Wrap);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973915), Contents);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973900), WidthFactors);
	}

	public override void Regen(RegenParams data)
	{
		if (CheckRegenParams(data))
		{
			_0023_003DzAJ2wgzdeSgYt(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	private void _0023_003DzAJ2wgzdeSgYt(RegenParams _0023_003DzELu0Pss_003D)
	{
		textLines = new List<string>(text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None));
		_linesTokens = new string[textLines.Count][];
		exactWidths = new double[textLines.Count];
		double[] array = new double[textLines.Count];
		Point3D[] array2 = new Point3D[textLines.Count];
		Point3D[] array3 = new Point3D[textLines.Count];
		if (WidthFactors == null || WidthFactors.Length != textLines.Count)
		{
			myWidthFactors = new double[textLines.Count];
			for (int i = 0; i < textLines.Count; i++)
			{
				myWidthFactors[i] = -1.0;
			}
		}
		else
		{
			myWidthFactors = new double[WidthFactors.Length];
			for (int j = 0; j < textLines.Count; j++)
			{
				myWidthFactors[j] = WidthFactors[j];
			}
		}
		for (int k = 0; k < textLines.Count; k++)
		{
			_0023_003DzhnnXav8_003D(textLines[k], _0023_003DzELu0Pss_003D, ref myWidthFactors[k], out exactWidths[k], out array[k], out var _0023_003DzDPcjoBJLcqli, out var _0023_003Dz_0024N_0024yKptW9BoC, out _linesTokens[k]);
			array2[k] = _0023_003DzDPcjoBJLcqli;
			array3[k] = _0023_003Dz_0024N_0024yKptW9BoC;
		}
		if (RectWidth > 0.0 && _0023_003DzELu0Pss_003D.Workspace != null)
		{
			TextStyle textStyle = _0023_003DzELu0Pss_003D.TextStyles[base.StyleName];
			if (_0023_003DzaNtM2nfRekbc(textLines, textStyle.IsSHX(), textStyle.FontFamilyName, textStyle.Style, exactWidths, _0023_003DzELu0Pss_003D, out var _0023_003Dz5WvOfowW3utZ, out var _0023_003DzZXpMhOrFju))
			{
				textLines = _0023_003Dz5WvOfowW3utZ;
				_linesTokens = _0023_003DzZXpMhOrFju;
				exactWidths = new double[textLines.Count];
				array = new double[textLines.Count];
				array2 = new Point3D[textLines.Count];
				array3 = new Point3D[textLines.Count];
				for (int l = 0; l < _0023_003Dz5WvOfowW3utZ.Count; l++)
				{
					_0023_003DziivS_0024a924P2e(_linesTokens[l], textStyle.FontFamilyName, textStyle.Style, _0023_003DzELu0Pss_003D.FontDefs, myWidthFactors[l], out exactWidths[l], out array[l], out array2[l], out array3[l]);
				}
			}
		}
		positions = new Point2D[textLines.Count];
		double num = 0.0;
		_vertices = new Point3D[textLines.Count * 4];
		int num2 = 0;
		double num3 = 0.0;
		switch (alignment)
		{
		case alignmentType.MiddleLeft:
		case alignmentType.MiddleCenter:
		case alignmentType.MiddleRight:
			num3 += LineSpaceDistance * (double)(textLines.Count - 1) / 2.0;
			break;
		case alignmentType.BottomLeft:
		case alignmentType.BottomCenter:
		case alignmentType.BottomRight:
			num3 += LineSpaceDistance * (double)(textLines.Count - 1);
			break;
		}
		for (int m = 0; m < textLines.Count; m++)
		{
			double offsetX = ((_0023_003DzELu0Pss_003D.Workspace != null && _0023_003DzELu0Pss_003D.TextStyles[base.StyleName].IsSHX() && array2[m] != null) ? array2[m].X : 0.0);
			positions[m] = Text.ComputePosition(exactWidths[m], height, array[m], offsetX, Alignment);
			positions[m].Y += num3;
			Point2D point2D = new Point2D(positions[m].X, positions[m].Y + num);
			Point2D point2D2 = new Point2D(positions[m].X, positions[m].Y + num);
			if (array2[m] != null)
			{
				point2D.X += array2[m].X;
				point2D.Y += array2[m].Y;
				point2D2.X += array3[m].X;
				point2D2.Y += array3[m].Y;
			}
			_vertices[num2++] = new Point3D(point2D.X, point2D.Y, 0.0);
			_vertices[num2++] = new Point3D(point2D2.X, point2D.Y, 0.0);
			_vertices[num2++] = new Point3D(point2D2.X, point2D2.Y, 0.0);
			_vertices[num2++] = new Point3D(point2D.X, point2D2.Y, 0.0);
			num -= LineSpaceDistance;
		}
		PostRegen(_vertices);
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973885) + LineSpaceDistance);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973852) + RectWidth);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973837) + RectHeight);
		return stringBuilder.ToString();
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003Dz6_0024vKBtk_003D(data);
		RegenMode = regenType.NotNeeded;
	}

	internal override void _0023_003Dz6_0024vKBtk_003D(CompileParams _0023_003DzELu0Pss_003D)
	{
		string[][] linesTokens = _linesTokens;
		foreach (string[] tokens in linesTokens)
		{
			CompileChars(tokens, _0023_003DzELu0Pss_003D);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
	}

	private bool _0023_003DzaNtM2nfRekbc(List<string> _0023_003Dzkn6DDdPSNent, bool _0023_003DzsRaZzaNNQtTX, string _0023_003DzUsjwj2w_003D, fontStyle _0023_003DzbD7eE_0024CynOmT, double[] _0023_003Dz474kkOleOJyc, RegenParams _0023_003DzELu0Pss_003D, out List<string> _0023_003Dz5WvOfowW3utZ, out string[][] _0023_003DzZXpMhOrFju40)
	{
		_0023_003Dz5WvOfowW3utZ = new List<string>();
		_0023_003DzZXpMhOrFju40 = null;
		List<double> list = new List<double>();
		bool _0023_003DzE3ZVbQdHkHzU = _0023_003DzELu0Pss_003D.workspaceInternal?.IsRightToLeft() ?? false;
		bool flag = false;
		for (int i = 0; i < _0023_003Dzkn6DDdPSNent.Count; i++)
		{
			string text = _0023_003Dzkn6DDdPSNent[i];
			double _0023_003Dz6tVBpdk_003D = _0023_003Dz474kkOleOJyc[i];
			list.Add(myWidthFactors[i]);
			while (_0023_003Dz6tVBpdk_003D > RectWidth)
			{
				flag = true;
				int num = (int)(RectWidth * (double)text.Length / _0023_003Dz6tVBpdk_003D);
				if (num >= text.Length)
				{
					break;
				}
				if (Wrap)
				{
					bool flag2 = false;
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						if (text[num2] == ' ')
						{
							flag2 = true;
							_0023_003Dz5WvOfowW3utZ.Add(text.Substring(0, num2));
							list.Add(myWidthFactors[i]);
							int j;
							for (j = num2; j < text.Length && text[j] == ' '; j++)
							{
							}
							text = text.Substring(j);
							break;
						}
					}
					if (!flag2)
					{
						for (int k = num; k < text.Length; k++)
						{
							if (text[k] == ' ')
							{
								flag2 = true;
								_0023_003Dz5WvOfowW3utZ.Add(text.Substring(0, k));
								list.Add(myWidthFactors[i]);
								int l;
								for (l = k; l < text.Length && text[l] == ' '; l++)
								{
								}
								text = text.Substring(l);
								break;
							}
						}
						if (!flag2)
						{
							break;
						}
					}
				}
				else
				{
					text = text.Substring(0, num);
				}
				string[] _0023_003Dz54nHjlA_003D = Text._0023_003Dz4HSxdHE_003D(text, _0023_003DzsRaZzaNNQtTX, _0023_003DzE3ZVbQdHkHzU);
				_0023_003DziivS_0024a924P2e(_0023_003Dz54nHjlA_003D, _0023_003DzUsjwj2w_003D, _0023_003DzbD7eE_0024CynOmT, _0023_003DzELu0Pss_003D.FontDefs, myWidthFactors[i], out _0023_003Dz6tVBpdk_003D, out var _, out var _, out var _);
			}
			_0023_003Dz5WvOfowW3utZ.Add(text);
		}
		myWidthFactors = list.ToArray();
		if (flag)
		{
			_0023_003DzZXpMhOrFju40 = new string[_0023_003Dz5WvOfowW3utZ.Count][];
			for (int m = 0; m < _0023_003Dz5WvOfowW3utZ.Count; m++)
			{
				_0023_003DzZXpMhOrFju40[m] = Text._0023_003Dz4HSxdHE_003D(_0023_003Dz5WvOfowW3utZ[m], _0023_003DzsRaZzaNNQtTX, _0023_003DzE3ZVbQdHkHzU);
			}
		}
		return flag;
	}

	protected new Transformation ScaleTransform(int lineIndex)
	{
		return new Scaling(_0023_003DzcAXPBc8_003D() * myWidthFactors[lineIndex], _0023_003DzcAXPBc8_003D());
	}

	private Transformation _0023_003DzK48Px00_003D(int _0023_003DzAzgurAo_003D)
	{
		return base.PlaneTransform * _0023_003Dzt9NAowayKmSWDXKThA_003D_003D(_0023_003DzAzgurAo_003D) * ScaleTransform(_0023_003DzAzgurAo_003D);
	}

	private Transformation _0023_003Dzt9NAowayKmSWDXKThA_003D_003D(int _0023_003Dz437_00244ak_003D)
	{
		return new Scaling((!Backward) ? 1 : (-1), (!UpsideDown) ? 1 : (-1)) * _0023_003Dz_IMYOouqHzC6(_0023_003Dz437_00244ak_003D);
	}

	private Transformation _0023_003Dz_IMYOouqHzC6(int _0023_003Dz437_00244ak_003D)
	{
		return new Translation(positions[_0023_003Dz437_00244ak_003D].X, positions[_0023_003Dz437_00244ak_003D].Y);
	}

	public override void TransformBy(Transformation xform)
	{
		if (xform.HasScaling)
		{
			double scaleFactor = xform.ScaleFactorX;
			if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
			{
				LineSpaceDistance *= scaleFactor;
				RectWidth *= scaleFactor;
				RectHeight *= scaleFactor;
			}
		}
		base.TransformBy(xform);
	}

	protected override void DrawText(DrawParams data)
	{
		PreDraw(data);
		Point3D origin = base.Plane.Origin;
		Vector3D vector3D = Vector3D.Subtract(base.Plane.PointAt(0.0, 0.0 - LineSpaceDistance), origin);
		RenderContextBase renderContext = data.RenderContext;
		for (int i = 0; i < textLines.Count; i++)
		{
			renderContext.PushModelView();
			renderContext.MultMatrixModelView(new Translation(vector3D.X * (double)i, vector3D.Y * (double)i, vector3D.Z * (double)i) * _0023_003DzK48Px00_003D(i));
			DrawChars(_linesTokens[i], data);
			renderContext.PopModelView();
		}
		PostDraw(data);
	}

	protected override void DrawSimplified(RenderContextBase context)
	{
		int num = 0;
		while (num < _vertices.Length)
		{
			context.DrawLineLoop(new Point3D[4]
			{
				_vertices[num++],
				_vertices[num++],
				_vertices[num++],
				_vertices[num++]
			});
		}
	}

	public override object Clone()
	{
		return new MultilineText(this);
	}

	private void _0023_003Dzvp3WRyUikWoH(Point3D _0023_003Dzz710fPUHVlV2)
	{
		Point2D point2D = base.Plane.Project(_0023_003Dzz710fPUHVlV2);
		switch (alignment)
		{
		case alignmentType.BottomLeft:
		case alignmentType.BaselineLeft:
			InsertionPoint = _0023_003Dzz710fPUHVlV2;
			break;
		case alignmentType.BottomCenter:
		case alignmentType.BaselineCenter:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth / 2.0, 0.0));
			break;
		case alignmentType.BottomRight:
		case alignmentType.BaselineRight:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth, 0.0));
			break;
		case alignmentType.MiddleLeft:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(0.0, RectHeight / 2.0));
			break;
		case alignmentType.MiddleCenter:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth / 2.0, RectHeight / 2.0));
			break;
		case alignmentType.MiddleRight:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth, RectHeight / 2.0));
			break;
		case alignmentType.TopLeft:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(0.0, RectHeight));
			break;
		case alignmentType.TopCenter:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth / 2.0, RectHeight));
			break;
		case alignmentType.TopRight:
			InsertionPoint = base.Plane.PointAt(point2D + new Point2D(RectWidth, RectHeight));
			break;
		default:
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973475));
		}
	}

	internal Point3D _0023_003DzFR_UvI_P_8hJ()
	{
		switch (alignment)
		{
		case alignmentType.BottomLeft:
		case alignmentType.BaselineLeft:
			return InsertionPoint;
		case alignmentType.MiddleLeft:
			return base.Plane.PointAt(new Point2D(0.0, (0.0 - RectHeight) / 2.0));
		case alignmentType.TopLeft:
			return base.Plane.PointAt(new Point2D(0.0, 0.0 - RectHeight));
		case alignmentType.BottomCenter:
		case alignmentType.BaselineCenter:
			return base.Plane.PointAt(new Point2D((0.0 - RectWidth) / 2.0, 0.0));
		case alignmentType.MiddleCenter:
			return base.Plane.PointAt(new Point2D((0.0 - RectWidth) / 2.0, (0.0 - RectHeight) / 2.0));
		case alignmentType.TopCenter:
			return base.Plane.PointAt(new Point2D((0.0 - RectWidth) / 2.0, 0.0 - RectHeight));
		case alignmentType.BottomRight:
		case alignmentType.BaselineRight:
			return base.Plane.PointAt(new Point2D(0.0 - RectWidth, 0.0));
		case alignmentType.MiddleRight:
			return base.Plane.PointAt(new Point2D(0.0 - RectWidth, (0.0 - RectHeight) / 2.0));
		case alignmentType.TopRight:
			return base.Plane.PointAt(new Point2D(0.0 - RectWidth, 0.0 - RectHeight));
		default:
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973475));
		}
	}

	protected override void GetTextOutlines(string myText, double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation transform, double fontScale, RenderContextBase renderContext, bool isRightToLeft, out ICurve[] ptOuters, out ICurve[][] ptInners)
	{
		List<ICurve> list = new List<ICurve>();
		List<ICurve[]> list2 = new List<ICurve[]>();
		bool flag = transform != null && !transform.IsIdentity();
		Vector3D vector3D = (0.0 - LineSpaceDistance) * base.Plane.AxisY;
		for (int i = 0; i < textLines.Count; i++)
		{
			Transformation transformation = new Translation(vector3D.X * (double)i, vector3D.Y * (double)i, vector3D.Z * (double)i) * _0023_003DzK48Px00_003D(i);
			if (flag)
			{
				transformation = transform * transformation;
			}
			GetTextOutlinesInternal(textLines[i], deviation, computeInners, toCurve, isShx, fsd, transformation, fontScale, renderContext, isRightToLeft, out var outers, out var inners);
			list.AddRange(outers);
			if (inners != null)
			{
				list2.AddRange(inners);
			}
		}
		ptOuters = list.ToArray();
		ptInners = list2.ToArray();
	}

	protected internal override Point3D[] GetTextRectangleVertices()
	{
		Point3D[] array = new Point3D[textLines.Count * 4];
		int num = 0;
		for (int i = 0; i < textLines.Count; i++)
		{
			Point3D point3D = new Point3D(positions[i].X, positions[i].Y - LineSpaceDistance * (double)i);
			Point3D point3D2 = new Point3D(point3D.X + exactWidths[i], point3D.Y + _0023_003DzcAXPBc8_003D());
			array[num++] = point3D;
			array[num++] = new Point3D(point3D2.X, point3D.Y);
			array[num++] = point3D2;
			array[num++] = new Point3D(point3D.X, point3D2.Y);
		}
		PostRegen(array);
		return array;
	}

	public Entity[] Explode()
	{
		if (Vertices == null)
		{
			_0023_003DzAJ2wgzdeSgYt(new RegenParams(0.0));
		}
		Point3D[] textRectangleVertices = GetTextRectangleVertices();
		int num = textRectangleVertices.Length / 4;
		Entity[] array = new Entity[num];
		for (int i = 0; i < num; i++)
		{
			Text text = new Text(base.Plane, textRectangleVertices[i * 4], textLines[i], base.Height, alignmentType.BaselineLeft, base.StyleName)
			{
				WidthFactor = WidthFactor,
				Backward = Backward,
				UpsideDown = UpsideDown
			};
			Entity.PropagateAttributes(this, text, force: true);
			array[i] = text;
		}
		return array;
	}

	internal override Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		return _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, null);
	}

	internal override Point3D[][] _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, Transformation _0023_003Dzptomndc_003D)
	{
		bool flag = _0023_003Dzptomndc_003D != null && !_0023_003Dzptomndc_003D.IsIdentity();
		Vector3D vector3D = (0.0 - LineSpaceDistance) * base.Plane.AxisY;
		List<Point3D[]> list = new List<Point3D[]>();
		for (int i = 0; i < textLines.Count; i++)
		{
			Transformation transformation = new Translation(vector3D.X * (double)i, vector3D.Y * (double)i, vector3D.Z * (double)i) * _0023_003DzK48Px00_003D(i);
			if (flag)
			{
				transformation = _0023_003Dzptomndc_003D * transformation;
			}
			Point3D[][] trianglesInternal = GetTrianglesInternal(_linesTokens[i], _0023_003DzFM3KC0w_003D, transformation, _0023_003DzWArtMuor9L71fptjtg_003D_003D);
			list.AddRange(trianglesInternal);
		}
		return list.ToArray();
	}

	public override Mesh[] ConvertToMesh(IWorkspace workspace, bool skipNormals = false)
	{
		if (RegenMode == regenType.RegenAndCompile || textLines == null)
		{
			RegenParams data = new RegenParams(0.0, workspace);
			Regen(data);
		}
		List<Mesh> list = new List<Mesh>();
		TextStyle textStyle = workspace.TextStyles[base.StyleName];
		if (textStyle.IsSHX())
		{
			return null;
		}
		FontStyleData styleData = workspace.Document.fontDefs[textStyle.FontFamilyName][textStyle.Style];
		Vector3D vector3D = (0.0 - LineSpaceDistance) * base.Plane.AxisY;
		for (int i = 0; i < textLines.Count; i++)
		{
			Transformation transf = new Translation(vector3D.X * (double)i, vector3D.Y * (double)i, vector3D.Z * (double)i) * _0023_003DzK48Px00_003D(i);
			string[] array = _linesTokens[i];
			foreach (string c in array)
			{
				Text.AddCharMesh(styleData, c, ref transf, list, skipNormals);
			}
		}
		return list.ToArray();
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		Transformation planeTransform = base.PlaneTransform;
		_0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D obj = new _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D(text, exactWidth, _0023_003DzcAXPBc8_003D(), planeTransform.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color);
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}
}
