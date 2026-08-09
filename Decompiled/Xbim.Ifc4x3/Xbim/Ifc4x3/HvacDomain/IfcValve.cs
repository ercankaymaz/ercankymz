using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcValve", 1311)]
public class IfcValve : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcValve>, IIfcValve, IIfcFlowController, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcValveTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcValveTypeEnum? PredefinedType
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
			SetValue(delegate(IfcValveTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcValve), 9)]
	Xbim.Ifc4.Interfaces.IfcValveTypeEnum? IIfcValve.PredefinedType
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
				IfcValveTypeEnum.DOUBLECHECK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLECHECK, 
				IfcValveTypeEnum.DOUBLEREGULATING => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DOUBLEREGULATING, 
				IfcValveTypeEnum.DRAWOFFCOCK => Xbim.Ifc4.Interfaces.IfcValveTypeEnum.DRAWOFFCOCK, 
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcValve(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcValveTypeEnum)Enum.Parse(typeof(IfcValveTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcValve other)
	{
		return this == other;
	}
}
