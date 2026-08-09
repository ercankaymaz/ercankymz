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

[ExpressType("IfcRectangleHollowProfileDef", 562)]
public class IfcRectangleHollowProfileDef : IfcRectangleProfileDef, IIfcRectangleHollowProfileDef, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcRectangleHollowProfileDef>, IExpressValidatable
{
	public enum IfcRectangleHollowProfileDefClause
	{
		WR31,
		WR32,
		WR33
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _wallThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _innerFilletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _outerFilletRadius;

	[CrossSchemaAttribute(typeof(IIfcRectangleHollowProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRectangleHollowProfileDef.WallThickness
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

	[CrossSchemaAttribute(typeof(IIfcRectangleHollowProfileDef), 7)]
	IfcNonNegativeLengthMeasure? IIfcRectangleHollowProfileDef.InnerFilletRadius
	{
		get
		{
			if (!InnerFilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(InnerFilletRadius.Value);
		}
		set
		{
			InnerFilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangleHollowProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcRectangleHollowProfileDef.OuterFilletRadius
	{
		get
		{
			if (!OuterFilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(OuterFilletRadius.Value);
		}
		set
		{
			OuterFilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? InnerFilletRadius
	{
		get
		{
			if (_activated)
			{
				return _innerFilletRadius;
			}
			Activate();
			return _innerFilletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_innerFilletRadius = v;
			}, _innerFilletRadius, value, "InnerFilletRadius", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? OuterFilletRadius
	{
		get
		{
			if (_activated)
			{
				return _outerFilletRadius;
			}
			Activate();
			return _outerFilletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_outerFilletRadius = v;
			}, _outerFilletRadius, value, "OuterFilletRadius", 8);
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

	internal IfcRectangleHollowProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_wallThickness = value.RealVal;
			break;
		case 6:
			_innerFilletRadius = value.RealVal;
			break;
		case 7:
			_outerFilletRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRectangleHollowProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRectangleHollowProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRectangleHollowProfileDefClause.WR31:
				result = (double)WallThickness < (double)base.XDim / 2.0 && (double)WallThickness < (double)base.YDim / 2.0;
				break;
			case IfcRectangleHollowProfileDefClause.WR32:
				result = !Functions.EXISTS(OuterFilletRadius) || ((double?)OuterFilletRadius <= (double)base.XDim / 2.0 && (double?)OuterFilletRadius <= (double)base.YDim / 2.0);
				break;
			case IfcRectangleHollowProfileDefClause.WR33:
				result = !Functions.EXISTS(InnerFilletRadius) || ((double?)InnerFilletRadius <= (double)base.XDim / 2.0 - (double)WallThickness && (double?)InnerFilletRadius <= (double)base.YDim / 2.0 - (double)WallThickness);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRectangleHollowProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcRectangleHollowProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.WR33))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.WR33",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
