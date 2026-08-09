using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcFixedReferenceSweptAreaSolid", 1180)]
public class IfcFixedReferenceSweptAreaSolid : IfcDirectrixCurveSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcFixedReferenceSweptAreaSolid>, IIfcFixedReferenceSweptAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcDirection _fixedReference;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcDirection FixedReference
	{
		get
		{
			if (_activated)
			{
				return _fixedReference;
			}
			Activate();
			return _fixedReference;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_fixedReference = v;
			}, _fixedReference, value, "FixedReference", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
			if (FixedReference != null)
			{
				yield return FixedReference;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFixedReferenceSweptAreaSolid), 3)]
	IIfcCurve IIfcFixedReferenceSweptAreaSolid.Directrix
	{
		get
		{
			return base.Directrix;
		}
		set
		{
			base.Directrix = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFixedReferenceSweptAreaSolid), 4)]
	IfcParameterValue? IIfcFixedReferenceSweptAreaSolid.StartParam
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFixedReferenceSweptAreaSolid), 5)]
	IfcParameterValue? IIfcFixedReferenceSweptAreaSolid.EndParam
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFixedReferenceSweptAreaSolid), 6)]
	IIfcDirection IIfcFixedReferenceSweptAreaSolid.FixedReference
	{
		get
		{
			return FixedReference;
		}
		set
		{
			FixedReference = value as IfcDirection;
		}
	}

	internal IfcFixedReferenceSweptAreaSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_fixedReference = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFixedReferenceSweptAreaSolid other)
	{
		return this == other;
	}
}
