using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcIndexedColourMap", 1189)]
public class IfcIndexedColourMap : IfcPresentationItem, IIfcIndexedColourMap, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcIndexedColourMap>
{
	private IfcTessellatedFaceSet _mappedTo;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _opacity;

	private IfcColourRgbList _colours;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> _colourIndex;

	[CrossSchemaAttribute(typeof(IIfcIndexedColourMap), 1)]
	IIfcTessellatedFaceSet IIfcIndexedColourMap.MappedTo
	{
		get
		{
			return MappedTo;
		}
		set
		{
			MappedTo = value as IfcTessellatedFaceSet;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedColourMap), 2)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcIndexedColourMap.Opacity
	{
		get
		{
			if (!Opacity.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Opacity.Value);
		}
		set
		{
			Opacity = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedColourMap), 3)]
	IIfcColourRgbList IIfcIndexedColourMap.Colours
	{
		get
		{
			return Colours;
		}
		set
		{
			Colours = value as IfcColourRgbList;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedColourMap), 4)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> IIfcIndexedColourMap.ColourIndex => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(ColourIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcTessellatedFaceSet MappedTo
	{
		get
		{
			if (_activated)
			{
				return _mappedTo;
			}
			Activate();
			return _mappedTo;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTessellatedFaceSet v)
			{
				_mappedTo = v;
			}, _mappedTo, value, "MappedTo", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? Opacity
	{
		get
		{
			if (_activated)
			{
				return _opacity;
			}
			Activate();
			return _opacity;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_opacity = v;
			}, _opacity, value, "Opacity", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcColourRgbList Colours
	{
		get
		{
			if (_activated)
			{
				return _colours;
			}
			Activate();
			return _colours;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourRgbList v)
			{
				_colours = v;
			}, _colours, value, "Colours", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> ColourIndex
	{
		get
		{
			if (_activated)
			{
				return _colourIndex;
			}
			Activate();
			return _colourIndex;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (MappedTo != null)
			{
				yield return MappedTo;
			}
			if (Colours != null)
			{
				yield return Colours;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (MappedTo != null)
			{
				yield return MappedTo;
			}
		}
	}

	internal IfcIndexedColourMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_colourIndex = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mappedTo = (IfcTessellatedFaceSet)value.EntityVal;
			break;
		case 1:
			_opacity = value.RealVal;
			break;
		case 2:
			_colours = (IfcColourRgbList)value.EntityVal;
			break;
		case 3:
			_colourIndex.InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedColourMap other)
	{
		return this == other;
	}
}
