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
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcTypeObject", 42)]
public class IfcTypeObject : IfcObjectDefinition, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTypeObject>, IExpressValidatable
{
	public enum IfcTypeObjectClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _applicableOccurrence;

	private readonly OptionalItemSet<IfcPropertySetDefinition> _hasPropertySets;

	[CrossSchemaAttribute(typeof(IIfcTypeObject), 5)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcTypeObject.ApplicableOccurrence
	{
		get
		{
			if (!ApplicableOccurrence.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(ApplicableOccurrence.Value);
		}
		set
		{
			ApplicableOccurrence = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTypeObject), 6)]
	IItemSet<IIfcPropertySetDefinition> IIfcTypeObject.HasPropertySets => new ProxyItemSet<IfcPropertySetDefinition, IIfcPropertySetDefinition>(HasPropertySets);

	IEnumerable<IIfcRelDefinesByType> IIfcTypeObject.Types => base.Model.Instances.Where((IIfcRelDefinesByType e) => e.RelatingType as IfcTypeObject == this, "RelatingType", this);

	IEnumerable<IIfcRelDefinesByProperties> IIfcTypeObject.DefinedByProperties
	{
		get
		{
			yield break;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ApplicableOccurrence
	{
		get
		{
			if (_activated)
			{
				return _applicableOccurrence;
			}
			Activate();
			return _applicableOccurrence;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_applicableOccurrence = v;
			}, _applicableOccurrence, value, "ApplicableOccurrence", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcPropertySetDefinition> HasPropertySets
	{
		get
		{
			if (_activated)
			{
				return _hasPropertySets;
			}
			Activate();
			return _hasPropertySets;
		}
	}

	[InverseProperty("RelatingType")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 11)]
	public IEnumerable<IfcRelDefinesByType> ObjectTypeOf => base.Model.Instances.Where((IfcRelDefinesByType e) => Equals(e.RelatingType), "RelatingType", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcPropertySetDefinition hasPropertySet in HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	public IEnumerable<IfcPropertySet> PropertySets
	{
		get
		{
			if (HasPropertySets != null)
			{
				return HasPropertySets.OfType<IfcPropertySet>();
			}
			return Enumerable.Empty<IfcPropertySet>();
		}
	}

	public IDictionary<Xbim.Ifc2x3.MeasureResource.IfcLabel, Dictionary<Xbim.Ifc2x3.MeasureResource.IfcIdentifier, Xbim.Ifc2x3.MeasureResource.IfcValue>> PropertySingleValues
	{
		get
		{
			Dictionary<Xbim.Ifc2x3.MeasureResource.IfcLabel, Dictionary<Xbim.Ifc2x3.MeasureResource.IfcIdentifier, Xbim.Ifc2x3.MeasureResource.IfcValue>> dictionary = new Dictionary<Xbim.Ifc2x3.MeasureResource.IfcLabel, Dictionary<Xbim.Ifc2x3.MeasureResource.IfcIdentifier, Xbim.Ifc2x3.MeasureResource.IfcValue>>();
			IOptionalItemSet<IfcPropertySetDefinition> hasPropertySets = HasPropertySets;
			if (hasPropertySets == null)
			{
				return dictionary;
			}
			foreach (IfcPropertySet item in hasPropertySets.OfType<IfcPropertySet>())
			{
				Dictionary<Xbim.Ifc2x3.MeasureResource.IfcIdentifier, Xbim.Ifc2x3.MeasureResource.IfcValue> dictionary2 = new Dictionary<Xbim.Ifc2x3.MeasureResource.IfcIdentifier, Xbim.Ifc2x3.MeasureResource.IfcValue>();
				Xbim.Ifc2x3.MeasureResource.IfcLabel key = item.Name ?? new Xbim.Ifc2x3.MeasureResource.IfcLabel("Undefined");
				foreach (IfcProperty hasProperty in item.HasProperties)
				{
					IfcPropertySingleValue ifcPropertySingleValue = hasProperty as IfcPropertySingleValue;
					if (!(ifcPropertySingleValue == null))
					{
						dictionary2.Add(hasProperty.Name, ifcPropertySingleValue.NominalValue);
					}
				}
				dictionary.Add(key, dictionary2);
			}
			return dictionary;
		}
	}

	public IEnumerable<IfcPhysicalSimpleQuantity> PhysicalSimpleQuantities => ElementQuantities.SelectMany((IfcElementQuantity eq) => eq.Quantities).OfType<IfcPhysicalSimpleQuantity>();

	public IEnumerable<IfcElementQuantity> ElementQuantities
	{
		get
		{
			if (HasPropertySets != null)
			{
				return HasPropertySets.OfType<IfcElementQuantity>();
			}
			return Enumerable.Empty<IfcElementQuantity>();
		}
	}

	internal IfcTypeObject(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasPropertySets = new OptionalItemSet<IfcPropertySetDefinition>(this, 0, 6);
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
			_applicableOccurrence = value.StringVal;
			break;
		case 5:
			_hasPropertySets.InternalAdd((IfcPropertySetDefinition)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTypeObject other)
	{
		return this == other;
	}

	public void AddPropertySet(IfcPropertySetDefinition pSetDefinition)
	{
		HasPropertySets.Add(pSetDefinition);
	}

	public IfcPropertySet GetPropertySet(string pSetName, bool caseSensitive = true)
	{
		if (HasPropertySets == null)
		{
			return null;
		}
		if (!caseSensitive)
		{
			return HasPropertySets.FirstOrDefault((IfcPropertySet r) => string.Equals(r.Name.ToString(), pSetName, StringComparison.CurrentCultureIgnoreCase));
		}
		return HasPropertySets.FirstOrDefault((IfcPropertySet r) => r.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)pSetName);
	}

	public IfcPropertySingleValue GetPropertySingleValue(string pSetName, string propertyName)
	{
		IfcPropertySet propertySet = GetPropertySet(pSetName);
		if (propertySet != null)
		{
			return propertySet.HasProperties.FirstOrDefault((IfcPropertySingleValue p) => p.Name == (Xbim.Ifc2x3.MeasureResource.IfcIdentifier)propertyName);
		}
		return null;
	}

	public Xbim.Ifc2x3.MeasureResource.IfcValue GetPropertySingleValueValue(string pSetName, string propertyName)
	{
		return GetPropertySingleValue(pSetName, propertyName).NominalValue;
	}

	public IfcPropertySingleValue SetPropertySingleValue(string pSetName, string propertyName, Xbim.Ifc2x3.MeasureResource.IfcValue value)
	{
		IfcPropertySet ifcPropertySet = GetPropertySet(pSetName);
		if (ifcPropertySet == null)
		{
			ifcPropertySet = base.Model.Instances.New<IfcPropertySet>();
			ifcPropertySet.Name = pSetName;
			AddPropertySet(ifcPropertySet);
		}
		IfcPropertySingleValue propertySingleValue = GetPropertySingleValue(pSetName, propertyName);
		IfcPropertySingleValue ifcPropertySingleValue;
		if (propertySingleValue != null)
		{
			ifcPropertySingleValue = propertySingleValue;
			propertySingleValue.NominalValue = value;
		}
		else
		{
			ifcPropertySingleValue = base.Model.Instances.New(delegate(IfcPropertySingleValue psv)
			{
				psv.Name = propertyName;
				psv.NominalValue = value;
			});
			ifcPropertySet.HasProperties.Add(ifcPropertySingleValue);
		}
		return ifcPropertySingleValue;
	}

	public IfcPhysicalSimpleQuantity GetElementPhysicalSimpleQuantity(string pSetName, string qualityName)
	{
		IfcElementQuantity elementQuantity = GetElementQuantity(pSetName);
		if (!(elementQuantity != null))
		{
			return null;
		}
		return elementQuantity.Quantities.FirstOrDefault((IfcPhysicalSimpleQuantity sq) => sq.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel)qualityName);
	}

	public IfcElementQuantity GetElementQuantity(string pSetName, bool caseSensitive = true)
	{
		if (HasPropertySets == null)
		{
			return null;
		}
		if (!caseSensitive)
		{
			return HasPropertySets.FirstOrDefault((IfcElementQuantity r) => r.Name.ToString().ToLower() == pSetName.ToLower());
		}
		return HasPropertySets.FirstOrDefault((IfcElementQuantity r) => r.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)pSetName);
	}

	public bool ValidateClause(IfcTypeObjectClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTypeObjectClause.WR1)
			{
				result = Functions.EXISTS(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTypeObject>()?.LogError($"Exception thrown evaluating where-clause 'IfcTypeObject.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTypeObjectClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTypeObject.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
