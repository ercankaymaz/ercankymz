using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ApprovalResource;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcProperty", 5)]
public abstract class IfcProperty : IfcPropertyAbstraction, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcProperty>
{
	private IfcIdentifier _name;

	private IfcText? _description;

	IfcIdentifier IIfcProperty.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcProperty.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IEnumerable<IIfcPropertySet> IIfcProperty.PartOfPset => PartOfPset;

	IEnumerable<IIfcPropertyDependencyRelationship> IIfcProperty.PropertyForDependance => PropertyForDependance;

	IEnumerable<IIfcPropertyDependencyRelationship> IIfcProperty.PropertyDependsOn => PropertyDependsOn;

	IEnumerable<IIfcComplexProperty> IIfcProperty.PartOfComplex => PartOfComplex;

	IEnumerable<IIfcResourceConstraintRelationship> IIfcProperty.HasConstraints => HasConstraints;

	IEnumerable<IIfcResourceApprovalRelationship> IIfcProperty.HasApprovals => HasApprovals;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcIdentifier Name
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
			SetValue(delegate(IfcIdentifier v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcText? Description
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
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[InverseProperty("HasProperties")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcPropertySet> PartOfPset => base.Model.Instances.Where((IfcPropertySet e) => e.HasProperties != null && e.HasProperties.Contains(this), "HasProperties", this);

	[InverseProperty("DependingProperty")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcPropertyDependencyRelationship> PropertyForDependance => base.Model.Instances.Where((IfcPropertyDependencyRelationship e) => Equals(e.DependingProperty), "DependingProperty", this);

	[InverseProperty("DependantProperty")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcPropertyDependencyRelationship> PropertyDependsOn => base.Model.Instances.Where((IfcPropertyDependencyRelationship e) => Equals(e.DependantProperty), "DependantProperty", this);

	[InverseProperty("HasProperties")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcComplexProperty> PartOfComplex => base.Model.Instances.Where((IfcComplexProperty e) => e.HasProperties != null && e.HasProperties.Contains(this), "HasProperties", this);

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcResourceConstraintRelationship> HasConstraints => base.Model.Instances.Where((IfcResourceConstraintRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcResourceApprovalRelationship> HasApprovals => base.Model.Instances.Where((IfcResourceApprovalRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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
