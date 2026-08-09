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

[ExpressType("IfcCondenser", 1132)]
public class IfcCondenser : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IIfcCondenser, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCondenser>, IExpressValidatable
{
	public enum IfcCondenserClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcCondenserTypeEnum? _predefinedType;

	IfcCondenserTypeEnum? IIfcCondenser.PredefinedType
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
	public IfcCondenserTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCondenserTypeEnum? v)
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

	internal IfcCondenser(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCondenserTypeEnum)Enum.Parse(typeof(IfcCondenserTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCondenser other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCondenserClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCondenserClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcCondenserTypeEnum.USERDEFINED || (PredefinedType == IfcCondenserTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcCondenserClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCCONDENSERTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCondenser>()?.LogError($"Exception thrown evaluating where-clause 'IfcCondenser.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCondenserClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCondenser.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCondenserClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCondenser.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
