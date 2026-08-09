using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcClosedShell", 161)]
public class IfcClosedShell : IfcConnectedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IIfcClosedShell, IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcShell, IIfcShell, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcClosedShell>
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

	internal IfcClosedShell(IModel model, int label, bool activated)
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

	public bool Equals(IfcClosedShell other)
	{
		return this == other;
	}
}
