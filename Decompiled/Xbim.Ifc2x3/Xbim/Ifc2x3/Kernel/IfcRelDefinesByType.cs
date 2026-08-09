using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelDefinesByType", 206)]
public class IfcRelDefinesByType : IfcRelDefines, IIfcRelDefinesByType, IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByType>
{
	private IfcTypeObject _relatingType;

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByType), 5)]
	IItemSet<IIfcObject> IIfcRelDefinesByType.RelatedObjects => new ProxyItemSet<IfcObject, IIfcObject>(base.RelatedObjects);

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByType), 6)]
	IIfcTypeObject IIfcRelDefinesByType.RelatingType
	{
		get
		{
			return RelatingType;
		}
		set
		{
			RelatingType = value as IfcTypeObject;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcTypeObject RelatingType
	{
		get
		{
			if (_activated)
			{
				return _relatingType;
			}
			Activate();
			return _relatingType;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTypeObject v)
			{
				_relatingType = v;
			}, _relatingType, value, "RelatingType", 6);
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
			if (RelatingType != null)
			{
				yield return RelatingType;
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
			if (RelatingType != null)
			{
				yield return RelatingType;
			}
		}
	}

	internal IfcRelDefinesByType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingType = (IfcTypeObject)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDefinesByType other)
	{
		return this == other;
	}
}
