using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Formats.Asn1;

[ComVisible(true)]
public struct AsnReaderOptions
{
	private const int DefaultTwoDigitMax = 2049;

	private ushort _twoDigitYearMax;

	public int UtcTimeTwoDigitYearMax
	{
		get
		{
			if (_twoDigitYearMax == 0)
			{
				return 2049;
			}
			return _twoDigitYearMax;
		}
		set
		{
			if (value < 1 || value > 9999)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_twoDigitYearMax = (ushort)value;
		}
	}

	public bool SkipSetSortOrderVerification
	{
		[System_002EFormats_002EAsn1_002EIsReadOnly]
		get;
		set; }
}
