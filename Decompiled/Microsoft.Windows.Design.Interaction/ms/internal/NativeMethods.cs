namespace MS.Internal;

internal static class NativeMethods
{
	internal struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	internal const int SM_CXDOUBLECLK = 36;

	internal const int SM_CYDOUBLECLK = 37;

	internal const int SPI_GETMOUSEHOVERWIDTH = 98;

	internal const int SPI_GETMOUSEHOVERHEIGHT = 100;

	internal const int SPI_GETMOUSEHOVERTIME = 102;

	internal const int GWL_STYLE = -16;

	internal const int GWL_EXSTYLE = -20;

	internal const int WS_EX_LAYOUTRTL = 4194304;
}
