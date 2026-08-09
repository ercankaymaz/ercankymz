using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.SharedFacilitiesElements;

[ExpressType("IfcInventory", 768)]
public class IfcInventory : Xbim.Ifc4x3.Kernel.IfcGroup, IIfcInventory, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcInventory>
{
	private IfcInventoryTypeEnum? _predefinedType;

	private IfcActorSelect _jurisdiction;

	private readonly OptionalItemSet<IfcPerson> _responsiblePersons;

	private Xbim.Ifc4x3.DateTimeResource.IfcDate? _lastUpdateDate;

	private IfcCostValue _currentValue;

	private IfcCostValue _originalValue;

	[CrossSchemaAttribute(typeof(IIfcInventory), 6)]
	Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum? IIfcInventory.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcInventoryTypeEnum.ASSETINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.ASSETINVENTORY, 
				IfcInventoryTypeEnum.FURNITUREINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.FURNITUREINVENTORY, 
				IfcInventoryTypeEnum.SPACEINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.SPACEINVENTORY, 
				IfcInventoryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.USERDEFINED, 
				IfcInventoryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.ASSETINVENTORY:
				PredefinedType = IfcInventoryTypeEnum.ASSETINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.SPACEINVENTORY:
				PredefinedType = IfcInventoryTypeEnum.SPACEINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.FURNITUREINVENTORY:
				PredefinedType = IfcInventoryTypeEnum.FURNITUREINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.USERDEFINED:
				PredefinedType = IfcInventoryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.NOTDEFINED:
				PredefinedType = IfcInventoryTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcInventory), 7)]
	IIfcActorSelect IIfcInventory.Jurisdiction
	{
		get
		{
			if (Jurisdiction == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = Jurisdiction as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = Jurisdiction as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = Jurisdiction as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				return ifcPersonAndOrganization;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Jurisdiction = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				Jurisdiction = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				Jurisdiction = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				Jurisdiction = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcInventory), 8)]
	IItemSet<IIfcPerson> IIfcInventory.ResponsiblePersons => new ProxyItemSet<IfcPerson, IIfcPerson>(ResponsiblePersons);

	[CrossSchemaAttribute(typeof(IIfcInventory), 9)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcInventory.LastUpdateDate
	{
		get
		{
			if (!LastUpdateDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(LastUpdateDate.Value);
		}
		set
		{
			LastUpdateDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDate?(new Xbim.Ifc4x3.DateTimeResource.IfcDate(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDate?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcInventory), 10)]
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

	[CrossSchemaAttribute(typeof(IIfcInventory), 11)]
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

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
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

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 21)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDate? LastUpdateDate
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDate? v)
			{
				_lastUpdateDate = v;
			}, _lastUpdateDate, value, "LastUpdateDate", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 24)]
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
