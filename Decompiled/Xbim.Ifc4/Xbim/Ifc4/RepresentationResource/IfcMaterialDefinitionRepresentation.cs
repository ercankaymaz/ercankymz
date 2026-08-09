using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcMaterialDefinitionRepresentation", 2)]
public class IfcMaterialDefinitionRepresentation : IfcProductRepresentation, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialDefinitionRepresentation, IIfcProductRepresentation, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialDefinitionRepresentation>, IExpressValidatable
{
	public enum IfcMaterialDefinitionRepresentationClause
	{
		OnlyStyledRepresentations
	}

	private IfcMaterial _representedMaterial;

	IIfcMaterial IIfcMaterialDefinitionRepresentation.RepresentedMaterial
	{
		get
		{
			return RepresentedMaterial;
		}
		set
		{
			RepresentedMaterial = value as IfcMaterial;
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMaterial RepresentedMaterial
	{
		get
		{
			if (_activated)
			{
				return _representedMaterial;
			}
			Activate();
			return _representedMaterial;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_representedMaterial = v;
			}, _representedMaterial, value, "RepresentedMaterial", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
			}
			if (RepresentedMaterial != null)
			{
				yield return RepresentedMaterial;
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
			if (RepresentedMaterial != null)
			{
				yield return RepresentedMaterial;
			}
		}
	}

	internal IfcMaterialDefinitionRepresentation(IModel model, int label, bool activated)
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
			_representedMaterial = (IfcMaterial)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialDefinitionRepresentation other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMaterialDefinitionRepresentationClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcMaterialDefinitionRepresentationClause.OnlyStyledRepresentations)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Representations, (IfcRepresentation temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCSTYLEDREPRESENTATION"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMaterialDefinitionRepresentation>()?.LogError($"Exception thrown evaluating where-clause 'IfcMaterialDefinitionRepresentation.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcMaterialDefinitionRepresentationClause.OnlyStyledRepresentations))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMaterialDefinitionRepresentation.OnlyStyledRepresentations",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
