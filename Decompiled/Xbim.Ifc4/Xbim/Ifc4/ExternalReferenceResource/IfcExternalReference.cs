using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcExternalReference", 133)]
public abstract class IfcExternalReference : PersistEntity, IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IEquatable<IfcExternalReference>, IExpressValidatable
{
	public enum IfcExternalReferenceClause
	{
		WR1
	}

	private IfcURIReference? _location;

	private IfcIdentifier? _identification;

	private IfcLabel? _name;

	IfcURIReference? IIfcExternalReference.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value;
		}
	}

	IfcIdentifier? IIfcExternalReference.Identification
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

	IfcLabel? IIfcExternalReference.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcExternalReference.ExternalReferenceForResources => ExternalReferenceForResources;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcURIReference? Location
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
			SetValue(delegate(IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _identification, value, "Identification", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[InverseProperty("RelatingReference")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcExternalReferenceRelationship> ExternalReferenceForResources => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => Equals(e.RelatingReference), "RelatingReference", this);

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
			_identification = value.StringVal;
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
				result = Functions.EXISTS(Identification) || Functions.EXISTS(Location) || Functions.EXISTS(Name);
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
