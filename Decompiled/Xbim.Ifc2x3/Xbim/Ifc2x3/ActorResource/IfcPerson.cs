using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcPerson", 198)]
public class IfcPerson : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcActorSelect, IExpressSelectType, IIfcActorSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPerson>, IIfcPerson, Xbim.Ifc4.ActorResource.IfcActorSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressValidatable
{
	public enum IfcPersonClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier? _id;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _familyName;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _givenName;

	private readonly OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> _middleNames;

	private readonly OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> _prefixTitles;

	private readonly OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> _suffixTitles;

	private readonly OptionalItemSet<IfcActorRole> _roles;

	private readonly OptionalItemSet<IfcAddress> _addresses;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier? Id
	{
		get
		{
			if (_activated)
			{
				return _id;
			}
			Activate();
			return _id;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier? v)
			{
				_id = v;
			}, _id, value, "Id", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? FamilyName
	{
		get
		{
			if (_activated)
			{
				return _familyName;
			}
			Activate();
			return _familyName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_familyName = v;
			}, _familyName, value, "FamilyName", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? GivenName
	{
		get
		{
			if (_activated)
			{
				return _givenName;
			}
			Activate();
			return _givenName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_givenName = v;
			}, _givenName, value, "GivenName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> MiddleNames
	{
		get
		{
			if (_activated)
			{
				return _middleNames;
			}
			Activate();
			return _middleNames;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 5)]
	public IOptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> PrefixTitles
	{
		get
		{
			if (_activated)
			{
				return _prefixTitles;
			}
			Activate();
			return _prefixTitles;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 6)]
	public IOptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> SuffixTitles
	{
		get
		{
			if (_activated)
			{
				return _suffixTitles;
			}
			Activate();
			return _suffixTitles;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<IfcActorRole> Roles
	{
		get
		{
			if (_activated)
			{
				return _roles;
			}
			Activate();
			return _roles;
		}
	}

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 8)]
	public IOptionalItemSet<IfcAddress> Addresses
	{
		get
		{
			if (_activated)
			{
				return _addresses;
			}
			Activate();
			return _addresses;
		}
	}

	[InverseProperty("ThePerson")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcPersonAndOrganization> EngagedIn => base.Model.Instances.Where((IfcPersonAndOrganization e) => Equals(e.ThePerson), "ThePerson", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcActorRole role in Roles)
			{
				yield return role;
			}
			foreach (IfcAddress address in Addresses)
			{
				yield return address;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcAddress address in Addresses)
			{
				yield return address;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerson), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcPerson.Identification
	{
		get
		{
			if (!Id.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Id.Value);
		}
		set
		{
			Id = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerson), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPerson.FamilyName
	{
		get
		{
			if (!FamilyName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(FamilyName.Value);
		}
		set
		{
			FamilyName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerson), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPerson.GivenName
	{
		get
		{
			if (!GivenName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(GivenName.Value);
		}
		set
		{
			GivenName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerson), 4)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcPerson.MiddleNames => new ProxyValueSet<Xbim.Ifc2x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(MiddleNames, (Xbim.Ifc2x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc2x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcPerson), 5)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcPerson.PrefixTitles => new ProxyValueSet<Xbim.Ifc2x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(PrefixTitles, (Xbim.Ifc2x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc2x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcPerson), 6)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcPerson.SuffixTitles => new ProxyValueSet<Xbim.Ifc2x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(SuffixTitles, (Xbim.Ifc2x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc2x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcPerson), 7)]
	IItemSet<IIfcActorRole> IIfcPerson.Roles => new ProxyItemSet<IfcActorRole, IIfcActorRole>(Roles);

	[CrossSchemaAttribute(typeof(IIfcPerson), 8)]
	IItemSet<IIfcAddress> IIfcPerson.Addresses => new ProxyItemSet<IfcAddress, IIfcAddress>(Addresses);

	IEnumerable<IIfcPersonAndOrganization> IIfcPerson.EngagedIn => base.Model.Instances.Where((IIfcPersonAndOrganization e) => e.ThePerson as IfcPerson == this, "ThePerson", this);

	internal IfcPerson(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_middleNames = new OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel>(this, 0, 4);
		_prefixTitles = new OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel>(this, 0, 5);
		_suffixTitles = new OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel>(this, 0, 6);
		_roles = new OptionalItemSet<IfcActorRole>(this, 0, 7);
		_addresses = new OptionalItemSet<IfcAddress>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_id = value.StringVal;
			break;
		case 1:
			_familyName = value.StringVal;
			break;
		case 2:
			_givenName = value.StringVal;
			break;
		case 3:
			_middleNames.InternalAdd(value.StringVal);
			break;
		case 4:
			_prefixTitles.InternalAdd(value.StringVal);
			break;
		case 5:
			_suffixTitles.InternalAdd(value.StringVal);
			break;
		case 6:
			_roles.InternalAdd((IfcActorRole)value.EntityVal);
			break;
		case 7:
			_addresses.InternalAdd((IfcAddress)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPerson other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPersonClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPersonClause.WR1)
			{
				result = Functions.EXISTS(FamilyName) || Functions.EXISTS(GivenName);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPerson>()?.LogError($"Exception thrown evaluating where-clause 'IfcPerson.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPersonClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPerson.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
