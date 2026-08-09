using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

public class IfcPropertiesSurrogate : Surrogate<IfcProperties>
{
	public string GUID;

	public string Parent;

	public List<string> Systems;

	public Dictionary<string, string> Identification;

	public Dictionary<string, Dictionary<string, ProtoObject>> Properties;

	public Dictionary<string, double> Materials;

	public Transformation LocalTransformation;

	public Transformation GlobalTransformation;

	public List<Entity> Axes;

	public List<Entity> Openings;

	public Region ProfileDef;

	public Vector3D ExtrusionAmount;

	public byte ElementType;

	public IfcPropertiesSurrogate(IfcProperties ifcProperties)
		: base(ifcProperties)
	{
	}

	protected override IfcProperties ConvertToObject()
	{
		IfcProperties ifcProperties = new IfcProperties();
		CopyDataToObject(ifcProperties);
		return ifcProperties;
	}

	protected override void CopyDataToObject(IfcProperties ifcProperties)
	{
		ifcProperties.GUID = GUID;
		if (Identification != null)
		{
			ifcProperties.Identification = Identification;
		}
		ifcProperties.Properties = ProtoObjectSurrogate.IfcPropertiesToObjects(Properties);
		if (Materials != null)
		{
			ifcProperties.Materials = Materials;
		}
		ifcProperties.Parent = Parent;
		if (Systems != null)
		{
			ifcProperties.Systems = Systems;
		}
		ifcProperties.LocalTransformation = LocalTransformation;
		ifcProperties.GlobalTransformation = GlobalTransformation;
		if (Axes != null)
		{
			ifcProperties.Axes = Axes.Cast<ICurve>().ToList();
		}
		if (Openings != null)
		{
			ifcProperties.Openings = Openings;
		}
		ifcProperties.ProfileDef = ProfileDef;
		ifcProperties.ExtrusionAmount = ExtrusionAmount;
		ifcProperties.ElementType = (ifcElementType)ElementType;
	}

	protected override void CopyDataFromObject(IfcProperties ifcProperties)
	{
		GUID = ifcProperties.GUID;
		Identification = ifcProperties.Identification;
		Properties = ProtoObjectSurrogate.IfcPropertiesToProtoObjects(ifcProperties.Properties);
		Materials = ifcProperties.Materials;
		Parent = ifcProperties.Parent;
		if (ifcProperties.Systems != null)
		{
			Systems = ifcProperties.Systems;
		}
		LocalTransformation = ifcProperties.LocalTransformation;
		GlobalTransformation = ifcProperties.GlobalTransformation;
		if (ifcProperties.Axes != null)
		{
			Axes = ifcProperties.Axes.Cast<Entity>().ToList();
		}
		if (ifcProperties.Openings != null)
		{
			Openings = ifcProperties.Openings;
		}
		ProfileDef = ifcProperties.ProfileDef;
		ExtrusionAmount = ifcProperties.ExtrusionAmount;
		ElementType = (byte)ifcProperties.ElementType;
	}

	public static implicit operator IfcProperties(IfcPropertiesSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator IfcPropertiesSurrogate(IfcProperties source)
	{
		return source?.ConvertToSurrogate();
	}
}
