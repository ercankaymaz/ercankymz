using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcBuildingStorey", 459)]
public class IfcBuildingStorey : IfcSpatialStructureElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcBuildingStorey, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingStorey>
{
	private IfcLengthMeasure? _elevation;

	IfcLengthMeasure? IIfcBuildingStorey.Elevation
	{
		get
		{
			return Elevation;
		}
		set
		{
			Elevation = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcLengthMeasure? Elevation
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
			SetValue(delegate(IfcLengthMeasure? v)
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

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	public IEnumerable<IIfcBuildingStorey> BuildingStoreys
	{
		get
		{
			List<IIfcBuildingStorey> list = base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcBuildingStorey>().ToList();
			list.Sort(CompareStoreysByElevation);
			return list;
		}
	}

	public IfcAreaMeasure? GrossFloorArea => (GetQuantity<IIfcQuantityArea>("BaseQuantities", "GrossFloorArea") ?? GetQuantity<IIfcQuantityArea>("GrossFloorArea"))?.AreaValue;

	public IfcLengthMeasure? TotalHeight => (GetQuantity<IIfcQuantityLength>("BaseQuantities", "TotalHeight") ?? GetQuantity<IIfcQuantityLength>("TotalHeight"))?.LengthValue;

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

	internal static int CompareStoreysByElevation(IIfcBuildingStorey x, IIfcBuildingStorey y)
	{
		double num = x.Elevation ?? ((IfcLengthMeasure)0.0);
		double value = y.Elevation ?? ((IfcLengthMeasure)0.0);
		return num.CompareTo(value);
	}
}
