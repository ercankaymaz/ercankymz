using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelContainedInSpatialStructure", 559)]
public class IfcRelContainedInSpatialStructure : IfcRelConnects, IIfcRelContainedInSpatialStructure, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelContainedInSpatialStructure>, IExpressValidatable
{
	public enum IfcRelContainedInSpatialStructureClause
	{
		WR31
	}

	private readonly ItemSet<IfcProduct> _relatedElements;

	private IfcSpatialStructureElement _relatingStructure;

	[CrossSchemaAttribute(typeof(IIfcRelContainedInSpatialStructure), 5)]
	IItemSet<IIfcProduct> IIfcRelContainedInSpatialStructure.RelatedElements => new ProxyItemSet<IfcProduct, IIfcProduct>(RelatedElements);

	[CrossSchemaAttribute(typeof(IIfcRelContainedInSpatialStructure), 6)]
	IIfcSpatialElement IIfcRelContainedInSpatialStructure.RelatingStructure
	{
		get
		{
			return RelatingStructure;
		}
		set
		{
			RelatingStructure = value as IfcSpatialStructureElement;
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
	public IfcSpatialStructureElement RelatingStructure
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
			SetValue(delegate(IfcSpatialStructureElement v)
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

	internal IfcRelContainedInSpatialStructure(IModel model, int label, bool activated)
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
			_relatingStructure = (IfcSpatialStructureElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelContainedInSpatialStructure other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelContainedInSpatialStructureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelContainedInSpatialStructureClause.WR31)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedElements, (IfcProduct temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCSPATIALSTRUCTUREELEMENT"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelContainedInSpatialStructure>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelContainedInSpatialStructure.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelContainedInSpatialStructureClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelContainedInSpatialStructure.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
