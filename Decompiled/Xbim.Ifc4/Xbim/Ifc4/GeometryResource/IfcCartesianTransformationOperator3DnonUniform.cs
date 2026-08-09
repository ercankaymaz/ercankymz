using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator3DnonUniform", 479)]
public class IfcCartesianTransformationOperator3DnonUniform : IfcCartesianTransformationOperator3D, IInstantiableEntity, IPersistEntity, IPersist, IIfcCartesianTransformationOperator3DnonUniform, IIfcCartesianTransformationOperator3D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator3DnonUniform>, IExpressValidatable
{
	public enum IfcCartesianTransformationOperator3DnonUniformClause
	{
		Scale2GreaterZero,
		Scale3GreaterZero
	}

	private IfcReal? _scale2;

	private IfcReal? _scale3;

	IfcReal? IIfcCartesianTransformationOperator3DnonUniform.Scale2
	{
		get
		{
			return Scale2;
		}
		set
		{
			Scale2 = value;
		}
	}

	IfcReal? IIfcCartesianTransformationOperator3DnonUniform.Scale3
	{
		get
		{
			return Scale3;
		}
		set
		{
			Scale3 = value;
		}
	}

	IfcReal IIfcCartesianTransformationOperator3DnonUniform.Scl2 => Scl2;

	IfcReal IIfcCartesianTransformationOperator3DnonUniform.Scl3 => Scl3;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcReal? Scale2
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
			SetValue(delegate(IfcReal? v)
			{
				_scale2 = v;
			}, _scale2, value, "Scale2", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcReal? Scale3
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
			SetValue(delegate(IfcReal? v)
			{
				_scale3 = v;
			}, _scale3, value, "Scale3", 7);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcReal Scl2 => Scale2 ?? base.Scl;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcReal Scl3 => Scale3 ?? base.Scl;

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
			case IfcCartesianTransformationOperator3DnonUniformClause.Scale2GreaterZero:
				result = (double)Scl2 > 0.0;
				break;
			case IfcCartesianTransformationOperator3DnonUniformClause.Scale3GreaterZero:
				result = (double)Scl3 > 0.0;
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
		if (!ValidateClause(IfcCartesianTransformationOperator3DnonUniformClause.Scale2GreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3DnonUniform.Scale2GreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DnonUniformClause.Scale3GreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3DnonUniform.Scale3GreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
