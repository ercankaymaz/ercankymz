using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedInfrastructureElements;

[ExpressType("IfcGeotechnicalElement", 1446)]
public abstract class IfcGeotechnicalElement : IfcElement, IEquatable<IfcGeotechnicalElement>
{
	internal IfcGeotechnicalElement(IModel model, int label, bool activated)
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

	public bool Equals(IfcGeotechnicalElement other)
	{
		return this == other;
	}
}
