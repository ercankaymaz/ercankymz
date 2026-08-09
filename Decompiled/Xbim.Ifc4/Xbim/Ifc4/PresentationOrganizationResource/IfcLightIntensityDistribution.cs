using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightIntensityDistribution", 754)]
public class IfcLightIntensityDistribution : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightIntensityDistribution, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLightIntensityDistribution>
{
	private IfcLightDistributionCurveEnum _lightDistributionCurve;

	private readonly ItemSet<IfcLightDistributionData> _distributionData;

	IfcLightDistributionCurveEnum IIfcLightIntensityDistribution.LightDistributionCurve
	{
		get
		{
			return LightDistributionCurve;
		}
		set
		{
			LightDistributionCurve = value;
		}
	}

	IItemSet<IIfcLightDistributionData> IIfcLightIntensityDistribution.DistributionData => new ProxyItemSet<IfcLightDistributionData, IIfcLightDistributionData>(DistributionData);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcLightDistributionCurveEnum LightDistributionCurve
	{
		get
		{
			if (_activated)
			{
				return _lightDistributionCurve;
			}
			Activate();
			return _lightDistributionCurve;
		}
		set
		{
			SetValue(delegate(IfcLightDistributionCurveEnum v)
			{
				_lightDistributionCurve = v;
			}, _lightDistributionCurve, value, "LightDistributionCurve", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcLightDistributionData> DistributionData
	{
		get
		{
			if (_activated)
			{
				return _distributionData;
			}
			Activate();
			return _distributionData;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcLightDistributionData distributionDatum in DistributionData)
			{
				yield return distributionDatum;
			}
		}
	}

	internal IfcLightIntensityDistribution(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_distributionData = new ItemSet<IfcLightDistributionData>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_lightDistributionCurve = (IfcLightDistributionCurveEnum)Enum.Parse(typeof(IfcLightDistributionCurveEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_distributionData.InternalAdd((IfcLightDistributionData)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightIntensityDistribution other)
	{
		return this == other;
	}
}
