using System;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class Packing
{
	public static byte[] PackPublicKey(PolyVecK t1, DilithiumEngine Engine)
	{
		byte[] array = new byte[Engine.CryptoPublicKeyBytes - 32];
		for (int i = 0; i < Engine.K; i++)
		{
			Array.Copy(t1.Vec[i].PolyT1Pack(), 0, array, i * 320, 320);
		}
		return array;
	}

	public static PolyVecK UnpackPublicKey(PolyVecK t1, byte[] pk, DilithiumEngine Engine)
	{
		for (int i = 0; i < Engine.K; i++)
		{
			t1.Vec[i].PolyT1Unpack(Arrays.CopyOfRange(pk, i * 320, 32 + (i + 1) * 320));
		}
		return t1;
	}

	public static void PackSecretKey(byte[] t0_, byte[] s1_, byte[] s2_, PolyVecK t0, PolyVecL s1, PolyVecK s2, DilithiumEngine Engine)
	{
		for (int i = 0; i < Engine.L; i++)
		{
			s1.Vec[i].PolyEtaPack(s1_, i * Engine.PolyEtaPackedBytes);
		}
		for (int i = 0; i < Engine.K; i++)
		{
			s2.Vec[i].PolyEtaPack(s2_, i * Engine.PolyEtaPackedBytes);
		}
		for (int i = 0; i < Engine.K; i++)
		{
			t0.Vec[i].PolyT0Pack(t0_, i * 416);
		}
	}

	public static void UnpackSecretKey(PolyVecK t0, PolyVecL s1, PolyVecK s2, byte[] t0Enc, byte[] s1Enc, byte[] s2Enc, DilithiumEngine Engine)
	{
		for (int i = 0; i < Engine.L; i++)
		{
			s1.Vec[i].PolyEtaUnpack(s1Enc, i * Engine.PolyEtaPackedBytes);
		}
		for (int i = 0; i < Engine.K; i++)
		{
			s2.Vec[i].PolyEtaUnpack(s2Enc, i * Engine.PolyEtaPackedBytes);
		}
		for (int i = 0; i < Engine.K; i++)
		{
			t0.Vec[i].PolyT0Unpack(t0Enc, i * 416);
		}
	}

	public static void PackSignature(byte[] sig, byte[] c, PolyVecL z, PolyVecK h, DilithiumEngine engine)
	{
		int num = 0;
		Array.Copy(c, 0, sig, 0, 32);
		num += 32;
		for (int i = 0; i < engine.L; i++)
		{
			z.Vec[i].PackZ(sig, num + i * engine.PolyZPackedBytes);
		}
		num += engine.L * engine.PolyZPackedBytes;
		for (int i = 0; i < engine.Omega + engine.K; i++)
		{
			sig[num + i] = 0;
		}
		int num2 = 0;
		for (int i = 0; i < engine.K; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				if (h.Vec[i].Coeffs[j] != 0)
				{
					sig[num + num2++] = (byte)j;
				}
			}
			sig[num + engine.Omega + i] = (byte)num2;
		}
	}

	public static bool UnpackSignature(PolyVecL z, PolyVecK h, byte[] sig, DilithiumEngine Engine)
	{
		int num = 32;
		for (int i = 0; i < Engine.L; i++)
		{
			z.Vec[i].UnpackZ(Arrays.CopyOfRange(sig, num + i * Engine.PolyZPackedBytes, num + (i + 1) * Engine.PolyZPackedBytes));
		}
		num += Engine.L * Engine.PolyZPackedBytes;
		int num2 = 0;
		for (int i = 0; i < Engine.K; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				h.Vec[i].Coeffs[j] = 0;
			}
			if ((sig[num + Engine.Omega + i] & 0xFF) < num2 || (sig[num + Engine.Omega + i] & 0xFF) > Engine.Omega)
			{
				return false;
			}
			for (int j = num2; j < (sig[num + Engine.Omega + i] & 0xFF); j++)
			{
				if (j > num2 && (sig[num + j] & 0xFF) <= (sig[num + j - 1] & 0xFF))
				{
					return false;
				}
				h.Vec[i].Coeffs[sig[num + j] & 0xFF] = 1;
			}
			num2 = sig[num + Engine.Omega + i];
		}
		for (int j = num2; j < Engine.Omega; j++)
		{
			if ((sig[num + j] & 0xFF) != 0)
			{
				return false;
			}
		}
		return true;
	}
}
