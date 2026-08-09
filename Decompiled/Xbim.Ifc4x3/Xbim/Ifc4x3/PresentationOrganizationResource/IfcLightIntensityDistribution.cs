using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcLightIntensityDistribution", 754)]
public class IfcLightIntensityDistribution : PersistEntity, IIfcLightIntensityDistribution, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IInstantiableEntity, IfcLightDistributionDataSourceSelect, IContainsEntityReferences, IEquatable<IfcLightIntensityDistribution>
{
	private IfcLightDistributionCurveEnum _lightDistributionCurve;

	private readonly ItemSet<IfcLightDistributionData> _distributionData;

	[CrossSchemaAttribute(typeof(IIfcLightIntensityDistribution), 1)]
	Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum IIfcLightIntensityDistribution.LightDistributionCurve
	{
		get
		{
			return LightDistributionCurve switch
			{
				IfcLightDistributionCurveEnum.TYPE_A => Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_A, 
				IfcLightDistributionCurveEnum.TYPE_B => Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_B, 
				IfcLightDistributionCurveEnum.TYPE_C => Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_C, 
				IfcLightDistributionCurveEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_A:
				LightDistributionCurve = IfcLightDistributionCurveEnum.TYPE_A;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_B:
				LightDistributionCurve = IfcLightDistributionCurveEnum.TYPE_B;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.TYPE_C:
				LightDistributionCurve = IfcLightDistributionCurveEnum.TYPE_C;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightDistributionCurveEnum.NOTDEFINED:
				LightDistributionCurve = IfcLightDistributionCurveEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightIntensityDistribution), 2)]
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
