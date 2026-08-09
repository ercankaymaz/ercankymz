using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedComponentElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcVibrationIsolatorType", 137)]
public class IfcVibrationIsolatorType : IfcElementComponentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVibrationIsolatorType>, IIfcVibrationIsolatorType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcVibrationIsolatorTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcVibrationIsolatorTypeEnum PredefinedType
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
			SetValue(delegate(IfcVibrationIsolatorTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcVibrationIsolatorType), 10)]
	Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum IIfcVibrationIsolatorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcVibrationIsolatorTypeEnum.BASE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum>(), 
				IfcVibrationIsolatorTypeEnum.COMPRESSION => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION, 
				IfcVibrationIsolatorTypeEnum.SPRING => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING, 
				IfcVibrationIsolatorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED, 
				IfcVibrationIsolatorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION:
				PredefinedType = IfcVibrationIsolatorTypeEnum.COMPRESSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING:
				PredefinedType = IfcVibrationIsolatorTypeEnum.SPRING;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcVibrationIsolatorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcVibrationIsolatorTypeEnum)Enum.Parse(typeof(IfcVibrationIsolatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVibrationIsolatorType other)
	{
		return this == other;
	}
}
