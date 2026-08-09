using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcConnectedFaceSet", 160)]
public class IfcConnectedFaceSet : IfcTopologicalRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcConnectedFaceSet>
{
	private readonly ItemSet<IfcFace> _cfsFaces;

	IItemSet<IIfcFace> IIfcConnectedFaceSet.CfsFaces => new ProxyItemSet<IfcFace, IIfcFace>(CfsFaces);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcFace> CfsFaces
	{
		get
		{
			if (_activated)
			{
				return _cfsFaces;
			}
			Activate();
			return _cfsFaces;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFace cfsFace in CfsFaces)
			{
				yield return cfsFace;
			}
		}
	}

	internal IfcConnectedFaceSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_cfsFaces = new ItemSet<IfcFace>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_cfsFaces.InternalAdd((IfcFace)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcConnectedFaceSet other)
	{
		return this == other;
	}
}
