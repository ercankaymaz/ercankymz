using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class AutodeskProperties : ICloneable
{
	public enum visualStyleType : byte
	{
		Wireframe2D,
		Conceptual,
		Hidden,
		Realistic,
		Shaded,
		ShadedWithEdges,
		ShadesOfGray,
		Sketchy,
		Wireframe,
		XRay
	}

	public virtual List<KeyValuePair<short, object>> XData { get; set; }

	public double Thickness { get; set; }

	public Vector3D ExtrusionDir { get; set; }

	public string UnparsedDimensionText { get; set; }

	public visualStyleType VisualStyleMode { get; set; }

	public Point3D[] XClip { get; set; }

	static AutodeskProperties()
	{
		visualStyleType.Wireframe2D.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955606));
		visualStyleType.Conceptual.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955591));
		visualStyleType.Hidden.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955578));
		visualStyleType.Realistic.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955557));
		visualStyleType.Shaded.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955541));
		visualStyleType.ShadedWithEdges.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955524));
		visualStyleType.ShadesOfGray.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955772));
		visualStyleType.Sketchy.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955759));
		visualStyleType.Wireframe.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955741));
		visualStyleType.XRay.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955725));
	}

	public AutodeskProperties()
	{
	}

	public AutodeskProperties(List<KeyValuePair<short, object>> xData)
	{
		XData = xData;
	}

	public AutodeskProperties(double thickness, Vector3D extrusionDir)
	{
		Thickness = thickness;
		ExtrusionDir = extrusionDir;
	}

	public AutodeskProperties(List<KeyValuePair<short, object>> xData, double thickness, Vector3D extrusionDir)
	{
		XData = xData;
		Thickness = thickness;
		ExtrusionDir = extrusionDir;
	}

	public AutodeskProperties(List<KeyValuePair<short, object>> xData, double thickness, Vector3D extrusionDir, visualStyleType visualStyleMode)
	{
		XData = xData;
		Thickness = thickness;
		ExtrusionDir = extrusionDir;
		VisualStyleMode = visualStyleMode;
	}

	protected AutodeskProperties(AutodeskProperties another)
	{
		if (another.XData != null)
		{
			XData = new List<KeyValuePair<short, object>>();
			foreach (KeyValuePair<short, object> xDatum in another.XData)
			{
				if (xDatum.Value is ICloneable cloneable)
				{
					XData.Add(new KeyValuePair<short, object>(xDatum.Key, cloneable.Clone()));
				}
				else if (xDatum.Value is ValueType)
				{
					XData.Add(new KeyValuePair<short, object>(xDatum.Key, xDatum.Value));
				}
			}
		}
		Thickness = another.Thickness;
		ExtrusionDir = another.ExtrusionDir;
		UnparsedDimensionText = another.UnparsedDimensionText;
		VisualStyleMode = another.VisualStyleMode;
		if (another.XClip != null)
		{
			XClip = new Point3D[another.XClip.Length];
			for (int i = 0; i < XClip.Length; i++)
			{
				XClip[i] = (Point3D)another.XClip[i].Clone();
			}
		}
	}

	protected internal AutodeskProperties(AutodeskPropertiesSurrogate surrogate)
		: this(surrogate.Thickness, surrogate.ExtrusionDir)
	{
	}

	protected AutodeskProperties(SerializationInfo info, StreamingContext context)
	{
		XData = (List<KeyValuePair<short, object>>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955705), typeof(List<KeyValuePair<short, object>>));
		Thickness = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955685));
		ExtrusionDir = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955669), typeof(Vector3D));
		UnparsedDimensionText = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955658));
		VisualStyleMode = (visualStyleType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956390), typeof(visualStyleType));
		XClip = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956380), typeof(Point3D[]));
	}

	public object Clone()
	{
		return new AutodeskProperties(this);
	}

	public virtual AutodeskPropertiesSurrogate ConvertToSurrogate()
	{
		return new AutodeskPropertiesSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955705), XData, typeof(List<KeyValuePair<short, object>>));
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955685), Thickness);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955669), ExtrusionDir);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955658), UnparsedDimensionText);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956390), VisualStyleMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956380), XClip);
	}
}
