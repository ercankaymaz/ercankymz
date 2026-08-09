using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcBuildingStorey", 459)]
public class IfcBuildingStorey : IfcSpatialStructureElement, IIfcBuildingStorey, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingStorey>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _elevation;

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
			Elevation = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	public IIfcSite Site => base.Decomposes.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates r) => r.RelatedObjects).OfType<IIfcSite>().FirstOrDefault();

	public IEnumerable<IIfcBuilding> Buildings => base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcBuilding>();

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	public IEnumerable<IIfcBuildingStorey> BuildingStoreys
	{
		get
		{
			List<IfcBuildingStorey> list = base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IfcBuildingStorey>().ToList();
			list.Sort(CompareStoreysByElevation);
			return list;
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcAreaMeasure? GrossFloorArea => (GetQuantity<IIfcQuantityArea>("BaseQuantities", "GrossFloorArea") ?? GetQuantity<IIfcQuantityArea>("GrossFloorArea"))?.AreaValue;

	public Xbim.Ifc4.MeasureResource.IfcLengthMeasure? TotalHeight => (GetQuantity<IIfcQuantityLength>("BaseQuantities", "TotalHeight") ?? GetQuantity<IIfcQuantityLength>("TotalHeight"))?.LengthValue;

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? Elevation
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
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

	public TQType GetQuantity<TQType>(string pSetName, string qName) where TQType : IIfcPhysicalQuantity
	{
		Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition ifcPropertySetDefinition = base.IsDefinedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).FirstOrDefault((Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition r) => r is IfcElementQuantity && r.Name == (Xbim.Ifc4x3.MeasureResource.IfcLabel?)(Xbim.Ifc4x3.MeasureResource.IfcLabel)pSetName);
		if (ifcPropertySetDefinition == null)
		{
			return default(TQType);
		}
		IfcElementQuantity ifcElementQuantity = ifcPropertySetDefinition as IfcElementQuantity;
		if (!(ifcElementQuantity == null))
		{
			return ifcElementQuantity.Quantities.OfType<TQType>().FirstOrDefault((TQType q) => q.Name == (Xbim.Ifc4.MeasureResource.IfcLabel)qName);
		}
		return default(TQType);
	}

	public TQType GetQuantity<TQType>(string qName) where TQType : IIfcPhysicalQuantity
	{
		return base.IsDefinedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcElementQuantity>().SelectMany((IIfcElementQuantity qset) => qset.Quantities)
			.OfType<TQType>()
			.FirstOrDefault((TQType q) => q.Name == (Xbim.Ifc4.MeasureResource.IfcLabel)qName);
	}

	internal static int CompareStoreysByElevation(IfcBuildingStorey x, IfcBuildingStorey y)
	{
		double num = x.Elevation ?? ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)0.0);
		double value = y.Elevation ?? ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)0.0);
		return num.CompareTo(value);
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
}
