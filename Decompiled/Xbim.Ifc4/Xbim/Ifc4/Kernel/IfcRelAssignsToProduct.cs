using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssignsToProduct", 309)]
public class IfcRelAssignsToProduct : IfcRelAssigns, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssignsToProduct, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToProduct>, IExpressValidatable
{
	public enum IfcRelAssignsToProductClause
	{
		NoSelfReference
	}

	private IfcProductSelect _relatingProduct;

	IIfcProductSelect IIfcRelAssignsToProduct.RelatingProduct
	{
		get
		{
			return RelatingProduct;
		}
		set
		{
			RelatingProduct = value as IfcProductSelect;
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

	public bool ValidateClause(IfcRelAssignsToProductClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToProductClause.NoSelfReference)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => RelatingProduct == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToProduct>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToProduct.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToProductClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToProduct.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
