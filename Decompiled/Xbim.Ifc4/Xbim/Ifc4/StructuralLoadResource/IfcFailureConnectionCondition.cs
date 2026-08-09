using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcFailureConnectionCondition", 640)]
public class IfcFailureConnectionCondition : IfcStructuralConnectionCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcFailureConnectionCondition, IIfcStructuralConnectionCondition, IEquatable<IfcFailureConnectionCondition>
{
	private IfcForceMeasure? _tensionFailureX;

	private IfcForceMeasure? _tensionFailureY;

	private IfcForceMeasure? _tensionFailureZ;

	private IfcForceMeasure? _compressionFailureX;

	private IfcForceMeasure? _compressionFailureY;

	private IfcForceMeasure? _compressionFailureZ;

	IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureX
	{
		get
		{
			return TensionFailureX;
		}
		set
		{
			TensionFailureX = value;
		}
	}

	IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureY
	{
		get
		{
			return TensionFailureY;
		}
		set
		{
			TensionFailureY = value;
		}
	}

	IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureZ
	{
		get
		{
			return TensionFailureZ;
		}
		set
		{
			TensionFailureZ = value;
		}
	}

	IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureX
	{
		get
		{
			return CompressionFailureX;
		}
		set
		{
			CompressionFailureX = value;
		}
	}

	IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureY
	{
		get
		{
			return CompressionFailureY;
		}
		set
		{
			CompressionFailureY = value;
		}
	}

	IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureZ
	{
		get
		{
			return CompressionFailureZ;
		}
		set
		{
			CompressionFailureZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcForceMeasure? TensionFailureX
	{
		get
		{
			if (_activated)
			{
				return _tensionFailureX;
			}
			Activate();
			return _tensionFailureX;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_tensionFailureX = v;
			}, _tensionFailureX, value, "TensionFailureX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcForceMeasure? TensionFailureY
	{
		get
		{
			if (_activated)
			{
				return _tensionFailureY;
			}
			Activate();
			return _tensionFailureY;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_tensionFailureY = v;
			}, _tensionFailureY, value, "TensionFailureY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcForceMeasure? TensionFailureZ
	{
		get
		{
			if (_activated)
			{
				return _tensionFailureZ;
			}
			Activate();
			return _tensionFailureZ;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_tensionFailureZ = v;
			}, _tensionFailureZ, value, "TensionFailureZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcForceMeasure? CompressionFailureX
	{
		get
		{
			if (_activated)
			{
				return _compressionFailureX;
			}
			Activate();
			return _compressionFailureX;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_compressionFailureX = v;
			}, _compressionFailureX, value, "CompressionFailureX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcForceMeasure? CompressionFailureY
	{
		get
		{
			if (_activated)
			{
				return _compressionFailureY;
			}
			Activate();
			return _compressionFailureY;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_compressionFailureY = v;
			}, _compressionFailureY, value, "CompressionFailureY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcForceMeasure? CompressionFailureZ
	{
		get
		{
			if (_activated)
			{
				return _compressionFailureZ;
			}
			Activate();
			return _compressionFailureZ;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_compressionFailureZ = v;
			}, _compressionFailureZ, value, "CompressionFailureZ", 7);
		}
	}

	internal IfcFailureConnectionCondition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_tensionFailureX = value.RealVal;
			break;
		case 2:
			_tensionFailureY = value.RealVal;
			break;
		case 3:
			_tensionFailureZ = value.RealVal;
			break;
		case 4:
			_compressionFailureX = value.RealVal;
			break;
		case 5:
			_compressionFailureY = value.RealVal;
			break;
		case 6:
			_compressionFailureZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFailureConnectionCondition other)
	{
		return this == other;
	}
}
