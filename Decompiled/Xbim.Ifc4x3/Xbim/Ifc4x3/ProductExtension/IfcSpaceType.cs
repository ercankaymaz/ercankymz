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

[ExpressType("IfcSpaceType", 529)]
public class IfcSpaceType : IfcSpatialStructureElementType, IIfcSpaceType, IIfcSpatialStructureElementType, IIfcSpatialElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpaceType>
{
	private IfcSpaceTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _longName;

	[CrossSchemaAttribute(typeof(IIfcSpaceType), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum IIfcSpaceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSpaceTypeEnum.BERTH => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum>(), 
				IfcSpaceTypeEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.EXTERNAL, 
				IfcSpaceTypeEnum.GFA => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.GFA, 
				IfcSpaceTypeEnum.INTERNAL => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.INTERNAL, 
				IfcSpaceTypeEnum.PARKING => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.PARKING, 
				IfcSpaceTypeEnum.SPACE => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.SPACE, 
				IfcSpaceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.USERDEFINED, 
				IfcSpaceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.SPACE:
				PredefinedType = IfcSpaceTypeEnum.SPACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.PARKING:
				PredefinedType = IfcSpaceTypeEnum.PARKING;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.GFA:
				PredefinedType = IfcSpaceTypeEnum.GFA;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.INTERNAL:
				PredefinedType = IfcSpaceTypeEnum.INTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.EXTERNAL:
				PredefinedType = IfcSpaceTypeEnum.EXTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.USERDEFINED:
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.NOTDEFINED:
				PredefinedType = IfcSpaceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpaceType), 11)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpaceType.LongName
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
	public IfcSpaceTypeEnum PredefinedType
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
			SetValue(delegate(IfcSpaceTypeEnum v)
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

	internal IfcSpaceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpaceTypeEnum)Enum.Parse(typeof(IfcSpaceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_longName = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceType other)
	{
		return this == other;
	}
}
