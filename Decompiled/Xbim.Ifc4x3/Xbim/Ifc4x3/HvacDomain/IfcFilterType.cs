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

[ExpressType("IfcFilterType", 139)]
public class IfcFilterType : IfcFlowTreatmentDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFilterType>, IIfcFilterType, IIfcFlowTreatmentDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcFilterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcFilterTypeEnum PredefinedType
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
			SetValue(delegate(IfcFilterTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcFilterType), 10)]
	Xbim.Ifc4.Interfaces.IfcFilterTypeEnum IIfcFilterType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFilterTypeEnum.AIRPARTICLEFILTER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.AIRPARTICLEFILTER, 
				IfcFilterTypeEnum.COMPRESSEDAIRFILTER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.COMPRESSEDAIRFILTER, 
				IfcFilterTypeEnum.ODORFILTER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.ODORFILTER, 
				IfcFilterTypeEnum.OILFILTER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.OILFILTER, 
				IfcFilterTypeEnum.STRAINER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.STRAINER, 
				IfcFilterTypeEnum.WATERFILTER => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.WATERFILTER, 
				IfcFilterTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.USERDEFINED, 
				IfcFilterTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.AIRPARTICLEFILTER:
				PredefinedType = IfcFilterTypeEnum.AIRPARTICLEFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.COMPRESSEDAIRFILTER:
				PredefinedType = IfcFilterTypeEnum.COMPRESSEDAIRFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.ODORFILTER:
				PredefinedType = IfcFilterTypeEnum.ODORFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.OILFILTER:
				PredefinedType = IfcFilterTypeEnum.OILFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.STRAINER:
				PredefinedType = IfcFilterTypeEnum.STRAINER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.WATERFILTER:
				PredefinedType = IfcFilterTypeEnum.WATERFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.USERDEFINED:
				PredefinedType = IfcFilterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.NOTDEFINED:
				PredefinedType = IfcFilterTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFilterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFilterTypeEnum)Enum.Parse(typeof(IfcFilterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFilterType other)
	{
		return this == other;
	}
}
