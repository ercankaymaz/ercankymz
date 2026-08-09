using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcLocalPlacement", 481)]
public class IfcLocalPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcLocalPlacement, IIfcObjectPlacement, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLocalPlacement>, IExpressValidatable
{
	public enum IfcLocalPlacementClause
	{
		WR21
	}

	private IfcObjectPlacement _placementRelTo;

	private IfcAxis2Placement _relativePlacement;

	IIfcObjectPlacement IIfcLocalPlacement.PlacementRelTo
	{
		get
		{
			return PlacementRelTo;
		}
		set
		{
			PlacementRelTo = value as IfcObjectPlacement;
		}
	}

	IIfcAxis2Placement IIfcLocalPlacement.RelativePlacement
	{
		get
		{
			return RelativePlacement;
		}
		set
		{
			RelativePlacement = value as IfcAxis2Placement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcObjectPlacement PlacementRelTo
	{
		get
		{
			if (_activated)
			{
				return _placementRelTo;
			}
			Activate();
			return _placementRelTo;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectPlacement v)
			{
				_placementRelTo = v;
			}, _placementRelTo, value, "PlacementRelTo", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcAxis2Placement RelativePlacement
	{
		get
		{
			if (_activated)
			{
				return _relativePlacement;
			}
			Activate();
			return _relativePlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_relativePlacement = v;
			}, _relativePlacement, value, "RelativePlacement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (PlacementRelTo != null)
			{
				yield return PlacementRelTo;
			}
			if (RelativePlacement != null)
			{
				yield return RelativePlacement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (PlacementRelTo != null)
			{
				yield return PlacementRelTo;
			}
		}
	}

	internal IfcLocalPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_placementRelTo = (IfcObjectPlacement)value.EntityVal;
			break;
		case 1:
			_relativePlacement = (IfcAxis2Placement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLocalPlacement other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcLocalPlacementClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcLocalPlacementClause.WR21)
			{
				result = Functions.IfcCorrectLocalPlacement(RelativePlacement, PlacementRelTo);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcLocalPlacement>()?.LogError($"Exception thrown evaluating where-clause 'IfcLocalPlacement.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcLocalPlacementClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLocalPlacement.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
