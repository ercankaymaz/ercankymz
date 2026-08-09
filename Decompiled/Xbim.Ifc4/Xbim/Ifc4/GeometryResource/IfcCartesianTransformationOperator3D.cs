using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator3D", 337)]
public class IfcCartesianTransformationOperator3D : IfcCartesianTransformationOperator, IInstantiableEntity, IPersistEntity, IPersist, IIfcCartesianTransformationOperator3D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator3D>, IExpressValidatable
{
	public enum IfcCartesianTransformationOperator3DClause
	{
		DimIs3D,
		Axis1Is3D,
		Axis2Is3D,
		Axis3Is3D
	}

	private IfcDirection _axis3;

	IIfcDirection IIfcCartesianTransformationOperator3D.Axis3
	{
		get
		{
			return Axis3;
		}
		set
		{
			Axis3 = value as IfcDirection;
		}
	}

	List<XbimVector3D> IIfcCartesianTransformationOperator3D.U => new List<XbimVector3D>(U);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcDirection Axis3
	{
		get
		{
			if (_activated)
			{
				return _axis3;
			}
			Activate();
			return _axis3;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis3 = v;
			}, _axis3, value, "Axis3", 5);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { 3 }, 0)]
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
			if (Axis3 != null)
			{
				yield return Axis3;
			}
		}
	}

	internal IfcCartesianTransformationOperator3D(IModel model, int label, bool activated)
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
			_axis3 = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator3D other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCartesianTransformationOperator3DClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCartesianTransformationOperator3DClause.DimIs3D:
				result = base.Dim == 3L;
				break;
			case IfcCartesianTransformationOperator3DClause.Axis1Is3D:
				result = !Functions.EXISTS(base.Axis1) || base.Axis1.Dim == 3L;
				break;
			case IfcCartesianTransformationOperator3DClause.Axis2Is3D:
				result = !Functions.EXISTS(base.Axis2) || base.Axis2.Dim == 3L;
				break;
			case IfcCartesianTransformationOperator3DClause.Axis3Is3D:
				result = !Functions.EXISTS(Axis3) || Axis3.Dim == 3L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianTransformationOperator3D>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianTransformationOperator3D.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DClause.DimIs3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3D.DimIs3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DClause.Axis1Is3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3D.Axis1Is3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DClause.Axis2Is3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3D.Axis2Is3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCartesianTransformationOperator3DClause.Axis3Is3D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator3D.Axis3Is3D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
