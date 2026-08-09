namespace ACadSharp.IO.DXF;

internal interface IDxfStreamReader
{
	DxfCode DxfCode { get; }

	GroupCodeValueType GroupCodeValue { get; }

	int Code { get; }

	object Value { get; }

	int Position { get; }

	string ValueAsString { get; }

	string ValueRaw { get; }

	bool ValueAsBool { get; }

	short ValueAsShort { get; }

	ushort ValueAsUShort { get; }

	int ValueAsInt { get; }

	long ValueAsLong { get; }

	double ValueAsDouble { get; }

	double ValueAsAngle { get; }

	ulong ValueAsHandle { get; }

	byte[] ValueAsBinaryChunk { get; }

	bool Find(string dxfEntry);

	void Start();

	void ReadNext();

	void ExpectedCode(int code);
}
