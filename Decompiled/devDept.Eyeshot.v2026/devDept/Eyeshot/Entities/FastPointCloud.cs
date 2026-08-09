using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class FastPointCloud : Entity
{
	internal enum _0023_003DzAtKz90KWkOZN
	{
		None,
		RGB,
		RGBA,
		Indeterminate
	}

	private float[] pointArray;

	private byte[] rgbArray;

	private int skipPoints;

	protected EntityGraphicsData drawSelectedData;

	public PointCloud.drawingStyleType DrawingStyle { get; set; }

	public PointCloud.natureType Nature { get; internal set; }

	public float[] PointArray
	{
		get
		{
			return pointArray;
		}
		set
		{
			pointArray = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public byte[] ColorArray
	{
		get
		{
			return rgbArray;
		}
		set
		{
			if (rgbArray == null)
			{
				rgbArray = value;
				_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
			}
			else
			{
				rgbArray = value;
			}
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public int ZoomFitSpeed
	{
		get
		{
			return skipPoints;
		}
		set
		{
			skipPoints = value;
		}
	}

	public FastPointCloud(float[] pointArray)
		: base(entityNatureType.Point)
	{
		this.pointArray = pointArray;
		DrawingStyle = PointCloud.drawingStyleType.Points;
		if (pointArray != null)
		{
			skipPoints = pointArray.Length / 49152;
		}
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
	}

	public FastPointCloud(float[] pointArray, float pointSize)
		: this(pointArray)
	{
		LineWeight = pointSize;
		LineWeightMethod = colorMethodType.byEntity;
	}

	public FastPointCloud(float[] pointArray, byte[] rgbArray)
		: this(pointArray)
	{
		this.rgbArray = rgbArray;
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
	}

	public FastPointCloud(float[] pointArray, byte[] rgbArray, float pointSize)
		: this(pointArray, rgbArray)
	{
		LineWeight = pointSize;
		LineWeightMethod = colorMethodType.byEntity;
	}

	protected FastPointCloud(FastPointCloud another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		int num = another.pointArray.Length;
		pointArray = new float[num];
		Array.Copy(another.pointArray, pointArray, num);
		if (another.rgbArray != null)
		{
			int num2 = another.rgbArray.Length;
			rgbArray = new byte[num2];
			Array.Copy(another.rgbArray, rgbArray, num2);
		}
		DrawingStyle = another.DrawingStyle;
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
	}

	protected FastPointCloud(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		pointArray = (float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968402), typeof(float[]));
		rgbArray = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968379), typeof(byte[]));
		DrawingStyle = (PointCloud.drawingStyleType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968477), typeof(PointCloud.drawingStyleType));
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawSelectedData == null)
		{
			drawSelectedData = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(pointArray);
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (PointArray.Length % 3 != 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969202));
			return false;
		}
		if (ColorArray != null && ColorArray.Length != 0 && ColorArray.Length != PointArray.Length / 3 && ColorArray.Length != PointArray.Length && ColorArray.Length != PointArray.Length / 3 * 4)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969182));
			return false;
		}
		return base.IsValid(log);
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.viewportInternal.parent.HiddenLines.WireColorMethod == edgeColorMethodType.SingleColor || data.Selected)
		{
			DrawCloudSelected(data);
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		DrawHiddenLines(data);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new FastPointCloudSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		return Nature != PointCloud.natureType.Undefined;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968402), pointArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968379), rgbArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968477), DrawingStyle);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969090) + pointArray.Length / 3);
		if (rgbArray != null)
		{
			if (rgbArray.Length == pointArray.Length)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968555) + rgbArray.Length / 3);
			}
			else
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969340) + rgbArray.Length);
			}
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969305) + Nature);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969289) + _0023_003DzcPAo3gzQ86BL());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969249) + DrawingStyle);
		return stringBuilder.ToString();
	}

	internal _0023_003DzAtKz90KWkOZN _0023_003DzcPAo3gzQ86BL()
	{
		_0023_003DzAtKz90KWkOZN result = _0023_003DzAtKz90KWkOZN.None;
		if (Nature == PointCloud.natureType.Multicolor)
		{
			result = ((rgbArray.Length == pointArray.Length) ? _0023_003DzAtKz90KWkOZN.RGB : ((rgbArray.Length != pointArray.Length / 3 * 4) ? _0023_003DzAtKz90KWkOZN.Indeterminate : _0023_003DzAtKz90KWkOZN.RGBA));
		}
		return result;
	}

	public void CentroidDownsampling(double voxelSize)
	{
		_0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(voxelSize, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D: true);
	}

	public void CenterDownsampling(double voxelSize)
	{
		_0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(voxelSize, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D: false);
	}

	private void _0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(double _0023_003DzHvAfpUm5f0OK, bool _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D)
	{
		if (PointArray == null || PointArray.Length == 0)
		{
			return;
		}
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
		Utility.ComputeBoundingBox(new Identity(), PointArray, PointArray.Length, 0, out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		int num = (int)(size3D.X / _0023_003DzHvAfpUm5f0OK) + 1;
		int num2 = (int)(size3D.Y / _0023_003DzHvAfpUm5f0OK) + 1;
		int num3 = (int)(size3D.Z / _0023_003DzHvAfpUm5f0OK) + 1;
		List<int>[,,] array = new List<int>[num, num2, num3];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				for (int k = 0; k < num3; k++)
				{
					array[i, j, k] = new List<int>();
				}
			}
		}
		_0023_003DzAtKz90KWkOZN _0023_003DzAtKz90KWkOZN2 = _0023_003DzcPAo3gzQ86BL();
		for (int l = 0; l < PointArray.Length; l++)
		{
			float num4 = PointArray[l++];
			float num5 = PointArray[l++];
			float num6 = PointArray[l];
			array[(int)(((double)num4 - boxMin.X) / _0023_003DzHvAfpUm5f0OK), (int)(((double)num5 - boxMin.Y) / _0023_003DzHvAfpUm5f0OK), (int)(((double)num6 - boxMin.Z) / _0023_003DzHvAfpUm5f0OK)].Add(l - 2);
		}
		List<float> list = new List<float>();
		List<byte> list2 = new List<byte>();
		for (int m = 0; m < num; m++)
		{
			for (int n = 0; n < num2; n++)
			{
				for (int num7 = 0; num7 < num3; num7++)
				{
					List<int> list3 = array[m, n, num7];
					int count = list3.Count;
					if (count <= 0)
					{
						continue;
					}
					int num8 = list3[0];
					if (_0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D)
					{
						float num9 = 0f;
						float num10 = 0f;
						float num11 = 0f;
						foreach (int item4 in list3)
						{
							num9 += PointArray[item4];
							num10 += PointArray[item4 + 1];
							num11 += PointArray[item4 + 2];
						}
						list.Add(num9 / (float)count);
						list.Add(num10 / (float)count);
						list.Add(num11 / (float)count);
					}
					else
					{
						float item = Convert.ToSingle(boxMin.X + (double)m * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0);
						float item2 = Convert.ToSingle(boxMin.Y + (double)n * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0);
						float item3 = Convert.ToSingle(boxMin.Z + (double)num7 * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0);
						list.Add(item);
						list.Add(item2);
						list.Add(item3);
					}
					switch (_0023_003DzAtKz90KWkOZN2)
					{
					case _0023_003DzAtKz90KWkOZN.RGB:
						list2.Add(rgbArray[num8]);
						list2.Add(rgbArray[num8 + 1]);
						list2.Add(rgbArray[num8 + 2]);
						break;
					case _0023_003DzAtKz90KWkOZN.RGBA:
						list2.Add(rgbArray[num8]);
						list2.Add(rgbArray[num8 + 1]);
						list2.Add(rgbArray[num8 + 2]);
						list2.Add(rgbArray[num8 + 3]);
						break;
					case _0023_003DzAtKz90KWkOZN.Indeterminate:
						list2.Add(rgbArray[num8 / 3]);
						break;
					}
				}
			}
		}
		PointArray = list.ToArray();
		if (_0023_003DzAtKz90KWkOZN2 != _0023_003DzAtKz90KWkOZN.None)
		{
			ColorArray = list2.ToArray();
		}
	}

	public void FitCircle(out Plane pln, out double radius)
	{
		Utility.FitCircle(pointArray, out pln, out radius);
	}

	public void FitLine(out Point3D p, out Vector3D v)
	{
		Utility.FitLine(pointArray, out p, out v);
	}

	public Plane FitPlane()
	{
		return Utility.FitPlane(pointArray);
	}

	public void FitCylinder(bool refineEstimation, out Point3D center, out Vector3D axis, out double radius, out double height)
	{
		Utility.FitCylinder(pointArray, refineEstimation, out center, out axis, out radius, out height);
	}

	public void FitCylinder(bool refineEstimation, out CylindricalSurf cylindrical, out double height)
	{
		Utility.FitCylinder(pointArray, refineEstimation, out var center, out var axis, out var radius, out height);
		Plane plane = new Plane(center, axis);
		cylindrical = new CylindricalSurf(plane, radius);
	}

	public bool FitSphere(out Point3D center, out double radius)
	{
		return Utility.FitSphere(pointArray, out center, out radius);
	}

	public bool FitSphere(out SphericalSurf spherical)
	{
		Point3D center;
		double radius;
		bool result = Utility.FitSphere(pointArray, out center, out radius);
		spherical = new SphericalSurf(center, Vector3D.AxisZ, Vector3D.AxisX, radius);
		return result;
	}

	public void FitCone(out Point3D center, out Vector3D axis, out double halfAngle, out double radius)
	{
		Utility.FitCone(pointArray, out center, out axis, out halfAngle, out radius);
	}

	public void FitCone(out ConicalSurf conical)
	{
		Utility.FitCone(pointArray, out var center, out var axis, out var halfAngle, out var radius);
		Plane plane = new Plane(center, axis);
		conical = new ConicalSurf(plane, radius, 0.0 - Math.Abs(halfAngle));
	}

	public bool FitTorus(out Point3D center, out Vector3D axis, out double majorRadius, out double minorRadius)
	{
		return Utility.FitTorus(pointArray, out center, out axis, out majorRadius, out minorRadius);
	}

	public bool FitTorus(out ToroidalSurf toroidal)
	{
		Point3D center;
		Vector3D axis;
		double majorRadius;
		double minorRadius;
		bool result = Utility.FitTorus(pointArray, out center, out axis, out majorRadius, out minorRadius);
		Plane plane = new Plane(center, axis);
		toroidal = new ToroidalSurf(plane, majorRadius, minorRadius);
		return result;
	}

	private void _0023_003DzZTr16fkQpUZHJpROCQ_003D_003D()
	{
		if (pointArray != null)
		{
			if (rgbArray != null && rgbArray.Length != 0)
			{
				Nature = PointCloud.natureType.Multicolor;
			}
			else
			{
				Nature = PointCloud.natureType.Plain;
			}
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
		data.RenderContext.CompileVBO(drawData, DrawWithoutVBO, new VBOParams
		{
			vertices = pointArray,
			colors = ((Nature == PointCloud.natureType.Multicolor) ? rgbArray : null),
			primitiveMode = primitiveType.PointList
		});
		if (Nature == PointCloud.natureType.Multicolor && !data.RenderContext.HasFBO())
		{
			base.Compiling = true;
			data.RenderContext.Compile(drawSelectedData, DrawSelected, null);
			base.Compiling = false;
		}
		RegenMode = regenType.NotNeeded;
	}

	protected void DrawWithoutVBO(RenderContextBase context, object myParams)
	{
		switch (Nature)
		{
		case PointCloud.natureType.Plain:
			context.DrawPointsIndeterminate(pointArray);
			break;
		case PointCloud.natureType.Multicolor:
			if (rgbArray.Length == pointArray.Length)
			{
				context.DrawPointsWithColorsRGBIndeterminate(pointArray, rgbArray);
			}
			else if (rgbArray.Length == pointArray.Length / 3 * 4)
			{
				context.DrawPointsWithColorsRGBAIndeterminate(pointArray, rgbArray);
			}
			else
			{
				context.DrawPointsWithColorIntensitiesIndeterminate(pointArray, rgbArray);
			}
			break;
		}
	}

	protected void DrawSelected(RenderContextBase context, object myParams)
	{
		context.DrawPointsIndeterminate(pointArray);
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		Point2D[] array = new Point3D[0];
		_0023_003DzrdSL0CI_003D = array;
		Point3D[] _0023_003DzcDEsV8s_003D = new Point3D[0];
		_0023_003DzD5Gs7jmmc9uK = false;
		_0023_003DzHhJEwwk_003D = 1;
		if (pointArray != null)
		{
			Utility._0023_003Dz7Vctk9GuN7ugAAgu_0024Q_003D_003D(pointArray, out _0023_003DzcDEsV8s_003D);
			array = _0023_003DzcDEsV8s_003D;
			_0023_003DzrdSL0CI_003D = array;
			if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
			{
				return true;
			}
			base.OrientedBounding = new OrientedBoundingBox(_0023_003DzcDEsV8s_003D);
			_0023_003DzD5Gs7jmmc9uK = true;
			return true;
		}
		return false;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		verticesCoords = pointArray;
		return true;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		return Entity.ComputeBoundingBox(data, pointArray, skipPoints, out boxMin, out boxMax);
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		if (Utility.AllVerticesInFrustum(data.Frustum, data.Transformation, pointArray, pointArray.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility._0023_003DzmNbBfJeObfba6gfTR6lLqbg_003D(data.ViewFrame, data.ModelViewProj, data.Transformation, data.ScreenPolygon, data.Min, data.Max, pointArray, pointArray.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public override object Clone()
	{
		return new FastPointCloud(this);
	}

	public override object CloneWithTessellation()
	{
		return new FastPointCloud(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Dispose()
	{
		base.Dispose();
		drawSelectedData?.Dispose();
	}

	public override void TransformBy(Transformation xform)
	{
		if (pointArray != null)
		{
			float[,] floatMatrix = xform.GetFloatMatrix();
			for (int i = 0; i < pointArray.Length; i += 3)
			{
				float[] array = Transformation.ActOnLeftOne(pointArray[i], pointArray[i + 1], pointArray[i + 2], floatMatrix);
				pointArray[i] = array[0];
				pointArray[i + 1] = array[1];
				pointArray[i + 2] = array[2];
			}
		}
		base.TransformBy(xform);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		int num = pointArray.Length;
		Transformation transformation = data.Transformation;
		PlaneEquation[] frustum = data.Frustum;
		switch (DrawingStyle)
		{
		case PointCloud.drawingStyleType.Points:
		{
			if (transformation == null)
			{
				for (int k = 0; k < num; k += 3)
				{
					if (Camera._0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(pointArray[k], pointArray[k + 1], pointArray[k + 2], frustum))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix2 = transformation.GetFloatMatrix();
			for (int l = 0; l < num; l += 3)
			{
				float[] array3 = Transformation.ActOnLeftOne(pointArray[l], pointArray[l + 1], pointArray[l + 2], floatMatrix2);
				if (Camera._0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(array3[0], array3[1], array3[2], frustum))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case PointCloud.drawingStyleType.Lines:
		case PointCloud.drawingStyleType.PointsAndLines:
		{
			if (transformation == null)
			{
				for (int m = 0; m <= num - 6; m += 6)
				{
					Segment3D segment = new Segment3D(new Point3D(pointArray[m], pointArray[m + 1], pointArray[m + 2]), new Point3D(pointArray[m + 3], pointArray[m + 4], pointArray[m + 5]));
					if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix3 = transformation.GetFloatMatrix();
			for (int n = 0; n <= num - 6; n += 6)
			{
				float[] array4 = Transformation.ActOnLeftOne(pointArray[n], pointArray[n + 1], pointArray[n + 2], floatMatrix3);
				float[] array5 = Transformation.ActOnLeftOne(pointArray[n + 3], pointArray[n + 4], pointArray[n + 5], floatMatrix3);
				Segment3D segment = new Segment3D(new Point3D(array4[0], array4[1], array4[2]), new Point3D(array5[0], array5[1], array5[2]));
				if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case PointCloud.drawingStyleType.LineStrip:
		case PointCloud.drawingStyleType.PointsAndLineStrip:
		{
			if (transformation == null)
			{
				for (int i = 0; i <= num - 6; i += 3)
				{
					Segment3D segment = new Segment3D(new Point3D(pointArray[i], pointArray[i + 1], pointArray[i + 2]), new Point3D(pointArray[i + 3], pointArray[i + 4], pointArray[i + 5]));
					if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix = transformation.GetFloatMatrix();
			for (int j = 0; j <= num - 6; j += 3)
			{
				float[] array = Transformation.ActOnLeftOne(pointArray[j], pointArray[j + 1], pointArray[j + 2], floatMatrix);
				float[] array2 = Transformation.ActOnLeftOne(pointArray[j + 3], pointArray[j + 4], pointArray[j + 5], floatMatrix);
				Segment3D segment = new Segment3D(new Point3D(array[0], array[1], array[2]), new Point3D(array2[0], array2[1], array2[2]));
				if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		int num = pointArray.Length;
		Transformation transformation = data.Transformation;
		switch (DrawingStyle)
		{
		case PointCloud.drawingStyleType.Points:
		{
			if (transformation == null)
			{
				for (int k = 0; k < num; k += 3)
				{
					if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, pointArray[k], pointArray[k + 1], pointArray[k + 2], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix2 = transformation.GetFloatMatrix();
			for (int l = 0; l < num; l += 3)
			{
				float[] array3 = Transformation.ActOnLeftOne(pointArray[l], pointArray[l + 1], pointArray[l + 2], floatMatrix2);
				if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, array3[0], array3[1], array3[2], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case PointCloud.drawingStyleType.Lines:
		case PointCloud.drawingStyleType.PointsAndLines:
		{
			if (transformation == null)
			{
				for (int m = 0; m <= num - 6; m += 6)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(new Point3D(pointArray[m], pointArray[m + 1], pointArray[m + 2]), new Point3D(pointArray[m + 3], pointArray[m + 4], pointArray[m + 5]), data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix3 = transformation.GetFloatMatrix();
			for (int n = 0; n <= num - 6; n += 6)
			{
				float[] array4 = Transformation.ActOnLeftOne(pointArray[n], pointArray[n + 1], pointArray[n + 2], floatMatrix3);
				float[] array5 = Transformation.ActOnLeftOne(pointArray[n + 3], pointArray[n + 4], pointArray[n + 5], floatMatrix3);
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(new Point3D(array4[0], array4[1], array4[2]), new Point3D(array5[0], array5[1], array5[2]), data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case PointCloud.drawingStyleType.LineStrip:
		case PointCloud.drawingStyleType.PointsAndLineStrip:
		{
			if (transformation == null)
			{
				for (int i = 0; i <= num - 6; i += 3)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(new Point3D(pointArray[i], pointArray[i + 1], pointArray[i + 2]), new Point3D(pointArray[i + 3], pointArray[i + 4], pointArray[i + 5]), data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			float[,] floatMatrix = transformation.GetFloatMatrix();
			for (int j = 0; j <= num - 6; j += 3)
			{
				float[] array = Transformation.ActOnLeftOne(pointArray[j], pointArray[j + 1], pointArray[j + 2], floatMatrix);
				float[] array2 = Transformation.ActOnLeftOne(pointArray[j + 3], pointArray[j + 4], pointArray[j + 5], floatMatrix);
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(new Point3D(array[0], array[1], array[2]), new Point3D(array2[0], array2[1], array2[2]), data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		}
		return false;
	}

	public PointCloud ConvertToPointCloud()
	{
		PointCloud pointCloud = null;
		if (pointArray != null)
		{
			int num = pointArray.Length / 3;
			Point3D[] array = new Point3D[num];
			bool flag = Nature == PointCloud.natureType.Multicolor;
			for (int i = 0; i < num; i++)
			{
				double x = pointArray[3 * i];
				double y = pointArray[3 * i + 1];
				double z = pointArray[3 * i + 2];
				if (flag)
				{
					array[i] = new PointRGB(x, y, z, ColorArray[3 * i], ColorArray[3 * i + 1], ColorArray[3 * i + 2]);
				}
				else
				{
					array[i] = new Point3D(x, y, z);
				}
			}
			pointCloud = new PointCloud(array, LineWeight);
			pointCloud.CopyAttributes(this);
		}
		return pointCloud;
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
		base.Regen(data);
	}

	internal override bool AvoidSmallSizeCulling()
	{
		return pointArray.Length == 3;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		PointF minQ = data.MinQ._0023_003Dzx9P_oXY_003D();
		PointF maxQ = data.MaxQ._0023_003Dzx9P_oXY_003D();
		Entity.ComputeOffsetOnCameraAxes(data.Transformation, pointArray, pointArray.Length, data.m1, data.m2, ref minQ, ref maxQ, skipPoints);
		data.MinQ = minQ;
		data.MaxQ = maxQ;
	}

	internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzZmXx2DpbugLKXntdQQPZMqY_003D(_0023_003DzELu0Pss_003D, pointArray, pointArray.Length, _0023_003Dz7xzxLVk_003D);
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		return _0023_003DzyI0wuvHQi9AG(_0023_003DzELu0Pss_003D, pointArray, pointArray.Length, _0023_003Dz7xzxLVk_003D);
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003DzE6BhEyCW20ng(data);
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		DrawCloudSelected(data);
	}

	protected internal override void DrawWireframeSelected(DrawParams data)
	{
		DrawCloudSelected(data);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override void Render(RenderParams data)
	{
		_0023_003DzE6BhEyCW20ng(data);
	}

	private void _0023_003DzE6BhEyCW20ng(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.HasFBO())
		{
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			switch (Nature)
			{
			case PointCloud.natureType.Plain:
				switch (DrawingStyle)
				{
				case PointCloud.drawingStyleType.Points:
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.PointList);
					break;
				case PointCloud.drawingStyleType.Lines:
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.LineList);
					break;
				case PointCloud.drawingStyleType.LineStrip:
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.LineStrip);
					break;
				case PointCloud.drawingStyleType.PointsAndLines:
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.PointList);
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
					_0023_003DzELu0Pss_003D.RenderContext.SetShader(shaderType.NoLights);
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.LineList);
					break;
				case PointCloud.drawingStyleType.PointsAndLineStrip:
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.PointList);
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
					_0023_003DzELu0Pss_003D.RenderContext.SetShader(shaderType.NoLights);
					_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, primitiveType.LineStrip);
					break;
				}
				break;
			case PointCloud.natureType.Multicolor:
				switch (DrawingStyle)
				{
				case PointCloud.drawingStyleType.Points:
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.PointList, _0023_003DzELu0Pss_003D);
					break;
				case PointCloud.drawingStyleType.Lines:
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.LineList, _0023_003DzELu0Pss_003D);
					break;
				case PointCloud.drawingStyleType.LineStrip:
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.LineStrip, _0023_003DzELu0Pss_003D);
					break;
				case PointCloud.drawingStyleType.PointsAndLines:
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.PointList, _0023_003DzELu0Pss_003D);
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
					_0023_003DzELu0Pss_003D.ShaderParams.PrimitiveType = shaderPrimitiveType.Line;
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.LineList, _0023_003DzELu0Pss_003D);
					break;
				case PointCloud.drawingStyleType.PointsAndLineStrip:
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.PointList, _0023_003DzELu0Pss_003D);
					_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
					_0023_003DzELu0Pss_003D.ShaderParams.PrimitiveType = shaderPrimitiveType.Line;
					_0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType.LineStrip, _0023_003DzELu0Pss_003D);
					break;
				}
				break;
			}
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth, setShader: false);
		}
		else
		{
			PointCloud._0023_003DzE6BhEyCW20ng(_0023_003DzELu0Pss_003D, Nature, DrawingStyle, drawData, drawSelectedData, null);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawCloudSelected(data);
	}

	protected void DrawCloudSelected(DrawParams data)
	{
		if (data.RenderContext.HasFBO())
		{
			switch (Nature)
			{
			case PointCloud.natureType.Plain:
				_0023_003DzE6BhEyCW20ng(data);
				break;
			case PointCloud.natureType.Multicolor:
			{
				float currentLineWidth = data.RenderContext.CurrentLineWidth;
				switch (DrawingStyle)
				{
				case PointCloud.drawingStyleType.Points:
					data.RenderContext.DrawSelected(drawData, primitiveType.PointList);
					break;
				case PointCloud.drawingStyleType.Lines:
					data.RenderContext.SetLineSize(data.RenderContext.CurrentPointSize);
					data.RenderContext.DrawSelected(drawData, primitiveType.LineList);
					break;
				case PointCloud.drawingStyleType.LineStrip:
					data.RenderContext.SetLineSize(data.RenderContext.CurrentPointSize);
					data.RenderContext.DrawSelected(drawData, primitiveType.LineStrip);
					break;
				case PointCloud.drawingStyleType.PointsAndLines:
					data.RenderContext.DrawSelected(drawData, primitiveType.PointList);
					data.RenderContext.SetLineSize(1f);
					data.RenderContext.SetShader(shaderType.NoLights);
					data.RenderContext.DrawSelected(drawData, primitiveType.LineList);
					break;
				case PointCloud.drawingStyleType.PointsAndLineStrip:
					data.RenderContext.DrawSelected(drawData, primitiveType.PointList);
					data.RenderContext.SetLineSize(1f);
					data.RenderContext.SetShader(shaderType.NoLights);
					data.RenderContext.DrawSelected(drawData, primitiveType.LineStrip);
					break;
				}
				data.RenderContext.SetLineSize(currentLineWidth, setShader: false);
				break;
			}
			}
		}
		else
		{
			PointCloud._0023_003DzPvMAdL67h0nj(data, Nature, DrawingStyle, drawData, drawSelectedData);
		}
	}

	private void _0023_003Dzs0193W19cqu0FSo8Hg_003D_003D(primitiveType _0023_003Dz3OSFymHvmyGP, DrawParams _0023_003DzELu0Pss_003D)
	{
		bool flag = false;
		bool colorsModulatedByIntensity = false;
		bool flag2 = false;
		if (_0023_003DzELu0Pss_003D.ShaderParams != null)
		{
			if (Utility._0023_003DziO8_0024N5HjLOoQRQgn7nLiej4gvs_amz7Myw_003D_003D(pointArray, rgbArray))
			{
				if (!_0023_003DzELu0Pss_003D.Selected && Nature == PointCloud.natureType.Multicolor)
				{
					colorsModulatedByIntensity = _0023_003DzELu0Pss_003D.ShaderParams.ColorsModulatedByIntensity;
					_0023_003DzELu0Pss_003D.ShaderParams.ColorsModulatedByIntensity = true;
					flag = true;
				}
				SetShader(_0023_003DzELu0Pss_003D);
				if (flag)
				{
					_0023_003DzELu0Pss_003D.ShaderParams.ColorsModulatedByIntensity = colorsModulatedByIntensity;
				}
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.PushShader();
				_0023_003DzELu0Pss_003D.ShaderParams.Multicolor = true;
				SetShader(_0023_003DzELu0Pss_003D);
				_0023_003DzELu0Pss_003D.ShaderParams.Multicolor = false;
				flag2 = true;
			}
		}
		_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData, _0023_003Dz3OSFymHvmyGP);
		if (flag2)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PopShader();
		}
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		DrawCloudSelected(data);
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForWireframe(DrawParams _0023_003DzELu0Pss_003D)
	{
		return _0023_003Dz6B6iXtIQPPqe();
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForFlat(DrawParams _0023_003DzELu0Pss_003D)
	{
		return _0023_003Dz6B6iXtIQPPqe();
	}

	private shaderPrimitiveType _0023_003Dz6B6iXtIQPPqe()
	{
		switch (DrawingStyle)
		{
		case PointCloud.drawingStyleType.Lines:
		case PointCloud.drawingStyleType.LineStrip:
			return shaderPrimitiveType.Line;
		case PointCloud.drawingStyleType.Points:
			return shaderPrimitiveType.Point;
		default:
			return shaderPrimitiveType.Point;
		}
	}

	public FastPointCloud[] Subdivide(int maxNumPoints)
	{
		NodeBase _0023_003Dzalvl9z8_003D = new NodeBase(base.BoxMin, base.BoxMax);
		bool[] _0023_003DzH9i1lhU_003D = new bool[PointArray.Length / 3];
		List<FastPointCloud> list = new List<FastPointCloud>();
		if (ColorArray != null && ColorArray.Length == PointArray.Length)
		{
			_0023_003DzDPVzMxj1jJ33(_0023_003Dzalvl9z8_003D, PointArray, ColorArray, _0023_003DzH9i1lhU_003D, list, maxNumPoints);
		}
		else if (ColorArray != null && ColorArray.Length == PointArray.Length / 3)
		{
			_0023_003DzwCuFO__1ayqPJ9cIMrqT1fc_003D(_0023_003Dzalvl9z8_003D, PointArray, ColorArray, _0023_003DzH9i1lhU_003D, list, maxNumPoints);
		}
		else
		{
			_0023_003DzyWSP1yCxygvX(_0023_003Dzalvl9z8_003D, PointArray, _0023_003DzH9i1lhU_003D, list, maxNumPoints);
		}
		return list.ToArray();
	}

	private void _0023_003DzyWSP1yCxygvX(NodeBase _0023_003Dzalvl9z8_003D, float[] _0023_003DzrdSL0CI_003D, bool[] _0023_003DzH9i1lhU_003D, List<FastPointCloud> _0023_003Dza0r4mvw_003D, int _0023_003DzLMo0v2w_003D)
	{
		_0023_003Dzalvl9z8_003D.GetBoudingBox(out var boxMin, out var boxMax);
		NodeBase[] array = _0023_003DzvUPMOzuyrZsFxcx3KQ_003D_003D((Point3D)boxMin, (Point3D)boxMax);
		for (int i = 0; i < 8; i++)
		{
			array[i].GetBoudingBox(out var boxMin2, out var boxMax2);
			List<float> list = new List<float>();
			for (int j = 0; j < _0023_003DzrdSL0CI_003D.Length; j += 3)
			{
				if (!_0023_003DzH9i1lhU_003D[j / 3] && _0023_003DzrfhmnHeX0Pzt(_0023_003DzrdSL0CI_003D[j], _0023_003DzrdSL0CI_003D[j + 1], _0023_003DzrdSL0CI_003D[j + 2], (Point3D)boxMin2, (Point3D)boxMax2))
				{
					list.AddRange(new float[3]
					{
						_0023_003DzrdSL0CI_003D[j],
						_0023_003DzrdSL0CI_003D[j + 1],
						_0023_003DzrdSL0CI_003D[j + 2]
					});
					_0023_003DzH9i1lhU_003D[j / 3] = true;
				}
			}
			if (list.Count > 3)
			{
				FastPointCloud fastPointCloud = new FastPointCloud(list.ToArray());
				fastPointCloud.CopyAttributes(this);
				if (fastPointCloud.PointArray.Length / 3 > _0023_003DzLMo0v2w_003D)
				{
					NodeBase _0023_003Dzalvl9z8_003D2 = new NodeBase(boxMin2, boxMax2);
					bool[] _0023_003DzH9i1lhU_003D2 = new bool[fastPointCloud.PointArray.Length / 3];
					_0023_003DzyWSP1yCxygvX(_0023_003Dzalvl9z8_003D2, fastPointCloud.PointArray, _0023_003DzH9i1lhU_003D2, _0023_003Dza0r4mvw_003D, _0023_003DzLMo0v2w_003D);
				}
				else
				{
					_0023_003Dza0r4mvw_003D.Add(fastPointCloud);
				}
			}
		}
	}

	private void _0023_003DzDPVzMxj1jJ33(NodeBase _0023_003Dzalvl9z8_003D, float[] _0023_003DzrdSL0CI_003D, byte[] _0023_003DzZQ2HyLn4R0pl, bool[] _0023_003DzH9i1lhU_003D, List<FastPointCloud> _0023_003Dza0r4mvw_003D, int _0023_003DzLMo0v2w_003D)
	{
		_0023_003Dzalvl9z8_003D.GetBoudingBox(out var boxMin, out var boxMax);
		NodeBase[] array = _0023_003DzvUPMOzuyrZsFxcx3KQ_003D_003D((Point3D)boxMin, (Point3D)boxMax);
		for (int i = 0; i < 8; i++)
		{
			array[i].GetBoudingBox(out var boxMin2, out var boxMax2);
			List<float> list = new List<float>();
			List<byte> list2 = new List<byte>();
			for (int j = 0; j < _0023_003DzrdSL0CI_003D.Length; j += 3)
			{
				if (!_0023_003DzH9i1lhU_003D[j / 3] && _0023_003DzrfhmnHeX0Pzt(_0023_003DzrdSL0CI_003D[j], _0023_003DzrdSL0CI_003D[j + 1], _0023_003DzrdSL0CI_003D[j + 2], (Point3D)boxMin2, (Point3D)boxMax2))
				{
					list.AddRange(new float[3]
					{
						_0023_003DzrdSL0CI_003D[j],
						_0023_003DzrdSL0CI_003D[j + 1],
						_0023_003DzrdSL0CI_003D[j + 2]
					});
					list2.AddRange(new byte[3]
					{
						_0023_003DzZQ2HyLn4R0pl[j],
						_0023_003DzZQ2HyLn4R0pl[j + 1],
						_0023_003DzZQ2HyLn4R0pl[j + 2]
					});
					_0023_003DzH9i1lhU_003D[j / 3] = true;
				}
			}
			if (list.Count > 3)
			{
				FastPointCloud fastPointCloud = new FastPointCloud(list.ToArray(), list2.ToArray());
				fastPointCloud.CopyAttributes(this);
				if (fastPointCloud.PointArray.Length / 3 > _0023_003DzLMo0v2w_003D)
				{
					NodeBase _0023_003Dzalvl9z8_003D2 = new NodeBase(boxMin2, boxMax2);
					bool[] _0023_003DzH9i1lhU_003D2 = new bool[fastPointCloud.PointArray.Length / 3];
					_0023_003DzDPVzMxj1jJ33(_0023_003Dzalvl9z8_003D2, fastPointCloud.PointArray, fastPointCloud.ColorArray, _0023_003DzH9i1lhU_003D2, _0023_003Dza0r4mvw_003D, _0023_003DzLMo0v2w_003D);
				}
				else
				{
					_0023_003Dza0r4mvw_003D.Add(fastPointCloud);
				}
			}
		}
	}

	private void _0023_003DzwCuFO__1ayqPJ9cIMrqT1fc_003D(NodeBase _0023_003Dzalvl9z8_003D, float[] _0023_003DzrdSL0CI_003D, byte[] _0023_003DzZQ2HyLn4R0pl, bool[] _0023_003DzH9i1lhU_003D, List<FastPointCloud> _0023_003Dza0r4mvw_003D, int _0023_003DzLMo0v2w_003D)
	{
		_0023_003Dzalvl9z8_003D.GetBoudingBox(out var boxMin, out var boxMax);
		NodeBase[] array = _0023_003DzvUPMOzuyrZsFxcx3KQ_003D_003D((Point3D)boxMin, (Point3D)boxMax);
		for (int i = 0; i < 8; i++)
		{
			array[i].GetBoudingBox(out var boxMin2, out var boxMax2);
			List<float> list = new List<float>();
			List<byte> list2 = new List<byte>();
			for (int j = 0; j < _0023_003DzrdSL0CI_003D.Length; j += 3)
			{
				if (!_0023_003DzH9i1lhU_003D[j / 3] && _0023_003DzrfhmnHeX0Pzt(_0023_003DzrdSL0CI_003D[j], _0023_003DzrdSL0CI_003D[j + 1], _0023_003DzrdSL0CI_003D[j + 2], (Point3D)boxMin2, (Point3D)boxMax2))
				{
					list.AddRange(new float[3]
					{
						_0023_003DzrdSL0CI_003D[j],
						_0023_003DzrdSL0CI_003D[j + 1],
						_0023_003DzrdSL0CI_003D[j + 2]
					});
					list2.AddRange(new byte[1] { _0023_003DzZQ2HyLn4R0pl[j / 3] });
					_0023_003DzH9i1lhU_003D[j / 3] = true;
				}
			}
			if (list.Count > 3)
			{
				FastPointCloud fastPointCloud = new FastPointCloud(list.ToArray(), list2.ToArray());
				fastPointCloud.CopyAttributes(this);
				if (fastPointCloud.PointArray.Length / 3 > _0023_003DzLMo0v2w_003D)
				{
					NodeBase _0023_003Dzalvl9z8_003D2 = new NodeBase(boxMin2, boxMax2);
					bool[] _0023_003DzH9i1lhU_003D2 = new bool[fastPointCloud.PointArray.Length / 3];
					_0023_003DzwCuFO__1ayqPJ9cIMrqT1fc_003D(_0023_003Dzalvl9z8_003D2, fastPointCloud.PointArray, fastPointCloud.ColorArray, _0023_003DzH9i1lhU_003D2, _0023_003Dza0r4mvw_003D, _0023_003DzLMo0v2w_003D);
				}
				else
				{
					_0023_003Dza0r4mvw_003D.Add(fastPointCloud);
				}
			}
		}
	}

	private NodeBase[] _0023_003DzvUPMOzuyrZsFxcx3KQ_003D_003D(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		NodeBase[] obj = new NodeBase[8]
		{
			new NodeBase(_0023_003DzF7v9r2A_003D, Point3D.MidPoint(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D)),
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		double num = (_0023_003Dz8dK2uhU_003D.X - _0023_003DzF7v9r2A_003D.X) / 2.0;
		double num2 = (_0023_003Dz8dK2uhU_003D.Y - _0023_003DzF7v9r2A_003D.Y) / 2.0;
		double num3 = (_0023_003Dz8dK2uhU_003D.Z - _0023_003DzF7v9r2A_003D.Z) / 2.0;
		obj[1] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003DzF7v9r2A_003D.Y, _0023_003DzF7v9r2A_003D.Z), new Point3D(_0023_003Dz8dK2uhU_003D.X, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003DzF7v9r2A_003D.Z + num3));
		obj[2] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003DzF7v9r2A_003D.Z), new Point3D(_0023_003Dz8dK2uhU_003D.X, _0023_003Dz8dK2uhU_003D.Y, _0023_003DzF7v9r2A_003D.Z + num3));
		obj[3] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003DzF7v9r2A_003D.Z), new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003Dz8dK2uhU_003D.Y, _0023_003DzF7v9r2A_003D.Z + num3));
		obj[4] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.Y, _0023_003DzF7v9r2A_003D.Z + num3), new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003Dz8dK2uhU_003D.Z));
		obj[5] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003DzF7v9r2A_003D.Y, _0023_003DzF7v9r2A_003D.Z + num3), new Point3D(_0023_003Dz8dK2uhU_003D.X, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003Dz8dK2uhU_003D.Z));
		obj[6] = new NodeBase(Point3D.MidPoint(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D), _0023_003Dz8dK2uhU_003D);
		obj[7] = new NodeBase(new Point3D(_0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.Y + num2, _0023_003DzF7v9r2A_003D.Z + num3), new Point3D(_0023_003DzF7v9r2A_003D.X + num, _0023_003Dz8dK2uhU_003D.Y, _0023_003Dz8dK2uhU_003D.Z));
		return obj;
	}

	private bool _0023_003DzrfhmnHeX0Pzt(float _0023_003DzBJFJHwk_003D, float _0023_003Dz40R7bAU_003D, float _0023_003DzId5C3LA_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		if ((double)_0023_003DzBJFJHwk_003D > _0023_003DzF7v9r2A_003D.X && (double)_0023_003DzBJFJHwk_003D < _0023_003Dz8dK2uhU_003D.X && (double)_0023_003Dz40R7bAU_003D > _0023_003DzF7v9r2A_003D.Y && (double)_0023_003Dz40R7bAU_003D < _0023_003Dz8dK2uhU_003D.Y && (double)_0023_003DzId5C3LA_003D > _0023_003DzF7v9r2A_003D.Z && (double)_0023_003DzId5C3LA_003D < _0023_003Dz8dK2uhU_003D.Z)
		{
			return true;
		}
		return false;
	}
}
