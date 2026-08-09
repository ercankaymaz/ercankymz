using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcComplexProperty", 379)]
public class IfcComplexProperty : IfcProperty, IIfcComplexProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcComplexProperty>, IExpressValidatable
{
	public enum IfcComplexPropertyClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _usageName;

	private readonly ItemSet<IfcProperty> _hasProperties;

	[CrossSchemaAttribute(typeof(IIfcComplexProperty), 3)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier IIfcComplexProperty.UsageName
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(UsageName);
		}
		set
		{
			UsageName = new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcComplexProperty), 4)]
	IItemSet<IIfcProperty> IIfcComplexProperty.HasProperties => new ProxyItemSet<IfcProperty, IIfcProperty>(HasProperties);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier UsageName
	{
		get
		{
			if (_activated)
			{
				return _usageName;
			}
			Activate();
			return _usageName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_usageName = v;
			}, _usageName, value, "UsageName", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
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
			foreach (IfcProperty hasProperty in HasProperties)
			{
				yield return hasProperty;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcProperty hasProperty in HasProperties)
			{
				yield return hasProperty;
			}
		}
	}

	internal IfcComplexProperty(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasProperties = new ItemSet<IfcProperty>(this, 0, 4);
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
			_usageName = value.StringVal;
			break;
		case 3:
			_hasProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcComplexProperty other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcComplexPropertyClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcComplexPropertyClause.WR21:
				result = Functions.SIZEOF(Enumerable.Where(HasProperties, (IfcProperty temp) => (object)this == temp)) == 0;
				break;
			case IfcComplexPropertyClause.WR22:
				result = Functions.IfcUniquePropertyName(HasProperties);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcComplexProperty>()?.LogError($"Exception thrown evaluating where-clause 'IfcComplexProperty.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcComplexPropertyClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcComplexProperty.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcComplexPropertyClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcComplexProperty.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
