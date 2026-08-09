using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcDirectrixDerivedReferenceSweptAreaSolid", 1431)]
public class IfcDirectrixDerivedReferenceSweptAreaSolid : IfcFixedReferenceSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcDirectrixDerivedReferenceSweptAreaSolid>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
			if (base.FixedReference != null)
			{
				yield return base.FixedReference;
			}
		}
	}

	internal IfcDirectrixDerivedReferenceSweptAreaSolid(IModel model, int label, bool activated)
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

	public bool Equals(IfcDirectrixDerivedReferenceSweptAreaSolid other)
	{
		return this == other;
	}
}
