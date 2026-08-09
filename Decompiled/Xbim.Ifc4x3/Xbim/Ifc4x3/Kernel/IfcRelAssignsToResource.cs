using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssignsToResource", 9)]
public class IfcRelAssignsToResource : IfcRelAssigns, IIfcRelAssignsToResource, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToResource>
{
	private IfcResourceSelect _relatingResource;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToResource), 7)]
	IIfcResourceSelect IIfcRelAssignsToResource.RelatingResource
	{
		get
		{
			if (RelatingResource == null)
			{
				return null;
			}
			IfcResource ifcResource = RelatingResource as IfcResource;
			if (ifcResource != null)
			{
				return ifcResource;
			}
			IfcTypeResource ifcTypeResource = RelatingResource as IfcTypeResource;
			if (ifcTypeResource != null)
			{
				return ifcTypeResource;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingResource = null;
				return;
			}
			IfcResource ifcResource = value as IfcResource;
			if (ifcResource != null)
			{
				RelatingResource = ifcResource;
				return;
			}
			IfcTypeResource ifcTypeResource = value as IfcTypeResource;
			if (ifcTypeResource != null)
			{
				RelatingResource = ifcTypeResource;
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcResourceSelect RelatingResource
	{
		get
		{
			if (_activated)
			{
				return _relatingResource;
			}
			Activate();
			return _relatingResource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcResourceSelect v)
			{
				_relatingResource = v;
			}, _relatingResource, value, "RelatingResource", 7);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingResource != null)
			{
				yield return RelatingResource;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingResource != null)
			{
				yield return RelatingResource;
			}
		}
	}

	internal IfcRelAssignsToResource(IModel model, int label, bool activated)
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
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_relatingResource = (IfcResourceSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToResource other)
	{
		return this == other;
	}
}
