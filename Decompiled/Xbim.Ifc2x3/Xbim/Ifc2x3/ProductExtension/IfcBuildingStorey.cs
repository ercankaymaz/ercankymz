using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcBuildingStorey", 459)]
public class IfcBuildingStorey : IfcSpatialStructureElement, IIfcBuildingStorey, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingStorey>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _elevation;

	[CrossSchemaAttribute(typeof(IIfcBuildingStorey), 10)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcBuildingStorey.Elevation
	{
		get
		{
			if (!Elevation.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Elevation.Value);
		}
		set
		{
			Elevation = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBuildingStorey), 8)]
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

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcSpatialElement.ContainsElements => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatingStructure as IfcBuildingStorey == this, "RelatingStructure", this);

	IEnumerable<IIfcRelServicesBuildings> IIfcSpatialElement.ServicedBySystems => base.Model.Instances.Where((IIfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcSpatialElement.ReferencesElements => base.Model.Instances.Where((IIfcRelReferencedInSpatialStructure e) => e.RelatingStructure as IfcBuildingStorey == this, "RelatingStructure", this);

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? Elevation
	{
		get
		{
			if (_activated)
			{
				return _elevation;
			}
			Activate();
			return _elevation;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_elevation = v;
			}, _elevation, value, "Elevation", 10);
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

	public Xbim.Ifc4.MeasureResource.IfcAreaMeasure? GrossFloorArea
	{
		get
		{
			IfcQuantityArea ifcQuantityArea = GetQuantity<IfcQuantityArea>("BaseQuantities", "GrossFloorArea") ?? GetQuantity<IfcQuantityArea>("GrossFloorArea");
			if (ifcQuantityArea != null)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(ifcQuantityArea.AreaValue);
			}
			return null;
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcLengthMeasure? TotalHeight
	{
		get
		{
			IfcQuantityLength ifcQuantityLength = GetQuantity<IfcQuantityLength>("BaseQuantities", "TotalHeight") ?? GetQuantity<IfcQuantityLength>("TotalHeight");
			if (ifcQuantityLength != null)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ifcQuantityLength.LengthValue);
			}
			return null;
		}
	}

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((Xbim.Ifc2x3.Kernel.IfcRelDecomposes s) => s.RelatedObjects).OfType<IfcSpace>();

	public IEnumerable<IIfcBuildingStorey> BuildingStoreys
	{
		get
		{
			List<IfcBuildingStorey> list = base.IsDecomposedBy.SelectMany((Xbim.Ifc2x3.Kernel.IfcRelDecomposes s) => s.RelatedObjects).OfType<IfcBuildingStorey>().ToList();
			list.Sort(CompareStoreysByElevation);
			return list;
		}
	}

	internal IfcBuildingStorey(IModel model, int label, bool activated)
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
			_elevation = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingStorey other)
	{
		return this == other;
	}

	internal static int CompareStoreysByElevation(IfcBuildingStorey x, IfcBuildingStorey y)
	{
		double num = x.Elevation ?? ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)0.0);
		double value = y.Elevation ?? ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)0.0);
		return num.CompareTo(value);
	}
}
