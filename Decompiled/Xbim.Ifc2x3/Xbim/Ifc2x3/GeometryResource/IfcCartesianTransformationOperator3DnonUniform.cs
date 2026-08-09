using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator3DnonUniform", 479)]
public class IfcCartesianTransformationOperator3DnonUniform : IfcCartesianTransformationOperator3D, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator3DnonUniform>, IIfcCartesianTransformationOperator3DnonUniform, IIfcCartesianTransformationOperator3D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcCartesianTransformationOperator3DnonUniformClause
	{
		WR1,
		WR2
	}

	private double? _scale2;

	private double? _scale3;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public double? Scale2
	{
		get
		{
			if (_activated)
			{
				return _scale2;
			}
			Activate();
			return _scale2;
		}
		set
		{
			SetValue(delegate(double? v)
			{
				_scale2 = v;
			}, _scale2, value, "Scale2", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public double? Scale3
	{
		get
		{
			if (_activated)
			{
				return _scale3;
			}
			Activate();
			return _scale3;
		}
		set
		{
			SetValue(delegate(double? v)
			{
				_scale3 = v;
			}, _scale3, value, "Scale3", 7);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public double Scl2 => Scale2 ?? base.Scl;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public double Scl3 => Scale3 ?? base.Scl;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Axis1 != null)
			{
				yield return base.Axis1;
			}
			if (base.Axis2 != null)
			{
				yield return base.Axis2;
			}
			if (base.LocalOrigin != null)
			{
				yield return base.LocalOrigin;
			}
			if (base.Axis3 != null)
			{
				yield return base.Axis3;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator3DnonUniform), 6)]
	IfcReal? IIfcCartesianTransformationOperator3DnonUniform.Scale2
	{
		get
		{
			if (!Scale2.HasValue)
			{
				return null;
			}
			return new IfcReal(Scale2.Value);
		}
		set
		{
			Scale2 = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianTransformationOperator3DnonUniform), 7)]
	IfcReal? IIfcCartesianTransformationOperator3DnonUniform.Scale3
	{
		get
		{
			if (!Scale3.HasValue)
			{
				return null;
			}
			return new IfcReal(Scale3.Value);
		}
		set
		{
			Scale3 = value;
		}
	}

	IfcReal IIfcCartesianTransformationOperator3DnonUniform.Scl2 => new IfcReal(Scl2);

	IfcReal IIfcCartesianTransformationOperator3DnonUniform.Scl3 => new IfcReal(Scl3);

	internal IfcCartesianTransformationOperator3DnonUniform(IModel model, int label, bool activated)
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
			_scale2 = value.RealVal;
			break;
		case 6:
			_scale3 = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator3DnonUniform other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCartesianTransformationOperator3DnonUniformClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCartesianTransformationOperator3DnonUniformClause.WR1:
				result = Scl2 > 0.0;
				break;
			case IfcCartesianTransformationOperator3DnonUniformClause.WR2:
				result = Scl3 > 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianTransformationOperator3DnonUniform>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianTransformationOperator3DnonUniform.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DnonUniformClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3DnonUniform.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DnonUniformClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3DnonUniform.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
