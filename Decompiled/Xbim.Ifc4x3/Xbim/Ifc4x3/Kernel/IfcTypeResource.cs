using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcTypeResource", 1307)]
public abstract class IfcTypeResource : IfcTypeObject, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect, IfcResourceSelect, IEquatable<IfcTypeResource>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _longDescription;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _resourceType;

	[CrossSchemaAttribute(typeof(IIfcTypeResource), 7)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcTypeResource.Identification
	{
		get
		{
			if (!Identification.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identification.Value);
		}
		set
		{
			Identification = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTypeResource), 8)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcTypeResource.LongDescription
	{
		get
		{
			if (!LongDescription.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(LongDescription.Value);
		}
		set
		{
			LongDescription = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTypeResource), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTypeResource.ResourceType
	{
		get
		{
			if (!ResourceType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ResourceType.Value);
		}
		set
		{
			ResourceType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelAssignsToResource> IIfcTypeResource.ResourceOf => base.Model.Instances.Where((IIfcRelAssignsToResource e) => e.RelatingResource as IfcTypeResource == this, "RelatingResource", this);

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Identification
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? LongDescription
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ResourceType
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
