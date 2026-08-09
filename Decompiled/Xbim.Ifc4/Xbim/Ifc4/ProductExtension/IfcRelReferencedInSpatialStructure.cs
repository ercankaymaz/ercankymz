using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelReferencedInSpatialStructure", 455)]
public class IfcRelReferencedInSpatialStructure : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelReferencedInSpatialStructure, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelReferencedInSpatialStructure>, IExpressValidatable
{
	public enum IfcRelReferencedInSpatialStructureClause
	{
		WR31
	}

	private readonly ItemSet<IfcProduct> _relatedElements;

	private IfcSpatialElement _relatingStructure;

	IItemSet<IIfcProduct> IIfcRelReferencedInSpatialStructure.RelatedElements => new ProxyItemSet<IfcProduct, IIfcProduct>(RelatedElements);

	IIfcSpatialElement IIfcRelReferencedInSpatialStructure.RelatingStructure
	{
		get
		{
			return RelatingStructure;
		}
		set
		{
			RelatingStructure = value as IfcSpatialElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcProduct> RelatedElements
	{
		get
		{
			if (_activated)
			{
				return _relatedElements;
			}
			Activate();
			return _relatedElements;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcSpatialElement RelatingStructure
	{
		get
		{
			if (_activated)
			{
				return _relatingStructure;
			}
			Activate();
			return _relatingStructure;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialElement v)
			{
				_relatingStructure = v;
			}, _relatingStructure, value, "RelatingStructure", 6);
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
			foreach (IfcProduct relatedElement in RelatedElements)
			{
				yield return relatedElement;
			}
			if (RelatingStructure != null)
			{
				yield return RelatingStructure;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcProduct relatedElement in RelatedElements)
			{
				yield return relatedElement;
			}
			if (RelatingStructure != null)
			{
				yield return RelatingStructure;
			}
		}
	}

	internal IfcRelReferencedInSpatialStructure(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedElements = new ItemSet<IfcProduct>(this, 0, 5);
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
			_relatedElements.InternalAdd((IfcProduct)value.EntityVal);
			break;
		case 5:
			_relatingStructure = (IfcSpatialElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelReferencedInSpatialStructure other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelReferencedInSpatialStructureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelReferencedInSpatialStructureClause.WR31)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedElements, (IfcProduct temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCSPATIALSTRUCTUREELEMENT"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelReferencedInSpatialStructure>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelReferencedInSpatialStructure.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelReferencedInSpatialStructureClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelReferencedInSpatialStructure.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
