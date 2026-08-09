using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssignsToProduct", 309)]
public class IfcRelAssignsToProduct : IfcRelAssigns, IIfcRelAssignsToProduct, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToProduct>
{
	private IfcProductSelect _relatingProduct;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToProduct), 7)]
	IIfcProductSelect IIfcRelAssignsToProduct.RelatingProduct
	{
		get
		{
			if (RelatingProduct == null)
			{
				return null;
			}
			IfcProduct ifcProduct = RelatingProduct as IfcProduct;
			if (ifcProduct != null)
			{
				return ifcProduct;
			}
			IfcTypeProduct ifcTypeProduct = RelatingProduct as IfcTypeProduct;
			if (ifcTypeProduct != null)
			{
				return ifcTypeProduct;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingProduct = null;
				return;
			}
			IfcProduct ifcProduct = value as IfcProduct;
			if (ifcProduct != null)
			{
				RelatingProduct = ifcProduct;
				return;
			}
			IfcTypeProduct ifcTypeProduct = value as IfcTypeProduct;
			if (ifcTypeProduct != null)
			{
				RelatingProduct = ifcTypeProduct;
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProductSelect RelatingProduct
	{
		get
		{
			if (_activated)
			{
				return _relatingProduct;
			}
			Activate();
			return _relatingProduct;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProductSelect v)
			{
				_relatingProduct = v;
			}, _relatingProduct, value, "RelatingProduct", 7);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingProduct != null)
			{
				yield return RelatingProduct;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingProduct != null)
			{
				yield return RelatingProduct;
			}
		}
	}

	internal IfcRelAssignsToProduct(IModel model, int label, bool activated)
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
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_relatingProduct = (IfcProductSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToProduct other)
	{
		return this == other;
	}
}
