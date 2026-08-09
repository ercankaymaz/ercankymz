using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingElement", 262)]
public abstract class IfcReinforcingElement : IfcBuildingElementComponent, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcReinforcingElement>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _steelGrade;

	[CrossSchemaAttribute(typeof(IIfcReinforcingElement), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcReinforcingElement.SteelGrade
	{
		get
		{
			if (!SteelGrade.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(SteelGrade.Value);
		}
		set
		{
			SteelGrade = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? SteelGrade
	{
		get
		{
			if (_activated)
			{
				return _steelGrade;
			}
			Activate();
			return _steelGrade;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_steelGrade = v;
			}, _steelGrade, value, "SteelGrade", 9);
		}
	}

	internal IfcReinforcingElement(IModel model, int label, bool activated)
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
			_steelGrade = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingElement other)
	{
		return this == other;
	}
}
