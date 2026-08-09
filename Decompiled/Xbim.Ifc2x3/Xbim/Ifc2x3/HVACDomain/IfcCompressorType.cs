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

[ExpressType("IfcCompressorType", 586)]
public class IfcCompressorType : IfcFlowMovingDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompressorType>, IIfcCompressorType, IIfcFlowMovingDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcCompressorTypeClause
	{
		WR1
	}

	private IfcCompressorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCompressorTypeEnum PredefinedType
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
			SetValue(delegate(IfcCompressorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCompressorType), 10)]
	Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum IIfcCompressorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCompressorTypeEnum.DYNAMIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.DYNAMIC, 
				IfcCompressorTypeEnum.RECIPROCATING => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.RECIPROCATING, 
				IfcCompressorTypeEnum.ROTARY => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARY, 
				IfcCompressorTypeEnum.SCROLL => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SCROLL, 
				IfcCompressorTypeEnum.TROCHOIDAL => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TROCHOIDAL, 
				IfcCompressorTypeEnum.SINGLESTAGE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESTAGE, 
				IfcCompressorTypeEnum.BOOSTER => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.BOOSTER, 
				IfcCompressorTypeEnum.OPENTYPE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.OPENTYPE, 
				IfcCompressorTypeEnum.HERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.HERMETIC, 
				IfcCompressorTypeEnum.SEMIHERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SEMIHERMETIC, 
				IfcCompressorTypeEnum.WELDEDSHELLHERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.WELDEDSHELLHERMETIC, 
				IfcCompressorTypeEnum.ROLLINGPISTON => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROLLINGPISTON, 
				IfcCompressorTypeEnum.ROTARYVANE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARYVANE, 
				IfcCompressorTypeEnum.SINGLESCREW => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESCREW, 
				IfcCompressorTypeEnum.TWINSCREW => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TWINSCREW, 
				IfcCompressorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.USERDEFINED, 
				IfcCompressorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.DYNAMIC:
				PredefinedType = IfcCompressorTypeEnum.DYNAMIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.RECIPROCATING:
				PredefinedType = IfcCompressorTypeEnum.RECIPROCATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARY:
				PredefinedType = IfcCompressorTypeEnum.ROTARY;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SCROLL:
				PredefinedType = IfcCompressorTypeEnum.SCROLL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TROCHOIDAL:
				PredefinedType = IfcCompressorTypeEnum.TROCHOIDAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESTAGE:
				PredefinedType = IfcCompressorTypeEnum.SINGLESTAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.BOOSTER:
				PredefinedType = IfcCompressorTypeEnum.BOOSTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.OPENTYPE:
				PredefinedType = IfcCompressorTypeEnum.OPENTYPE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.HERMETIC:
				PredefinedType = IfcCompressorTypeEnum.HERMETIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SEMIHERMETIC:
				PredefinedType = IfcCompressorTypeEnum.SEMIHERMETIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.WELDEDSHELLHERMETIC:
				PredefinedType = IfcCompressorTypeEnum.WELDEDSHELLHERMETIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROLLINGPISTON:
				PredefinedType = IfcCompressorTypeEnum.ROLLINGPISTON;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARYVANE:
				PredefinedType = IfcCompressorTypeEnum.ROTARYVANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESCREW:
				PredefinedType = IfcCompressorTypeEnum.SINGLESCREW;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TWINSCREW:
				PredefinedType = IfcCompressorTypeEnum.TWINSCREW;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.USERDEFINED:
				PredefinedType = IfcCompressorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.NOTDEFINED:
				PredefinedType = IfcCompressorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCompressorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCompressorTypeEnum)Enum.Parse(typeof(IfcCompressorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompressorType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCompressorTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCompressorTypeClause.WR1)
			{
				result = PredefinedType != IfcCompressorTypeEnum.USERDEFINED || (PredefinedType == IfcCompressorTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCompressorType>()?.LogError($"Exception thrown evaluating where-clause 'IfcCompressorType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCompressorTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompressorType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
