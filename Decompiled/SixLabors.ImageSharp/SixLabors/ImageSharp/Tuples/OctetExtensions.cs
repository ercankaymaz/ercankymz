using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Tuples;

internal static class OctetExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void LoadFrom(this ref Octet<uint> destination, ref Octet<byte> source)
	{
		destination.V0 = source.V0;
		destination.V1 = source.V1;
		destination.V2 = source.V2;
		destination.V3 = source.V3;
		destination.V4 = source.V4;
		destination.V5 = source.V5;
		destination.V6 = source.V6;
		destination.V7 = source.V7;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void LoadFrom(this ref Octet<byte> destination, ref Octet<uint> source)
	{
		destination.V0 = (byte)source.V0;
		destination.V1 = (byte)source.V1;
		destination.V2 = (byte)source.V2;
		destination.V3 = (byte)source.V3;
		destination.V4 = (byte)source.V4;
		destination.V5 = (byte)source.V5;
		destination.V6 = (byte)source.V6;
		destination.V7 = (byte)source.V7;
	}
}
