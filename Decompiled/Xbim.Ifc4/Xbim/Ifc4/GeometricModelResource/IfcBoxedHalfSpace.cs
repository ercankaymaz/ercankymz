using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcBoxedHalfSpace", 655)]
public class IfcBoxedHalfSpace : IfcHalfSpaceSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoxedHalfSpace, IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcBoxedHalfSpace>, IExpressValidatable
{
	public enum IfcBoxedHalfSpaceClause
	{
		UnboundedSurface
	}

	private IfcBoundingBox _enclosure;

	IIfcBoundingBox IIfcBoxedHalfSpace.Enclosure
	{
		get
		{
			return Enclosure;
		}
		set
		{
			Enclosure = value as IfcBoundingBox;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcBoundingBox Enclosure
	{
		get
		{
			if (_activated)
			{
				return _enclosure;
			}
			Activate();
			return _enclosure;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundingBox v)
			{
				_enclosure = v;
			}, _enclosure, value, "Enclosure", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.BaseSurface != null)
			{
				yield return base.BaseSurface;
			}
			if (Enclosure != null)
			{
				yield return Enclosure;
			}
		}
	}

	internal IfcBoxedHalfSpace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_enclosure = (IfcBoundingBox)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoxedHalfSpace other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBoxedHalfSpaceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBoxedHalfSpaceClause.UnboundedSurface)
			{
				result = !Functions.TYPEOF(base.BaseSurface).Contains("IFC4.IFCCURVEBOUNDEDPLANE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBoxedHalfSpace>()?.LogError($"Exception thrown evaluating where-clause 'IfcBoxedHalfSpace.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBoxedHalfSpaceClause.UnboundedSurface))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBoxedHalfSpace.UnboundedSurface",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
