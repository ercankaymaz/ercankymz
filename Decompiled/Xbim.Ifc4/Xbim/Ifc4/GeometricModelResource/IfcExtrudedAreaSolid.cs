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

[ExpressType("IfcExtrudedAreaSolid", 238)]
public class IfcExtrudedAreaSolid : IfcSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcExtrudedAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcExtrudedAreaSolid>, IExpressValidatable
{
	public enum IfcExtrudedAreaSolidClause
	{
		ValidExtrusionDirection
	}

	private IfcDirection _extrudedDirection;

	private IfcPositiveLengthMeasure _depth;

	IIfcDirection IIfcExtrudedAreaSolid.ExtrudedDirection
	{
		get
		{
			return ExtrudedDirection;
		}
		set
		{
			ExtrudedDirection = value as IfcDirection;
		}
	}

	IfcPositiveLengthMeasure IIfcExtrudedAreaSolid.Depth
	{
		get
		{
			return Depth;
		}
		set
		{
			Depth = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcDirection ExtrudedDirection
	{
		get
		{
			if (_activated)
			{
				return _extrudedDirection;
			}
			Activate();
			return _extrudedDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_extrudedDirection = v;
			}, _extrudedDirection, value, "ExtrudedDirection", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (ExtrudedDirection != null)
			{
				yield return ExtrudedDirection;
			}
		}
	}

	internal IfcExtrudedAreaSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_extrudedDirection = (IfcDirection)value.EntityVal;
			break;
		case 3:
			_depth = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExtrudedAreaSolid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcExtrudedAreaSolidClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcExtrudedAreaSolidClause.ValidExtrusionDirection)
			{
				result = Functions.IfcDotProduct(Functions.IfcDirection(0.0, 0.0, 1.0), ExtrudedDirection) != 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcExtrudedAreaSolid>()?.LogError($"Exception thrown evaluating where-clause 'IfcExtrudedAreaSolid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcExtrudedAreaSolidClause.ValidExtrusionDirection))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcExtrudedAreaSolid.ValidExtrusionDirection",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
