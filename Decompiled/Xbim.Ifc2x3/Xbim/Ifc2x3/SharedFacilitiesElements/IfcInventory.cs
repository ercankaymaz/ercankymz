using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcInventory", 768)]
public class IfcInventory : Xbim.Ifc2x3.Kernel.IfcGroup, IIfcInventory, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcInventory>, IExpressValidatable
{
	public enum IfcInventoryClause
	{
		WR41
	}

	private IfcInventoryTypeEnum _inventoryType;

	private IfcActorSelect _jurisdiction;

	private readonly ItemSet<IfcPerson> _responsiblePersons;

	private IfcCalendarDate _lastUpdateDate;

	private IfcCostValue _currentValue;

	private IfcCostValue _originalValue;

	[CrossSchemaAttribute(typeof(IIfcInventory), 6)]
	Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum? IIfcInventory.PredefinedType
	{
		get
		{
			return InventoryType switch
			{
				IfcInventoryTypeEnum.ASSETINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.ASSETINVENTORY, 
				IfcInventoryTypeEnum.SPACEINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.SPACEINVENTORY, 
				IfcInventoryTypeEnum.FURNITUREINVENTORY => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.FURNITUREINVENTORY, 
				IfcInventoryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.USERDEFINED, 
				IfcInventoryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.ASSETINVENTORY:
				InventoryType = IfcInventoryTypeEnum.ASSETINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.SPACEINVENTORY:
				InventoryType = IfcInventoryTypeEnum.SPACEINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.FURNITUREINVENTORY:
				InventoryType = IfcInventoryTypeEnum.FURNITUREINVENTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.USERDEFINED:
				InventoryType = IfcInventoryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcInventoryTypeEnum.NOTDEFINED:
				InventoryType = IfcInventoryTypeEnum.NOTDEFINED;
				break;
			case null:
				InventoryType = IfcInventoryTypeEnum.NOTDEFINED;
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
	IfcDate? IIfcInventory.LastUpdateDate
	{
		get
		{
			return (LastUpdateDate != null) ? new IfcDate(LastUpdateDate.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				LastUpdateDate = null;
				return;
			}
			DateTime date = value.Value;
			LastUpdateDate = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
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

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcInventoryTypeEnum InventoryType
	{
		get
		{
			if (_activated)
			{
				return _inventoryType;
			}
			Activate();
			return _inventoryType;
		}
		set
		{
			SetValue(delegate(IfcInventoryTypeEnum v)
			{
				_inventoryType = v;
			}, _inventoryType, value, "InventoryType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
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

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 14)]
	public IItemSet<IfcPerson> ResponsiblePersons
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

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcCalendarDate LastUpdateDate
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_lastUpdateDate = v;
			}, _lastUpdateDate, value, "LastUpdateDate", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 16)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 17)]
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
			if (LastUpdateDate != null)
			{
				yield return LastUpdateDate;
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
		_responsiblePersons = new ItemSet<IfcPerson>(this, 0, 8);
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
			_inventoryType = (IfcInventoryTypeEnum)Enum.Parse(typeof(IfcInventoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_jurisdiction = (IfcActorSelect)value.EntityVal;
			break;
		case 7:
			_responsiblePersons.InternalAdd((IfcPerson)value.EntityVal);
			break;
		case 8:
			_lastUpdateDate = (IfcCalendarDate)value.EntityVal;
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

	public bool ValidateClause(IfcInventoryClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcInventoryClause.WR41)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.IsGroupedBy.RelatedObjects, (Xbim.Ifc2x3.Kernel.IfcObjectDefinition temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCSPACE") && !Functions.TYPEOF(temp).Contains("IFC2X3.IFCASSET") && !Functions.TYPEOF(temp).Contains("IFC2X3.IFCFURNISHINGELEMENT"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcInventory>()?.LogError($"Exception thrown evaluating where-clause 'IfcInventory.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcInventoryClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcInventory.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
