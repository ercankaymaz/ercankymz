using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcPostalAddress", 662)]
public class IfcPostalAddress : IfcAddress, IInstantiableEntity, IPersistEntity, IPersist, IIfcPostalAddress, IIfcAddress, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType, IEquatable<IfcPostalAddress>, IExpressValidatable
{
	public enum IfcPostalAddressClause
	{
		WR1
	}

	private IfcLabel? _internalLocation;

	private readonly OptionalItemSet<IfcLabel> _addressLines;

	private IfcLabel? _postalBox;

	private IfcLabel? _town;

	private IfcLabel? _region;

	private IfcLabel? _postalCode;

	private IfcLabel? _country;

	IfcLabel? IIfcPostalAddress.InternalLocation
	{
		get
		{
			return InternalLocation;
		}
		set
		{
			InternalLocation = value;
		}
	}

	IItemSet<IfcLabel> IIfcPostalAddress.AddressLines => AddressLines;

	IfcLabel? IIfcPostalAddress.PostalBox
	{
		get
		{
			return PostalBox;
		}
		set
		{
			PostalBox = value;
		}
	}

	IfcLabel? IIfcPostalAddress.Town
	{
		get
		{
			return Town;
		}
		set
		{
			Town = value;
		}
	}

	IfcLabel? IIfcPostalAddress.Region
	{
		get
		{
			return Region;
		}
		set
		{
			Region = value;
		}
	}

	IfcLabel? IIfcPostalAddress.PostalCode
	{
		get
		{
			return PostalCode;
		}
		set
		{
			PostalCode = value;
		}
	}

	IfcLabel? IIfcPostalAddress.Country
	{
		get
		{
			return Country;
		}
		set
		{
			Country = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLabel? InternalLocation
	{
		get
		{
			if (_activated)
			{
				return _internalLocation;
			}
			Activate();
			return _internalLocation;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_internalLocation = v;
			}, _internalLocation, value, "InternalLocation", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<IfcLabel> AddressLines
	{
		get
		{
			if (_activated)
			{
				return _addressLines;
			}
			Activate();
			return _addressLines;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLabel? PostalBox
	{
		get
		{
			if (_activated)
			{
				return _postalBox;
			}
			Activate();
			return _postalBox;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_postalBox = v;
			}, _postalBox, value, "PostalBox", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLabel? Town
	{
		get
		{
			if (_activated)
			{
				return _town;
			}
			Activate();
			return _town;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_town = v;
			}, _town, value, "Town", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel? Region
	{
		get
		{
			if (_activated)
			{
				return _region;
			}
			Activate();
			return _region;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_region = v;
			}, _region, value, "Region", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcLabel? PostalCode
	{
		get
		{
			if (_activated)
			{
				return _postalCode;
			}
			Activate();
			return _postalCode;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_postalCode = v;
			}, _postalCode, value, "PostalCode", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcLabel? Country
	{
		get
		{
			if (_activated)
			{
				return _country;
			}
			Activate();
			return _country;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_country = v;
			}, _country, value, "Country", 10);
		}
	}

	internal IfcPostalAddress(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_addressLines = new OptionalItemSet<IfcLabel>(this, 0, 5);
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
			_internalLocation = value.StringVal;
			break;
		case 4:
			_addressLines.InternalAdd(value.StringVal);
			break;
		case 5:
			_postalBox = value.StringVal;
			break;
		case 6:
			_town = value.StringVal;
			break;
		case 7:
			_region = value.StringVal;
			break;
		case 8:
			_postalCode = value.StringVal;
			break;
		case 9:
			_country = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPostalAddress other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPostalAddressClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPostalAddressClause.WR1)
			{
				result = Functions.EXISTS(InternalLocation) || Functions.EXISTS(AddressLines) || Functions.EXISTS(PostalBox) || Functions.EXISTS(PostalCode) || Functions.EXISTS(Town) || Functions.EXISTS(Region) || Functions.EXISTS(Country);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPostalAddress>()?.LogError($"Exception thrown evaluating where-clause 'IfcPostalAddress.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPostalAddressClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPostalAddress.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
