using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcMember", 310)]
public class IfcMember : IfcBuildingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcMember, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMember>, IExpressValidatable
{
	public enum IfcMemberClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcMemberTypeEnum? _predefinedType;

	IfcMemberTypeEnum? IIfcMember.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 33)]
	public IfcMemberTypeEnum? PredefinedType
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
			SetValue(delegate(IfcMemberTypeEnum? v)
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

	internal IfcMember(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMemberTypeEnum)Enum.Parse(typeof(IfcMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMember other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMemberClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcMemberClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcMemberTypeEnum.USERDEFINED || (PredefinedType == IfcMemberTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcMemberClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCMEMBERTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMember>()?.LogError($"Exception thrown evaluating where-clause 'IfcMember.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcMemberClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMember.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMemberClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMember.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
