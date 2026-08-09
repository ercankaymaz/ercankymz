using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcServiceLife", 769)]
public class IfcServiceLife : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcServiceLife>
{
	private IfcServiceLifeTypeEnum _serviceLifeType;

	private IfcTimeMeasure _serviceLifeDuration;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcServiceLifeTypeEnum ServiceLifeType
	{
		get
		{
			if (_activated)
			{
				return _serviceLifeType;
			}
			Activate();
			return _serviceLifeType;
		}
		set
		{
			SetValue(delegate(IfcServiceLifeTypeEnum v)
			{
				_serviceLifeType = v;
			}, _serviceLifeType, value, "ServiceLifeType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcTimeMeasure ServiceLifeDuration
	{
		get
		{
			if (_activated)
			{
				return _serviceLifeDuration;
			}
			Activate();
			return _serviceLifeDuration;
		}
		set
		{
			SetValue(delegate(IfcTimeMeasure v)
			{
				_serviceLifeDuration = v;
			}, _serviceLifeDuration, value, "ServiceLifeDuration", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcServiceLife(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_serviceLifeType = (IfcServiceLifeTypeEnum)Enum.Parse(typeof(IfcServiceLifeTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_serviceLifeDuration = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcServiceLife other)
	{
		return this == other;
	}
}
