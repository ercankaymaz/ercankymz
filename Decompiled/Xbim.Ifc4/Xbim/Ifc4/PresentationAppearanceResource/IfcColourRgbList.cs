using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcColourRgbList", 1125)]
public class IfcColourRgbList : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcColourRgbList, IIfcPresentationItem, IEquatable<IfcColourRgbList>
{
	private readonly ItemSet<IItemSet<IfcNormalisedRatioMeasure>> _colourList;

	IItemSet<IItemSet<IfcNormalisedRatioMeasure>> IIfcColourRgbList.ColourList => ColourList;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 1)]
	public IItemSet<IItemSet<IfcNormalisedRatioMeasure>> ColourList
	{
		get
		{
			if (_activated)
			{
				return _colourList;
			}
			Activate();
			return _colourList;
		}
	}

	internal IfcColourRgbList(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_colourList = new ItemSet<IItemSet<IfcNormalisedRatioMeasure>>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			((ItemSet<IfcNormalisedRatioMeasure>)_colourList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcColourRgbList other)
	{
		return this == other;
	}
}
