using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssignsToProduct", 309)]
public class IfcRelAssignsToProduct : IfcRelAssigns, IIfcRelAssignsToProduct, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToProduct>, IExpressValidatable
{
	public enum IfcRelAssignsToProductClause
	{
		WR1
	}

	private IIfcProductSelect _relatingProduct4;

	private IfcProduct _relatingProduct;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToProduct), 7)]
	IIfcProductSelect IIfcRelAssignsToProduct.RelatingProduct
	{
		get
		{
			return _relatingProduct4 ?? RelatingProduct;
		}
		set
		{
			if (value == null)
			{
				RelatingProduct = null;
				if (_relatingProduct4 != null)
				{
					SetValue(delegate(IIfcProductSelect v)
					{
						_relatingProduct4 = v;
					}, _relatingProduct4, null, "RelatingProduct", -7);
				}
				return;
			}
			IfcProduct ifcProduct = value as IfcProduct;
			if (ifcProduct != null)
			{
				RelatingProduct = ifcProduct;
				if (_relatingProduct4 != null)
				{
					SetValue(delegate(IIfcProductSelect v)
					{
						_relatingProduct4 = v;
					}, _relatingProduct4, null, "RelatingProduct", -7);
				}
			}
			else
			{
				if (RelatingProduct != null)
				{
					RelatingProduct = null;
				}
				SetValue(delegate(IIfcProductSelect v)
				{
					_relatingProduct4 = v;
				}, _relatingProduct4, value, "RelatingProduct", -7);
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProduct RelatingProduct
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
			SetValue(delegate(IfcProduct v)
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
			_relatingProduct = (IfcProduct)value.EntityVal;
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
			if (clause == IfcRelAssignsToProductClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingProduct == Temp)) == 0;
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
		if (!ValidateClause(IfcRelAssignsToProductClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToProduct.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
