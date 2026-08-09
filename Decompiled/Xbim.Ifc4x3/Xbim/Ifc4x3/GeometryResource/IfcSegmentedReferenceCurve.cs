using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcSegmentedReferenceCurve", 1486)]
public class IfcSegmentedReferenceCurve : IfcCompositeCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSegmentedReferenceCurve>
{
	private IfcBoundedCurve _baseCurve;

	private IfcPlacement _endPoint;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcBoundedCurve BaseCurve
	{
		get
		{
			if (_activated)
			{
				return _baseCurve;
			}
			Activate();
			return _baseCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundedCurve v)
			{
				_baseCurve = v;
			}, _baseCurve, value, "BaseCurve", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPlacement EndPoint
	{
		get
		{
			if (_activated)
			{
				return _endPoint;
			}
			Activate();
			return _endPoint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPlacement v)
			{
				_endPoint = v;
			}, _endPoint, value, "EndPoint", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSegment segment in base.Segments)
			{
				yield return segment;
			}
			if (BaseCurve != null)
			{
				yield return BaseCurve;
			}
			if (EndPoint != null)
			{
				yield return EndPoint;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	internal IfcSegmentedReferenceCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_baseCurve = (IfcBoundedCurve)value.EntityVal;
			break;
		case 3:
			_endPoint = (IfcPlacement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSegmentedReferenceCurve other)
	{
		return this == other;
	}
}
