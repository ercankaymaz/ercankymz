using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcGrid", 564)]
public class IfcGrid : IfcProduct, IInstantiableEntity, IPersistEntity, IPersist, IIfcGrid, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGrid>, IExpressValidatable
{
	public enum IfcGridClause
	{
		HasPlacement
	}

	private readonly ItemSet<IfcGridAxis> _uAxes;

	private readonly ItemSet<IfcGridAxis> _vAxes;

	private readonly OptionalItemSet<IfcGridAxis> _wAxes;

	private IfcGridTypeEnum? _predefinedType;

	IItemSet<IIfcGridAxis> IIfcGrid.UAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(UAxes);

	IItemSet<IIfcGridAxis> IIfcGrid.VAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(VAxes);

	IItemSet<IIfcGridAxis> IIfcGrid.WAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(WAxes);

	IfcGridTypeEnum? IIfcGrid.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcGrid.ContainedInStructure => ContainedInStructure;

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IItemSet<IfcGridAxis> UAxes
	{
		get
		{
			if (_activated)
			{
				return _uAxes;
			}
			Activate();
			return _uAxes;
		}
	}

	[IndexedProperty]
	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 21)]
	public IItemSet<IfcGridAxis> VAxes
	{
		get
		{
			if (_activated)
			{
				return _vAxes;
			}
			Activate();
			return _vAxes;
		}
	}

	[IndexedProperty]
	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 22)]
	public IOptionalItemSet<IfcGridAxis> WAxes
	{
		get
		{
			if (_activated)
			{
				return _wAxes;
			}
			Activate();
			return _wAxes;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcGridTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcGridTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
		}
	}

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 24)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainedInStructure => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			foreach (IfcGridAxis uAxis in UAxes)
			{
				yield return uAxis;
			}
			foreach (IfcGridAxis vAxis in VAxes)
			{
				yield return vAxis;
			}
			foreach (IfcGridAxis wAxis in WAxes)
			{
				yield return wAxis;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			foreach (IfcGridAxis uAxis in UAxes)
			{
				yield return uAxis;
			}
			foreach (IfcGridAxis vAxis in VAxes)
			{
				yield return vAxis;
			}
			foreach (IfcGridAxis wAxis in WAxes)
			{
				yield return wAxis;
			}
		}
	}

	internal IfcGrid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_uAxes = new ItemSet<IfcGridAxis>(this, 0, 8);
		_vAxes = new ItemSet<IfcGridAxis>(this, 0, 9);
		_wAxes = new OptionalItemSet<IfcGridAxis>(this, 0, 10);
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
			_uAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 8:
			_vAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 9:
			_wAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 10:
			_predefinedType = (IfcGridTypeEnum)Enum.Parse(typeof(IfcGridTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGrid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGridClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcGridClause.HasPlacement)
			{
				result = Functions.EXISTS(base.ObjectPlacement);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGrid>()?.LogError($"Exception thrown evaluating where-clause 'IfcGrid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcGridClause.HasPlacement))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGrid.HasPlacement",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
