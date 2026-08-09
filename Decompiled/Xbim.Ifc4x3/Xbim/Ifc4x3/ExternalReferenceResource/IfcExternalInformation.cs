using System;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcExternalInformation", 1172)]
public abstract class IfcExternalInformation : PersistEntity, IfcResourceObjectSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcResourceObjectSelect, IEquatable<IfcExternalInformation>, IIfcExternalInformation, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect
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
