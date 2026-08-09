using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcProductDefinitionShape", 90)]
public class IfcProductDefinitionShape : IfcProductRepresentation, IInstantiableEntity, IPersistEntity, IPersist, IIfcProductDefinitionShape, IIfcProductRepresentation, IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProductDefinitionShape>, IExpressValidatable
{
	public enum IfcProductDefinitionShapeClause
	{
		OnlyShapeModel
	}

	IEnumerable<IIfcProduct> IIfcProductDefinitionShape.ShapeOfProduct => ShapeOfProduct;

	IEnumerable<IIfcShapeAspect> IIfcProductDefinitionShape.HasShapeAspects => HasShapeAspects;

	[InverseProperty("Representation")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcProduct> ShapeOfProduct => base.Model.Instances.Where((IfcProduct e) => Equals(e.Representation), "Representation", this);

	[InverseProperty("PartOfProductDefinitionShape")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcShapeAspect> HasShapeAspects => base.Model.Instances.Where((IfcShapeAspect e) => Equals(e.PartOfProductDefinitionShape), "PartOfProductDefinitionShape", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
			}
		}
	}

	internal IfcProductDefinitionShape(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcProductDefinitionShape other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcProductDefinitionShapeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcProductDefinitionShapeClause.OnlyShapeModel)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Representations, (IfcRepresentation temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCSHAPEMODEL"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProductDefinitionShape>()?.LogError($"Exception thrown evaluating where-clause 'IfcProductDefinitionShape.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcProductDefinitionShapeClause.OnlyShapeModel))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProductDefinitionShape.OnlyShapeModel",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
