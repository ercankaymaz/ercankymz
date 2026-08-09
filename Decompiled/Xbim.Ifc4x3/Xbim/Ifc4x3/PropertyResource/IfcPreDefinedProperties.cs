using System;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPreDefinedProperties", 1225)]
public abstract class IfcPreDefinedProperties : IfcPropertyAbstraction, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcPreDefinedProperties>
{
	internal IfcPreDefinedProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcPreDefinedProperties other)
	{
		return this == other;
	}
}
