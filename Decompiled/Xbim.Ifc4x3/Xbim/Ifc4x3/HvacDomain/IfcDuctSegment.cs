using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcDuctSegment", 1154)]
public class IfcDuctSegment : IfcFlowSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctSegment>, IIfcDuctSegment, IIfcFlowSegment, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcDuctSegmentTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDuctSegmentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDuctSegmentTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcDuctSegment), 9)]
	Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum? IIfcDuctSegment.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT, 
				IfcDuctSegmentTypeEnum.RIGIDSEGMENT => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.RIGIDSEGMENT, 
				IfcDuctSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.USERDEFINED, 
				IfcDuctSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.RIGIDSEGMENT:
				PredefinedType = IfcDuctSegmentTypeEnum.RIGIDSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT:
				PredefinedType = IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcDuctSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcDuctSegmentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctSegment(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctSegmentTypeEnum)Enum.Parse(typeof(IfcDuctSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctSegment other)
	{
		return this == other;
	}
}
