using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcPerson", 198)]
public class IfcPerson : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcPerson, IfcActorSelect, IIfcActorSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPerson>, IExpressValidatable
{
	public enum IfcPersonClause
	{
		IdentifiablePerson,
		ValidSetOfNames
	}

	private IfcIdentifier? _identification;

	private IfcLabel? _familyName;

	private IfcLabel? _givenName;

	private readonly OptionalItemSet<IfcLabel> _middleNames;

	private readonly OptionalItemSet<IfcLabel> _prefixTitles;

	private readonly OptionalItemSet<IfcLabel> _suffixTitles;

	private readonly OptionalItemSet<IfcActorRole> _roles;

	private readonly OptionalItemSet<IfcAddress> _addresses;

	IfcIdentifier? IIfcPerson.Identification
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

	IfcLabel? IIfcPerson.FamilyName
	{
		get
		{
			return FamilyName;
		}
		set
		{
			FamilyName = value;
		}
	}

	IfcLabel? IIfcPerson.GivenName
	{
		get
		{
			return GivenName;
		}
		set
		{
			GivenName = value;
		}
	}

	IItemSet<IfcLabel> IIfcPerson.MiddleNames => MiddleNames;

	IItemSet<IfcLabel> IIfcPerson.PrefixTitles => PrefixTitles;

	IItemSet<IfcLabel> IIfcPerson.SuffixTitles => SuffixTitles;

	IItemSet<IIfcActorRole> IIfcPerson.Roles => new ProxyItemSet<IfcActorRole, IIfcActorRole>(Roles);

	IItemSet<IIfcAddress> IIfcPerson.Addresses => new ProxyItemSet<IfcAddress, IIfcAddress>(Addresses);

	IEnumerable<IIfcPersonAndOrganization> IIfcPerson.EngagedIn => EngagedIn;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
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
			}, _identification, value, "Identification", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? FamilyName
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
			SetValue(delegate(IfcLabel? v)
			{
				_familyName = v;
			}, _familyName, value, "FamilyName", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? GivenName
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
			SetValue(delegate(IfcLabel? v)
			{
				_givenName = v;
			}, _givenName, value, "GivenName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcLabel> MiddleNames
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
	public IOptionalItemSet<IfcLabel> PrefixTitles
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
	public IOptionalItemSet<IfcLabel> SuffixTitles
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

	internal IfcPerson(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_middleNames = new OptionalItemSet<IfcLabel>(this, 0, 4);
		_prefixTitles = new OptionalItemSet<IfcLabel>(this, 0, 5);
		_suffixTitles = new OptionalItemSet<IfcLabel>(this, 0, 6);
		_roles = new OptionalItemSet<IfcActorRole>(this, 0, 7);
		_addresses = new OptionalItemSet<IfcAddress>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_identification = value.StringVal;
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
			switch (clause)
			{
			case IfcPersonClause.IdentifiablePerson:
				result = Functions.EXISTS(Identification) || Functions.EXISTS(FamilyName) || Functions.EXISTS(GivenName);
				break;
			case IfcPersonClause.ValidSetOfNames:
				result = !Functions.EXISTS(MiddleNames) || Functions.EXISTS(FamilyName) || Functions.EXISTS(GivenName);
				break;
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
		if (!ValidateClause(IfcPersonClause.IdentifiablePerson))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPerson.IdentifiablePerson",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPersonClause.ValidSetOfNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPerson.ValidSetOfNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
