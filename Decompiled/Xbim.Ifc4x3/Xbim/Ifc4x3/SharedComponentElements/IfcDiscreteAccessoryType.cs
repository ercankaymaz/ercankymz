using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcDiscreteAccessoryType", 135)]
public class IfcDiscreteAccessoryType : IfcElementComponentType, IIfcDiscreteAccessoryType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDiscreteAccessoryType>
{
	private IfcDiscreteAccessoryTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcDiscreteAccessoryType), 10)]
	Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum IIfcDiscreteAccessoryType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDiscreteAccessoryTypeEnum.ANCHORPLATE => Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.ANCHORPLATE, 
				IfcDiscreteAccessoryTypeEnum.BIRDPROTECTION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.BRACKET => Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.BRACKET, 
				IfcDiscreteAccessoryTypeEnum.CABLEARRANGER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.ELASTIC_CUSHION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.EXPANSION_JOINT_DEVICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.FILLER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.FLASHING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.INSULATOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.LOCK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.PANEL_STRENGTHENING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.POINTMACHINEMOUNTINGDEVICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.POINT_MACHINE_LOCKING_DEVICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.RAILBRACE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.RAILPAD => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.RAIL_LUBRICATION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.RAIL_MECHANICAL_EQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.SHOE => Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.SHOE, 
				IfcDiscreteAccessoryTypeEnum.SLIDINGCHAIR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.SOUNDABSORPTION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.TENSIONINGEQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum>(), 
				IfcDiscreteAccessoryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.USERDEFINED, 
				IfcDiscreteAccessoryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.ANCHORPLATE:
				PredefinedType = IfcDiscreteAccessoryTypeEnum.ANCHORPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.BRACKET:
				PredefinedType = IfcDiscreteAccessoryTypeEnum.BRACKET;
				break;
			case Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.SHOE:
				PredefinedType = IfcDiscreteAccessoryTypeEnum.SHOE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.USERDEFINED:
				PredefinedType = IfcDiscreteAccessoryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum.NOTDEFINED:
				PredefinedType = IfcDiscreteAccessoryTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDiscreteAccessoryTypeEnum PredefinedType
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
			SetValue(delegate(IfcDiscreteAccessoryTypeEnum v)
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

	internal IfcDiscreteAccessoryType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDiscreteAccessoryTypeEnum)Enum.Parse(typeof(IfcDiscreteAccessoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDiscreteAccessoryType other)
	{
		return this == other;
	}
}
