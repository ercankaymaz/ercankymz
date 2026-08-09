using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionControlElement", 468)]
public class IfcDistributionControlElement : IfcDistributionElement, IIfcDistributionControlElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionControlElement>
{
	private IfcIdentifier? _controlElementId;

	IEnumerable<IIfcRelFlowControlElements> IIfcDistributionControlElement.AssignedToFlowElement => base.Model.Instances.Where((IIfcRelFlowControlElements e) => e.RelatedControlElements != null && e.RelatedControlElements.Contains(this), "RelatedControlElements", this);

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public IfcIdentifier? ControlElementId
	{
		get
		{
			if (_activated)
			{
				return _controlElementId;
			}
			Activate();
			return _controlElementId;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_controlElementId = v;
			}, _controlElementId, value, "ControlElementId", 9);
		}
	}

	[InverseProperty("RelatedControlElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 28)]
	public IEnumerable<IfcRelFlowControlElements> AssignedToFlowElement => base.Model.Instances.Where((IfcRelFlowControlElements e) => e.RelatedControlElements != null && e.RelatedControlElements.Contains(this), "RelatedControlElements", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcDistributionControlElement(IModel model, int label, bool activated)
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
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_controlElementId = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionControlElement other)
	{
		return this == other;
	}
}
