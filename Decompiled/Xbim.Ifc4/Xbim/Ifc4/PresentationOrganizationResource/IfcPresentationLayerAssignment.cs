using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcPresentationLayerAssignment", 258)]
public class IfcPresentationLayerAssignment : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcPresentationLayerAssignment, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPresentationLayerAssignment>, IExpressValidatable
{
	public enum IfcPresentationLayerAssignmentClause
	{
		ApplicableItems
	}

	private IfcLabel _name;

	private IfcText? _description;

	private readonly ItemSet<IfcLayeredItem> _assignedItems;

	private IfcIdentifier? _identifier;

	IfcLabel IIfcPresentationLayerAssignment.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcPresentationLayerAssignment.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IItemSet<IIfcLayeredItem> IIfcPresentationLayerAssignment.AssignedItems => new ProxyItemSet<IfcLayeredItem, IIfcLayeredItem>(AssignedItems);

	IfcIdentifier? IIfcPresentationLayerAssignment.Identifier
	{
		get
		{
			return Identifier;
		}
		set
		{
			Identifier = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcLayeredItem> AssignedItems
	{
		get
		{
			if (_activated)
			{
				return _assignedItems;
			}
			Activate();
			return _assignedItems;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcIdentifier? Identifier
	{
		get
		{
			if (_activated)
			{
				return _identifier;
			}
			Activate();
			return _identifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	internal IfcPresentationLayerAssignment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_assignedItems = new ItemSet<IfcLayeredItem>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_assignedItems.InternalAdd((IfcLayeredItem)value.EntityVal);
			break;
		case 3:
			_identifier = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPresentationLayerAssignment other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPresentationLayerAssignmentClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPresentationLayerAssignmentClause.ApplicableItems)
			{
				result = Functions.SIZEOF(Enumerable.Where(AssignedItems, (IfcLayeredItem temp) => Functions.SIZEOF(Functions.TYPEOF(temp) * Functions.NewTypesArray("IFC4.IFCSHAPEREPRESENTATION", "IFC4.IFCGEOMETRICREPRESENTATIONITEM", "IFC4.IFCMAPPEDITEM")) == 1)) == Functions.SIZEOF(AssignedItems);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPresentationLayerAssignment>()?.LogError($"Exception thrown evaluating where-clause 'IfcPresentationLayerAssignment.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPresentationLayerAssignmentClause.ApplicableItems))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPresentationLayerAssignment.ApplicableItems",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
