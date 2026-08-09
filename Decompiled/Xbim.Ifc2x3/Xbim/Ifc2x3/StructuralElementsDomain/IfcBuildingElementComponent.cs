using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ProductExtension;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcBuildingElementComponent", 221)]
public abstract class IfcBuildingElementComponent : IfcBuildingElement, IEquatable<IfcBuildingElementComponent>
{
	internal IfcBuildingElementComponent(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcBuildingElementComponent other)
	{
		return this == other;
	}
}
