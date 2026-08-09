using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPcurve", 1220)]
public class IfcPcurve : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IfcCurveOnSurface, IExpressSelectType, IIfcCurveOnSurface, IContainsEntityReferences, IEquatable<IfcPcurve>, IIfcPcurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IfcGeometricSetSelect, IIfcGeometricSetSelect, Xbim.Ifc4.GeometryResource.IfcCurveOnSurface
{
	private IfcSurface _basisSurface;

	private IfcCurve _referenceCurve;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BasisSurface
	{
		get
		{
			if (_activated)
			{
				return _basisSurface;
			}
			Activate();
			return _basisSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCurve ReferenceCurve
	{
		get
		{
			if (_activated)
			{
				return _referenceCurve;
			}
			Activate();
			return _referenceCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_referenceCurve = v;
			}, _referenceCurve, value, "ReferenceCurve", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisSurface != null)
			{
				yield return BasisSurface;
			}
			if (ReferenceCurve != null)
			{
				yield return ReferenceCurve;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPcurve), 1)]
	IIfcSurface IIfcPcurve.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPcurve), 2)]
	IIfcCurve IIfcPcurve.ReferenceCurve
	{
		get
		{
			return ReferenceCurve;
		}
		set
		{
			ReferenceCurve = value as IfcCurve;
		}
	}

	internal IfcPcurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcSurface)value.EntityVal;
			break;
		case 1:
			_referenceCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPcurve other)
	{
		return this == other;
	}
}
