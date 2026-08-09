using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcMember", 310)]
public class IfcMember : IfcBuiltElement, IIfcMember, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMember>
{
	private IfcMemberTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcMember), 9)]
	Xbim.Ifc4.Interfaces.IfcMemberTypeEnum? IIfcMember.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcMemberTypeEnum.ARCH_SEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.BRACE => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.BRACE, 
				IfcMemberTypeEnum.CHORD => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.CHORD, 
				IfcMemberTypeEnum.COLLAR => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.COLLAR, 
				IfcMemberTypeEnum.MEMBER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MEMBER, 
				IfcMemberTypeEnum.MULLION => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.MULLION, 
				IfcMemberTypeEnum.PLATE => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PLATE, 
				IfcMemberTypeEnum.POST => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.POST, 
				IfcMemberTypeEnum.PURLIN => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.PURLIN, 
				IfcMemberTypeEnum.RAFTER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.RAFTER, 
				IfcMemberTypeEnum.STAY_CABLE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.STIFFENING_RIB => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.STRINGER => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRINGER, 
				IfcMemberTypeEnum.STRUCTURALCABLE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.STRUT => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STRUT, 
				IfcMemberTypeEnum.STUD => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.STUD, 
				IfcMemberTypeEnum.SUSPENDER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.SUSPENSION_CABLE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.TIEBAR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMemberTypeEnum>(), 
				IfcMemberTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.USERDEFINED, 
				IfcMemberTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcMemberTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcMemberTypeEnum? PredefinedType
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
			SetValue(delegate(IfcMemberTypeEnum? v)
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

	internal IfcMember(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMemberTypeEnum)Enum.Parse(typeof(IfcMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMember other)
	{
		return this == other;
	}
}
