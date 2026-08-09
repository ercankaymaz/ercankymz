using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralSurfaceReaction", 1285)]
public class IfcStructuralSurfaceReaction : IfcStructuralReaction, IIfcStructuralSurfaceReaction, IIfcStructuralReaction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceReaction>
{
	private IfcStructuralSurfaceActivityTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStructuralSurfaceReaction), 10)]
	Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum IIfcStructuralSurfaceReaction.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralSurfaceActivityTypeEnum.BILINEAR => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.BILINEAR, 
				IfcStructuralSurfaceActivityTypeEnum.CONST => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.CONST, 
				IfcStructuralSurfaceActivityTypeEnum.DISCRETE => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.DISCRETE, 
				IfcStructuralSurfaceActivityTypeEnum.ISOCONTOUR => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.ISOCONTOUR, 
				IfcStructuralSurfaceActivityTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.USERDEFINED, 
				IfcStructuralSurfaceActivityTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.CONST:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.CONST;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.BILINEAR:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.BILINEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.DISCRETE:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.DISCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.ISOCONTOUR:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.ISOCONTOUR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralSurfaceActivityTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralSurfaceActivityTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcStructuralSurfaceActivityTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralSurfaceActivityTypeEnum v)
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.AppliedLoad != null)
			{
				yield return base.AppliedLoad;
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

	internal IfcStructuralSurfaceReaction(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStructuralSurfaceActivityTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceReaction other)
	{
		return this == other;
	}
}
