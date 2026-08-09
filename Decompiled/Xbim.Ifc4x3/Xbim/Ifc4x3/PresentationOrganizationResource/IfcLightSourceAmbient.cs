using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcLightSourceAmbient", 756)]
public class IfcLightSourceAmbient : IfcLightSource, IIfcLightSourceAmbient, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcLightSourceAmbient>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.LightColour != null)
			{
				yield return base.LightColour;
			}
		}
	}

	internal IfcLightSourceAmbient(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcLightSourceAmbient other)
	{
		return this == other;
	}
}
