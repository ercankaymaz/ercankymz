using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcPcurve", 1220)]
public class IfcPcurve : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcPcurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOnSurface, IIfcCurveOnSurface, IContainsEntityReferences, IEquatable<IfcPcurve>, IExpressValidatable
{
	public enum IfcPcurveClause
	{
		DimIs2D
	}

	private IfcSurface _basisSurface;

	private IfcCurve _referenceCurve;

	IIfcSurface IIfcPcurve.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcSurface;
		}
	}

	IIfcCurve IIfcPcurve.ReferenceCurve
	{
		get
		{
			return ReferenceCurve;
		}
		set
		{
			ReferenceCurve = value as IfcCurve;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BasisSurface
	{
		get
		{
			if (_activated)
			{
				return _basisSurface;
			}
			Activate();
			return _basisSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCurve ReferenceCurve
	{
		get
		{
			if (_activated)
			{
				return _referenceCurve;
			}
			Activate();
			return _referenceCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_referenceCurve = v;
			}, _referenceCurve, value, "ReferenceCurve", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisSurface != null)
			{
				yield return BasisSurface;
			}
			if (ReferenceCurve != null)
			{
				yield return ReferenceCurve;
			}
		}
	}

	internal IfcPcurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcSurface)value.EntityVal;
			break;
		case 1:
			_referenceCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPcurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPcurveClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPcurveClause.DimIs2D)
			{
				result = ReferenceCurve.Dim == 2L;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPcurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcPcurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPcurveClause.DimIs2D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPcurve.DimIs2D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
