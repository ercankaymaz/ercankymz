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

[ExpressType("IfcPipeSegmentType", 62)]
public class IfcPipeSegmentType : IfcFlowSegmentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPipeSegmentType>, IIfcPipeSegmentType, IIfcFlowSegmentType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcPipeSegmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcPipeSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcPipeSegmentTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcPipeSegmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum IIfcPipeSegmentType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPipeSegmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPipeSegmentTypeEnum)Enum.Parse(typeof(IfcPipeSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPipeSegmentType other)
	{
		return this == other;
	}
}
