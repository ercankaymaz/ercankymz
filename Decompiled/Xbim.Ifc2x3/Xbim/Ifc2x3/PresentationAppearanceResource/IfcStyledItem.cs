using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcStyledItem", 56)]
public class IfcStyledItem : IfcRepresentationItem, IIfcStyledItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStyledItem>, IExpressValidatable
{
	public enum IfcStyledItemClause
	{
		WR11,
		WR12
	}

	private IItemSet<IIfcStyleAssignmentSelect> _stylesIfc4;

	private IfcRepresentationItem _item;

	private readonly ItemSet<IfcPresentationStyleAssignment> _styles;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 1)]
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

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 2)]
	IItemSet<IIfcStyleAssignmentSelect> IIfcStyledItem.Styles => _stylesIfc4 ?? (_stylesIfc4 = new ExtendedItemSet<IfcPresentationStyleAssignment, IIfcStyleAssignmentSelect>(Styles, new ItemSet<IIfcStyleAssignmentSelect>(this, 0, -2), StylesToIfc4, StylesToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcStyledItem.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
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
	public IItemSet<IfcPresentationStyleAssignment> Styles
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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
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
			foreach (IfcPresentationStyleAssignment style in Styles)
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

	private static IIfcStyleAssignmentSelect StylesToIfc4(IfcPresentationStyleAssignment member)
	{
		return member;
	}

	private IfcPresentationStyleAssignment StylesToIfc2X3(IIfcStyleAssignmentSelect member)
	{
		IIfcPresentationStyleSelect ps = member as IIfcPresentationStyleSelect;
		if (ps != null && base.Model.CurrentTransaction != null)
		{
			return base.Model.Instances.New(delegate(IfcPresentationStyleAssignment pa)
			{
				((IIfcPresentationStyleAssignment)pa).Styles.Add(ps);
			});
		}
		return member as IfcPresentationStyleAssignment;
	}

	internal IfcStyledItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcPresentationStyleAssignment>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_item = (IfcRepresentationItem)value.EntityVal;
			break;
		case 1:
			_styles.InternalAdd((IfcPresentationStyleAssignment)value.EntityVal);
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
			switch (clause)
			{
			case IfcStyledItemClause.WR11:
				result = Functions.SIZEOF(Styles) == 1;
				break;
			case IfcStyledItemClause.WR12:
				result = !Functions.TYPEOF(Item).Contains("IFC2X3.IFCSTYLEDITEM");
				break;
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
		if (!ValidateClause(IfcStyledItemClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStyledItem.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStyledItemClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStyledItem.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
