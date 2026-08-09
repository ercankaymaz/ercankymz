using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcRelOccupiesSpaces", 324)]
public class IfcRelOccupiesSpaces : IfcRelAssignsToActor, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelOccupiesSpaces>
{
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
			if (base.RelatingActor != null)
			{
				yield return base.RelatingActor;
			}
			if (base.ActingRole != null)
			{
				yield return base.ActingRole;
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
			if (base.RelatingActor != null)
			{
				yield return base.RelatingActor;
			}
		}
	}

	internal IfcRelOccupiesSpaces(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcRelOccupiesSpaces other)
	{
		return this == other;
	}
}
