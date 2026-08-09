using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.SharedBldgElements;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcElement", 19)]
public abstract class IfcElement : IfcProduct, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcElement>
{
	private IfcIdentifier? _tag;

	IfcIdentifier? IIfcElement.Tag
	{
		get
		{
			return Tag;
		}
		set
		{
			Tag = value;
		}
	}

	IEnumerable<IIfcRelFillsElement> IIfcElement.FillsVoids => FillsVoids;

	IEnumerable<IIfcRelConnectsElements> IIfcElement.ConnectedTo => ConnectedTo;

	IEnumerable<IIfcRelInterferesElements> IIfcElement.IsInterferedByElements => IsInterferedByElements;

	IEnumerable<IIfcRelInterferesElements> IIfcElement.InterferesElements => InterferesElements;

	IEnumerable<IIfcRelProjectsElement> IIfcElement.HasProjections => HasProjections;

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcElement.ReferencedInStructures => ReferencedInStructures;

	IEnumerable<IIfcRelVoidsElement> IIfcElement.HasOpenings => HasOpenings;

	IEnumerable<IIfcRelConnectsWithRealizingElements> IIfcElement.IsConnectionRealization => IsConnectionRealization;

	IEnumerable<IIfcRelSpaceBoundary> IIfcElement.ProvidesBoundaries => ProvidesBoundaries;

	IEnumerable<IIfcRelConnectsElements> IIfcElement.ConnectedFrom => ConnectedFrom;

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcElement.ContainedInStructure => ContainedInStructure;

	IEnumerable<IIfcRelCoversBldgElements> IIfcElement.HasCoverings => HasCoverings;

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcIdentifier? Tag
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 8);
		}
	}

	[InverseProperty("RelatedBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 21)]
	public IEnumerable<IfcRelFillsElement> FillsVoids => base.Model.Instances.Where((IfcRelFillsElement e) => Equals(e.RelatedBuildingElement), "RelatedBuildingElement", this);

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 22)]
	public IEnumerable<IfcRelConnectsElements> ConnectedTo => base.Model.Instances.Where((IfcRelConnectsElements e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatedElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 23)]
	public IEnumerable<IfcRelInterferesElements> IsInterferedByElements => base.Model.Instances.Where((IfcRelInterferesElements e) => Equals(e.RelatedElement), "RelatedElement", this);

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 24)]
	public IEnumerable<IfcRelInterferesElements> InterferesElements => base.Model.Instances.Where((IfcRelInterferesElements e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 25)]
	public IEnumerable<IfcRelProjectsElement> HasProjections => base.Model.Instances.Where((IfcRelProjectsElement e) => Equals(e.RelatingElement), "RelatingElement", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 26)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencedInStructures => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[InverseProperty("RelatingBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 27)]
	public IEnumerable<IfcRelVoidsElement> HasOpenings => base.Model.Instances.Where((IfcRelVoidsElement e) => Equals(e.RelatingBuildingElement), "RelatingBuildingElement", this);

	[InverseProperty("RealizingElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 28)]
	public IEnumerable<IfcRelConnectsWithRealizingElements> IsConnectionRealization => base.Model.Instances.Where((IfcRelConnectsWithRealizingElements e) => e.RealizingElements != null && e.RealizingElements.Contains(this), "RealizingElements", this);

	[InverseProperty("RelatedBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 29)]
	public IEnumerable<IfcRelSpaceBoundary> ProvidesBoundaries => base.Model.Instances.Where((IfcRelSpaceBoundary e) => Equals(e.RelatedBuildingElement), "RelatedBuildingElement", this);

	[InverseProperty("RelatedElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 30)]
	public IEnumerable<IfcRelConnectsElements> ConnectedFrom => base.Model.Instances.Where((IfcRelConnectsElements e) => Equals(e.RelatedElement), "RelatedElement", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 31)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainedInStructure => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[InverseProperty("RelatingBuildingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 32)]
	public IEnumerable<IfcRelCoversBldgElements> HasCoverings => base.Model.Instances.Where((IfcRelCoversBldgElements e) => Equals(e.RelatingBuildingElement), "RelatingBuildingElement", this);

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
