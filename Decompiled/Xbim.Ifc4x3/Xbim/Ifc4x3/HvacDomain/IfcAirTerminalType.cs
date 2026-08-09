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

[ExpressType("IfcAirTerminalType", 271)]
public class IfcAirTerminalType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAirTerminalType>, IIfcAirTerminalType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcAirTerminalTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcAirTerminalTypeEnum PredefinedType
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
			SetValue(delegate(IfcAirTerminalTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcAirTerminalType), 10)]
	Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum IIfcAirTerminalType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAirTerminalTypeEnum.DIFFUSER => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.DIFFUSER, 
				IfcAirTerminalTypeEnum.GRILLE => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.GRILLE, 
				IfcAirTerminalTypeEnum.LOUVRE => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.LOUVRE, 
				IfcAirTerminalTypeEnum.REGISTER => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.REGISTER, 
				IfcAirTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.USERDEFINED, 
				IfcAirTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.DIFFUSER:
				PredefinedType = IfcAirTerminalTypeEnum.DIFFUSER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.GRILLE:
				PredefinedType = IfcAirTerminalTypeEnum.GRILLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.LOUVRE:
				PredefinedType = IfcAirTerminalTypeEnum.LOUVRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.REGISTER:
				PredefinedType = IfcAirTerminalTypeEnum.REGISTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcAirTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcAirTerminalTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAirTerminalType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAirTerminalTypeEnum)Enum.Parse(typeof(IfcAirTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAirTerminalType other)
	{
		return this == other;
	}
}
