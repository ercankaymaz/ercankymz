using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcSpatialStructureElement", 170)]
public abstract class IfcSpatialStructureElement : IfcSpatialElement, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialStructureElement>
{
	private IfcElementCompositionEnum? _compositionType;

	[CrossSchemaAttribute(typeof(IIfcSpatialStructureElement), 9)]
	Xbim.Ifc4.Interfaces.IfcElementCompositionEnum? IIfcSpatialStructureElement.CompositionType
	{
		get
		{
			return CompositionType switch
			{
				IfcElementCompositionEnum.COMPLEX => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.COMPLEX, 
				IfcElementCompositionEnum.ELEMENT => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.ELEMENT, 
				IfcElementCompositionEnum.PARTIAL => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.PARTIAL, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.COMPLEX:
				CompositionType = IfcElementCompositionEnum.COMPLEX;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.ELEMENT:
				CompositionType = IfcElementCompositionEnum.ELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.PARTIAL:
				CompositionType = IfcElementCompositionEnum.PARTIAL;
				break;
			case null:
				CompositionType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
	public IfcElementCompositionEnum? CompositionType
	{
		get
		{
			if (_activated)
			{
				return _compositionType;
			}
			Activate();
			return _compositionType;
		}
		set
		{
			SetValue(delegate(IfcElementCompositionEnum? v)
			{
				_compositionType = v;
			}, _compositionType, value, "CompositionType", 9);
		}
	}

	internal IfcSpatialStructureElement(IModel model, int label, bool activated)
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
			_compositionType = (IfcElementCompositionEnum)Enum.Parse(typeof(IfcElementCompositionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialStructureElement other)
	{
		return this == other;
	}
}
