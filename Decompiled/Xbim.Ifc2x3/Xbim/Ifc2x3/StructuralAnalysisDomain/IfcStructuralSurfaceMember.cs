using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralSurfaceMember", 420)]
public class IfcStructuralSurfaceMember : IfcStructuralMember, IIfcStructuralSurfaceMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceMember>
{
	private IfcStructuralSurfaceTypeEnum _predefinedType;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _thickness;

	[CrossSchemaAttribute(typeof(IIfcStructuralSurfaceMember), 8)]
	IfcStructuralSurfaceMemberTypeEnum IIfcStructuralSurfaceMember.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralSurfaceTypeEnum.BENDING_ELEMENT => IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT, 
				IfcStructuralSurfaceTypeEnum.MEMBRANE_ELEMENT => IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT, 
				IfcStructuralSurfaceTypeEnum.SHELL => IfcStructuralSurfaceMemberTypeEnum.SHELL, 
				IfcStructuralSurfaceTypeEnum.USERDEFINED => IfcStructuralSurfaceMemberTypeEnum.USERDEFINED, 
				IfcStructuralSurfaceTypeEnum.NOTDEFINED => IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case IfcStructuralSurfaceMemberTypeEnum.BENDING_ELEMENT:
				PredefinedType = IfcStructuralSurfaceTypeEnum.BENDING_ELEMENT;
				break;
			case IfcStructuralSurfaceMemberTypeEnum.MEMBRANE_ELEMENT:
				PredefinedType = IfcStructuralSurfaceTypeEnum.MEMBRANE_ELEMENT;
				break;
			case IfcStructuralSurfaceMemberTypeEnum.SHELL:
				PredefinedType = IfcStructuralSurfaceTypeEnum.SHELL;
				break;
			case IfcStructuralSurfaceMemberTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralSurfaceTypeEnum.USERDEFINED;
				break;
			case IfcStructuralSurfaceMemberTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralSurfaceTypeEnum.NOTDEFINED;
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
			Thickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 17)]
	public IfcStructuralSurfaceTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralSurfaceTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? Thickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
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
			_predefinedType = (IfcStructuralSurfaceTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceTypeEnum), value.EnumVal, ignoreCase: true);
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
