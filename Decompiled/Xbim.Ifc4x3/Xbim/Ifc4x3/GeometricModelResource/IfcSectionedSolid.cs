using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSectionedSolid", 1354)]
public abstract class IfcSectionedSolid : IfcSolidModel, IEquatable<IfcSectionedSolid>, IIfcSectionedSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcCurve _directrix;

	private readonly ItemSet<IfcProfileDef> _crossSections;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve Directrix
	{
		get
		{
			if (_activated)
			{
				return _directrix;
			}
			Activate();
			return _directrix;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_directrix = v;
			}, _directrix, value, "Directrix", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 4)]
	public IItemSet<IfcProfileDef> CrossSections
	{
		get
		{
			if (_activated)
			{
				return _crossSections;
			}
			Activate();
			return _crossSections;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSolid), 1)]
	IIfcCurve IIfcSectionedSolid.Directrix
	{
		get
		{
			return Directrix;
		}
		set
		{
			Directrix = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSolid), 2)]
	IItemSet<IIfcProfileDef> IIfcSectionedSolid.CrossSections => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(CrossSections);

	internal IfcSectionedSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSections = new ItemSet<IfcProfileDef>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_directrix = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_crossSections.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionedSolid other)
	{
		return this == other;
	}
}
