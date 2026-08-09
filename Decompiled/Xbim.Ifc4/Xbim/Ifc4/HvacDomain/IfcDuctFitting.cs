using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.SharedBldgServiceElements;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.HvacDomain;

[ExpressType("IfcDuctFitting", 1153)]
public class IfcDuctFitting : IfcFlowFitting, IInstantiableEntity, IPersistEntity, IPersist, IIfcDuctFitting, IIfcFlowFitting, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctFitting>, IExpressValidatable
{
	public enum IfcDuctFittingClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcDuctFittingTypeEnum? _predefinedType;

	IfcDuctFittingTypeEnum? IIfcDuctFitting.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcDuctFittingTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcDuctFittingTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
		}
	}

	internal IfcDuctFitting(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcDuctFittingTypeEnum)Enum.Parse(typeof(IfcDuctFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctFitting other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDuctFittingClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDuctFittingClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcDuctFittingTypeEnum.USERDEFINED || (PredefinedType == IfcDuctFittingTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcDuctFittingClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCDUCTFITTINGTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDuctFitting>()?.LogError($"Exception thrown evaluating where-clause 'IfcDuctFitting.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDuctFittingClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDuctFitting.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDuctFittingClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDuctFitting.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
