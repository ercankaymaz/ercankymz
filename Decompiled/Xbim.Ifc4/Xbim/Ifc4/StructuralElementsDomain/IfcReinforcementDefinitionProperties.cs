using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProfileResource;

namespace Xbim.Ifc4.StructuralElementsDomain;

[ExpressType("IfcReinforcementDefinitionProperties", 263)]
public class IfcReinforcementDefinitionProperties : IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcReinforcementDefinitionProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcReinforcementDefinitionProperties>
{
	private IfcLabel? _definitionType;

	private readonly ItemSet<IfcSectionReinforcementProperties> _reinforcementSectionDefinitions;

	IfcLabel? IIfcReinforcementDefinitionProperties.DefinitionType
	{
		get
		{
			return DefinitionType;
		}
		set
		{
			DefinitionType = value;
		}
	}

	IItemSet<IIfcSectionReinforcementProperties> IIfcReinforcementDefinitionProperties.ReinforcementSectionDefinitions => new ProxyItemSet<IfcSectionReinforcementProperties, IIfcSectionReinforcementProperties>(ReinforcementSectionDefinitions);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel? DefinitionType
	{
		get
		{
			if (_activated)
			{
				return _definitionType;
			}
			Activate();
			return _definitionType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_definitionType = v;
			}, _definitionType, value, "DefinitionType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<IfcSectionReinforcementProperties> ReinforcementSectionDefinitions
	{
		get
		{
			if (_activated)
			{
				return _reinforcementSectionDefinitions;
			}
			Activate();
			return _reinforcementSectionDefinitions;
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
			foreach (IfcSectionReinforcementProperties reinforcementSectionDefinition in ReinforcementSectionDefinitions)
			{
				yield return reinforcementSectionDefinition;
			}
		}
	}

	internal IfcReinforcementDefinitionProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_reinforcementSectionDefinitions = new ItemSet<IfcSectionReinforcementProperties>(this, 0, 6);
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
			_definitionType = value.StringVal;
			break;
		case 5:
			_reinforcementSectionDefinitions.InternalAdd((IfcSectionReinforcementProperties)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcementDefinitionProperties other)
	{
		return this == other;
	}
}
