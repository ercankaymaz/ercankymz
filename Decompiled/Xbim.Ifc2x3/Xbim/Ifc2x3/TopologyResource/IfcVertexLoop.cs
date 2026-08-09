using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcVertexLoop", 244)]
public class IfcVertexLoop : IfcLoop, IIfcVertexLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcVertexLoop>
{
	private IfcVertex _loopVertex;

	[CrossSchemaAttribute(typeof(IIfcVertexLoop), 1)]
	IIfcVertex IIfcVertexLoop.LoopVertex
	{
		get
		{
			return LoopVertex;
		}
		set
		{
			LoopVertex = value as IfcVertex;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcVertex LoopVertex
	{
		get
		{
			if (_activated)
			{
				return _loopVertex;
			}
			Activate();
			return _loopVertex;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVertex v)
			{
				_loopVertex = v;
			}, _loopVertex, value, "LoopVertex", 1);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (LoopVertex != null)
			{
				yield return LoopVertex;
			}
		}
	}

	internal IfcVertexLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_loopVertex = (IfcVertex)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcVertexLoop other)
	{
		return this == other;
	}
}
