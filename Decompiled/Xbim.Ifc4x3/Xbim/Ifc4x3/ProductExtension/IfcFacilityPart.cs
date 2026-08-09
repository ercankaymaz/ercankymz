using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcFacilityPart", 1440)]
public abstract class IfcFacilityPart : IfcSpatialStructureElement, IEquatable<IfcFacilityPart>
{
	private IfcFacilityUsageEnum _usageType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 29)]
	public IfcFacilityUsageEnum UsageType
	{
		get
		{
			if (_activated)
			{
				return _usageType;
			}
			Activate();
			return _usageType;
		}
		set
		{
			SetValue(delegate(IfcFacilityUsageEnum v)
			{
				_usageType = v;
			}, _usageType, value, "UsageType", 10);
		}
	}

	internal IfcFacilityPart(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_usageType = (IfcFacilityUsageEnum)Enum.Parse(typeof(IfcFacilityUsageEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFacilityPart other)
	{
		return this == other;
	}
}
