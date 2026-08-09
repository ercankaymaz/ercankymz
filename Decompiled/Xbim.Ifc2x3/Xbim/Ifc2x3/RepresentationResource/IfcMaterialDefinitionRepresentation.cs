using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcMaterialDefinitionRepresentation", 2)]
public class IfcMaterialDefinitionRepresentation : IfcProductRepresentation, IIfcMaterialDefinitionRepresentation, IIfcProductRepresentation, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialDefinitionRepresentation>, IExpressValidatable
{
	public enum IfcMaterialDefinitionRepresentationClause
	{
		WR11
	}

	private IfcMaterial _representedMaterial;

	[CrossSchemaAttribute(typeof(IIfcMaterialDefinitionRepresentation), 4)]
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
			if (clause == IfcMaterialDefinitionRepresentationClause.WR11)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Representations, (IfcRepresentation temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCSTYLEDREPRESENTATION"))) == 0;
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
		if (!ValidateClause(IfcMaterialDefinitionRepresentationClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMaterialDefinitionRepresentation.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
