using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcConnectionCurveGeometry", 590)]
public class IfcConnectionCurveGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionCurveGeometry>, IIfcConnectionCurveGeometry, IIfcConnectionGeometry
{
	private IfcCurveOrEdgeCurve _curveOnRelatingElement;

	private IfcCurveOrEdgeCurve _curveOnRelatedElement;

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

	[CrossSchemaAttribute(typeof(IIfcConnectionCurveGeometry), 1)]
	IIfcCurveOrEdgeCurve IIfcConnectionCurveGeometry.CurveOnRelatingElement
	{
		get
		{
			if (CurveOnRelatingElement == null)
			{
				return null;
			}
			IfcBoundedCurve ifcBoundedCurve = CurveOnRelatingElement as IfcBoundedCurve;
			if (ifcBoundedCurve != null)
			{
				return ifcBoundedCurve;
			}
			IfcEdgeCurve ifcEdgeCurve = CurveOnRelatingElement as IfcEdgeCurve;
			if (ifcEdgeCurve != null)
			{
				return ifcEdgeCurve;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveOnRelatingElement = null;
				return;
			}
			IfcBoundedCurve ifcBoundedCurve = value as IfcBoundedCurve;
			if (ifcBoundedCurve != null)
			{
				CurveOnRelatingElement = ifcBoundedCurve;
				return;
			}
			IfcEdgeCurve ifcEdgeCurve = value as IfcEdgeCurve;
			if (ifcEdgeCurve != null)
			{
				CurveOnRelatingElement = ifcEdgeCurve;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionCurveGeometry), 2)]
	IIfcCurveOrEdgeCurve IIfcConnectionCurveGeometry.CurveOnRelatedElement
	{
		get
		{
			if (CurveOnRelatedElement == null)
			{
				return null;
			}
			IfcBoundedCurve ifcBoundedCurve = CurveOnRelatedElement as IfcBoundedCurve;
			if (ifcBoundedCurve != null)
			{
				return ifcBoundedCurve;
			}
			IfcEdgeCurve ifcEdgeCurve = CurveOnRelatedElement as IfcEdgeCurve;
			if (ifcEdgeCurve != null)
			{
				return ifcEdgeCurve;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveOnRelatedElement = null;
				return;
			}
			IfcBoundedCurve ifcBoundedCurve = value as IfcBoundedCurve;
			if (ifcBoundedCurve != null)
			{
				CurveOnRelatedElement = ifcBoundedCurve;
				return;
			}
			IfcEdgeCurve ifcEdgeCurve = value as IfcEdgeCurve;
			if (ifcEdgeCurve != null)
			{
				CurveOnRelatedElement = ifcEdgeCurve;
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
