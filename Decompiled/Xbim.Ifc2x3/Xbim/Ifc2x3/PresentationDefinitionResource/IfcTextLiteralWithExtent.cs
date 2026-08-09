using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationDefinitionResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextLiteralWithExtent", 426)]
public class IfcTextLiteralWithExtent : IfcTextLiteral, IIfcTextLiteralWithExtent, IIfcTextLiteral, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTextLiteralWithExtent>, IExpressValidatable
{
	public enum IfcTextLiteralWithExtentClause
	{
		WR31
	}

	private Xbim.Ifc2x3.PresentationResource.IfcPlanarExtent _extent;

	private IfcBoxAlignment _boxAlignment;

	[CrossSchemaAttribute(typeof(IIfcTextLiteralWithExtent), 4)]
	IIfcPlanarExtent IIfcTextLiteralWithExtent.Extent
	{
		get
		{
			return Extent;
		}
		set
		{
			Extent = value as Xbim.Ifc2x3.PresentationResource.IfcPlanarExtent;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextLiteralWithExtent), 5)]
	Xbim.Ifc4.PresentationDefinitionResource.IfcBoxAlignment IIfcTextLiteralWithExtent.BoxAlignment
	{
		get
		{
			return new Xbim.Ifc4.PresentationDefinitionResource.IfcBoxAlignment(BoxAlignment);
		}
		set
		{
			BoxAlignment = new IfcBoxAlignment(value);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.PresentationResource.IfcPlanarExtent Extent
	{
		get
		{
			if (_activated)
			{
				return _extent;
			}
			Activate();
			return _extent;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcPlanarExtent v)
			{
				_extent = v;
			}, _extent, value, "Extent", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcBoxAlignment BoxAlignment
	{
		get
		{
			if (_activated)
			{
				return _boxAlignment;
			}
			Activate();
			return _boxAlignment;
		}
		set
		{
			SetValue(delegate(IfcBoxAlignment v)
			{
				_boxAlignment = v;
			}, _boxAlignment, value, "BoxAlignment", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Placement != null)
			{
				yield return base.Placement;
			}
			if (Extent != null)
			{
				yield return Extent;
			}
		}
	}

	internal IfcTextLiteralWithExtent(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_extent = (Xbim.Ifc2x3.PresentationResource.IfcPlanarExtent)value.EntityVal;
			break;
		case 4:
			_boxAlignment = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextLiteralWithExtent other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTextLiteralWithExtentClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTextLiteralWithExtentClause.WR31)
			{
				result = !Functions.TYPEOF(Extent).Contains("IFC2X3.IFCPLANARBOX");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTextLiteralWithExtent>()?.LogError($"Exception thrown evaluating where-clause 'IfcTextLiteralWithExtent.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTextLiteralWithExtentClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTextLiteralWithExtent.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
