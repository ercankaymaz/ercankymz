using System;
using CSMath;

namespace ACadSharp.XData;

public abstract class ExtendedDataRecord
{
	private DxfCode _code;

	protected object _value;

	public DxfCode Code => _code;

	public object RawValue => _value;

	protected ExtendedDataRecord(DxfCode code, object value)
	{
		_code = code;
		_value = value;
	}

	public override string ToString()
	{
		return $"{Code}:{_value}";
	}

	public static ExtendedDataRecord Create(GroupCodeValueType groupCode, object value)
	{
		switch (groupCode)
		{
		case GroupCodeValueType.Bool:
			return new ExtendedDataInteger16(((bool)value) ? ((short)1) : ((short)0));
		case GroupCodeValueType.Point3D:
			return new ExtendedDataCoordinate((XYZ)value);
		case GroupCodeValueType.Handle:
		case GroupCodeValueType.ObjectId:
			return new ExtendedDataHandle((ulong)value);
		case GroupCodeValueType.String:
		case GroupCodeValueType.Comment:
		case GroupCodeValueType.ExtendedDataString:
			return new ExtendedDataString((string)value);
		case GroupCodeValueType.Chunk:
		case GroupCodeValueType.ExtendedDataChunk:
			return new ExtendedDataBinaryChunk((byte[])value);
		case GroupCodeValueType.ExtendedDataHandle:
			return new ExtendedDataHandle((ulong)value);
		case GroupCodeValueType.Double:
		case GroupCodeValueType.ExtendedDataDouble:
			return new ExtendedDataReal((double)value);
		case GroupCodeValueType.Int16:
		case GroupCodeValueType.ExtendedDataInt16:
			return new ExtendedDataInteger16((short)value);
		case GroupCodeValueType.Int32:
		case GroupCodeValueType.ExtendedDataInt32:
			return new ExtendedDataInteger32((int)value);
		default:
			throw new NotSupportedException();
		}
	}
}
public abstract class ExtendedDataRecord<T> : ExtendedDataRecord
{
	public T Value
	{
		get
		{
			return (T)_value;
		}
		set
		{
			_value = value;
		}
	}

	protected ExtendedDataRecord(DxfCode code, T value)
		: base(code, value)
	{
	}
}
