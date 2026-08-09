using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcLine", 272)]
public class IfcLine : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcLine>, IIfcLine, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect
{
	private IfcCartesianPoint _pnt;

	private IfcVector _dir;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint Pnt
	{
		get
		{
			if (_activated)
			{
				return _pnt;
			}
			Activate();
			return _pnt;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_pnt = v;
			}, _pnt, value, "Pnt", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcVector Dir
	{
		get
		{
			if (_activated)
			{
				return _dir;
			}
			Activate();
			return _dir;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVector v)
			{
				_dir = v;
			}, _dir, value, "Dir", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Pnt != null)
			{
				yield return Pnt;
			}
			if (Dir != null)
			{
				yield return Dir;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLine), 1)]
	IIfcCartesianPoint IIfcLine.Pnt
	{
		get
		{
			return Pnt;
		}
		set
		{
			Pnt = value as IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLine), 2)]
	IIfcVector IIfcLine.Dir
	{
		get
		{
			return Dir;
		}
		set
		{
			Dir = value as IfcVector;
		}
	}

	internal IfcLine(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_pnt = (IfcCartesianPoint)value.EntityVal;
			break;
		case 1:
			_dir = (IfcVector)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLine other)
	{
		return this == other;
	}
}
