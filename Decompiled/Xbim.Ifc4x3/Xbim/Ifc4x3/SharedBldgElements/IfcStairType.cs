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

[ExpressType("IfcStairType", 1278)]
public class IfcStairType : IfcBuiltElementType, IIfcStairType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStairType>
{
	private IfcStairTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStairType), 10)]
	Xbim.Ifc4.Interfaces.IfcStairTypeEnum IIfcStairType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStairTypeEnum.CURVED_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.CURVED_RUN_STAIR, 
				IfcStairTypeEnum.DOUBLE_RETURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.DOUBLE_RETURN_STAIR, 
				IfcStairTypeEnum.HALF_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_TURN_STAIR, 
				IfcStairTypeEnum.HALF_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_WINDING_STAIR, 
				IfcStairTypeEnum.LADDER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcStairTypeEnum>(), 
				IfcStairTypeEnum.QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.SPIRAL_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.SPIRAL_STAIR, 
				IfcStairTypeEnum.STRAIGHT_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.STRAIGHT_RUN_STAIR, 
				IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.TWO_CURVED_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_CURVED_RUN_STAIR, 
				IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR, 
				IfcStairTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.USERDEFINED, 
				IfcStairTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.STRAIGHT_RUN_STAIR:
				PredefinedType = IfcStairTypeEnum.STRAIGHT_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR:
				PredefinedType = IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_WINDING_STAIR:
				PredefinedType = IfcStairTypeEnum.QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_TURN_STAIR:
				PredefinedType = IfcStairTypeEnum.QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_WINDING_STAIR:
				PredefinedType = IfcStairTypeEnum.HALF_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_TURN_STAIR:
				PredefinedType = IfcStairTypeEnum.HALF_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR:
				PredefinedType = IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR:
				PredefinedType = IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR:
				PredefinedType = IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR:
				PredefinedType = IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.SPIRAL_STAIR:
				PredefinedType = IfcStairTypeEnum.SPIRAL_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.DOUBLE_RETURN_STAIR:
				PredefinedType = IfcStairTypeEnum.DOUBLE_RETURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.CURVED_RUN_STAIR:
				PredefinedType = IfcStairTypeEnum.CURVED_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_CURVED_RUN_STAIR:
				PredefinedType = IfcStairTypeEnum.TWO_CURVED_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.USERDEFINED:
				PredefinedType = IfcStairTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.NOTDEFINED:
				PredefinedType = IfcStairTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcStairTypeEnum PredefinedType
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
			SetValue(delegate(IfcStairTypeEnum v)
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

	internal IfcStairType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStairTypeEnum)Enum.Parse(typeof(IfcStairTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStairType other)
	{
		return this == other;
	}
}
