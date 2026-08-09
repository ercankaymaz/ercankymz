using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ArchitectureDomain;

[ExpressType("IfcDoorPanelProperties", 602)]
public class IfcDoorPanelProperties : IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcDoorPanelProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcDoorPanelProperties>, IExpressValidatable
{
	public enum IfcDoorPanelPropertiesClause
	{
		ApplicableToType
	}

	private IfcPositiveLengthMeasure? _panelDepth;

	private IfcDoorPanelOperationEnum _panelOperation;

	private IfcNormalisedRatioMeasure? _panelWidth;

	private IfcDoorPanelPositionEnum _panelPosition;

	private IfcShapeAspect _shapeAspectStyle;

	IfcPositiveLengthMeasure? IIfcDoorPanelProperties.PanelDepth
	{
		get
		{
			return PanelDepth;
		}
		set
		{
			PanelDepth = value;
		}
	}

	IfcDoorPanelOperationEnum IIfcDoorPanelProperties.PanelOperation
	{
		get
		{
			return PanelOperation;
		}
		set
		{
			PanelOperation = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcDoorPanelProperties.PanelWidth
	{
		get
		{
			return PanelWidth;
		}
		set
		{
			PanelWidth = value;
		}
	}

	IfcDoorPanelPositionEnum IIfcDoorPanelProperties.PanelPosition
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

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcPositiveLengthMeasure? PanelDepth
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
			SetValue(delegate(IfcPositiveLengthMeasure? v)
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
	public IfcNormalisedRatioMeasure? PanelWidth
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
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
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

	public bool ValidateClause(IfcDoorPanelPropertiesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDoorPanelPropertiesClause.ApplicableToType)
			{
				result = Functions.EXISTS(base.DefinesType.ItemAt(0L)) && (Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCDOORTYPE") || Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCDOORSTYLE"));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDoorPanelProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcDoorPanelProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDoorPanelPropertiesClause.ApplicableToType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorPanelProperties.ApplicableToType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
