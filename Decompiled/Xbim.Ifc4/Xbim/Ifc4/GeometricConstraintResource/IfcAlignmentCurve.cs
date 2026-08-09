using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignmentCurve", 1347)]
public class IfcAlignmentCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignmentCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAlignmentCurve>
{
	private IfcAlignment2DHorizontal _horizontal;

	private IfcAlignment2DVertical _vertical;

	private IfcLabel? _tag;

	IIfcAlignment2DHorizontal IIfcAlignmentCurve.Horizontal
	{
		get
		{
			return Horizontal;
		}
		set
		{
			Horizontal = value as IfcAlignment2DHorizontal;
		}
	}

	IIfcAlignment2DVertical IIfcAlignmentCurve.Vertical
	{
		get
		{
			return Vertical;
		}
		set
		{
			Vertical = value as IfcAlignment2DVertical;
		}
	}

	IfcLabel? IIfcAlignmentCurve.Tag
	{
		get
		{
			return Tag;
		}
		set
		{
			Tag = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcAlignment2DHorizontal Horizontal
	{
		get
		{
			if (_activated)
			{
				return _horizontal;
			}
			Activate();
			return _horizontal;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAlignment2DHorizontal v)
			{
				_horizontal = v;
			}, _horizontal, value, "Horizontal", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcAlignment2DVertical Vertical
	{
		get
		{
			if (_activated)
			{
				return _vertical;
			}
			Activate();
			return _vertical;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAlignment2DVertical v)
			{
				_vertical = v;
			}, _vertical, value, "Vertical", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? Tag
	{
		get
		{
			if (_activated)
			{
				return _tag;
			}
			Activate();
			return _tag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Horizontal != null)
			{
				yield return Horizontal;
			}
			if (Vertical != null)
			{
				yield return Vertical;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (Horizontal != null)
			{
				yield return Horizontal;
			}
			if (Vertical != null)
			{
				yield return Vertical;
			}
		}
	}

	internal IfcAlignmentCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_horizontal = (IfcAlignment2DHorizontal)value.EntityVal;
			break;
		case 1:
			_vertical = (IfcAlignment2DVertical)value.EntityVal;
			break;
		case 2:
			_tag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignmentCurve other)
	{
		return this == other;
	}
}
