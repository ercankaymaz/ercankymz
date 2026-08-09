using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcCoveringType", 565)]
public class IfcCoveringType : IfcBuildingElementType, IIfcCoveringType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoveringType>
{
	private IfcCoveringTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCoveringType), 10)]
	Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum IIfcCoveringType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcCoveringTypeEnum.CEILING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING;
			case IfcCoveringTypeEnum.FLOORING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING;
			case IfcCoveringTypeEnum.CLADDING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING;
			case IfcCoveringTypeEnum.ROOFING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING;
			case IfcCoveringTypeEnum.INSULATION:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION;
			case IfcCoveringTypeEnum.MEMBRANE:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE;
			case IfcCoveringTypeEnum.SLEEVING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING;
			case IfcCoveringTypeEnum.WRAPPING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING;
			case IfcCoveringTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED;
			}
			case IfcCoveringTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING:
				PredefinedType = IfcCoveringTypeEnum.CEILING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING:
				PredefinedType = IfcCoveringTypeEnum.FLOORING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING:
				PredefinedType = IfcCoveringTypeEnum.CLADDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING:
				PredefinedType = IfcCoveringTypeEnum.ROOFING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MOLDING:
				base.ElementType = value.ToString();
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD:
				base.ElementType = value.ToString();
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION:
				PredefinedType = IfcCoveringTypeEnum.INSULATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE:
				PredefinedType = IfcCoveringTypeEnum.MEMBRANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING:
				PredefinedType = IfcCoveringTypeEnum.SLEEVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING:
				PredefinedType = IfcCoveringTypeEnum.WRAPPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED:
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoveringTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCoveringTypeEnum PredefinedType
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
			SetValue(delegate(IfcCoveringTypeEnum v)
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

	internal IfcCoveringType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoveringTypeEnum)Enum.Parse(typeof(IfcCoveringTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoveringType other)
	{
		return this == other;
	}
}
