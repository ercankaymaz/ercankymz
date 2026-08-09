using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcConnectionGeometry", 70)]
public abstract class IfcConnectionGeometry : PersistEntity, IEquatable<IfcConnectionGeometry>, IIfcConnectionGeometry, IPersistEntity, IPersist
{
	internal IfcConnectionGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcConnectionGeometry other)
	{
		return this == other;
	}
}
