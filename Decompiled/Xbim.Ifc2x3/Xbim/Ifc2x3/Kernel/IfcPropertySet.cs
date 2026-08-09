using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcPropertySet", 666)]
public class IfcPropertySet : IfcPropertySetDefinition, IIfcPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertySet>, IExpressValidatable
{
	public enum IfcPropertySetClause
	{
		WR31,
		WR32
	}

	private readonly ItemSet<IfcProperty> _hasProperties;

	[CrossSchemaAttribute(typeof(IIfcPropertySet), 5)]
	IItemSet<IIfcProperty> IIfcPropertySet.HasProperties => new ProxyItemSet<IfcProperty, IIfcProperty>(HasProperties);

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 8)]
	public IItemSet<IfcProperty> HasProperties
	{
		get
		{
			if (_activated)
			{
				return _hasProperties;
			}
			Activate();
			return _hasProperties;
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
			foreach (IfcProperty hasProperty in HasProperties)
			{
				yield return hasProperty;
			}
		}
	}

	internal IfcPropertySet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasProperties = new ItemSet<IfcProperty>(this, 0, 5);
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
			_hasProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertySet other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertySetClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPropertySetClause.WR31:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcPropertySetClause.WR32:
				result = Functions.IfcUniquePropertyName(HasProperties);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertySet>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertySet.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertySetClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertySet.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertySetClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertySet.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
