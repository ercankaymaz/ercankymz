namespace ACadSharp.Tables;

public enum ZeroHandling : byte
{
	SuppressZeroFeetAndInches = 0,
	ShowZeroFeetAndInches = 1,
	ShowZeroFeetSuppressZeroInches = 2,
	SuppressZeroFeetShowZeroInches = 3,
	SuppressDecimalLeadingZeroes = 4,
	SuppressDecimalTrailingZeroes = 8,
	SuppressDecimalLeadingAndTrailingZeroes = 12
}
