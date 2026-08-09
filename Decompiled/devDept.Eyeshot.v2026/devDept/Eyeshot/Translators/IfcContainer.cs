using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class IfcContainer : IEyeIfcObject, ISerializable, ICloneable
{
	public Dictionary<string, string> Identification { get; set; }

	public Dictionary<string, Dictionary<string, object>> Properties { get; set; }

	public Transformation LocalTransformation { get; set; }

	public Transformation GlobalTransformation { get; set; }

	public string GUID { get; set; }

	public string Parent { get; set; }

	public List<string> Childs { get; set; }

	public List<string> Systems { get; set; }

	public List<string> ContainedElements { get; set; }

	public IfcContainer()
	{
		Identification = new Dictionary<string, string>();
		Properties = new Dictionary<string, Dictionary<string, object>>();
		Childs = new List<string>();
		Systems = new List<string>();
		ContainedElements = new List<string>();
	}

	protected IfcContainer(SerializationInfo info, StreamingContext context)
	{
		GUID = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998880));
		Parent = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998857));
		Childs = (List<string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998840), typeof(List<string>));
		Systems = (List<string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998819), typeof(List<string>));
		ContainedElements = (List<string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998801), typeof(List<string>));
		Identification = (Dictionary<string, string>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998793), typeof(Dictionary<string, string>));
		Properties = (Dictionary<string, Dictionary<string, object>>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999040), typeof(Dictionary<string, Dictionary<string, object>>));
		GlobalTransformation = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999023), typeof(Transformation));
		LocalTransformation = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998988), typeof(Transformation));
	}

	protected IfcContainer(IfcContainer another)
	{
		GUID = another.GUID;
		Parent = another.Parent;
		Childs = another.Childs;
		Systems = another.Systems;
		ContainedElements = another.ContainedElements;
		Identification = another.Identification;
		Properties = another.Properties;
		GlobalTransformation = another.GlobalTransformation;
		LocalTransformation = another.LocalTransformation;
	}

	public IfcContainerSurrogate ConvertToSurrogate()
	{
		return new IfcContainerSurrogate(this);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998880), GUID);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998857), Parent);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998840), Childs);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998819), Systems);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998801), ContainedElements);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998793), Identification);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999040), Properties);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999023), GlobalTransformation);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998988), LocalTransformation);
	}

	public object Clone()
	{
		return new IfcContainer(this);
	}
}
