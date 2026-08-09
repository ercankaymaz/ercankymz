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

[ExpressType("IfcEvaporatorType", 513)]
public class IfcEvaporatorType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEvaporatorType>, IIfcEvaporatorType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcEvaporatorTypeClause
	{
		WR1
	}

	private IfcEvaporatorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcEvaporatorTypeEnum PredefinedType
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
			SetValue(delegate(IfcEvaporatorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcEvaporatorType), 10)]
	Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum IIfcEvaporatorType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE;
			case IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE;
			case IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE;
			case IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE;
			case IfcEvaporatorTypeEnum.SHELLANDCOIL:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.SHELLANDCOIL;
			case IfcEvaporatorTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.USERDEFINED;
			}
			case IfcEvaporatorTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSION:
				base.ElementType = value.ToString();
				PredefinedType = IfcEvaporatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.SHELLANDCOIL:
				PredefinedType = IfcEvaporatorTypeEnum.SHELLANDCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.USERDEFINED:
				PredefinedType = IfcEvaporatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcEvaporatorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcEvaporatorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEvaporatorTypeEnum)Enum.Parse(typeof(IfcEvaporatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvaporatorType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEvaporatorTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcEvaporatorTypeClause.WR1)
			{
				result = PredefinedType != IfcEvaporatorTypeEnum.USERDEFINED || (PredefinedType == IfcEvaporatorTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEvaporatorType>()?.LogError($"Exception thrown evaluating where-clause 'IfcEvaporatorType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcEvaporatorTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEvaporatorType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
