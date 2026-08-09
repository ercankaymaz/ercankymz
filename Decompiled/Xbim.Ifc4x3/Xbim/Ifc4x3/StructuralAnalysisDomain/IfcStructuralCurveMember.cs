using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralCurveMember", 224)]
public class IfcStructuralCurveMember : IfcStructuralMember, IIfcStructuralCurveMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralCurveMember>
{
	private IfcStructuralCurveMemberTypeEnum _predefinedType;

	private IfcDirection _axis;

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveMember), 8)]
	Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum IIfcStructuralCurveMember.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralCurveMemberTypeEnum.CABLE => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.CABLE, 
				IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER, 
				IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER, 
				IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER, 
				IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER, 
				IfcStructuralCurveMemberTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.USERDEFINED, 
				IfcStructuralCurveMemberTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.CABLE:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.CABLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveMemberTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralCurveMemberTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveMember), 9)]
	IIfcDirection IIfcStructuralCurveMember.Axis
	{
		get
		{
			return Axis;
		}
		set
		{
			Axis = value as IfcDirection;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcStructuralCurveMemberTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralCurveMemberTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 25)]
	public IfcDirection Axis
	{
		get
		{
			if (_activated)
			{
				return _axis;
			}
			Activate();
			return _axis;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_axis = v;
			}, _axis, value, "Axis", 9);
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
			if (Axis != null)
			{
				yield return Axis;
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

	internal IfcStructuralCurveMember(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcStructuralCurveMemberTypeEnum)Enum.Parse(typeof(IfcStructuralCurveMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_axis = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralCurveMember other)
	{
		return this == other;
	}
}
