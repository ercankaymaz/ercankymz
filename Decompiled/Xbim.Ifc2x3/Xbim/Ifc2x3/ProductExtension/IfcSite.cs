using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcSite", 349)]
public class IfcSite : IfcSpatialStructureElement, IIfcSite, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSite>
{
	private Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? _refLatitude;

	private Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? _refLongitude;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _refElevation;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _landTitleNumber;

	private IfcPostalAddress _siteAddress;

	[CrossSchemaAttribute(typeof(IIfcSite), 10)]
	Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure? IIfcSite.RefLatitude
	{
		get
		{
			if (!RefLatitude.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure(RefLatitude.Value);
		}
		set
		{
			RefLatitude = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSite), 11)]
	Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure? IIfcSite.RefLongitude
	{
		get
		{
			if (!RefLongitude.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure(RefLongitude.Value);
		}
		set
		{
			RefLongitude = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSite), 12)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSite.RefElevation
	{
		get
		{
			if (!RefElevation.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(RefElevation.Value);
		}
		set
		{
			RefElevation = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSite), 13)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSite.LandTitleNumber
	{
		get
		{
			if (!LandTitleNumber.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LandTitleNumber.Value);
		}
		set
		{
			LandTitleNumber = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSite), 14)]
	IIfcPostalAddress IIfcSite.SiteAddress
	{
		get
		{
			return SiteAddress;
		}
		set
		{
			SiteAddress = value as IfcPostalAddress;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSite), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpatialElement.LongName
	{
		get
		{
			if (!base.LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(base.LongName.Value);
		}
		set
		{
			base.LongName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcSpatialElement.ContainsElements => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatingStructure as IfcSite == this, "RelatingStructure", this);

	IEnumerable<IIfcRelServicesBuildings> IIfcSpatialElement.ServicedBySystems => base.Model.Instances.Where((IIfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcSpatialElement.ReferencesElements => base.Model.Instances.Where((IIfcRelReferencedInSpatialStructure e) => e.RelatingStructure as IfcSite == this, "RelatingStructure", this);

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? RefLatitude
	{
		get
		{
			if (_activated)
			{
				return _refLatitude;
			}
			Activate();
			return _refLatitude;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? v)
			{
				_refLatitude = v;
			}, _refLatitude, value, "RefLatitude", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? RefLongitude
	{
		get
		{
			if (_activated)
			{
				return _refLongitude;
			}
			Activate();
			return _refLongitude;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure? v)
			{
				_refLongitude = v;
			}, _refLongitude, value, "RefLongitude", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? RefElevation
	{
		get
		{
			if (_activated)
			{
				return _refElevation;
			}
			Activate();
			return _refElevation;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_refElevation = v;
			}, _refElevation, value, "RefElevation", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? LandTitleNumber
	{
		get
		{
			if (_activated)
			{
				return _landTitleNumber;
			}
			Activate();
			return _landTitleNumber;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_landTitleNumber = v;
			}, _landTitleNumber, value, "LandTitleNumber", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
	public IfcPostalAddress SiteAddress
	{
		get
		{
			if (_activated)
			{
				return _siteAddress;
			}
			Activate();
			return _siteAddress;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPostalAddress v)
			{
				_siteAddress = v;
			}, _siteAddress, value, "SiteAddress", 14);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (SiteAddress != null)
			{
				yield return SiteAddress;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcAreaMeasure? FootprintArea
	{
		get
		{
			IfcQuantityArea quantity = GetQuantity<IfcQuantityArea>("BaseQuantities", "GrossArea");
			if (quantity == null)
			{
				quantity = GetQuantity<IfcQuantityArea>("GrossArea");
			}
			if (quantity != null)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(quantity.AreaValue);
			}
			return GetPropertySingleValue<Xbim.Ifc4.MeasureResource.IfcAreaMeasure>("PSet_Revit_Dimensions", "Projected Area");
		}
	}

	public IEnumerable<IIfcBuilding> Buildings => base.IsDecomposedBy.OfType<Xbim.Ifc2x3.Kernel.IfcRelAggregates>().SelectMany((Xbim.Ifc2x3.Kernel.IfcRelAggregates rel) => rel.RelatedObjects.OfType<IfcBuilding>());

	public IEnumerable<IIfcSpace> Spaces
	{
		get
		{
			if (base.IsDecomposedBy != null)
			{
				return base.IsDecomposedBy.SelectMany((Xbim.Ifc2x3.Kernel.IfcRelDecomposes s) => s.RelatedObjects).OfType<IfcSpace>();
			}
			return Enumerable.Empty<IfcSpace>();
		}
	}

	public IfcShapeRepresentation FootPrintRepresentation
	{
		get
		{
			if (base.Representation != null)
			{
				return base.Representation.Representations.OfType<IfcShapeRepresentation>().FirstOrDefault((IfcShapeRepresentation r) => string.Compare(r.RepresentationIdentifier.GetValueOrDefault(), "FootPrint", ignoreCase: true) == 0);
			}
			return null;
		}
	}

	internal IfcSite(IModel model, int label, bool activated)
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
		case 5:
		case 6:
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
		{
			if (!_refLatitude.HasValue)
			{
				_refLatitude = default(Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure);
			}
			Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure comp2 = _refLatitude.Value;
			Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure.Add(ref comp2, value.IntegerVal);
			_refLatitude = comp2;
			break;
		}
		case 10:
		{
			if (!_refLongitude.HasValue)
			{
				_refLongitude = default(Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure);
			}
			Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure comp = _refLongitude.Value;
			Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure.Add(ref comp, value.IntegerVal);
			_refLongitude = comp;
			break;
		}
		case 11:
			_refElevation = value.RealVal;
			break;
		case 12:
			_landTitleNumber = value.StringVal;
			break;
		case 13:
			_siteAddress = (IfcPostalAddress)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSite other)
	{
		return this == other;
	}

	public void AddBuilding(IfcBuilding building)
	{
		Xbim.Ifc2x3.Kernel.IfcRelDecomposes ifcRelDecomposes = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelDecomposes == null)
		{
			Xbim.Ifc2x3.Kernel.IfcRelAggregates ifcRelAggregates = base.Model.Instances.New<Xbim.Ifc2x3.Kernel.IfcRelAggregates>();
			ifcRelAggregates.RelatingObject = this;
			ifcRelAggregates.RelatedObjects.Add(building);
		}
		else
		{
			ifcRelDecomposes.RelatedObjects.Add(building);
		}
	}

	public void AddSite(IfcSite subSite)
	{
		Xbim.Ifc2x3.Kernel.IfcRelDecomposes ifcRelDecomposes = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelDecomposes == null)
		{
			Xbim.Ifc2x3.Kernel.IfcRelAggregates ifcRelAggregates = base.Model.Instances.New<Xbim.Ifc2x3.Kernel.IfcRelAggregates>();
			ifcRelAggregates.RelatingObject = this;
			ifcRelAggregates.RelatedObjects.Add(subSite);
		}
		else
		{
			ifcRelDecomposes.RelatedObjects.Add(subSite);
		}
	}

	public void AddElement(Xbim.Ifc2x3.Kernel.IfcProduct element)
	{
		IfcRelContainedInSpatialStructure ifcRelContainedInSpatialStructure = base.ContainsElements.FirstOrDefault();
		if (ifcRelContainedInSpatialStructure == null)
		{
			IfcRelContainedInSpatialStructure ifcRelContainedInSpatialStructure2 = base.Model.Instances.New<IfcRelContainedInSpatialStructure>();
			ifcRelContainedInSpatialStructure2.RelatingStructure = this;
			ifcRelContainedInSpatialStructure2.RelatedElements.Add(element);
		}
		else
		{
			ifcRelContainedInSpatialStructure.RelatedElements.Add(element);
		}
	}
}
