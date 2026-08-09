using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightDistributionData", 753)]
public class IfcLightDistributionData : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightDistributionData, IEquatable<IfcLightDistributionData>
{
	private IfcPlaneAngleMeasure _mainPlaneAngle;

	private readonly ItemSet<IfcPlaneAngleMeasure> _secondaryPlaneAngle;

	private readonly ItemSet<IfcLuminousIntensityDistributionMeasure> _luminousIntensity;

	IfcPlaneAngleMeasure IIfcLightDistributionData.MainPlaneAngle
	{
		get
		{
			return MainPlaneAngle;
		}
		set
		{
			MainPlaneAngle = value;
		}
	}

	IItemSet<IfcPlaneAngleMeasure> IIfcLightDistributionData.SecondaryPlaneAngle => SecondaryPlaneAngle;

	IItemSet<IfcLuminousIntensityDistributionMeasure> IIfcLightDistributionData.LuminousIntensity => LuminousIntensity;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcPlaneAngleMeasure MainPlaneAngle
	{
		get
		{
			if (_activated)
			{
				return _mainPlaneAngle;
			}
			Activate();
			return _mainPlaneAngle;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure v)
			{
				_mainPlaneAngle = v;
			}, _mainPlaneAngle, value, "MainPlaneAngle", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcPlaneAngleMeasure> SecondaryPlaneAngle
	{
		get
		{
			if (_activated)
			{
				return _secondaryPlaneAngle;
			}
			Activate();
			return _secondaryPlaneAngle;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcLuminousIntensityDistributionMeasure> LuminousIntensity
	{
		get
		{
			if (_activated)
			{
				return _luminousIntensity;
			}
			Activate();
			return _luminousIntensity;
		}
	}

	internal IfcLightDistributionData(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_secondaryPlaneAngle = new ItemSet<IfcPlaneAngleMeasure>(this, 0, 2);
		_luminousIntensity = new ItemSet<IfcLuminousIntensityDistributionMeasure>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mainPlaneAngle = value.RealVal;
			break;
		case 1:
			_secondaryPlaneAngle.InternalAdd(value.RealVal);
			break;
		case 2:
			_luminousIntensity.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightDistributionData other)
	{
		return this == other;
	}
}
