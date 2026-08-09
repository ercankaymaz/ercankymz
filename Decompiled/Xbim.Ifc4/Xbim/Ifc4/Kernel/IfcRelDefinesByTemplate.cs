using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelDefinesByTemplate", 1251)]
public class IfcRelDefinesByTemplate : IfcRelDefines, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelDefinesByTemplate, IIfcRelDefines, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByTemplate>
{
	private readonly ItemSet<IfcPropertySetDefinition> _relatedPropertySets;

	private IfcPropertySetTemplate _relatingTemplate;

	IItemSet<IIfcPropertySetDefinition> IIfcRelDefinesByTemplate.RelatedPropertySets => new ProxyItemSet<IfcPropertySetDefinition, IIfcPropertySetDefinition>(RelatedPropertySets);

	IIfcPropertySetTemplate IIfcRelDefinesByTemplate.RelatingTemplate
	{
		get
		{
			return RelatingTemplate;
		}
		set
		{
			RelatingTemplate = value as IfcPropertySetTemplate;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcPropertySetDefinition> RelatedPropertySets
	{
		get
		{
			if (_activated)
			{
				return _relatedPropertySets;
			}
			Activate();
			return _relatedPropertySets;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPropertySetTemplate RelatingTemplate
	{
		get
		{
			if (_activated)
			{
				return _relatingTemplate;
			}
			Activate();
			return _relatingTemplate;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPropertySetTemplate v)
			{
				_relatingTemplate = v;
			}, _relatingTemplate, value, "RelatingTemplate", 6);
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
			foreach (IfcPropertySetDefinition relatedPropertySet in RelatedPropertySets)
			{
				yield return relatedPropertySet;
			}
			if (RelatingTemplate != null)
			{
				yield return RelatingTemplate;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition relatedPropertySet in RelatedPropertySets)
			{
				yield return relatedPropertySet;
			}
			if (RelatingTemplate != null)
			{
				yield return RelatingTemplate;
			}
		}
	}

	internal IfcRelDefinesByTemplate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedPropertySets = new ItemSet<IfcPropertySetDefinition>(this, 0, 5);
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
			_relatedPropertySets.InternalAdd((IfcPropertySetDefinition)value.EntityVal);
			break;
		case 5:
			_relatingTemplate = (IfcPropertySetTemplate)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDefinesByTemplate other)
	{
		return this == other;
	}
}
