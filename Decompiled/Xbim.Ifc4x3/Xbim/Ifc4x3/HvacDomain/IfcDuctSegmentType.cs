using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcDuctSegmentType", 270)]
public class IfcDuctSegmentType : IfcFlowSegmentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctSegmentType>, IIfcDuctSegmentType, IIfcFlowSegmentType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcDuctSegmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDuctSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcDuctSegmentTypeEnum v)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDuctSegmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum IIfcDuctSegmentType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.FLEXIBLESEGMENT, 
				IfcDuctSegmentTypeEnum.RIGIDSEGMENT => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.RIGIDSEGMENT, 
				IfcDuctSegmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.USERDEFINED, 
				IfcDuctSegmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSegmentTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctSegmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctSegmentTypeEnum)Enum.Parse(typeof(IfcDuctSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctSegmentType other)
	{
		return this == other;
	}
}
