using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcAirTerminal", 1095)]
public class IfcAirTerminal : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAirTerminal>, IIfcAirTerminal, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcAirTerminalTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcAirTerminalTypeEnum? PredefinedType
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
			SetValue(delegate(IfcAirTerminalTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcAirTerminal), 9)]
	Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum? IIfcAirTerminal.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAirTerminalTypeEnum.DIFFUSER => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.DIFFUSER, 
				IfcAirTerminalTypeEnum.GRILLE => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.GRILLE, 
				IfcAirTerminalTypeEnum.LOUVRE => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.LOUVRE, 
				IfcAirTerminalTypeEnum.REGISTER => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.REGISTER, 
				IfcAirTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.USERDEFINED, 
				IfcAirTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.DIFFUSER:
				PredefinedType = IfcAirTerminalTypeEnum.DIFFUSER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.GRILLE:
				PredefinedType = IfcAirTerminalTypeEnum.GRILLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.LOUVRE:
				PredefinedType = IfcAirTerminalTypeEnum.LOUVRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.REGISTER:
				PredefinedType = IfcAirTerminalTypeEnum.REGISTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcAirTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcAirTerminalTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAirTerminal(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAirTerminalTypeEnum)Enum.Parse(typeof(IfcAirTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAirTerminal other)
	{
		return this == other;
	}
}
