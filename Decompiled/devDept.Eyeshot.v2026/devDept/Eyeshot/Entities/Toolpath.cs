using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Toolpath : Entity
{
	[Serializable]
	public class CircularMotion : Motion
	{
		public double Depth { get; set; }

		public Plane Plane { get; set; }

		public double Radius { get; set; }

		public Interval Angle { get; set; }

		public Vector3D StartNormal { get; set; }

		public Vector3D EndNormal { get; set; }

		public override Point3D StartPoint => Ellipse.PointOnEllipseAt(Angle.t0, Plane, Radius, Radius);

		public override Point3D EndPoint => Ellipse.PointOnEllipseAt(Angle.t1, Plane, Radius, Radius) + Plane.AxisZ * Depth;

		public CircularMotion(Plane plane, double radius, Interval angle, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = plane;
			Radius = radius;
			Angle = angle;
		}

		public CircularMotion(Plane arcPlane, Point3D center, double radius, Interval angle, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = new Plane(center, arcPlane.AxisX, arcPlane.AxisY);
			Radius = radius;
			Angle = angle;
		}

		public CircularMotion(Plane plane, double radius, Interval angle, Vector3D start, Vector3D end, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = plane;
			Radius = radius;
			Angle = angle;
			StartNormal = start;
			EndNormal = end;
		}

		public CircularMotion(Plane arcPlane, Point3D center, double radius, Interval angle, Vector3D start, Vector3D end, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = new Plane(center, arcPlane.AxisX, arcPlane.AxisY);
			Radius = radius;
			Angle = angle;
			StartNormal = start;
			EndNormal = end;
		}

		public CircularMotion(Plane plane, double radius, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = plane;
			Radius = radius;
		}

		public CircularMotion(Plane arcPlane, Point3D center, double radius, Vector3D normal, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			Plane = new Plane(center, arcPlane.AxisX, arcPlane.AxisY);
			Radius = radius;
			StartNormal = normal;
			EndNormal = (Vector3D)normal.Clone();
		}

		protected CircularMotion(CircularMotion another)
			: base(another)
		{
			Plane = (Plane)another.Plane.Clone();
			Radius = another.Radius;
			Angle = another.Angle;
			Depth = another.Depth;
			StartNormal = another.StartNormal;
			EndNormal = another.EndNormal;
		}

		internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
		{
			double scaleFactor = Math.Abs(_0023_003DzLS0sR0pzioXc.ScaleFactorX);
			bool num = _0023_003DzLS0sR0pzioXc.IsScaleFactorUniform() || _0023_003DzLS0sR0pzioXc.IsScaleFactorUniformForPlanar(Plane, ref scaleFactor);
			Plane.TransformBy(_0023_003DzLS0sR0pzioXc);
			StartNormal?.TransformBy(_0023_003DzLS0sR0pzioXc);
			EndNormal?.TransformBy(_0023_003DzLS0sR0pzioXc);
			if (num)
			{
				Radius *= scaleFactor;
			}
		}

		internal override void _0023_003Dz41Aikc8L0dNl(Plane _0023_003DzWyu8GpqY0Yoha79NLIWLdvM_003D)
		{
			base.Code = (Vector3D.AreOpposite(_0023_003DzWyu8GpqY0Yoha79NLIWLdvM_003D.AxisZ, Plane.AxisZ) ? motionType.G02 : motionType.G03);
		}

		internal override Vector3D _0023_003DznwYbRgIzSbCB(double _0023_003DzNDQ_E88_003D)
		{
			return (0.0 - Radius) * Math.Sin(_0023_003DzNDQ_E88_003D) * Plane.AxisX + Radius * Math.Cos(_0023_003DzNDQ_E88_003D) * Plane.AxisY;
		}

		internal override Vector3D _0023_003Dz_0024SVYRCY_003D()
		{
			return _0023_003DznwYbRgIzSbCB(Angle.t0);
		}

		internal override Vector3D _0023_003Dzmz8dUcc_003D()
		{
			return _0023_003DznwYbRgIzSbCB(Angle.t1);
		}

		internal override Point3D[] _0023_003DzfHSvFLY_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
		{
			Arc arc = new Arc(Plane, Point2D.Origin, Radius, Angle.t0, Angle.t1);
			arc.Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
			if (Depth != 0.0)
			{
				int num = arc.Vertices.Length;
				double num2 = Math.Atan2(Depth / Length(), arc.Vertices[0].DistanceTo(arc.Vertices[1]));
				for (int i = 0; i < num; i++)
				{
					Transformation xform = Transformation.CreateRotation(0.0 - num2, arc.Vertices[i], arc.Center);
					arc.Vertices[i].TransformBy(xform);
					arc.Vertices[i].Z += (arc.Plane.AxisZ * i * Depth / (num - 1)).Z;
				}
				if (StartNormal != null && EndNormal != null)
				{
					_0023_003DzwS2mgIjG37bg(arc);
				}
			}
			else if (StartNormal != null && EndNormal != null)
			{
				_0023_003DzwS2mgIjG37bg(arc);
			}
			return arc.Vertices;
		}

		private void _0023_003DzwS2mgIjG37bg(Arc _0023_003DzN4MDZ_0024c_003D)
		{
			int num = _0023_003DzN4MDZ_0024c_003D.Vertices.Length;
			Vector3D axisZ = _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ;
			Vector3D startTangent = _0023_003DzN4MDZ_0024c_003D.StartTangent;
			Vector3D vector3D = Vector3D.Cross(axisZ, startTangent);
			double num2 = StartNormal * startTangent;
			double num3 = StartNormal * vector3D;
			double num4 = StartNormal * axisZ;
			Vector3D endTangent = _0023_003DzN4MDZ_0024c_003D.EndTangent;
			Vector3D vector3D2 = Vector3D.Cross(axisZ, endTangent);
			double num5 = EndNormal * endTangent;
			double num6 = EndNormal * vector3D2;
			double num7 = EndNormal * axisZ;
			for (int i = 0; i < num; i++)
			{
				double num8 = (double)i / (double)(num - 1);
				double num9 = (1.0 - num8) * num2 + num8 * num5;
				double num10 = (1.0 - num8) * num3 + num8 * num6;
				double num11 = (1.0 - num8) * num4 + num8 * num7;
				Vector3D tangent = ((PointTangent)_0023_003DzN4MDZ_0024c_003D.Vertices[i]).Tangent;
				Vector3D vector3D3 = Vector3D.Cross(axisZ, tangent);
				Vector3D vector3D4 = num9 * tangent + num10 * vector3D3 + num11 * axisZ;
				vector3D4.Normalize();
				_0023_003DzN4MDZ_0024c_003D.Vertices[i] = new PointNormal(_0023_003DzN4MDZ_0024c_003D.Vertices[i].X, _0023_003DzN4MDZ_0024c_003D.Vertices[i].Y, _0023_003DzN4MDZ_0024c_003D.Vertices[i].Z, vector3D4.X, vector3D4.Y, vector3D4.Z);
			}
		}

		public override object Clone()
		{
			return new CircularMotion(this);
		}

		public override MotionSurrogate ConvertToSurrogate()
		{
			return new CircularMotionSurrogate(this);
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981996), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981933), base.Code, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981914), base.Speed, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981894), base.Feed, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), Plane, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), Radius, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971719), Angle);
		}

		public override double Length()
		{
			double num = Radius * Angle.Length;
			if (Depth != 0.0)
			{
				return Math.Sqrt(num * num + Depth * Depth);
			}
			return num;
		}
	}

	[Serializable]
	public class LinearMotion : Motion
	{
		public Point3D From { get; set; }

		public Point3D To { get; set; }

		public override Point3D StartPoint => From;

		public override Point3D EndPoint => To;

		public LinearMotion(Point3D from, Point3D to, motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
			: base(code, speed, feed, codeLine)
		{
			From = from;
			To = to;
		}

		protected LinearMotion(LinearMotion another)
			: base(another)
		{
			From = (Point3D)another.From.Clone();
			To = (Point3D)another.To.Clone();
		}

		internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
		{
			From.TransformBy(_0023_003DzLS0sR0pzioXc);
			To.TransformBy(_0023_003DzLS0sR0pzioXc);
		}

		internal override void _0023_003Dz41Aikc8L0dNl(Plane _0023_003DzWyu8GpqY0Yoha79NLIWLdvM_003D)
		{
		}

		internal override Vector3D _0023_003DznwYbRgIzSbCB(double _0023_003DzNDQ_E88_003D)
		{
			return (To - From).AsVector;
		}

		internal override Vector3D _0023_003Dz_0024SVYRCY_003D()
		{
			return _0023_003DznwYbRgIzSbCB(0.0);
		}

		internal override Vector3D _0023_003Dzmz8dUcc_003D()
		{
			return _0023_003Dz_0024SVYRCY_003D();
		}

		internal override Point3D[] _0023_003DzfHSvFLY_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
		{
			if (!(StartPoint is PointNormal pointNormal) || !(EndPoint is PointNormal pointNormal2) || Vector3D.AreCoincident(pointNormal.Normal, pointNormal2.Normal))
			{
				return new Point3D[2] { StartPoint, EndPoint };
			}
			Point3D[] array = new Point3D[5];
			Segment3D segment3D = new Segment3D(StartPoint, EndPoint);
			for (int i = 0; i < 5; i++)
			{
				double t = (double)i / 4.0;
				Point3D point3D = segment3D.PointAt(t);
				Vector3D vector3D = Utility.Slerp(pointNormal.Normal, pointNormal2.Normal, t);
				array[i] = new PointNormal(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
			}
			return array;
		}

		public override object Clone()
		{
			return new LinearMotion(this);
		}

		public override MotionSurrogate ConvertToSurrogate()
		{
			return new LinearMotionSurrogate(this);
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981903), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981933), base.Code, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981914), base.Speed, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981894), base.Feed, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982088), From, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982065), To);
		}

		public override double Length()
		{
			return new Vector3D(StartPoint, EndPoint).Length;
		}
	}

	[Serializable]
	public abstract class Motion : ICloneable
	{
		internal double lengthUpTo;

		protected internal Point3D[] points;

		public int PrintLayer { get; set; }

		public float PrintExtrusionRadiusX { get; set; }

		public float PrintExtrusionRadiusY { get; set; }

		public double Speed { get; set; }

		public double Feed { get; set; }

		public motionType Code { get; set; }

		public string CodeLine { get; set; }

		public virtual Point3D StartPoint { get; }

		public virtual Point3D EndPoint { get; }

		public approachType Approach { get; set; }

		protected Motion(motionType code, double speed = 0.0, double feed = 0.0, string codeLine = "")
		{
			Code = code;
			Speed = speed;
			Feed = feed;
			CodeLine = codeLine;
		}

		protected Motion(Motion another)
		{
			CopyFrom(another);
		}

		public void CopyFrom(Motion another)
		{
			Code = another.Code;
			Speed = another.Speed;
			Feed = another.Feed;
			CodeLine = another.CodeLine;
			Approach = another.Approach;
		}

		internal abstract void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc);

		internal abstract void _0023_003Dz41Aikc8L0dNl(Plane _0023_003DzWyu8GpqY0Yoha79NLIWLdvM_003D);

		internal abstract Vector3D _0023_003DznwYbRgIzSbCB(double _0023_003DzNDQ_E88_003D);

		internal abstract Vector3D _0023_003Dz_0024SVYRCY_003D();

		internal abstract Vector3D _0023_003Dzmz8dUcc_003D();

		internal abstract Point3D[] _0023_003DzfHSvFLY_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);

		public abstract object Clone();

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982076), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981933), Code, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981914), Speed, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981894), Feed);
		}

		public abstract double Length();

		public abstract MotionSurrogate ConvertToSurrogate();
	}

	protected internal EntityGraphicsData drawRapidData;

	protected internal EntityGraphicsData drawLeadData;

	protected internal EntityGraphicsData drawRampData;

	internal Point3D[] allVertices;

	public int Tool { get; set; }

	public List<Motion> MotionList { get; set; }

	public bool ShowPoints { get; set; }

	public Color RapidColor { get; set; } = Color.Red;

	public Color LeadColor { get; set; } = Color.LimeGreen;

	public Color RampColor { get; set; } = Color.DarkViolet;

	public Point3D StartPoint => MotionList.First().StartPoint;

	public Point3D EndPoint => MotionList.Last().EndPoint;

	[CLSCompliant(false)]
	public ushort RapidPattern { get; set; } = 3855;

	public Transformation Transformation { get; set; } = new Identity();

	public Toolpath(ICollection<Motion> motions, int tool = 0)
		: base(entityNatureType.Wire)
	{
		MotionList = new List<Motion>(motions);
		Tool = tool;
	}

	protected Toolpath(Toolpath another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		MotionList = new List<Motion>(another.MotionList.Count);
		for (int i = 0; i < another.MotionList.Count; i++)
		{
			MotionList.Add((Motion)another.MotionList[i].Clone());
		}
		Tool = another.Tool;
		RapidColor = another.RapidColor;
		RapidPattern = another.RapidPattern;
		ShowPoints = another.ShowPoints;
		if (!keepTessellation)
		{
			return;
		}
		allVertices = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(another.allVertices);
		for (int j = 0; j < another.MotionList.Count; j++)
		{
			if (another.MotionList[j] is CircularMotion circularMotion)
			{
				((CircularMotion)MotionList[j]).points = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(circularMotion.points);
			}
		}
	}

	protected Toolpath(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		MotionList = (List<Motion>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982045), typeof(List<Motion>));
		Tool = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982031));
		RapidColor = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981729), typeof(Color));
		RapidPattern = (ushort)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981715), typeof(ushort));
		ShowPoints = (bool)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981703), typeof(bool));
		Transformation = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), typeof(Transformation));
	}

	protected internal Toolpath(ToolpathSurrogate surrogate)
		: this(surrogate.MotionList, surrogate.Tool)
	{
	}

	public override void Dispose()
	{
		drawRapidData?.Dispose();
		drawLeadData?.Dispose();
		drawRampData?.Dispose();
		base.Dispose();
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982045), MotionList);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982031), Tool);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981729), RapidColor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981715), RapidPattern);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981703), ShowPoints);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), Transformation);
	}

	public override object Clone()
	{
		return new Toolpath(this);
	}

	public override object CloneWithTessellation()
	{
		return new Toolpath(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Motion motion in MotionList)
		{
			motion._0023_003DzUNQ_t5U_003D(xform);
		}
		base.TransformBy(xform);
	}

	private protected override void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
		base._0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(_0023_003DzLS0sR0pzioXc, _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D);
		if (_0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
		{
			return;
		}
		if (allVertices != null)
		{
			Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(allVertices, _0023_003DzLS0sR0pzioXc);
		}
		foreach (Motion motion in MotionList)
		{
			if (motion is CircularMotion circularMotion)
			{
				Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(circularMotion.points, _0023_003DzLS0sR0pzioXc);
			}
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transformation);
		Color currentWireColor = data.RenderContext.CurrentWireColor;
		data.RenderContext.Draw(drawData);
		if (RapidPattern != ushort.MaxValue)
		{
			data.RenderContext.SetLineStipple(1, RapidPattern, null);
			data.RenderContext.EnableLineStipple(enable: true);
		}
		if (data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(RapidColor);
		}
		data.RenderContext.Draw(drawRapidData);
		if (RapidPattern != ushort.MaxValue)
		{
			data.RenderContext.EnableLineStipple(enable: false);
		}
		if (data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(LeadColor);
		}
		data.RenderContext.Draw(drawLeadData);
		if (data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(RampColor);
		}
		data.RenderContext.Draw(drawRampData);
		if (ShowPoints)
		{
			data.RenderContext.SetColorWireframe(data.Viewport.Background.GetContrastColor());
			data.RenderContext.SetShader(shaderType.NoLightsThickPoints);
			data.RenderContext.SetPointSize((float)data.Viewport.VertexSize * data.viewportInternal.parent.GetScalingLevel().Height, setShader: false);
			data.RenderContext.SetState(rasterizerStateType.CW_PolygonFill_NoCullFace_NoPolygonOffset);
			base.DrawVertices(data);
			data.RenderContext.SetShader(shaderType.NoLights);
		}
		if (data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(currentWireColor);
		}
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transformation);
		for (int i = 0; i < MotionList.Count - 1; i++)
		{
			Motion motion = MotionList[i];
			Motion motion2 = MotionList[i + 1];
			if (motion.Code != motionType.G01 && motion.Code != motionType.G02 && motion.Code != motionType.G03)
			{
				continue;
			}
			Vector3D vector3D = motion._0023_003Dzmz8dUcc_003D();
			Vector3D vector3D2 = motion2._0023_003Dz_0024SVYRCY_003D();
			if (!vector3D.IsZero && !vector3D2.IsZero)
			{
				vector3D.Normalize();
				vector3D2.Normalize();
				if (Vector3D.AngleBetween(vector3D, vector3D2) > 0.8660254037844386)
				{
					Utility.DrawArrowOnView(data, vector3D, motion.EndPoint);
				}
			}
		}
		if (MotionList.Last() is LinearMotion { Code: motionType.G01 } linearMotion)
		{
			Vector3D vector3D3 = new Vector3D(linearMotion.From, linearMotion.To);
			if (!vector3D3.IsZero)
			{
				vector3D3.Normalize();
				Utility.DrawArrowOnView(data, vector3D3, linearMotion.To);
			}
		}
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transformation);
		if (RapidPattern != ushort.MaxValue)
		{
			data.RenderContext.SetLineStipple(1, RapidPattern, null);
			data.RenderContext.EnableLineStipple(enable: true);
		}
		data.RenderContext.Draw(drawRapidData);
		if (RapidPattern != ushort.MaxValue)
		{
			data.RenderContext.EnableLineStipple(enable: false);
		}
		data.RenderContext.Draw(drawData);
		data.RenderContext.Draw(drawLeadData);
		data.RenderContext.Draw(drawRampData);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transformation);
		base.DrawVertices(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(Transformation);
		double normalLength = GetNormalLength();
		foreach (Motion motion in MotionList)
		{
			if (motion is CircularMotion circularMotion && circularMotion.StartNormal != null && circularMotion.EndNormal != null)
			{
				data.RenderContext.DrawLine(circularMotion.StartPoint, circularMotion.StartPoint + circularMotion.StartNormal * normalLength);
				data.RenderContext.DrawLine(circularMotion.EndPoint, circularMotion.EndPoint + circularMotion.EndNormal * normalLength);
			}
			else if (motion is LinearMotion { StartPoint: PointNormal startPoint, EndPoint: PointNormal endPoint })
			{
				data.RenderContext.DrawLine(startPoint, startPoint + startPoint.Normal * normalLength);
				data.RenderContext.DrawLine(endPoint, endPoint + endPoint.Normal * normalLength);
			}
		}
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		List<Point3D> list = new List<Point3D>(MotionList.Count * 2);
		foreach (Motion motion in MotionList)
		{
			if (motion is CircularMotion { Angle: { Length: var length } } circularMotion)
			{
				list.Add(Ellipse.PointOnEllipseAt(circularMotion.Angle.t0 + 0.0 * length / 2.0, circularMotion.Plane, circularMotion.Radius, circularMotion.Radius));
				list.Add(Ellipse.PointOnEllipseAt(circularMotion.Angle.t0 + length / 2.0, circularMotion.Plane, circularMotion.Radius, circularMotion.Radius));
				list.Add(Ellipse.PointOnEllipseAt(circularMotion.Angle.t0 + 2.0 * length / 2.0, circularMotion.Plane, circularMotion.Radius, circularMotion.Radius));
			}
			else if (motion is LinearMotion linearMotion)
			{
				list.Add(linearMotion.From);
			}
		}
		return list.ToArray();
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (allVertices != null)
		{
			return allVertices.Length != 0;
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new ToolpathSurrogate(this);
	}

	public override void Regen(RegenParams data)
	{
		_vertices = new Point3D[MotionList.Count + 1];
		for (int i = 0; i < MotionList.Count; i++)
		{
			Motion motion = MotionList[i];
			motion.points = motion._0023_003DzfHSvFLY_003D(data.Deviation);
			int num = motion.points.Length;
			for (int j = 0; j < num; j++)
			{
				Point3D point3D = motion.points[j];
				if (point3D is PointNormal pointNormal)
				{
					motion.points[j] = new PointCL(pointNormal.X, pointNormal.Y, pointNormal.Z, pointNormal.Nx, pointNormal.Ny, pointNormal.Nz, Tool, motion, i);
				}
				else
				{
					motion.points[j] = new PointCL(point3D.X, point3D.Y, point3D.Z, Tool, motion, i);
				}
			}
			if (i == 0)
			{
				_vertices[0] = (Point3D)motion.points.First().Clone();
			}
			_vertices[i + 1] = (Point3D)motion.points.Last().Clone();
		}
		allVertices = _0023_003Dz6vmoHJQOfQV04W37tQ_003D_003D();
		base.Regen(data);
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzELu0Pss_003D.PushTransformation(Transformation);
		bool result = base.FindClosestVertex(_0023_003DzELu0Pss_003D, _0023_003Dz7xzxLVk_003D);
		_0023_003DzELu0Pss_003D.PopTransformation();
		return result;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		float[] array = new float[allVertices.Length * 3];
		for (int i = 0; i < allVertices.Length; i++)
		{
			Point3D point3D = (Point3D)allVertices[i].Clone();
			point3D.TransformBy(Transformation);
			array[i * 3] = (float)point3D.X;
			array[i * 3 + 1] = (float)point3D.Y;
			array[i * 3 + 2] = (float)point3D.Z;
		}
		verticesCoords = array;
		return true;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(data._0023_003Dz0v5zcfYmTwCF(Transformation), allVertices, out boxMin, out boxMax);
		return true;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		data.PushTransformation(Transformation);
		Entity.ComputeOffsetOnCameraAxes(data, allVertices, allVertices.Length);
		data.PopTransformation();
	}

	private Point3D[] _0023_003Dz6vmoHJQOfQV04W37tQ_003D_003D()
	{
		List<Point3D> list = new List<Point3D>(MotionList.Count);
		double num = 0.0;
		foreach (Motion motion2 in MotionList)
		{
			motion2.lengthUpTo = num;
			num += motion2.Length();
			for (int i = 0; i < motion2.points.Length - 1; i++)
			{
				list.Add((Point3D)motion2.points[i].Clone());
			}
		}
		if (MotionList.Count > 0)
		{
			Motion motion = MotionList.Last();
			list.Add((Point3D)motion.points.Last().Clone());
		}
		return list.ToArray();
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawRapidData == null)
		{
			drawRapidData = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawLeadData == null)
		{
			drawLeadData = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawRampData == null)
		{
			drawRampData = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		List<Point3D> list = new List<Point3D>(MotionList.Count * 2);
		List<Point3D> list2 = new List<Point3D>(MotionList.Count * 2);
		List<Point3D> list3 = new List<Point3D>(MotionList.Count * 2);
		List<Point3D> list4 = new List<Point3D>(MotionList.Count * 2);
		foreach (Motion motion in MotionList)
		{
			if (motion is CircularMotion circularMotion)
			{
				for (int i = 0; i < circularMotion.points.Length - 1; i++)
				{
					Point3D[] collection = new Point3D[2]
					{
						circularMotion.points[i],
						circularMotion.points[i + 1]
					};
					switch (motion.Approach)
					{
					case approachType.None:
						list.AddRange(collection);
						break;
					case approachType.Lead:
						list3.AddRange(collection);
						break;
					case approachType.Ramp:
						list4.AddRange(collection);
						break;
					}
				}
			}
			else
			{
				if (!(motion is LinearMotion linearMotion))
				{
					continue;
				}
				if (motion.Code == motionType.Undefined || motion.Code == motionType.G00)
				{
					list2.Add(linearMotion.From);
					list2.Add(linearMotion.To);
					continue;
				}
				Point3D[] collection2 = new Point3D[2] { linearMotion.From, linearMotion.To };
				switch (motion.Approach)
				{
				case approachType.None:
					list.AddRange(collection2);
					break;
				case approachType.Lead:
					list3.AddRange(collection2);
					break;
				case approachType.Ramp:
					list4.AddRange(collection2);
					break;
				}
			}
		}
		data.RenderContext.Compile(drawData, DrawPoints, list.ToArray());
		data.RenderContext.Compile(drawRapidData, DrawPoints, list2.ToArray());
		data.RenderContext.Compile(drawLeadData, DrawPoints, list3.ToArray());
		data.RenderContext.Compile(drawRampData, DrawPoints, list4.ToArray());
		RegenMode = regenType.NotNeeded;
	}

	protected void DrawPoints(RenderContextBase context, object myParams)
	{
		context.DrawLines((Point3D[])myParams);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawSelected(data);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, allVertices, allVertices.Length, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, allVertices, allVertices.Length, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981689) + MotionList.Count);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981650) + Tool);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981637) + RapidColor.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981884) + LeadColor.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981872) + RampColor.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981828) + RapidPattern.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971672) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits);
		return stringBuilder.ToString();
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (MotionList.Count == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981793));
			return false;
		}
		return base.IsValid(log);
	}

	public double Length()
	{
		double num = 0.0;
		foreach (Motion motion in MotionList)
		{
			num += motion.Length();
		}
		return num;
	}

	public LinearPath ConvertToLinearPath(double deviation)
	{
		Regen(deviation);
		return new LinearPath(Utility.DeepCopy(allVertices));
	}
}
