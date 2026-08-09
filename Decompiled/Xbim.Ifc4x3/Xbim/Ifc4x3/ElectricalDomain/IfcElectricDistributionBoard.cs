using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricDistributionBoard", 1157)]
public class IfcElectricDistributionBoard : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricDistributionBoard>, IIfcElectricDistributionBoard, IIfcFlowController, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcElectricDistributionBoardTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcElectricDistributionBoardTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElectricDistributionBoardTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricDistributionBoard), 9)]
	Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum? IIfcElectricDistributionBoard.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricDistributionBoardTypeEnum.CONSUMERUNIT => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.CONSUMERUNIT, 
				IfcElectricDistributionBoardTypeEnum.DISTRIBUTIONBOARD => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.DISTRIBUTIONBOARD, 
				IfcElectricDistributionBoardTypeEnum.MOTORCONTROLCENTRE => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.MOTORCONTROLCENTRE, 
				IfcElectricDistributionBoardTypeEnum.SWITCHBOARD => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.SWITCHBOARD, 
				IfcElectricDistributionBoardTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.USERDEFINED, 
				IfcElectricDistributionBoardTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.CONSUMERUNIT:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.CONSUMERUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.DISTRIBUTIONBOARD:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.DISTRIBUTIONBOARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.MOTORCONTROLCENTRE:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.MOTORCONTROLCENTRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.SWITCHBOARD:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.SWITCHBOARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricDistributionBoardTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricDistributionBoard(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricDistributionBoardTypeEnum)Enum.Parse(typeof(IfcElectricDistributionBoardTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricDistributionBoard other)
	{
		return this == other;
	}
}
