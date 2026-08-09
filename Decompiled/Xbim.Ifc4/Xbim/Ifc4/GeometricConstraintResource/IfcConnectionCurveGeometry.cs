using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcConnectionCurveGeometry", 590)]
public class IfcConnectionCurveGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IIfcConnectionCurveGeometry, IIfcConnectionGeometry, IContainsEntityReferences, IEquatable<IfcConnectionCurveGeometry>
{
	private IfcCurveOrEdgeCurve _curveOnRelatingElement;

	private IfcCurveOrEdgeCurve _curveOnRelatedElement;

	IIfcCurveOrEdgeCurve IIfcConnectionCurveGeometry.CurveOnRelatingElement
	{
		get
		{
			return CurveOnRelatingElement;
		}
		set
		{
			CurveOnRelatingElement = value as IfcCurveOrEdgeCurve;
		}
	}

	IIfcCurveOrEdgeCurve IIfcConnectionCurveGeometry.CurveOnRelatedElement
	{
		get
		{
			return CurveOnRelatedElement;
		}
		set
		{
			CurveOnRelatedElement = value as IfcCurveOrEdgeCurve;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcCurveOrEdgeCurve CurveOnRelatingElement
	{
		get
		{
			if (_activated)
			{
				return _curveOnRelatingElement;
			}
			Activate();
			return _curveOnRelatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveOrEdgeCurve v)
			{
				_curveOnRelatingElement = v;
			}, _curveOnRelatingElement, value, "CurveOnRelatingElement", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCurveOrEdgeCurve CurveOnRelatedElement
	{
		get
		{
			if (_activated)
			{
				return _curveOnRelatedElement;
			}
			Activate();
			return _curveOnRelatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveOrEdgeCurve v)
			{
				_curveOnRelatedElement = v;
			}, _curveOnRelatedElement, value, "CurveOnRelatedElement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (CurveOnRelatingElement != null)
			{
				yield return CurveOnRelatingElement;
			}
			if (CurveOnRelatedElement != null)
			{
				yield return CurveOnRelatedElement;
			}
		}
	}

	internal IfcConnectionCurveGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_curveOnRelatingElement = (IfcCurveOrEdgeCurve)value.EntityVal;
			break;
		case 1:
			_curveOnRelatedElement = (IfcCurveOrEdgeCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionCurveGeometry other)
	{
		return this == other;
	}
}
