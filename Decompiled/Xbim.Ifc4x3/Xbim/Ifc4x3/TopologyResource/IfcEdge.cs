using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcEdge", 202)]
public class IfcEdge : IfcTopologicalRepresentationItem, IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcEdge>
{
	private IfcVertex _edgeStart;

	private IfcVertex _edgeEnd;

	[CrossSchemaAttribute(typeof(IIfcEdge), 1)]
	IIfcVertex IIfcEdge.EdgeStart
	{
		get
		{
			return EdgeStart;
		}
		set
		{
			EdgeStart = value as IfcVertex;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEdge), 2)]
	IIfcVertex IIfcEdge.EdgeEnd
	{
		get
		{
			return EdgeEnd;
		}
		set
		{
			EdgeEnd = value as IfcVertex;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public virtual IfcVertex EdgeStart
	{
		get
		{
			if (_activated)
			{
				return _edgeStart;
			}
			Activate();
			return _edgeStart;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVertex v)
			{
				_edgeStart = v;
			}, _edgeStart, value, "EdgeStart", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public virtual IfcVertex EdgeEnd
	{
		get
		{
			if (_activated)
			{
				return _edgeEnd;
			}
			Activate();
			return _edgeEnd;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVertex v)
			{
				_edgeEnd = v;
			}, _edgeEnd, value, "EdgeEnd", 2);
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
		}
	}

	internal IfcEdge(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_edgeStart = (IfcVertex)value.EntityVal;
			break;
		case 1:
			_edgeEnd = (IfcVertex)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEdge other)
	{
		return this == other;
	}
}
