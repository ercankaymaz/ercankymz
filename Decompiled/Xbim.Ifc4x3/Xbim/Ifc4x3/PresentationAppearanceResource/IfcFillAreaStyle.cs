using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyle", 33)]
public class IfcFillAreaStyle : IfcPresentationStyle, IIfcFillAreaStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcFillAreaStyle>
{
	private readonly ItemSet<IfcFillStyleSelect> _fillStyles;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _modelOrDraughting;

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyle), 2)]
	IItemSet<IIfcFillStyleSelect> IIfcFillAreaStyle.FillStyles => new ProxyItemSet<IfcFillStyleSelect, IIfcFillStyleSelect>(FillStyles);

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyle), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcFillAreaStyle.ModelorDraughting
	{
		get
		{
			if (!ModelOrDraughting.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(ModelOrDraughting.Value);
		}
		set
		{
			ModelOrDraughting = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcFillStyleSelect> FillStyles
	{
		get
		{
			if (_activated)
			{
				return _fillStyles;
			}
			Activate();
			return _fillStyles;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? ModelOrDraughting
	{
		get
		{
			if (_activated)
			{
				return _modelOrDraughting;
			}
			Activate();
			return _modelOrDraughting;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
			{
				_modelOrDraughting = v;
			}, _modelOrDraughting, value, "ModelOrDraughting", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFillStyleSelect fillStyle in FillStyles)
			{
				yield return fillStyle;
			}
		}
	}

	internal IfcFillAreaStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_fillStyles = new ItemSet<IfcFillStyleSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_fillStyles.InternalAdd((IfcFillStyleSelect)value.EntityVal);
			break;
		case 2:
			_modelOrDraughting = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFillAreaStyle other)
	{
		return this == other;
	}
}
