using System;

namespace CSUtilities.Converters;

internal class LittleEndianConverter : EndianConverter
{
	public static LittleEndianConverter Instance = new LittleEndianConverter();

	private static IEndianConverter init()
	{
		if (BitConverter.IsLittleEndian)
		{
			return new DefaultEndianConverter();
		}
		return new InverseConverter();
	}

	public LittleEndianConverter()
		: base(init())
	{
	}
}
