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

[ExpressType("IfcCartesianTransformationOperator", 146)]
public abstract class IfcCartesianTransformationOperator : IfcGeometricRepresentationItem, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcCartesianTransformationOperator>, IExpressValidatable
{
	public enum IfcCartesianTransformationOperatorClause
	{
		ScaleGreaterZero
	}

	private IfcDirection _axis1;

	private IfcDirection _axis2;

	private IfcCartesianPoint _localOrigin;

	private IfcReal? _scale;

	IIfcDirection IIfcCartesianTransformationOperator.Axis1
	{
		get
		{
			return Axis1;
		}
		set
		{
			Axis1 = value as IfcDirection;
		}
	}

	IIfcDirection IIfcCartesianTransformationOperator.Axis2
	{
		get
		{
			return Axis2;
		}
		set
		{
			Axis2 = value as IfcDirection;
		}
	}

	IIfcCartesianPoint IIfcCartesianTransformationOperator.LocalOrigin
	{
		get
		{
			return LocalOrigin;
		}
		set
		{
			LocalOrigin = value as IfcCartesianPoint;
		}
	}

	IfcReal? IIfcCartesianTransformationOperator.Scale
	{
		get
		{
			return Scale;
		}
		set
		{
			Scale = value;
		}
	}

	IfcReal IIfcCartesianTransformationOperator.Scl => Scl;

	IfcDimensionCount IIfcCartesianTransformationOperator.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDirection Axis1
	{
		get
		{
			if (_activated)
			{
				return _axis1;
			}
			Activate();
			return _axis1;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis1 = v;
			}, _axis1, value, "Axis1", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDirection Axis2
	{
		get
		{
			if (_activated)
			{
				return _axis2;
			}
			Activate();
			return _axis2;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis2 = v;
			}, _axis2, value, "Axis2", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCartesianPoint LocalOrigin
	{
		get
		{
			if (_activated)
			{
				return _localOrigin;
			}
			Activate();
			return _localOrigin;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_localOrigin = v;
			}, _localOrigin, value, "LocalOrigin", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcReal? Scale
	{
		get
		{
			if (_activated)
			{
				return _scale;
			}
			Activate();
			return _scale;
		}
		set
		{
			SetValue(delegate(IfcReal? v)
			{
				_scale = v;
			}, _scale, value, "Scale", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcReal Scl => Scale ?? ((IfcReal)1.0);

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => LocalOrigin.Dim;

	internal IfcCartesianTransformationOperator(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_axis1 = (IfcDirection)value.EntityVal;
			break;
		case 1:
			_axis2 = (IfcDirection)value.EntityVal;
			break;
		case 2:
			_localOrigin = (IfcCartesianPoint)value.EntityVal;
			break;
		case 3:
			_scale = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianTransformationOperator other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCartesianTransformationOperatorClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCartesianTransformationOperatorClause.ScaleGreaterZero)
			{
				result = (double)Scl > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCartesianTransformationOperator>()?.LogError($"Exception thrown evaluating where-clause 'IfcCartesianTransformationOperator.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCartesianTransformationOperatorClause.ScaleGreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCartesianTransformationOperator.ScaleGreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
