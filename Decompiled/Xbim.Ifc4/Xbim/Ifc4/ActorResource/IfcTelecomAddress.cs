using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcTelecomAddress", 553)]
public class IfcTelecomAddress : IfcAddress, IInstantiableEntity, IPersistEntity, IPersist, IIfcTelecomAddress, IIfcAddress, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType, IEquatable<IfcTelecomAddress>, IExpressValidatable
{
	public enum IfcTelecomAddressClause
	{
		MinimumDataProvided
	}

	private readonly OptionalItemSet<IfcLabel> _telephoneNumbers;

	private readonly OptionalItemSet<IfcLabel> _facsimileNumbers;

	private IfcLabel? _pagerNumber;

	private readonly OptionalItemSet<IfcLabel> _electronicMailAddresses;

	private IfcURIReference? _wWWHomePageURL;

	private readonly OptionalItemSet<IfcURIReference> _messagingIDs;

	IItemSet<IfcLabel> IIfcTelecomAddress.TelephoneNumbers => TelephoneNumbers;

	IItemSet<IfcLabel> IIfcTelecomAddress.FacsimileNumbers => FacsimileNumbers;

	IfcLabel? IIfcTelecomAddress.PagerNumber
	{
		get
		{
			return PagerNumber;
		}
		set
		{
			PagerNumber = value;
		}
	}

	IItemSet<IfcLabel> IIfcTelecomAddress.ElectronicMailAddresses => ElectronicMailAddresses;

	IfcURIReference? IIfcTelecomAddress.WWWHomePageURL
	{
		get
		{
			return WWWHomePageURL;
		}
		set
		{
			WWWHomePageURL = value;
		}
	}

	IItemSet<IfcURIReference> IIfcTelecomAddress.MessagingIDs => MessagingIDs;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 6)]
	public IOptionalItemSet<IfcLabel> TelephoneNumbers
	{
		get
		{
			if (_activated)
			{
				return _telephoneNumbers;
			}
			Activate();
			return _telephoneNumbers;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<IfcLabel> FacsimileNumbers
	{
		get
		{
			if (_activated)
			{
				return _facsimileNumbers;
			}
			Activate();
			return _facsimileNumbers;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLabel? PagerNumber
	{
		get
		{
			if (_activated)
			{
				return _pagerNumber;
			}
			Activate();
			return _pagerNumber;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_pagerNumber = v;
			}, _pagerNumber, value, "PagerNumber", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 9)]
	public IOptionalItemSet<IfcLabel> ElectronicMailAddresses
	{
		get
		{
			if (_activated)
			{
				return _electronicMailAddresses;
			}
			Activate();
			return _electronicMailAddresses;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcURIReference? WWWHomePageURL
	{
		get
		{
			if (_activated)
			{
				return _wWWHomePageURL;
			}
			Activate();
			return _wWWHomePageURL;
		}
		set
		{
			SetValue(delegate(IfcURIReference? v)
			{
				_wWWHomePageURL = v;
			}, _wWWHomePageURL, value, "WWWHomePageURL", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 11)]
	public IOptionalItemSet<IfcURIReference> MessagingIDs
	{
		get
		{
			if (_activated)
			{
				return _messagingIDs;
			}
			Activate();
			return _messagingIDs;
		}
	}

	internal IfcTelecomAddress(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_telephoneNumbers = new OptionalItemSet<IfcLabel>(this, 0, 4);
		_facsimileNumbers = new OptionalItemSet<IfcLabel>(this, 0, 5);
		_electronicMailAddresses = new OptionalItemSet<IfcLabel>(this, 0, 7);
		_messagingIDs = new OptionalItemSet<IfcURIReference>(this, 0, 9);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_telephoneNumbers.InternalAdd(value.StringVal);
			break;
		case 4:
			_facsimileNumbers.InternalAdd(value.StringVal);
			break;
		case 5:
			_pagerNumber = value.StringVal;
			break;
		case 6:
			_electronicMailAddresses.InternalAdd(value.StringVal);
			break;
		case 7:
			_wWWHomePageURL = value.StringVal;
			break;
		case 8:
			_messagingIDs.InternalAdd(value.StringVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTelecomAddress other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTelecomAddressClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTelecomAddressClause.MinimumDataProvided)
			{
				result = Functions.EXISTS(TelephoneNumbers) || Functions.EXISTS(FacsimileNumbers) || Functions.EXISTS(PagerNumber) || Functions.EXISTS(ElectronicMailAddresses) || Functions.EXISTS(WWWHomePageURL) || Functions.EXISTS(MessagingIDs);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTelecomAddress>()?.LogError($"Exception thrown evaluating where-clause 'IfcTelecomAddress.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTelecomAddressClause.MinimumDataProvided))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTelecomAddress.MinimumDataProvided",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
