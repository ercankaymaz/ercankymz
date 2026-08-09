using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcTextStyleWithBoxCharacteristics", 730)]
public class IfcTextStyleWithBoxCharacteristics : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcTextStyleSelect, IExpressSelectType, IEquatable<IfcTextStyleWithBoxCharacteristics>
{
	private IfcPositiveLengthMeasure? _boxHeight;

	private IfcPositiveLengthMeasure? _boxWidth;

	private IfcPlaneAngleMeasure? _boxSlantAngle;

	private IfcPlaneAngleMeasure? _boxRotateAngle;

	private IfcSizeSelect _characterSpacing;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcPositiveLengthMeasure? BoxHeight
	{
		get
		{
			if (_activated)
			{
				return _boxHeight;
			}
			Activate();
			return _boxHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_boxHeight = v;
			}, _boxHeight, value, "BoxHeight", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcPositiveLengthMeasure? BoxWidth
	{
		get
		{
			if (_activated)
			{
				return _boxWidth;
			}
			Activate();
			return _boxWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_boxWidth = v;
			}, _boxWidth, value, "BoxWidth", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPlaneAngleMeasure? BoxSlantAngle
	{
		get
		{
			if (_activated)
			{
				return _boxSlantAngle;
			}
			Activate();
			return _boxSlantAngle;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_boxSlantAngle = v;
			}, _boxSlantAngle, value, "BoxSlantAngle", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPlaneAngleMeasure? BoxRotateAngle
	{
		get
		{
			if (_activated)
			{
				return _boxRotateAngle;
			}
			Activate();
			return _boxRotateAngle;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_boxRotateAngle = v;
			}, _boxRotateAngle, value, "BoxRotateAngle", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSizeSelect CharacterSpacing
	{
		get
		{
			if (_activated)
			{
				return _characterSpacing;
			}
			Activate();
			return _characterSpacing;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_characterSpacing = v;
			}, _characterSpacing, value, "CharacterSpacing", 5);
		}
	}

	internal IfcTextStyleWithBoxCharacteristics(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_boxHeight = value.RealVal;
			break;
		case 1:
			_boxWidth = value.RealVal;
			break;
		case 2:
			_boxSlantAngle = value.RealVal;
			break;
		case 3:
			_boxRotateAngle = value.RealVal;
			break;
		case 4:
			_characterSpacing = (IfcSizeSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextStyleWithBoxCharacteristics other)
	{
		return this == other;
	}
}
