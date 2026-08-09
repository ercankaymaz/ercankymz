using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.SharedInfrastructureElements;

[ExpressType("IfcGeoslice", 1444)]
public class IfcGeoslice : IfcGeotechnicalAssembly, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGeoslice>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcGeoslice(IModel model, int label, bool activated)
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

	public bool Equals(IfcGeoslice other)
	{
		return this == other;
	}
}
