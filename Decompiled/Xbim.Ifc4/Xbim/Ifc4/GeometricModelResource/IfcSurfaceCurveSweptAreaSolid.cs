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

[ExpressType("IfcSurfaceCurveSweptAreaSolid", 480)]
public class IfcSurfaceCurveSweptAreaSolid : IfcSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceCurveSweptAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcSurfaceCurveSweptAreaSolid>, IExpressValidatable
{
	public enum IfcSurfaceCurveSweptAreaSolidClause
	{
		DirectrixBounded
	}

	private IfcCurve _directrix;

	private IfcParameterValue? _startParam;

	private IfcParameterValue? _endParam;

	private IfcSurface _referenceSurface;

	IIfcCurve IIfcSurfaceCurveSweptAreaSolid.Directrix
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

	IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.StartParam
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

	IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.EndParam
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

	IIfcSurface IIfcSurfaceCurveSweptAreaSolid.ReferenceSurface
	{
		get
		{
			return ReferenceSurface;
		}
		set
		{
			ReferenceSurface = value as IfcSurface;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
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
			}, _directrix, value, "Directrix", 3);
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

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcSurface ReferenceSurface
	{
		get
		{
			if (_activated)
			{
				return _referenceSurface;
			}
			Activate();
			return _referenceSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_referenceSurface = v;
			}, _referenceSurface, value, "ReferenceSurface", 6);
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
			if (Directrix != null)
			{
				yield return Directrix;
			}
			if (ReferenceSurface != null)
			{
				yield return ReferenceSurface;
			}
		}
	}

	internal IfcSurfaceCurveSweptAreaSolid(IModel model, int label, bool activated)
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
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 3:
			_startParam = value.RealVal;
			break;
		case 4:
			_endParam = value.RealVal;
			break;
		case 5:
			_referenceSurface = (IfcSurface)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceCurveSweptAreaSolid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSurfaceCurveSweptAreaSolidClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSurfaceCurveSweptAreaSolidClause.DirectrixBounded)
			{
				result = (Functions.EXISTS(StartParam) && Functions.EXISTS(EndParam)) || Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCCONIC", "IFC4.IFCBOUNDEDCURVE") * Functions.TYPEOF(Directrix)) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSurfaceCurveSweptAreaSolid>()?.LogError($"Exception thrown evaluating where-clause 'IfcSurfaceCurveSweptAreaSolid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSurfaceCurveSweptAreaSolidClause.DirectrixBounded))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceCurveSweptAreaSolid.DirectrixBounded",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
