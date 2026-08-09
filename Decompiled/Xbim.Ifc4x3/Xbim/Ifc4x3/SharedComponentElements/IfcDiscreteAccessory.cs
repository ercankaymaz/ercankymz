using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcDiscreteAccessory", 423)]
public class IfcDiscreteAccessory : IfcElementComponent, IIfcDiscreteAccessory, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDiscreteAccessory>
{
	private IfcDiscreteAccessoryTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcDiscreteAccessory), 9)]
	Xbim.Ifc4.Interfaces.IfcDiscreteAccessoryTypeEnum? IIfcDiscreteAccessory.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcDiscreteAccessoryTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDiscreteAccessoryTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcDiscreteAccessory(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcDiscreteAccessoryTypeEnum)Enum.Parse(typeof(IfcDiscreteAccessoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDiscreteAccessory other)
	{
		return this == other;
	}
}
