using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCoilType", 622)]
public class IfcCoilType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoilType>, IIfcCoilType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcCoilTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCoilTypeEnum PredefinedType
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
			SetValue(delegate(IfcCoilTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCoilType), 10)]
	Xbim.Ifc4.Interfaces.IfcCoilTypeEnum IIfcCoilType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoilTypeEnum.DXCOOLINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL, 
				IfcCoilTypeEnum.ELECTRICHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL, 
				IfcCoilTypeEnum.GASHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL, 
				IfcCoilTypeEnum.HYDRONICCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.HYDRONICCOIL, 
				IfcCoilTypeEnum.STEAMHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL, 
				IfcCoilTypeEnum.WATERCOOLINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL, 
				IfcCoilTypeEnum.WATERHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL, 
				IfcCoilTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED, 
				IfcCoilTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.DXCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.ELECTRICHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.GASHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.HYDRONICCOIL:
				PredefinedType = IfcCoilTypeEnum.HYDRONICCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.STEAMHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED:
				PredefinedType = IfcCoilTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoilTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCoilType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoilTypeEnum)Enum.Parse(typeof(IfcCoilTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoilType other)
	{
		return this == other;
	}
}
