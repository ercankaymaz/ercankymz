using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyle", 260)]
public class IfcSurfaceStyle : IfcPresentationStyle, IIfcSurfaceStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcSurfaceStyle>
{
	private IfcSurfaceSide _side;

	private readonly ItemSet<IfcSurfaceStyleElementSelect> _styles;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyle), 2)]
	Xbim.Ifc4.Interfaces.IfcSurfaceSide IIfcSurfaceStyle.Side
	{
		get
		{
			return Side switch
			{
				IfcSurfaceSide.BOTH => Xbim.Ifc4.Interfaces.IfcSurfaceSide.BOTH, 
				IfcSurfaceSide.NEGATIVE => Xbim.Ifc4.Interfaces.IfcSurfaceSide.NEGATIVE, 
				IfcSurfaceSide.POSITIVE => Xbim.Ifc4.Interfaces.IfcSurfaceSide.POSITIVE, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.POSITIVE:
				Side = IfcSurfaceSide.POSITIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.NEGATIVE:
				Side = IfcSurfaceSide.NEGATIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.BOTH:
				Side = IfcSurfaceSide.BOTH;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyle), 3)]
	IItemSet<IIfcSurfaceStyleElementSelect> IIfcSurfaceStyle.Styles => new ProxyItemSet<IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect>(Styles);

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcSurfaceSide Side
	{
		get
		{
			if (_activated)
			{
				return _side;
			}
			Activate();
			return _side;
		}
		set
		{
			SetValue(delegate(IfcSurfaceSide v)
			{
				_side = v;
			}, _side, value, "Side", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 5 }, 3)]
	public IItemSet<IfcSurfaceStyleElementSelect> Styles
	{
		get
		{
			if (_activated)
			{
				return _styles;
			}
			Activate();
			return _styles;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceStyleElementSelect style in Styles)
			{
				yield return style;
			}
		}
	}

	internal IfcSurfaceStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcSurfaceStyleElementSelect>(this, 5, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_side = (IfcSurfaceSide)Enum.Parse(typeof(IfcSurfaceSide), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_styles.InternalAdd((IfcSurfaceStyleElementSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyle other)
	{
		return this == other;
	}
}
