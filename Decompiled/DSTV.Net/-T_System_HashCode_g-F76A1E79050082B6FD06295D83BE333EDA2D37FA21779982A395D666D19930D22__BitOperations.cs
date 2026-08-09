using System.Runtime.CompilerServices;

internal static class _003CT_System_HashCode_g_003EF76A1E79050082B6FD06295D83BE333EDA2D37FA21779982A395D666D19930D22__BitOperations
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint RotateLeft(uint value, int offset)
	{
		return (value << offset) | (value >> 32 - offset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong RotateLeft(ulong value, int offset)
	{
		return (value << offset) | (value >> 64 - offset);
	}
}
