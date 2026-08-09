using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssignsToControl", 558)]
public class IfcRelAssignsToControl : IfcRelAssigns, IIfcRelAssignsToControl, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToControl>, IExpressValidatable
{
	public enum IfcRelAssignsToControlClause
	{
		WR1
	}

	private IfcControl _relatingControl;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToControl), 7)]
	IIfcControl IIfcRelAssignsToControl.RelatingControl
	{
		get
		{
			return RelatingControl;
		}
		set
		{
			RelatingControl = value as IfcControl;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcControl RelatingControl
	{
		get
		{
			if (_activated)
			{
				return _relatingControl;
			}
			Activate();
			return _relatingControl;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcControl v)
			{
				_relatingControl = v;
			}, _relatingControl, value, "RelatingControl", 7);
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
			if (RelatingControl != null)
			{
				yield return RelatingControl;
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
			if (RelatingControl != null)
			{
				yield return RelatingControl;
			}
		}
	}

	internal IfcRelAssignsToControl(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_relatingControl = (IfcControl)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToControl other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsToControlClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToControlClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingControl == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToControl>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToControl.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToControlClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToControl.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
