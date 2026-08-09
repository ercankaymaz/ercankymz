using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator2D", 145)]
public class IfcCartesianTransformationOperator2D : IfcCartesianTransformationOperator, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator2D>, IIfcCartesianTransformationOperator2D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcCartesianTransformationOperator2DClause
	{
		WR1,
		WR2,
		WR3
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { 2 }, 0)]
	public List<XbimVector3D> U
	{
		get
		{
			throw new NotImplementedException();
		}
	}

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

	List<XbimVector3D> IIfcCartesianTransformationOperator2D.U => U;

	internal IfcCartesianTransformationOperator2D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCartesianTransformationOperator2D other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCartesianTransformationOperator2DClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCartesianTransformationOperator2DClause.WR1:
				result = base.Dim == 2L;
				break;
			case IfcCartesianTransformationOperator2DClause.WR2:
				result = !Functions.EXISTS(base.Axis1) || base.Axis1.Dim == 2L;
				break;
			case IfcCartesianTransformationOperator2DClause.WR3:
				result = !Functions.EXISTS(base.Axis2) || base.Axis2.Dim == 2L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianTransformationOperator2D>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianTransformationOperator2D.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCartesianTransformationOperator2DClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator2D.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator2DClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator2D.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator2DClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator2D.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
