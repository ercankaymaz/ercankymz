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

[ExpressType("IfcReparametrisedCompositeCurveSegment", 1255)]
public class IfcReparametrisedCompositeCurveSegment : IfcCompositeCurveSegment, IInstantiableEntity, IPersistEntity, IPersist, IIfcReparametrisedCompositeCurveSegment, IIfcCompositeCurveSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcReparametrisedCompositeCurveSegment>, IExpressValidatable
{
	public enum IfcReparametrisedCompositeCurveSegmentClause
	{
		PositiveLengthParameter
	}

	private IfcParameterValue _paramLength;

	IfcParameterValue IIfcReparametrisedCompositeCurveSegment.ParamLength
	{
		get
		{
			return ParamLength;
		}
		set
		{
			ParamLength = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcParameterValue ParamLength
	{
		get
		{
			if (_activated)
			{
				return _paramLength;
			}
			Activate();
			return _paramLength;
		}
		set
		{
			SetValue(delegate(IfcParameterValue v)
			{
				_paramLength = v;
			}, _paramLength, value, "ParamLength", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ParentCurve != null)
			{
				yield return base.ParentCurve;
			}
		}
	}

	internal IfcReparametrisedCompositeCurveSegment(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_paramLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReparametrisedCompositeCurveSegment other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcReparametrisedCompositeCurveSegmentClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcReparametrisedCompositeCurveSegmentClause.PositiveLengthParameter)
			{
				result = (double)ParamLength > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcReparametrisedCompositeCurveSegment>()?.LogError($"Exception thrown evaluating where-clause 'IfcReparametrisedCompositeCurveSegment.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcReparametrisedCompositeCurveSegmentClause.PositiveLengthParameter))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReparametrisedCompositeCurveSegment.PositiveLengthParameter",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
