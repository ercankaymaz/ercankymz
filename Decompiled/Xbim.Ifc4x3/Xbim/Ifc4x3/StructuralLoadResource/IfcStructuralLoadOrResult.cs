using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadOrResult", 1283)]
public abstract class IfcStructuralLoadOrResult : IfcStructuralLoad, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IEquatable<IfcStructuralLoadOrResult>
{
	internal IfcStructuralLoadOrResult(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStructuralLoadOrResult other)
	{
		return this == other;
	}
}
