using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class IfcProperties : IEyeIfcObject, ISerializable, ICloneable
{
	public string GUID { get; set; }

	public string Parent { get; set; }

	public List<string> Systems { get; set; } = new List<string>();

	public Dictionary<string, string> Identification { get; set; } = new Dictionary<string, string>();

	public Dictionary<string, double> Materials { get; set; } = new Dictionary<string, double>();

	public Transformation LocalTransformation { get; set; }

	public Transformation GlobalTransformation { get; set; }

	public Dictionary<string, Dictionary<string, object>> Properties { get; set; } = new Dictionary<string, Dictionary<string, object>>();

	public List<ICurve> Axes { get; set; }

	public Region ProfileDef { get; set; }

	public Vector3D ExtrusionAmount { get; set; }

	public List<Entity> Openings { get; set; }

	public ifcElementType ElementType { get; set; }

	public IfcProperties()
	{
	}

	protected internal IfcProperties(IfcPropertiesSurrogate surrogate)
	{
	}

	protected IfcProperties(SerializationInfo info, StreamingContext context)
	{
		GUID = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998880));
		Parent = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998857));
		Systems = (List<string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998819), typeof(List<string>));
		Identification = (Dictionary<string, string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998793), typeof(Dictionary<string, string>));
		Materials = (Dictionary<string, double>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998950), typeof(Dictionary<string, double>));
		Properties = (Dictionary<string, Dictionary<string, object>>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999040), typeof(Dictionary<string, Dictionary<string, object>>));
		Axes = (List<ICurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998934), typeof(List<ICurve>));
		ProfileDef = (Region)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998943), typeof(Region));
		ExtrusionAmount = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998642), typeof(Vector3D));
		Openings = (List<Entity>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998632), typeof(List<Entity>));
		ElementType = (ifcElementType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998613), typeof(ifcElementType));
		GlobalTransformation = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999023), typeof(Transformation));
		LocalTransformation = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998988), typeof(Transformation));
	}

	protected IfcProperties(IfcProperties another)
	{
		GUID = another.GUID;
		Parent = another.Parent;
		Systems = another.Systems;
		Identification = another.Identification;
		Materials = another.Materials;
		Properties = another.Properties;
		if (another.Axes != null)
		{
			Axes = new List<ICurve>();
			foreach (ICurve axis in another.Axes)
			{
				Axes.Add((ICurve)axis.Clone());
			}
		}
		ProfileDef = (Region)(another.ProfileDef?.Clone());
		ExtrusionAmount = (Vector3D)(another.ExtrusionAmount?.Clone());
		Openings = another.Openings;
		ElementType = another.ElementType;
		GlobalTransformation = another.GlobalTransformation;
		LocalTransformation = another.LocalTransformation;
	}

	public virtual IfcPropertiesSurrogate ConvertToSurrogate()
	{
		return new IfcPropertiesSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998880), GUID);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998857), Parent);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998819), Systems);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998793), Identification);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998950), Materials);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999040), Properties);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998934), Axes);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998943), ProfileDef);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998642), ExtrusionAmount);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998632), Openings);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998613), ElementType);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999023), GlobalTransformation);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998988), LocalTransformation);
	}

	public virtual object Clone()
	{
		return new IfcProperties(this);
	}

	public string Dump()
	{
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998599);
		text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998562);
		text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998553) + GUID + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535);
		foreach (string key in Identification.Keys)
		{
			Identification.TryGetValue(key, out var value);
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007) + key + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + value + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535);
		}
		text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998770);
		foreach (string key2 in Materials.Keys)
		{
			Materials.TryGetValue(key2, out var value2);
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007) + key2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + value2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535);
		}
		foreach (KeyValuePair<string, Dictionary<string, object>> property in Properties)
		{
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535) + property.Key + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535);
			foreach (KeyValuePair<string, object> item in property.Value)
			{
				string text2 = ((item.Value != null) ? item.Value.ToString() : string.Empty);
				text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007) + item.Key + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998535);
			}
		}
		return text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998755);
	}
}
