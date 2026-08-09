using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAggregates", 631)]
public class IfcRelAggregates : IfcRelDecomposes, IIfcRelAggregates, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAggregates>
{
	[CrossSchemaAttribute(typeof(IIfcRelAggregates), 5)]
	IIfcObjectDefinition IIfcRelAggregates.RelatingObject
	{
		get
		{
			return base.RelatingObject;
		}
		set
		{
			base.RelatingObject = value as IfcObjectDefinition;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelAggregates), 6)]
	IItemSet<IIfcObjectDefinition> IIfcRelAggregates.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(base.RelatedObjects);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.RelatingObject != null)
			{
				yield return base.RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingObject != null)
			{
				yield return base.RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAggregates(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 5u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcRelAggregates other)
	{
		return this == other;
	}
}
