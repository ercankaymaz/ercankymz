using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralAction", 40)]
public abstract class IfcStructuralAction : IfcStructuralActivity, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcStructuralAction>
{
	private bool _destabilizingLoad;

	private IfcStructuralReaction _causedBy;

	[CrossSchemaAttribute(typeof(IIfcStructuralAction), 10)]
	IfcBoolean? IIfcStructuralAction.DestabilizingLoad
	{
		get
		{
			return new IfcBoolean(DestabilizingLoad);
		}
		set
		{
			if (!value.HasValue)
			{
				DestabilizingLoad = false;
			}
			else
			{
				DestabilizingLoad = value.Value;
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public bool DestabilizingLoad
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
			SetValue(delegate(bool v)
			{
				_destabilizingLoad = v;
			}, _destabilizingLoad, value, "DestabilizingLoad", 10);
		}
	}

	[IndexedProperty]
	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
	public IfcStructuralReaction CausedBy
	{
		get
		{
			if (_activated)
			{
				return _causedBy;
			}
			Activate();
			return _causedBy;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralReaction v)
			{
				_causedBy = v;
			}, _causedBy, value, "CausedBy", 11);
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
		case 10:
			_causedBy = (IfcStructuralReaction)value.EntityVal;
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
