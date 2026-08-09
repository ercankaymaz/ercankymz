using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcSlabType", 381)]
public class IfcSlabType : IfcBuiltElementType, IIfcSlabType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSlabType>
{
	private IfcSlabTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSlabType), 10)]
	Xbim.Ifc4.Interfaces.IfcSlabTypeEnum IIfcSlabType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSlabTypeEnum.APPROACH_SLAB => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSlabTypeEnum>(), 
				IfcSlabTypeEnum.BASESLAB => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.BASESLAB, 
				IfcSlabTypeEnum.FLOOR => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.FLOOR, 
				IfcSlabTypeEnum.LANDING => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.LANDING, 
				IfcSlabTypeEnum.PAVING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSlabTypeEnum>(), 
				IfcSlabTypeEnum.ROOF => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.ROOF, 
				IfcSlabTypeEnum.SIDEWALK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSlabTypeEnum>(), 
				IfcSlabTypeEnum.TRACKSLAB => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSlabTypeEnum>(), 
				IfcSlabTypeEnum.WEARING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSlabTypeEnum>(), 
				IfcSlabTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.USERDEFINED, 
				IfcSlabTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.FLOOR:
				PredefinedType = IfcSlabTypeEnum.FLOOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.ROOF:
				PredefinedType = IfcSlabTypeEnum.ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.LANDING:
				PredefinedType = IfcSlabTypeEnum.LANDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.BASESLAB:
				PredefinedType = IfcSlabTypeEnum.BASESLAB;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.USERDEFINED:
				PredefinedType = IfcSlabTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.NOTDEFINED:
				PredefinedType = IfcSlabTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSlabTypeEnum PredefinedType
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
			SetValue(delegate(IfcSlabTypeEnum v)
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

	internal IfcSlabType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSlabTypeEnum)Enum.Parse(typeof(IfcSlabTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSlabType other)
	{
		return this == other;
	}
}
