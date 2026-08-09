using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelDefinesByProperties", 247)]
public class IfcRelDefinesByProperties : IfcRelDefines, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelDefinesByProperties, IIfcRelDefines, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByProperties>
{
	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	private IfcPropertySetDefinitionSelect _relatingPropertyDefinition;

	IItemSet<IIfcObjectDefinition> IIfcRelDefinesByProperties.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(RelatedObjects);

	IIfcPropertySetDefinitionSelect IIfcRelDefinesByProperties.RelatingPropertyDefinition
	{
		get
		{
			return RelatingPropertyDefinition;
		}
		set
		{
			RelatingPropertyDefinition = value as IfcPropertySetDefinitionSelect;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcObjectDefinition> RelatedObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedObjects;
			}
			Activate();
			return _relatedObjects;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPropertySetDefinitionSelect RelatingPropertyDefinition
	{
		get
		{
			if (_activated)
			{
				return _relatingPropertyDefinition;
			}
			Activate();
			return _relatingPropertyDefinition;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPropertySetDefinitionSelect v)
			{
				_relatingPropertyDefinition = v;
			}, _relatingPropertyDefinition, value, "RelatingPropertyDefinition", 6);
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
			foreach (IfcObjectDefinition relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingPropertyDefinition == null)
			{
				yield break;
			}
			foreach (IIfcPropertySetDefinition propertySetDefinition in RelatingPropertyDefinition.PropertySetDefinitions)
			{
				yield return propertySetDefinition;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingPropertyDefinition == null)
			{
				yield break;
			}
			foreach (IIfcPropertySetDefinition propertySetDefinition in RelatingPropertyDefinition.PropertySetDefinitions)
			{
				yield return propertySetDefinition;
			}
		}
	}

	internal IfcRelDefinesByProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObjectDefinition>(this, 0, 5);
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
			_relatedObjects.InternalAdd((IfcObjectDefinition)value.EntityVal);
			break;
		case 5:
			_relatingPropertyDefinition = (IfcPropertySetDefinitionSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDefinesByProperties other)
	{
		return this == other;
	}
}
