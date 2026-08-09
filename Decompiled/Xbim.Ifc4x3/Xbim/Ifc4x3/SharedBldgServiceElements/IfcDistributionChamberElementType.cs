using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionChamberElementType", 396)]
public class IfcDistributionChamberElementType : IfcDistributionFlowElementType, IIfcDistributionChamberElementType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionChamberElementType>
{
	private IfcDistributionChamberElementTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcDistributionChamberElementType), 10)]
	Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum IIfcDistributionChamberElementType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDistributionChamberElementTypeEnum.FORMEDDUCT => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.FORMEDDUCT, 
				IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER, 
				IfcDistributionChamberElementTypeEnum.INSPECTIONPIT => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONPIT, 
				IfcDistributionChamberElementTypeEnum.MANHOLE => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.MANHOLE, 
				IfcDistributionChamberElementTypeEnum.METERCHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.METERCHAMBER, 
				IfcDistributionChamberElementTypeEnum.SUMP => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.SUMP, 
				IfcDistributionChamberElementTypeEnum.TRENCH => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.TRENCH, 
				IfcDistributionChamberElementTypeEnum.VALVECHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.VALVECHAMBER, 
				IfcDistributionChamberElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.USERDEFINED, 
				IfcDistributionChamberElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.FORMEDDUCT:
				PredefinedType = IfcDistributionChamberElementTypeEnum.FORMEDDUCT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONPIT:
				PredefinedType = IfcDistributionChamberElementTypeEnum.INSPECTIONPIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.MANHOLE:
				PredefinedType = IfcDistributionChamberElementTypeEnum.MANHOLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.METERCHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.METERCHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.SUMP:
				PredefinedType = IfcDistributionChamberElementTypeEnum.SUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.TRENCH:
				PredefinedType = IfcDistributionChamberElementTypeEnum.TRENCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.VALVECHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.VALVECHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.USERDEFINED:
				PredefinedType = IfcDistributionChamberElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcDistributionChamberElementTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDistributionChamberElementTypeEnum PredefinedType
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
			SetValue(delegate(IfcDistributionChamberElementTypeEnum v)
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

	internal IfcDistributionChamberElementType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDistributionChamberElementTypeEnum)Enum.Parse(typeof(IfcDistributionChamberElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionChamberElementType other)
	{
		return this == other;
	}
}
