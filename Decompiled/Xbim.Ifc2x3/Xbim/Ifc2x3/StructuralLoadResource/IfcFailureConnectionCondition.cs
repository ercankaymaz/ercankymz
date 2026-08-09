using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcFailureConnectionCondition", 640)]
public class IfcFailureConnectionCondition : IfcStructuralConnectionCondition, IIfcFailureConnectionCondition, IIfcStructuralConnectionCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcFailureConnectionCondition>
{
	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _tensionFailureX;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _tensionFailureY;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _tensionFailureZ;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _compressionFailureX;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _compressionFailureY;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _compressionFailureZ;

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 2)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureX
	{
		get
		{
			if (!TensionFailureX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(TensionFailureX.Value);
		}
		set
		{
			TensionFailureX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 3)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureY
	{
		get
		{
			if (!TensionFailureY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(TensionFailureY.Value);
		}
		set
		{
			TensionFailureY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 4)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.TensionFailureZ
	{
		get
		{
			if (!TensionFailureZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(TensionFailureZ.Value);
		}
		set
		{
			TensionFailureZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 5)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureX
	{
		get
		{
			if (!CompressionFailureX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(CompressionFailureX.Value);
		}
		set
		{
			CompressionFailureX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 6)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureY
	{
		get
		{
			if (!CompressionFailureY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(CompressionFailureY.Value);
		}
		set
		{
			CompressionFailureY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFailureConnectionCondition), 7)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcFailureConnectionCondition.CompressionFailureZ
	{
		get
		{
			if (!CompressionFailureZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(CompressionFailureZ.Value);
		}
		set
		{
			CompressionFailureZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? TensionFailureX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_tensionFailureX = v;
			}, _tensionFailureX, value, "TensionFailureX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? TensionFailureY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_tensionFailureY = v;
			}, _tensionFailureY, value, "TensionFailureY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? TensionFailureZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_tensionFailureZ = v;
			}, _tensionFailureZ, value, "TensionFailureZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? CompressionFailureX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_compressionFailureX = v;
			}, _compressionFailureX, value, "CompressionFailureX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? CompressionFailureY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_compressionFailureY = v;
			}, _compressionFailureY, value, "CompressionFailureY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? CompressionFailureZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
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
