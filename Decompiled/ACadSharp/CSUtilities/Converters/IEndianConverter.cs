namespace CSUtilities.Converters;

internal interface IEndianConverter
{
	byte[] GetBytes(char value);

	byte[] GetBytes(short value);

	byte[] GetBytes(ushort value);

	byte[] GetBytes(int value);

	byte[] GetBytes(uint value);

	byte[] GetBytes(long value);

	byte[] GetBytes(ulong value);

	byte[] GetBytes(double value);

	byte[] GetBytes(float value);

	char ToChar(byte[] arr);

	short ToInt16(byte[] arr);

	ushort ToUInt16(byte[] arr);

	int ToInt32(byte[] arr);

	uint ToUInt32(byte[] arr);

	long ToInt64(byte[] arr);

	ulong ToUInt64(byte[] arr);

	double ToDouble(byte[] arr);

	float ToSingle(byte[] arr);

	char ToChar(byte[] arr, int offset);

	short ToInt16(byte[] arr, int offset);

	ushort ToUInt16(byte[] arr, int offset);

	int ToInt32(byte[] arr, int offset);

	uint ToUInt32(byte[] arr, int offset);

	long ToInt64(byte[] arr, int offset);

	ulong ToUInt64(byte[] arr, int offset);

	double ToDouble(byte[] arr, int offset);

	float ToSingle(byte[] arr, int offset);

	byte[] GetBytes<T>(T value) where T : struct;
}
