using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcBuilding", 169)]
public class IfcBuilding : IfcSpatialStructureElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcBuilding, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuilding>
{
	private IfcLengthMeasure? _elevationOfRefHeight;

	private IfcLengthMeasure? _elevationOfTerrain;

	private IfcPostalAddress _buildingAddress;

	IfcLengthMeasure? IIfcBuilding.ElevationOfRefHeight
	{
		get
		{
			return ElevationOfRefHeight;
		}
		set
		{
			ElevationOfRefHeight = value;
		}
	}

	IfcLengthMeasure? IIfcBuilding.ElevationOfTerrain
	{
		get
		{
			return ElevationOfTerrain;
		}
		set
		{
			ElevationOfTerrain = value;
		}
	}

	IIfcPostalAddress IIfcBuilding.BuildingAddress
	{
		get
		{
			return BuildingAddress;
		}
		set
		{
			BuildingAddress = value as IfcPostalAddress;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcLengthMeasure? ElevationOfRefHeight
	{
		get
		{
			if (_activated)
			{
				return _elevationOfRefHeight;
			}
			Activate();
			return _elevationOfRefHeight;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_elevationOfRefHeight = v;
			}, _elevationOfRefHeight, value, "ElevationOfRefHeight", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public IfcLengthMeasure? ElevationOfTerrain
	{
		get
		{
			if (_activated)
			{
				return _elevationOfTerrain;
			}
			Activate();
			return _elevationOfTerrain;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_elevationOfTerrain = v;
			}, _elevationOfTerrain, value, "ElevationOfTerrain", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 27)]
	public IfcPostalAddress BuildingAddress
	{
		get
		{
			if (_activated)
			{
				return _buildingAddress;
			}
			Activate();
			return _buildingAddress;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPostalAddress v)
			{
				_buildingAddress = v;
			}, _buildingAddress, value, "BuildingAddress", 12);
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
			if (BuildingAddress != null)
			{
				yield return BuildingAddress;
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

	public IIfcSite Site => base.Decomposes.SelectMany((IfcRelAggregates r) => r.RelatedObjects).OfType<IIfcSite>().FirstOrDefault();

	public IEnumerable<IIfcBuilding> Buildings => base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcBuilding>();

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	public IEnumerable<IIfcBuildingStorey> BuildingStoreys
	{
		get
		{
			List<IIfcBuildingStorey> list = base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcBuildingStorey>().ToList();
			list.Sort(IfcBuildingStorey.CompareStoreysByElevation);
			return list;
		}
	}

	internal IfcBuilding(IModel model, int label, bool activated)
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
			_elevationOfRefHeight = value.RealVal;
			break;
		case 10:
			_elevationOfTerrain = value.RealVal;
			break;
		case 11:
			_buildingAddress = (IfcPostalAddress)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuilding other)
	{
		return this == other;
	}
}
