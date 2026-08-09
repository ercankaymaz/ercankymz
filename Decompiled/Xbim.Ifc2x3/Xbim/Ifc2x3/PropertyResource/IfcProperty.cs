using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcProperty", 5)]
public abstract class IfcProperty : PersistEntity, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcProperty>
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	[CrossSchemaAttribute(typeof(IIfcProperty), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier IIfcProperty.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProperty), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcProperty.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	IEnumerable<IIfcPropertySet> IIfcProperty.PartOfPset => base.Model.Instances.Where((IIfcPropertySet e) => e.HasProperties != null && e.HasProperties.Contains(this), "HasProperties", this);

	IEnumerable<IIfcPropertyDependencyRelationship> IIfcProperty.PropertyForDependance => base.Model.Instances.Where((IIfcPropertyDependencyRelationship e) => e.DependingProperty as IfcProperty == this, "DependingProperty", this);

	IEnumerable<IIfcPropertyDependencyRelationship> IIfcProperty.PropertyDependsOn => base.Model.Instances.Where((IIfcPropertyDependencyRelationship e) => e.DependantProperty as IfcProperty == this, "DependantProperty", this);

	IEnumerable<IIfcComplexProperty> IIfcProperty.PartOfComplex => base.Model.Instances.Where((IIfcComplexProperty e) => e.HasProperties != null && e.HasProperties.Contains(this), "HasProperties", this);

	IEnumerable<IIfcResourceConstraintRelationship> IIfcProperty.HasConstraints => base.Model.Instances.Where((IIfcResourceConstraintRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcResourceApprovalRelationship> IIfcProperty.HasApprovals => base.Model.Instances.Where((IIfcResourceApprovalRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[InverseProperty("DependingProperty")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcPropertyDependencyRelationship> PropertyForDependance => base.Model.Instances.Where((IfcPropertyDependencyRelationship e) => Equals(e.DependingProperty), "DependingProperty", this);

	[InverseProperty("DependantProperty")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcPropertyDependencyRelationship> PropertyDependsOn => base.Model.Instances.Where((IfcPropertyDependencyRelationship e) => Equals(e.DependantProperty), "DependantProperty", this);

	[InverseProperty("HasProperties")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcComplexProperty> PartOfComplex => base.Model.Instances.Where((IfcComplexProperty e) => e.HasProperties != null && e.HasProperties.Contains(this), "HasProperties", this);

	internal IfcProperty(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProperty other)
	{
		return this == other;
	}
}
