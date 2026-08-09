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

[ExpressType("IfcRelDecomposes", 306)]
public abstract class IfcRelDecomposes : IfcRelationship, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRelDecomposes>, IExpressValidatable
{
	public enum IfcRelDecomposesClause
	{
		WR31
	}

	private IfcObjectDefinition _relatingObject;

	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcObjectDefinition RelatingObject
	{
		get
		{
			if (_activated)
			{
				return _relatingObject;
			}
			Activate();
			return _relatingObject;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectDefinition v)
			{
				_relatingObject = v;
			}, _relatingObject, value, "RelatingObject", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
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

	internal IfcRelDecomposes(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObjectDefinition>(this, 0, 6);
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
			_relatingObject = (IfcObjectDefinition)value.EntityVal;
			break;
		case 5:
			_relatedObjects.InternalAdd((IfcObjectDefinition)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDecomposes other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelDecomposesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelDecomposesClause.WR31)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingObject == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelDecomposes>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelDecomposes.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelDecomposesClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelDecomposes.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
