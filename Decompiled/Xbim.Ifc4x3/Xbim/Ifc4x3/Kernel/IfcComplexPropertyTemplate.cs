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

[ExpressType("IfcComplexPropertyTemplate", 1129)]
public class IfcComplexPropertyTemplate : IfcPropertyTemplate, IIfcComplexPropertyTemplate, IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcComplexPropertyTemplate>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _usageName;

	private IfcComplexPropertyTemplateTypeEnum? _templateType;

	private readonly OptionalItemSet<IfcPropertyTemplate> _hasPropertyTemplates;

	[CrossSchemaAttribute(typeof(IIfcComplexPropertyTemplate), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcComplexPropertyTemplate.UsageName
	{
		get
		{
			if (!UsageName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UsageName.Value);
		}
		set
		{
			UsageName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcComplexPropertyTemplate), 6)]
	Xbim.Ifc4.Interfaces.IfcComplexPropertyTemplateTypeEnum? IIfcComplexPropertyTemplate.TemplateType
	{
		get
		{
			return TemplateType switch
			{
				IfcComplexPropertyTemplateTypeEnum.P_COMPLEX => Xbim.Ifc4.Interfaces.IfcComplexPropertyTemplateTypeEnum.P_COMPLEX, 
				IfcComplexPropertyTemplateTypeEnum.Q_COMPLEX => Xbim.Ifc4.Interfaces.IfcComplexPropertyTemplateTypeEnum.Q_COMPLEX, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcComplexPropertyTemplateTypeEnum.P_COMPLEX:
				TemplateType = IfcComplexPropertyTemplateTypeEnum.P_COMPLEX;
				break;
			case Xbim.Ifc4.Interfaces.IfcComplexPropertyTemplateTypeEnum.Q_COMPLEX:
				TemplateType = IfcComplexPropertyTemplateTypeEnum.Q_COMPLEX;
				break;
			case null:
				TemplateType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcComplexPropertyTemplate), 7)]
	IItemSet<IIfcPropertyTemplate> IIfcComplexPropertyTemplate.HasPropertyTemplates => new ProxyItemSet<IfcPropertyTemplate, IIfcPropertyTemplate>(HasPropertyTemplates);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UsageName
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
}
