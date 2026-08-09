using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.SharedBldgElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ArchitectureDomain;

[ExpressType("IfcPermeableCoveringProperties", 707)]
public class IfcPermeableCoveringProperties : Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPermeableCoveringProperties>, IIfcPermeableCoveringProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	private IfcPermeableCoveringOperationEnum _operationType;

	private Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum _panelPosition;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _frameDepth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _frameThickness;

	private IfcShapeAspect _shapeAspectStyle;

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcPermeableCoveringOperationEnum OperationType
	{
		get
		{
			if (_activated)
			{
				return _operationType;
			}
			Activate();
			return _operationType;
		}
		set
		{
			SetValue(delegate(IfcPermeableCoveringOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum PanelPosition
	{
		get
		{
			if (_activated)
			{
				return _panelPosition;
			}
			Activate();
			return _panelPosition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum v)
			{
				_panelPosition = v;
			}, _panelPosition, value, "PanelPosition", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? FrameDepth
	{
		get
		{
			if (_activated)
			{
				return _frameDepth;
			}
			Activate();
			return _frameDepth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_frameDepth = v;
			}, _frameDepth, value, "FrameDepth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? FrameThickness
	{
		get
		{
			if (_activated)
			{
				return _frameThickness;
			}
			Activate();
			return _frameThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_frameThickness = v;
			}, _frameThickness, value, "FrameThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcShapeAspect ShapeAspectStyle
	{
		get
		{
			if (_activated)
			{
				return _shapeAspectStyle;
			}
			Activate();
			return _shapeAspectStyle;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_shapeAspectStyle = v;
			}, _shapeAspectStyle, value, "ShapeAspectStyle", 9);
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
			if (ShapeAspectStyle != null)
			{
				yield return ShapeAspectStyle;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermeableCoveringProperties), 5)]
	Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum IIfcPermeableCoveringProperties.OperationType
	{
		get
		{
			return OperationType switch
			{
				IfcPermeableCoveringOperationEnum.GRILL => Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.GRILL, 
				IfcPermeableCoveringOperationEnum.LOUVER => Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.LOUVER, 
				IfcPermeableCoveringOperationEnum.SCREEN => Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.SCREEN, 
				IfcPermeableCoveringOperationEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.USERDEFINED, 
				IfcPermeableCoveringOperationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.GRILL:
				OperationType = IfcPermeableCoveringOperationEnum.GRILL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.LOUVER:
				OperationType = IfcPermeableCoveringOperationEnum.LOUVER;
				break;
			case Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.SCREEN:
				OperationType = IfcPermeableCoveringOperationEnum.SCREEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.USERDEFINED:
				OperationType = IfcPermeableCoveringOperationEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPermeableCoveringOperationEnum.NOTDEFINED:
				OperationType = IfcPermeableCoveringOperationEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermeableCoveringProperties), 6)]
	Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum IIfcPermeableCoveringProperties.PanelPosition
	{
		get
		{
			return PanelPosition switch
			{
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.LEFT => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.LEFT, 
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.MIDDLE => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.MIDDLE, 
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.RIGHT => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.RIGHT, 
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.BOTTOM => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.BOTTOM, 
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.TOP => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.TOP, 
				Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.LEFT:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.MIDDLE:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.MIDDLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.RIGHT:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.BOTTOM:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.BOTTOM;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.TOP:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.TOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowPanelPositionEnum.NOTDEFINED:
				PanelPosition = Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermeableCoveringProperties), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcPermeableCoveringProperties.FrameDepth
	{
		get
		{
			if (!FrameDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FrameDepth.Value);
		}
		set
		{
			FrameDepth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermeableCoveringProperties), 8)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcPermeableCoveringProperties.FrameThickness
	{
		get
		{
			if (!FrameThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FrameThickness.Value);
		}
		set
		{
			FrameThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermeableCoveringProperties), 9)]
	IIfcShapeAspect IIfcPermeableCoveringProperties.ShapeAspectStyle
	{
		get
		{
			return ShapeAspectStyle;
		}
		set
		{
			ShapeAspectStyle = value as IfcShapeAspect;
		}
	}

	internal IfcPermeableCoveringProperties(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_operationType = (IfcPermeableCoveringOperationEnum)Enum.Parse(typeof(IfcPermeableCoveringOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_panelPosition = (Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum)Enum.Parse(typeof(Xbim.Ifc2x3.SharedBldgElements.IfcWindowPanelPositionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_frameDepth = value.RealVal;
			break;
		case 7:
			_frameThickness = value.RealVal;
			break;
		case 8:
			_shapeAspectStyle = (IfcShapeAspect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPermeableCoveringProperties other)
	{
		return this == other;
	}
}
