using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcAsset", 767)]
public class IfcAsset : Xbim.Ifc2x3.Kernel.IfcGroup, IIfcAsset, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAsset>, IExpressValidatable
{
	public enum IfcAssetClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _assetID;

	private IfcCostValue _originalValue;

	private IfcCostValue _currentValue;

	private IfcCostValue _totalReplacementCost;

	private IfcActorSelect _owner;

	private IfcActorSelect _user;

	private IfcPerson _responsiblePerson;

	private IfcCalendarDate _incorporationDate;

	private IfcCostValue _depreciatedValue;

	[CrossSchemaAttribute(typeof(IIfcAsset), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcAsset.Identification
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(AssetID);
		}
		set
		{
			AssetID = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcIdentifier));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 7)]
	IIfcCostValue IIfcAsset.OriginalValue
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

	[CrossSchemaAttribute(typeof(IIfcAsset), 8)]
	IIfcCostValue IIfcAsset.CurrentValue
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

	[CrossSchemaAttribute(typeof(IIfcAsset), 9)]
	IIfcCostValue IIfcAsset.TotalReplacementCost
	{
		get
		{
			return TotalReplacementCost;
		}
		set
		{
			TotalReplacementCost = value as IfcCostValue;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 10)]
	IIfcActorSelect IIfcAsset.Owner
	{
		get
		{
			if (Owner == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = Owner as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = Owner as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = Owner as IfcPersonAndOrganization;
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
				Owner = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				Owner = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				Owner = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				Owner = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 11)]
	IIfcActorSelect IIfcAsset.User
	{
		get
		{
			if (User == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = User as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = User as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = User as IfcPersonAndOrganization;
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
				User = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				User = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				User = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				User = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 12)]
	IIfcPerson IIfcAsset.ResponsiblePerson
	{
		get
		{
			return ResponsiblePerson;
		}
		set
		{
			ResponsiblePerson = value as IfcPerson;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 13)]
	IfcDate? IIfcAsset.IncorporationDate
	{
		get
		{
			return (IncorporationDate != null) ? new IfcDate(IncorporationDate.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				IncorporationDate = null;
				return;
			}
			DateTime d = value.Value;
			IncorporationDate = base.Model.Instances.New(delegate(IfcCalendarDate date)
			{
				date.YearComponent = d.Year;
				date.MonthComponent = d.Month;
				date.DayComponent = d.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsset), 14)]
	IIfcCostValue IIfcAsset.DepreciatedValue
	{
		get
		{
			return DepreciatedValue;
		}
		set
		{
			DepreciatedValue = value as IfcCostValue;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier AssetID
	{
		get
		{
			if (_activated)
			{
				return _assetID;
			}
			Activate();
			return _assetID;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_assetID = v;
			}, _assetID, value, "AssetID", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
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
			}, _originalValue, value, "OriginalValue", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
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
			}, _currentValue, value, "CurrentValue", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcCostValue TotalReplacementCost
	{
		get
		{
			if (_activated)
			{
				return _totalReplacementCost;
			}
			Activate();
			return _totalReplacementCost;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCostValue v)
			{
				_totalReplacementCost = v;
			}, _totalReplacementCost, value, "TotalReplacementCost", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 16)]
	public IfcActorSelect Owner
	{
		get
		{
			if (_activated)
			{
				return _owner;
			}
			Activate();
			return _owner;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_owner = v;
			}, _owner, value, "Owner", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 17)]
	public IfcActorSelect User
	{
		get
		{
			if (_activated)
			{
				return _user;
			}
			Activate();
			return _user;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_user = v;
			}, _user, value, "User", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
	public IfcPerson ResponsiblePerson
	{
		get
		{
			if (_activated)
			{
				return _responsiblePerson;
			}
			Activate();
			return _responsiblePerson;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPerson v)
			{
				_responsiblePerson = v;
			}, _responsiblePerson, value, "ResponsiblePerson", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
	public IfcCalendarDate IncorporationDate
	{
		get
		{
			if (_activated)
			{
				return _incorporationDate;
			}
			Activate();
			return _incorporationDate;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_incorporationDate = v;
			}, _incorporationDate, value, "IncorporationDate", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcCostValue DepreciatedValue
	{
		get
		{
			if (_activated)
			{
				return _depreciatedValue;
			}
			Activate();
			return _depreciatedValue;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCostValue v)
			{
				_depreciatedValue = v;
			}, _depreciatedValue, value, "DepreciatedValue", 14);
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
			if (OriginalValue != null)
			{
				yield return OriginalValue;
			}
			if (CurrentValue != null)
			{
				yield return CurrentValue;
			}
			if (TotalReplacementCost != null)
			{
				yield return TotalReplacementCost;
			}
			if (Owner != null)
			{
				yield return Owner;
			}
			if (User != null)
			{
				yield return User;
			}
			if (ResponsiblePerson != null)
			{
				yield return ResponsiblePerson;
			}
			if (IncorporationDate != null)
			{
				yield return IncorporationDate;
			}
			if (DepreciatedValue != null)
			{
				yield return DepreciatedValue;
			}
		}
	}

	internal IfcAsset(IModel model, int label, bool activated)
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
			_assetID = value.StringVal;
			break;
		case 6:
			_originalValue = (IfcCostValue)value.EntityVal;
			break;
		case 7:
			_currentValue = (IfcCostValue)value.EntityVal;
			break;
		case 8:
			_totalReplacementCost = (IfcCostValue)value.EntityVal;
			break;
		case 9:
			_owner = (IfcActorSelect)value.EntityVal;
			break;
		case 10:
			_user = (IfcActorSelect)value.EntityVal;
			break;
		case 11:
			_responsiblePerson = (IfcPerson)value.EntityVal;
			break;
		case 12:
			_incorporationDate = (IfcCalendarDate)value.EntityVal;
			break;
		case 13:
			_depreciatedValue = (IfcCostValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAsset other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAssetClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAssetClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.IsGroupedBy.RelatedObjects, (Xbim.Ifc2x3.Kernel.IfcObjectDefinition Temp) => !Functions.TYPEOF(Temp).Contains("IFC2X3.IFCELEMENT"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAsset>()?.LogError($"Exception thrown evaluating where-clause 'IfcAsset.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAssetClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAsset.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
