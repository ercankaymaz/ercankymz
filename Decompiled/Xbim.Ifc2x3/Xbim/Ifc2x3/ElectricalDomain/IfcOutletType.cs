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

[ExpressType("IfcOutletType", 240)]
public class IfcOutletType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOutletType>, IIfcOutletType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcOutletTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcOutletTypeEnum PredefinedType
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
			SetValue(delegate(IfcOutletTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcOutletType), 10)]
	Xbim.Ifc4.Interfaces.IfcOutletTypeEnum IIfcOutletType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcOutletTypeEnum.AUDIOVISUALOUTLET:
				return Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.AUDIOVISUALOUTLET;
			case IfcOutletTypeEnum.COMMUNICATIONSOUTLET:
				return Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.COMMUNICATIONSOUTLET;
			case IfcOutletTypeEnum.POWEROUTLET:
				return Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.POWEROUTLET;
			case IfcOutletTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcOutletTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.USERDEFINED;
			}
			case IfcOutletTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.AUDIOVISUALOUTLET:
				PredefinedType = IfcOutletTypeEnum.AUDIOVISUALOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.COMMUNICATIONSOUTLET:
				PredefinedType = IfcOutletTypeEnum.COMMUNICATIONSOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.POWEROUTLET:
				PredefinedType = IfcOutletTypeEnum.POWEROUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.DATAOUTLET:
				base.ElementType = value.ToString();
				PredefinedType = IfcOutletTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.TELEPHONEOUTLET:
				base.ElementType = value.ToString();
				PredefinedType = IfcOutletTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.USERDEFINED:
				PredefinedType = IfcOutletTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.NOTDEFINED:
				PredefinedType = IfcOutletTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcOutletType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcOutletTypeEnum)Enum.Parse(typeof(IfcOutletTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOutletType other)
	{
		return this == other;
	}
}
