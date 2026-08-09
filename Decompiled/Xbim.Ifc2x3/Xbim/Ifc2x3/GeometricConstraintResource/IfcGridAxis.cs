using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcGridAxis", 441)]
public class IfcGridAxis : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGridAxis>, IIfcGridAxis, IExpressValidatable
{
	public enum IfcGridAxisClause
	{
		WR1,
		WR2
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _axisTag;

	private IfcCurve _axisCurve;

	private Xbim.Ifc2x3.MeasureResource.IfcBoolean _sameSense;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? AxisTag
	{
		get
		{
			if (_activated)
			{
				return _axisTag;
			}
			Activate();
			return _axisTag;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_axisTag = v;
			}, _axisTag, value, "AxisTag", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCurve AxisCurve
	{
		get
		{
			if (_activated)
			{
				return _axisCurve;
			}
			Activate();
			return _axisCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_axisCurve = v;
			}, _axisCurve, value, "AxisCurve", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcBoolean SameSense
	{
		get
		{
			if (_activated)
			{
				return _sameSense;
			}
			Activate();
			return _sameSense;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcBoolean v)
			{
				_sameSense = v;
			}, _sameSense, value, "SameSense", 3);
		}
	}

	[InverseProperty("WAxes")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcGrid> PartOfW => base.Model.Instances.Where((IfcGrid e) => e.WAxes != null && e.WAxes.Contains(this), "WAxes", this);

	[InverseProperty("VAxes")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcGrid> PartOfV => base.Model.Instances.Where((IfcGrid e) => e.VAxes != null && e.VAxes.Contains(this), "VAxes", this);

	[InverseProperty("UAxes")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 6)]
	public IEnumerable<IfcGrid> PartOfU => base.Model.Instances.Where((IfcGrid e) => e.UAxes != null && e.UAxes.Contains(this), "UAxes", this);

	[InverseProperty("IntersectingAxes")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcVirtualGridIntersection> HasIntersections => base.Model.Instances.Where((IfcVirtualGridIntersection e) => e.IntersectingAxes != null && e.IntersectingAxes.Contains(this), "IntersectingAxes", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (AxisCurve != null)
			{
				yield return AxisCurve;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGridAxis), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcGridAxis.AxisTag
	{
		get
		{
			if (!AxisTag.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(AxisTag.Value);
		}
		set
		{
			AxisTag = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGridAxis), 2)]
	IIfcCurve IIfcGridAxis.AxisCurve
	{
		get
		{
			return AxisCurve;
		}
		set
		{
			AxisCurve = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGridAxis), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcGridAxis.SameSense
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(SameSense);
		}
		set
		{
			SameSense = new Xbim.Ifc2x3.MeasureResource.IfcBoolean(value);
		}
	}

	IEnumerable<IIfcGrid> IIfcGridAxis.PartOfW => base.Model.Instances.Where((IIfcGrid e) => e.WAxes != null && e.WAxes.Contains(this), "WAxes", this);

	IEnumerable<IIfcGrid> IIfcGridAxis.PartOfV => base.Model.Instances.Where((IIfcGrid e) => e.VAxes != null && e.VAxes.Contains(this), "VAxes", this);

	IEnumerable<IIfcGrid> IIfcGridAxis.PartOfU => base.Model.Instances.Where((IIfcGrid e) => e.UAxes != null && e.UAxes.Contains(this), "UAxes", this);

	IEnumerable<IIfcVirtualGridIntersection> IIfcGridAxis.HasIntersections => base.Model.Instances.Where((IIfcVirtualGridIntersection e) => e.IntersectingAxes != null && e.IntersectingAxes.Contains(this), "IntersectingAxes", this);

	internal IfcGridAxis(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_axisTag = value.StringVal;
			break;
		case 1:
			_axisCurve = (IfcCurve)value.EntityVal;
			break;
		case 2:
			_sameSense = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGridAxis other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGridAxisClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcGridAxisClause.WR1:
				result = AxisCurve.Dim == 2L;
				break;
			case IfcGridAxisClause.WR2:
				result = (Functions.SIZEOF(PartOfU) == 1) ^ (Functions.SIZEOF(PartOfV) == 1) ^ (Functions.SIZEOF(PartOfW) == 1);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGridAxis>()?.LogError($"Exception thrown evaluating where-clause 'IfcGridAxis.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcGridAxisClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGridAxis.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcGridAxisClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGridAxis.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
