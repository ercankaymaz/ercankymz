using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcProjectLibrary", 1229)]
public class IfcProjectLibrary : IfcContext, IInstantiableEntity, IPersistEntity, IPersist, IIfcProjectLibrary, IIfcContext, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcProjectLibrary>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcRepresentationContext representationContext in base.RepresentationContexts)
			{
				yield return representationContext;
			}
			if (base.UnitsInContext != null)
			{
				yield return base.UnitsInContext;
			}
		}
	}

	internal IfcProjectLibrary(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcProjectLibrary other)
	{
		return this == other;
	}
}
