using System.Collections.Generic;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

public class IfcContainerSurrogate : Surrogate<IfcContainer>
{
	public string GUID;

	public Dictionary<string, string> Identification;

	public Dictionary<string, Dictionary<string, ProtoObject>> Properties;

	public Transformation LocalTransformation;

	public Transformation GlobalTransformation;

	public string Parent;

	public List<string> Childs;

	public List<string> Systems;

	public List<string> ContainedElements;

	public IfcContainerSurrogate(IfcContainer ifcContainer)
		: base(ifcContainer)
	{
	}

	protected override IfcContainer ConvertToObject()
	{
		IfcContainer ifcContainer = new IfcContainer();
		CopyDataToObject(ifcContainer);
		return ifcContainer;
	}

	protected override void CopyDataToObject(IfcContainer ifcContainer)
	{
		ifcContainer.GUID = GUID;
		if (Identification != null)
		{
			ifcContainer.Identification = Identification;
		}
		ifcContainer.Properties = ProtoObjectSurrogate.IfcPropertiesToObjects(Properties);
		ifcContainer.LocalTransformation = LocalTransformation;
		ifcContainer.GlobalTransformation = GlobalTransformation;
		ifcContainer.Parent = Parent;
		if (Childs != null)
		{
			ifcContainer.Childs = Childs;
		}
		if (Systems != null)
		{
			ifcContainer.Systems = Systems;
		}
		if (ContainedElements != null)
		{
			ifcContainer.ContainedElements = ContainedElements;
		}
	}

	protected override void CopyDataFromObject(IfcContainer ifcContainer)
	{
		GUID = ifcContainer.GUID;
		Identification = ifcContainer.Identification;
		Properties = ProtoObjectSurrogate.IfcPropertiesToProtoObjects(ifcContainer.Properties);
		LocalTransformation = ifcContainer.LocalTransformation;
		GlobalTransformation = ifcContainer.GlobalTransformation;
		Parent = ifcContainer.Parent;
		Childs = ifcContainer.Childs;
		Systems = ifcContainer.Systems;
		ContainedElements = ifcContainer.ContainedElements;
	}

	public static implicit operator IfcContainer(IfcContainerSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator IfcContainerSurrogate(IfcContainer source)
	{
		return source?.ConvertToSurrogate();
	}
}
