using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelDefinesByProperties", 247)]
public class IfcRelDefinesByProperties : IfcRelDefines, IIfcRelDefinesByProperties, IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByProperties>
{
	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	private IfcPropertySetDefinitionSelect _relatingPropertyDefinition;

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByProperties), 5)]
	IItemSet<IIfcObjectDefinition> IIfcRelDefinesByProperties.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(RelatedObjects);

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByProperties), 6)]
	IIfcPropertySetDefinitionSelect IIfcRelDefinesByProperties.RelatingPropertyDefinition
	{
		get
		{
			if (RelatingPropertyDefinition == null)
			{
				return null;
			}
			IfcPropertySetDefinition ifcPropertySetDefinition = RelatingPropertyDefinition as IfcPropertySetDefinition;
			if (ifcPropertySetDefinition != null)
			{
				return ifcPropertySetDefinition;
			}
			if (RelatingPropertyDefinition is IfcPropertySetDefinitionSet ifcPropertySetDefinitionSet)
			{
				return ifcPropertySetDefinitionSet;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingPropertyDefinition = null;
				return;
			}
			IfcPropertySetDefinition ifcPropertySetDefinition = value as IfcPropertySetDefinition;
			if (ifcPropertySetDefinition != null)
			{
				RelatingPropertyDefinition = ifcPropertySetDefinition;
			}
			else if (value is Xbim.Ifc4.Kernel.IfcPropertySetDefinitionSet)
			{
				throw new NotImplementedException();
			}
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
			foreach (IfcPropertySetDefinition propertySetDefinition in RelatingPropertyDefinition.PropertySetDefinitions)
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
			foreach (IfcPropertySetDefinition propertySetDefinition in RelatingPropertyDefinition.PropertySetDefinitions)
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
