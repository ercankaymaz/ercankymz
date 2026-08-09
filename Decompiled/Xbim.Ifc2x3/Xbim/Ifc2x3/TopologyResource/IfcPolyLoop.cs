using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcPolyLoop", 200)]
public class IfcPolyLoop : IfcLoop, IIfcPolyLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPolyLoop>, IExpressValidatable
{
	public enum IfcPolyLoopClause
	{
		WR21
	}

	private readonly ItemSet<IfcCartesianPoint> _polygon;

	[CrossSchemaAttribute(typeof(IIfcPolyLoop), 1)]
	IItemSet<IIfcCartesianPoint> IIfcPolyLoop.Polygon => new ProxyItemSet<IfcCartesianPoint, IIfcCartesianPoint>(Polygon);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 3)]
	public IItemSet<IfcCartesianPoint> Polygon
	{
		get
		{
			if (_activated)
			{
				return _polygon;
			}
			Activate();
			return _polygon;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint item in Polygon)
			{
				yield return item;
			}
		}
	}

	internal IfcPolyLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_polygon = new ItemSet<IfcCartesianPoint>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_polygon.InternalAdd((IfcCartesianPoint)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPolyLoop other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPolyLoopClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPolyLoopClause.WR21)
			{
				result = Functions.SIZEOF(Enumerable.Where(Polygon, (IfcCartesianPoint Temp) => Temp.Dim != Polygon.ItemAt(0L).Dim)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPolyLoop>()?.LogError($"Exception thrown evaluating where-clause 'IfcPolyLoop.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPolyLoopClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPolyLoop.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
