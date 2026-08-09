using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcShapeModel", 89)]
public abstract class IfcShapeModel : IfcRepresentation, IIfcShapeModel, IIfcRepresentation, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcShapeModel>, IExpressValidatable
{
	public enum IfcShapeModelClause
	{
		WR11
	}

	IEnumerable<IIfcShapeAspect> IIfcShapeModel.OfShapeAspect => base.Model.Instances.Where((IIfcShapeAspect e) => e.ShapeRepresentations != null && e.ShapeRepresentations.Contains(this), "ShapeRepresentations", this);

	[InverseProperty("ShapeRepresentations")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 8)]
	public IEnumerable<IfcShapeAspect> OfShapeAspect => base.Model.Instances.Where((IfcShapeAspect e) => e.ShapeRepresentations != null && e.ShapeRepresentations.Contains(this), "ShapeRepresentations", this);

	internal IfcShapeModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcShapeModel other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcShapeModelClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcShapeModelClause.WR11)
			{
				result = (Functions.SIZEOF(base.OfProductRepresentation) == 1) ^ (Functions.SIZEOF(base.RepresentationMap) == 1) ^ (Functions.SIZEOF(OfShapeAspect) == 1);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcShapeModel>()?.LogError($"Exception thrown evaluating where-clause 'IfcShapeModel.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcShapeModelClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeModel.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
