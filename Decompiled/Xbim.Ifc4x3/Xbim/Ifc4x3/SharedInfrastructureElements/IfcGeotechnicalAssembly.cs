using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.SharedInfrastructureElements;

[ExpressType("IfcGeotechnicalAssembly", 1445)]
public abstract class IfcGeotechnicalAssembly : IfcGeotechnicalElement, IEquatable<IfcGeotechnicalAssembly>
{
	internal IfcGeotechnicalAssembly(IModel model, int label, bool activated)
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

	public bool Equals(IfcGeotechnicalAssembly other)
	{
		return this == other;
	}
}
