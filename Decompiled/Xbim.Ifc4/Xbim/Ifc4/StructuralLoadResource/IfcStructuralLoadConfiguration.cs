using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadConfiguration", 1282)]
public class IfcStructuralLoadConfiguration : IfcStructuralLoad, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadConfiguration, IIfcStructuralLoad, IContainsEntityReferences, IEquatable<IfcStructuralLoadConfiguration>, IExpressValidatable
{
	public enum IfcStructuralLoadConfigurationClause
	{
		ValidListSize
	}

	private readonly ItemSet<IfcStructuralLoadOrResult> _values;

	private readonly OptionalItemSet<IItemSet<IfcLengthMeasure>> _locations;

	IItemSet<IIfcStructuralLoadOrResult> IIfcStructuralLoadConfiguration.Values => new ProxyItemSet<IfcStructuralLoadOrResult, IIfcStructuralLoadOrResult>(Values);

	IItemSet<IItemSet<IfcLengthMeasure>> IIfcStructuralLoadConfiguration.Locations => Locations;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcStructuralLoadOrResult> Values
	{
		get
		{
			if (_activated)
			{
				return _values;
			}
			Activate();
			return _values;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 1 }, new int[] { -1, 2 }, 3)]
	public IOptionalItemSet<IItemSet<IfcLengthMeasure>> Locations
	{
		get
		{
			if (_activated)
			{
				return _locations;
			}
			Activate();
			return _locations;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcStructuralLoadOrResult value in Values)
			{
				yield return value;
			}
		}
	}

	internal IfcStructuralLoadConfiguration(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_values = new ItemSet<IfcStructuralLoadOrResult>(this, 0, 2);
		_locations = new OptionalItemSet<IItemSet<IfcLengthMeasure>>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_values.InternalAdd((IfcStructuralLoadOrResult)value.EntityVal);
			break;
		case 2:
			((ItemSet<IfcLengthMeasure>)_locations.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadConfiguration other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralLoadConfigurationClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralLoadConfigurationClause.ValidListSize)
			{
				result = !Functions.EXISTS(Locations) || Functions.SIZEOF(Locations) == Functions.SIZEOF(Values);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralLoadConfiguration>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralLoadConfiguration.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcStructuralLoadConfigurationClause.ValidListSize))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLoadConfiguration.ValidListSize",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
