internal sealed class _0023_003DqVFAcyYKahdwaFZMP0V7msloqDPsKfPMdS_OP1RFEjy4_003D
{
	private _0023_003DqVFAcyYKahdwaFZMP0V7msloqDPsKfPMdS_OP1RFEjy4_003D()
	{
	}

	internal static void _0023_003Dzalpqgan0IZA60xlAp_0024vo4iwjs0qqnGVrGs_6tRRtKU1O(uint _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)_0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D[++_0023_003DzAvn2b38_003D] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[++_0023_003DzAvn2b38_003D] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[++_0023_003DzAvn2b38_003D] = (byte)(_0023_003DziDLVpbY_003D >> 24);
	}

	internal static uint _0023_003DzWLTb2pZoJDz0eIRFw_MrwjLc8FVxb3xlmc_0024_1_4A21qs(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		return (uint)(_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] | (_0023_003DziDLVpbY_003D[++_0023_003Dz5rQzobg_003D] << 8) | (_0023_003DziDLVpbY_003D[++_0023_003Dz5rQzobg_003D] << 16) | (_0023_003DziDLVpbY_003D[++_0023_003Dz5rQzobg_003D] << 24));
	}
}
