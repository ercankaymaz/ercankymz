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

[ExpressType("IfcRampType", 1240)]
public class IfcRampType : IfcBuiltElementType, IIfcRampType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRampType>
{
	private IfcRampTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRampType), 10)]
	Xbim.Ifc4.Interfaces.IfcRampTypeEnum IIfcRampType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRampTypeEnum.HALF_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP, 
				IfcRampTypeEnum.QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.SPIRAL_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP, 
				IfcRampTypeEnum.STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED, 
				IfcRampTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP:
				PredefinedType = IfcRampTypeEnum.STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP:
				PredefinedType = IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP:
				PredefinedType = IfcRampTypeEnum.HALF_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP:
				PredefinedType = IfcRampTypeEnum.SPIRAL_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED:
				PredefinedType = IfcRampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED:
				PredefinedType = IfcRampTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcRampTypeEnum PredefinedType
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
			SetValue(delegate(IfcRampTypeEnum v)
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

	internal IfcRampType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRampTypeEnum)Enum.Parse(typeof(IfcRampTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRampType other)
	{
		return this == other;
	}
}
