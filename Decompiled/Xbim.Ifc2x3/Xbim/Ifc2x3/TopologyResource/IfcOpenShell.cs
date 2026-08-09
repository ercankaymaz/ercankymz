using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcOpenShell", 488)]
public class IfcOpenShell : IfcConnectedFaceSet, IIfcOpenShell, IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.TopologyResource.IfcShell, IIfcShell, IInstantiableEntity, IfcShell, IContainsEntityReferences, IEquatable<IfcOpenShell>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFace cfsFace in base.CfsFaces)
			{
				yield return cfsFace;
			}
		}
	}

	internal IfcOpenShell(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcOpenShell other)
	{
		return this == other;
	}
}
