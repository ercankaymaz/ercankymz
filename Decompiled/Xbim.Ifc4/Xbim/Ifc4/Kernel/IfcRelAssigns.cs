using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssigns", 10)]
public abstract class IfcRelAssigns : IfcRelationship, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRelAssigns>, IExpressValidatable
{
	public enum IfcRelAssignsClause
	{
		WR1
	}

	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	private IfcObjectTypeEnum? _relatedObjectsType;

	IItemSet<IIfcObjectDefinition> IIfcRelAssigns.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(RelatedObjects);

	IfcObjectTypeEnum? IIfcRelAssigns.RelatedObjectsType
	{
		get
		{
			return RelatedObjectsType;
		}
		set
		{
			RelatedObjectsType = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcObjectDefinition> RelatedObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedObjects;
			}
			Activate();
			return _relatedObjects;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 6)]
	public IfcObjectTypeEnum? RelatedObjectsType
	{
		get
		{
			if (_activated)
			{
				return _relatedObjectsType;
			}
			Activate();
			return _relatedObjectsType;
		}
		set
		{
			SetValue(delegate(IfcObjectTypeEnum? v)
			{
				_relatedObjectsType = v;
			}, _relatedObjectsType, value, "RelatedObjectsType", 6);
		}
	}

	internal IfcRelAssigns(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObjectDefinition>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatedObjects.InternalAdd((IfcObjectDefinition)value.EntityVal);
			break;
		case 5:
			_relatedObjectsType = (IfcObjectTypeEnum)Enum.Parse(typeof(IfcObjectTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssigns other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsClause.WR1)
			{
				result = Functions.IfcCorrectObjectAssignment(RelatedObjectsType, RelatedObjects);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssigns>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssigns.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelAssignsClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssigns.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
