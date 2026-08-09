using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralAction", 40)]
public abstract class IfcStructuralAction : IfcStructuralActivity, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcStructuralAction>
{
	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _destabilizingLoad;

	[CrossSchemaAttribute(typeof(IIfcStructuralAction), 10)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcStructuralAction.DestabilizingLoad
	{
		get
		{
			if (!DestabilizingLoad.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(DestabilizingLoad.Value);
		}
		set
		{
			DestabilizingLoad = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? DestabilizingLoad
	{
		get
		{
			if (_activated)
			{
				return _destabilizingLoad;
			}
			Activate();
			return _destabilizingLoad;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
			{
				_destabilizingLoad = v;
			}, _destabilizingLoad, value, "DestabilizingLoad", 10);
		}
	}

	internal IfcStructuralAction(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_destabilizingLoad = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralAction other)
	{
		return this == other;
	}
}
