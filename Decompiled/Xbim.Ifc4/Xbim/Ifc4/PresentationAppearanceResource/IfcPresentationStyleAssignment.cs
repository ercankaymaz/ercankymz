using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcPresentationStyleAssignment", 584)]
public class IfcPresentationStyleAssignment : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcPresentationStyleAssignment, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IEquatable<IfcPresentationStyleAssignment>
{
	private readonly ItemSet<IfcPresentationStyleSelect> _styles;

	IItemSet<IIfcPresentationStyleSelect> IIfcPresentationStyleAssignment.Styles => new ProxyItemSet<IfcPresentationStyleSelect, IIfcPresentationStyleSelect>(Styles);

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

	public IEnumerable<IIfcSurfaceStyle> SurfaceStyles => Styles.OfType<IfcSurfaceStyle>();

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
