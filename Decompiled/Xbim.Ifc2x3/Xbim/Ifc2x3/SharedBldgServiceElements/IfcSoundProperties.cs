using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcSoundProperties", 474)]
public class IfcSoundProperties : IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSoundProperties>
{
	private IfcBoolean _isAttenuating;

	private IfcSoundScaleEnum? _soundScale;

	private readonly ItemSet<IfcSoundValue> _soundValues;

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcBoolean IsAttenuating
	{
		get
		{
			if (_activated)
			{
				return _isAttenuating;
			}
			Activate();
			return _isAttenuating;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isAttenuating = v;
			}, _isAttenuating, value, "IsAttenuating", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcSoundScaleEnum? SoundScale
	{
		get
		{
			if (_activated)
			{
				return _soundScale;
			}
			Activate();
			return _soundScale;
		}
		set
		{
			SetValue(delegate(IfcSoundScaleEnum? v)
			{
				_soundScale = v;
			}, _soundScale, value, "SoundScale", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { 8 }, 10)]
	public IItemSet<IfcSoundValue> SoundValues
	{
		get
		{
			if (_activated)
			{
				return _soundValues;
			}
			Activate();
			return _soundValues;
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
			foreach (IfcSoundValue soundValue in SoundValues)
			{
				yield return soundValue;
			}
		}
	}

	internal IfcSoundProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_soundValues = new ItemSet<IfcSoundValue>(this, 8, 7);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_isAttenuating = value.BooleanVal;
			break;
		case 5:
			_soundScale = (IfcSoundScaleEnum)Enum.Parse(typeof(IfcSoundScaleEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_soundValues.InternalAdd((IfcSoundValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSoundProperties other)
	{
		return this == other;
	}
}
