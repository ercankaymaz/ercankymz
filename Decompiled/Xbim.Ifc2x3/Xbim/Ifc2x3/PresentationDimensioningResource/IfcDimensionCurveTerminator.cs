using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDimensionCurveTerminator", 744)]
public class IfcDimensionCurveTerminator : IfcTerminatorSymbol, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDimensionCurveTerminator>, IExpressValidatable
{
	public enum IfcDimensionCurveTerminatorClause
	{
		WR61
	}

	private IfcDimensionExtentUsage _role;

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 7)]
	public IfcDimensionExtentUsage Role
	{
		get
		{
			if (_activated)
			{
				return _role;
			}
			Activate();
			return _role;
		}
		set
		{
			SetValue(delegate(IfcDimensionExtentUsage v)
			{
				_role = v;
			}, _role, value, "Role", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
			foreach (IfcPresentationStyleAssignment style in base.Styles)
			{
				yield return style;
			}
			if (base.AnnotatedCurve != null)
			{
				yield return base.AnnotatedCurve;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
			if (base.AnnotatedCurve != null)
			{
				yield return base.AnnotatedCurve;
			}
		}
	}

	internal IfcDimensionCurveTerminator(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_role = (IfcDimensionExtentUsage)Enum.Parse(typeof(IfcDimensionExtentUsage), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDimensionCurveTerminator other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDimensionCurveTerminatorClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDimensionCurveTerminatorClause.WR61)
			{
				result = Functions.TYPEOF(base.AnnotatedCurve).Contains("IFC2X3.IFCDIMENSIONCURVE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDimensionCurveTerminator>()?.LogError($"Exception thrown evaluating where-clause 'IfcDimensionCurveTerminator.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDimensionCurveTerminatorClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurveTerminator.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
