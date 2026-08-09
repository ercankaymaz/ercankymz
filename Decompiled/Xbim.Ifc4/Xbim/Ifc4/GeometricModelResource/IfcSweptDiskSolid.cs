using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSweptDiskSolid", 547)]
public class IfcSweptDiskSolid : IfcSolidModel, IInstantiableEntity, IPersistEntity, IPersist, IIfcSweptDiskSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcSweptDiskSolid>, IExpressValidatable
{
	public enum IfcSweptDiskSolidClause
	{
		DirectrixDim,
		InnerRadiusSize,
		DirectrixBounded
	}

	private IfcCurve _directrix;

	private IfcPositiveLengthMeasure _radius;

	private IfcPositiveLengthMeasure? _innerRadius;

	private IfcParameterValue? _startParam;

	private IfcParameterValue? _endParam;

	IIfcCurve IIfcSweptDiskSolid.Directrix
	{
		get
		{
			return Directrix;
		}
		set
		{
			Directrix = value as IfcCurve;
		}
	}

	IfcPositiveLengthMeasure IIfcSweptDiskSolid.Radius
	{
		get
		{
			return Radius;
		}
		set
		{
			Radius = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcSweptDiskSolid.InnerRadius
	{
		get
		{
			return InnerRadius;
		}
		set
		{
			InnerRadius = value;
		}
	}

	IfcParameterValue? IIfcSweptDiskSolid.StartParam
	{
		get
		{
			return StartParam;
		}
		set
		{
			StartParam = value;
		}
	}

	IfcParameterValue? IIfcSweptDiskSolid.EndParam
	{
		get
		{
			return EndParam;
		}
		set
		{
			EndParam = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve Directrix
	{
		get
		{
			if (_activated)
			{
				return _directrix;
			}
			Activate();
			return _directrix;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_directrix = v;
			}, _directrix, value, "Directrix", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure Radius
	{
		get
		{
			if (_activated)
			{
				return _radius;
			}
			Activate();
			return _radius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure? InnerRadius
	{
		get
		{
			if (_activated)
			{
				return _innerRadius;
			}
			Activate();
			return _innerRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_innerRadius = v;
			}, _innerRadius, value, "InnerRadius", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcParameterValue? StartParam
	{
		get
		{
			if (_activated)
			{
				return _startParam;
			}
			Activate();
			return _startParam;
		}
		set
		{
			SetValue(delegate(IfcParameterValue? v)
			{
				_startParam = v;
			}, _startParam, value, "StartParam", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcParameterValue? EndParam
	{
		get
		{
			if (_activated)
			{
				return _endParam;
			}
			Activate();
			return _endParam;
		}
		set
		{
			SetValue(delegate(IfcParameterValue? v)
			{
				_endParam = v;
			}, _endParam, value, "EndParam", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Directrix != null)
			{
				yield return Directrix;
			}
		}
	}

	internal IfcSweptDiskSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_radius = value.RealVal;
			break;
		case 2:
			_innerRadius = value.RealVal;
			break;
		case 3:
			_startParam = value.RealVal;
			break;
		case 4:
			_endParam = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptDiskSolid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSweptDiskSolidClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSweptDiskSolidClause.DirectrixDim:
				result = Directrix.Dim == 3L;
				break;
			case IfcSweptDiskSolidClause.InnerRadiusSize:
				result = !Functions.EXISTS(InnerRadius) || (double)Radius > (double?)InnerRadius;
				break;
			case IfcSweptDiskSolidClause.DirectrixBounded:
				result = (Functions.EXISTS(StartParam) && Functions.EXISTS(EndParam)) || Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCCONIC", "IFC4.IFCBOUNDEDCURVE") * Functions.TYPEOF(Directrix)) == 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSweptDiskSolid>()?.LogError($"Exception thrown evaluating where-clause 'IfcSweptDiskSolid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSweptDiskSolidClause.DirectrixDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptDiskSolid.DirectrixDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSweptDiskSolidClause.InnerRadiusSize))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptDiskSolid.InnerRadiusSize",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSweptDiskSolidClause.DirectrixBounded))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptDiskSolid.DirectrixBounded",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
