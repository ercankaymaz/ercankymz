using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcSurfaceCurve", 1327)]
public class IfcSurfaceCurve : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOnSurface, IIfcCurveOnSurface, IContainsEntityReferences, IEquatable<IfcSurfaceCurve>
{
	private IfcCurve _curve3D;

	private readonly ItemSet<IfcPcurve> _associatedGeometry;

	private IfcPreferredSurfaceCurveRepresentation _masterRepresentation;

	IIfcCurve IIfcSurfaceCurve.Curve3D
	{
		get
		{
			return Curve3D;
		}
		set
		{
			Curve3D = value as IfcCurve;
		}
	}

	IItemSet<IIfcPcurve> IIfcSurfaceCurve.AssociatedGeometry => new ProxyItemSet<IfcPcurve, IIfcPcurve>(AssociatedGeometry);

	IfcPreferredSurfaceCurveRepresentation IIfcSurfaceCurve.MasterRepresentation
	{
		get
		{
			return MasterRepresentation;
		}
		set
		{
			MasterRepresentation = value;
		}
	}

	List<IIfcSurface> IIfcSurfaceCurve.BasisSurface => new List<IIfcSurface>(BasisSurface);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve Curve3D
	{
		get
		{
			if (_activated)
			{
				return _curve3D;
			}
			Activate();
			return _curve3D;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_curve3D = v;
			}, _curve3D, value, "Curve3D", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { 2 }, 4)]
	public IItemSet<IfcPcurve> AssociatedGeometry
	{
		get
		{
			if (_activated)
			{
				return _associatedGeometry;
			}
			Activate();
			return _associatedGeometry;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcPreferredSurfaceCurveRepresentation MasterRepresentation
	{
		get
		{
			if (_activated)
			{
				return _masterRepresentation;
			}
			Activate();
			return _masterRepresentation;
		}
		set
		{
			SetValue(delegate(IfcPreferredSurfaceCurveRepresentation v)
			{
				_masterRepresentation = v;
			}, _masterRepresentation, value, "MasterRepresentation", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 2 }, 0)]
	public List<IfcSurface> BasisSurface
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Curve3D != null)
			{
				yield return Curve3D;
			}
			foreach (IfcPcurve item in AssociatedGeometry)
			{
				yield return item;
			}
		}
	}

	internal IfcSurfaceCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_associatedGeometry = new ItemSet<IfcPcurve>(this, 2, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_curve3D = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_associatedGeometry.InternalAdd((IfcPcurve)value.EntityVal);
			break;
		case 2:
			_masterRepresentation = (IfcPreferredSurfaceCurveRepresentation)Enum.Parse(typeof(IfcPreferredSurfaceCurveRepresentation), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceCurve other)
	{
		return this == other;
	}
}
