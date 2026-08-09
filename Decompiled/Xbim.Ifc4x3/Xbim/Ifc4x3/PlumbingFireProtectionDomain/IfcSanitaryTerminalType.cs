using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcSanitaryTerminalType", 435)]
public class IfcSanitaryTerminalType : IfcFlowTerminalType, IIfcSanitaryTerminalType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSanitaryTerminalType>
{
	private IfcSanitaryTerminalTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSanitaryTerminalType), 10)]
	Xbim.Ifc4.Interfaces.IfcSanitaryTerminalTypeEnum IIfcSanitaryTerminalType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSanitaryTerminalTypeEnum PredefinedType
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
			SetValue(delegate(IfcSanitaryTerminalTypeEnum v)
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

	internal IfcSanitaryTerminalType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSanitaryTerminalTypeEnum)Enum.Parse(typeof(IfcSanitaryTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSanitaryTerminalType other)
	{
		return this == other;
	}
}
