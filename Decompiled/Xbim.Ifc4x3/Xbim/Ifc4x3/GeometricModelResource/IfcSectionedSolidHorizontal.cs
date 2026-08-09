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
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSectionedSolidHorizontal", 1355)]
public class IfcSectionedSolidHorizontal : IfcSectionedSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSectionedSolidHorizontal>, IIfcSectionedSolidHorizontal, IIfcSectionedSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private readonly ItemSet<IfcAxis2PlacementLinear> _crossSectionPositions;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcAxis2PlacementLinear> CrossSectionPositions
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
			foreach (IfcAxis2PlacementLinear crossSectionPosition in CrossSectionPositions)
			{
				yield return crossSectionPosition;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSolidHorizontal), 3)]
	IItemSet<IIfcDistanceExpression> IIfcSectionedSolidHorizontal.CrossSectionPositions
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSolidHorizontal), 4)]
	IfcBoolean IIfcSectionedSolidHorizontal.FixedAxisVertical
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

	internal IfcSectionedSolidHorizontal(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSectionPositions = new ItemSet<IfcAxis2PlacementLinear>(this, 0, 3);
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
			_crossSectionPositions.InternalAdd((IfcAxis2PlacementLinear)value.EntityVal);
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
