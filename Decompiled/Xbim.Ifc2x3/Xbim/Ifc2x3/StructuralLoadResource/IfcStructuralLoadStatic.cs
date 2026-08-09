using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadStatic", 37)]
public abstract class IfcStructuralLoadStatic : IfcStructuralLoad, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IEquatable<IfcStructuralLoadStatic>
{
	internal IfcStructuralLoadStatic(IModel model, int label, bool activated)
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

	public bool Equals(IfcStructuralLoadStatic other)
	{
		return this == other;
	}
}
