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

[ExpressType("IfcValveType", 465)]
public class IfcValveType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcValveType>, IIfcValveType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcValveTypeClause
	{
		WR1
	}

	private IfcValveTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcValveTypeEnum PredefinedType
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
			SetValue(delegate(IfcValveTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcValveType), 10)]
	Xbim.Ifc4.Interfaces.IfcValveTypeEnum IIfcValveType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcValveTypeEnum.AIRRELEASE => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.AIRRELEASE, 
				IfcValveTypeEnum.ANTIVACUUM => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.ANTIVACUUM, 
				IfcValveTypeEnum.CHANGEOVER => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.CHANGEOVER, 
				IfcValveTypeEnum.CHECK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.CHECK, 
				IfcValveTypeEnum.COMMISSIONING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.COMMISSIONING, 
				IfcValveTypeEnum.DIVERTING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DIVERTING, 
				IfcValveTypeEnum.DRAWOFFCOCK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DRAWOFFCOCK, 
				IfcValveTypeEnum.DOUBLECHECK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLECHECK, 
				IfcValveTypeEnum.DOUBLEREGULATING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLEREGULATING, 
				IfcValveTypeEnum.FAUCET => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.FAUCET, 
				IfcValveTypeEnum.FLUSHING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.FLUSHING, 
				IfcValveTypeEnum.GASCOCK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.GASCOCK, 
				IfcValveTypeEnum.GASTAP => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.GASTAP, 
				IfcValveTypeEnum.ISOLATING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.ISOLATING, 
				IfcValveTypeEnum.MIXING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.MIXING, 
				IfcValveTypeEnum.PRESSUREREDUCING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.PRESSUREREDUCING, 
				IfcValveTypeEnum.PRESSURERELIEF => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.PRESSURERELIEF, 
				IfcValveTypeEnum.REGULATING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.REGULATING, 
				IfcValveTypeEnum.SAFETYCUTOFF => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.SAFETYCUTOFF, 
				IfcValveTypeEnum.STEAMTRAP => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.STEAMTRAP, 
				IfcValveTypeEnum.STOPCOCK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.STOPCOCK, 
				IfcValveTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.USERDEFINED, 
				IfcValveTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.AIRRELEASE:
				PredefinedType = IfcValveTypeEnum.AIRRELEASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.ANTIVACUUM:
				PredefinedType = IfcValveTypeEnum.ANTIVACUUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.CHANGEOVER:
				PredefinedType = IfcValveTypeEnum.CHANGEOVER;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.CHECK:
				PredefinedType = IfcValveTypeEnum.CHECK;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.COMMISSIONING:
				PredefinedType = IfcValveTypeEnum.COMMISSIONING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DIVERTING:
				PredefinedType = IfcValveTypeEnum.DIVERTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DRAWOFFCOCK:
				PredefinedType = IfcValveTypeEnum.DRAWOFFCOCK;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLECHECK:
				PredefinedType = IfcValveTypeEnum.DOUBLECHECK;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLEREGULATING:
				PredefinedType = IfcValveTypeEnum.DOUBLEREGULATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.FAUCET:
				PredefinedType = IfcValveTypeEnum.FAUCET;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.FLUSHING:
				PredefinedType = IfcValveTypeEnum.FLUSHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.GASCOCK:
				PredefinedType = IfcValveTypeEnum.GASCOCK;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.GASTAP:
				PredefinedType = IfcValveTypeEnum.GASTAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.ISOLATING:
				PredefinedType = IfcValveTypeEnum.ISOLATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.MIXING:
				PredefinedType = IfcValveTypeEnum.MIXING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.PRESSUREREDUCING:
				PredefinedType = IfcValveTypeEnum.PRESSUREREDUCING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.PRESSURERELIEF:
				PredefinedType = IfcValveTypeEnum.PRESSURERELIEF;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.REGULATING:
				PredefinedType = IfcValveTypeEnum.REGULATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.SAFETYCUTOFF:
				PredefinedType = IfcValveTypeEnum.SAFETYCUTOFF;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.STEAMTRAP:
				PredefinedType = IfcValveTypeEnum.STEAMTRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.STOPCOCK:
				PredefinedType = IfcValveTypeEnum.STOPCOCK;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.USERDEFINED:
				PredefinedType = IfcValveTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcValveTypeEnum.NOTDEFINED:
				PredefinedType = IfcValveTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcValveType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcValveTypeEnum)Enum.Parse(typeof(IfcValveTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcValveType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcValveTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcValveTypeClause.WR1)
			{
				result = PredefinedType != IfcValveTypeEnum.USERDEFINED || (PredefinedType == IfcValveTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcValveType>()?.LogError($"Exception thrown evaluating where-clause 'IfcValveType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcValveTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcValveType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
