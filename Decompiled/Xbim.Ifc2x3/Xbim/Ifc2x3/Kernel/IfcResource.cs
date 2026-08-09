using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcResource", 158)]
public abstract class IfcResource : IfcObject, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IEquatable<IfcResource>
{
	private IfcIdentifier? _identification;

	private IfcText? _longDescription;

	[CrossSchemaAttribute(typeof(IIfcResource), 6)]
	IfcIdentifier? IIfcResource.Identification
	{
		get
		{
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", -6);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResource), 7)]
	IfcText? IIfcResource.LongDescription
	{
		get
		{
			return _longDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", -7);
		}
	}

	IEnumerable<IIfcRelAssignsToResource> IIfcResource.ResourceOf => base.Model.Instances.Where((IIfcRelAssignsToResource e) => e.RelatingResource as IfcResource == this, "RelatingResource", this);

	[InverseProperty("RelatingResource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelAssignsToResource> ResourceOf => base.Model.Instances.Where((IfcRelAssignsToResource e) => Equals(e.RelatingResource), "RelatingResource", this);

	internal IfcResource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcResource other)
	{
		return this == other;
	}
}
