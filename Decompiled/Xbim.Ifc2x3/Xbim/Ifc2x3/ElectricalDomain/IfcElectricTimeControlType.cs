using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcElectricTimeControlType", 273)]
public class IfcElectricTimeControlType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricTimeControlType>, IIfcElectricTimeControlType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcElectricTimeControlTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcElectricTimeControlTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricTimeControlTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcElectricTimeControlType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum IIfcElectricTimeControlType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricTimeControlTypeEnum.TIMECLOCK => Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.TIMECLOCK, 
				IfcElectricTimeControlTypeEnum.TIMEDELAY => Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.TIMEDELAY, 
				IfcElectricTimeControlTypeEnum.RELAY => Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.RELAY, 
				IfcElectricTimeControlTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.USERDEFINED, 
				IfcElectricTimeControlTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.TIMECLOCK:
				PredefinedType = IfcElectricTimeControlTypeEnum.TIMECLOCK;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.TIMEDELAY:
				PredefinedType = IfcElectricTimeControlTypeEnum.TIMEDELAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.RELAY:
				PredefinedType = IfcElectricTimeControlTypeEnum.RELAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricTimeControlTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricTimeControlTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricTimeControlTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricTimeControlType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricTimeControlTypeEnum)Enum.Parse(typeof(IfcElectricTimeControlTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricTimeControlType other)
	{
		return this == other;
	}
}
