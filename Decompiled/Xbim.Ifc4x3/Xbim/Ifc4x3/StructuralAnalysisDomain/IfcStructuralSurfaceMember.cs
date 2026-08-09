using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralSurfaceMember", 420)]
public class IfcStructuralSurfaceMember : IfcStructuralMember, IIfcStructuralSurfaceMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceMember>
{
	private IfcStructuralSurfaceMemberTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _thickness;

	[CrossSchemaAttribute(typeof(IIfcStructuralSurfaceMember), 8)]
	Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum IIfcStructuralSurfaceMember.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT, 
				IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT, 
				IfcStructuralSurfaceMemberTypeEnum.SHELL => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.SHELL, 
				IfcStructuralSurfaceMemberTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.USERDEFINED, 
				IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT:
				PredefinedType = IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT:
				PredefinedType = IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.SHELL:
				PredefinedType = IfcStructuralSurfaceMemberTypeEnum.SHELL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralSurfaceMemberTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralSurfaceMember), 9)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcStructuralSurfaceMember.Thickness
	{
		get
		{
			if (!Thickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Thickness.Value);
		}
		set
		{
			Thickness = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcStructuralSurfaceMemberTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralSurfaceMemberTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 9);
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

	internal IfcStructuralSurfaceMember(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStructuralSurfaceMemberTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_thickness = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceMember other)
	{
		return this == other;
	}
}
