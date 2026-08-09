using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcOffsetCurve3D", 67)]
public class IfcOffsetCurve3D : IfcOffsetCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcOffsetCurve3D, IIfcOffsetCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IContainsEntityReferences, IEquatable<IfcOffsetCurve3D>, IExpressValidatable
{
	public enum IfcOffsetCurve3DClause
	{
		DimIs2D
	}

	private IfcLengthMeasure _distance;

	private IfcLogical _selfIntersect;

	private IfcDirection _refDirection;

	IfcLengthMeasure IIfcOffsetCurve3D.Distance
	{
		get
		{
			return Distance;
		}
		set
		{
			Distance = value;
		}
	}

	IfcLogical IIfcOffsetCurve3D.SelfIntersect
	{
		get
		{
			return SelfIntersect;
		}
		set
		{
			SelfIntersect = value;
		}
	}

	IIfcDirection IIfcOffsetCurve3D.RefDirection
	{
		get
		{
			return RefDirection;
		}
		set
		{
			RefDirection = value as IfcDirection;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure Distance
	{
		get
		{
			if (_activated)
			{
				return _distance;
			}
			Activate();
			return _distance;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_distance = v;
			}, _distance, value, "Distance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLogical SelfIntersect
	{
		get
		{
			if (_activated)
			{
				return _selfIntersect;
			}
			Activate();
			return _selfIntersect;
		}
		set
		{
			SetValue(delegate(IfcLogical v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDirection RefDirection
	{
		get
		{
			if (_activated)
			{
				return _refDirection;
			}
			Activate();
			return _refDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_refDirection = v;
			}, _refDirection, value, "RefDirection", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.BasisCurve != null)
			{
				yield return base.BasisCurve;
			}
			if (RefDirection != null)
			{
				yield return RefDirection;
			}
		}
	}

	internal IfcOffsetCurve3D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_distance = value.RealVal;
			break;
		case 2:
			_selfIntersect = value.BooleanVal;
			break;
		case 3:
			_refDirection = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOffsetCurve3D other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcOffsetCurve3DClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcOffsetCurve3DClause.DimIs2D)
			{
				result = base.BasisCurve.Dim == 3L;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcOffsetCurve3D>()?.LogError($"Exception thrown evaluating where-clause 'IfcOffsetCurve3D.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcOffsetCurve3DClause.DimIs2D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcOffsetCurve3D.DimIs2D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
