using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcPresentationStyle", 34)]
public abstract class IfcPresentationStyle : PersistEntity, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IEquatable<IfcPresentationStyle>
{
	private IfcLabel? _name;

	IfcLabel? IIfcPresentationStyle.Name
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

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	public IEnumerable<IIfcSurfaceStyle> SurfaceStyles => Enumerable.Empty<IIfcSurfaceStyle>();

	internal IfcPresentationStyle(IModel model, int label, bool activated)
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

	public bool Equals(IfcPresentationStyle other)
	{
		return this == other;
	}
}
