using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcPileType", 1221)]
public class IfcPileType : IfcDeepFoundationType, IIfcPileType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPileType>
{
	private IfcPileTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcPileType), 10)]
	Xbim.Ifc4.Interfaces.IfcPileTypeEnum IIfcPileType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPileTypeEnum.BORED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.BORED, 
				IfcPileTypeEnum.COHESION => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.COHESION, 
				IfcPileTypeEnum.DRIVEN => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.DRIVEN, 
				IfcPileTypeEnum.FRICTION => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.FRICTION, 
				IfcPileTypeEnum.JETGROUTING => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.JETGROUTING, 
				IfcPileTypeEnum.SUPPORT => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.SUPPORT, 
				IfcPileTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.USERDEFINED, 
				IfcPileTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.BORED:
				PredefinedType = IfcPileTypeEnum.BORED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.DRIVEN:
				PredefinedType = IfcPileTypeEnum.DRIVEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.JETGROUTING:
				PredefinedType = IfcPileTypeEnum.JETGROUTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.COHESION:
				PredefinedType = IfcPileTypeEnum.COHESION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.FRICTION:
				PredefinedType = IfcPileTypeEnum.FRICTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.SUPPORT:
				PredefinedType = IfcPileTypeEnum.SUPPORT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.USERDEFINED:
				PredefinedType = IfcPileTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.NOTDEFINED:
				PredefinedType = IfcPileTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcPileTypeEnum PredefinedType
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
			SetValue(delegate(IfcPileTypeEnum v)
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

	internal IfcPileType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPileTypeEnum)Enum.Parse(typeof(IfcPileTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPileType other)
	{
		return this == other;
	}
}
