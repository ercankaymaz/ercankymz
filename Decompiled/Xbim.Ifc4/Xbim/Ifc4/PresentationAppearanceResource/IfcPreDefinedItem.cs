using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcPreDefinedItem", 288)]
public abstract class IfcPreDefinedItem : IfcPresentationItem, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcPreDefinedItem>
{
	private IfcLabel _name;

	IfcLabel IIfcPreDefinedItem.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	internal IfcPreDefinedItem(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedItem other)
	{
		return this == other;
	}
}
