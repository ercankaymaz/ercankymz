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

[ExpressType("IfcConstructionMaterialResource", 243)]
public class IfcConstructionMaterialResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IIfcConstructionMaterialResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IContainsEntityReferences, IEquatable<IfcConstructionMaterialResource>, IExpressValidatable
{
	public enum IfcConstructionMaterialResourceClause
	{
		CorrectPredefinedType
	}

	private IfcConstructionMaterialResourceTypeEnum? _predefinedType;

	IfcConstructionMaterialResourceTypeEnum? IIfcConstructionMaterialResource.PredefinedType
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcConstructionMaterialResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcConstructionMaterialResourceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
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
			if (base.Usage != null)
			{
				yield return base.Usage;
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

	internal IfcConstructionMaterialResource(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_predefinedType = (IfcConstructionMaterialResourceTypeEnum)Enum.Parse(typeof(IfcConstructionMaterialResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionMaterialResource other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstructionMaterialResourceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcConstructionMaterialResourceClause.CorrectPredefinedType)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcConstructionMaterialResourceTypeEnum.USERDEFINED || (PredefinedType == IfcConstructionMaterialResourceTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstructionMaterialResource>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstructionMaterialResource.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcConstructionMaterialResourceClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionMaterialResource.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
