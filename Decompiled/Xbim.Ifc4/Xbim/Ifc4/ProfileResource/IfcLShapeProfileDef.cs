using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcLShapeProfileDef", 284)]
public class IfcLShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcLShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLShapeProfileDef>, IExpressValidatable
{
	public enum IfcLShapeProfileDefClause
	{
		ValidThickness
	}

	private IfcPositiveLengthMeasure _depth;

	private IfcPositiveLengthMeasure? _width;

	private IfcPositiveLengthMeasure _thickness;

	private IfcNonNegativeLengthMeasure? _filletRadius;

	private IfcNonNegativeLengthMeasure? _edgeRadius;

	private IfcPlaneAngleMeasure? _legSlope;

	IfcPositiveLengthMeasure IIfcLShapeProfileDef.Depth
	{
		get
		{
			return Depth;
		}
		set
		{
			Depth = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcLShapeProfileDef.Width
	{
		get
		{
			return Width;
		}
		set
		{
			Width = value;
		}
	}

	IfcPositiveLengthMeasure IIfcLShapeProfileDef.Thickness
	{
		get
		{
			return Thickness;
		}
		set
		{
			Thickness = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.FilletRadius
	{
		get
		{
			return FilletRadius;
		}
		set
		{
			FilletRadius = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.EdgeRadius
	{
		get
		{
			return EdgeRadius;
		}
		set
		{
			EdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcLShapeProfileDef.LegSlope
	{
		get
		{
			return LegSlope;
		}
		set
		{
			LegSlope = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure? Width
	{
		get
		{
			if (_activated)
			{
				return _width;
			}
			Activate();
			return _width;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcNonNegativeLengthMeasure? FilletRadius
	{
		get
		{
			if (_activated)
			{
				return _filletRadius;
			}
			Activate();
			return _filletRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcNonNegativeLengthMeasure? EdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _edgeRadius;
			}
			Activate();
			return _edgeRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_edgeRadius = v;
			}, _edgeRadius, value, "EdgeRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPlaneAngleMeasure? LegSlope
	{
		get
		{
			if (_activated)
			{
				return _legSlope;
			}
			Activate();
			return _legSlope;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_legSlope = v;
			}, _legSlope, value, "LegSlope", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcLShapeProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_depth = value.RealVal;
			break;
		case 4:
			_width = value.RealVal;
			break;
		case 5:
			_thickness = value.RealVal;
			break;
		case 6:
			_filletRadius = value.RealVal;
			break;
		case 7:
			_edgeRadius = value.RealVal;
			break;
		case 8:
			_legSlope = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcLShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcLShapeProfileDefClause.ValidThickness)
			{
				result = (double)Thickness < (double)Depth && (!Functions.EXISTS(Width) || (double)Thickness < (double?)Width);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcLShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcLShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcLShapeProfileDefClause.ValidThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLShapeProfileDef.ValidThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
