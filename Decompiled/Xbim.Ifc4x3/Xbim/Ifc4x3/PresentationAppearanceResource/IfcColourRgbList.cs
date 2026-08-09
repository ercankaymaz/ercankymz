using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcColourRgbList", 1125)]
public class IfcColourRgbList : IfcPresentationItem, IIfcColourRgbList, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcColourRgbList>
{
	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure>> _colourList;

	[CrossSchemaAttribute(typeof(IIfcColourRgbList), 1)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure>> IIfcColourRgbList.ColourList => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure, Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure>(ColourList, (Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure s) => new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(s), (Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(t));

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 1)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure>> ColourList
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
		_colourList = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure>>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure>)_colourList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcColourRgbList other)
	{
		return this == other;
	}
}
