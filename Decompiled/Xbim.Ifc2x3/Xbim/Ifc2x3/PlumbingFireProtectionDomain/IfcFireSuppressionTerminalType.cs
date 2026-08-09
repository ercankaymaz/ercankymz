using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.PlumbingFireProtectionDomain;

[ExpressType("IfcFireSuppressionTerminalType", 477)]
public class IfcFireSuppressionTerminalType : IfcFlowTerminalType, IIfcFireSuppressionTerminalType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFireSuppressionTerminalType>
{
	private IfcFireSuppressionTerminalTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFireSuppressionTerminalType), 10)]
	Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum IIfcFireSuppressionTerminalType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET, 
				IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT, 
				IfcFireSuppressionTerminalTypeEnum.HOSEREEL => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL, 
				IfcFireSuppressionTerminalTypeEnum.SPRINKLER => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER, 
				IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR, 
				IfcFireSuppressionTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED, 
				IfcFireSuppressionTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.HOSEREEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcFireSuppressionTerminalTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcFireSuppressionTerminalTypeEnum PredefinedType
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
			SetValue(delegate(IfcFireSuppressionTerminalTypeEnum v)
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

	internal IfcFireSuppressionTerminalType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFireSuppressionTerminalTypeEnum)Enum.Parse(typeof(IfcFireSuppressionTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFireSuppressionTerminalType other)
	{
		return this == other;
	}
}
