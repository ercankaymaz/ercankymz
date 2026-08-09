using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelDecomposes", 306)]
public abstract class IfcRelDecomposes : IfcRelationship, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRelDecomposes>
{
	internal IfcRelDecomposes(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcRelDecomposes other)
	{
		return this == other;
	}
}
