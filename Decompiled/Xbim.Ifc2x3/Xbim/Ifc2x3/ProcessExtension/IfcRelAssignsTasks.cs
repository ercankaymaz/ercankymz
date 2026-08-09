using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ProcessExtension;

[ExpressType("IfcRelAssignsTasks", 618)]
public class IfcRelAssignsTasks : IfcRelAssignsToControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsTasks>, IExpressValidatable
{
	public enum IfcRelAssignsTasksClause
	{
		WR1,
		WR2,
		WR3
	}

	private IfcScheduleTimeControl _timeForTask;

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcScheduleTimeControl TimeForTask
	{
		get
		{
			if (_activated)
			{
				return _timeForTask;
			}
			Activate();
			return _timeForTask;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcScheduleTimeControl v)
			{
				_timeForTask = v;
			}, _timeForTask, value, "TimeForTask", 8);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingControl != null)
			{
				yield return base.RelatingControl;
			}
			if (TimeForTask != null)
			{
				yield return TimeForTask;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingControl != null)
			{
				yield return base.RelatingControl;
			}
			if (TimeForTask != null)
			{
				yield return TimeForTask;
			}
		}
	}

	internal IfcRelAssignsTasks(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_timeForTask = (IfcScheduleTimeControl)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsTasks other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsTasksClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRelAssignsTasksClause.WR1:
				result = Functions.HIINDEX(base.RelatedObjects) == 1;
				break;
			case IfcRelAssignsTasksClause.WR2:
				result = Functions.TYPEOF(base.RelatedObjects.ItemAt(0L)).Contains("IFC2X3.IFCTASK");
				break;
			case IfcRelAssignsTasksClause.WR3:
				result = Functions.TYPEOF(base.RelatingControl).Contains("IFC2X3.IFCWORKCONTROL");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsTasks>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsTasks.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsTasksClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsTasks.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelAssignsTasksClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsTasks.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelAssignsTasksClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsTasks.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
