using ACadSharp.Classes;

namespace ACadSharp.Objects;

public class UnknownNonGraphicalObject : NonGraphicalObject
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

	internal UnknownNonGraphicalObject(DxfClass dxfClass)
	{
		DxfClass = dxfClass;
	}
}
