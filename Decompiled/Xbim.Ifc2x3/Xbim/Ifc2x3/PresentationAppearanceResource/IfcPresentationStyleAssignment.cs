using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcPresentationStyleAssignment", 584)]
public class IfcPresentationStyleAssignment : PersistEntity, IIfcPresentationStyleAssignment, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IInstantiableEntity, IEquatable<IfcPresentationStyleAssignment>
{
	private IItemSet<IIfcPresentationStyleSelect> _stylesIfc4;

	private readonly ItemSet<IfcPresentationStyleSelect> _styles;

	[CrossSchemaAttribute(typeof(IIfcPresentationStyleAssignment), 1)]
	IItemSet<IIfcPresentationStyleSelect> IIfcPresentationStyleAssignment.Styles => _stylesIfc4 ?? (_stylesIfc4 = new ExtendedItemSet<IfcPresentationStyleSelect, IIfcPresentationStyleSelect>(Styles, new ItemSet<IIfcPresentationStyleSelect>(this, 0, -1), StylesToIfc4, StylesToIfc2X3));

	public IEnumerable<IIfcSurfaceStyle> SurfaceStyles => Styles.OfType<IfcSurfaceStyle>();

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcPresentationStyleSelect> Styles
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

	private static IIfcPresentationStyleSelect StylesToIfc4(IfcPresentationStyleSelect member)
	{
		if (member == null)
		{
			return null;
		}
		return member.GetType().Name switch
		{
			"IfcCurveStyle" => member as IfcCurveStyle, 
			"IfcSymbolStyle" => default(Xbim.Ifc4.PresentationAppearanceResource.IfcNullStyle), 
			"IfcFillAreaStyle" => member as IfcFillAreaStyle, 
			"IfcTextStyle" => member as IfcTextStyle, 
			"IfcSurfaceStyle" => member as IfcSurfaceStyle, 
			"IfcNullStyle" => null, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static IfcPresentationStyleSelect StylesToIfc2X3(IIfcPresentationStyleSelect member)
	{
		if (member == null)
		{
			return null;
		}
		return member.GetType().Name switch
		{
			"IfcCurveStyle" => member as IfcCurveStyle, 
			"IfcFillAreaStyle" => member as IfcFillAreaStyle, 
			"IfcSurfaceStyle" => member as IfcSurfaceStyle, 
			"IfcTextStyle" => member as IfcTextStyle, 
			"IfcNullStyle" => null, 
			_ => throw new NotSupportedException(), 
		};
	}

	internal IfcPresentationStyleAssignment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcPresentationStyleSelect>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_styles.InternalAdd((IfcPresentationStyleSelect)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPresentationStyleAssignment other)
	{
		return this == other;
	}
}
