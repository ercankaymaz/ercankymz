using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcElementQuantity", 458)]
public class IfcElementQuantity : IfcQuantitySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcElementQuantity, IIfcQuantitySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcElementQuantity>, IExpressValidatable
{
	public enum IfcElementQuantityClause
	{
		UniqueQuantityNames
	}

	private IfcLabel? _methodOfMeasurement;

	private readonly ItemSet<IfcPhysicalQuantity> _quantities;

	IfcLabel? IIfcElementQuantity.MethodOfMeasurement
	{
		get
		{
			return MethodOfMeasurement;
		}
		set
		{
			MethodOfMeasurement = value;
		}
	}

	IItemSet<IIfcPhysicalQuantity> IIfcElementQuantity.Quantities => new ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>(Quantities);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel? MethodOfMeasurement
	{
		get
		{
			if (_activated)
			{
				return _methodOfMeasurement;
			}
			Activate();
			return _methodOfMeasurement;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_methodOfMeasurement = v;
			}, _methodOfMeasurement, value, "MethodOfMeasurement", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<IfcPhysicalQuantity> Quantities
	{
		get
		{
			if (_activated)
			{
				return _quantities;
			}
			Activate();
			return _quantities;
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
			foreach (IfcPhysicalQuantity quantity in Quantities)
			{
				yield return quantity;
			}
		}
	}

	internal IfcElementQuantity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_quantities = new ItemSet<IfcPhysicalQuantity>(this, 0, 6);
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
			_methodOfMeasurement = value.StringVal;
			break;
		case 5:
			_quantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElementQuantity other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcElementQuantityClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcElementQuantityClause.UniqueQuantityNames)
			{
				result = Functions.IfcUniqueQuantityNames(Quantities);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcElementQuantity>()?.LogError($"Exception thrown evaluating where-clause 'IfcElementQuantity.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcElementQuantityClause.UniqueQuantityNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcElementQuantity.UniqueQuantityNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
