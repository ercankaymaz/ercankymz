using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcPipeSegment", 1223)]
public class IfcPipeSegment : IfcFlowSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPipeSegment>, IIfcPipeSegment, IIfcFlowSegment, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcPipeSegmentTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcPipeSegmentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPipeSegmentTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcPipeSegment), 9)]
	Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum? IIfcPipeSegment.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPipeSegmentTypeEnum.CULVERT => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.CULVERT, 
				IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT, 
				IfcPipeSegmentTypeEnum.GUTTER => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.GUTTER, 
				IfcPipeSegmentTypeEnum.RIGIDSEGMENT => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.RIGIDSEGMENT, 
				IfcPipeSegmentTypeEnum.SPOOL => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.SPOOL, 
				IfcPipeSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.USERDEFINED, 
				IfcPipeSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.CULVERT:
				PredefinedType = IfcPipeSegmentTypeEnum.CULVERT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT:
				PredefinedType = IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.RIGIDSEGMENT:
				PredefinedType = IfcPipeSegmentTypeEnum.RIGIDSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.GUTTER:
				PredefinedType = IfcPipeSegmentTypeEnum.GUTTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.SPOOL:
				PredefinedType = IfcPipeSegmentTypeEnum.SPOOL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcPipeSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcPipeSegmentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPipeSegment(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPipeSegmentTypeEnum)Enum.Parse(typeof(IfcPipeSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPipeSegment other)
	{
		return this == other;
	}
}
