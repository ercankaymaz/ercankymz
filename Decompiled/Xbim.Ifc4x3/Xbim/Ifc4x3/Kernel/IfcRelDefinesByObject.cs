using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelDefinesByObject", 1250)]
public class IfcRelDefinesByObject : IfcRelDefines, IIfcRelDefinesByObject, IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByObject>
{
	private readonly ItemSet<IfcObject> _relatedObjects;

	private IfcObject _relatingObject;

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByObject), 5)]
	IItemSet<IIfcObject> IIfcRelDefinesByObject.RelatedObjects => new ProxyItemSet<IfcObject, IIfcObject>(RelatedObjects);

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByObject), 6)]
	IIfcObject IIfcRelDefinesByObject.RelatingObject
	{
		get
		{
			return RelatingObject;
		}
		set
		{
			RelatingObject = value as IfcObject;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcObject> RelatedObjects
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
	public IfcObject RelatingObject
	{
		get
		{
			if (_activated)
			{
				return _relatingObject;
			}
			Activate();
			return _relatingObject;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObject v)
			{
				_relatingObject = v;
			}, _relatingObject, value, "RelatingObject", 6);
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
			foreach (IfcObject relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingObject != null)
			{
				yield return RelatingObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObject relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingObject != null)
			{
				yield return RelatingObject;
			}
		}
	}

	internal IfcRelDefinesByObject(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObject>(this, 0, 5);
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
			_relatedObjects.InternalAdd((IfcObject)value.EntityVal);
			break;
		case 5:
			_relatingObject = (IfcObject)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDefinesByObject other)
	{
		return this == other;
	}
}
