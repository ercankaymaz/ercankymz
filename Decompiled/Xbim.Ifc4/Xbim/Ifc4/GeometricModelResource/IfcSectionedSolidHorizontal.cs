using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.ProfileResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSectionedSolidHorizontal", 1355)]
public class IfcSectionedSolidHorizontal : IfcSectionedSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcSectionedSolidHorizontal, IIfcSectionedSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcSectionedSolidHorizontal>
{
	private readonly ItemSet<IfcDistanceExpression> _crossSectionPositions;

	private IfcBoolean _fixedAxisVertical;

	IItemSet<IIfcDistanceExpression> IIfcSectionedSolidHorizontal.CrossSectionPositions => new ProxyItemSet<IfcDistanceExpression, IIfcDistanceExpression>(CrossSectionPositions);

	IfcBoolean IIfcSectionedSolidHorizontal.FixedAxisVertical
	{
		get
		{
			return FixedAxisVertical;
		}
		set
		{
			FixedAxisVertical = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcDistanceExpression> CrossSectionPositions
	{
		get
		{
			if (_activated)
			{
				return _crossSectionPositions;
			}
			Activate();
			return _crossSectionPositions;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcBoolean FixedAxisVertical
	{
		get
		{
			if (_activated)
			{
				return _fixedAxisVertical;
			}
			Activate();
			return _fixedAxisVertical;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_fixedAxisVertical = v;
			}, _fixedAxisVertical, value, "FixedAxisVertical", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
			foreach (IfcProfileDef crossSection in base.CrossSections)
			{
				yield return crossSection;
			}
			foreach (IfcDistanceExpression crossSectionPosition in CrossSectionPositions)
			{
				yield return crossSectionPosition;
			}
		}
	}

	internal IfcSectionedSolidHorizontal(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSectionPositions = new ItemSet<IfcDistanceExpression>(this, 0, 3);
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
			_crossSectionPositions.InternalAdd((IfcDistanceExpression)value.EntityVal);
			break;
		case 3:
			_fixedAxisVertical = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionedSolidHorizontal other)
	{
		return this == other;
	}
}
