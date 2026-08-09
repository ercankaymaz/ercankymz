using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProcessExtension;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.FacilitiesMgmtDomain;

[ExpressType("IfcMove", 74)]
public class IfcMove : IfcTask, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMove>, IExpressValidatable
{
	public enum IfcMoveClause
	{
		WR1,
		WR2,
		WR3
	}

	private IfcSpatialStructureElement _moveFrom;

	private IfcSpatialStructureElement _moveTo;

	private readonly OptionalItemSet<IfcText> _punchList;

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
	public IfcSpatialStructureElement MoveFrom
	{
		get
		{
			if (_activated)
			{
				return _moveFrom;
			}
			Activate();
			return _moveFrom;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialStructureElement v)
			{
				_moveFrom = v;
			}, _moveFrom, value, "MoveFrom", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcSpatialStructureElement MoveTo
	{
		get
		{
			if (_activated)
			{
				return _moveTo;
			}
			Activate();
			return _moveTo;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialStructureElement v)
			{
				_moveTo = v;
			}, _moveTo, value, "MoveTo", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 21)]
	public IOptionalItemSet<IfcText> PunchList
	{
		get
		{
			if (_activated)
			{
				return _punchList;
			}
			Activate();
			return _punchList;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (MoveFrom != null)
			{
				yield return MoveFrom;
			}
			if (MoveTo != null)
			{
				yield return MoveTo;
			}
		}
	}

	internal IfcMove(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_punchList = new OptionalItemSet<IfcText>(this, 0, 13);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_moveFrom = (IfcSpatialStructureElement)value.EntityVal;
			break;
		case 11:
			_moveTo = (IfcSpatialStructureElement)value.EntityVal;
			break;
		case 12:
			_punchList.InternalAdd(value.StringVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMove other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMoveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcMoveClause.WR1:
				result = Functions.SIZEOF(base.OperatesOn) >= 1;
				break;
			case IfcMoveClause.WR2:
				result = Functions.SIZEOF(base.OperatesOn.Where((IfcRelAssignsToProcess temp) => Functions.SIZEOF(Enumerable.Where(temp.RelatedObjects, (IfcObjectDefinition instance) => Functions.TYPEOF(instance).Contains("IFC2X3.IFCACTOR") || Functions.TYPEOF(instance).Contains("IFC2X3.IFCEQUIPMENTELEMENT") || Functions.TYPEOF(instance).Contains("IFC2X3.IFCFURNISHINGELEMENT"))) >= 1)) >= 1;
				break;
			case IfcMoveClause.WR3:
				result = Functions.EXISTS(base.Name);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMove>()?.LogError($"Exception thrown evaluating where-clause 'IfcMove.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcMoveClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMove.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMoveClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMove.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMoveClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMove.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
