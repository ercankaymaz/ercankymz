using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricDistributionBoardType", 1158)]
public class IfcElectricDistributionBoardType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricDistributionBoardType>, IIfcElectricDistributionBoardType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcElectricDistributionBoardTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcElectricDistributionBoardTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricDistributionBoardTypeEnum v)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcElectricDistributionBoardType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricDistributionBoardTypeEnum IIfcElectricDistributionBoardType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricDistributionBoardType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricDistributionBoardTypeEnum)Enum.Parse(typeof(IfcElectricDistributionBoardTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricDistributionBoardType other)
	{
		return this == other;
	}
}
