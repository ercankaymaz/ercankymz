using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.SharedFacilitiesElements;

[ExpressType("IfcInventory", 768)]
public class IfcInventory : IfcGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcInventory, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcInventory>
{
	private IfcInventoryTypeEnum? _predefinedType;

	private IfcActorSelect _jurisdiction;

	private readonly OptionalItemSet<IfcPerson> _responsiblePersons;

	private IfcDate? _lastUpdateDate;

	private IfcCostValue _currentValue;

	private IfcCostValue _originalValue;

	IfcInventoryTypeEnum? IIfcInventory.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IIfcActorSelect IIfcInventory.Jurisdiction
	{
		get
		{
			return Jurisdiction;
		}
		set
		{
			Jurisdiction = value as IfcActorSelect;
		}
	}

	IItemSet<IIfcPerson> IIfcInventory.ResponsiblePersons => new ProxyItemSet<IfcPerson, IIfcPerson>(ResponsiblePersons);

	IfcDate? IIfcInventory.LastUpdateDate
	{
		get
		{
			return LastUpdateDate;
		}
		set
		{
			LastUpdateDate = value;
		}
	}

	IIfcCostValue IIfcInventory.CurrentValue
	{
		get
		{
			return CurrentValue;
		}
		set
		{
			CurrentValue = value as IfcCostValue;
		}
	}

	IIfcCostValue IIfcInventory.OriginalValue
	{
		get
		{
			return OriginalValue;
		}
		set
		{
			OriginalValue = value as IfcCostValue;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 18)]
	public IfcInventoryTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcInventoryTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
	public IfcActorSelect Jurisdiction
	{
		get
		{
			if (_activated)
			{
				return _jurisdiction;
			}
			Activate();
			return _jurisdiction;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_jurisdiction = v;
			}, _jurisdiction, value, "Jurisdiction", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IOptionalItemSet<IfcPerson> ResponsiblePersons
	{
		get
		{
			if (_activated)
			{
				return _responsiblePersons;
			}
			Activate();
			return _responsiblePersons;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcDate? LastUpdateDate
	{
		get
		{
			if (_activated)
			{
				return _lastUpdateDate;
			}
			Activate();
			return _lastUpdateDate;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_lastUpdateDate = v;
			}, _lastUpdateDate, value, "LastUpdateDate", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 22)]
	public IfcCostValue CurrentValue
	{
		get
		{
			if (_activated)
			{
				return _currentValue;
			}
			Activate();
			return _currentValue;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCostValue v)
			{
				_currentValue = v;
			}, _currentValue, value, "CurrentValue", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
	public IfcCostValue OriginalValue
	{
		get
		{
			if (_activated)
			{
				return _originalValue;
			}
			Activate();
			return _originalValue;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCostValue v)
			{
				_originalValue = v;
			}, _originalValue, value, "OriginalValue", 11);
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
			if (Jurisdiction != null)
			{
				yield return Jurisdiction;
			}
			foreach (IfcPerson responsiblePerson in ResponsiblePersons)
			{
				yield return responsiblePerson;
			}
			if (CurrentValue != null)
			{
				yield return CurrentValue;
			}
			if (OriginalValue != null)
			{
				yield return OriginalValue;
			}
		}
	}

	internal IfcInventory(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_responsiblePersons = new OptionalItemSet<IfcPerson>(this, 0, 8);
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
			_predefinedType = (IfcInventoryTypeEnum)Enum.Parse(typeof(IfcInventoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_jurisdiction = (IfcActorSelect)value.EntityVal;
			break;
		case 7:
			_responsiblePersons.InternalAdd((IfcPerson)value.EntityVal);
			break;
		case 8:
			_lastUpdateDate = value.StringVal;
			break;
		case 9:
			_currentValue = (IfcCostValue)value.EntityVal;
			break;
		case 10:
			_originalValue = (IfcCostValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcInventory other)
	{
		return this == other;
	}
}
