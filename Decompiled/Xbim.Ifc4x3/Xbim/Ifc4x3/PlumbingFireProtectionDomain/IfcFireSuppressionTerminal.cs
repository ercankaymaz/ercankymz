using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcFireSuppressionTerminal", 1179)]
public class IfcFireSuppressionTerminal : IfcFlowTerminal, IIfcFireSuppressionTerminal, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFireSuppressionTerminal>
{
	private IfcFireSuppressionTerminalTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFireSuppressionTerminal), 9)]
	Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum? IIfcFireSuppressionTerminal.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET, 
				IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT, 
				IfcFireSuppressionTerminalTypeEnum.FIREMONITOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum>(), 
				IfcFireSuppressionTerminalTypeEnum.HOSEREEL => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL, 
				IfcFireSuppressionTerminalTypeEnum.SPRINKLER => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER, 
				IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR, 
				IfcFireSuppressionTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED, 
				IfcFireSuppressionTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.HOSEREEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.NOTDEFINED;
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
	public IfcFireSuppressionTerminalTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFireSuppressionTerminalTypeEnum? v)
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

	internal IfcFireSuppressionTerminal(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFireSuppressionTerminalTypeEnum)Enum.Parse(typeof(IfcFireSuppressionTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFireSuppressionTerminal other)
	{
		return this == other;
	}
}
