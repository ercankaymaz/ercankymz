using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertyReferenceValue", 277)]
public class IfcPropertyReferenceValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyReferenceValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyReferenceValue>
{
	private IfcText? _usageName;

	private IfcObjectReferenceSelect _propertyReference;

	IfcText? IIfcPropertyReferenceValue.UsageName
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

	IIfcObjectReferenceSelect IIfcPropertyReferenceValue.PropertyReference
	{
		get
		{
			return PropertyReference;
		}
		set
		{
			PropertyReference = value as IfcObjectReferenceSelect;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcText? UsageName
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
			SetValue(delegate(IfcText? v)
			{
				_usageName = v;
			}, _usageName, value, "UsageName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
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
