using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcMemberType", 601)]
public class IfcMemberType : IfcBuildingElementType, IIfcMemberType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMemberType>
{
	private IfcMemberTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcMemberType), 10)]
	Xbim.Ifc4.Interfaces.IfcMemberTypeEnum IIfcMemberType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcMemberTypeEnum.BRACE => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.BRACE, 
				IfcMemberTypeEnum.CHORD => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.CHORD, 
				IfcMemberTypeEnum.COLLAR => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.COLLAR, 
				IfcMemberTypeEnum.MEMBER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MEMBER, 
				IfcMemberTypeEnum.MULLION => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MULLION, 
				IfcMemberTypeEnum.PLATE => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PLATE, 
				IfcMemberTypeEnum.POST => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.POST, 
				IfcMemberTypeEnum.PURLIN => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PURLIN, 
				IfcMemberTypeEnum.RAFTER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.RAFTER, 
				IfcMemberTypeEnum.STRINGER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRINGER, 
				IfcMemberTypeEnum.STRUT => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRUT, 
				IfcMemberTypeEnum.STUD => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STUD, 
				IfcMemberTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.USERDEFINED, 
				IfcMemberTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.BRACE:
				PredefinedType = IfcMemberTypeEnum.BRACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.CHORD:
				PredefinedType = IfcMemberTypeEnum.CHORD;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.COLLAR:
				PredefinedType = IfcMemberTypeEnum.COLLAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MEMBER:
				PredefinedType = IfcMemberTypeEnum.MEMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MULLION:
				PredefinedType = IfcMemberTypeEnum.MULLION;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PLATE:
				PredefinedType = IfcMemberTypeEnum.PLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.POST:
				PredefinedType = IfcMemberTypeEnum.POST;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PURLIN:
				PredefinedType = IfcMemberTypeEnum.PURLIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.RAFTER:
				PredefinedType = IfcMemberTypeEnum.RAFTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRINGER:
				PredefinedType = IfcMemberTypeEnum.STRINGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRUT:
				PredefinedType = IfcMemberTypeEnum.STRUT;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STUD:
				PredefinedType = IfcMemberTypeEnum.STUD;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.USERDEFINED:
				PredefinedType = IfcMemberTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.NOTDEFINED:
				PredefinedType = IfcMemberTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcMemberTypeEnum PredefinedType
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
			SetValue(delegate(IfcMemberTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcMemberType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMemberTypeEnum)Enum.Parse(typeof(IfcMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMemberType other)
	{
		return this == other;
	}
}
