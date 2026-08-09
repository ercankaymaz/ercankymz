using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationDefinitionResource;

[ExpressType("IfcPresentationItem", 1227)]
public abstract class IfcPresentationItem : PersistEntity, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcPresentationItem>
{
	internal IfcPresentationItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcPresentationItem other)
	{
		return this == other;
	}
}
