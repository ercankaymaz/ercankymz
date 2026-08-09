using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcCShapeProfileDef", 501)]
public class IfcCShapeProfileDef : IfcParameterizedProfileDef, IIfcCShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCShapeProfileDef>, IExpressValidatable
{
	public enum IfcCShapeProfileDefClause
	{
		WR1,
		WR2,
		WR3
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _width;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _wallThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _girth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _internalFilletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInX;

	[CrossSchemaAttribute(typeof(IIfcCShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcCShapeProfileDef.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcCShapeProfileDef.Width
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Width);
		}
		set
		{
			Width = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcCShapeProfileDef.WallThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(WallThickness);
		}
		set
		{
			WallThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcCShapeProfileDef.Girth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Girth);
		}
		set
		{
			Girth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcCShapeProfileDef.InternalFilletRadius
	{
		get
		{
			if (!InternalFilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(InternalFilletRadius.Value);
		}
		set
		{
			InternalFilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Depth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Width
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure WallThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_wallThickness = v;
			}, _wallThickness, value, "WallThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Girth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_girth = v;
			}, _girth, value, "Girth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? InternalFilletRadius
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_internalFilletRadius = v;
			}, _internalFilletRadius, value, "InternalFilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? CentreOfGravityInX
	{
		get
		{
			if (_activated)
			{
				return _centreOfGravityInX;
			}
			Activate();
			return _centreOfGravityInX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_centreOfGravityInX = v;
			}, _centreOfGravityInX, value, "CentreOfGravityInX", 9);
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
		case 8:
			_centreOfGravityInX = value.RealVal;
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
			case IfcCShapeProfileDefClause.WR1:
				result = (double)Girth < (double)Depth / 2.0;
				break;
			case IfcCShapeProfileDefClause.WR2:
				result = !Functions.EXISTS(InternalFilletRadius) || ((double?)InternalFilletRadius <= (double)Width / 2.0 && (double?)InternalFilletRadius <= (double)Depth / 2.0);
				break;
			case IfcCShapeProfileDefClause.WR3:
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
		if (!ValidateClause(IfcCShapeProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCShapeProfileDefClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCShapeProfileDefClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCShapeProfileDef.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
