using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcGeometricRepresentationSubContext", 556)]
public class IfcGeometricRepresentationSubContext : IfcGeometricRepresentationContext, IIfcGeometricRepresentationSubContext, IIfcGeometricRepresentationContext, IIfcRepresentationContext, IPersistEntity, IPersist, Xbim.Ifc4.RepresentationResource.IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGeometricRepresentationSubContext>
{
	private IfcGeometricRepresentationContext _parentContext;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? _targetScale;

	private IfcGeometricProjectionEnum _targetView;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedTargetView;

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationSubContext), 7)]
	IIfcGeometricRepresentationContext IIfcGeometricRepresentationSubContext.ParentContext
	{
		get
		{
			return ParentContext;
		}
		set
		{
			ParentContext = value as IfcGeometricRepresentationContext;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationSubContext), 8)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure? IIfcGeometricRepresentationSubContext.TargetScale
	{
		get
		{
			if (!TargetScale.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(TargetScale.Value);
		}
		set
		{
			TargetScale = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationSubContext), 9)]
	Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum IIfcGeometricRepresentationSubContext.TargetView
	{
		get
		{
			return TargetView switch
			{
				IfcGeometricProjectionEnum.ELEVATION_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.ELEVATION_VIEW, 
				IfcGeometricProjectionEnum.GRAPH_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.GRAPH_VIEW, 
				IfcGeometricProjectionEnum.MODEL_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.MODEL_VIEW, 
				IfcGeometricProjectionEnum.PLAN_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.PLAN_VIEW, 
				IfcGeometricProjectionEnum.REFLECTED_PLAN_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.REFLECTED_PLAN_VIEW, 
				IfcGeometricProjectionEnum.SECTION_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.SECTION_VIEW, 
				IfcGeometricProjectionEnum.SKETCH_VIEW => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.SKETCH_VIEW, 
				IfcGeometricProjectionEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.USERDEFINED, 
				IfcGeometricProjectionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.GRAPH_VIEW:
				TargetView = IfcGeometricProjectionEnum.GRAPH_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.SKETCH_VIEW:
				TargetView = IfcGeometricProjectionEnum.SKETCH_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.MODEL_VIEW:
				TargetView = IfcGeometricProjectionEnum.MODEL_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.PLAN_VIEW:
				TargetView = IfcGeometricProjectionEnum.PLAN_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.REFLECTED_PLAN_VIEW:
				TargetView = IfcGeometricProjectionEnum.REFLECTED_PLAN_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.SECTION_VIEW:
				TargetView = IfcGeometricProjectionEnum.SECTION_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.ELEVATION_VIEW:
				TargetView = IfcGeometricProjectionEnum.ELEVATION_VIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.USERDEFINED:
				TargetView = IfcGeometricProjectionEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeometricProjectionEnum.NOTDEFINED:
				TargetView = IfcGeometricProjectionEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricRepresentationSubContext), 10)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcGeometricRepresentationSubContext.UserDefinedTargetView
	{
		get
		{
			if (!UserDefinedTargetView.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedTargetView.Value);
		}
		set
		{
			UserDefinedTargetView = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcGeometricRepresentationContext ParentContext
	{
		get
		{
			if (_activated)
			{
				return _parentContext;
			}
			Activate();
			return _parentContext;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcGeometricRepresentationContext v)
			{
				_parentContext = v;
			}, _parentContext, value, "ParentContext", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? TargetScale
	{
		get
		{
			if (_activated)
			{
				return _targetScale;
			}
			Activate();
			return _targetScale;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? v)
			{
				_targetScale = v;
			}, _targetScale, value, "TargetScale", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcGeometricProjectionEnum TargetView
	{
		get
		{
			if (_activated)
			{
				return _targetView;
			}
			Activate();
			return _targetView;
		}
		set
		{
			SetValue(delegate(IfcGeometricProjectionEnum v)
			{
				_targetView = v;
			}, _targetView, value, "TargetView", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedTargetView
	{
		get
		{
			if (_activated)
			{
				return _userDefinedTargetView;
			}
			Activate();
			return _userDefinedTargetView;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedTargetView = v;
			}, _userDefinedTargetView, value, "UserDefinedTargetView", 10);
		}
	}

	[EntityAttribute(5, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcAxis2Placement WorldCoordinateSystem
	{
		get
		{
			return ParentContext.WorldCoordinateSystem;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property WorldCoordinateSystem in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(3, EntityAttributeState.DerivedOverride, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount CoordinateSpaceDimension
	{
		get
		{
			return ParentContext.CoordinateSpaceDimension;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property CoordinateSpaceDimension in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(6, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcDirection TrueNorth
	{
		get
		{
			if (ParentContext != null && ParentContext.TrueNorth != null)
			{
				return ParentContext.TrueNorth;
			}
			if (WorldCoordinateSystem is IfcAxis2Placement2D ifcAxis2Placement2D)
			{
				return ifcAxis2Placement2D.P[1];
			}
			if (WorldCoordinateSystem is IfcAxis2Placement3D ifcAxis2Placement3D)
			{
				return ifcAxis2Placement3D.P[1];
			}
			return null;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property TrueNorth in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(4, EntityAttributeState.DerivedOverride, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override Xbim.Ifc4x3.MeasureResource.IfcReal? Precision
	{
		get
		{
			return ParentContext.Precision ?? ((Xbim.Ifc4x3.MeasureResource.IfcReal)1E-05);
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property Precision in IfcGeometricRepresentationSubContext");
		}
	}

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
			if (ParentContext != null)
			{
				yield return ParentContext;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ParentContext != null)
			{
				yield return ParentContext;
			}
		}
	}

	internal IfcGeometricRepresentationSubContext(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_parentContext = (IfcGeometricRepresentationContext)value.EntityVal;
			break;
		case 7:
			_targetScale = value.RealVal;
			break;
		case 8:
			_targetView = (IfcGeometricProjectionEnum)Enum.Parse(typeof(IfcGeometricProjectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_userDefinedTargetView = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeometricRepresentationSubContext other)
	{
		return this == other;
	}
}
