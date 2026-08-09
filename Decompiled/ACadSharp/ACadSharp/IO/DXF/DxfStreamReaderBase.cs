using System;
using System.IO;
using ACadSharp.Exceptions;
using CSMath;

namespace ACadSharp.IO.DXF;

internal abstract class DxfStreamReaderBase : IDxfStreamReader
{
	public DxfCode DxfCode { get; protected set; }

	public GroupCodeValueType GroupCodeValue { get; protected set; }

	public int Code => (int)DxfCode;

	public object Value { get; protected set; }

	public virtual int Position { get; protected set; }

	public string ValueRaw { get; protected set; }

	public string ValueAsString => Value.ToString().Replace("^J", "\n").Replace("^M", "\r")
		.Replace("^I", "\t")
		.Replace("^ ", "^");

	public bool ValueAsBool => Convert.ToBoolean(Value);

	public short ValueAsShort => Convert.ToInt16(Value);

	public ushort ValueAsUShort => Convert.ToUInt16(Value);

	public int ValueAsInt => Convert.ToInt32(Value);

	public long ValueAsLong => Convert.ToInt64(Value);

	public double ValueAsDouble => Convert.ToDouble(Value);

	public double ValueAsAngle => MathHelper.DegToRad(Convert.ToDouble(Value));

	public ulong ValueAsHandle => (ulong)Value;

	public byte[] ValueAsBinaryChunk => Value as byte[];

	protected abstract Stream baseStream { get; }

	public virtual void ReadNext()
	{
		DxfCode = readCode();
		GroupCodeValue = ACadSharp.GroupCodeValue.TransformValue(Code);
		Value = transformValue(GroupCodeValue);
	}

	public bool Find(string dxfEntry)
	{
		Start();
		do
		{
			ReadNext();
		}
		while (ValueAsString != dxfEntry && ValueAsString != "EOF");
		return ValueAsString == dxfEntry;
	}

	public void ExpectedCode(int code)
	{
		ReadNext();
		if (Code != code)
		{
			throw new DxfException(code, Position);
		}
	}

	public override string ToString()
	{
		return $"{Code} | {Value}";
	}

	public virtual void Start()
	{
		DxfCode = DxfCode.Invalid;
		Value = string.Empty;
		baseStream.Position = 0L;
		Position = 0;
	}

	protected abstract DxfCode readCode();

	protected abstract string readStringLine();

	protected abstract double lineAsDouble();

	protected abstract short lineAsShort();

	protected abstract int lineAsInt();

	protected abstract long lineAsLong();

	protected abstract ulong lineAsHandle();

	protected abstract byte[] lineAsBinaryChunk();

	protected abstract bool lineAsBool();

	private object transformValue(GroupCodeValueType code)
	{
		switch (code)
		{
		case GroupCodeValueType.String:
		case GroupCodeValueType.Comment:
		case GroupCodeValueType.ExtendedDataString:
			return readStringLine();
		case GroupCodeValueType.Point3D:
		case GroupCodeValueType.Double:
		case GroupCodeValueType.ExtendedDataDouble:
			return lineAsDouble();
		case GroupCodeValueType.Byte:
		case GroupCodeValueType.Int16:
		case GroupCodeValueType.ExtendedDataInt16:
			return lineAsShort();
		case GroupCodeValueType.Int32:
		case GroupCodeValueType.ExtendedDataInt32:
			return lineAsInt();
		case GroupCodeValueType.Int64:
			return lineAsLong();
		case GroupCodeValueType.Handle:
		case GroupCodeValueType.ObjectId:
		case GroupCodeValueType.ExtendedDataHandle:
			return lineAsHandle();
		case GroupCodeValueType.Bool:
			return lineAsBool();
		case GroupCodeValueType.Chunk:
		case GroupCodeValueType.ExtendedDataChunk:
			return lineAsBinaryChunk();
		default:
			throw new DxfException((int)code, Position);
		}
	}
}
