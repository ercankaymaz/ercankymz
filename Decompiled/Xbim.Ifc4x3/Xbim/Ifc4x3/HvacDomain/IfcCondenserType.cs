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

[ExpressType("IfcCondenserType", 297)]
public class IfcCondenserType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCondenserType>, IIfcCondenserType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcCondenserTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCondenserTypeEnum PredefinedType
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
			SetValue(delegate(IfcCondenserTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCondenserType), 10)]
	Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum IIfcCondenserType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCondenserTypeEnum.AIRCOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED, 
				IfcCondenserTypeEnum.EVAPORATIVECOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED, 
				IfcCondenserTypeEnum.WATERCOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLED, 
				IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE, 
				IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL, 
				IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE, 
				IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE, 
				IfcCondenserTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED, 
				IfcCondenserTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED:
				PredefinedType = IfcCondenserTypeEnum.AIRCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED:
				PredefinedType = IfcCondenserTypeEnum.EVAPORATIVECOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLED:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED:
				PredefinedType = IfcCondenserTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED:
				PredefinedType = IfcCondenserTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCondenserType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCondenserTypeEnum)Enum.Parse(typeof(IfcCondenserTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCondenserType other)
	{
		return this == other;
	}
}
