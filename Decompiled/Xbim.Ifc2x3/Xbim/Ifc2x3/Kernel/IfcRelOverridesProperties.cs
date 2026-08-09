using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelOverridesProperties", 248)]
public class IfcRelOverridesProperties : IfcRelDefinesByProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelOverridesProperties>, IExpressValidatable
{
	public enum IfcRelOverridesPropertiesClause
	{
		WR1
	}

	private readonly ItemSet<IfcProperty> _overridingProperties;

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
	public IItemSet<IfcProperty> OverridingProperties
	{
		get
		{
			if (_activated)
			{
				return _overridingProperties;
			}
			Activate();
			return _overridingProperties;
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
			foreach (IfcObject relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingPropertyDefinition != null)
			{
				yield return base.RelatingPropertyDefinition;
			}
			foreach (IfcProperty overridingProperty in OverridingProperties)
			{
				yield return overridingProperty;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObject relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingPropertyDefinition != null)
			{
				yield return base.RelatingPropertyDefinition;
			}
		}
	}

	internal IfcRelOverridesProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_overridingProperties = new ItemSet<IfcProperty>(this, 0, 7);
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
			_overridingProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelOverridesProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelOverridesPropertiesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelOverridesPropertiesClause.WR1)
			{
				result = Functions.SIZEOF(base.RelatedObjects) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelOverridesProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelOverridesProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelOverridesPropertiesClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelOverridesProperties.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
