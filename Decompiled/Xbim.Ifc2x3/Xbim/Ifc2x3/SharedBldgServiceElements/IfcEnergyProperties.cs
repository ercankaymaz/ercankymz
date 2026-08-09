using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcEnergyProperties", 176)]
public class IfcEnergyProperties : IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcEnergyProperties>
{
	private IfcEnergySequenceEnum? _energySequence;

	private IfcLabel? _userDefinedEnergySequence;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcEnergySequenceEnum? EnergySequence
	{
		get
		{
			if (_activated)
			{
				return _energySequence;
			}
			Activate();
			return _energySequence;
		}
		set
		{
			SetValue(delegate(IfcEnergySequenceEnum? v)
			{
				_energySequence = v;
			}, _energySequence, value, "EnergySequence", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLabel? UserDefinedEnergySequence
	{
		get
		{
			if (_activated)
			{
				return _userDefinedEnergySequence;
			}
			Activate();
			return _userDefinedEnergySequence;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedEnergySequence = v;
			}, _userDefinedEnergySequence, value, "UserDefinedEnergySequence", 6);
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

	internal IfcEnergyProperties(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_energySequence = (IfcEnergySequenceEnum)Enum.Parse(typeof(IfcEnergySequenceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_userDefinedEnergySequence = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEnergyProperties other)
	{
		return this == other;
	}
}
