using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLinearAction", 463)]
public class IfcStructuralLinearAction : IfcStructuralAction, IIfcStructuralLinearAction, IIfcStructuralCurveAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralLinearAction>, IExpressValidatable
{
	public enum IfcStructuralLinearActionClause
	{
		WR61
	}

	private IfcStructuralCurveActivityTypeEnum _predefinedType;

	private IfcProjectedOrTrueLengthEnum _projectedOrTrue;

	[CrossSchemaAttribute(typeof(IIfcStructuralLinearAction), 11)]
	Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum? IIfcStructuralCurveAction.ProjectedOrTrue
	{
		get
		{
			return ProjectedOrTrue switch
			{
				IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH => Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH, 
				IfcProjectedOrTrueLengthEnum.TRUE_LENGTH => Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.TRUE_LENGTH, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH:
				ProjectedOrTrue = IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.TRUE_LENGTH:
				ProjectedOrTrue = IfcProjectedOrTrueLengthEnum.TRUE_LENGTH;
				break;
			case null:
				ProjectedOrTrue = IfcProjectedOrTrueLengthEnum.TRUE_LENGTH;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLinearAction), 12)]
	IfcStructuralCurveActivityTypeEnum IIfcStructuralCurveAction.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcStructuralCurveActivityTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -12);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcProjectedOrTrueLengthEnum ProjectedOrTrue
	{
		get
		{
			if (_activated)
			{
				return _projectedOrTrue;
			}
			Activate();
			return _projectedOrTrue;
		}
		set
		{
			SetValue(delegate(IfcProjectedOrTrueLengthEnum v)
			{
				_projectedOrTrue = v;
			}, _projectedOrTrue, value, "ProjectedOrTrue", 12);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.AppliedLoad != null)
			{
				yield return base.AppliedLoad;
			}
			if (base.CausedBy != null)
			{
				yield return base.CausedBy;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.CausedBy != null)
			{
				yield return base.CausedBy;
			}
		}
	}

	internal IfcStructuralLinearAction(IModel model, int label, bool activated)
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
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 11:
			_projectedOrTrue = (IfcProjectedOrTrueLengthEnum)Enum.Parse(typeof(IfcProjectedOrTrueLengthEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLinearAction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralLinearActionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralLinearActionClause.WR61)
			{
				result = Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCSTRUCTURALLOADLINEARFORCE", "IFC2X3.IFCSTRUCTURALLOADTEMPERATURE") * Functions.TYPEOF(base.AppliedLoad)) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralLinearAction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralLinearAction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralLinearActionClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLinearAction.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
