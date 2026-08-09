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

[ExpressType("IfcLampType", 592)]
public class IfcLampType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLampType>, IIfcLampType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcLampTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcLampTypeEnum PredefinedType
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
			SetValue(delegate(IfcLampTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcLampType), 10)]
	Xbim.Ifc4.Interfaces.IfcLampTypeEnum IIfcLampType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcLampTypeEnum.COMPACTFLUORESCENT:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.COMPACTFLUORESCENT;
			case IfcLampTypeEnum.FLUORESCENT:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.FLUORESCENT;
			case IfcLampTypeEnum.HIGHPRESSUREMERCURY:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSUREMERCURY;
			case IfcLampTypeEnum.HIGHPRESSURESODIUM:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSURESODIUM;
			case IfcLampTypeEnum.METALHALIDE:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.METALHALIDE;
			case IfcLampTypeEnum.TUNGSTENFILAMENT:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.TUNGSTENFILAMENT;
			case IfcLampTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcLampTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.USERDEFINED;
			}
			case IfcLampTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcLampTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.COMPACTFLUORESCENT:
				PredefinedType = IfcLampTypeEnum.COMPACTFLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.FLUORESCENT:
				PredefinedType = IfcLampTypeEnum.FLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HALOGEN:
				base.ElementType = value.ToString();
				PredefinedType = IfcLampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSUREMERCURY:
				PredefinedType = IfcLampTypeEnum.HIGHPRESSUREMERCURY;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.HIGHPRESSURESODIUM:
				PredefinedType = IfcLampTypeEnum.HIGHPRESSURESODIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.LED:
				base.ElementType = value.ToString();
				PredefinedType = IfcLampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.METALHALIDE:
				PredefinedType = IfcLampTypeEnum.METALHALIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.OLED:
				base.ElementType = value.ToString();
				PredefinedType = IfcLampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.TUNGSTENFILAMENT:
				PredefinedType = IfcLampTypeEnum.TUNGSTENFILAMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.USERDEFINED:
				PredefinedType = IfcLampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLampTypeEnum.NOTDEFINED:
				PredefinedType = IfcLampTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLampType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLampTypeEnum)Enum.Parse(typeof(IfcLampTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLampType other)
	{
		return this == other;
	}
}
