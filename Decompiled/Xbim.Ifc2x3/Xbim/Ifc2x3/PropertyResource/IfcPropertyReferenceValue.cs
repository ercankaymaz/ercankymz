using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.TimeSeriesResource;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcPropertyReferenceValue", 277)]
public class IfcPropertyReferenceValue : IfcSimpleProperty, IIfcPropertyReferenceValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyReferenceValue>
{
	private IIfcObjectReferenceSelect _propertyReference4;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _usageName;

	private IfcObjectReferenceSelect _propertyReference;

	[CrossSchemaAttribute(typeof(IIfcPropertyReferenceValue), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcPropertyReferenceValue.UsageName
	{
		get
		{
			if (!UsageName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(UsageName.Value);
		}
		set
		{
			UsageName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyReferenceValue), 4)]
	IIfcObjectReferenceSelect IIfcPropertyReferenceValue.PropertyReference
	{
		get
		{
			if (_propertyReference4 != null)
			{
				return _propertyReference4;
			}
			if (PropertyReference == null)
			{
				return null;
			}
			IfcMaterial ifcMaterial = PropertyReference as IfcMaterial;
			if (ifcMaterial != null)
			{
				return ifcMaterial;
			}
			IfcPerson ifcPerson = PropertyReference as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			_ = PropertyReference as IfcDateAndTime != null;
			_ = PropertyReference as IfcMaterialList != null;
			IfcOrganization ifcOrganization = PropertyReference as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			_ = PropertyReference as IfcCalendarDate != null;
			_ = PropertyReference as IfcLocalTime != null;
			IfcPersonAndOrganization ifcPersonAndOrganization = PropertyReference as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				return ifcPersonAndOrganization;
			}
			IfcMaterialLayer ifcMaterialLayer = PropertyReference as IfcMaterialLayer;
			if (ifcMaterialLayer != null)
			{
				return ifcMaterialLayer;
			}
			Xbim.Ifc2x3.ExternalReferenceResource.IfcExternalReference ifcExternalReference = PropertyReference as Xbim.Ifc2x3.ExternalReferenceResource.IfcExternalReference;
			if (ifcExternalReference != null)
			{
				return ifcExternalReference;
			}
			IfcTimeSeries ifcTimeSeries = PropertyReference as IfcTimeSeries;
			if (ifcTimeSeries != null)
			{
				return ifcTimeSeries;
			}
			IfcAddress ifcAddress = PropertyReference as IfcAddress;
			if (ifcAddress != null)
			{
				return ifcAddress;
			}
			IfcAppliedValue ifcAppliedValue = PropertyReference as IfcAppliedValue;
			if (ifcAppliedValue != null)
			{
				return ifcAppliedValue;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PropertyReference = null;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcAddress ifcAddress = value as IfcAddress;
			if (ifcAddress != null)
			{
				PropertyReference = ifcAddress;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcAppliedValue ifcAppliedValue = value as IfcAppliedValue;
			if (ifcAppliedValue != null)
			{
				PropertyReference = ifcAppliedValue;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			Xbim.Ifc2x3.ExternalReferenceResource.IfcExternalReference ifcExternalReference = value as Xbim.Ifc2x3.ExternalReferenceResource.IfcExternalReference;
			if (ifcExternalReference != null)
			{
				PropertyReference = ifcExternalReference;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcMaterial ifcMaterial = value as IfcMaterial;
			if (ifcMaterial != null)
			{
				PropertyReference = ifcMaterial;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcMaterialLayer ifcMaterialLayer = value as IfcMaterialLayer;
			if (ifcMaterialLayer != null)
			{
				PropertyReference = ifcMaterialLayer;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			if (value as IfcMaterialLayerSet != null)
			{
				throw new NotImplementedException();
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				PropertyReference = ifcOrganization;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				PropertyReference = ifcPerson;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				PropertyReference = ifcPersonAndOrganization;
				if (_propertyReference4 != null)
				{
					SetValue(delegate(IIfcObjectReferenceSelect v)
					{
						_propertyReference4 = v;
					}, _propertyReference4, null, "PropertyReference", -4);
				}
				return;
			}
			if (value as IfcTable != null)
			{
				if (PropertyReference != null)
				{
					PropertyReference = null;
				}
				SetValue(delegate(IIfcObjectReferenceSelect v)
				{
					_propertyReference4 = v;
				}, _propertyReference4, value, "PropertyReference", -4);
				return;
			}
			IfcTimeSeries ifcTimeSeries = value as IfcTimeSeries;
			if (!(ifcTimeSeries != null))
			{
				return;
			}
			PropertyReference = ifcTimeSeries;
			if (_propertyReference4 != null)
			{
				SetValue(delegate(IIfcObjectReferenceSelect v)
				{
					_propertyReference4 = v;
				}, _propertyReference4, null, "PropertyReference", -4);
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UsageName
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_usageName = v;
			}, _usageName, value, "UsageName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcObjectReferenceSelect PropertyReference
	{
		get
		{
			if (_activated)
			{
				return _propertyReference;
			}
			Activate();
			return _propertyReference;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectReferenceSelect v)
			{
				_propertyReference = v;
			}, _propertyReference, value, "PropertyReference", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (PropertyReference != null)
			{
				yield return PropertyReference;
			}
		}
	}

	internal IfcPropertyReferenceValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_usageName = value.StringVal;
			break;
		case 3:
			_propertyReference = (IfcObjectReferenceSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyReferenceValue other)
	{
		return this == other;
	}
}
