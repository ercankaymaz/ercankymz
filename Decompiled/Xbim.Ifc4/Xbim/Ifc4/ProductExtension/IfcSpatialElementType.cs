using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSpatialElementType", 1274)]
public abstract class IfcSpatialElementType : IfcTypeProduct, IIfcSpatialElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialElementType>
{
	private IfcLabel? _elementType;

	IfcLabel? IIfcSpatialElementType.ElementType
	{
		get
		{
			return ElementType;
		}
		set
		{
			ElementType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcLabel? ElementType
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
			SetValue(delegate(IfcLabel? v)
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
