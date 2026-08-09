using System;
using System.Collections.Generic;
using System.Linq;
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

[ExpressType("IfcComplexPropertyTemplate", 1129)]
public class IfcComplexPropertyTemplate : IfcPropertyTemplate, IInstantiableEntity, IPersistEntity, IPersist, IIfcComplexPropertyTemplate, IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcComplexPropertyTemplate>, IExpressValidatable
{
	public enum IfcComplexPropertyTemplateClause
	{
		UniquePropertyNames,
		NoSelfReference
	}

	private IfcLabel? _usageName;

	private IfcComplexPropertyTemplateTypeEnum? _templateType;

	private readonly OptionalItemSet<IfcPropertyTemplate> _hasPropertyTemplates;

	IfcLabel? IIfcComplexPropertyTemplate.UsageName
	{
		get
		{
			return UsageName;
		}
		set
		{
			UsageName = value;
		}
	}

	IfcComplexPropertyTemplateTypeEnum? IIfcComplexPropertyTemplate.TemplateType
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

	IItemSet<IIfcPropertyTemplate> IIfcComplexPropertyTemplate.HasPropertyTemplates => new ProxyItemSet<IfcPropertyTemplate, IIfcPropertyTemplate>(HasPropertyTemplates);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLabel? UsageName
	{
		get
		{
			if (_activated)
			{
				return _usageName;
			}
			Activate();
			return _usageName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_usageName = v;
			}, _usageName, value, "UsageName", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcComplexPropertyTemplateTypeEnum? TemplateType
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
			SetValue(delegate(IfcComplexPropertyTemplateTypeEnum? v)
			{
				_templateType = v;
			}, _templateType, value, "TemplateType", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IOptionalItemSet<IfcPropertyTemplate> HasPropertyTemplates
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

	internal IfcComplexPropertyTemplate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasPropertyTemplates = new OptionalItemSet<IfcPropertyTemplate>(this, 0, 7);
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
			_usageName = value.StringVal;
			break;
		case 5:
			_templateType = (IfcComplexPropertyTemplateTypeEnum)Enum.Parse(typeof(IfcComplexPropertyTemplateTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_hasPropertyTemplates.InternalAdd((IfcPropertyTemplate)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcComplexPropertyTemplate other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcComplexPropertyTemplateClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcComplexPropertyTemplateClause.UniquePropertyNames:
				result = Functions.IfcUniquePropertyTemplateNames(HasPropertyTemplates);
				break;
			case IfcComplexPropertyTemplateClause.NoSelfReference:
				result = Functions.SIZEOF(Enumerable.Where(HasPropertyTemplates, (IfcPropertyTemplate temp) => (object)this == temp)) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcComplexPropertyTemplate>()?.LogError($"Exception thrown evaluating where-clause 'IfcComplexPropertyTemplate.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcComplexPropertyTemplateClause.UniquePropertyNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcComplexPropertyTemplate.UniquePropertyNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcComplexPropertyTemplateClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcComplexPropertyTemplate.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
