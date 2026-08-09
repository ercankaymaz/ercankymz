using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcSubedge", 487)]
public class IfcSubedge : IfcEdge, IInstantiableEntity, IPersistEntity, IPersist, IIfcSubedge, IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSubedge>
{
	private IfcEdge _parentEdge;

	IIfcEdge IIfcSubedge.ParentEdge
	{
		get
		{
			return ParentEdge;
		}
		set
		{
			ParentEdge = value as IfcEdge;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcEdge ParentEdge
	{
		get
		{
			if (_activated)
			{
				return _parentEdge;
			}
			Activate();
			return _parentEdge;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcEdge v)
			{
				_parentEdge = v;
			}, _parentEdge, value, "ParentEdge", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (EdgeStart != null)
			{
				yield return EdgeStart;
			}
			if (EdgeEnd != null)
			{
				yield return EdgeEnd;
			}
			if (ParentEdge != null)
			{
				yield return ParentEdge;
			}
		}
	}

	internal IfcSubedge(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_parentEdge = (IfcEdge)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSubedge other)
	{
		return this == other;
	}
}
