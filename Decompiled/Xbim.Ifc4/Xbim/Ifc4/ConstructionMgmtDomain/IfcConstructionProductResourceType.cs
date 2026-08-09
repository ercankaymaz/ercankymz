using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ConstructionMgmtDomain;

[ExpressType("IfcConstructionProductResourceType", 1136)]
public class IfcConstructionProductResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IIfcConstructionProductResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstructionProductResourceType>, IExpressValidatable
{
	public enum IfcConstructionProductResourceTypeClause
	{
		CorrectPredefinedType
	}

	private IfcConstructionProductResourceTypeEnum _predefinedType;

	IfcConstructionProductResourceTypeEnum IIfcConstructionProductResourceType.PredefinedType
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

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcConstructionProductResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcConstructionProductResourceTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 12);
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcAppliedValue baseCost in base.BaseCosts)
			{
				yield return baseCost;
			}
			if (base.BaseQuantity != null)
			{
				yield return base.BaseQuantity;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcConstructionProductResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcConstructionProductResourceTypeEnum)Enum.Parse(typeof(IfcConstructionProductResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionProductResourceType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstructionProductResourceTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcConstructionProductResourceTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcConstructionProductResourceTypeEnum.USERDEFINED || (PredefinedType == IfcConstructionProductResourceTypeEnum.USERDEFINED && Functions.EXISTS(base.ResourceType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstructionProductResourceType>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstructionProductResourceType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcConstructionProductResourceTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionProductResourceType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
