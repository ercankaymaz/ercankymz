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
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyle", 260)]
public class IfcSurfaceStyle : IfcPresentationStyle, IIfcSurfaceStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcSurfaceStyle>, IExpressValidatable
{
	public enum IfcSurfaceStyleClause
	{
		WR11,
		WR12,
		WR13,
		WR14,
		WR15
	}

	private IfcSurfaceSide _side;

	private readonly ItemSet<IfcSurfaceStyleElementSelect> _styles;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyle), 2)]
	Xbim.Ifc4.Interfaces.IfcSurfaceSide IIfcSurfaceStyle.Side
	{
		get
		{
			return Side switch
			{
				IfcSurfaceSide.POSITIVE => Xbim.Ifc4.Interfaces.IfcSurfaceSide.POSITIVE, 
				IfcSurfaceSide.NEGATIVE => Xbim.Ifc4.Interfaces.IfcSurfaceSide.NEGATIVE, 
				IfcSurfaceSide.BOTH => Xbim.Ifc4.Interfaces.IfcSurfaceSide.BOTH, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.POSITIVE:
				Side = IfcSurfaceSide.POSITIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.NEGATIVE:
				Side = IfcSurfaceSide.NEGATIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceSide.BOTH:
				Side = IfcSurfaceSide.BOTH;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyle), 3)]
	IItemSet<IIfcSurfaceStyleElementSelect> IIfcSurfaceStyle.Styles => new ProxyItemSet<IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect>(Styles);

	public new IEnumerable<IIfcSurfaceStyle> SurfaceStyles => new IfcSurfaceStyle[1] { this };

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
			case IfcSurfaceStyleClause.WR11:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCSURFACESTYLESHADING"))) <= 1;
				break;
			case IfcSurfaceStyleClause.WR12:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCSURFACESTYLELIGHTING"))) <= 1;
				break;
			case IfcSurfaceStyleClause.WR13:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCSURFACESTYLEREFRACTION"))) <= 1;
				break;
			case IfcSurfaceStyleClause.WR14:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCSURFACESTYLEWITHTEXTURES"))) <= 1;
				break;
			case IfcSurfaceStyleClause.WR15:
				result = Functions.SIZEOF(Enumerable.Where(Styles, (IfcSurfaceStyleElementSelect Style) => Functions.TYPEOF(Style).Contains("IFC2X3.IFCEXTERNALLYDEFINEDSURFACESTYLE"))) <= 1;
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
		if (!ValidateClause(IfcSurfaceStyleClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.WR13))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.WR13",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.WR14))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.WR14",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceStyleClause.WR15))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceStyle.WR15",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
