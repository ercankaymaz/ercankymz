using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcTriangulatedIrregularNetwork", 1357)]
public class IfcTriangulatedIrregularNetwork : IfcTriangulatedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTriangulatedIrregularNetwork>, IIfcTriangulatedIrregularNetwork, IIfcTriangulatedFaceSet, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _flags;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 10)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> Flags
	{
		get
		{
			if (_activated)
			{
				return _flags;
			}
			Activate();
			return _flags;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Coordinates != null)
			{
				yield return base.Coordinates;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTriangulatedIrregularNetwork), 6)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcTriangulatedIrregularNetwork.Flags => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(Flags, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	internal IfcTriangulatedIrregularNetwork(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_flags = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 6);
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
			_flags.InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTriangulatedIrregularNetwork other)
	{
		return this == other;
	}
}
