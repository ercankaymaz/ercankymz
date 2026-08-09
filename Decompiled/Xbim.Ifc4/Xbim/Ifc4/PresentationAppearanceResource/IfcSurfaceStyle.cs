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
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyle", 260)]
public class IfcSurfaceStyle : IfcPresentationStyle, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceStyle, IIfcPresentationStyle, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcSurfaceStyle>, IExpressValidatable
{
	public enum IfcSurfaceStyleClause
	{
		MaxOneShading,
		MaxOneLighting,
		MaxOneRefraction,
		MaxOneTextures,
		MaxOneExtDefined
	}

	private IfcSurfaceSide _side;

	private readonly ItemSet<IfcSurfaceStyleElementSelect> _styles;

	IfcSurfaceSide IIfcSurfaceStyle.Side
	{
		get
		{
			return Side;
		}
		set
		{
			Side = value;
		}
	}

	IItemSet<IIfcSurfaceStyleElementSelect> IIfcSurfaceStyle.Styles => new ProxyItemSet<IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect>(Styles);

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcSurfaceSide Side
	{
		get
		{
			if (_activated)
			{
				return _side;
			}
			Activate();
			return _side;
		}
		set
		{
			SetValue(delegate(IfcSurfaceSide v)
			{
				_side = v;
			}, _side, value, "Side", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 5 }, 3)]
	public IItemSet<IfcSurfaceStyleElementSelect> Styles
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

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceStyleElementSelect style in Styles)
			{
				yield return style;
			}
		}
	}

	public new IEnumerable<IIfcSurfaceStyle> SurfaceStyles => new IfcSurfaceStyle[1] { this };

	internal IfcSurfaceStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcSurfaceStyleElementSelect>(this, 5, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_side = (IfcSurfaceSide)Enum.Parse(typeof(IfcSurfaceSide), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_styles.InternalAdd((IfcSurfaceStyleElementSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyle other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSurfaceStyleClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSurfaceStyleClause.MaxOneShading:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC4.IFCSURFACESTYLESHADING"))) <= 1;
				break;
			case IfcSurfaceStyleClause.MaxOneLighting:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC4.IFCSURFACESTYLELIGHTING"))) <= 1;
				break;
			case IfcSurfaceStyleClause.MaxOneRefraction:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC4.IFCSURFACESTYLEREFRACTION"))) <= 1;
				break;
			case IfcSurfaceStyleClause.MaxOneTextures:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC4.IFCSURFACESTYLEWITHTEXTURES"))) <= 1;
				break;
			case IfcSurfaceStyleClause.MaxOneExtDefined:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC4.IFCEXTERNALLYDEFINEDSURFACESTYLE"))) <= 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSurfaceStyle>()?.LogError($"Exception thrown evaluating where-clause 'IfcSurfaceStyle.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSurfaceStyleClause.MaxOneShading))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.MaxOneShading",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.MaxOneLighting))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.MaxOneLighting",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.MaxOneRefraction))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.MaxOneRefraction",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.MaxOneTextures))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.MaxOneTextures",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.MaxOneExtDefined))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.MaxOneExtDefined",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
