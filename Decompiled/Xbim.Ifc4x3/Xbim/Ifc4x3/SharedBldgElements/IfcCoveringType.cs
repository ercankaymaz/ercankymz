using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcCoveringType", 565)]
public class IfcCoveringType : IfcBuiltElementType, IIfcCoveringType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoveringType>
{
	private IfcCoveringTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCoveringType), 10)]
	Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum IIfcCoveringType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoveringTypeEnum.CEILING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING, 
				IfcCoveringTypeEnum.CLADDING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING, 
				IfcCoveringTypeEnum.COPING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(), 
				IfcCoveringTypeEnum.FLOORING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING, 
				IfcCoveringTypeEnum.INSULATION => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION, 
				IfcCoveringTypeEnum.MEMBRANE => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE, 
				IfcCoveringTypeEnum.MOLDING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MOLDING, 
				IfcCoveringTypeEnum.ROOFING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING, 
				IfcCoveringTypeEnum.SKIRTINGBOARD => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD, 
				IfcCoveringTypeEnum.SLEEVING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING, 
				IfcCoveringTypeEnum.TOPPING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(), 
				IfcCoveringTypeEnum.WRAPPING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING, 
				IfcCoveringTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED, 
				IfcCoveringTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
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
				PredefinedType = IfcCoveringTypeEnum.MOLDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD:
				PredefinedType = IfcCoveringTypeEnum.SKIRTINGBOARD;
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
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
