using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcExternalReference", 133)]
public abstract class IfcExternalReference : PersistEntity, Xbim.Ifc2x3.PresentationOrganizationResource.IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IPersist, IPersistEntity, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IEquatable<IfcExternalReference>, IIfcExternalReference, Xbim.Ifc4.PresentationOrganizationResource.IfcLightDistributionDataSourceSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressValidatable
{
	public enum IfcExternalReferenceClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _location;

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier? _itemReference;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Location
	{
		get
		{
			if (_activated)
			{
				return _location;
			}
			Activate();
			return _location;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier? ItemReference
	{
		get
		{
			if (_activated)
			{
				return _itemReference;
			}
			Activate();
			return _itemReference;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier? v)
			{
				_itemReference = v;
			}, _itemReference, value, "ItemReference", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReference), 1)]
	IfcURIReference? IIfcExternalReference.Location
	{
		get
		{
			if (!Location.HasValue)
			{
				return null;
			}
			return new IfcURIReference(Location.Value);
		}
		set
		{
			Location = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReference), 2)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExternalReference.Identification
	{
		get
		{
			if (!ItemReference.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(ItemReference.Value);
		}
		set
		{
			ItemReference = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReference), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcExternalReference.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcExternalReference.ExternalReferenceForResources => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatingReference as IfcExternalReference == this, "RelatingReference", this);

	internal IfcExternalReference(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_location = value.StringVal;
			break;
		case 1:
			_itemReference = value.StringVal;
			break;
		case 2:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExternalReference other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcExternalReferenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcExternalReferenceClause.WR1)
			{
				result = Functions.EXISTS(ItemReference) || Functions.EXISTS(Location) || Functions.EXISTS(Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcExternalReference>()?.LogError($"Exception thrown evaluating where-clause 'IfcExternalReference.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcExternalReferenceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcExternalReference.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
