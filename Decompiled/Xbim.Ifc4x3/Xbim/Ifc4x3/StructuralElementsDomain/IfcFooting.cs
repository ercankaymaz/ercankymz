using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcFooting", 120)]
public class IfcFooting : IfcBuiltElement, IIfcFooting, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFooting>
{
	private IfcFootingTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFooting), 9)]
	Xbim.Ifc4.Interfaces.IfcFootingTypeEnum? IIfcFooting.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFootingTypeEnum.CAISSON_FOUNDATION => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION, 
				IfcFootingTypeEnum.FOOTING_BEAM => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM, 
				IfcFootingTypeEnum.PAD_FOOTING => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING, 
				IfcFootingTypeEnum.PILE_CAP => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP, 
				IfcFootingTypeEnum.STRIP_FOOTING => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING, 
				IfcFootingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED, 
				IfcFootingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION:
				PredefinedType = IfcFootingTypeEnum.CAISSON_FOUNDATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM:
				PredefinedType = IfcFootingTypeEnum.FOOTING_BEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING:
				PredefinedType = IfcFootingTypeEnum.PAD_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP:
				PredefinedType = IfcFootingTypeEnum.PILE_CAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING:
				PredefinedType = IfcFootingTypeEnum.STRIP_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED:
				PredefinedType = IfcFootingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED:
				PredefinedType = IfcFootingTypeEnum.NOTDEFINED;
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
	public IfcFootingTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFootingTypeEnum? v)
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

	internal IfcFooting(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFootingTypeEnum)Enum.Parse(typeof(IfcFootingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFooting other)
	{
		return this == other;
	}
}
