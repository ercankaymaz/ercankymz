using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcColumnType", 214)]
public class IfcColumnType : IfcBuildingElementType, IIfcColumnType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcColumnType>
{
	private IfcColumnTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcColumnType), 10)]
	Xbim.Ifc4.Interfaces.IfcColumnTypeEnum IIfcColumnType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcColumnTypeEnum.COLUMN:
				return Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.COLUMN;
			case IfcColumnTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcColumnTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.USERDEFINED;
			}
			case IfcColumnTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.COLUMN:
				PredefinedType = IfcColumnTypeEnum.COLUMN;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.PILASTER:
				base.ElementType = value.ToString();
				PredefinedType = IfcColumnTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.USERDEFINED:
				PredefinedType = IfcColumnTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.NOTDEFINED:
				PredefinedType = IfcColumnTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcColumnTypeEnum PredefinedType
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
			SetValue(delegate(IfcColumnTypeEnum v)
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

	internal IfcColumnType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcColumnTypeEnum)Enum.Parse(typeof(IfcColumnTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcColumnType other)
	{
		return this == other;
	}
}
