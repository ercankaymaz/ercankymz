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

[ExpressType("IfcWallType", 282)]
public class IfcWallType : IfcBuildingElementType, IIfcWallType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWallType>
{
	private IfcWallTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWallType), 10)]
	Xbim.Ifc4.Interfaces.IfcWallTypeEnum IIfcWallType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcWallTypeEnum.STANDARD:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.STANDARD;
			case IfcWallTypeEnum.POLYGONAL:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.POLYGONAL;
			case IfcWallTypeEnum.SHEAR:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SHEAR;
			case IfcWallTypeEnum.ELEMENTEDWALL:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.ELEMENTEDWALL;
			case IfcWallTypeEnum.PLUMBINGWALL:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PLUMBINGWALL;
			case IfcWallTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcWallTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.USERDEFINED;
			}
			case IfcWallTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcWallTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.MOVABLE:
				base.ElementType = value.ToString();
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARAPET:
				base.ElementType = value.ToString();
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARTITIONING:
				base.ElementType = value.ToString();
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PLUMBINGWALL:
				PredefinedType = IfcWallTypeEnum.PLUMBINGWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SHEAR:
				PredefinedType = IfcWallTypeEnum.SHEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SOLIDWALL:
				base.ElementType = value.ToString();
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.STANDARD:
				PredefinedType = IfcWallTypeEnum.STANDARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.POLYGONAL:
				PredefinedType = IfcWallTypeEnum.POLYGONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.ELEMENTEDWALL:
				PredefinedType = IfcWallTypeEnum.ELEMENTEDWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.USERDEFINED:
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.NOTDEFINED:
				PredefinedType = IfcWallTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcWallTypeEnum PredefinedType
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
			SetValue(delegate(IfcWallTypeEnum v)
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

	internal IfcWallType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWallTypeEnum)Enum.Parse(typeof(IfcWallTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWallType other)
	{
		return this == other;
	}
}
