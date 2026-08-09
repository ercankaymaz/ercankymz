using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcStyledItem", 56)]
public class IfcStyledItem : IfcRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcStyledItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStyledItem>, IExpressValidatable
{
	public enum IfcStyledItemClause
	{
		ApplicableItem
	}

	private IfcRepresentationItem _item;

	private readonly ItemSet<IfcStyleAssignmentSelect> _styles;

	private IfcLabel? _name;

	IIfcRepresentationItem IIfcStyledItem.Item
	{
		get
		{
			return Item;
		}
		set
		{
			Item = value as IfcRepresentationItem;
		}
	}

	IItemSet<IIfcStyleAssignmentSelect> IIfcStyledItem.Styles => new ProxyItemSet<IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect>(Styles);

	IfcLabel? IIfcStyledItem.Name
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

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcRepresentationItem Item
	{
		get
		{
			if (_activated)
			{
				return _item;
			}
			Activate();
			return _item;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRepresentationItem v)
			{
				_item = v;
			}, _item, value, "Item", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcStyleAssignmentSelect> Styles
	{
		get
		{
			if (_activated)
			{
				return _styles;
			}
			Activate();
			return _styles;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Item != null)
			{
				yield return Item;
			}
			foreach (IfcStyleAssignmentSelect style in Styles)
			{
				yield return style;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (Item != null)
			{
				yield return Item;
			}
		}
	}

	internal IfcStyledItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcStyleAssignmentSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_item = (IfcRepresentationItem)value.EntityVal;
			break;
		case 1:
			_styles.InternalAdd((IfcStyleAssignmentSelect)value.EntityVal);
			break;
		case 2:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStyledItem other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStyledItemClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStyledItemClause.ApplicableItem)
			{
				result = !Functions.TYPEOF(Item).Contains("IFC4.IFCSTYLEDITEM");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStyledItem>()?.LogError($"Exception thrown evaluating where-clause 'IfcStyledItem.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcStyledItemClause.ApplicableItem))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStyledItem.ApplicableItem",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
