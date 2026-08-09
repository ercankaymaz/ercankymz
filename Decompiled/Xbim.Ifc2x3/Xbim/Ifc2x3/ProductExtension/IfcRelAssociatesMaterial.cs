using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelAssociatesMaterial", 497)]
public class IfcRelAssociatesMaterial : IfcRelAssociates, IIfcRelAssociatesMaterial, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesMaterial>, IExpressValidatable
{
	public enum IfcRelAssociatesMaterialClause
	{
		WR21,
		WR22
	}

	private IfcMaterialSelect _relatingMaterial;

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesMaterial), 6)]
	IIfcMaterialSelect IIfcRelAssociatesMaterial.RelatingMaterial
	{
		get
		{
			if (RelatingMaterial == null)
			{
				return null;
			}
			IfcMaterial ifcMaterial = RelatingMaterial as IfcMaterial;
			if (ifcMaterial != null)
			{
				return ifcMaterial;
			}
			IfcMaterialList ifcMaterialList = RelatingMaterial as IfcMaterialList;
			if (ifcMaterialList != null)
			{
				return ifcMaterialList;
			}
			IfcMaterialLayerSetUsage ifcMaterialLayerSetUsage = RelatingMaterial as IfcMaterialLayerSetUsage;
			if (ifcMaterialLayerSetUsage != null)
			{
				return ifcMaterialLayerSetUsage;
			}
			IfcMaterialLayerSet ifcMaterialLayerSet = RelatingMaterial as IfcMaterialLayerSet;
			if (ifcMaterialLayerSet != null)
			{
				return ifcMaterialLayerSet;
			}
			IfcMaterialLayer ifcMaterialLayer = RelatingMaterial as IfcMaterialLayer;
			if (ifcMaterialLayer != null)
			{
				return ifcMaterialLayer;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingMaterial = null;
				return;
			}
			IfcMaterial ifcMaterial = value as IfcMaterial;
			if (ifcMaterial != null)
			{
				RelatingMaterial = ifcMaterial;
				return;
			}
			IfcMaterialLayer ifcMaterialLayer = value as IfcMaterialLayer;
			if (ifcMaterialLayer != null)
			{
				RelatingMaterial = ifcMaterialLayer;
				return;
			}
			IfcMaterialLayerSet ifcMaterialLayerSet = value as IfcMaterialLayerSet;
			if (ifcMaterialLayerSet != null)
			{
				RelatingMaterial = ifcMaterialLayerSet;
				return;
			}
			IfcMaterialLayerSetUsage ifcMaterialLayerSetUsage = value as IfcMaterialLayerSetUsage;
			if (ifcMaterialLayerSetUsage != null)
			{
				RelatingMaterial = ifcMaterialLayerSetUsage;
				return;
			}
			IfcMaterialList ifcMaterialList = value as IfcMaterialList;
			if (ifcMaterialList != null)
			{
				RelatingMaterial = ifcMaterialList;
			}
		}
	}

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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
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
			case IfcRelAssociatesMaterialClause.WR21:
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcRoot temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCFEATUREELEMENTSUBTRACTION") || Functions.TYPEOF(temp).Contains("IFC2X3.IFCVIRTUALELEMENT"))) == 0;
				break;
			case IfcRelAssociatesMaterialClause.WR22:
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcRoot temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCPRODUCT") && !Functions.TYPEOF(temp).Contains("IFC2X3.IFCTYPEPRODUCT"))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssociatesMaterial>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssociatesMaterial.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssociatesMaterialClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssociatesMaterial.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelAssociatesMaterialClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssociatesMaterial.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
