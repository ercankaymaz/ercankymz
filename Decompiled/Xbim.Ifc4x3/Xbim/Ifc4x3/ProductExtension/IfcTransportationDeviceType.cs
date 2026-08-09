using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcTransportationDeviceType", 1502)]
public abstract class IfcTransportationDeviceType : IfcElementType, IEquatable<IfcTransportationDeviceType>
{
	internal IfcTransportationDeviceType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTransportationDeviceType other)
	{
		return this == other;
	}
}
