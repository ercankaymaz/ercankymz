using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcTriangulatedIrregularNetwork", 1357)]
public class IfcTriangulatedIrregularNetwork : IfcTriangulatedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IIfcTriangulatedIrregularNetwork, IIfcTriangulatedFaceSet, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcTriangulatedIrregularNetwork>
{
	private readonly ItemSet<IfcInteger> _flags;

	IItemSet<IfcInteger> IIfcTriangulatedIrregularNetwork.Flags => Flags;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 10)]
	public IItemSet<IfcInteger> Flags
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

	internal IfcTriangulatedIrregularNetwork(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_flags = new ItemSet<IfcInteger>(this, 0, 6);
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
