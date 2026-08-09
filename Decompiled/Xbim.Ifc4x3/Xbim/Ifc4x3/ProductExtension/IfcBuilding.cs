using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcBuilding", 169)]
public class IfcBuilding : IfcFacility, IIfcBuilding, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuilding>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _elevationOfRefHeight;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _elevationOfTerrain;

	private IfcPostalAddress _buildingAddress;

	[CrossSchemaAttribute(typeof(IIfcBuilding), 10)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcBuilding.ElevationOfRefHeight
	{
		get
		{
			if (!ElevationOfRefHeight.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ElevationOfRefHeight.Value);
		}
		set
		{
			ElevationOfRefHeight = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBuilding), 11)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcBuilding.ElevationOfTerrain
	{
		get
		{
			if (!ElevationOfTerrain.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ElevationOfTerrain.Value);
		}
		set
		{
			ElevationOfTerrain = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBuilding), 12)]
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

	public IIfcSite Site => base.Decomposes.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates r) => r.RelatedObjects).OfType<IIfcSite>().FirstOrDefault();

	public IEnumerable<IIfcBuilding> Buildings => base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcBuilding>();

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	public IEnumerable<IIfcBuildingStorey> BuildingStoreys
	{
		get
		{
			List<IfcBuildingStorey> list = base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IfcBuildingStorey>().ToList();
			list.Sort(IfcBuildingStorey.CompareStoreysByElevation);
			return list;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? ElevationOfRefHeight
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_elevationOfRefHeight = v;
			}, _elevationOfRefHeight, value, "ElevationOfRefHeight", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 30)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? ElevationOfTerrain
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_elevationOfTerrain = v;
			}, _elevationOfTerrain, value, "ElevationOfTerrain", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 31)]
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
