using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralCurveMember", 224)]
public class IfcStructuralCurveMember : IfcStructuralMember, IIfcStructuralCurveMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralCurveMember>
{
	private IIfcDirection _axis;

	private IfcStructuralCurveTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveMember), 8)]
	IfcStructuralCurveMemberTypeEnum IIfcStructuralCurveMember.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralCurveTypeEnum.RIGID_JOINED_MEMBER => IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER, 
				IfcStructuralCurveTypeEnum.PIN_JOINED_MEMBER => IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER, 
				IfcStructuralCurveTypeEnum.CABLE => IfcStructuralCurveMemberTypeEnum.CABLE, 
				IfcStructuralCurveTypeEnum.TENSION_MEMBER => IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER, 
				IfcStructuralCurveTypeEnum.COMPRESSION_MEMBER => IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER, 
				IfcStructuralCurveTypeEnum.USERDEFINED => IfcStructuralCurveMemberTypeEnum.USERDEFINED, 
				IfcStructuralCurveTypeEnum.NOTDEFINED => IfcStructuralCurveMemberTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case IfcStructuralCurveMemberTypeEnum.RIGID_JOINED_MEMBER:
				PredefinedType = IfcStructuralCurveTypeEnum.RIGID_JOINED_MEMBER;
				break;
			case IfcStructuralCurveMemberTypeEnum.PIN_JOINED_MEMBER:
				PredefinedType = IfcStructuralCurveTypeEnum.PIN_JOINED_MEMBER;
				break;
			case IfcStructuralCurveMemberTypeEnum.CABLE:
				PredefinedType = IfcStructuralCurveTypeEnum.CABLE;
				break;
			case IfcStructuralCurveMemberTypeEnum.TENSION_MEMBER:
				PredefinedType = IfcStructuralCurveTypeEnum.TENSION_MEMBER;
				break;
			case IfcStructuralCurveMemberTypeEnum.COMPRESSION_MEMBER:
				PredefinedType = IfcStructuralCurveTypeEnum.COMPRESSION_MEMBER;
				break;
			case IfcStructuralCurveMemberTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralCurveTypeEnum.USERDEFINED;
				break;
			case IfcStructuralCurveMemberTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralCurveTypeEnum.NOTDEFINED;
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
			return _axis;
		}
		set
		{
			SetValue(delegate(IIfcDirection v)
			{
				_axis = v;
			}, _axis, value, "Axis", -9);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 17)]
	public IfcStructuralCurveTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralCurveTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
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
			_predefinedType = (IfcStructuralCurveTypeEnum)Enum.Parse(typeof(IfcStructuralCurveTypeEnum), value.EnumVal, ignoreCase: true);
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
