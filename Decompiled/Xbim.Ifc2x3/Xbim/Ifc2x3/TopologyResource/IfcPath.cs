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
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcPath", 771)]
public class IfcPath : IfcTopologicalRepresentationItem, IIfcPath, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPath>, IExpressValidatable
{
	public enum IfcPathClause
	{
		WR1
	}

	private readonly ItemSet<IfcOrientedEdge> _edgeList;

	[CrossSchemaAttribute(typeof(IIfcPath), 1)]
	IItemSet<IIfcOrientedEdge> IIfcPath.EdgeList => new ProxyItemSet<IfcOrientedEdge, IIfcOrientedEdge>(EdgeList);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
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

	internal IfcPath(IModel model, int label, bool activated)
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

	public bool Equals(IfcPath other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPathClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPathClause.WR1)
			{
				result = Functions.IfcPathHeadToTail(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPath>()?.LogError($"Exception thrown evaluating where-clause 'IfcPath.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPathClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPath.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
