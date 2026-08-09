using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcLightDistributionData", 753)]
public class IfcLightDistributionData : PersistEntity, IIfcLightDistributionData, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcLightDistributionData>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure _mainPlaneAngle;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure> _secondaryPlaneAngle;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure> _luminousIntensity;

	[CrossSchemaAttribute(typeof(IIfcLightDistributionData), 1)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure IIfcLightDistributionData.MainPlaneAngle
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(MainPlaneAngle);
		}
		set
		{
			MainPlaneAngle = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightDistributionData), 2)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure> IIfcLightDistributionData.SecondaryPlaneAngle => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure, Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure>(SecondaryPlaneAngle, (Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure s) => new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(s), (Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(t));

	[CrossSchemaAttribute(typeof(IIfcLightDistributionData), 3)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure> IIfcLightDistributionData.LuminousIntensity => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure, Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure>(LuminousIntensity, (Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure(t));

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure MainPlaneAngle
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure v)
			{
				_mainPlaneAngle = v;
			}, _mainPlaneAngle, value, "MainPlaneAngle", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure> SecondaryPlaneAngle
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
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure> LuminousIntensity
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
		_secondaryPlaneAngle = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure>(this, 0, 2);
		_luminousIntensity = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure>(this, 0, 3);
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
