using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcTypeResource", 1307)]
public abstract class IfcTypeResource : IfcTypeObject, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IEquatable<IfcTypeResource>
{
	private IfcIdentifier? _identification;

	private IfcText? _longDescription;

	private IfcLabel? _resourceType;

	IfcIdentifier? IIfcTypeResource.Identification
	{
		get
		{
			return Identification;
		}
		set
		{
			Identification = value;
		}
	}

	IfcText? IIfcTypeResource.LongDescription
	{
		get
		{
			return LongDescription;
		}
		set
		{
			LongDescription = value;
		}
	}

	IfcLabel? IIfcTypeResource.ResourceType
	{
		get
		{
			return ResourceType;
		}
		set
		{
			ResourceType = value;
		}
	}

	IEnumerable<IIfcRelAssignsToResource> IIfcTypeResource.ResourceOf => ResourceOf;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcIdentifier? Identification
	{
		get
		{
			if (_activated)
			{
				return _identification;
			}
			Activate();
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcText? LongDescription
	{
		get
		{
			if (_activated)
			{
				return _longDescription;
			}
			Activate();
			return _longDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcLabel? ResourceType
	{
		get
		{
			if (_activated)
			{
				return _resourceType;
			}
			Activate();
			return _resourceType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_resourceType = v;
			}, _resourceType, value, "ResourceType", 9);
		}
	}

	[InverseProperty("RelatingResource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelAssignsToResource> ResourceOf => base.Model.Instances.Where((IfcRelAssignsToResource e) => Equals(e.RelatingResource), "RelatingResource", this);

	internal IfcTypeResource(IModel model, int label, bool activated)
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
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_identification = value.StringVal;
			break;
		case 7:
			_longDescription = value.StringVal;
			break;
		case 8:
			_resourceType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTypeResource other)
	{
		return this == other;
	}
}
