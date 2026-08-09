using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;
using Xbim.Ifc4x3.GeometricConstraintResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcClosedShell", 161)]
public class IfcClosedShell : IfcConnectedFaceSet, IIfcClosedShell, IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.TopologyResource.IfcShell, IIfcShell, Xbim.Ifc4.GeometricConstraintResource.IfcSolidOrShell, IIfcSolidOrShell, IInstantiableEntity, IfcShell, Xbim.Ifc4x3.GeometricConstraintResource.IfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcClosedShell>
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
