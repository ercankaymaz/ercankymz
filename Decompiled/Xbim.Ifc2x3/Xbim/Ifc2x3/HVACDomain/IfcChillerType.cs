using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcChillerType", 368)]
public class IfcChillerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcChillerType>, IIfcChillerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcChillerTypeClause
	{
		WR1
	}

	private IfcChillerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcChillerTypeEnum PredefinedType
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
			SetValue(delegate(IfcChillerTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcChillerType), 10)]
	Xbim.Ifc4.Interfaces.IfcChillerTypeEnum IIfcChillerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcChillerTypeEnum.AIRCOOLED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.AIRCOOLED, 
				IfcChillerTypeEnum.WATERCOOLED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.WATERCOOLED, 
				IfcChillerTypeEnum.HEATRECOVERY => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.HEATRECOVERY, 
				IfcChillerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.USERDEFINED, 
				IfcChillerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.AIRCOOLED:
				PredefinedType = IfcChillerTypeEnum.AIRCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.WATERCOOLED:
				PredefinedType = IfcChillerTypeEnum.WATERCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.HEATRECOVERY:
				PredefinedType = IfcChillerTypeEnum.HEATRECOVERY;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.USERDEFINED:
				PredefinedType = IfcChillerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChillerTypeEnum.NOTDEFINED:
				PredefinedType = IfcChillerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcChillerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcChillerTypeEnum)Enum.Parse(typeof(IfcChillerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcChillerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcChillerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcChillerTypeClause.WR1)
			{
				result = PredefinedType != IfcChillerTypeEnum.USERDEFINED || (PredefinedType == IfcChillerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcChillerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcChillerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcChillerTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcChillerType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
