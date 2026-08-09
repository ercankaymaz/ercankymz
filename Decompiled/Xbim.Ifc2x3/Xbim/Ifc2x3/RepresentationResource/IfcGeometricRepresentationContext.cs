using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcGeometricRepresentationContext", 555)]
public class IfcGeometricRepresentationContext : IfcRepresentationContext, IIfcGeometricRepresentationContext, IIfcRepresentationContext, IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcGeometricRepresentationContext>
{
	private Xbim.Ifc2x3.GeometryResource.IfcDimensionCount _coordinateSpaceDimension;

	private double? _precision;

	private Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement _worldCoordinateSystem;

	private Xbim.Ifc2x3.GeometryResource.IfcDirection _trueNorth;

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationContext), 3)]
	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcGeometricRepresentationContext.CoordinateSpaceDimension
	{
		get
		{
			return new Xbim.Ifc4.GeometryResource.IfcDimensionCount(CoordinateSpaceDimension);
		}
		set
		{
			CoordinateSpaceDimension = new Xbim.Ifc2x3.GeometryResource.IfcDimensionCount(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationContext), 4)]
	IfcReal? IIfcGeometricRepresentationContext.Precision
	{
		get
		{
			if (!Precision.HasValue)
			{
				return null;
			}
			return new IfcReal(Precision.Value);
		}
		set
		{
			Precision = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationContext), 5)]
	IIfcAxis2Placement IIfcGeometricRepresentationContext.WorldCoordinateSystem
	{
		get
		{
			if (WorldCoordinateSystem == null)
			{
				return null;
			}
			Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement2D ifcAxis2Placement2D = WorldCoordinateSystem as Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				return ifcAxis2Placement2D;
			}
			Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D ifcAxis2Placement3D = WorldCoordinateSystem as Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D;
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
				WorldCoordinateSystem = null;
				return;
			}
			Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement2D ifcAxis2Placement2D = value as Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				WorldCoordinateSystem = ifcAxis2Placement2D;
				return;
			}
			Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D ifcAxis2Placement3D = value as Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				WorldCoordinateSystem = ifcAxis2Placement3D;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationContext), 6)]
	IIfcDirection IIfcGeometricRepresentationContext.TrueNorth
	{
		get
		{
			return TrueNorth;
		}
		set
		{
			TrueNorth = value as Xbim.Ifc2x3.GeometryResource.IfcDirection;
		}
	}

	IEnumerable<IIfcGeometricRepresentationSubContext> IIfcGeometricRepresentationContext.HasSubContexts => base.Model.Instances.Where((IIfcGeometricRepresentationSubContext e) => e.ParentContext as IfcGeometricRepresentationContext == this, "ParentContext", this);

	IEnumerable<IIfcCoordinateOperation> IIfcGeometricRepresentationContext.HasCoordinateOperation => base.Model.Instances.Where((IIfcCoordinateOperation e) => e.SourceCRS as IfcGeometricRepresentationContext == this, "SourceCRS", this);

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public virtual Xbim.Ifc2x3.GeometryResource.IfcDimensionCount CoordinateSpaceDimension
	{
		get
		{
			if (_activated)
			{
				return _coordinateSpaceDimension;
			}
			Activate();
			return _coordinateSpaceDimension;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcDimensionCount v)
			{
				_coordinateSpaceDimension = v;
			}, _coordinateSpaceDimension, value, "CoordinateSpaceDimension", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public virtual double? Precision
	{
		get
		{
			if (_activated)
			{
				return _precision;
			}
			Activate();
			return _precision;
		}
		set
		{
			SetValue(delegate(double? v)
			{
				_precision = v;
			}, _precision, value, "Precision", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public virtual Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement WorldCoordinateSystem
	{
		get
		{
			if (_activated)
			{
				return _worldCoordinateSystem;
			}
			Activate();
			return _worldCoordinateSystem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement v)
			{
				_worldCoordinateSystem = v;
			}, _worldCoordinateSystem, value, "WorldCoordinateSystem", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public virtual Xbim.Ifc2x3.GeometryResource.IfcDirection TrueNorth
	{
		get
		{
			if (_activated)
			{
				return _trueNorth;
			}
			Activate();
			return _trueNorth;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcDirection v)
			{
				_trueNorth = v;
			}, _trueNorth, value, "TrueNorth", 6);
		}
	}

	[InverseProperty("ParentContext")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcGeometricRepresentationSubContext> HasSubContexts => base.Model.Instances.Where((IfcGeometricRepresentationSubContext e) => Equals(e.ParentContext), "ParentContext", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (WorldCoordinateSystem != null)
			{
				yield return WorldCoordinateSystem;
			}
			if (TrueNorth != null)
			{
				yield return TrueNorth;
			}
		}
	}

	internal IfcGeometricRepresentationContext(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_coordinateSpaceDimension = value.IntegerVal;
			break;
		case 3:
			_precision = value.RealVal;
			break;
		case 4:
			_worldCoordinateSystem = (Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement)value.EntityVal;
			break;
		case 5:
			_trueNorth = (Xbim.Ifc2x3.GeometryResource.IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeometricRepresentationContext other)
	{
		return this == other;
	}
}
