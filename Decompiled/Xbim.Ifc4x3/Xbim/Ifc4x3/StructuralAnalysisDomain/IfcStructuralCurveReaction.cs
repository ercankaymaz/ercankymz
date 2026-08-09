using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralCurveReaction", 1280)]
public class IfcStructuralCurveReaction : IfcStructuralReaction, IIfcStructuralCurveReaction, IIfcStructuralReaction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralCurveReaction>
{
	private IfcStructuralCurveActivityTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveReaction), 10)]
	Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum IIfcStructuralCurveReaction.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStructuralCurveActivityTypeEnum.CONST => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.CONST, 
				IfcStructuralCurveActivityTypeEnum.DISCRETE => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.DISCRETE, 
				IfcStructuralCurveActivityTypeEnum.EQUIDISTANT => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.EQUIDISTANT, 
				IfcStructuralCurveActivityTypeEnum.LINEAR => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.LINEAR, 
				IfcStructuralCurveActivityTypeEnum.PARABOLA => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.PARABOLA, 
				IfcStructuralCurveActivityTypeEnum.POLYGONAL => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.POLYGONAL, 
				IfcStructuralCurveActivityTypeEnum.SINUS => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.SINUS, 
				IfcStructuralCurveActivityTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.USERDEFINED, 
				IfcStructuralCurveActivityTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.CONST:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.CONST;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.LINEAR:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.LINEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.POLYGONAL:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.POLYGONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.EQUIDISTANT:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.EQUIDISTANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.SINUS:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.SINUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.PARABOLA:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.PARABOLA;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.DISCRETE:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.DISCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.USERDEFINED:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum.NOTDEFINED:
				PredefinedType = IfcStructuralCurveActivityTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcStructuralCurveActivityTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralCurveActivityTypeEnum v)
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

	internal IfcStructuralCurveReaction(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStructuralCurveActivityTypeEnum)Enum.Parse(typeof(IfcStructuralCurveActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralCurveReaction other)
	{
		return this == other;
	}
}
