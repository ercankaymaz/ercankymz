using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.ArchitectureDomain;

[ExpressType("IfcDoorPanelProperties", 602)]
public class IfcDoorPanelProperties : Xbim.Ifc4x3.Kernel.IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcDoorPanelProperties>, IIfcDoorPanelProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _panelDepth;

	private IfcDoorPanelOperationEnum _panelOperation;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _panelWidth;

	private IfcDoorPanelPositionEnum _panelPosition;

	private IfcShapeAspect _shapeAspectStyle;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? PanelDepth
	{
		get
		{
			if (_activated)
			{
				return _panelDepth;
			}
			Activate();
			return _panelDepth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_panelDepth = v;
			}, _panelDepth, value, "PanelDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcDoorPanelOperationEnum PanelOperation
	{
		get
		{
			if (_activated)
			{
				return _panelOperation;
			}
			Activate();
			return _panelOperation;
		}
		set
		{
			SetValue(delegate(IfcDoorPanelOperationEnum v)
			{
				_panelOperation = v;
			}, _panelOperation, value, "PanelOperation", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? PanelWidth
	{
		get
		{
			if (_activated)
			{
				return _panelWidth;
			}
			Activate();
			return _panelWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_panelWidth = v;
			}, _panelWidth, value, "PanelWidth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcDoorPanelPositionEnum PanelPosition
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
			SetValue(delegate(IfcDoorPanelPositionEnum v)
			{
				_panelPosition = v;
			}, _panelPosition, value, "PanelPosition", 8);
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

	[CrossSchemaAttribute(typeof(IIfcDoorPanelProperties), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorPanelProperties.PanelDepth
	{
		get
		{
			if (!PanelDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(PanelDepth.Value);
		}
		set
		{
			PanelDepth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorPanelProperties), 6)]
	Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum IIfcDoorPanelProperties.PanelOperation
	{
		get
		{
			return PanelOperation switch
			{
				IfcDoorPanelOperationEnum.DOUBLE_ACTING => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.DOUBLE_ACTING, 
				IfcDoorPanelOperationEnum.FIXEDPANEL => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.FIXEDPANEL, 
				IfcDoorPanelOperationEnum.FOLDING => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.FOLDING, 
				IfcDoorPanelOperationEnum.REVOLVING => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.REVOLVING, 
				IfcDoorPanelOperationEnum.ROLLINGUP => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.ROLLINGUP, 
				IfcDoorPanelOperationEnum.SLIDING => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.SLIDING, 
				IfcDoorPanelOperationEnum.SWINGING => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.SWINGING, 
				IfcDoorPanelOperationEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.USERDEFINED, 
				IfcDoorPanelOperationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.SWINGING:
				PanelOperation = IfcDoorPanelOperationEnum.SWINGING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.DOUBLE_ACTING:
				PanelOperation = IfcDoorPanelOperationEnum.DOUBLE_ACTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.SLIDING:
				PanelOperation = IfcDoorPanelOperationEnum.SLIDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.FOLDING:
				PanelOperation = IfcDoorPanelOperationEnum.FOLDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.REVOLVING:
				PanelOperation = IfcDoorPanelOperationEnum.REVOLVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.ROLLINGUP:
				PanelOperation = IfcDoorPanelOperationEnum.ROLLINGUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.FIXEDPANEL:
				PanelOperation = IfcDoorPanelOperationEnum.FIXEDPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.USERDEFINED:
				PanelOperation = IfcDoorPanelOperationEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelOperationEnum.NOTDEFINED:
				PanelOperation = IfcDoorPanelOperationEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorPanelProperties), 7)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcDoorPanelProperties.PanelWidth
	{
		get
		{
			if (!PanelWidth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(PanelWidth.Value);
		}
		set
		{
			PanelWidth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorPanelProperties), 8)]
	Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum IIfcDoorPanelProperties.PanelPosition
	{
		get
		{
			return PanelPosition switch
			{
				IfcDoorPanelPositionEnum.LEFT => Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.LEFT, 
				IfcDoorPanelPositionEnum.MIDDLE => Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.MIDDLE, 
				IfcDoorPanelPositionEnum.RIGHT => Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.RIGHT, 
				IfcDoorPanelPositionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.LEFT:
				PanelPosition = IfcDoorPanelPositionEnum.LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.MIDDLE:
				PanelPosition = IfcDoorPanelPositionEnum.MIDDLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.RIGHT:
				PanelPosition = IfcDoorPanelPositionEnum.RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDoorPanelPositionEnum.NOTDEFINED:
				PanelPosition = IfcDoorPanelPositionEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorPanelProperties), 9)]
	IIfcShapeAspect IIfcDoorPanelProperties.ShapeAspectStyle
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

	internal IfcDoorPanelProperties(IModel model, int label, bool activated)
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
			_panelDepth = value.RealVal;
			break;
		case 5:
			_panelOperation = (IfcDoorPanelOperationEnum)Enum.Parse(typeof(IfcDoorPanelOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_panelWidth = value.RealVal;
			break;
		case 7:
			_panelPosition = (IfcDoorPanelPositionEnum)Enum.Parse(typeof(IfcDoorPanelPositionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_shapeAspectStyle = (IfcShapeAspect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoorPanelProperties other)
	{
		return this == other;
	}
}
