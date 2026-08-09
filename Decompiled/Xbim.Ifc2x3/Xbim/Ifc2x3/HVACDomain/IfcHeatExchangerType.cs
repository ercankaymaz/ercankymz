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

[ExpressType("IfcHeatExchangerType", 365)]
public class IfcHeatExchangerType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcHeatExchangerType>, IIfcHeatExchangerType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcHeatExchangerTypeClause
	{
		WR1
	}

	private IfcHeatExchangerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcHeatExchangerTypeEnum PredefinedType
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
			SetValue(delegate(IfcHeatExchangerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcHeatExchangerType), 10)]
	Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum IIfcHeatExchangerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcHeatExchangerTypeEnum.PLATE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE, 
				IfcHeatExchangerTypeEnum.SHELLANDTUBE => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE, 
				IfcHeatExchangerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED, 
				IfcHeatExchangerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.PLATE:
				PredefinedType = IfcHeatExchangerTypeEnum.PLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.SHELLANDTUBE:
				PredefinedType = IfcHeatExchangerTypeEnum.SHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.USERDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcHeatExchangerTypeEnum.NOTDEFINED:
				PredefinedType = IfcHeatExchangerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcHeatExchangerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcHeatExchangerTypeEnum)Enum.Parse(typeof(IfcHeatExchangerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHeatExchangerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcHeatExchangerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcHeatExchangerTypeClause.WR1)
			{
				result = PredefinedType != IfcHeatExchangerTypeEnum.USERDEFINED || (PredefinedType == IfcHeatExchangerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcHeatExchangerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcHeatExchangerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcHeatExchangerTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcHeatExchangerType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
