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

[ExpressType("IfcEvaporatorType", 513)]
public class IfcEvaporatorType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEvaporatorType>, IIfcEvaporatorType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcEvaporatorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcEvaporatorTypeEnum PredefinedType
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
			SetValue(delegate(IfcEvaporatorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcEvaporatorType), 10)]
	Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum IIfcEvaporatorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcEvaporatorTypeEnum.DIRECTEXPANSION => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSION, 
				IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE, 
				IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE, 
				IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE, 
				IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE, 
				IfcEvaporatorTypeEnum.SHELLANDCOIL => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.SHELLANDCOIL, 
				IfcEvaporatorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.USERDEFINED, 
				IfcEvaporatorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSION:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONSHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONTUBEINTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE:
				PredefinedType = IfcEvaporatorTypeEnum.DIRECTEXPANSIONBRAZEDPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE:
				PredefinedType = IfcEvaporatorTypeEnum.FLOODEDSHELLANDTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.SHELLANDCOIL:
				PredefinedType = IfcEvaporatorTypeEnum.SHELLANDCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.USERDEFINED:
				PredefinedType = IfcEvaporatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcEvaporatorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcEvaporatorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEvaporatorTypeEnum)Enum.Parse(typeof(IfcEvaporatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvaporatorType other)
	{
		return this == other;
	}
}
