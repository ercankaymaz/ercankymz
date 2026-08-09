using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssignsToProcess", 249)]
public class IfcRelAssignsToProcess : IfcRelAssigns, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssignsToProcess, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToProcess>, IExpressValidatable
{
	public enum IfcRelAssignsToProcessClause
	{
		NoSelfReference
	}

	private IfcProcessSelect _relatingProcess;

	private IfcMeasureWithUnit _quantityInProcess;

	IIfcProcessSelect IIfcRelAssignsToProcess.RelatingProcess
	{
		get
		{
			return RelatingProcess;
		}
		set
		{
			RelatingProcess = value as IfcProcessSelect;
		}
	}

	IIfcMeasureWithUnit IIfcRelAssignsToProcess.QuantityInProcess
	{
		get
		{
			return QuantityInProcess;
		}
		set
		{
			QuantityInProcess = value as IfcMeasureWithUnit;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProcessSelect RelatingProcess
	{
		get
		{
			if (_activated)
			{
				return _relatingProcess;
			}
			Activate();
			return _relatingProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProcessSelect v)
			{
				_relatingProcess = v;
			}, _relatingProcess, value, "RelatingProcess", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcMeasureWithUnit QuantityInProcess
	{
		get
		{
			if (_activated)
			{
				return _quantityInProcess;
			}
			Activate();
			return _quantityInProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMeasureWithUnit v)
			{
				_quantityInProcess = v;
			}, _quantityInProcess, value, "QuantityInProcess", 8);
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
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (QuantityInProcess != null)
			{
				yield return QuantityInProcess;
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
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
		}
	}

	internal IfcRelAssignsToProcess(IModel model, int label, bool activated)
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
			_relatingProcess = (IfcProcessSelect)value.EntityVal;
			break;
		case 7:
			_quantityInProcess = (IfcMeasureWithUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToProcess other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsToProcessClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToProcessClause.NoSelfReference)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => RelatingProcess == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToProcess>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToProcess.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToProcessClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToProcess.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
