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
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcPresentationLayerWithStyle", 259)]
public class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment, IInstantiableEntity, IPersistEntity, IPersist, IIfcPresentationLayerWithStyle, IIfcPresentationLayerAssignment, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPresentationLayerWithStyle>, IExpressValidatable
{
	public enum IfcPresentationLayerWithStyleClause
	{
		ApplicableOnlyToItems
	}

	private IfcLogical _layerOn;

	private IfcLogical _layerFrozen;

	private IfcLogical _layerBlocked;

	private readonly ItemSet<IfcPresentationStyle> _layerStyles;

	IfcLogical IIfcPresentationLayerWithStyle.LayerOn
	{
		get
		{
			return LayerOn;
		}
		set
		{
			LayerOn = value;
		}
	}

	IfcLogical IIfcPresentationLayerWithStyle.LayerFrozen
	{
		get
		{
			return LayerFrozen;
		}
		set
		{
			LayerFrozen = value;
		}
	}

	IfcLogical IIfcPresentationLayerWithStyle.LayerBlocked
	{
		get
		{
			return LayerBlocked;
		}
		set
		{
			LayerBlocked = value;
		}
	}

	IItemSet<IIfcPresentationStyle> IIfcPresentationLayerWithStyle.LayerStyles => new ProxyItemSet<IfcPresentationStyle, IIfcPresentationStyle>(LayerStyles);

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLogical LayerOn
	{
		get
		{
			if (_activated)
			{
				return _layerOn;
			}
			Activate();
			return _layerOn;
		}
		set
		{
			SetValue(delegate(IfcLogical v)
			{
				_layerOn = v;
			}, _layerOn, value, "LayerOn", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLogical LayerFrozen
	{
		get
		{
			if (_activated)
			{
				return _layerFrozen;
			}
			Activate();
			return _layerFrozen;
		}
		set
		{
			SetValue(delegate(IfcLogical v)
			{
				_layerFrozen = v;
			}, _layerFrozen, value, "LayerFrozen", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLogical LayerBlocked
	{
		get
		{
			if (_activated)
			{
				return _layerBlocked;
			}
			Activate();
			return _layerBlocked;
		}
		set
		{
			SetValue(delegate(IfcLogical v)
			{
				_layerBlocked = v;
			}, _layerBlocked, value, "LayerBlocked", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IItemSet<IfcPresentationStyle> LayerStyles
	{
		get
		{
			if (_activated)
			{
				return _layerStyles;
			}
			Activate();
			return _layerStyles;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in base.AssignedItems)
			{
				yield return assignedItem;
			}
			foreach (IfcPresentationStyle layerStyle in LayerStyles)
			{
				yield return layerStyle;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in base.AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	internal IfcPresentationLayerWithStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_layerStyles = new ItemSet<IfcPresentationStyle>(this, 0, 8);
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
			_layerOn = value.BooleanVal;
			break;
		case 5:
			_layerFrozen = value.BooleanVal;
			break;
		case 6:
			_layerBlocked = value.BooleanVal;
			break;
		case 7:
			_layerStyles.InternalAdd((IfcPresentationStyle)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPresentationLayerWithStyle other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPresentationLayerWithStyleClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPresentationLayerWithStyleClause.ApplicableOnlyToItems)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.AssignedItems, (IfcLayeredItem temp) => Functions.SIZEOF(Functions.TYPEOF(temp) * Functions.NewTypesArray("IFC4.IFCGEOMETRICREPRESENTATIONITEM", "IFC4.IFCMAPPEDITEM")) == 1)) == Functions.SIZEOF(base.AssignedItems);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPresentationLayerWithStyle>()?.LogError($"Exception thrown evaluating where-clause 'IfcPresentationLayerWithStyle.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPresentationLayerWithStyleClause.ApplicableOnlyToItems))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPresentationLayerWithStyle.ApplicableOnlyToItems",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
