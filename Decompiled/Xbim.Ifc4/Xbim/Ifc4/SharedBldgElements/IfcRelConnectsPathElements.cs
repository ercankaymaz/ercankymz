using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcRelConnectsPathElements", 668)]
public class IfcRelConnectsPathElements : IfcRelConnectsElements, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelConnectsPathElements, IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsPathElements>, IExpressValidatable
{
	public enum IfcRelConnectsPathElementsClause
	{
		NormalizedRelatingPriorities,
		NormalizedRelatedPriorities
	}

	private readonly ItemSet<IfcInteger> _relatingPriorities;

	private readonly ItemSet<IfcInteger> _relatedPriorities;

	private IfcConnectionTypeEnum _relatedConnectionType;

	private IfcConnectionTypeEnum _relatingConnectionType;

	IItemSet<IfcInteger> IIfcRelConnectsPathElements.RelatingPriorities => RelatingPriorities;

	IItemSet<IfcInteger> IIfcRelConnectsPathElements.RelatedPriorities => RelatedPriorities;

	IfcConnectionTypeEnum IIfcRelConnectsPathElements.RelatedConnectionType
	{
		get
		{
			return RelatedConnectionType;
		}
		set
		{
			RelatedConnectionType = value;
		}
	}

	IfcConnectionTypeEnum IIfcRelConnectsPathElements.RelatingConnectionType
	{
		get
		{
			return RelatingConnectionType;
		}
		set
		{
			RelatingConnectionType = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 8)]
	public IItemSet<IfcInteger> RelatingPriorities
	{
		get
		{
			if (_activated)
			{
				return _relatingPriorities;
			}
			Activate();
			return _relatingPriorities;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 9)]
	public IItemSet<IfcInteger> RelatedPriorities
	{
		get
		{
			if (_activated)
			{
				return _relatedPriorities;
			}
			Activate();
			return _relatedPriorities;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcConnectionTypeEnum RelatedConnectionType
	{
		get
		{
			if (_activated)
			{
				return _relatedConnectionType;
			}
			Activate();
			return _relatedConnectionType;
		}
		set
		{
			SetValue(delegate(IfcConnectionTypeEnum v)
			{
				_relatedConnectionType = v;
			}, _relatedConnectionType, value, "RelatedConnectionType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcConnectionTypeEnum RelatingConnectionType
	{
		get
		{
			if (_activated)
			{
				return _relatingConnectionType;
			}
			Activate();
			return _relatingConnectionType;
		}
		set
		{
			SetValue(delegate(IfcConnectionTypeEnum v)
			{
				_relatingConnectionType = v;
			}, _relatingConnectionType, value, "RelatingConnectionType", 11);
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
			if (base.ConnectionGeometry != null)
			{
				yield return base.ConnectionGeometry;
			}
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
		}
	}

	internal IfcRelConnectsPathElements(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatingPriorities = new ItemSet<IfcInteger>(this, 0, 8);
		_relatedPriorities = new ItemSet<IfcInteger>(this, 0, 9);
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_relatingPriorities.InternalAdd(value.IntegerVal);
			break;
		case 8:
			_relatedPriorities.InternalAdd(value.IntegerVal);
			break;
		case 9:
			_relatedConnectionType = (IfcConnectionTypeEnum)Enum.Parse(typeof(IfcConnectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_relatingConnectionType = (IfcConnectionTypeEnum)Enum.Parse(typeof(IfcConnectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsPathElements other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelConnectsPathElementsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRelConnectsPathElementsClause.NormalizedRelatingPriorities:
				result = Functions.SIZEOF(RelatingPriorities) == 0 || Functions.SIZEOF(Enumerable.Where(RelatingPriorities, (IfcInteger temp) => 0 <= (long)temp && (long)temp <= 100)) == Functions.SIZEOF(RelatingPriorities);
				break;
			case IfcRelConnectsPathElementsClause.NormalizedRelatedPriorities:
				result = Functions.SIZEOF(RelatedPriorities) == 0 || Functions.SIZEOF(Enumerable.Where(RelatedPriorities, (IfcInteger temp) => 0 <= (long)temp && (long)temp <= 100)) == Functions.SIZEOF(RelatedPriorities);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelConnectsPathElements>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelConnectsPathElements.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelConnectsPathElementsClause.NormalizedRelatingPriorities))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelConnectsPathElements.NormalizedRelatingPriorities",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelConnectsPathElementsClause.NormalizedRelatedPriorities))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelConnectsPathElements.NormalizedRelatedPriorities",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
