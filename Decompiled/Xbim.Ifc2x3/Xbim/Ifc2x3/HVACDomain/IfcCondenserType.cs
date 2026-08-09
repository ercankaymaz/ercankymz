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

[ExpressType("IfcCondenserType", 297)]
public class IfcCondenserType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCondenserType>, IIfcCondenserType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcCondenserTypeClause
	{
		WR1
	}

	private IfcCondenserTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCondenserTypeEnum PredefinedType
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
			SetValue(delegate(IfcCondenserTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCondenserType), 10)]
	Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum IIfcCondenserType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE;
			case IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL;
			case IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE;
			case IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE;
			case IfcCondenserTypeEnum.AIRCOOLED:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED;
			case IfcCondenserTypeEnum.EVAPORATIVECOOLED:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED;
			case IfcCondenserTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED;
			}
			case IfcCondenserTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED:
				PredefinedType = IfcCondenserTypeEnum.AIRCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED:
				PredefinedType = IfcCondenserTypeEnum.EVAPORATIVECOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLED:
				base.ElementType = value.ToString();
				PredefinedType = IfcCondenserTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED:
				PredefinedType = IfcCondenserTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED:
				PredefinedType = IfcCondenserTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCondenserType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCondenserTypeEnum)Enum.Parse(typeof(IfcCondenserTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCondenserType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCondenserTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCondenserTypeClause.WR1)
			{
				result = PredefinedType != IfcCondenserTypeEnum.USERDEFINED || (PredefinedType == IfcCondenserTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCondenserType>()?.LogError($"Exception thrown evaluating where-clause 'IfcCondenserType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCondenserTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCondenserType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
