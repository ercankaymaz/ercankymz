using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcOrientedEdge", 596)]
public class IfcOrientedEdge : IfcEdge, IInstantiableEntity, IPersistEntity, IPersist, IIfcOrientedEdge, IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcOrientedEdge>, IExpressValidatable
{
	public enum IfcOrientedEdgeClause
	{
		EdgeElementNotOriented
	}

	private IfcEdge _edgeElement;

	private IfcBoolean _orientation;

	IIfcEdge IIfcOrientedEdge.EdgeElement
	{
		get
		{
			return EdgeElement;
		}
		set
		{
			EdgeElement = value as IfcEdge;
		}
	}

	IfcBoolean IIfcOrientedEdge.Orientation
	{
		get
		{
			return Orientation;
		}
		set
		{
			Orientation = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcEdge EdgeElement
	{
		get
		{
			if (_activated)
			{
				return _edgeElement;
			}
			Activate();
			return _edgeElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcEdge v)
			{
				_edgeElement = v;
			}, _edgeElement, value, "EdgeElement", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcBoolean Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 4);
		}
	}

	[EntityAttribute(1, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcVertex EdgeStart
	{
		get
		{
			if (!Orientation)
			{
				return EdgeElement.EdgeEnd;
			}
			return EdgeElement.EdgeStart;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property EdgeStart in IfcOrientedEdge");
		}
	}

	[EntityAttribute(2, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcVertex EdgeEnd
	{
		get
		{
			if (!Orientation)
			{
				return EdgeElement.EdgeStart;
			}
			return EdgeElement.EdgeEnd;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property EdgeEnd in IfcOrientedEdge");
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
			if (EdgeElement != null)
			{
				yield return EdgeElement;
			}
		}
	}

	internal IfcOrientedEdge(IModel model, int label, bool activated)
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
			_edgeElement = (IfcEdge)value.EntityVal;
			break;
		case 3:
			_orientation = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOrientedEdge other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcOrientedEdgeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcOrientedEdgeClause.EdgeElementNotOriented)
			{
				result = !Functions.TYPEOF(EdgeElement).Contains("IFC4.IFCORIENTEDEDGE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcOrientedEdge>()?.LogError($"Exception thrown evaluating where-clause 'IfcOrientedEdge.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcOrientedEdgeClause.EdgeElementNotOriented))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcOrientedEdge.EdgeElementNotOriented",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
