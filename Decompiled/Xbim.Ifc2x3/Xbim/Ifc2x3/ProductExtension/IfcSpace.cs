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
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcSpace", 454)]
public class IfcSpace : IfcSpatialStructureElement, IIfcSpace, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpace>
{
	private Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum? _predefinedType;

	private IfcInternalOrExternalEnum _interiorOrExteriorSpace;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _elevationWithFlooring;

	[CrossSchemaAttribute(typeof(IIfcSpace), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum? IIfcSpace.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -10);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpace), 11)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSpace.ElevationWithFlooring
	{
		get
		{
			if (!ElevationWithFlooring.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ElevationWithFlooring.Value);
		}
		set
		{
			ElevationWithFlooring = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpace), 8)]
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

	IEnumerable<IIfcRelCoversSpaces> IIfcSpace.HasCoverings => base.Model.Instances.Where((IIfcRelCoversSpaces e) => e.RelatingSpace as IfcSpace == this, "RelatingSpace", this);

	IEnumerable<IIfcRelSpaceBoundary> IIfcSpace.BoundedBy => base.Model.Instances.Where((IIfcRelSpaceBoundary e) => e.RelatingSpace as IfcSpace == this, "RelatingSpace", this);

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcSpatialElement.ContainsElements => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatingStructure as IfcSpace == this, "RelatingStructure", this);

	IEnumerable<IIfcRelServicesBuildings> IIfcSpatialElement.ServicedBySystems => base.Model.Instances.Where((IIfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcSpatialElement.ReferencesElements => base.Model.Instances.Where((IIfcRelReferencedInSpatialStructure e) => e.RelatingStructure as IfcSpace == this, "RelatingStructure", this);

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((Xbim.Ifc2x3.Kernel.IfcRelDecomposes s) => s.RelatedObjects).OfType<IfcSpace>();

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcInternalOrExternalEnum InteriorOrExteriorSpace
	{
		get
		{
			if (_activated)
			{
				return _interiorOrExteriorSpace;
			}
			Activate();
			return _interiorOrExteriorSpace;
		}
		set
		{
			SetValue(delegate(IfcInternalOrExternalEnum v)
			{
				_interiorOrExteriorSpace = v;
			}, _interiorOrExteriorSpace, value, "InteriorOrExteriorSpace", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? ElevationWithFlooring
	{
		get
		{
			if (_activated)
			{
				return _elevationWithFlooring;
			}
			Activate();
			return _elevationWithFlooring;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_elevationWithFlooring = v;
			}, _elevationWithFlooring, value, "ElevationWithFlooring", 11);
		}
	}

	[InverseProperty("RelatedSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
	public IEnumerable<IfcRelCoversSpaces> HasCoverings => base.Model.Instances.Where((IfcRelCoversSpaces e) => Equals(e.RelatedSpace), "RelatedSpace", this);

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 22)]
	public IEnumerable<IfcRelSpaceBoundary> BoundedBy => base.Model.Instances.Where((IfcRelSpaceBoundary e) => Equals(e.RelatingSpace), "RelatingSpace", this);

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

	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure? GrossFloorArea
	{
		get
		{
			IfcQuantityArea ifcQuantityArea = GetQuantity<IfcQuantityArea>("BaseQuantities", "GrossFloorArea") ?? GetQuantity<IfcQuantityArea>("GrossFloorArea");
			if (!(ifcQuantityArea != null))
			{
				return null;
			}
			return ifcQuantityArea.AreaValue;
		}
	}

	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure? NetFloorArea
	{
		get
		{
			IfcQuantityArea ifcQuantityArea = GetQuantity<IfcQuantityArea>("BaseQuantities", "NetFloorArea") ?? GetQuantity<IfcQuantityArea>("NetFloorArea");
			if (ifcQuantityArea != null)
			{
				return ifcQuantityArea.AreaValue;
			}
			ifcQuantityArea = GetQuantity<IfcQuantityArea>("GSA Space Areas", "GSA BIM Area");
			if (ifcQuantityArea != null)
			{
				return ifcQuantityArea.AreaValue;
			}
			return null;
		}
	}

	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? Height
	{
		get
		{
			IfcQuantityLength ifcQuantityLength = GetQuantity<IfcQuantityLength>("BaseQuantities", "Height") ?? GetQuantity<IfcQuantityLength>("Height");
			if (!(ifcQuantityLength != null))
			{
				return null;
			}
			return ifcQuantityLength.LengthValue;
		}
	}

	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? GrossPerimeter
	{
		get
		{
			IfcQuantityLength ifcQuantityLength = GetQuantity<IfcQuantityLength>("BaseQuantities", "GrossPerimeter") ?? GetQuantity<IfcQuantityLength>("GrossPerimeter");
			if (ifcQuantityLength != null)
			{
				return ifcQuantityLength.LengthValue;
			}
			return null;
		}
	}

	internal IfcSpace(IModel model, int label, bool activated)
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
			_interiorOrExteriorSpace = (IfcInternalOrExternalEnum)Enum.Parse(typeof(IfcInternalOrExternalEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_elevationWithFlooring = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpace other)
	{
		return this == other;
	}
}
