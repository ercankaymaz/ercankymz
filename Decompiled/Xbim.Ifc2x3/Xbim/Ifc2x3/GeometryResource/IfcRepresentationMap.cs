using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcRepresentationMap", 95)]
public class IfcRepresentationMap : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRepresentationMap>, IIfcRepresentationMap, IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType
{
	private IfcAxis2Placement _mappingOrigin;

	private Xbim.Ifc2x3.RepresentationResource.IfcRepresentation _mappedRepresentation;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcAxis2Placement MappingOrigin
	{
		get
		{
			if (_activated)
			{
				return _mappingOrigin;
			}
			Activate();
			return _mappingOrigin;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_mappingOrigin = v;
			}, _mappingOrigin, value, "MappingOrigin", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.RepresentationResource.IfcRepresentation MappedRepresentation
	{
		get
		{
			if (_activated)
			{
				return _mappedRepresentation;
			}
			Activate();
			return _mappedRepresentation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.RepresentationResource.IfcRepresentation v)
			{
				_mappedRepresentation = v;
			}, _mappedRepresentation, value, "MappedRepresentation", 2);
		}
	}

	[InverseProperty("MappingSource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcMappedItem> MapUsage => base.Model.Instances.Where((IfcMappedItem e) => Equals(e.MappingSource), "MappingSource", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (MappingOrigin != null)
			{
				yield return MappingOrigin;
			}
			if (MappedRepresentation != null)
			{
				yield return MappedRepresentation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (MappedRepresentation != null)
			{
				yield return MappedRepresentation;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentationMap), 1)]
	IIfcAxis2Placement IIfcRepresentationMap.MappingOrigin
	{
		get
		{
			if (MappingOrigin == null)
			{
				return null;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = MappingOrigin as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				return ifcAxis2Placement2D;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = MappingOrigin as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				return ifcAxis2Placement3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				MappingOrigin = null;
				return;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = value as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				MappingOrigin = ifcAxis2Placement2D;
				return;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = value as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				MappingOrigin = ifcAxis2Placement3D;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentationMap), 2)]
	IIfcRepresentation IIfcRepresentationMap.MappedRepresentation
	{
		get
		{
			return MappedRepresentation;
		}
		set
		{
			MappedRepresentation = value as Xbim.Ifc2x3.RepresentationResource.IfcRepresentation;
		}
	}

	IEnumerable<IIfcShapeAspect> IIfcRepresentationMap.HasShapeAspects => base.Model.Instances.Where((IIfcShapeAspect e) => e.PartOfProductDefinitionShape as IfcRepresentationMap == this, "PartOfProductDefinitionShape", this);

	IEnumerable<IIfcMappedItem> IIfcRepresentationMap.MapUsage => base.Model.Instances.Where((IIfcMappedItem e) => e.MappingSource as IfcRepresentationMap == this, "MappingSource", this);

	internal IfcRepresentationMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mappingOrigin = (IfcAxis2Placement)value.EntityVal;
			break;
		case 1:
			_mappedRepresentation = (Xbim.Ifc2x3.RepresentationResource.IfcRepresentation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRepresentationMap other)
	{
		return this == other;
	}
}
