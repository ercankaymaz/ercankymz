using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcExternalInformation", 1172)]
public abstract class IfcExternalInformation : PersistEntity, IIfcExternalInformation, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcExternalInformation>
{
	internal IfcExternalInformation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcExternalInformation other)
	{
		return this == other;
	}
}
