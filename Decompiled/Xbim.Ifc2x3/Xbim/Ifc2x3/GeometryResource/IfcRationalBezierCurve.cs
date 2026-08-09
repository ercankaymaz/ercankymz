using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcRationalBezierCurve", 546)]
public class IfcRationalBezierCurve : IfcBezierCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRationalBezierCurve>, IExpressValidatable
{
	public enum IfcRationalBezierCurveClause
	{
		WR1,
		WR2
	}

	private readonly ItemSet<double> _weightsData;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 8)]
	public IItemSet<double> WeightsData
	{
		get
		{
			if (_activated)
			{
				return _weightsData;
			}
			Activate();
			return _weightsData;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.None, new int[] { 0 }, new int[] { 255 }, 0)]
	public List<double> Weights => WeightsData.ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint controlPoints in base.ControlPointsList)
			{
				yield return controlPoints;
			}
		}
	}

	internal IfcRationalBezierCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_weightsData = new ItemSet<double>(this, 0, 6);
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
			_weightsData.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRationalBezierCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRationalBezierCurveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRationalBezierCurveClause.WR1:
				result = Functions.SIZEOF(WeightsData) == Functions.SIZEOF(base.ControlPointsList);
				break;
			case IfcRationalBezierCurveClause.WR2:
				result = Functions.IfcCurveWeightsPositive(this);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRationalBezierCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcRationalBezierCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRationalBezierCurveClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBezierCurve.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRationalBezierCurveClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBezierCurve.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
