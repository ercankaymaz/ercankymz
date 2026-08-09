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

[ExpressType("IfcCableSegmentType", 77)]
public class IfcCableSegmentType : IfcFlowSegmentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableSegmentType>, IIfcCableSegmentType, IIfcFlowSegmentType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcCableSegmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCableSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcCableSegmentTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCableSegmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum IIfcCableSegmentType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcCableSegmentTypeEnum.CABLESEGMENT:
				return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CABLESEGMENT;
			case IfcCableSegmentTypeEnum.CONDUCTORSEGMENT:
				return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CONDUCTORSEGMENT;
			case IfcCableSegmentTypeEnum.USERDEFINED:
				if (base.ElementType.HasValue)
				{
					string text = base.ElementType.Value;
					if (text == "BUSBARSEGMENT")
					{
						return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.BUSBARSEGMENT;
					}
					if (text == "CORESEGMENT")
					{
						return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CORESEGMENT;
					}
				}
				return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.USERDEFINED;
			case IfcCableSegmentTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.BUSBARSEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.USERDEFINED;
				base.ElementType = value.ToString();
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CABLESEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.CABLESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CONDUCTORSEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.CONDUCTORSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.CORESEGMENT:
				PredefinedType = IfcCableSegmentTypeEnum.USERDEFINED;
				base.ElementType = value.ToString();
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcCableSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcCableSegmentTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableSegmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableSegmentTypeEnum)Enum.Parse(typeof(IfcCableSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableSegmentType other)
	{
		return this == other;
	}
}
