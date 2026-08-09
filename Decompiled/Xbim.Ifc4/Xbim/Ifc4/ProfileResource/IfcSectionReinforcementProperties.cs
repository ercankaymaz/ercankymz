using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcSectionReinforcementProperties", 508)]
public class IfcSectionReinforcementProperties : IfcPreDefinedProperties, IInstantiableEntity, IPersistEntity, IPersist, IIfcSectionReinforcementProperties, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSectionReinforcementProperties>
{
	private IfcLengthMeasure _longitudinalStartPosition;

	private IfcLengthMeasure _longitudinalEndPosition;

	private IfcLengthMeasure? _transversePosition;

	private IfcReinforcingBarRoleEnum _reinforcementRole;

	private IfcSectionProperties _sectionDefinition;

	private readonly ItemSet<IfcReinforcementBarProperties> _crossSectionReinforcementDefinitions;

	IfcLengthMeasure IIfcSectionReinforcementProperties.LongitudinalStartPosition
	{
		get
		{
			return LongitudinalStartPosition;
		}
		set
		{
			LongitudinalStartPosition = value;
		}
	}

	IfcLengthMeasure IIfcSectionReinforcementProperties.LongitudinalEndPosition
	{
		get
		{
			return LongitudinalEndPosition;
		}
		set
		{
			LongitudinalEndPosition = value;
		}
	}

	IfcLengthMeasure? IIfcSectionReinforcementProperties.TransversePosition
	{
		get
		{
			return TransversePosition;
		}
		set
		{
			TransversePosition = value;
		}
	}

	IfcReinforcingBarRoleEnum IIfcSectionReinforcementProperties.ReinforcementRole
	{
		get
		{
			return ReinforcementRole;
		}
		set
		{
			ReinforcementRole = value;
		}
	}

	IIfcSectionProperties IIfcSectionReinforcementProperties.SectionDefinition
	{
		get
		{
			return SectionDefinition;
		}
		set
		{
			SectionDefinition = value as IfcSectionProperties;
		}
	}

	IItemSet<IIfcReinforcementBarProperties> IIfcSectionReinforcementProperties.CrossSectionReinforcementDefinitions => new ProxyItemSet<IfcReinforcementBarProperties, IIfcReinforcementBarProperties>(CrossSectionReinforcementDefinitions);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLengthMeasure LongitudinalStartPosition
	{
		get
		{
			if (_activated)
			{
				return _longitudinalStartPosition;
			}
			Activate();
			return _longitudinalStartPosition;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_longitudinalStartPosition = v;
			}, _longitudinalStartPosition, value, "LongitudinalStartPosition", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure LongitudinalEndPosition
	{
		get
		{
			if (_activated)
			{
				return _longitudinalEndPosition;
			}
			Activate();
			return _longitudinalEndPosition;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_longitudinalEndPosition = v;
			}, _longitudinalEndPosition, value, "LongitudinalEndPosition", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure? TransversePosition
	{
		get
		{
			if (_activated)
			{
				return _transversePosition;
			}
			Activate();
			return _transversePosition;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_transversePosition = v;
			}, _transversePosition, value, "TransversePosition", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcReinforcingBarRoleEnum ReinforcementRole
	{
		get
		{
			if (_activated)
			{
				return _reinforcementRole;
			}
			Activate();
			return _reinforcementRole;
		}
		set
		{
			SetValue(delegate(IfcReinforcingBarRoleEnum v)
			{
				_reinforcementRole = v;
			}, _reinforcementRole, value, "ReinforcementRole", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcSectionProperties SectionDefinition
	{
		get
		{
			if (_activated)
			{
				return _sectionDefinition;
			}
			Activate();
			return _sectionDefinition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSectionProperties v)
			{
				_sectionDefinition = v;
			}, _sectionDefinition, value, "SectionDefinition", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
	public IItemSet<IfcReinforcementBarProperties> CrossSectionReinforcementDefinitions
	{
		get
		{
			if (_activated)
			{
				return _crossSectionReinforcementDefinitions;
			}
			Activate();
			return _crossSectionReinforcementDefinitions;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (SectionDefinition != null)
			{
				yield return SectionDefinition;
			}
			foreach (IfcReinforcementBarProperties crossSectionReinforcementDefinition in CrossSectionReinforcementDefinitions)
			{
				yield return crossSectionReinforcementDefinition;
			}
		}
	}

	internal IfcSectionReinforcementProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSectionReinforcementDefinitions = new ItemSet<IfcReinforcementBarProperties>(this, 0, 6);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_longitudinalStartPosition = value.RealVal;
			break;
		case 1:
			_longitudinalEndPosition = value.RealVal;
			break;
		case 2:
			_transversePosition = value.RealVal;
			break;
		case 3:
			_reinforcementRole = (IfcReinforcingBarRoleEnum)Enum.Parse(typeof(IfcReinforcingBarRoleEnum), value.EnumVal, ignoreCase: true);
			break;
		case 4:
			_sectionDefinition = (IfcSectionProperties)value.EntityVal;
			break;
		case 5:
			_crossSectionReinforcementDefinitions.InternalAdd((IfcReinforcementBarProperties)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionReinforcementProperties other)
	{
		return this == other;
	}
}
