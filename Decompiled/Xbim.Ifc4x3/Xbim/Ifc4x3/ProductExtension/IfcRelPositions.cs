using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelPositions", 1479)]
public class IfcRelPositions : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelPositions>
{
	private IfcPositioningElement _relatingPositioningElement;

	private readonly ItemSet<IfcProduct> _relatedProducts;

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcPositioningElement RelatingPositioningElement
	{
		get
		{
			if (_activated)
			{
				return _relatingPositioningElement;
			}
			Activate();
			return _relatingPositioningElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPositioningElement v)
			{
				_relatingPositioningElement = v;
			}, _relatingPositioningElement, value, "RelatingPositioningElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcProduct> RelatedProducts
	{
		get
		{
			if (_activated)
			{
				return _relatedProducts;
			}
			Activate();
			return _relatedProducts;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (RelatingPositioningElement != null)
			{
				yield return RelatingPositioningElement;
			}
			foreach (IfcProduct relatedProduct in RelatedProducts)
			{
				yield return relatedProduct;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingPositioningElement != null)
			{
				yield return RelatingPositioningElement;
			}
			foreach (IfcProduct relatedProduct in RelatedProducts)
			{
				yield return relatedProduct;
			}
		}
	}

	internal IfcRelPositions(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedProducts = new ItemSet<IfcProduct>(this, 0, 6);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingPositioningElement = (IfcPositioningElement)value.EntityVal;
			break;
		case 5:
			_relatedProducts.InternalAdd((IfcProduct)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelPositions other)
	{
		return this == other;
	}
}
