using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcWasteTerminal", 1315)]
public class IfcWasteTerminal : IfcFlowTerminal, IIfcWasteTerminal, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWasteTerminal>
{
	private IfcWasteTerminalTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWasteTerminal), 9)]
	Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum? IIfcWasteTerminal.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWasteTerminalTypeEnum.FLOORTRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORTRAP, 
				IfcWasteTerminalTypeEnum.FLOORWASTE => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORWASTE, 
				IfcWasteTerminalTypeEnum.GULLYSUMP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYSUMP, 
				IfcWasteTerminalTypeEnum.GULLYTRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYTRAP, 
				IfcWasteTerminalTypeEnum.ROOFDRAIN => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.ROOFDRAIN, 
				IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT, 
				IfcWasteTerminalTypeEnum.WASTETRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTETRAP, 
				IfcWasteTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED, 
				IfcWasteTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORTRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.FLOORTRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORWASTE:
				PredefinedType = IfcWasteTerminalTypeEnum.FLOORWASTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYSUMP:
				PredefinedType = IfcWasteTerminalTypeEnum.GULLYSUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYTRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.GULLYTRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.ROOFDRAIN:
				PredefinedType = IfcWasteTerminalTypeEnum.ROOFDRAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT:
				PredefinedType = IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTETRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.WASTETRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcWasteTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcWasteTerminalTypeEnum.NOTDEFINED;
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
	public IfcWasteTerminalTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWasteTerminalTypeEnum? v)
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

	internal IfcWasteTerminal(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWasteTerminalTypeEnum)Enum.Parse(typeof(IfcWasteTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWasteTerminal other)
	{
		return this == other;
	}
}
