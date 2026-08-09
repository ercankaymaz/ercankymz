using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcPropertySetTemplate", 1232)]
public class IfcPropertySetTemplate : IfcPropertyTemplateDefinition, IIfcPropertySetTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertySetTemplate>
{
	private IfcPropertySetTemplateTypeEnum? _templateType;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _applicableEntity;

	private readonly ItemSet<IfcPropertyTemplate> _hasPropertyTemplates;

	[CrossSchemaAttribute(typeof(IIfcPropertySetTemplate), 5)]
	Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum? IIfcPropertySetTemplate.TemplateType
	{
		get
		{
			return TemplateType switch
			{
				IfcPropertySetTemplateTypeEnum.PSET_MATERIALDRIVEN => throw new NotImplementedException(), 
				IfcPropertySetTemplateTypeEnum.PSET_OCCURRENCEDRIVEN => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_OCCURRENCEDRIVEN, 
				IfcPropertySetTemplateTypeEnum.PSET_PERFORMANCEDRIVEN => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_PERFORMANCEDRIVEN, 
				IfcPropertySetTemplateTypeEnum.PSET_PROFILEDRIVEN => throw new NotImplementedException(), 
				IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENONLY => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENONLY, 
				IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENOVERRIDE => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENOVERRIDE, 
				IfcPropertySetTemplateTypeEnum.QTO_OCCURRENCEDRIVEN => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_OCCURRENCEDRIVEN, 
				IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENONLY => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENONLY, 
				IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENOVERRIDE => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENOVERRIDE, 
				IfcPropertySetTemplateTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENONLY:
				TemplateType = IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENONLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENOVERRIDE:
				TemplateType = IfcPropertySetTemplateTypeEnum.PSET_TYPEDRIVENOVERRIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_OCCURRENCEDRIVEN:
				TemplateType = IfcPropertySetTemplateTypeEnum.PSET_OCCURRENCEDRIVEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.PSET_PERFORMANCEDRIVEN:
				TemplateType = IfcPropertySetTemplateTypeEnum.PSET_PERFORMANCEDRIVEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENONLY:
				TemplateType = IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENONLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENOVERRIDE:
				TemplateType = IfcPropertySetTemplateTypeEnum.QTO_TYPEDRIVENOVERRIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.QTO_OCCURRENCEDRIVEN:
				TemplateType = IfcPropertySetTemplateTypeEnum.QTO_OCCURRENCEDRIVEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPropertySetTemplateTypeEnum.NOTDEFINED:
				TemplateType = IfcPropertySetTemplateTypeEnum.NOTDEFINED;
				break;
			case null:
				TemplateType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertySetTemplate), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcPropertySetTemplate.ApplicableEntity
	{
		get
		{
			if (!ApplicableEntity.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(ApplicableEntity.Value);
		}
		set
		{
			ApplicableEntity = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertySetTemplate), 7)]
	IItemSet<IIfcPropertyTemplate> IIfcPropertySetTemplate.HasPropertyTemplates => new ProxyItemSet<IfcPropertyTemplate, IIfcPropertyTemplate>(HasPropertyTemplates);

	IEnumerable<IIfcRelDefinesByTemplate> IIfcPropertySetTemplate.Defines => base.Model.Instances.Where((IIfcRelDefinesByTemplate e) => e.RelatingTemplate as IfcPropertySetTemplate == this, "RelatingTemplate", this);

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
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? ApplicableEntity
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
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
}
