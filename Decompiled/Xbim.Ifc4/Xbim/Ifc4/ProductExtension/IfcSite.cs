using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSite", 349)]
public class IfcSite : IfcSpatialStructureElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcSite, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSite>
{
	private IfcCompoundPlaneAngleMeasure? _refLatitude;

	private IfcCompoundPlaneAngleMeasure? _refLongitude;

	private IfcLengthMeasure? _refElevation;

	private IfcLabel? _landTitleNumber;

	private IfcPostalAddress _siteAddress;

	IfcCompoundPlaneAngleMeasure? IIfcSite.RefLatitude
	{
		get
		{
			return RefLatitude;
		}
		set
		{
			RefLatitude = value;
		}
	}

	IfcCompoundPlaneAngleMeasure? IIfcSite.RefLongitude
	{
		get
		{
			return RefLongitude;
		}
		set
		{
			RefLongitude = value;
		}
	}

	IfcLengthMeasure? IIfcSite.RefElevation
	{
		get
		{
			return RefElevation;
		}
		set
		{
			RefElevation = value;
		}
	}

	IfcLabel? IIfcSite.LandTitleNumber
	{
		get
		{
			return LandTitleNumber;
		}
		set
		{
			LandTitleNumber = value;
		}
	}

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

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcCompoundPlaneAngleMeasure? RefLatitude
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
			SetValue(delegate(IfcCompoundPlaneAngleMeasure? v)
			{
				_refLatitude = v;
			}, _refLatitude, value, "RefLatitude", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public IfcCompoundPlaneAngleMeasure? RefLongitude
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
			SetValue(delegate(IfcCompoundPlaneAngleMeasure? v)
			{
				_refLongitude = v;
			}, _refLongitude, value, "RefLongitude", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public IfcLengthMeasure? RefElevation
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
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_refElevation = v;
			}, _refElevation, value, "RefElevation", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public IfcLabel? LandTitleNumber
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
			SetValue(delegate(IfcLabel? v)
			{
				_landTitleNumber = v;
			}, _landTitleNumber, value, "LandTitleNumber", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 29)]
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

	public IEnumerable<IIfcBuilding> Buildings => base.IsDecomposedBy.SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IfcBuilding>());

	public IEnumerable<IfcSpace> Spaces
	{
		get
		{
			if (base.IsDecomposedBy != null)
			{
				return base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IfcSpace>();
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
				_refLatitude = default(IfcCompoundPlaneAngleMeasure);
			}
			IfcCompoundPlaneAngleMeasure comp2 = _refLatitude.Value;
			IfcCompoundPlaneAngleMeasure.Add(ref comp2, value.IntegerVal);
			_refLatitude = comp2;
			break;
		}
		case 10:
		{
			if (!_refLongitude.HasValue)
			{
				_refLongitude = default(IfcCompoundPlaneAngleMeasure);
			}
			IfcCompoundPlaneAngleMeasure comp = _refLongitude.Value;
			IfcCompoundPlaneAngleMeasure.Add(ref comp, value.IntegerVal);
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
		IfcRelAggregates ifcRelAggregates = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			IfcRelAggregates ifcRelAggregates2 = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates2.RelatingObject = this;
			ifcRelAggregates2.RelatedObjects.Add(building);
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(building);
		}
	}

	public void AddSite(IfcSite subSite)
	{
		IfcRelAggregates ifcRelAggregates = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			IfcRelAggregates ifcRelAggregates2 = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates2.RelatingObject = this;
			ifcRelAggregates2.RelatedObjects.Add(subSite);
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(subSite);
		}
	}
}
