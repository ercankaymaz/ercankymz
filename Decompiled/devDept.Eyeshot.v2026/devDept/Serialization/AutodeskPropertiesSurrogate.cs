using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class AutodeskPropertiesSurrogate : Surrogate<AutodeskProperties>
{
	public List<KeyValuePair<short, ProtoObject>> XData;

	public double Thickness;

	public Vector3D ExtrusionDir;

	public string UnparsedDimensionText;

	public byte VisualStyleMode;

	public Point3D[] XClip;

	public AutodeskPropertiesSurrogate(AutodeskProperties AutodeskProperties)
		: base(AutodeskProperties)
	{
	}

	protected override AutodeskProperties ConvertToObject()
	{
		AutodeskProperties autodeskProperties = new AutodeskProperties(this);
		CopyDataToObject(autodeskProperties);
		return autodeskProperties;
	}

	protected override void CopyDataToObject(AutodeskProperties AutodeskProperties)
	{
		AutodeskProperties.ExtrusionDir = ExtrusionDir;
		AutodeskProperties.Thickness = Thickness;
		AutodeskProperties.UnparsedDimensionText = UnparsedDimensionText;
		AutodeskProperties.VisualStyleMode = (AutodeskProperties.visualStyleType)VisualStyleMode;
		AutodeskProperties.XClip = XClip;
		if (XData == null)
		{
			return;
		}
		AutodeskProperties.XData = new List<KeyValuePair<short, object>>();
		foreach (KeyValuePair<short, ProtoObject> xDatum in XData)
		{
			ProtoObject value = xDatum.Value;
			AutodeskProperties.XData.Add(new KeyValuePair<short, object>(xDatum.Key, value?.Object));
		}
	}

	protected override void CopyDataFromObject(AutodeskProperties AutodeskProperties)
	{
		ExtrusionDir = AutodeskProperties.ExtrusionDir;
		Thickness = AutodeskProperties.Thickness;
		UnparsedDimensionText = AutodeskProperties.UnparsedDimensionText;
		VisualStyleMode = (byte)AutodeskProperties.VisualStyleMode;
		XClip = AutodeskProperties.XClip;
		if (AutodeskProperties.XData == null)
		{
			return;
		}
		XData = new List<KeyValuePair<short, ProtoObject>>();
		foreach (KeyValuePair<short, object> xDatum in AutodeskProperties.XData)
		{
			XData.Add(new KeyValuePair<short, ProtoObject>(xDatum.Key, new ProtoObject(xDatum.Value)));
		}
	}

	public static implicit operator AutodeskProperties(AutodeskPropertiesSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator AutodeskPropertiesSurrogate(AutodeskProperties source)
	{
		return source?.ConvertToSurrogate();
	}
}
