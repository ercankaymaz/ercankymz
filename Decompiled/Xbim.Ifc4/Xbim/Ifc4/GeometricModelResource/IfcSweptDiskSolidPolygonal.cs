using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSweptDiskSolidPolygonal", 1289)]
public class IfcSweptDiskSolidPolygonal : IfcSweptDiskSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcSweptDiskSolidPolygonal, IIfcSweptDiskSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcSweptDiskSolidPolygonal>, IExpressValidatable
{
	public enum IfcSweptDiskSolidPolygonalClause
	{
		CorrectRadii,
		DirectrixIsPolyline
	}

	private IfcPositiveLengthMeasure? _filletRadius;

	IfcPositiveLengthMeasure? IIfcSweptDiskSolidPolygonal.FilletRadius
	{
		get
		{
			return FilletRadius;
		}
		set
		{
			FilletRadius = value;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure? FilletRadius
	{
		get
		{
			if (_activated)
			{
				return _filletRadius;
			}
			Activate();
			return _filletRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
		}
	}

	internal IfcSweptDiskSolidPolygonal(IModel model, int label, bool activated)
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
			_filletRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptDiskSolidPolygonal other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSweptDiskSolidPolygonalClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSweptDiskSolidPolygonalClause.CorrectRadii:
				result = !Functions.EXISTS(FilletRadius) || (double?)FilletRadius >= (double)base.Radius;
				break;
			case IfcSweptDiskSolidPolygonalClause.DirectrixIsPolyline:
				result = Functions.TYPEOF(base.Directrix).Contains("IFC4.IFCPOLYLINE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSweptDiskSolidPolygonal>()?.LogError($"Exception thrown evaluating where-clause 'IfcSweptDiskSolidPolygonal.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSweptDiskSolidPolygonalClause.CorrectRadii))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptDiskSolidPolygonal.CorrectRadii",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSweptDiskSolidPolygonalClause.DirectrixIsPolyline))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptDiskSolidPolygonal.DirectrixIsPolyline",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
