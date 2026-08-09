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

[ExpressType("IfcCShapeProfileDef", 501)]
public class IfcCShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcCShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCShapeProfileDef>, IExpressValidatable
{
	public enum IfcCShapeProfileDefClause
	{
		ValidGirth,
		ValidInternalFilletRadius,
		ValidWallThickness
	}

	private IfcPositiveLengthMeasure _depth;

	private IfcPositiveLengthMeasure _width;

	private IfcPositiveLengthMeasure _wallThickness;

	private IfcPositiveLengthMeasure _girth;

	private IfcNonNegativeLengthMeasure? _internalFilletRadius;

	IfcPositiveLengthMeasure IIfcCShapeProfileDef.Depth
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

	IfcPositiveLengthMeasure IIfcCShapeProfileDef.Width
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

	IfcPositiveLengthMeasure IIfcCShapeProfileDef.WallThickness
	{
		get
		{
			return WallThickness;
		}
		set
		{
			WallThickness = value;
		}
	}

	IfcPositiveLengthMeasure IIfcCShapeProfileDef.Girth
	{
		get
		{
			return Girth;
		}
		set
		{
			Girth = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcCShapeProfileDef.InternalFilletRadius
	{
		get
		{
			return InternalFilletRadius;
		}
		set
		{
			InternalFilletRadius = value;
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

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure Width
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure WallThickness
	{
		get
		{
			if (_activated)
			{
				return _wallThickness;
			}
			Activate();
			return _wallThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_wallThickness = v;
			}, _wallThickness, value, "WallThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcPositiveLengthMeasure Girth
	{
		get
		{
			if (_activated)
			{
				return _girth;
			}
			Activate();
			return _girth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_girth = v;
			}, _girth, value, "Girth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcNonNegativeLengthMeasure? InternalFilletRadius
	{
		get
		{
			if (_activated)
			{
				return _internalFilletRadius;
			}
			Activate();
			return _internalFilletRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_internalFilletRadius = v;
			}, _internalFilletRadius, value, "InternalFilletRadius", 8);
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

	internal IfcCShapeProfileDef(IModel model, int label, bool activated)
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
			_wallThickness = value.RealVal;
			break;
		case 6:
			_girth = value.RealVal;
			break;
		case 7:
			_internalFilletRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCShapeProfileDefClause.ValidGirth:
				result = (double)Girth < (double)Depth / 2.0;
				break;
			case IfcCShapeProfileDefClause.ValidInternalFilletRadius:
				result = !Functions.EXISTS(InternalFilletRadius) || ((double?)InternalFilletRadius <= (double)Width / 2.0 - (double)WallThickness && (double?)InternalFilletRadius <= (double)Depth / 2.0 - (double)WallThickness);
				break;
			case IfcCShapeProfileDefClause.ValidWallThickness:
				result = (double)WallThickness < (double)Width / 2.0 && (double)WallThickness < (double)Depth / 2.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcCShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCShapeProfileDefClause.ValidGirth))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.ValidGirth",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCShapeProfileDefClause.ValidInternalFilletRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.ValidInternalFilletRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCShapeProfileDefClause.ValidWallThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.ValidWallThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
