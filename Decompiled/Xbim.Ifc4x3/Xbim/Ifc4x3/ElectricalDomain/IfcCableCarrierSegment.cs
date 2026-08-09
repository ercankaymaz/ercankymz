using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcCableCarrierSegment", 1112)]
public class IfcCableCarrierSegment : IfcFlowSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableCarrierSegment>, IIfcCableCarrierSegment, IIfcFlowSegment, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCableCarrierSegmentTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCableCarrierSegmentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCableCarrierSegmentTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCableCarrierSegment), 9)]
	Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum? IIfcCableCarrierSegment.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCableCarrierSegmentTypeEnum.CABLEBRACKET => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum>(), 
				IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CATENARYWIRE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum>(), 
				IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.DROPPER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum>(), 
				IfcCableCarrierSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.USERDEFINED, 
				IfcCableCarrierSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcCableCarrierSegmentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableCarrierSegment(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableCarrierSegmentTypeEnum)Enum.Parse(typeof(IfcCableCarrierSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableCarrierSegment other)
	{
		return this == other;
	}
}
