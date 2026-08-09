using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcLamp", 1198)]
public class IfcLamp : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLamp>, IIfcLamp, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcLampTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcLampTypeEnum? PredefinedType
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
			SetValue(delegate(IfcLampTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcLamp), 9)]
	Xbim.Ifc4.Interfaces.IfcLampTypeEnum? IIfcLamp.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcLampTypeEnum.COMPACTFLUORESCENT => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.COMPACTFLUORESCENT, 
				IfcLampTypeEnum.FLUORESCENT => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.FLUORESCENT, 
				IfcLampTypeEnum.HALOGEN => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HALOGEN, 
				IfcLampTypeEnum.HIGHPRESSUREMERCURY => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSUREMERCURY, 
				IfcLampTypeEnum.HIGHPRESSURESODIUM => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSURESODIUM, 
				IfcLampTypeEnum.LED => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.LED, 
				IfcLampTypeEnum.METALHALIDE => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.METALHALIDE, 
				IfcLampTypeEnum.OLED => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.OLED, 
				IfcLampTypeEnum.TUNGSTENFILAMENT => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.TUNGSTENFILAMENT, 
				IfcLampTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.USERDEFINED, 
				IfcLampTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLampTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.COMPACTFLUORESCENT:
				PredefinedType = IfcLampTypeEnum.COMPACTFLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.FLUORESCENT:
				PredefinedType = IfcLampTypeEnum.FLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HALOGEN:
				PredefinedType = IfcLampTypeEnum.HALOGEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSUREMERCURY:
				PredefinedType = IfcLampTypeEnum.HIGHPRESSUREMERCURY;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSURESODIUM:
				PredefinedType = IfcLampTypeEnum.HIGHPRESSURESODIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.LED:
				PredefinedType = IfcLampTypeEnum.LED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.METALHALIDE:
				PredefinedType = IfcLampTypeEnum.METALHALIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.OLED:
				PredefinedType = IfcLampTypeEnum.OLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.TUNGSTENFILAMENT:
				PredefinedType = IfcLampTypeEnum.TUNGSTENFILAMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.USERDEFINED:
				PredefinedType = IfcLampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.NOTDEFINED:
				PredefinedType = IfcLampTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLamp(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLampTypeEnum)Enum.Parse(typeof(IfcLampTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLamp other)
	{
		return this == other;
	}
}
