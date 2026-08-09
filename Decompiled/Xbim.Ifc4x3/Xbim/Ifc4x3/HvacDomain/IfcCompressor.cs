using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCompressor", 1131)]
public class IfcCompressor : IfcFlowMovingDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompressor>, IIfcCompressor, IIfcFlowMovingDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCompressorTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCompressorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCompressorTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCompressor), 9)]
	Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum? IIfcCompressor.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCompressorTypeEnum.BOOSTER => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.BOOSTER, 
				IfcCompressorTypeEnum.DYNAMIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.DYNAMIC, 
				IfcCompressorTypeEnum.HERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.HERMETIC, 
				IfcCompressorTypeEnum.OPENTYPE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.OPENTYPE, 
				IfcCompressorTypeEnum.RECIPROCATING => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.RECIPROCATING, 
				IfcCompressorTypeEnum.ROLLINGPISTON => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROLLINGPISTON, 
				IfcCompressorTypeEnum.ROTARY => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARY, 
				IfcCompressorTypeEnum.ROTARYVANE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.ROTARYVANE, 
				IfcCompressorTypeEnum.SCROLL => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SCROLL, 
				IfcCompressorTypeEnum.SEMIHERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SEMIHERMETIC, 
				IfcCompressorTypeEnum.SINGLESCREW => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESCREW, 
				IfcCompressorTypeEnum.SINGLESTAGE => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.SINGLESTAGE, 
				IfcCompressorTypeEnum.TROCHOIDAL => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TROCHOIDAL, 
				IfcCompressorTypeEnum.TWINSCREW => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.TWINSCREW, 
				IfcCompressorTypeEnum.WELDEDSHELLHERMETIC => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.WELDEDSHELLHERMETIC, 
				IfcCompressorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.USERDEFINED, 
				IfcCompressorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCompressorTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCompressor(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCompressorTypeEnum)Enum.Parse(typeof(IfcCompressorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompressor other)
	{
		return this == other;
	}
}
