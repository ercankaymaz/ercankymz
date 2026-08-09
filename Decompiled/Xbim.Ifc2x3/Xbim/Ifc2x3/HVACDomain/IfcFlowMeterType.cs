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
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcFlowMeterType", 366)]
public class IfcFlowMeterType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFlowMeterType>, IIfcFlowMeterType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcFlowMeterTypeClause
	{
		WR1
	}

	private IfcFlowMeterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcFlowMeterTypeEnum PredefinedType
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
			SetValue(delegate(IfcFlowMeterTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcFlowMeterType), 10)]
	Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum IIfcFlowMeterType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFlowMeterTypeEnum.ELECTRICMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED, 
				IfcFlowMeterTypeEnum.ENERGYMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.ENERGYMETER, 
				IfcFlowMeterTypeEnum.FLOWMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED, 
				IfcFlowMeterTypeEnum.GASMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.GASMETER, 
				IfcFlowMeterTypeEnum.OILMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.OILMETER, 
				IfcFlowMeterTypeEnum.WATERMETER => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.WATERMETER, 
				IfcFlowMeterTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED, 
				IfcFlowMeterTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.ENERGYMETER:
				PredefinedType = IfcFlowMeterTypeEnum.ENERGYMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.GASMETER:
				PredefinedType = IfcFlowMeterTypeEnum.GASMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.OILMETER:
				PredefinedType = IfcFlowMeterTypeEnum.OILMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.WATERMETER:
				PredefinedType = IfcFlowMeterTypeEnum.WATERMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.USERDEFINED:
				PredefinedType = IfcFlowMeterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowMeterTypeEnum.NOTDEFINED:
				PredefinedType = IfcFlowMeterTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			IfcFlowMeterTypeEnum predefinedType = PredefinedType;
			if (predefinedType == IfcFlowMeterTypeEnum.ELECTRICMETER || predefinedType == IfcFlowMeterTypeEnum.FLOWMETER)
			{
				return new IfcLabel(Enum.GetName(typeof(IfcAirTerminalTypeEnum), PredefinedType));
			}
			return (!base.ElementType.HasValue) ? ((IfcLabel)null) : new IfcLabel(base.ElementType.Value);
		}
		set
		{
			base.ElementType = (value.HasValue ? value.Value.ToString() : null);
			if (value.HasValue && Enum.TryParse<IfcFlowMeterTypeEnum>(value.Value.ToString(), ignoreCase: true, out var result))
			{
				PredefinedType = result;
			}
		}
	}

	internal IfcFlowMeterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFlowMeterTypeEnum)Enum.Parse(typeof(IfcFlowMeterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFlowMeterType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFlowMeterTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFlowMeterTypeClause.WR1)
			{
				result = PredefinedType != IfcFlowMeterTypeEnum.USERDEFINED || (PredefinedType == IfcFlowMeterTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFlowMeterType>()?.LogError($"Exception thrown evaluating where-clause 'IfcFlowMeterType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFlowMeterTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFlowMeterType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
