using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcPostalAddress", 662)]
public class IfcPostalAddress : IfcAddress, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcPostalAddress>, IIfcPostalAddress, IIfcAddress, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType, IExpressValidatable
{
	public enum IfcPostalAddressClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _internalLocation;

	private readonly OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> _addressLines;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _postalBox;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _town;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _region;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _postalCode;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _country;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? InternalLocation
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_internalLocation = v;
			}, _internalLocation, value, "InternalLocation", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel> AddressLines
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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? PostalBox
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_postalBox = v;
			}, _postalBox, value, "PostalBox", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Town
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_town = v;
			}, _town, value, "Town", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Region
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_region = v;
			}, _region, value, "Region", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? PostalCode
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_postalCode = v;
			}, _postalCode, value, "PostalCode", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Country
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_country = v;
			}, _country, value, "Country", 10);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.InternalLocation
	{
		get
		{
			if (!InternalLocation.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(InternalLocation.Value);
		}
		set
		{
			InternalLocation = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 5)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcPostalAddress.AddressLines => new ProxyValueSet<Xbim.Ifc2x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(AddressLines, (Xbim.Ifc2x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc2x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.PostalBox
	{
		get
		{
			if (!PostalBox.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(PostalBox.Value);
		}
		set
		{
			PostalBox = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.Town
	{
		get
		{
			if (!Town.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Town.Value);
		}
		set
		{
			Town = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.Region
	{
		get
		{
			if (!Region.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Region.Value);
		}
		set
		{
			Region = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.PostalCode
	{
		get
		{
			if (!PostalCode.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(PostalCode.Value);
		}
		set
		{
			PostalCode = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPostalAddress), 10)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPostalAddress.Country
	{
		get
		{
			if (!Country.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Country.Value);
		}
		set
		{
			Country = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	internal IfcPostalAddress(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_addressLines = new OptionalItemSet<Xbim.Ifc2x3.MeasureResource.IfcLabel>(this, 0, 5);
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
