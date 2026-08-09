using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcColourSpecification", 28)]
public abstract class IfcColourSpecification : PersistEntity, IIfcColourSpecification, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcColour, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IfcColour, Xbim.Ifc2x3.PresentationAppearanceResource.IfcFillStyleSelect, IfcSymbolStyleSelect, IEquatable<IfcColourSpecification>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	[CrossSchemaAttribute(typeof(IIfcColourSpecification), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcColourSpecification.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	internal IfcColourSpecification(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_name = value.StringVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcColourSpecification other)
	{
		return this == other;
	}
}
