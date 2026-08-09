using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationOrganizationResource;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcExternalReference", 133)]
public abstract class IfcExternalReference : PersistEntity, Xbim.Ifc4x3.PresentationOrganizationResource.IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IPersist, IPersistEntity, Xbim.Ifc4x3.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IEquatable<IfcExternalReference>, IIfcExternalReference, Xbim.Ifc4.PresentationOrganizationResource.IfcLightDistributionDataSourceSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcURIReference? _location;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcURIReference? Location
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _identification, value, "Identification", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[InverseProperty("RelatingReference")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcExternalReferenceRelationship> ExternalReferenceForResources => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => Equals(e.RelatingReference), "RelatingReference", this);

	[CrossSchemaAttribute(typeof(IIfcExternalReference), 1)]
	Xbim.Ifc4.ExternalReferenceResource.IfcURIReference? IIfcExternalReference.Location
	{
		get
		{
			if (!Location.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.ExternalReferenceResource.IfcURIReference(Location.Value);
		}
		set
		{
			Location = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcURIReference?(new Xbim.Ifc4x3.MeasureResource.IfcURIReference(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcURIReference?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReference), 2)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExternalReference.Identification
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
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
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
}
