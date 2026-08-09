using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcHalfSpaceSolid", 338)]
public class IfcHalfSpaceSolid : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcHalfSpaceSolid>
{
	private IfcSurface _baseSurface;

	private IfcBoolean _agreementFlag;

	IIfcSurface IIfcHalfSpaceSolid.BaseSurface
	{
		get
		{
			return BaseSurface;
		}
		set
		{
			BaseSurface = value as IfcSurface;
		}
	}

	IfcBoolean IIfcHalfSpaceSolid.AgreementFlag
	{
		get
		{
			return AgreementFlag;
		}
		set
		{
			AgreementFlag = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BaseSurface
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
			SetValue(delegate(IfcSurface v)
			{
				_baseSurface = v;
			}, _baseSurface, value, "BaseSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcBoolean AgreementFlag
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
			SetValue(delegate(IfcBoolean v)
			{
				_agreementFlag = v;
			}, _agreementFlag, value, "AgreementFlag", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => 3L;

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

	internal IfcHalfSpaceSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_baseSurface = (IfcSurface)value.EntityVal;
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
