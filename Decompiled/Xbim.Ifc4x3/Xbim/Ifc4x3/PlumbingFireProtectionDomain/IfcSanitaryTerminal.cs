using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcSanitaryTerminal", 1262)]
public class IfcSanitaryTerminal : IfcFlowTerminal, IIfcSanitaryTerminal, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSanitaryTerminal>
{
	private IfcSanitaryTerminalTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSanitaryTerminal), 9)]
	Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum? IIfcSanitaryTerminal.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSanitaryTerminalTypeEnum.BATH => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.BATH, 
				IfcSanitaryTerminalTypeEnum.BIDET => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.BIDET, 
				IfcSanitaryTerminalTypeEnum.CISTERN => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.CISTERN, 
				IfcSanitaryTerminalTypeEnum.SANITARYFOUNTAIN => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SANITARYFOUNTAIN, 
				IfcSanitaryTerminalTypeEnum.SHOWER => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SHOWER, 
				IfcSanitaryTerminalTypeEnum.SINK => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SINK, 
				IfcSanitaryTerminalTypeEnum.TOILETPAN => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.TOILETPAN, 
				IfcSanitaryTerminalTypeEnum.URINAL => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.URINAL, 
				IfcSanitaryTerminalTypeEnum.WASHHANDBASIN => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.WASHHANDBASIN, 
				IfcSanitaryTerminalTypeEnum.WCSEAT => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.WCSEAT, 
				IfcSanitaryTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.USERDEFINED, 
				IfcSanitaryTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.BATH:
				PredefinedType = IfcSanitaryTerminalTypeEnum.BATH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.BIDET:
				PredefinedType = IfcSanitaryTerminalTypeEnum.BIDET;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.CISTERN:
				PredefinedType = IfcSanitaryTerminalTypeEnum.CISTERN;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SHOWER:
				PredefinedType = IfcSanitaryTerminalTypeEnum.SHOWER;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SINK:
				PredefinedType = IfcSanitaryTerminalTypeEnum.SINK;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.SANITARYFOUNTAIN:
				PredefinedType = IfcSanitaryTerminalTypeEnum.SANITARYFOUNTAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.TOILETPAN:
				PredefinedType = IfcSanitaryTerminalTypeEnum.TOILETPAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.URINAL:
				PredefinedType = IfcSanitaryTerminalTypeEnum.URINAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.WASHHANDBASIN:
				PredefinedType = IfcSanitaryTerminalTypeEnum.WASHHANDBASIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.WCSEAT:
				PredefinedType = IfcSanitaryTerminalTypeEnum.WCSEAT;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcSanitaryTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcSanitaryTerminalTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcSanitaryTerminalTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSanitaryTerminalTypeEnum? v)
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

	internal IfcSanitaryTerminal(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSanitaryTerminalTypeEnum)Enum.Parse(typeof(IfcSanitaryTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSanitaryTerminal other)
	{
		return this == other;
	}
}
