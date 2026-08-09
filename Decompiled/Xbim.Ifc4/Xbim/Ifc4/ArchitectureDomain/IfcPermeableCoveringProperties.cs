using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.ArchitectureDomain;

[ExpressType("IfcPermeableCoveringProperties", 707)]
public class IfcPermeableCoveringProperties : IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcPermeableCoveringProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcPermeableCoveringProperties>
{
	private IfcPermeableCoveringOperationEnum _operationType;

	private IfcWindowPanelPositionEnum _panelPosition;

	private IfcPositiveLengthMeasure? _frameDepth;

	private IfcPositiveLengthMeasure? _frameThickness;

	private IfcShapeAspect _shapeAspectStyle;

	IfcPermeableCoveringOperationEnum IIfcPermeableCoveringProperties.OperationType
	{
		get
		{
			return OperationType;
		}
		set
		{
			OperationType = value;
		}
	}

	IfcWindowPanelPositionEnum IIfcPermeableCoveringProperties.PanelPosition
	{
		get
		{
			return PanelPosition;
		}
		set
		{
			PanelPosition = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcPermeableCoveringProperties.FrameDepth
	{
		get
		{
			return FrameDepth;
		}
		set
		{
			FrameDepth = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcPermeableCoveringProperties.FrameThickness
	{
		get
		{
			return FrameThickness;
		}
		set
		{
			FrameThickness = value;
		}
	}

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

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
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

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcWindowPanelPositionEnum PanelPosition
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
			SetValue(delegate(IfcWindowPanelPositionEnum v)
			{
				_panelPosition = v;
			}, _panelPosition, value, "PanelPosition", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPositiveLengthMeasure? FrameDepth
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
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_frameDepth = v;
			}, _frameDepth, value, "FrameDepth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcPositiveLengthMeasure? FrameThickness
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
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_frameThickness = v;
			}, _frameThickness, value, "FrameThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
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
			_panelPosition = (IfcWindowPanelPositionEnum)Enum.Parse(typeof(IfcWindowPanelPositionEnum), value.EnumVal, ignoreCase: true);
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
