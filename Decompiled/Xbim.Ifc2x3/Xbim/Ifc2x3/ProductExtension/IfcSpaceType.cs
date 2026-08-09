using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcSpaceType", 529)]
public class IfcSpaceType : IfcSpatialStructureElementType, IIfcSpaceType, IIfcSpatialStructureElementType, IIfcSpatialElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpaceType>
{
	private Xbim.Ifc4.MeasureResource.IfcLabel? _longName;

	private IfcSpaceTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSpaceType), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum IIfcSpaceType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcSpaceTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.USERDEFINED;
			}
			case IfcSpaceTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.SPACE:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.PARKING:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.GFA:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.INTERNAL:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.EXTERNAL:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
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
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", -11);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpaceType), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpatialElementType.ElementType
	{
		get
		{
			if (!base.ElementType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(base.ElementType.Value);
		}
		set
		{
			base.ElementType = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceType other)
	{
		return this == other;
	}
}
