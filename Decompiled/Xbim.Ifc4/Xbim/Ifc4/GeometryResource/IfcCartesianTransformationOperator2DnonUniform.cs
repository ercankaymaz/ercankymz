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

[ExpressType("IfcCartesianTransformationOperator2DnonUniform", 147)]
public class IfcCartesianTransformationOperator2DnonUniform : IfcCartesianTransformationOperator2D, IInstantiableEntity, IPersistEntity, IPersist, IIfcCartesianTransformationOperator2DnonUniform, IIfcCartesianTransformationOperator2D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator2DnonUniform>, IExpressValidatable
{
	public enum IfcCartesianTransformationOperator2DnonUniformClause
	{
		Scale2GreaterZero
	}

	private IfcReal? _scale2;

	IfcReal? IIfcCartesianTransformationOperator2DnonUniform.Scale2
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

	IfcReal IIfcCartesianTransformationOperator2DnonUniform.Scl2 => Scl2;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
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
			}, _scale2, value, "Scale2", 5);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcReal Scl2 => Scale2 ?? base.Scl;

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
		}
	}

	internal IfcCartesianTransformationOperator2DnonUniform(IModel model, int label, bool activated)
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
			_scale2 = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator2DnonUniform other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCartesianTransformationOperator2DnonUniformClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCartesianTransformationOperator2DnonUniformClause.Scale2GreaterZero)
			{
				result = (double)Scl2 > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianTransformationOperator2DnonUniform>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianTransformationOperator2DnonUniform.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCartesianTransformationOperator2DnonUniformClause.Scale2GreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator2DnonUniform.Scale2GreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
