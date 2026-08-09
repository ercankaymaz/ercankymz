using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class VectorView : View
{
	private double _fontAccuracy;

	private bool _keepEntityColor;

	private bool _ignoreTransparency;

	private bool _treatWhiteAsBlack;

	private bool _hiddenSegments;

	private bool _fillTexts = true;

	private bool _fillRegions = true;

	private bool _shaded;

	private bool _forceCompile;

	internal int hdlCount;

	internal int hiddenHdlCount;

	internal float[][] pointArrays = new float[8][];

	internal byte[][] colorArrays = new byte[8][];

	internal EntityGraphicsData[] drawDataArray = new EntityGraphicsData[8];

	internal float[] lineWeights = new float[8];

	internal string[] layers = new string[8];

	internal IList<HiddenLinesView.HdlCurve> hiddenSilho2D;

	internal IList<HiddenLinesView.HdlCurve> hiddenEdges2D;

	internal IList<HiddenLinesView.HdlCurve> hiddenWires2D;

	internal double segmentsScaleFactor;

	internal Translation originTranslation;

	internal List<Entity> selectedHdlSegments = new List<Entity>();

	internal bool inScope;

	public double CenterlinesExtensionAmount { get; set; } = 1.0;

	public override double Scale
	{
		get
		{
			return base.Scale;
		}
		set
		{
			if (value != 0.0)
			{
				base.Scale = value;
			}
		}
	}

	internal override AutodeskProperties.visualStyleType visualStyleMode
	{
		get
		{
			AutodeskProperties autodeskProperties = AutodeskProperties;
			if (autodeskProperties != null)
			{
				_ = autodeskProperties.VisualStyleMode;
				if (true)
				{
					return AutodeskProperties.VisualStyleMode;
				}
			}
			if (!Shaded)
			{
				return AutodeskProperties.visualStyleType.Hidden;
			}
			return AutodeskProperties.visualStyleType.Realistic;
		}
		set
		{
			if (AutodeskProperties == null)
			{
				AutodeskProperties = new AutodeskProperties();
			}
			AutodeskProperties.VisualStyleMode = value;
		}
	}

	public bool Shaded
	{
		get
		{
			return _shaded;
		}
		set
		{
			_shaded = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool HiddenSegments
	{
		get
		{
			return _hiddenSegments;
		}
		set
		{
			_hiddenSegments = value;
			if (value && hiddenSilho2D == null)
			{
				_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
			}
		}
	}

	public bool IgnoreTransparency
	{
		get
		{
			return _ignoreTransparency;
		}
		set
		{
			_ignoreTransparency = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool FillTexts
	{
		get
		{
			return _fillTexts;
		}
		set
		{
			_fillTexts = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public double FontAccuracy
	{
		get
		{
			return _fontAccuracy;
		}
		set
		{
			_fontAccuracy = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool FillRegions
	{
		get
		{
			return _fillRegions;
		}
		set
		{
			_fillRegions = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool KeepEntityColor
	{
		get
		{
			return _keepEntityColor;
		}
		set
		{
			_keepEntityColor = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool TreatWhiteAsBlack
	{
		get
		{
			return _treatWhiteAsBlack;
		}
		set
		{
			_treatWhiteAsBlack = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public VectorView(double x, double y, viewType standardView, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, standardView, scale, name, width, height)
	{
	}

	public VectorView(double x, double y, Camera camera, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, camera, scale, name, width, height)
	{
	}

	public VectorView(double x, double y, Camera camera, double scale, string name, Size viewportSize)
		: base(x, y, camera, scale, name, viewportSize)
	{
	}

	public VectorView(double x, double y, Camera camera, double scale, string name, RectangleF window, Size viewportSize)
		: base(x, y, camera, scale, name, window, viewportSize)
	{
	}

	public VectorView(VectorView another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_hiddenSegments = another._hiddenSegments;
		_fillTexts = another._fillTexts;
		_fontAccuracy = another._fontAccuracy;
		_ignoreTransparency = another._ignoreTransparency;
		_fillRegions = another._fillRegions;
		CenterlinesExtensionAmount = another.CenterlinesExtensionAmount;
		_keepEntityColor = another._keepEntityColor;
		_treatWhiteAsBlack = another._treatWhiteAsBlack;
		_shaded = another._shaded;
	}

	protected internal VectorView(VectorViewSurrogate surrogate)
		: base(surrogate)
	{
	}

	protected VectorView(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_hiddenSegments = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982931));
		_ignoreTransparency = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982922));
		_fillTexts = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983137));
		_fontAccuracy = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983121));
		_fillRegions = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983110));
		CenterlinesExtensionAmount = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983096));
		_keepEntityColor = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983065));
		_treatWhiteAsBlack = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983055));
		_shaded = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955541));
	}

	private void _0023_003DzHQdR0_0024o3SV7U()
	{
		for (int i = 0; i < 8; i++)
		{
			drawDataArray[i]?.Dispose();
			drawDataArray[i] = null;
			pointArrays[i] = null;
			colorArrays[i] = null;
		}
		lineWeights = new float[8];
	}

	public override object Clone()
	{
		return new VectorView(this);
	}

	public override object CloneWithTessellation()
	{
		return new VectorView(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Regen(RegenParams data)
	{
		if (!(data.Document is DrawingDocument))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982759));
		}
		regenMode = regenType.RegenAndCompile;
		_0023_003DzHQdR0_0024o3SV7U();
		Block block = data.Blocks[base.BlockName];
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		List<float> list3 = new List<float>();
		List<float> list4 = new List<float>();
		List<float> list5 = new List<float>();
		List<float> list6 = new List<float>();
		List<byte> list7 = new List<byte>();
		List<byte> list8 = new List<byte>();
		List<byte> list9 = new List<byte>();
		List<byte> list10 = new List<byte>();
		List<byte> list11 = new List<byte>();
		List<byte> list12 = new List<byte>();
		List<float> list13 = new List<float>();
		List<float> list14 = new List<float>();
		List<byte> list15 = new List<byte>();
		List<byte> list16 = new List<byte>();
		DrawingDocument obj = (DrawingDocument)data.Document;
		string silhouettesLayerName = obj.SilhouettesLayerName;
		string edgesLayerName = obj.EdgesLayerName;
		string wiresLayerName = obj.WiresLayerName;
		string hiddenSilhouettesLayerName = obj.HiddenSilhouettesLayerName;
		string hiddenEdgesLayerName = obj.HiddenEdgesLayerName;
		string hiddenWiresLayerName = obj.HiddenWiresLayerName;
		hdlCount = 0;
		hiddenHdlCount = 0;
		for (int i = 0; i < block.Entities.Count; i++)
		{
			Entity entity = block.Entities[i];
			if (!(entity is LinearPath) && !(entity is Circle) && !(entity is Point) && !(entity is Ellipse) && !(entity is Curve))
			{
				break;
			}
			string layerName = entity.LayerName;
			if (layerName.Equals(hiddenSilhouettesLayerName))
			{
				_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list4, list10, null, null);
				hiddenHdlCount++;
				continue;
			}
			if (layerName.Equals(hiddenEdgesLayerName))
			{
				_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list5, list11, null, null);
				hiddenHdlCount++;
				continue;
			}
			if (layerName.Equals(hiddenWiresLayerName))
			{
				_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list6, list12, list14, list16);
				hiddenHdlCount++;
				continue;
			}
			if (layerName.Equals(silhouettesLayerName))
			{
				_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list, list7, null, null);
				hdlCount++;
				continue;
			}
			if (layerName.Equals(edgesLayerName))
			{
				_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list2, list8, null, null);
				hdlCount++;
				continue;
			}
			if (!layerName.Equals(wiresLayerName))
			{
				break;
			}
			_0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(entity, data, list3, list9, list13, list15);
			hdlCount++;
		}
		hdlCount += hiddenHdlCount;
		for (int j = 0; j < 8; j++)
		{
			float[] array;
			byte[] array2;
			string layerName;
			switch (j)
			{
			case 0:
				array = list.ToArray();
				array2 = list7.ToArray();
				layerName = silhouettesLayerName;
				break;
			case 1:
				array = list2.ToArray();
				array2 = list8.ToArray();
				layerName = edgesLayerName;
				break;
			case 2:
				array = list3.ToArray();
				array2 = list9.ToArray();
				layerName = wiresLayerName;
				break;
			case 3:
				array = list4.ToArray();
				array2 = list10.ToArray();
				layerName = hiddenSilhouettesLayerName;
				break;
			case 4:
				array = list5.ToArray();
				array2 = list11.ToArray();
				layerName = hiddenEdgesLayerName;
				break;
			case 5:
				array = list6.ToArray();
				array2 = list12.ToArray();
				layerName = hiddenWiresLayerName;
				break;
			case 6:
				array = list13.ToArray();
				array2 = list15.ToArray();
				layerName = wiresLayerName;
				break;
			case 7:
				array = list14.ToArray();
				array2 = list16.ToArray();
				layerName = hiddenWiresLayerName;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (array.Length != 0)
			{
				pointArrays[j] = array;
				colorArrays[j] = array2;
				lineWeights[j] = data.Document.Layers[layerName].LineWeight;
				layers[j] = layerName;
			}
			else
			{
				pointArrays[j] = null;
				colorArrays[j] = null;
			}
		}
		base.Regen(data);
		regenMode = regenType.CompileOnly;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		if (hdlCount == 0)
		{
			return base.ComputeBoundingBox(data, out boxMin, out boxMax);
		}
		List<Entity> list = GetEntities(data.Blocks).ToList();
		if (hdlCount >= list.Count)
		{
			return base.ComputeBoundingBox(data, out boxMin, out boxMax);
		}
		bool result = _0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(data, transformedEntityBoxes, list.GetRange(0, hdlCount), base.Attributes, out boxMin, out boxMax);
		ComputeRectangleVerticesForSelection(((DrawingDocument)data.Document).ActiveSheet);
		return result;
	}

	public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		return true;
	}

	public override void Compile(CompileParams data)
	{
		for (int i = 0; i < 8; i++)
		{
			_0023_003DzjG6yJcznyCn8(data, i);
		}
		base.Compile(data);
	}

	private void _0023_003DzjG6yJcznyCn8(CompileParams _0023_003DzELu0Pss_003D, int _0023_003Dz437_00244ak_003D)
	{
		float[] array = pointArrays[_0023_003Dz437_00244ak_003D];
		if (array != null && array.Length != 0)
		{
			byte[] colors = colorArrays[_0023_003Dz437_00244ak_003D];
			drawDataArray[_0023_003Dz437_00244ak_003D] = _0023_003DzELu0Pss_003D.RenderContext.CreateEntityGraphicsData();
			_0023_003DzELu0Pss_003D.RenderContext.CompileVBO(drawDataArray[_0023_003Dz437_00244ak_003D], _0023_003DzXBBhDy4lyAgJ3S4AkA_003D_003D, new VBOParams
			{
				vertices = array,
				colors = colors,
				primitiveMode = primitiveType.PointList
			});
			pointArrays[_0023_003Dz437_00244ak_003D] = null;
			colorArrays[_0023_003Dz437_00244ak_003D] = null;
		}
	}

	private void _0023_003DzXBBhDy4lyAgJ3S4AkA_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		VBOParams vBOParams = (VBOParams)_0023_003DzmPmPjCPqZ3T3;
		_0023_003DzB8iS0QA_003D.DrawPointsWithColorsRGBIndeterminate(vBOParams.vertices, vBOParams.colors);
	}

	private void _0023_003Dzac92H3SfqCqEGCdpi_njbW0_003D(Entity _0023_003Dzs_0024uS8LA_003D, RegenParams _0023_003DzELu0Pss_003D, List<float> _0023_003Dz718vejI_003D, List<byte> _0023_003Dz_QzSJjGzDUL8, List<float> _0023_003Dzwt3zNs8_003D, List<byte> _0023_003DzCWSi6GRsfW5N)
	{
		if (!_0023_003Dzs_0024uS8LA_003D.IsVisible(_0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.Document.Layers, attributeReferenceVisibilityType.Normal))
		{
			return;
		}
		Color color = _0023_003Dzs_0024uS8LA_003D.GetColor(_0023_003DzELu0Pss_003D.Document.Layers, GetColor(_0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.Document.DefaultColor));
		if (_0023_003Dzs_0024uS8LA_003D is Point point)
		{
			_0023_003Dzwt3zNs8_003D.Add((float)point.Vertices[0].X);
			_0023_003Dzwt3zNs8_003D.Add((float)point.Vertices[0].Y);
			_0023_003Dzwt3zNs8_003D.Add((float)point.Vertices[0].Z);
			_0023_003DzCWSi6GRsfW5N.Add(color.R);
			_0023_003DzCWSi6GRsfW5N.Add(color.G);
			_0023_003DzCWSi6GRsfW5N.Add(color.B);
			return;
		}
		LineType lineType = _0023_003Dzs_0024uS8LA_003D.GetLineType(_0023_003DzELu0Pss_003D.Document.LineTypes, _0023_003DzELu0Pss_003D.Document.Layers, GetLineType(_0023_003DzELu0Pss_003D.Document.LineTypes, _0023_003DzELu0Pss_003D.Document.Layers));
		if (lineType != null)
		{
			_0023_003DzeQGh0UTt6b0yphyViw_003D_003D(_0023_003Dzs_0024uS8LA_003D, lineType, _0023_003DzELu0Pss_003D, _0023_003Dz718vejI_003D, _0023_003Dz_QzSJjGzDUL8);
			return;
		}
		for (int i = 0; i < _0023_003Dzs_0024uS8LA_003D.Vertices.Length - 1; i++)
		{
			Point3D point3D = _0023_003Dzs_0024uS8LA_003D.Vertices[i];
			Point3D point3D2 = _0023_003Dzs_0024uS8LA_003D.Vertices[i + 1];
			_0023_003Dz718vejI_003D.Add((float)point3D.X);
			_0023_003Dz718vejI_003D.Add((float)point3D.Y);
			_0023_003Dz718vejI_003D.Add((float)point3D.Z);
			_0023_003Dz718vejI_003D.Add((float)point3D2.X);
			_0023_003Dz718vejI_003D.Add((float)point3D2.Y);
			_0023_003Dz718vejI_003D.Add((float)point3D2.Z);
			_0023_003Dz_QzSJjGzDUL8.Add(color.R);
			_0023_003Dz_QzSJjGzDUL8.Add(color.G);
			_0023_003Dz_QzSJjGzDUL8.Add(color.B);
			_0023_003Dz_QzSJjGzDUL8.Add(color.R);
			_0023_003Dz_QzSJjGzDUL8.Add(color.G);
			_0023_003Dz_QzSJjGzDUL8.Add(color.B);
		}
	}

	private void _0023_003DzeQGh0UTt6b0yphyViw_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D, LineType _0023_003DzhC3Yby0_003D, RegenParams _0023_003DzELu0Pss_003D, List<float> _0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D, List<byte> _0023_003DzJ2Dey1diwS3E)
	{
		Point3D[] vertices = _0023_003Dzs_0024uS8LA_003D.Vertices;
		_0023_003DzhC3Yby0_003D.GetPatternVertices(_0023_003DzELu0Pss_003D.Document.MaxPatternRepetitions, vertices, _0023_003Dzs_0024uS8LA_003D.LineTypeScale * _0023_003DzELu0Pss_003D.Document.LineTypeScale / (float)Scale, out var lines, out var points);
		Color color = _0023_003Dzs_0024uS8LA_003D.GetColor(_0023_003DzELu0Pss_003D.Document.Layers, GetColor(_0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.Document.DefaultColor));
		foreach (Point3D item in lines)
		{
			_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item.X);
			_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item.Y);
			_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item.Z);
			_0023_003DzJ2Dey1diwS3E.Add(color.R);
			_0023_003DzJ2Dey1diwS3E.Add(color.G);
			_0023_003DzJ2Dey1diwS3E.Add(color.B);
		}
		foreach (Point3D item2 in points)
		{
			for (int i = 0; i < 2; i++)
			{
				_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item2.X);
				_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item2.Y);
				_0023_003Dzk2quabjLoI1_0024rVNFm0w3FZI_003D.Add((float)item2.Z);
				_0023_003DzJ2Dey1diwS3E.Add(color.R);
				_0023_003DzJ2Dey1diwS3E.Add(color.G);
				_0023_003DzJ2Dey1diwS3E.Add(color.B);
			}
		}
	}

	public override void Dispose()
	{
		_0023_003DzHQdR0_0024o3SV7U();
		base.Dispose();
	}

	protected internal override void Draw(DrawEntitiesParams myParams, WorkspaceDrawCallback drawCall)
	{
		DrawParams drawParams = myParams.DrawParams;
		if (drawParams.SelectionStatus != selectionStatusType.Temporary)
		{
			drawParams.RenderContext.PushModelView();
			drawParams.RenderContext.MultMatrixModelView(GetFullTransformation(myParams.Workspace.Blocks));
			if (selectedHdlSegments.Count > 0)
			{
				Color currentWireColor = drawParams.RenderContext.CurrentWireColor;
				drawParams.RenderContext.SetColorWireframe(drawParams.SelectionColor);
				float currentLineWidth = drawParams.RenderContext.CurrentLineWidth;
				foreach (Entity selectedHdlSegment in selectedHdlSegments)
				{
					if (selectedHdlSegment.IsVisible(drawParams.Parents, drawParams.Layers, attributeReferenceVisibilityType.Off))
					{
						drawParams.RenderContext.SetLineSize(drawParams.Layers.GetItemFast(selectedHdlSegment.LayerName).LineWeight * drawParams.LineWeightFactor);
						drawParams.RenderContext.DrawLineStrip(selectedHdlSegment.Vertices);
					}
				}
				drawParams.RenderContext.SetLineSize(currentLineWidth);
				drawParams.RenderContext.SetColorWireframe(currentWireColor);
			}
			bool flag = drawParams.RenderContext.HasFBO();
			for (int i = 0; i < drawDataArray.Length; i++)
			{
				if ((!HiddenSegments && i > 2 && i != 6) || drawDataArray[i] == null || !myParams.Workspace.Layers[layers[i]].Visible)
				{
					continue;
				}
				primitiveType primitiveType2 = ((i >= 6) ? primitiveType.PointList : primitiveType.LineList);
				float currentLineWidth2 = drawParams.RenderContext.CurrentLineWidth;
				float currentPointSize = drawParams.RenderContext.CurrentPointSize;
				float size = lineWeights[i] * drawParams.LineWeightFactor;
				if (primitiveType2 == primitiveType.LineList)
				{
					drawParams.RenderContext.SetLineSize(size);
				}
				else
				{
					drawParams.RenderContext.SetPointSize(size);
				}
				if (flag)
				{
					shaderType currentShader = drawParams.RenderContext.CurrentShader;
					if (drawParams.ForceGray)
					{
						drawParams.RenderContext.SetColorWireframe(Color.FromArgb(drawParams.Attributes.Color.A / 4, Color.Black));
						drawParams.RenderContext.PushBlendState();
						drawParams.RenderContext.SetState(blendStateType.Blend);
						drawParams.RenderContext.SetLineSize(drawParams.RenderContext.CurrentPointSize);
						drawParams.RenderContext.DrawSelected(drawDataArray[i], primitiveType2);
						drawParams.RenderContext.PopBlendState();
					}
					else
					{
						if (drawParams.ShaderParams != null)
						{
							drawParams.ShaderParams.Multicolor = true;
							SetShader(drawParams);
							drawParams.ShaderParams.Multicolor = false;
						}
						drawParams.RenderContext.Draw(drawDataArray[i], primitiveType2);
						drawParams.RenderContext.SetShader(currentShader);
					}
				}
				else
				{
					if (primitiveType2 == primitiveType.LineList)
					{
						drawParams.RenderContext.DrawIndeterminateAsLineList(drawDataArray[i]);
					}
					else
					{
						drawParams.RenderContext.DrawIndeterminateAsPoints(drawDataArray[i]);
					}
					drawParams.RenderContext.SetColorWireframe(Color.Black, force: true);
				}
				drawParams.RenderContext.SetLineSize(currentLineWidth2);
				drawParams.RenderContext.SetPointSize(currentPointSize);
			}
			drawParams.RenderContext.PopModelView();
		}
		base.Draw(myParams, drawCall);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new VectorViewSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982931), _hiddenSegments);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982922), _ignoreTransparency);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983137), _fillTexts);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983121), _fontAccuracy);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983110), _fillRegions);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983096), CenterlinesExtensionAmount);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983065), KeepEntityColor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983055), TreatWhiteAsBlack);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955541), _shaded);
	}

	public void UpdateViewBlock(bool add, DesignDocument design, DrawingDocument drawing)
	{
		Block block = drawing.Blocks[base.BlockName];
		if (add)
		{
			float _0023_003DzCJ_GAlyQBtZp = (float)Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, drawing.ActiveSheet.Units);
			int num = 0;
			int num2 = hdlCount - hiddenHdlCount;
			IList<HiddenLinesView.HdlCurve> list = hiddenSilho2D;
			if (list != null && list.Count > 0)
			{
				num = ViewBuilder._0023_003DzKNMpdHcfFd_0024g(block, hiddenSilho2D, originTranslation, segmentsScaleFactor, _0023_003DzCJ_GAlyQBtZp, drawing.HiddenSilhouettesLayerName, KeepEntityColor, _0023_003DzSZ0NwQM_003D: true, num2);
				num2 += num;
			}
			IList<HiddenLinesView.HdlCurve> list2 = hiddenEdges2D;
			if (list2 != null && list2.Count > 0)
			{
				num = ViewBuilder._0023_003DzKNMpdHcfFd_0024g(block, hiddenEdges2D, originTranslation, segmentsScaleFactor, _0023_003DzCJ_GAlyQBtZp, drawing.HiddenEdgesLayerName, KeepEntityColor, _0023_003DzSZ0NwQM_003D: true, num2);
				num2 += num;
			}
			IList<HiddenLinesView.HdlCurve> list3 = hiddenWires2D;
			if (list3 != null && list3.Count > 0)
			{
				num = ViewBuilder._0023_003DzKNMpdHcfFd_0024g(block, hiddenWires2D, originTranslation, segmentsScaleFactor, _0023_003DzCJ_GAlyQBtZp, drawing.HiddenWiresLayerName, KeepEntityColor, _0023_003DzSZ0NwQM_003D: true, num2);
				num2 += num;
			}
		}
		else
		{
			block.Entities.RemoveRange(hdlCount - hiddenHdlCount, hiddenHdlCount);
		}
	}

	public Block Rebuild(DesignDocument design, Sheet sheet, DrawingDocument drawing, bool async = false)
	{
		ViewBuilder viewBuilder = new ViewBuilder(design, drawing, this, sheet);
		Block result = null;
		if (async && drawing.workspace != null)
		{
			drawing.workspace.StartWork(viewBuilder);
		}
		else
		{
			viewBuilder.DoWork();
			result = viewBuilder.viewsBlocks[this];
		}
		return result;
	}

	internal Point3D[] _0023_003DzEe14bmJJRgPE(IList<Point2D> _0023_003DzrdSL0CI_003D)
	{
		Camera camera = (Camera)base.Camera.Clone();
		camera.Target = base.WindowCenter;
		camera.GetFrame(out var origin, out var camX, out var camY, out var _);
		Plane plane = new Plane(origin, camX, camY);
		camera.RecomputeViewport(viewportSize);
		camera.UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
		int[] _0023_003DzqDFBISpCePlj = HiddenLinesViewSettings._0023_003DziNJ_4d0rqJ74(viewportSize);
		Transformation transformation = (Transformation)originTranslation.Clone();
		transformation.Invert();
		transformation = new Scaling(1.0 / segmentsScaleFactor) * transformation;
		Point3D[] array = new Point3D[_0023_003DzrdSL0CI_003D.Count];
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Count; i++)
		{
			Point2D point2D = transformation * _0023_003DzrdSL0CI_003D[i];
			camera._0023_003DzWDEN4JKKoYiWQLji1w_003D_003D(point2D.X, (double)viewportSize.Height - point2D.Y, plane.Equation, viewportSize.Height, _0023_003DzqDFBISpCePlj, out array[i]);
		}
		return array;
	}
}
