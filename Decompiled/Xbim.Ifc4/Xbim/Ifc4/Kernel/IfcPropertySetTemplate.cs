using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcPropertySetTemplate", 1232)]
public class IfcPropertySetTemplate : IfcPropertyTemplateDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertySetTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertySetTemplate>, IExpressValidatable
{
	public enum IfcPropertySetTemplateClause
	{
		ExistsName,
		UniquePropertyNames
	}

	private IfcPropertySetTemplateTypeEnum? _templateType;

	private IfcIdentifier? _applicableEntity;

	private readonly ItemSet<IfcPropertyTemplate> _hasPropertyTemplates;

	IfcPropertySetTemplateTypeEnum? IIfcPropertySetTemplate.TemplateType
	{
		get
		{
			return TemplateType;
		}
		set
		{
			TemplateType = value;
		}
	}

	IfcIdentifier? IIfcPropertySetTemplate.ApplicableEntity
	{
		get
		{
			return ApplicableEntity;
		}
		set
		{
			ApplicableEntity = value;
		}
	}

	IItemSet<IIfcPropertyTemplate> IIfcPropertySetTemplate.HasPropertyTemplates => new ProxyItemSet<IfcPropertyTemplate, IIfcPropertyTemplate>(HasPropertyTemplates);

	IEnumerable<IIfcRelDefinesByTemplate> IIfcPropertySetTemplate.Defines => Defines;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 7)]
	public IfcPropertySetTemplateTypeEnum? TemplateType
	{
		get
		{
			if (_activated)
			{
				return _templateType;
			}
			Activate();
			return _templateType;
		}
		set
		{
			SetValue(delegate(IfcPropertySetTemplateTypeEnum? v)
			{
				_templateType = v;
			}, _templateType, value, "TemplateType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcIdentifier? ApplicableEntity
	{
		get
		{
			if (_activated)
			{
				return _applicableEntity;
			}
			Activate();
			return _applicableEntity;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_applicableEntity = v;
			}, _applicableEntity, value, "ApplicableEntity", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 9)]
	public IItemSet<IfcPropertyTemplate> HasPropertyTemplates
	{
		get
		{
			if (_activated)
			{
				return _hasPropertyTemplates;
			}
			Activate();
			return _hasPropertyTemplates;
		}
	}

	[InverseProperty("RelatingTemplate")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 10)]
	public IEnumerable<IfcRelDefinesByTemplate> Defines => base.Model.Instances.Where((IfcRelDefinesByTemplate e) => Equals(e.RelatingTemplate), "RelatingTemplate", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcPropertyTemplate hasPropertyTemplate in HasPropertyTemplates)
			{
				yield return hasPropertyTemplate;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertyTemplate hasPropertyTemplate in HasPropertyTemplates)
			{
				yield return hasPropertyTemplate;
			}
		}
	}

	internal IfcPropertySetTemplate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasPropertyTemplates = new ItemSet<IfcPropertyTemplate>(this, 0, 7);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_templateType = (IfcPropertySetTemplateTypeEnum)Enum.Parse(typeof(IfcPropertySetTemplateTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_applicableEntity = value.StringVal;
			break;
		case 6:
			_hasPropertyTemplates.InternalAdd((IfcPropertyTemplate)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertySetTemplate other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertySetTemplateClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPropertySetTemplateClause.ExistsName:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcPropertySetTemplateClause.UniquePropertyNames:
				result = Functions.IfcUniquePropertyTemplateNames(HasPropertyTemplates);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertySetTemplate>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertySetTemplate.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertySetTemplateClause.ExistsName))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertySetTemplate.ExistsName",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertySetTemplateClause.UniquePropertyNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertySetTemplate.UniquePropertyNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
