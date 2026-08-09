using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcOffsetCurve3D", 67)]
public class IfcOffsetCurve3D : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOffsetCurve3D>, IIfcOffsetCurve3D, IIfcOffsetCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IExpressValidatable
{
	public enum IfcOffsetCurve3DClause
	{
		WR1
	}

	private IfcCurve _basisCurve;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _distance;

	private bool? _selfIntersect;

	private IfcDirection _refDirection;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve BasisCurve
	{
		get
		{
			if (_activated)
			{
				return _basisCurve;
			}
			Activate();
			return _basisCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_basisCurve = v;
			}, _basisCurve, value, "BasisCurve", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure Distance
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_distance = v;
			}, _distance, value, "Distance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public bool? SelfIntersect
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
			SetValue(delegate(bool? v)
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
			if (BasisCurve != null)
			{
				yield return BasisCurve;
			}
			if (RefDirection != null)
			{
				yield return RefDirection;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve3D), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcOffsetCurve3D.Distance
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Distance);
		}
		set
		{
			Distance = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve3D), 3)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcOffsetCurve3D.SelfIntersect
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve3D), 4)]
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

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve3D), 1)]
	IIfcCurve IIfcOffsetCurve.BasisCurve
	{
		get
		{
			return BasisCurve;
		}
		set
		{
			BasisCurve = value as IfcCurve;
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
			_basisCurve = (IfcCurve)value.EntityVal;
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
			if (clause == IfcOffsetCurve3DClause.WR1)
			{
				result = BasisCurve.Dim == 3L;
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
		if (!ValidateClause(IfcOffsetCurve3DClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcOffsetCurve3D.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
