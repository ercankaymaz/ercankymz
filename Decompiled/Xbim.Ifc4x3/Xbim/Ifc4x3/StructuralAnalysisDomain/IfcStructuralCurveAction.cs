using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralCurveAction", 1279)]
public class IfcStructuralCurveAction : IfcStructuralAction, IIfcStructuralCurveAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralCurveAction>
{
	private IfcProjectedOrTrueLengthEnum? _projectedOrTrue;

	private IfcStructuralCurveActivityTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveAction), 11)]
	Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum? IIfcStructuralCurveAction.ProjectedOrTrue
	{
		get
		{
			return ProjectedOrTrue switch
			{
				IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH => Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH, 
				IfcProjectedOrTrueLengthEnum.TRUE_LENGTH => Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.TRUE_LENGTH, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH:
				ProjectedOrTrue = IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectedOrTrueLengthEnum.TRUE_LENGTH:
				ProjectedOrTrue = IfcProjectedOrTrueLengthEnum.TRUE_LENGTH;
				break;
			case null:
				ProjectedOrTrue = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralCurveAction), 12)]
	Xbim.Ifc4.Interfaces.IfcStructuralCurveActivityTypeEnum IIfcStructuralCurveAction.PredefinedType
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 26)]
	public IfcProjectedOrTrueLengthEnum? ProjectedOrTrue
	{
		get
		{
			if (_activated)
			{
				return _projectedOrTrue;
			}
			Activate();
			return _projectedOrTrue;
		}
		set
		{
			SetValue(delegate(IfcProjectedOrTrueLengthEnum? v)
			{
				_projectedOrTrue = v;
			}, _projectedOrTrue, value, "ProjectedOrTrue", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
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
			}, _predefinedType, value, "PredefinedType", 12);
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

	internal IfcStructuralCurveAction(IModel model, int label, bool activated)
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
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_projectedOrTrue = (IfcProjectedOrTrueLengthEnum)Enum.Parse(typeof(IfcProjectedOrTrueLengthEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_predefinedType = (IfcStructuralCurveActivityTypeEnum)Enum.Parse(typeof(IfcStructuralCurveActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralCurveAction other)
	{
		return this == other;
	}
}
