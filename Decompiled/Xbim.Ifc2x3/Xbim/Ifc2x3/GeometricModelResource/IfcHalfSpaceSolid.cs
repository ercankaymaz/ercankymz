using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcHalfSpaceSolid", 338)]
public class IfcHalfSpaceSolid : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IfcBooleanOperand, IExpressSelectType, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcHalfSpaceSolid>, IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand
{
	private Xbim.Ifc2x3.GeometryResource.IfcSurface _baseSurface;

	private bool _agreementFlag;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.GeometryResource.IfcSurface BaseSurface
	{
		get
		{
			if (_activated)
			{
				return _baseSurface;
			}
			Activate();
			return _baseSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcSurface v)
			{
				_baseSurface = v;
			}, _baseSurface, value, "BaseSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public bool AgreementFlag
	{
		get
		{
			if (_activated)
			{
				return _agreementFlag;
			}
			Activate();
			return _agreementFlag;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_agreementFlag = v;
			}, _agreementFlag, value, "AgreementFlag", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BaseSurface != null)
			{
				yield return BaseSurface;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcHalfSpaceSolid), 1)]
	IIfcSurface IIfcHalfSpaceSolid.BaseSurface
	{
		get
		{
			return BaseSurface;
		}
		set
		{
			BaseSurface = value as Xbim.Ifc2x3.GeometryResource.IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcHalfSpaceSolid), 2)]
	IfcBoolean IIfcHalfSpaceSolid.AgreementFlag
	{
		get
		{
			return new IfcBoolean(AgreementFlag);
		}
		set
		{
			AgreementFlag = value;
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcHalfSpaceSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_baseSurface = (Xbim.Ifc2x3.GeometryResource.IfcSurface)value.EntityVal;
			break;
		case 1:
			_agreementFlag = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHalfSpaceSolid other)
	{
		return this == other;
	}
}
