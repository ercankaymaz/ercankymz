using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcZone", 669)]
public class IfcZone : IfcSystem, IInstantiableEntity, IPersistEntity, IPersist, IIfcZone, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcZone>, IExpressValidatable
{
	public enum IfcZoneClause
	{
		WR1
	}

	private IfcLabel? _longName;

	IfcLabel? IIfcZone.LongName
	{
		get
		{
			return LongName;
		}
		set
		{
			LongName = value;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
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
		}
	}

	internal IfcZone(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_longName = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcZone other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcZoneClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcZoneClause.WR1)
			{
				result = Functions.SIZEOF(base.IsGroupedBy) == 0 || Functions.SIZEOF(Enumerable.Where(base.IsGroupedBy.ItemAt(0L).RelatedObjects, (IfcObjectDefinition temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCZONE") && !Functions.TYPEOF(temp).Contains("IFC4.IFCSPACE") && !Functions.TYPEOF(temp).Contains("IFC4.IFCSPATIALZONE"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcZone>()?.LogError($"Exception thrown evaluating where-clause 'IfcZone.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcZoneClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcZone.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
