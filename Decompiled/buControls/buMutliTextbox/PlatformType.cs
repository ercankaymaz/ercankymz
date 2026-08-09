using System;
using ns27;

namespace buMutliTextbox;

public static class PlatformType
{
	internal struct Struct30
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public uint uint_0;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public UIntPtr uintptr_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public ushort ushort_2;

		public ushort ushort_3;
	}

	public static Platform GetOperationSystemPlatform()
	{
		Struct30 struct30_ = default(Struct30);
		if (Environment.OSVersion.Version.Major <= 5 && (Environment.OSVersion.Version.Major != 5 || Environment.OSVersion.Version.Minor < 1))
		{
			Class76.GetSystemInfo(ref struct30_);
		}
		else
		{
			Class76.GetNativeSystemInfo(ref struct30_);
		}
		switch (struct30_.ushort_0)
		{
		case 0:
			return Platform.X86;
		case 6:
		case 9:
			return Platform.X64;
		default:
			return Platform.Unknown;
		}
	}
}
