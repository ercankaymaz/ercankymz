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

[ExpressType("IfcRectangleHollowProfileDef", 562)]
public class IfcRectangleHollowProfileDef : IfcRectangleProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcRectangleHollowProfileDef, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcRectangleHollowProfileDef>, IExpressValidatable
{
	public enum IfcRectangleHollowProfileDefClause
	{
		ValidWallThickness,
		ValidInnerRadius,
		ValidOuterRadius
	}

	private IfcPositiveLengthMeasure _wallThickness;

	private IfcNonNegativeLengthMeasure? _innerFilletRadius;

	private IfcNonNegativeLengthMeasure? _outerFilletRadius;

	IfcPositiveLengthMeasure IIfcRectangleHollowProfileDef.WallThickness
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

	IfcNonNegativeLengthMeasure? IIfcRectangleHollowProfileDef.InnerFilletRadius
	{
		get
		{
			return InnerFilletRadius;
		}
		set
		{
			InnerFilletRadius = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcRectangleHollowProfileDef.OuterFilletRadius
	{
		get
		{
			return OuterFilletRadius;
		}
		set
		{
			OuterFilletRadius = value;
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcNonNegativeLengthMeasure? InnerFilletRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_innerFilletRadius = v;
			}, _innerFilletRadius, value, "InnerFilletRadius", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcNonNegativeLengthMeasure? OuterFilletRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
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
			case IfcRectangleHollowProfileDefClause.ValidWallThickness:
				result = (double)WallThickness < (double)base.XDim / 2.0 && (double)WallThickness < (double)base.YDim / 2.0;
				break;
			case IfcRectangleHollowProfileDefClause.ValidInnerRadius:
				result = !Functions.EXISTS(InnerFilletRadius) || ((double?)InnerFilletRadius <= (double)base.XDim / 2.0 - (double)WallThickness && (double?)InnerFilletRadius <= (double)base.YDim / 2.0 - (double)WallThickness);
				break;
			case IfcRectangleHollowProfileDefClause.ValidOuterRadius:
				result = !Functions.EXISTS(OuterFilletRadius) || ((double?)OuterFilletRadius <= (double)base.XDim / 2.0 && (double?)OuterFilletRadius <= (double)base.YDim / 2.0);
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
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.ValidWallThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.ValidWallThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.ValidInnerRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.ValidInnerRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangleHollowProfileDefClause.ValidOuterRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangleHollowProfileDef.ValidOuterRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
