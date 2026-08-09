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

[ExpressType("IfcCableFittingType", 1114)]
public class IfcCableFittingType : IfcFlowFittingType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableFittingType>, IIfcCableFittingType, IIfcFlowFittingType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcCableFittingTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCableFittingTypeEnum PredefinedType
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
			SetValue(delegate(IfcCableFittingTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCableFittingType), 10)]
	Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum IIfcCableFittingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCableFittingTypeEnum.CONNECTOR => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.CONNECTOR, 
				IfcCableFittingTypeEnum.ENTRY => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.ENTRY, 
				IfcCableFittingTypeEnum.EXIT => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.EXIT, 
				IfcCableFittingTypeEnum.FANOUT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum>(), 
				IfcCableFittingTypeEnum.JUNCTION => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.JUNCTION, 
				IfcCableFittingTypeEnum.TRANSITION => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.TRANSITION, 
				IfcCableFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.USERDEFINED, 
				IfcCableFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.CONNECTOR:
				PredefinedType = IfcCableFittingTypeEnum.CONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.ENTRY:
				PredefinedType = IfcCableFittingTypeEnum.ENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.EXIT:
				PredefinedType = IfcCableFittingTypeEnum.EXIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.JUNCTION:
				PredefinedType = IfcCableFittingTypeEnum.JUNCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.TRANSITION:
				PredefinedType = IfcCableFittingTypeEnum.TRANSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcCableFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcCableFittingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableFittingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableFittingTypeEnum)Enum.Parse(typeof(IfcCableFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableFittingType other)
	{
		return this == other;
	}
}
