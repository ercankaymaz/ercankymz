using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLoadCase", 1281)]
public class IfcStructuralLoadCase : IfcStructuralLoadGroup, IIfcStructuralLoadCase, IIfcStructuralLoadGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcStructuralLoadCase>
{
	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure> _selfWeightCoefficients;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadCase), 11)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcRatioMeasure> IIfcStructuralLoadCase.SelfWeightCoefficients => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure, Xbim.Ifc4.MeasureResource.IfcRatioMeasure>(SelfWeightCoefficients, (Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure s) => new Xbim.Ifc4.MeasureResource.IfcRatioMeasure(s), (Xbim.Ifc4.MeasureResource.IfcRatioMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure(t));

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { 3 }, 26)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure> SelfWeightCoefficients
	{
		get
		{
			if (_activated)
			{
				return _selfWeightCoefficients;
			}
			Activate();
			return _selfWeightCoefficients;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcStructuralLoadCase(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_selfWeightCoefficients = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure>(this, 3, 11);
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
		case 8:
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_selfWeightCoefficients.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadCase other)
	{
		return this == other;
	}
}
