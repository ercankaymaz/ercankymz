using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcCableCarrierSegmentType", 301)]
public class IfcCableCarrierSegmentType : IfcFlowSegmentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableCarrierSegmentType>, IIfcCableCarrierSegmentType, IIfcFlowSegmentType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcCableCarrierSegmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCableCarrierSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcCableCarrierSegmentTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCableCarrierSegmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum IIfcCableCarrierSegmentType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLELADDERSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRAYSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CABLETRUNKINGSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.CONDUITSEGMENT, 
				IfcCableCarrierSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.USERDEFINED, 
				IfcCableCarrierSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierSegmentTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableCarrierSegmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableCarrierSegmentTypeEnum)Enum.Parse(typeof(IfcCableCarrierSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableCarrierSegmentType other)
	{
		return this == other;
	}
}
