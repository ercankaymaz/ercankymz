using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.StructuralAnalysisDomain;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcElement", 19)]
public abstract class IfcElement : Xbim.Ifc2x3.Kernel.IfcProduct, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IIfcDistributionElement, Xbim.Ifc2x3.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IEquatable<IfcElement>
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier? _tag;

	[CrossSchemaAttribute(typeof(IIfcElement), 8)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcElement.Tag
	{
		get
		{
			if (!Tag.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Tag.Value);
		}
		set
		{
			Tag = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	IEnumerable<IIfcRelFillsElement> IIfcElement.FillsVoids => base.Model.Instances.Where((IIfcRelFillsElement e) => e.RelatedBuildingElement as IfcElement == this, "RelatedBuildingElement", this);

	IEnumerable<IIfcRelConnectsElements> IIfcElement.ConnectedTo => base.Model.Instances.Where((IIfcRelConnectsElements e) => e.RelatingElement as IfcElement == this, "RelatingElement", this);

	IEnumerable<IIfcRelInterferesElements> IIfcElement.IsInterferedByElements => base.Model.Instances.Where((IIfcRelInterferesElements e) => e.RelatedElement as IfcElement == this, "RelatedElement", this);

	IEnumerable<IIfcRelInterferesElements> IIfcElement.InterferesElements => base.Model.Instances.Where((IIfcRelInterferesElements e) => e.RelatingElement as IfcElement == this, "RelatingElement", this);

	IEnumerable<IIfcRelProjectsElement> IIfcElement.HasProjections => base.Model.Instances.Where((IIfcRelProjectsElement e) => e.RelatingElement as IfcElement == this, "RelatingElement", this);

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcElement.ReferencedInStructures => base.Model.Instances.Where((IIfcRelReferencedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	IEnumerable<IIfcRelVoidsElement> IIfcElement.HasOpenings => base.Model.Instances.Where((IIfcRelVoidsElement e) => e.RelatingBuildingElement as IfcElement == this, "RelatingBuildingElement", this);

	IEnumerable<IIfcRelConnectsWithRealizingElements> IIfcElement.IsConnectionRealization => base.Model.Instances.Where((IIfcRelConnectsWithRealizingElements e) => e.RealizingElements != null && e.RealizingElements.Contains(this), "RealizingElements", this);

	IEnumerable<IIfcRelSpaceBoundary> IIfcElement.ProvidesBoundaries => base.Model.Instances.Where((IIfcRelSpaceBoundary e) => e.RelatedBuildingElement as IfcElement == this, "RelatedBuildingElement", this);

	IEnumerable<IIfcRelConnectsElements> IIfcElement.ConnectedFrom => base.Model.Instances.Where((IIfcRelConnectsElements e) => e.RelatedElement as IfcElement == this, "RelatedElement", this);

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcElement.ContainedInStructure => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	IEnumerable<IIfcRelCoversBldgElements> IIfcElement.HasCoverings => base.Model.Instances.Where((IIfcRelCoversBldgElements e) => e.RelatingBuildingElement as IfcElement == this, "RelatingBuildingElement", this);

	IEnumerable<IIfcRelConnectsPortToElement> IIfcDistributionElement.HasPorts => HasPorts;

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier? Tag
	{
		get
		{
			if (_activated)
			{
				return _tag;
			}
			Activate();
			return _tag;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 8);
		}
	}

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 15)]
	public IEnumerable<IfcRelConnectsStructuralElement> HasStructuralMember => base.Model.Instances.Where((IfcRelConnectsStructuralElement e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatedBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 16)]
	public IEnumerable<IfcRelFillsElement> FillsVoids => base.Model.Instances.Where((IfcRelFillsElement e) => Equals(e.RelatedBuildingElement), "RelatedBuildingElement", this);

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelConnectsElements> ConnectedTo => base.Model.Instances.Where((IfcRelConnectsElements e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatingBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelCoversBldgElements> HasCoverings => base.Model.Instances.Where((IfcRelCoversBldgElements e) => Equals(e.RelatingBuildingElement), "RelatingBuildingElement", this);

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 19)]
	public IEnumerable<IfcRelProjectsElement> HasProjections => base.Model.Instances.Where((IfcRelProjectsElement e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 20)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencedInStructures => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[InverseProperty("RelatedElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
	public IEnumerable<IfcRelConnectsPortToElement> HasPorts => base.Model.Instances.Where((IfcRelConnectsPortToElement e) => Equals(e.RelatedElement), "RelatedElement", this);

	[InverseProperty("RelatingBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 22)]
	public IEnumerable<IfcRelVoidsElement> HasOpenings => base.Model.Instances.Where((IfcRelVoidsElement e) => Equals(e.RelatingBuildingElement), "RelatingBuildingElement", this);

	[InverseProperty("RealizingElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 23)]
	public IEnumerable<IfcRelConnectsWithRealizingElements> IsConnectionRealization => base.Model.Instances.Where((IfcRelConnectsWithRealizingElements e) => e.RealizingElements != null && e.RealizingElements.Contains(this), "RealizingElements", this);

	[InverseProperty("RelatedBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 24)]
	public IEnumerable<IfcRelSpaceBoundary> ProvidesBoundaries => base.Model.Instances.Where((IfcRelSpaceBoundary e) => Equals(e.RelatedBuildingElement), "RelatedBuildingElement", this);

	[InverseProperty("RelatedElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 25)]
	public IEnumerable<IfcRelConnectsElements> ConnectedFrom => base.Model.Instances.Where((IfcRelConnectsElements e) => Equals(e.RelatedElement), "RelatedElement", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 26)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainedInStructure => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	public IEnumerable<IfcOpeningElement> Openings => (from rv in base.Model.Instances
		where rv.RelatingBuildingElement == this
		select rv.RelatedOpeningElement).OfType<IfcOpeningElement>();

	internal IfcElement(IModel model, int label, bool activated)
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_tag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElement other)
	{
		return this == other;
	}
}
