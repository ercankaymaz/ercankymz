using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcCableSegment", 1115)]
public class IfcCableSegment : IfcFlowSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableSegment>, IIfcCableSegment, IIfcFlowSegment, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCableSegmentTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCableSegmentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCableSegmentTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCableSegment), 9)]
	Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum? IIfcCableSegment.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCableSegmentTypeEnum.BUSBARSEGMENT => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.BUSBARSEGMENT, 
				IfcCableSegmentTypeEnum.CABLESEGMENT => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CABLESEGMENT, 
				IfcCableSegmentTypeEnum.CONDUCTORSEGMENT => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CONDUCTORSEGMENT, 
				IfcCableSegmentTypeEnum.CONTACTWIRESEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.CORESEGMENT => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CORESEGMENT, 
				IfcCableSegmentTypeEnum.FIBERSEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.FIBERTUBE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.OPTICALCABLESEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.STITCHWIRE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.WIREPAIRSEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum>(), 
				IfcCableSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.USERDEFINED, 
				IfcCableSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.BUSBARSEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.BUSBARSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CABLESEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.CABLESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CONDUCTORSEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.CONDUCTORSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CORESEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.CORESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcCableSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcCableSegmentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableSegment(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableSegmentTypeEnum)Enum.Parse(typeof(IfcCableSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableSegment other)
	{
		return this == other;
	}
}
