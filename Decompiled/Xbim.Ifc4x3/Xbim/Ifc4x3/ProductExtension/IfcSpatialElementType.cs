using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcSpatialElementType", 1274)]
public abstract class IfcSpatialElementType : Xbim.Ifc4x3.Kernel.IfcTypeProduct, IIfcSpatialElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialElementType>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _elementType;

	[CrossSchemaAttribute(typeof(IIfcSpatialElementType), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpatialElementType.ElementType
	{
		get
		{
			if (!ElementType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ElementType.Value);
		}
		set
		{
			ElementType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ElementType
	{
		get
		{
			if (_activated)
			{
				return _elementType;
			}
			Activate();
			return _elementType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_elementType = v;
			}, _elementType, value, "ElementType", 9);
		}
	}

	internal IfcSpatialElementType(IModel model, int label, bool activated)
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
			_elementType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialElementType other)
	{
		return this == other;
	}
}
