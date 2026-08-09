using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.SharedBldgServiceElements;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.HvacDomain;

[ExpressType("IfcTankType", 619)]
public class IfcTankType : IfcFlowStorageDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IIfcTankType, IIfcFlowStorageDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTankType>, IExpressValidatable
{
	public enum IfcTankTypeClause
	{
		CorrectPredefinedType
	}

	private IfcTankTypeEnum _predefinedType;

	IfcTankTypeEnum IIfcTankType.PredefinedType
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTankTypeEnum PredefinedType
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
			SetValue(delegate(IfcTankTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
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

	internal IfcTankType(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcTankTypeEnum)Enum.Parse(typeof(IfcTankTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTankType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTankTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTankTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcTankTypeEnum.USERDEFINED || (PredefinedType == IfcTankTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTankType>()?.LogError($"Exception thrown evaluating where-clause 'IfcTankType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTankTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTankType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
