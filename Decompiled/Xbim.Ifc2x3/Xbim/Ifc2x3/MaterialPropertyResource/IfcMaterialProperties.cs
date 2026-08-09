using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces.Conversions;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcMaterialProperties", 437)]
public abstract class IfcMaterialProperties : PersistEntity, IIfcMaterialProperties, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcMaterialProperties>
{
	private Xbim.Ifc4.MeasureResource.IfcIdentifier? _name;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	private IfcMaterial _material;

	[CrossSchemaAttribute(typeof(IIfcMaterialProperties), 4)]
	IIfcMaterialDefinition IIfcMaterialProperties.Material
	{
		get
		{
			return Material;
		}
		set
		{
			Material = value as IfcMaterial;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialProperties), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExtendedProperties.Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcIdentifier? v)
			{
				_name = v;
			}, _name, value, "Name", -1);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialProperties), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcExtendedProperties.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -2);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialProperties), 3)]
	IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties
	{
		get
		{
			IEnumerable<PropertyInfo> enumerable = from p in GetType().GetProperties()
				where typeof(Xbim.Ifc2x3.MeasureResource.IfcValue).IsAssignableFrom(p.PropertyType)
				select p;
			foreach (PropertyInfo item in enumerable)
			{
				string name = item.Name;
				object value = item.GetValue(this, null);
				if (value != null)
				{
					Type sourceType = (item.PropertyType.IsGenericType ? item.PropertyType.GetGenericArguments()[0] : item.PropertyType);
					Type type = typeof(Xbim.Ifc4.MeasureResource.IfcValue).Assembly.GetTypes().FirstOrDefault((Type t) => t.IsValueType && string.Compare(t.Name, sourceType.Name, StringComparison.OrdinalIgnoreCase) == 0);
					if (!(type == null))
					{
						Xbim.Ifc4.MeasureResource.IfcValue value2 = Activator.CreateInstance(type, value) as Xbim.Ifc4.MeasureResource.IfcValue;
						yield return new IfcPropertySingleValueTransient(name, value2);
					}
				}
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcMaterial Material
	{
		get
		{
			if (_activated)
			{
				return _material;
			}
			Activate();
			return _material;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_material = v;
			}, _material, value, "Material", 1);
		}
	}

	internal IfcMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_material = (IfcMaterial)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMaterialProperties other)
	{
		return this == other;
	}
}
