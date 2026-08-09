using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcSpatialZone", 1275)]
public class IfcSpatialZone : IfcSpatialElement, IIfcSpatialZone, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpatialZone>
{
	private IfcSpatialZoneTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSpatialZone), 9)]
	Xbim.Ifc4.Interfaces.IfcSpatialZoneTypeEnum? IIfcSpatialZone.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
	public IfcSpatialZoneTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSpatialZoneTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcSpatialZone(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcSpatialZoneTypeEnum)Enum.Parse(typeof(IfcSpatialZoneTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialZone other)
	{
		return this == other;
	}
}
