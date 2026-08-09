using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcEdgeLoop", 302)]
public class IfcEdgeLoop : IfcLoop, IIfcEdgeLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcEdgeLoop>, IExpressValidatable
{
	public enum IfcEdgeLoopClause
	{
		WR1,
		WR2
	}

	private readonly ItemSet<IfcOrientedEdge> _edgeList;

	[CrossSchemaAttribute(typeof(IIfcEdgeLoop), 1)]
	IItemSet<IIfcOrientedEdge> IIfcEdgeLoop.EdgeList => new ProxyItemSet<IfcOrientedEdge, IIfcOrientedEdge>(EdgeList);

	IfcInteger IIfcEdgeLoop.Ne => new IfcInteger(Ne);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcOrientedEdge> EdgeList
	{
		get
		{
			if (_activated)
			{
				return _edgeList;
			}
			Activate();
			return _edgeList;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long Ne => EdgeList.Count;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcOrientedEdge edge in EdgeList)
			{
				yield return edge;
			}
		}
	}

	internal IfcEdgeLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_edgeList = new ItemSet<IfcOrientedEdge>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_edgeList.InternalAdd((IfcOrientedEdge)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcEdgeLoop other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEdgeLoopClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcEdgeLoopClause.WR1:
				result = (object)EdgeList.ItemAt(0L).EdgeStart == EdgeList.ItemAt(Ne - 1).EdgeEnd;
				break;
			case IfcEdgeLoopClause.WR2:
				result = Functions.IfcLoopHeadToTail(this);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEdgeLoop>()?.LogError($"Exception thrown evaluating where-clause 'IfcEdgeLoop.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcEdgeLoopClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEdgeLoop.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcEdgeLoopClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEdgeLoop.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
