using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcTypeObject", 42)]
public class IfcTypeObject : IfcObjectDefinition, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTypeObject>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _applicableOccurrence;

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
			ApplicableOccurrence = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTypeObject), 6)]
	IItemSet<IIfcPropertySetDefinition> IIfcTypeObject.HasPropertySets => new ProxyItemSet<IfcPropertySetDefinition, IIfcPropertySetDefinition>(HasPropertySets);

	IEnumerable<IIfcRelDefinesByType> IIfcTypeObject.Types => base.Model.Instances.Where((IIfcRelDefinesByType e) => e.RelatingType as IfcTypeObject == this, "RelatingType", this);

	IEnumerable<IIfcRelDefinesByProperties> IIfcTypeObject.DefinedByProperties => base.Model.Instances.Where((IfcRelDefinesByProperties e) => e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? ApplicableOccurrence
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_applicableOccurrence = v;
			}, _applicableOccurrence, value, "ApplicableOccurrence", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 13)]
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
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 14)]
	public IEnumerable<IfcRelDefinesByType> Types => base.Model.Instances.Where((IfcRelDefinesByType e) => Equals(e.RelatingType), "RelatingType", this);

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
}
