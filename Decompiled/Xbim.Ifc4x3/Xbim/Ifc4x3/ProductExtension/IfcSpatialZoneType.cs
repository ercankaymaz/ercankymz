using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcSpatialZoneType", 1276)]
public class IfcSpatialZoneType : IfcSpatialElementType, IIfcSpatialZoneType, IIfcSpatialElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpatialZoneType>
{
	private IfcSpatialZoneTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _longName;

	[CrossSchemaAttribute(typeof(IIfcSpatialZoneType), 10)]
	Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum IIfcSpatialZoneType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSpatialZoneTypeEnum.CONSTRUCTION => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.CONSTRUCTION, 
				IfcSpatialZoneTypeEnum.FIRESAFETY => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.FIRESAFETY, 
				IfcSpatialZoneTypeEnum.INTERFERENCE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum>(), 
				IfcSpatialZoneTypeEnum.LIGHTING => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.LIGHTING, 
				IfcSpatialZoneTypeEnum.OCCUPANCY => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.OCCUPANCY, 
				IfcSpatialZoneTypeEnum.RESERVATION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum>(), 
				IfcSpatialZoneTypeEnum.SECURITY => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.SECURITY, 
				IfcSpatialZoneTypeEnum.THERMAL => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.THERMAL, 
				IfcSpatialZoneTypeEnum.TRANSPORT => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.TRANSPORT, 
				IfcSpatialZoneTypeEnum.VENTILATION => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.VENTILATION, 
				IfcSpatialZoneTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.USERDEFINED, 
				IfcSpatialZoneTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.CONSTRUCTION:
				PredefinedType = IfcSpatialZoneTypeEnum.CONSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.FIRESAFETY:
				PredefinedType = IfcSpatialZoneTypeEnum.FIRESAFETY;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.LIGHTING:
				PredefinedType = IfcSpatialZoneTypeEnum.LIGHTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.OCCUPANCY:
				PredefinedType = IfcSpatialZoneTypeEnum.OCCUPANCY;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.SECURITY:
				PredefinedType = IfcSpatialZoneTypeEnum.SECURITY;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.THERMAL:
				PredefinedType = IfcSpatialZoneTypeEnum.THERMAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.TRANSPORT:
				PredefinedType = IfcSpatialZoneTypeEnum.TRANSPORT;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.VENTILATION:
				PredefinedType = IfcSpatialZoneTypeEnum.VENTILATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.USERDEFINED:
				PredefinedType = IfcSpatialZoneTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum.NOTDEFINED:
				PredefinedType = IfcSpatialZoneTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpatialZoneType), 11)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpatialZoneType.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSpatialZoneTypeEnum PredefinedType
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
			SetValue(delegate(IfcSpatialZoneTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 11);
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

	internal IfcSpatialZoneType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpatialZoneTypeEnum)Enum.Parse(typeof(IfcSpatialZoneTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_longName = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialZoneType other)
	{
		return this == other;
	}
}
