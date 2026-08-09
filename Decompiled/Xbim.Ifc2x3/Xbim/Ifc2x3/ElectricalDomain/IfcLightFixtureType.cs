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

[ExpressType("IfcLightFixtureType", 517)]
public class IfcLightFixtureType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLightFixtureType>, IIfcLightFixtureType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcLightFixtureTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcLightFixtureTypeEnum PredefinedType
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
			SetValue(delegate(IfcLightFixtureTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcLightFixtureType), 10)]
	Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum IIfcLightFixtureType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcLightFixtureTypeEnum.POINTSOURCE:
				return Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.POINTSOURCE;
			case IfcLightFixtureTypeEnum.DIRECTIONSOURCE:
				return Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.DIRECTIONSOURCE;
			case IfcLightFixtureTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.USERDEFINED;
			}
			case IfcLightFixtureTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.POINTSOURCE:
				PredefinedType = IfcLightFixtureTypeEnum.POINTSOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.DIRECTIONSOURCE:
				PredefinedType = IfcLightFixtureTypeEnum.DIRECTIONSOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.SECURITYLIGHTING:
				base.ElementType = value.ToString();
				PredefinedType = IfcLightFixtureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.USERDEFINED:
				PredefinedType = IfcLightFixtureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.NOTDEFINED:
				PredefinedType = IfcLightFixtureTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLightFixtureType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLightFixtureTypeEnum)Enum.Parse(typeof(IfcLightFixtureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightFixtureType other)
	{
		return this == other;
	}
}
