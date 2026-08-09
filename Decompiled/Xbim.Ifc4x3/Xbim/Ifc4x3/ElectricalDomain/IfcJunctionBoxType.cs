using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcJunctionBoxType", 593)]
public class IfcJunctionBoxType : IfcFlowFittingType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcJunctionBoxType>, IIfcJunctionBoxType, IIfcFlowFittingType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcJunctionBoxTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcJunctionBoxTypeEnum PredefinedType
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
			SetValue(delegate(IfcJunctionBoxTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcJunctionBoxType), 10)]
	Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum IIfcJunctionBoxType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcJunctionBoxTypeEnum.DATA => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.DATA, 
				IfcJunctionBoxTypeEnum.POWER => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.POWER, 
				IfcJunctionBoxTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.USERDEFINED, 
				IfcJunctionBoxTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.DATA:
				PredefinedType = IfcJunctionBoxTypeEnum.DATA;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.POWER:
				PredefinedType = IfcJunctionBoxTypeEnum.POWER;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.USERDEFINED:
				PredefinedType = IfcJunctionBoxTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.NOTDEFINED:
				PredefinedType = IfcJunctionBoxTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcJunctionBoxType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcJunctionBoxTypeEnum)Enum.Parse(typeof(IfcJunctionBoxTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcJunctionBoxType other)
	{
		return this == other;
	}
}
