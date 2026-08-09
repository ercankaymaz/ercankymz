using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcBuildingElementPartType", 1107)]
public class IfcBuildingElementPartType : IfcElementComponentType, IIfcBuildingElementPartType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingElementPartType>
{
	private IfcBuildingElementPartTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcBuildingElementPartType), 10)]
	Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum IIfcBuildingElementPartType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBuildingElementPartTypeEnum.APRON => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.ARMOURUNIT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.INSULATION => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.INSULATION, 
				IfcBuildingElementPartTypeEnum.PRECASTPANEL => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.PRECASTPANEL, 
				IfcBuildingElementPartTypeEnum.SAFETYCAGE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.USERDEFINED, 
				IfcBuildingElementPartTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.INSULATION:
				PredefinedType = IfcBuildingElementPartTypeEnum.INSULATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.PRECASTPANEL:
				PredefinedType = IfcBuildingElementPartTypeEnum.PRECASTPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.USERDEFINED:
				PredefinedType = IfcBuildingElementPartTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.NOTDEFINED:
				PredefinedType = IfcBuildingElementPartTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcBuildingElementPartTypeEnum PredefinedType
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
			SetValue(delegate(IfcBuildingElementPartTypeEnum v)
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

	internal IfcBuildingElementPartType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBuildingElementPartTypeEnum)Enum.Parse(typeof(IfcBuildingElementPartTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingElementPartType other)
	{
		return this == other;
	}
}
