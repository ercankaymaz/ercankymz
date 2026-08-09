using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

internal class IfcLinearPathSurrogate : LinearPathSurrogate
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

	public IfcLinearPathSurrogate(IfcLinearPath ifcLp)
		: base(ifcLp)
	{
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is LinearPath)
		{
			IfcProperties ifcProperties = new IfcProperties();
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
			entity.IfcProperties = ifcProperties;
			base.CopyDataToObject(entity);
		}
		base.CopyDataToObject(entity);
	}
}
