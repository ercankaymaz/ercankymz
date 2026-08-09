using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.QuantityResource;

[ExpressType("IfcPhysicalComplexQuantity", 604)]
public class IfcPhysicalComplexQuantity : IfcPhysicalQuantity, IInstantiableEntity, IPersistEntity, IPersist, IIfcPhysicalComplexQuantity, IIfcPhysicalQuantity, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPhysicalComplexQuantity>, IExpressValidatable
{
	public enum IfcPhysicalComplexQuantityClause
	{
		NoSelfReference,
		UniqueQuantityNames
	}

	private readonly ItemSet<IfcPhysicalQuantity> _hasQuantities;

	private IfcLabel _discrimination;

	private IfcLabel? _quality;

	private IfcLabel? _usage;

	IItemSet<IIfcPhysicalQuantity> IIfcPhysicalComplexQuantity.HasQuantities => new ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>(HasQuantities);

	IfcLabel IIfcPhysicalComplexQuantity.Discrimination
	{
		get
		{
			return Discrimination;
		}
		set
		{
			Discrimination = value;
		}
	}

	IfcLabel? IIfcPhysicalComplexQuantity.Quality
	{
		get
		{
			return Quality;
		}
		set
		{
			Quality = value;
		}
	}

	IfcLabel? IIfcPhysicalComplexQuantity.Usage
	{
		get
		{
			return Usage;
		}
		set
		{
			Usage = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcPhysicalQuantity> HasQuantities
	{
		get
		{
			if (_activated)
			{
				return _hasQuantities;
			}
			Activate();
			return _hasQuantities;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLabel Discrimination
	{
		get
		{
			if (_activated)
			{
				return _discrimination;
			}
			Activate();
			return _discrimination;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_discrimination = v;
			}, _discrimination, value, "Discrimination", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? Quality
	{
		get
		{
			if (_activated)
			{
				return _quality;
			}
			Activate();
			return _quality;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_quality = v;
			}, _quality, value, "Quality", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLabel? Usage
	{
		get
		{
			if (_activated)
			{
				return _usage;
			}
			Activate();
			return _usage;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_usage = v;
			}, _usage, value, "Usage", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcPhysicalQuantity hasQuantity in HasQuantities)
			{
				yield return hasQuantity;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPhysicalQuantity hasQuantity in HasQuantities)
			{
				yield return hasQuantity;
			}
		}
	}

	internal IfcPhysicalComplexQuantity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasQuantities = new ItemSet<IfcPhysicalQuantity>(this, 0, 3);
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
			_hasQuantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
			break;
		case 3:
			_discrimination = value.StringVal;
			break;
		case 4:
			_quality = value.StringVal;
			break;
		case 5:
			_usage = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPhysicalComplexQuantity other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPhysicalComplexQuantityClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPhysicalComplexQuantityClause.NoSelfReference:
				result = Functions.SIZEOF(Enumerable.Where(HasQuantities, (IfcPhysicalQuantity temp) => (object)this == temp)) == 0;
				break;
			case IfcPhysicalComplexQuantityClause.UniqueQuantityNames:
				result = Functions.IfcUniqueQuantityNames(HasQuantities);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPhysicalComplexQuantity>()?.LogError($"Exception thrown evaluating where-clause 'IfcPhysicalComplexQuantity.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPhysicalComplexQuantityClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPhysicalComplexQuantity.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPhysicalComplexQuantityClause.UniqueQuantityNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPhysicalComplexQuantity.UniqueQuantityNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
