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

[ExpressType("IfcStackTerminalType", 476)]
public class IfcStackTerminalType : IfcFlowTerminalType, IIfcStackTerminalType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStackTerminalType>
{
	private IfcStackTerminalTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStackTerminalType), 10)]
	Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum IIfcStackTerminalType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStackTerminalTypeEnum.BIRDCAGE => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.BIRDCAGE, 
				IfcStackTerminalTypeEnum.COWL => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.COWL, 
				IfcStackTerminalTypeEnum.RAINWATERHOPPER => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.RAINWATERHOPPER, 
				IfcStackTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.USERDEFINED, 
				IfcStackTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.BIRDCAGE:
				PredefinedType = IfcStackTerminalTypeEnum.BIRDCAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.COWL:
				PredefinedType = IfcStackTerminalTypeEnum.COWL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.RAINWATERHOPPER:
				PredefinedType = IfcStackTerminalTypeEnum.RAINWATERHOPPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcStackTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStackTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcStackTerminalTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcStackTerminalTypeEnum PredefinedType
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
			SetValue(delegate(IfcStackTerminalTypeEnum v)
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

	internal IfcStackTerminalType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStackTerminalTypeEnum)Enum.Parse(typeof(IfcStackTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStackTerminalType other)
	{
		return this == other;
	}
}
