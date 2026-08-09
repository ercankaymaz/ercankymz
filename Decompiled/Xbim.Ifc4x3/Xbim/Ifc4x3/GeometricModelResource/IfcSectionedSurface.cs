using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSectionedSurface", 1484)]
public class IfcSectionedSurface : IfcSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSectionedSurface>
{
	private IfcCurve _directrix;

	private readonly ItemSet<IfcAxis2PlacementLinear> _crossSectionPositions;

	private readonly ItemSet<IfcProfileDef> _crossSections;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve Directrix
	{
		get
		{
			if (_activated)
			{
				return _directrix;
			}
			Activate();
			return _directrix;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_directrix = v;
			}, _directrix, value, "Directrix", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 4)]
	public IItemSet<IfcAxis2PlacementLinear> CrossSectionPositions
	{
		get
		{
			if (_activated)
			{
				return _crossSectionPositions;
			}
			Activate();
			return _crossSectionPositions;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcProfileDef> CrossSections
	{
		get
		{
			if (_activated)
			{
				return _crossSections;
			}
			Activate();
			return _crossSections;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Directrix != null)
			{
				yield return Directrix;
			}
			foreach (IfcAxis2PlacementLinear crossSectionPosition in CrossSectionPositions)
			{
				yield return crossSectionPosition;
			}
			foreach (IfcProfileDef crossSection in CrossSections)
			{
				yield return crossSection;
			}
		}
	}

	internal IfcSectionedSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSectionPositions = new ItemSet<IfcAxis2PlacementLinear>(this, 0, 2);
		_crossSections = new ItemSet<IfcProfileDef>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_crossSectionPositions.InternalAdd((IfcAxis2PlacementLinear)value.EntityVal);
			break;
		case 2:
			_crossSections.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionedSurface other)
	{
		return this == other;
	}
}
