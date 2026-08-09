using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcStackTerminal", 1277)]
public class IfcStackTerminal : IfcFlowTerminal, IIfcStackTerminal, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStackTerminal>
{
	private IfcStackTerminalTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStackTerminal), 9)]
	Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum? IIfcStackTerminal.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStackTerminalTypeEnum.BIRDCAGE => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.BIRDCAGE, 
				IfcStackTerminalTypeEnum.COWL => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.COWL, 
				IfcStackTerminalTypeEnum.RAINWATERHOPPER => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.RAINWATERHOPPER, 
				IfcStackTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.USERDEFINED, 
				IfcStackTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.BIRDCAGE:
				PredefinedType = IfcStackTerminalTypeEnum.BIRDCAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.COWL:
				PredefinedType = IfcStackTerminalTypeEnum.COWL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.RAINWATERHOPPER:
				PredefinedType = IfcStackTerminalTypeEnum.RAINWATERHOPPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcStackTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcStackTerminalTypeEnum.NOTDEFINED;
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
	public IfcStackTerminalTypeEnum? PredefinedType
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
			SetValue(delegate(IfcStackTerminalTypeEnum? v)
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

	internal IfcStackTerminal(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStackTerminalTypeEnum)Enum.Parse(typeof(IfcStackTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStackTerminal other)
	{
		return this == other;
	}
}
