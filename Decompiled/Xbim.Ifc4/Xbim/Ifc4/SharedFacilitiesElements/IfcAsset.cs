using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.SharedFacilitiesElements;

[ExpressType("IfcAsset", 767)]
public class IfcAsset : IfcGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcAsset, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcAsset>
{
	private IfcIdentifier? _identification;

	private IfcCostValue _originalValue;

	private IfcCostValue _currentValue;

	private IfcCostValue _totalReplacementCost;

	private IfcActorSelect _owner;

	private IfcActorSelect _user;

	private IfcPerson _responsiblePerson;

	private IfcDate? _incorporationDate;

	private IfcCostValue _depreciatedValue;

	IfcIdentifier? IIfcAsset.Identification
	{
		get
		{
			return Identification;
		}
		set
		{
			Identification = value;
		}
	}

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

	IIfcActorSelect IIfcAsset.Owner
	{
		get
		{
			return Owner;
		}
		set
		{
			Owner = value as IfcActorSelect;
		}
	}

	IIfcActorSelect IIfcAsset.User
	{
		get
		{
			return User;
		}
		set
		{
			User = value as IfcActorSelect;
		}
	}

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

	IfcDate? IIfcAsset.IncorporationDate
	{
		get
		{
			return IncorporationDate;
		}
		set
		{
			IncorporationDate = value;
		}
	}

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

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcIdentifier? Identification
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
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

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 21)]
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

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 22)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
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

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 24)]
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

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcDate? IncorporationDate
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
			SetValue(delegate(IfcDate? v)
			{
				_incorporationDate = v;
			}, _incorporationDate, value, "IncorporationDate", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 26)]
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
