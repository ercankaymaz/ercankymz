using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyle", 33)]
public class IfcFillAreaStyle : IfcPresentationStyle, IIfcFillAreaStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcFillAreaStyle>, IExpressValidatable
{
	public enum IfcFillAreaStyleClause
	{
		WR11,
		WR12,
		WR13
	}

	private IfcBoolean? _modelorDraughting;

	private readonly ItemSet<IfcFillStyleSelect> _fillStyles;

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyle), 2)]
	IItemSet<IIfcFillStyleSelect> IIfcFillAreaStyle.FillStyles => new ProxyItemSet<IfcFillStyleSelect, IIfcFillStyleSelect>(FillStyles);

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyle), 3)]
	IfcBoolean? IIfcFillAreaStyle.ModelorDraughting
	{
		get
		{
			return _modelorDraughting;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_modelorDraughting = v;
			}, _modelorDraughting, value, "ModelorDraughting", -3);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcFillStyleSelect> FillStyles
	{
		get
		{
			if (_activated)
			{
				return _fillStyles;
			}
			Activate();
			return _fillStyles;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFillStyleSelect fillStyle in FillStyles)
			{
				yield return fillStyle;
			}
		}
	}

	internal IfcFillAreaStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_fillStyles = new ItemSet<IfcFillStyleSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_fillStyles.InternalAdd((IfcFillStyleSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFillAreaStyle other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFillAreaStyleClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcFillAreaStyleClause.WR11:
				result = Functions.SIZEOF(Enumerable.Where(FillStyles, (IfcFillStyleSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCCOLOUR"))) <= 1;
				break;
			case IfcFillAreaStyleClause.WR12:
				result = Functions.SIZEOF(Enumerable.Where(FillStyles, (IfcFillStyleSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCEXTERNALLYDEFINEDHATCHSTYLE"))) <= 1;
				break;
			case IfcFillAreaStyleClause.WR13:
				result = Functions.IfcCorrectFillAreaStyle(FillStyles);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFillAreaStyle>()?.LogError($"Exception thrown evaluating where-clause 'IfcFillAreaStyle.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcFillAreaStyleClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFillAreaStyle.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcFillAreaStyleClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFillAreaStyle.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcFillAreaStyleClause.WR13))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFillAreaStyle.WR13",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
