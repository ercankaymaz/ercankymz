using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.SharedFacilitiesElements;

[ExpressType("IfcAsset", 767)]
public class IfcAsset : Xbim.Ifc4x3.Kernel.IfcGroup, IIfcAsset, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAsset>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	private IfcCostValue _originalValue;

	private IfcCostValue _currentValue;

	private IfcCostValue _totalReplacementCost;

	private IfcActorSelect _owner;

	private IfcActorSelect _user;

	private IfcPerson _responsiblePerson;

	private Xbim.Ifc4x3.DateTimeResource.IfcDate? _incorporationDate;

	private IfcCostValue _depreciatedValue;

	[CrossSchemaAttribute(typeof(IIfcAsset), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcAsset.Identification
	{
		get
		{
			if (!Identification.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identification.Value);
		}
		set
		{
			Identification = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
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
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcAsset.IncorporationDate
	{
		get
		{
			if (!IncorporationDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(IncorporationDate.Value);
		}
		set
		{
			IncorporationDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDate?(new Xbim.Ifc4x3.DateTimeResource.IfcDate(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDate?)null));
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

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Identification
	{
		get
		{
			if (_activated)
			{
				return _identification;
			}
			Activate();
			return _identification;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
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

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 21)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 22)]
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

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 24)]
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

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 25)]
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

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDate? IncorporationDate
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDate? v)
			{
				_incorporationDate = v;
			}, _incorporationDate, value, "IncorporationDate", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 27)]
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
			_identification = value.StringVal;
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
			_incorporationDate = value.StringVal;
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
}
