using ACadSharp.Classes;
using CSMath;

namespace ACadSharp.Entities;

public class UnknownEntity : Entity
{
	public override ObjectType ObjectType => ObjectType.UNDEFINED;

	public override string ObjectName
	{
		get
		{
			if (DxfClass == null)
			{
				return "UNKNOWN";
			}
			return DxfClass.DxfName;
		}
	}

	public override string SubclassMarker
	{
		get
		{
			if (DxfClass == null)
			{
				return "AcDbEntity";
			}
			return DxfClass.CppClassName;
		}
	}

	public DxfClass DxfClass { get; }

	internal UnknownEntity(DxfClass dxfClass)
	{
		DxfClass = dxfClass;
	}

	public override void ApplyTransform(Transform transform)
	{
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}
}
