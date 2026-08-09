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

[ExpressType("IfcDuctFittingType", 686)]
public class IfcDuctFittingType : IfcFlowFittingType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctFittingType>, IIfcDuctFittingType, IIfcFlowFittingType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcDuctFittingTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDuctFittingTypeEnum PredefinedType
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
			SetValue(delegate(IfcDuctFittingTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcDuctFittingType), 10)]
	Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum IIfcDuctFittingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctFittingTypeEnum.BEND => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.BEND, 
				IfcDuctFittingTypeEnum.CONNECTOR => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.CONNECTOR, 
				IfcDuctFittingTypeEnum.ENTRY => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.ENTRY, 
				IfcDuctFittingTypeEnum.EXIT => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.EXIT, 
				IfcDuctFittingTypeEnum.JUNCTION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.JUNCTION, 
				IfcDuctFittingTypeEnum.OBSTRUCTION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.OBSTRUCTION, 
				IfcDuctFittingTypeEnum.TRANSITION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.TRANSITION, 
				IfcDuctFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.USERDEFINED, 
				IfcDuctFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.BEND:
				PredefinedType = IfcDuctFittingTypeEnum.BEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.CONNECTOR:
				PredefinedType = IfcDuctFittingTypeEnum.CONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.ENTRY:
				PredefinedType = IfcDuctFittingTypeEnum.ENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.EXIT:
				PredefinedType = IfcDuctFittingTypeEnum.EXIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.JUNCTION:
				PredefinedType = IfcDuctFittingTypeEnum.JUNCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.OBSTRUCTION:
				PredefinedType = IfcDuctFittingTypeEnum.OBSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.TRANSITION:
				PredefinedType = IfcDuctFittingTypeEnum.TRANSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcDuctFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcDuctFittingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctFittingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctFittingTypeEnum)Enum.Parse(typeof(IfcDuctFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctFittingType other)
	{
		return this == other;
	}
}
