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
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelAssociatesMaterial", 497)]
public class IfcRelAssociatesMaterial : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssociatesMaterial, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesMaterial>, IExpressValidatable
{
	public enum IfcRelAssociatesMaterialClause
	{
		NoVoidElement,
		AllowedElements
	}

	private IfcMaterialSelect _relatingMaterial;

	IIfcMaterialSelect IIfcRelAssociatesMaterial.RelatingMaterial
	{
		get
		{
			return RelatingMaterial;
		}
		set
		{
			RelatingMaterial = value as IfcMaterialSelect;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcMaterialSelect RelatingMaterial
	{
		get
		{
			if (_activated)
			{
				return _relatingMaterial;
			}
			Activate();
			return _relatingMaterial;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterialSelect v)
			{
				_relatingMaterial = v;
			}, _relatingMaterial, value, "RelatingMaterial", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
		}
	}

	internal IfcRelAssociatesMaterial(IModel model, int label, bool activated)
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
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingMaterial = (IfcMaterialSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesMaterial other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssociatesMaterialClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRelAssociatesMaterialClause.NoVoidElement:
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcDefinitionSelect temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCFEATUREELEMENTSUBTRACTION") || Functions.TYPEOF(temp).Contains("IFC4.IFCVIRTUALELEMENT"))) == 0;
				break;
			case IfcRelAssociatesMaterialClause.AllowedElements:
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcDefinitionSelect temp) => Functions.SIZEOF(Functions.TYPEOF(temp) * Functions.NewTypesArray("IFC4.IFCELEMENT", "IFC4.IFCELEMENTTYPE", "IFC4.IFCWINDOWSTYLE", "IFC4.IFCDOORSTYLE", "IFC4.IFCSTRUCTURALMEMBER", "IFC4.IFCPORT")) == 0)) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssociatesMaterial>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssociatesMaterial.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelAssociatesMaterialClause.NoVoidElement))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssociatesMaterial.NoVoidElement",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelAssociatesMaterialClause.AllowedElements))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssociatesMaterial.AllowedElements",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
