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

[ExpressType("IfcStairFlightType", 525)]
public class IfcStairFlightType : IfcBuildingElementType, IIfcStairFlightType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStairFlightType>
{
	private IfcStairFlightTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStairFlightType), 10)]
	Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum IIfcStairFlightType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStairFlightTypeEnum.STRAIGHT => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.STRAIGHT, 
				IfcStairFlightTypeEnum.WINDER => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.WINDER, 
				IfcStairFlightTypeEnum.SPIRAL => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.SPIRAL, 
				IfcStairFlightTypeEnum.CURVED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.CURVED, 
				IfcStairFlightTypeEnum.FREEFORM => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.FREEFORM, 
				IfcStairFlightTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.USERDEFINED, 
				IfcStairFlightTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.STRAIGHT:
				PredefinedType = IfcStairFlightTypeEnum.STRAIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.WINDER:
				PredefinedType = IfcStairFlightTypeEnum.WINDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.SPIRAL:
				PredefinedType = IfcStairFlightTypeEnum.SPIRAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.CURVED:
				PredefinedType = IfcStairFlightTypeEnum.CURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.FREEFORM:
				PredefinedType = IfcStairFlightTypeEnum.FREEFORM;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.USERDEFINED:
				PredefinedType = IfcStairFlightTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.NOTDEFINED:
				PredefinedType = IfcStairFlightTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcStairFlightTypeEnum PredefinedType
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
			SetValue(delegate(IfcStairFlightTypeEnum v)
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

	internal IfcStairFlightType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStairFlightTypeEnum)Enum.Parse(typeof(IfcStairFlightTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStairFlightType other)
	{
		return this == other;
	}
}
