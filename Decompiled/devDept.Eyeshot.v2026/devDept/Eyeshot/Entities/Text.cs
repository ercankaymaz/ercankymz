using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Text : PlanarEntity, IText
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<char, bool> _0023_003Dz_flk8Dd8dzuAveOTIg_003D_003D;

		internal bool _0023_003Dz7DW9mxTkX5_lWLfPxaOx0ANB5Q1l(char _0023_003Dzt_m8zV0_003D)
		{
			if ((uint)_0023_003Dzt_m8zV0_003D >= 19968u)
			{
				return (uint)_0023_003Dzt_m8zV0_003D <= 195103u;
			}
			return false;
		}
	}

	private sealed class _0023_003DzywvMlRNjhDHtYg9OVw_003D_003D
	{
		private double[] _0023_003Dzej_M7byj9SrT;

		public _0023_003DzywvMlRNjhDHtYg9OVw_003D_003D()
		{
			_0023_003Dzej_M7byj9SrT = new double[2] { -1.0, -1.0 };
		}

		public _0023_003DzywvMlRNjhDHtYg9OVw_003D_003D(fontStyle _0023_003Dz_0024wQZnFQ_003D, double _0023_003DzAZbTv8c_003D, double _0023_003DzirIS_0024oE_003D)
			: this()
		{
			_0023_003Dzb8Tgipw_003D(_0023_003Dz_0024wQZnFQ_003D, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D);
		}

		public void _0023_003DzlMQGOkw_003D(fontStyle _0023_003Dz_0024wQZnFQ_003D, out double _0023_003DzAZbTv8c_003D, out double _0023_003DzirIS_0024oE_003D)
		{
			_0023_003DzAZbTv8c_003D = _0023_003Dzej_M7byj9SrT[0];
			_0023_003DzirIS_0024oE_003D = _0023_003Dzej_M7byj9SrT[1];
		}

		public void _0023_003Dzb8Tgipw_003D(fontStyle _0023_003Dz_0024wQZnFQ_003D, double _0023_003DzAZbTv8c_003D, double _0023_003DzirIS_0024oE_003D)
		{
			_0023_003Dzej_M7byj9SrT[0] = _0023_003DzAZbTv8c_003D;
			_0023_003Dzej_M7byj9SrT[1] = _0023_003DzirIS_0024oE_003D;
		}

		public bool _0023_003DzlGXalEw_003D(fontStyle _0023_003Dz_0024wQZnFQ_003D)
		{
			if (_0023_003Dzej_M7byj9SrT[0] != -1.0)
			{
				return _0023_003Dzej_M7byj9SrT[1] != -1.0;
			}
			return false;
		}
	}

	public delegate void GetTextOutlinesDelegate(double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation transform, double fontScale, RenderContextBase renderContext, bool isRightToLeft, out ICurve[] ptOuters, out ICurve[][] ptInners);

	public enum alignmentType : byte
	{
		BottomLeft,
		BottomCenter,
		BottomRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		TopLeft,
		TopCenter,
		TopRight,
		BaselineLeft,
		BaselineCenter,
		BaselineRight
	}

	private string _styleName = TextStyle._0023_003Dz4zXHKUEM3ZZu;

	internal alignmentType alignment = _0023_003DzzzJE33Q87WgH();

	internal string text;

	private protected string[] _textTokens;

	internal double height;

	internal double myWidthFactor = 1.0;

	private double _widthFactor = -1.0;

	private bool _simplify = true;

	private bool _billboard;

	internal double exactWidth;

	internal double exactDescend;

	internal FontStyleData trueTypeCharData;

	[CompilerGenerated]
	private Transformation _003CTranslationTransform_003Ek__BackingField = Transformation.CreateIdentity();

	public const int DefaultFontHeight = 2048;

	public string StyleName
	{
		get
		{
			return _styleName;
		}
		set
		{
			if (value != _styleName)
			{
				_styleName = value;
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	public virtual bool Backward { get; set; }

	public virtual bool UpsideDown { get; set; }

	public virtual string TextString
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Height
	{
		get
		{
			return height;
		}
		set
		{
			height = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public virtual double WidthFactor
	{
		get
		{
			return _widthFactor;
		}
		set
		{
			_widthFactor = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public virtual alignmentType Alignment
	{
		get
		{
			return alignment;
		}
		set
		{
			alignment = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public virtual Point3D InsertionPoint
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

	public bool Simplify
	{
		get
		{
			return _simplify;
		}
		set
		{
			_simplify = value;
		}
	}

	public bool Billboard
	{
		get
		{
			return _billboard;
		}
		set
		{
			_billboard = value;
		}
	}

	protected Transformation Transform => PlaneTransform * UnscaledTransform * ScaleTransform;

	protected Transformation UnscaledTransform => new Scaling((!Backward) ? 1 : (-1), (!UpsideDown) ? 1 : (-1)) * _0023_003DzVydljDgqtgNs();

	protected Transformation PlaneTransform => new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);

	protected double ScaleBackward => (!Backward) ? 1 : (-1);

	protected double ScaleUpsideDown => (!UpsideDown) ? 1 : (-1);

	protected double ScaleX => _0023_003DzcAXPBc8_003D() * myWidthFactor;

	protected double ScaleY => _0023_003DzcAXPBc8_003D();

	protected Transformation ScaleTransform => new Scaling(_0023_003DzcAXPBc8_003D() * myWidthFactor, _0023_003DzcAXPBc8_003D());

	protected Transformation TransformNoPlane => _0023_003DzVydljDgqtgNs() * ScaleTransform;

	public Text(double x, double y, string textString, double height)
		: this(x, y, 0.0, textString, height)
	{
	}

	public Text(double x, double y, double z, string textString, double height)
		: this(x, y, z, textString, height, _0023_003DzzzJE33Q87WgH())
	{
	}

	public Text(double x, double y, double z, string textString, double height, alignmentType alignment)
		: this(x, y, z, textString, height, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public Text(double x, double y, double z, string textString, double height, alignmentType alignment, string styleName)
		: this(x, y, z, textString, height, alignment, styleName, simplify: true)
	{
	}

	public Text(double x, double y, double z, string textString, double height, alignmentType alignment, string styleName, bool simplify)
	{
		_0023_003DzDBrp9S8_003D(new Point3D(x, y, z), textString, height, alignment, styleName, simplify);
	}

	public Text(Point3D insPoint, string textString, double height)
		: this(insPoint, textString, height, _0023_003DzzzJE33Q87WgH())
	{
	}

	public Text(Point3D insPoint, string textString, double height, alignmentType alignment)
		: this(insPoint, textString, height, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public Text(Point3D insPoint, string textString, double height, alignmentType alignment, string styleName)
		: this(insPoint, textString, height, alignment, styleName, simplify: true)
	{
	}

	public Text(Point3D insPoint, string textString, double height, alignmentType alignment, string styleName, bool simplify)
	{
		_0023_003DzDBrp9S8_003D(insPoint, textString, height, alignment, styleName, simplify);
	}

	internal Text()
	{
	}

	public Text(Plane textPlane, string textString, double height)
		: this(textPlane, textString, height, _0023_003DzzzJE33Q87WgH())
	{
	}

	public Text(Plane textPlane, string textString, double height, alignmentType alignment)
		: this(textPlane, textString, height, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public Text(Plane textPlane, string textString, double height, alignmentType alignment, string styleName)
		: this(textPlane, textString, height, alignment, styleName, simplify: true)
	{
	}

	public Text(Plane textPlane, string textString, double height, alignmentType alignment, string styleName, bool simplify)
		: base((Plane)textPlane.Clone())
	{
		_0023_003DzDBrp9S8_003D(textPlane.Origin, textString, height, alignment, styleName, simplify);
	}

	internal Text(Plane _0023_003DzzFdA9v85NXe7)
		: base((Plane)_0023_003DzzFdA9v85NXe7.Clone())
	{
	}

	public Text(Plane textPlane, Point3D insPoint, string textString, double height)
		: this(textPlane, insPoint, textString, height, _0023_003DzzzJE33Q87WgH())
	{
	}

	public Text(Plane textPlane, Point3D insPoint, string textString, double height, alignmentType alignment)
		: this(textPlane, insPoint, textString, height, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public Text(Plane textPlane, Point3D insPoint, string textString, double height, alignmentType alignment, string styleName)
		: this(textPlane, insPoint, textString, height, alignment, styleName, simplify: true)
	{
	}

	public Text(Plane textPlane, Point3D insPoint, string textString, double height, alignmentType alignment, string styleName, bool simplify)
		: base((Plane)textPlane.Clone())
	{
		_0023_003DzDBrp9S8_003D(insPoint, textString, height, alignment, styleName, simplify);
	}

	public Text(Plane sketchPlane, Point2D insPoint, string textString, double height)
		: this(sketchPlane, insPoint, textString, height, _0023_003DzzzJE33Q87WgH())
	{
	}

	public Text(Plane sketchPlane, Point2D insPoint, string textString, double height, alignmentType alignment)
		: this(sketchPlane, insPoint, textString, height, alignment, TextStyle._0023_003Dz4zXHKUEM3ZZu)
	{
	}

	public Text(Plane sketchPlane, Point2D insPoint, string textString, double height, alignmentType alignment, string styleName)
		: this(sketchPlane, insPoint, textString, height, alignment, styleName, simplify: true)
	{
	}

	public Text(Plane sketchPlane, Point2D insPoint, string textString, double height, alignmentType alignment, string styleName, bool simplify)
		: base((Plane)sketchPlane.Clone())
	{
		_0023_003DzDBrp9S8_003D(sketchPlane.PointAt(insPoint), textString, height, alignment, styleName, simplify);
	}

	protected Text(Plane textPlane, Point3D insPoint, double height, alignmentType alignment)
		: this(textPlane, insPoint, string.Empty, height, alignment)
	{
	}

	protected Text(Text another)
		: base(another)
	{
		_0023_003DzjkGENH0_003D(another);
	}

	protected internal Text(TextSurrogate surrogate)
		: this(surrogate.Plane, surrogate.TextString, surrogate.Height)
	{
	}

	protected Text(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		height = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246));
		_widthFactor = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981478));
		text = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981463));
		alignment = (alignmentType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981444), typeof(alignmentType));
		Simplify = (bool)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981428), typeof(bool));
		StyleName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981409), typeof(string));
		Backward = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911644));
		UpsideDown = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981393));
		Billboard = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981380));
	}

	public override Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981620));
	}

	public override Surface ExtrudeAsSurface(double amount)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981620));
	}

	internal static alignmentType _0023_003DzzzJE33Q87WgH()
	{
		return alignmentType.BaselineLeft;
	}

	private void _0023_003DzDBrp9S8_003D(Point3D _0023_003DzJPR4E5ZNOD6H, string _0023_003DzlUfsUzo_003D, double _0023_003DzvAxV_0024Ic_003D, alignmentType _0023_003Dz1pzzCsQ_003D, string _0023_003DzMc5f1FY_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		base.Plane.Origin = _0023_003DzJPR4E5ZNOD6H;
		text = _0023_003DzlUfsUzo_003D;
		height = _0023_003DzvAxV_0024Ic_003D;
		Alignment = _0023_003Dz1pzzCsQ_003D;
		StyleName = _0023_003DzMc5f1FY_003D;
		Simplify = _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D;
	}

	private void _0023_003DzjkGENH0_003D(Text _0023_003DzySgeilxprQOK)
	{
		text = _0023_003DzySgeilxprQOK.text;
		height = _0023_003DzySgeilxprQOK.height;
		alignment = _0023_003DzySgeilxprQOK.alignment;
		Simplify = _0023_003DzySgeilxprQOK.Simplify;
		StyleName = _0023_003DzySgeilxprQOK.StyleName;
		_widthFactor = _0023_003DzySgeilxprQOK._widthFactor;
		UpsideDown = _0023_003DzySgeilxprQOK.UpsideDown;
		Backward = _0023_003DzySgeilxprQOK.Backward;
		Billboard = _0023_003DzySgeilxprQOK.Billboard;
	}

	protected override void Update(PlanarEntity another)
	{
		base.Update(another);
		_0023_003DzjkGENH0_003D((Text)another);
	}

	public override object Clone()
	{
		return new Text(this);
	}

	public override object CloneWithTessellation()
	{
		return Clone();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, (LayerKeyedCollection)null, materials, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981596) + text);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973989) + height);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981584) + _widthFactor);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981542) + alignment);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981527) + UpsideDown);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981518) + Backward);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981248) + StyleName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981204) + Simplify);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981190) + Billboard);
		return stringBuilder.ToString();
	}

	internal override bool IsValidForDraw()
	{
		return RegenMode == regenType.NotNeeded;
	}

	internal virtual double _0023_003DzcAXPBc8_003D()
	{
		return height;
	}

	internal void _0023_003Dz6_tAcSMiWiQ_0024635CMcOdIWk_003D(DrawParams _0023_003DzELu0Pss_003D, out Transformation _0023_003Dzk3JS5glTSWfF, out double _0023_003DzAZbTv8c_003D, out double _0023_003DzirIS_0024oE_003D, out double _0023_003DzmA8WJu0_003D)
	{
		_0023_003Dzk3JS5glTSWfF = ((_0023_003DzELu0Pss_003D.Transformation != null) ? (_0023_003DzELu0Pss_003D.Transformation.Clone() as Transformation) : new Identity());
		_0023_003DzAZbTv8c_003D = 1.0;
		_0023_003DzirIS_0024oE_003D = 1.0;
		_0023_003DzmA8WJu0_003D = 1.0;
		if (_0023_003Dzk3JS5glTSWfF.HasScaling)
		{
			_0023_003DzAZbTv8c_003D = _0023_003Dzk3JS5glTSWfF.ScaleFactorX;
			_0023_003DzirIS_0024oE_003D = _0023_003Dzk3JS5glTSWfF.ScaleFactorY;
			_0023_003DzmA8WJu0_003D = _0023_003Dzk3JS5glTSWfF.ScaleFactorZ;
		}
		_0023_003Dzk3JS5glTSWfF.Matrix[0, 3] = 0.0;
		_0023_003Dzk3JS5glTSWfF.Matrix[1, 3] = 0.0;
		_0023_003Dzk3JS5glTSWfF.Matrix[2, 3] = 0.0;
		_0023_003Dzk3JS5glTSWfF.Invert();
	}

	protected internal virtual Transformation GetBillboardTransformation(DrawParams data, out double scaleX, out double scaleY, out double scaleZ)
	{
		data.Viewport.Camera.GetFrame(out var _, out var camX, out var camY, out var _);
		Plane plane = (Plane)base.Plane.Clone();
		plane.Origin = Point3D.Origin;
		_0023_003Dz6_tAcSMiWiQ_0024635CMcOdIWk_003D(data, out var _0023_003Dzk3JS5glTSWfF, out scaleX, out scaleY, out scaleZ);
		return _0023_003Dzk3JS5glTSWfF * new Align3D(plane, new Plane(Point3D.Origin, camX, camY));
	}

	protected internal override void Draw(DrawParams data)
	{
		PreDraw(data);
		if (Billboard)
		{
			data.RenderContext.PushModelView();
			Point3D point3D = Transform * new Point3D(exactWidth / (2.0 * _0023_003DzcAXPBc8_003D()), 0.5, 0.0);
			data.RenderContext.TranslateMatrixModelView(point3D.X, point3D.Y, point3D.Z);
			data.RenderContext.MultMatrixModelView(GetBillboardTransformation(data, out var scaleX, out var scaleY, out var scaleZ).MatrixAsVectorByColumn);
			data.RenderContext.ScaleMatrixModelView(scaleX, scaleY, scaleZ);
			data.RenderContext.TranslateMatrixModelView(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
		}
		if (!ShouldSimplify(data))
		{
			DrawText(data);
		}
		else
		{
			DrawSimplified(data.RenderContext);
		}
		if (Billboard)
		{
			data.RenderContext.PopModelView();
		}
		PostDraw(data);
	}

	protected bool ShouldSimplifyWithFastPointCloud(DrawParams data)
	{
		if (data.ScreenToWorld > 0f)
		{
			return _0023_003DzcAXPBc8_003D() < (double)data._0023_003DzWyuTTljMwrxwShKMYA_003D_003D();
		}
		return false;
	}

	protected bool ShouldSimplify(DrawParams data)
	{
		return Simplify && (!(data.ScreenToWorld > 0f) || !(_0023_003DzcAXPBc8_003D() > 0.5 * (double)data.ScreenToWorld4Times));
	}

	protected virtual void DrawSimplified(RenderContextBase context)
	{
		context.DrawLineLoop(_vertices);
	}

	protected virtual void DrawText(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transform);
		DrawChars(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected virtual void DrawChars(DrawParams data)
	{
		DrawChars(_textTokens, data);
	}

	private bool _0023_003Dzr_bLbeN2yAu3Q1g_CQ_003D_003D(string _0023_003DzwyYng5o_003D)
	{
		return _0023_003DzwyYng5o_003D.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7DW9mxTkX5_lWLfPxaOx0ANB5Q1l);
	}

	protected void DrawChars(string[] tokens, DrawParams data)
	{
		if (tokens != null && tokens.Length == 0)
		{
			return;
		}
		TextStyle textStyle = data.TextStyles[StyleName];
		bool flag = textStyle.IsSHX();
		bool flag2 = ShouldSimplifyWithFastPointCloud(data);
		float currentPointSize = data.RenderContext.CurrentPointSize;
		float currentLineWidth = data.RenderContext.CurrentLineWidth;
		if (flag2)
		{
			if (flag)
			{
				data.RenderContext.SetLineSize(0.5f, setShader: false);
				flag2 = false;
			}
			else
			{
				data.RenderContext.SetPointSize(0.5f, setShader: false);
			}
		}
		FontStyleData fontStyleData = data.FontDefs[textStyle.FontFamilyName][textStyle.Style];
		foreach (string key in tokens)
		{
			fontStyleData.TryGetValue(key, out var value);
			value._0023_003DzwuJjRo0_003D(data, flag, flag2);
		}
		if (flag)
		{
			data.RenderContext.SetLineSize(currentLineWidth, setShader: false);
		}
		if (flag2)
		{
			data.RenderContext.SetPointSize(currentPointSize, setShader: false);
		}
	}

	protected void PostDraw(DrawParams data)
	{
		if (!IsSingleLineFont(data))
		{
			data.RenderContext.PopRasterizerState();
		}
	}

	protected void PreDraw(DrawParams data)
	{
		if (IsSingleLineFont(data))
		{
			data.RenderContext.EndDrawBufferedLines();
			return;
		}
		data.RenderContext.PushRasterizerState();
		data.RenderContext.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
	}

	protected bool IsSingleLineFont(DrawParams data)
	{
		if (!data.TextStyles[StyleName].IsSHX())
		{
			return ShouldSimplifyWithFastPointCloud(data);
		}
		return true;
	}

	protected bool CheckRegenParams(RegenParams data)
	{
		if (data.SkipTexts)
		{
			return false;
		}
		if (data.Workspace == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970600));
		}
		if (data.Workspace.RenderContext == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981175) + GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981156));
		}
		return true;
	}

	public override void Regen(RegenParams data)
	{
		if (CheckRegenParams(data))
		{
			myWidthFactor = _widthFactor;
			PrepareText(data, ref myWidthFactor, out exactWidth, out exactDescend, out var boxMin, out var boxMax);
			double offsetX = ((data.TextStyles[StyleName].IsSHX() && boxMin != null) ? boxMin.X : 0.0);
			Point2D point2D = ComputePosition(exactWidth, _0023_003DzcAXPBc8_003D(), exactDescend, offsetX, Alignment);
			_0023_003DzVydljDgqtgNs().Translation(point2D.X, point2D.Y);
			_vertices = new Point3D[4];
			if (boxMin == null)
			{
				_vertices[0] = new Point3D(0.0, 0.0, 0.0);
				_vertices[1] = new Point3D(0.0, 0.0, 0.0);
				_vertices[2] = new Point3D(0.0, 0.0, 0.0);
				_vertices[3] = new Point3D(0.0, 0.0, 0.0);
			}
			else
			{
				Point2D point2D2 = new Point2D(boxMin.X, boxMin.Y);
				Point2D point2D3 = new Point2D(boxMax.X, boxMax.Y);
				_vertices[0] = new Point3D(point2D2.X, point2D2.Y, 0.0);
				_vertices[1] = new Point3D(point2D3.X, point2D2.Y, 0.0);
				_vertices[2] = new Point3D(point2D3.X, point2D3.Y, 0.0);
				_vertices[3] = new Point3D(point2D2.X, point2D3.Y, 0.0);
			}
			PostRegen(_vertices);
			UpdateBoundingBox(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	public override void Compile(CompileParams data)
	{
		_0023_003Dz6_0024vKBtk_003D(data);
		base.Compile(data);
	}

	internal virtual void _0023_003Dz6_0024vKBtk_003D(CompileParams _0023_003DzELu0Pss_003D)
	{
		CompileChars(_textTokens, _0023_003DzELu0Pss_003D);
	}

	protected internal void CompileChars(string[] tokens, CompileParams data)
	{
		if (tokens != null && tokens.Length != 0)
		{
			TextStyle textStyle = data.TextStyles[StyleName];
			FontStyleData fontStyleData = data._0023_003DznaQO_0024lT1kfzX()[textStyle.FontFamilyName][textStyle.Style];
			foreach (string key in tokens)
			{
				fontStyleData[key]._0023_003DzmHTSerA_003D(data);
			}
		}
	}

	protected void PostRegen(IList<Point3D> myVertices)
	{
		Transformation transformation = PlaneTransform * UnscaledTransform;
		for (int i = 0; i < myVertices.Count; i++)
		{
			myVertices[i] = transformation * myVertices[i];
		}
	}

	protected static Point2D ComputePosition(double width, double height, double descend, double offsetX, alignmentType alignment)
	{
		return alignment switch
		{
			alignmentType.BottomLeft => new Point2D(0.0, descend), 
			alignmentType.BottomCenter => new Point2D(0.0 - (offsetX + width / 2.0), descend), 
			alignmentType.BottomRight => new Point2D(0.0 - (offsetX + width), descend), 
			alignmentType.BaselineLeft => new Point2D(0.0, 0.0), 
			alignmentType.BaselineCenter => new Point2D(0.0 - (offsetX + width / 2.0), 0.0), 
			alignmentType.BaselineRight => new Point2D(0.0 - (offsetX + width), 0.0), 
			alignmentType.MiddleLeft => new Point2D(0.0, (0.0 - height) / 2.0), 
			alignmentType.MiddleCenter => new Point2D(0.0 - (offsetX + width / 2.0), (0.0 - height) / 2.0), 
			alignmentType.MiddleRight => new Point2D(0.0 - (offsetX + width), (0.0 - height) / 2.0), 
			alignmentType.TopLeft => new Point2D(0.0, 0.0 - height), 
			alignmentType.TopCenter => new Point2D(0.0 - (offsetX + width / 2.0), 0.0 - height), 
			alignmentType.TopRight => new Point2D(0.0 - (offsetX + width), 0.0 - height), 
			_ => throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973475)), 
		};
	}

	public override void Dispose()
	{
		base.Dispose();
		RegenMode = regenType.RegenAndCompile;
	}

	public override void Regen(double deviation)
	{
		throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981366));
	}

	protected internal virtual void PrepareText(RegenParams data, ref double widthFactor, out double width, out double descend, out Point3D boxMin, out Point3D boxMax)
	{
		_0023_003DzhnnXav8_003D(text, data, ref widthFactor, out width, out descend, out boxMin, out boxMax, out _textTokens);
	}

	internal void _0023_003DzhnnXav8_003D(string _0023_003Dz4FulV1A_003D, RegenParams _0023_003DzELu0Pss_003D, ref double _0023_003DzwzMn4TDvq4kF, out double _0023_003Dz6tVBpdk_003D, out double _0023_003DzzZ7ER_0024M_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC, out string[] _0023_003Dz54nHjlA_003D)
	{
		if (_0023_003DzELu0Pss_003D.Workspace != null)
		{
			TextStyle textStyle = _0023_003DzELu0Pss_003D.TextStyles[StyleName];
			if (_0023_003DzwzMn4TDvq4kF == -1.0)
			{
				_0023_003DzwzMn4TDvq4kF = textStyle.WidthFactor;
			}
			bool _0023_003DzE3ZVbQdHkHzU = _0023_003DzELu0Pss_003D.workspaceInternal.IsRightToLeft();
			_0023_003DzkDbXKHRUFxl9(_0023_003Dz4FulV1A_003D, _0023_003DzELu0Pss_003D.Workspace.RenderContext, _0023_003DzELu0Pss_003D.TextStyles[StyleName], _0023_003DzELu0Pss_003D.FontDefs, _0023_003DzE3ZVbQdHkHzU, out _0023_003Dz54nHjlA_003D);
			_0023_003DziivS_0024a924P2e(_0023_003Dz54nHjlA_003D, textStyle.FontFamilyName, textStyle.Style, _0023_003DzELu0Pss_003D.FontDefs, _0023_003DzwzMn4TDvq4kF, out _0023_003Dz6tVBpdk_003D, out _0023_003DzzZ7ER_0024M_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
			if (_0023_003Dz6tVBpdk_003D != 0.0 && textStyle.IsSHX())
			{
				_0023_003Dz6tVBpdk_003D -= height * (_0023_003DzwzMn4TDvq4kF / 3.0);
			}
		}
		else
		{
			_0023_003Dz6tVBpdk_003D = 1.0;
			_0023_003DzzZ7ER_0024M_003D = 1.0;
			_0023_003DzDPcjoBJLcqli = new Point3D(0.0, 0.0, 0.0);
			_0023_003Dz_0024N_0024yKptW9BoC = new Point3D(1.0, 1.0, 1.0);
			_0023_003Dz54nHjlA_003D = Array.Empty<string>();
		}
	}

	internal static void _0023_003DzkDbXKHRUFxl9(string _0023_003DzwyYng5o_003D, RenderContextBase _0023_003DzQdnFby4_003D, TextStyle _0023_003Dzgkctzk6d2IIh, FontDataDictionary _0023_003Dzb_EPJPaEdtf0, bool _0023_003DzE3ZVbQdHkHzU, out string[] _0023_003Dz54nHjlA_003D)
	{
		if (string.IsNullOrEmpty(_0023_003DzwyYng5o_003D))
		{
			_0023_003Dz54nHjlA_003D = Array.Empty<string>();
			return;
		}
		bool _0023_003DzsRaZzaNNQtTX = _0023_003Dzgkctzk6d2IIh.IsSHX();
		if (string.IsNullOrEmpty(_0023_003Dzgkctzk6d2IIh.FontFamilyName))
		{
			_0023_003Dzgkctzk6d2IIh.FontFamilyName = _0023_003DzQdnFby4_003D.GetDefaultFontFamilyName();
		}
		string fontFamilyName = _0023_003Dzgkctzk6d2IIh.FontFamilyName;
		_0023_003Dzb_EPJPaEdtf0.TryAdd(fontFamilyName, new FontData());
		FontData fontData = _0023_003Dzb_EPJPaEdtf0[fontFamilyName];
		_0023_003Dz54nHjlA_003D = _0023_003Dz4HSxdHE_003D(_0023_003DzwyYng5o_003D, _0023_003DzsRaZzaNNQtTX, _0023_003DzE3ZVbQdHkHzU);
		for (int i = 0; i < _0023_003Dz54nHjlA_003D.Length; i++)
		{
			fontData._0023_003Dz2QgzNYs_003D(_0023_003Dz54nHjlA_003D[i], _0023_003Dzgkctzk6d2IIh, _0023_003DzQdnFby4_003D, _0023_003DzE3ZVbQdHkHzU);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
	}

	public virtual Mesh[] ConvertToMesh(IWorkspace workspace, bool skipNormals = false)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			RegenParams data = new RegenParams(workspace.Document.GetVisualRefinement().Deviation, workspace.Document);
			Regen(data);
		}
		List<Mesh> list = new List<Mesh>();
		TextStyle textStyle = workspace.TextStyles[StyleName];
		if (textStyle.IsSHX())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981296));
		}
		FontStyleData styleData = workspace.Document.fontDefs[textStyle.FontFamilyName][textStyle.Style];
		Transformation transf = Transform;
		string[] textTokens = _textTokens;
		foreach (string c in textTokens)
		{
			AddCharMesh(styleData, c, ref transf, list, skipNormals);
		}
		return list.ToArray();
	}

	protected static void AddCharMesh(FontStyleData styleData, string c, ref Transformation transf, List<Mesh> meshes, bool skipNormals = false)
	{
		FontStyleCharData fontStyleCharData = styleData[c];
		Entity[] array = fontStyleCharData._0023_003Dz0erUYWA_003D(_0023_003Dz_Gzfs9c_003D: true, skipNormals);
		Mesh mesh = null;
		if (array.Length > 1)
		{
			for (int i = 1; i < array.Length; i++)
			{
				((Mesh)array[0]).MergeWith((Mesh)array[i], weldNow: false);
			}
			mesh = (Mesh)array[0];
		}
		else if (array.Length == 1)
		{
			mesh = (Mesh)array[0];
		}
		if (mesh != null && mesh.Vertices.Length != 0)
		{
			if (skipNormals)
			{
				for (int j = 0; j < mesh.Vertices.Length; j++)
				{
					Point3D point3D = mesh.Vertices[j];
					double[] array2 = transf.ActOnLeftOne(point3D.X, point3D.Y, point3D.Z);
					point3D.X = array2[0];
					point3D.Y = array2[1];
					point3D.Z = array2[2];
				}
			}
			else
			{
				mesh.TransformBy(transf);
			}
			meshes.Add(mesh);
		}
		transf *= (Transformation)new Translation(fontStyleCharData.Width, 0.0);
	}

	public LinearPath[] ConvertToLinearPaths(double deviation, IWorkspace workspace)
	{
		ConvertToInternal(deviation, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: false, _0023_003Dzh6bB8iUYNCW4: false, workspace, out var _0023_003DzsdySxIlQLgFZ, out var _);
		LinearPath[] array = new LinearPath[_0023_003DzsdySxIlQLgFZ.Length];
		for (int i = 0; i < _0023_003DzsdySxIlQLgFZ.Length; i++)
		{
			if (_0023_003DzsdySxIlQLgFZ[i] is LinearPath)
			{
				array[i] = (LinearPath)_0023_003DzsdySxIlQLgFZ[i];
			}
			else
			{
				array[i] = new LinearPath(((Entity)_0023_003DzsdySxIlQLgFZ[i]).Vertices);
			}
		}
		return array;
	}

	public void ConvertToLinearPaths(double deviation, IWorkspace workspace, out LinearPath[] outers, out LinearPath[][] inners)
	{
		ConvertToInternal(deviation, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: true, _0023_003Dzh6bB8iUYNCW4: false, workspace, out var _0023_003DzsdySxIlQLgFZ, out var _0023_003DzWaFlkhfmYCja);
		outers = new LinearPath[_0023_003DzsdySxIlQLgFZ.Length];
		for (int i = 0; i < _0023_003DzsdySxIlQLgFZ.Length; i++)
		{
			if (_0023_003DzsdySxIlQLgFZ[i] is LinearPath)
			{
				outers[i] = (LinearPath)_0023_003DzsdySxIlQLgFZ[i];
			}
			else
			{
				outers[i] = new LinearPath(((Entity)_0023_003DzsdySxIlQLgFZ[i]).Vertices);
			}
		}
		inners = new LinearPath[_0023_003DzWaFlkhfmYCja.Length][];
		int num = 0;
		ICurve[][] array = _0023_003DzWaFlkhfmYCja;
		foreach (IList<ICurve> list in array)
		{
			LinearPath[] array2 = new LinearPath[list.Count];
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k] is LinearPath)
				{
					array2[k] = (LinearPath)list[k];
				}
				else
				{
					outers[k] = new LinearPath(((Entity)_0023_003DzsdySxIlQLgFZ[k]).Vertices);
				}
			}
			inners[num++] = array2;
		}
	}

	public ICurve[] ConvertToCurves(IWorkspace workspace)
	{
		ConvertToInternal(0.0, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: false, _0023_003Dzh6bB8iUYNCW4: true, workspace, out var _0023_003DzsdySxIlQLgFZ, out var _);
		return _0023_003DzsdySxIlQLgFZ;
	}

	public void ConvertToCurves(IWorkspace workspace, out ICurve[] outers, out ICurve[][] inners)
	{
		ConvertToInternal(0.0, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: true, _0023_003Dzh6bB8iUYNCW4: true, workspace, out outers, out inners);
	}

	public Region[] ConvertToRegions(IWorkspace workspace)
	{
		if (workspace.TextStyles[StyleName].IsSHX())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981296));
		}
		ConvertToInternal(0.0, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: true, _0023_003Dzh6bB8iUYNCW4: true, workspace, out var _0023_003DzsdySxIlQLgFZ, out var _0023_003DzWaFlkhfmYCja);
		int num = _0023_003DzsdySxIlQLgFZ.Length;
		Region[] array = new Region[num];
		for (int i = 0; i < num; i++)
		{
			List<ICurve> list = new List<ICurve>(_0023_003DzWaFlkhfmYCja[i].Length + 1);
			list.Add(_0023_003DzsdySxIlQLgFZ[i]);
			list.AddRange(_0023_003DzWaFlkhfmYCja[i]);
			array[i] = new Region(list, base.Plane, sortAndOrient: false);
		}
		return array;
	}

	public Surface[] ConvertToSurfaces(IWorkspace workspace)
	{
		if (workspace.TextStyles[StyleName].IsSHX())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981296));
		}
		Region[] array = ConvertToRegions(workspace);
		Surface[] array2 = new Surface[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].ConvertToSurface();
		}
		return array2;
	}

	internal static bool _0023_003Dza1Qy0j6yPM5UdxIUBg_003D_003D(string _0023_003DzuwH5j5s_003D)
	{
		for (int num = _0023_003DzBZajHpTy5liQ(_0023_003DzuwH5j5s_003D); num != -1; num = _0023_003DzBZajHpTy5liQ(_0023_003DzuwH5j5s_003D))
		{
			_0023_003DzuwH5j5s_003D = _0023_003DzuwH5j5s_003D.Remove(num);
		}
		for (int i = 0; i < _0023_003DzuwH5j5s_003D.Length; i += ((!char.IsSurrogatePair(_0023_003DzuwH5j5s_003D, i)) ? 1 : 2))
		{
			if (_0023_003DzoXoTx6hOgm5cVN8wxg_003D_003D(char.ConvertToUtf32(_0023_003DzuwH5j5s_003D, i)))
			{
				return true;
			}
		}
		return false;
	}

	private static int _0023_003DzBZajHpTy5liQ(string _0023_003DzAhpHhJA_003D)
	{
		for (int i = 0; i < _0023_003DzAhpHhJA_003D.Length; i++)
		{
			int num = _0023_003DzAhpHhJA_003D[i];
			if (num < 55296)
			{
				continue;
			}
			if (num >= 55296 && num <= 56319)
			{
				i++;
				if (i == _0023_003DzAhpHhJA_003D.Length)
				{
					return i - 1;
				}
				int num2 = _0023_003DzAhpHhJA_003D[i];
				if (num2 < 56320 || num2 > 57343)
				{
					return i - 1;
				}
				num = (num - 55296) * 1024 + (num2 - 56320) + 65536;
				if (num > 1114111)
				{
					return i;
				}
				if ((num & 0xFFFE) == 65534)
				{
					return i;
				}
			}
			else
			{
				if (num >= 56320 && num <= 57343)
				{
					return i;
				}
				if (num >= 64976 && num <= 65007)
				{
					return i;
				}
				if ((num & 0xFFFE) == 65534)
				{
					return i;
				}
			}
		}
		return -1;
	}

	private static bool _0023_003DzoXoTx6hOgm5cVN8wxg_003D_003D(int _0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
	{
		switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
		{
		default:
			if (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1520 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1524)
			{
				break;
			}
			switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
			{
			default:
				if ((_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1600 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1610) || (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1645 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1647) || (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1649 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1749))
				{
					break;
				}
				switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
				{
				default:
					if ((_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1786 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1790) || (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1792 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1805))
					{
						break;
					}
					switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
					{
					default:
						if (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 1920 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 1957)
						{
							break;
						}
						switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
						{
						default:
							if ((_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 64298 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 64310) || (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 64312 && _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 64316))
							{
								break;
							}
							switch (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D)
							{
							default:
								if ((_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 64323 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 64324) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 64326 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 64433) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 64467 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 64829) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 64848 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 64911) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 64914 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 64967) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 65008 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 65020) && (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D < 65136 || _0023_003DzAv1eNIBsseLUXurHyw_003D_003D > 65140))
								{
									if (_0023_003DzAv1eNIBsseLUXurHyw_003D_003D >= 65142)
									{
										return _0023_003DzAv1eNIBsseLUXurHyw_003D_003D <= 65276;
									}
									return false;
								}
								break;
							case 64318:
							case 64320:
							case 64321:
								break;
							}
							break;
						case 1969:
						case 8207:
						case 64285:
						case 64287:
						case 64288:
						case 64289:
						case 64290:
						case 64291:
						case 64292:
						case 64293:
						case 64294:
						case 64295:
						case 64296:
							break;
						}
						break;
					case 1808:
					case 1810:
					case 1811:
					case 1812:
					case 1813:
					case 1814:
					case 1815:
					case 1816:
					case 1817:
					case 1818:
					case 1819:
					case 1820:
					case 1821:
					case 1822:
					case 1823:
					case 1824:
					case 1825:
					case 1826:
					case 1827:
					case 1828:
					case 1829:
					case 1830:
					case 1831:
					case 1832:
					case 1833:
					case 1834:
					case 1835:
					case 1836:
						break;
					}
					break;
				case 1757:
				case 1765:
				case 1766:
					break;
				}
				break;
			case 1563:
			case 1567:
			case 1569:
			case 1570:
			case 1571:
			case 1572:
			case 1573:
			case 1574:
			case 1575:
			case 1576:
			case 1577:
			case 1578:
			case 1579:
			case 1580:
			case 1581:
			case 1582:
			case 1583:
			case 1584:
			case 1585:
			case 1586:
			case 1587:
			case 1588:
			case 1589:
			case 1590:
			case 1591:
			case 1592:
			case 1593:
			case 1594:
				break;
			}
			break;
		case 1470:
		case 1472:
		case 1475:
		case 1488:
		case 1489:
		case 1490:
		case 1491:
		case 1492:
		case 1493:
		case 1494:
		case 1495:
		case 1496:
		case 1497:
		case 1498:
		case 1499:
		case 1500:
		case 1501:
		case 1502:
		case 1503:
		case 1504:
		case 1505:
		case 1506:
		case 1507:
		case 1508:
		case 1509:
		case 1510:
		case 1511:
		case 1512:
		case 1513:
		case 1514:
			break;
		}
		return true;
	}

	private protected static string[] _0023_003Dz4HSxdHE_003D(string _0023_003DzuwH5j5s_003D, bool _0023_003DzsRaZzaNNQtTX, bool _0023_003DzE3ZVbQdHkHzU)
	{
		string text = (_0023_003DzsRaZzaNNQtTX ? _0023_003DzuwH5j5s_003D : _0023_003DzuwH5j5s_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982015)));
		if (_0023_003Dza1Qy0j6yPM5UdxIUBg_003D_003D(text))
		{
			text = _0023_003DzfX_LGlVWP5fZ._0023_003DzNzMWwTmGe_0024Sn(text, _0023_003DzE3ZVbQdHkHzU, null);
			List<string> list = new List<string>();
			List<char> list2 = new List<char>();
			bool flag = false;
			for (int i = 0; i < text.Length; i++)
			{
				bool flag2 = _0023_003DzoXoTx6hOgm5cVN8wxg_003D_003D(char.ConvertToUtf32(text, i));
				if (flag != flag2)
				{
					_0023_003DzKQOpFewNmqL6(flag, list2, list);
					list2.Clear();
					flag = flag2;
				}
				list2.Add(text[i]);
				if (char.IsSurrogatePair(text, i))
				{
					list2.Add(text[++i]);
				}
			}
			_0023_003DzKQOpFewNmqL6(flag, list2, list);
			return list.ToArray();
		}
		return _0023_003Dz2luigvoyVLkpRhbivw_003D_003D(text);
	}

	private static void _0023_003DzKQOpFewNmqL6(bool _0023_003DzlIM_s5vynZ8N, List<char> _0023_003DzSeb_0024PPo_003D, List<string> _0023_003DzuJJZ4KE_003D)
	{
		if (_0023_003DzlIM_s5vynZ8N)
		{
			char[] array = _0023_003DzSeb_0024PPo_003D.ToArray();
			Array.Reverse(array);
			_0023_003DzuJJZ4KE_003D.Add(new string(array));
			_0023_003DzSeb_0024PPo_003D.Clear();
		}
		else
		{
			_0023_003DzuJJZ4KE_003D.AddRange(_0023_003Dz2luigvoyVLkpRhbivw_003D_003D(new string(_0023_003DzSeb_0024PPo_003D.ToArray())));
		}
	}

	private static string[] _0023_003Dz2luigvoyVLkpRhbivw_003D_003D(string _0023_003DzuwH5j5s_003D)
	{
		List<string> list = new List<string>(_0023_003DzuwH5j5s_003D.Length);
		for (int i = 0; i < _0023_003DzuwH5j5s_003D.Length; i++)
		{
			if (i < _0023_003DzuwH5j5s_003D.Length - 1 && char.GetUnicodeCategory(_0023_003DzuwH5j5s_003D[i + 1]) == UnicodeCategory.NonSpacingMark)
			{
				list.Add(_0023_003DzuwH5j5s_003D.Substring(i, 2));
				i++;
			}
			else
			{
				list.Add(_0023_003DzuwH5j5s_003D[i].ToString());
			}
		}
		return list.ToArray();
	}

	internal void ConvertToInternal(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, Transformation _0023_003Dz9ZUzIX4xmsyA, bool _0023_003DztGfy8BAzQdGaU6HShA_003D_003D, bool _0023_003Dzh6bB8iUYNCW4, IWorkspace _0023_003DzFM3KC0w_003D, out ICurve[] _0023_003DzsdySxIlQLgFZ, out ICurve[][] _0023_003DzWaFlkhfmYCja)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			RegenParams data = new RegenParams(_0023_003DzFM3KC0w_003D.Document.GetVisualRefinement().Deviation, _0023_003DzFM3KC0w_003D.Document);
			Regen(data);
		}
		TextStyle textStyle = _0023_003DzFM3KC0w_003D.TextStyles[StyleName];
		FontStyleData fsd = _0023_003DzFM3KC0w_003D.Document.fontDefs[textStyle.FontFamilyName][textStyle.Style];
		_0023_003DzFM3KC0w_003D.RenderContext.GetTextOutlines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003Dz9ZUzIX4xmsyA, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D, _0023_003Dzh6bB8iUYNCW4, _0023_003DzFM3KC0w_003D, this, textStyle, fsd, out _0023_003DzsdySxIlQLgFZ, out _0023_003DzWaFlkhfmYCja, GetTextOutlines);
	}

	protected void GetSHXOutlines(string text, double deviation, Transformation transf, FontStyleData fsd, out ICurve[] outers, out ICurve[][] inners)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < text.Length; i++)
		{
			FontStyleCharData fontStyleCharData = fsd[text[i].ToString()];
			Entity[] array = fontStyleCharData._0023_003Dz0erUYWA_003D(_0023_003Dz_Gzfs9c_003D: true, _0023_003DzMq_3pL2oL0w4r1oLOw_003D_003D: false);
			for (int j = 0; j < array.Length; j++)
			{
				Entity entity = array[j];
				if (entity is Circle circle)
				{
					double scaleFactor = Math.Abs(transf.ScaleFactorX);
					if (!transf.IsScaleFactorUniform() && !transf.IsScaleFactorUniformForPlanar(circle.Plane, ref scaleFactor))
					{
						circle.Regen(deviation);
						entity = new LinearPath(circle.Vertices);
					}
				}
				entity.TransformBy(transf);
				list.Add((ICurve)entity);
			}
			transf *= (Transformation)new Translation(fontStyleCharData.Width, 0.0);
		}
		outers = list.ToArray();
		inners = new ICurve[0][];
	}

	protected virtual void GetTextOutlines(double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation transform, double fontScale, RenderContextBase renderContext, bool isRightToLeft, out ICurve[] ptOuters, out ICurve[][] ptInners)
	{
		GetTextOutlines(text, deviation, computeInners, toCurve, isShx, fsd, transform, fontScale, renderContext, isRightToLeft, out ptOuters, out ptInners);
	}

	protected virtual void GetTextOutlines(string myText, double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation transform, double fontScale, RenderContextBase renderContext, bool isRightToLeft, out ICurve[] ptOuters, out ICurve[][] ptInners)
	{
		Transformation transformation = GetTextMatrix();
		if (transform != null && !transform.IsIdentity())
		{
			transformation = transform * transformation;
		}
		GetTextOutlinesInternal(myText, deviation, computeInners, toCurve, isShx, fsd, transformation, fontScale, renderContext, isRightToLeft, out ptOuters, out ptInners);
	}

	protected internal virtual Point3D[] GetTextRectangleVertices()
	{
		Point3D[] array = new Point3D[4]
		{
			Point3D.Origin,
			new Point3D(exactWidth, 0.0),
			new Point3D(exactWidth, _0023_003DzcAXPBc8_003D()),
			new Point3D(0.0, _0023_003DzcAXPBc8_003D())
		};
		PostRegen(array);
		return array;
	}

	protected virtual Transformation GetTextMatrix()
	{
		return new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ) * UnscaledTransform * ScaleTransform;
	}

	protected void GetTextOutlinesInternal(string myText, double deviation, bool computeInners, bool toCurve, bool isShx, FontStyleData fsd, Transformation myTransform, double fontScale, RenderContextBase renderContext, bool isRightToLeft, out ICurve[] outers, out ICurve[][] inners)
	{
		outers = null;
		inners = null;
		if (isShx)
		{
			GetSHXOutlines(myText, deviation, myTransform, fsd, out outers, out inners);
			RegenParams data = new RegenParams(deviation);
			ICurve[] array = outers;
			for (int i = 0; i < array.Length; i++)
			{
				((Entity)array[i]).Regen(data);
			}
			return;
		}
		Point2D[][] loops;
		Point2D[][][] inners2;
		double Descend;
		if (computeInners)
		{
			renderContext.GetCharOutlines(myText, deviation, toCurve, isRightToLeft, out loops, out inners2, out Descend, fontScale);
		}
		else
		{
			inners2 = null;
			renderContext.GetCharOutlines(myText, deviation, toCurve, isRightToLeft, out loops, out Descend, fontScale);
		}
		if (!toCurve)
		{
			_0023_003DzzGkm1uraupz9(myTransform, loops, inners2, out outers, out inners);
			return;
		}
		outers = new ICurve[loops.Length];
		inners = new ICurve[loops.Length][];
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			for (int j = 0; j < loops.Length; j++)
			{
				Point2D[] _0023_003DzdEvMFOw_003D = loops[j];
				List<ICurve> list = _0023_003Dzm9PBHGvJ9XUi(_0023_003DzdEvMFOw_003D);
				if (list.Count == 1)
				{
					outers[j] = list[0];
				}
				else
				{
					outers[j] = new CompositeCurve(list);
				}
				((Entity)outers[j]).TransformBy(myTransform);
				if (inners2 == null || inners2[j].Length == 0)
				{
					inners[j] = new ICurve[0];
					continue;
				}
				inners[j] = new ICurve[inners2[j].Length];
				for (int k = 0; k < inners2[j].Length; k++)
				{
					Point2D[] _0023_003DzdEvMFOw_003D2 = inners2[j][k];
					List<ICurve> list2 = _0023_003Dzm9PBHGvJ9XUi(_0023_003DzdEvMFOw_003D2);
					if (list2.Count == 1)
					{
						inners[j][k] = list2[0];
					}
					else
					{
						inners[j][k] = new CompositeCurve(list2);
					}
					((Entity)inners[j][k]).TransformBy(myTransform);
				}
			}
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	private List<ICurve> _0023_003Dzm9PBHGvJ9XUi(Point2D[] _0023_003DzdEvMFOw_003D)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < _0023_003DzdEvMFOw_003D.Length - 1; i++)
		{
			Point2D point2D = _0023_003DzdEvMFOw_003D[i];
			if (point2D is Point3D && _0023_003DzdEvMFOw_003D[i + 1] is Point3D)
			{
				list.Add(new Curve(3, new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 }, new Point4D[4]
				{
					new Point4D(point2D.X, point2D.Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 1].X, _0023_003DzdEvMFOw_003D[i + 1].Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 2].X, _0023_003DzdEvMFOw_003D[i + 2].Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 3].X, _0023_003DzdEvMFOw_003D[i + 3].Y, 0.0, 1.0)
				}));
				i = ((i + 4 >= _0023_003DzdEvMFOw_003D.Length - 1 || _0023_003DzdEvMFOw_003D[i + 4] is Point3D) ? (i + 3) : (i + 2));
			}
			else if (Point2D.DistanceSquared(point2D, _0023_003DzdEvMFOw_003D[i + 1]) > 0.0)
			{
				list.Add(new Line(point2D.X, point2D.Y, _0023_003DzdEvMFOw_003D[i + 1].X, _0023_003DzdEvMFOw_003D[i + 1].Y));
			}
		}
		return list;
	}

	private void _0023_003DzzGkm1uraupz9(Transformation _0023_003Dzptomndc_003D, Point2D[][] _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D, Point2D[][][] _0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D, out ICurve[] _0023_003DzsdySxIlQLgFZ, out ICurve[][] _0023_003DzWaFlkhfmYCja)
	{
		_0023_003DzsdySxIlQLgFZ = new ICurve[_0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D.Length];
		for (int i = 0; i < _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D.Length; i++)
		{
			_0023_003DzsdySxIlQLgFZ[i] = new LinearPath(_0023_003DzsqjfJ42_00241lfT(_0023_003Dzptomndc_003D, _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D[i]));
			((Entity)_0023_003DzsdySxIlQLgFZ[i]).Regen(0.0);
		}
		int num = ((_0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D != null) ? _0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D.Length : 0);
		_0023_003DzWaFlkhfmYCja = new ICurve[num][];
		for (int j = 0; j < num; j++)
		{
			_0023_003DzWaFlkhfmYCja[j] = new ICurve[_0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D[j].Length];
			for (int k = 0; k < _0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D[j].Length; k++)
			{
				_0023_003DzWaFlkhfmYCja[j][k] = new LinearPath(_0023_003DzsqjfJ42_00241lfT(_0023_003Dzptomndc_003D, _0023_003DzRXQJxW3qWNB_rIgwrg_003D_003D[j][k]));
				((Entity)_0023_003DzWaFlkhfmYCja[j][k]).Regen(0.0);
			}
		}
	}

	private static Point3D[] _0023_003DzsqjfJ42_00241lfT(Transformation _0023_003Dzptomndc_003D, Point2D[] _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D)
	{
		Point3D[] array = new Point3D[_0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D.Length];
		for (int i = 0; i < _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D.Length; i++)
		{
			array[i] = _0023_003Dzptomndc_003D * new Point3D(_0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D[i].X, _0023_003DzUZpQxAP3Xo6p6Q91iw_003D_003D[i].Y, 0.0);
		}
		return array;
	}

	public override void TransformBy(Transformation xform)
	{
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
		{
			height *= scaleFactor;
		}
		base.TransformBy(xform);
	}

	private Transformation _0023_003DzVydljDgqtgNs()
	{
		return _003CTranslationTransform_003Ek__BackingField;
	}

	private void _0023_003Dz40K3Bdu_0024uJ6w(Transformation _0023_003DzPzO_0024GUk_003D)
	{
		_003CTranslationTransform_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	internal virtual Point3D[][] GetTriangles(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		return _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D, Transform);
	}

	internal virtual Point3D[][] _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, Transformation _0023_003Dzptomndc_003D)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			RegenParams data = new RegenParams(_0023_003DzFM3KC0w_003D.Document.GetVisualRefinement().Deviation, _0023_003DzFM3KC0w_003D.Document);
			Regen(data);
		}
		return GetTrianglesInternal(_0023_003DzFM3KC0w_003D, _0023_003Dzptomndc_003D, _0023_003DzWArtMuor9L71fptjtg_003D_003D);
	}

	protected virtual Point3D[][] GetTrianglesInternal(IWorkspace ws, Transformation myTransform, double accuracy)
	{
		return GetTrianglesInternal(_textTokens, ws, myTransform, accuracy);
	}

	protected Point3D[][] GetTrianglesInternal(string[] tokens, IWorkspace ws, Transformation myTransform, double accuracy)
	{
		TextStyle textStyle = ws.TextStyles[StyleName];
		FontStyleData fontStyleData = ws.Document.fontDefs[textStyle.FontFamilyName][textStyle.Style];
		Point3D[][][] array = null;
		int[][][] array2 = null;
		if (textStyle.IsSHX())
		{
			return new Point3D[0][];
		}
		array = new Point3D[tokens.Length][][];
		array2 = new int[tokens.Length][][];
		int num = 0;
		bool _0023_003DzbamQ1mQWVhT = ((IWorkspaceInternal)ws).IsRightToLeft();
		foreach (string text in tokens)
		{
			fontStyleData.TryGetValue(text, out var value);
			value._0023_003DzWYTqKrPYeTk8SjO2Vw_003D_003D(text, ws.RenderContext, textStyle.FontFamilyName, textStyle.Style, accuracy, fontStyleData.ScaleToUnitSize, _0023_003DzbamQ1mQWVhT, ref myTransform, out array[num], out array2[num]);
			num++;
		}
		List<Point3D[]> list = new List<Point3D[]>();
		for (int j = 0; j < array2.GetLength(0); j++)
		{
			for (int k = 0; k < array2[j].GetLength(0); k++)
			{
				Point3D[] array3 = array[j][k];
				int[] array4 = array2[j][k];
				List<Point3D> list2 = new List<Point3D>(array4.Length);
				int num2 = 0;
				while (num2 < array4.Length)
				{
					list2.Add((Point3D)array3[array4[num2++]].Clone());
				}
				list.Add(list2.ToArray());
			}
		}
		return list.ToArray();
	}

	protected internal virtual Point3D[][] GetOutlines(double accuracy, IWorkspace ws)
	{
		return _0023_003DzPMjadmqUl4WCDqPi2w_003D_003D(accuracy, ws, null);
	}

	internal virtual Point3D[][] _0023_003DzPMjadmqUl4WCDqPi2w_003D_003D(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, Transformation _0023_003Dz9ZUzIX4xmsyA)
	{
		ConvertToInternal(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003Dz9ZUzIX4xmsyA, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: false, _0023_003Dzh6bB8iUYNCW4: false, _0023_003DzFM3KC0w_003D, out var _0023_003DzsdySxIlQLgFZ, out var _);
		Point3D[][] array = new Point3D[_0023_003DzsdySxIlQLgFZ.Length][];
		for (int i = 0; i < _0023_003DzsdySxIlQLgFZ.Length; i++)
		{
			array[i] = ((Entity)_0023_003DzsdySxIlQLgFZ[i]).Vertices;
		}
		return array;
	}

	internal static void _0023_003DziivS_0024a924P2e(string _0023_003Dz3BH4yh6JQ_tc, fontStyle _0023_003Dz_0024wQZnFQ_003D, FontDataDictionary _0023_003Dzb_EPJPaEdtf0, string[] _0023_003Dz54nHjlA_003D, double _0023_003DzvAxV_0024Ic_003D, double _0023_003DzwzMn4TDvq4kF, out double _0023_003Dz6tVBpdk_003D, out double _0023_003DzzZ7ER_0024M_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		_0023_003Dz6tVBpdk_003D = (_0023_003DzzZ7ER_0024M_003D = 0.0);
		_0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		if (_0023_003Dz54nHjlA_003D.Length == 0)
		{
			_0023_003DzDPcjoBJLcqli = (_0023_003Dz_0024N_0024yKptW9BoC = null);
			return;
		}
		double num = 0.0;
		FontStyleData fontStyleData = _0023_003Dzb_EPJPaEdtf0[_0023_003Dz3BH4yh6JQ_tc][_0023_003Dz_0024wQZnFQ_003D];
		List<Point3D> list = new List<Point3D>();
		foreach (string key in _0023_003Dz54nHjlA_003D)
		{
			fontStyleData.TryGetValue(key, out var value);
			if (value.boxMin == null)
			{
				list.Add(new Point3D(num, 0.0, 0.0));
				list.Add(new Point3D(num + value.Width, 1.0, 0.0));
			}
			else
			{
				list.Add(new Point3D(value.boxMin.X + num, value.boxMin.Y, 0.0));
				list.Add(new Point3D(value.boxMax.X + num, value.boxMax.Y, 0.0));
			}
			num += value.Width;
			if (value.Descend > _0023_003DzzZ7ER_0024M_003D)
			{
				_0023_003DzzZ7ER_0024M_003D = value.Descend;
			}
		}
		Utility.UpdateMinMax(null, list, list.Count, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		_0023_003DzzZ7ER_0024M_003D *= _0023_003DzvAxV_0024Ic_003D;
		double num2 = _0023_003DzvAxV_0024Ic_003D * _0023_003DzwzMn4TDvq4kF;
		_0023_003DzDPcjoBJLcqli = new Point3D(_0023_003DzDPcjoBJLcqli.X * num2, _0023_003DzDPcjoBJLcqli.Y * _0023_003DzvAxV_0024Ic_003D, 0.0);
		_0023_003Dz_0024N_0024yKptW9BoC = new Point3D(_0023_003Dz_0024N_0024yKptW9BoC.X * num2, _0023_003Dz_0024N_0024yKptW9BoC.Y * _0023_003DzvAxV_0024Ic_003D, 0.0);
		_0023_003Dz6tVBpdk_003D = num * num2;
	}

	internal void _0023_003DziivS_0024a924P2e(string[] _0023_003Dz54nHjlA_003D, string _0023_003DzUsjwj2w_003D, fontStyle _0023_003DzbD7eE_0024CynOmT, FontDataDictionary _0023_003Dzb_EPJPaEdtf0, double _0023_003DzwzMn4TDvq4kF, out double _0023_003Dz6tVBpdk_003D, out double _0023_003DzzZ7ER_0024M_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		_0023_003DziivS_0024a924P2e(_0023_003DzUsjwj2w_003D, _0023_003DzbD7eE_0024CynOmT, _0023_003Dzb_EPJPaEdtf0, _0023_003Dz54nHjlA_003D, _0023_003DzcAXPBc8_003D(), _0023_003DzwzMn4TDvq4kF, out _0023_003Dz6tVBpdk_003D, out _0023_003DzzZ7ER_0024M_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity.ThroughTriangleQuad(data, _vertices))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.ThroughTriangleScreenPolygonQuad(_vertices, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D obj = (_0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D)_0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D(text, exactWidth, _0023_003DzcAXPBc8_003D(), PlaneTransform.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new TextSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), height);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981478), _widthFactor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981463), text);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981444), alignment);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981428), Simplify);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981409), StyleName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911644), Backward);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981393), UpsideDown);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981380), Billboard);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[1] { base.Plane.Origin };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForWireframe(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (IsSingleLineFont(_0023_003DzELu0Pss_003D))
		{
			return shaderPrimitiveType.Line;
		}
		return shaderPrimitiveType.Polygon;
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForFlat(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (IsSingleLineFont(_0023_003DzELu0Pss_003D))
		{
			return shaderPrimitiveType.Line;
		}
		return shaderPrimitiveType.Polygon;
	}
}
