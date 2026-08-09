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

[ExpressType("IfcRampFlightType", 283)]
public class IfcRampFlightType : IfcBuildingElementType, IIfcRampFlightType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRampFlightType>
{
	private IfcRampFlightTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRampFlightType), 10)]
	Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum IIfcRampFlightType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRampFlightTypeEnum.STRAIGHT => Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.STRAIGHT, 
				IfcRampFlightTypeEnum.SPIRAL => Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.SPIRAL, 
				IfcRampFlightTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.USERDEFINED, 
				IfcRampFlightTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.STRAIGHT:
				PredefinedType = IfcRampFlightTypeEnum.STRAIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.SPIRAL:
				PredefinedType = IfcRampFlightTypeEnum.SPIRAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.USERDEFINED:
				PredefinedType = IfcRampFlightTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampFlightTypeEnum.NOTDEFINED:
				PredefinedType = IfcRampFlightTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcRampFlightTypeEnum PredefinedType
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
			SetValue(delegate(IfcRampFlightTypeEnum v)
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

	internal IfcRampFlightType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRampFlightTypeEnum)Enum.Parse(typeof(IfcRampFlightTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRampFlightType other)
	{
		return this == other;
	}
}
