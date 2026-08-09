using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcTankType", 619)]
public class IfcTankType : IfcFlowStorageDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTankType>, IIfcTankType, IIfcFlowStorageDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcTankTypeClause
	{
		WR1
	}

	private IfcTankTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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

	[CrossSchemaAttribute(typeof(IIfcTankType), 10)]
	Xbim.Ifc4.Interfaces.IfcTankTypeEnum IIfcTankType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcTankTypeEnum.PREFORMED:
				return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED;
			case IfcTankTypeEnum.SECTIONAL:
				return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED;
			case IfcTankTypeEnum.EXPANSION:
				return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.EXPANSION;
			case IfcTankTypeEnum.PRESSUREVESSEL:
				return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.PRESSUREVESSEL;
			case IfcTankTypeEnum.USERDEFINED:
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel ifcLabel = base.ElementType ?? ((Xbim.Ifc2x3.MeasureResource.IfcLabel)"");
				switch (ifcLabel)
				{
				case "BASIN":
				case "BREAKPRESSURE":
				case "FEEDANDEXPANSION":
				case "STORAGE":
				case "VESSEL":
					return (Xbim.Ifc4.Interfaces.IfcTankTypeEnum)Enum.Parse(typeof(Xbim.Ifc4.Interfaces.IfcTankTypeEnum), ifcLabel);
				default:
					return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED;
				}
			}
			case IfcTankTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcTankTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BASIN:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				base.ElementType = "BASIN";
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.BREAKPRESSURE:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				base.ElementType = "BREAKPRESSURE";
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.EXPANSION:
				PredefinedType = IfcTankTypeEnum.EXPANSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.FEEDANDEXPANSION:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				base.ElementType = "FEEDANDEXPANSION";
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.PRESSUREVESSEL:
				PredefinedType = IfcTankTypeEnum.PRESSUREVESSEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.STORAGE:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				base.ElementType = "STORAGE";
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.VESSEL:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				base.ElementType = "VESSEL";
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.USERDEFINED:
				PredefinedType = IfcTankTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTankTypeEnum.NOTDEFINED:
				PredefinedType = IfcTankTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			if (PredefinedType == IfcTankTypeEnum.SECTIONAL)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel("SECTIONAL");
			}
			if (PredefinedType == IfcTankTypeEnum.PREFORMED)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel("PREFORMED");
			}
			Xbim.Ifc4.MeasureResource.IfcLabel value;
			if (!base.ElementType.HasValue)
			{
				value = null;
			}
			else
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel? elementType = base.ElementType;
				value = new Xbim.Ifc4.MeasureResource.IfcLabel(elementType.HasValue ? ((string)elementType.GetValueOrDefault()) : null);
			}
			return value;
		}
		set
		{
			base.ElementType = (value.HasValue ? value.Value.ToString() : null);
			if (value.HasValue && Enum.TryParse<IfcTankTypeEnum>(value.Value.ToString(), ignoreCase: true, out var result))
			{
				PredefinedType = result;
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
			if (clause == IfcTankTypeClause.WR1)
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
		if (!ValidateClause(IfcTankTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTankType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
