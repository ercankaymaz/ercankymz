using System;
using System.IO;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Crypto.Digests;

public sealed class SparkleDigest : IDigest
{
	public enum SparkleParameters
	{
		ESCH256,
		ESCH384
	}

	private static readonly uint[] RCON = new uint[8] { 3084996962u, 3211876480u, 951376470u, 844003128u, 3138487787u, 1333558103u, 3485442504u, 3266521405u };

	private string algorithmName;

	private readonly uint[] state;

	private readonly MemoryStream message = new MemoryStream();

	private readonly int DIGEST_BYTES;

	private readonly int SPARKLE_STEPS_SLIM;

	private readonly int SPARKLE_STEPS_BIG;

	private readonly int STATE_BRANS;

	private readonly int STATE_WORDS;

	private readonly int RATE_WORDS;

	private readonly int RATE_BYTES;

	public string AlgorithmName => algorithmName;

	public SparkleDigest(SparkleParameters sparkleParameters)
	{
		int num = 128;
		int num2;
		int num3;
		switch (sparkleParameters)
		{
		case SparkleParameters.ESCH256:
			num2 = 256;
			num3 = 384;
			SPARKLE_STEPS_SLIM = 7;
			SPARKLE_STEPS_BIG = 11;
			algorithmName = "ESCH-256";
			break;
		case SparkleParameters.ESCH384:
			num2 = 384;
			num3 = 512;
			SPARKLE_STEPS_SLIM = 8;
			SPARKLE_STEPS_BIG = 12;
			algorithmName = "ESCH-384";
			break;
		default:
			throw new ArgumentException("Invalid definition of SCHWAEMM instance");
		}
		STATE_BRANS = num3 >> 6;
		STATE_WORDS = num3 >> 5;
		RATE_WORDS = num >> 5;
		RATE_BYTES = num >> 3;
		DIGEST_BYTES = num2 >> 3;
		state = new uint[STATE_WORDS];
	}

	public int GetDigestSize()
	{
		return DIGEST_BYTES;
	}

	public int GetByteLength()
	{
		return RATE_BYTES;
	}

	public void Update(byte input)
	{
		message.WriteByte(input);
	}

	public void BlockUpdate(byte[] input, int inOff, int inLen)
	{
		Check.DataLength(input, inOff, inLen, "input buffer too short");
		message.Write(input, inOff, inLen);
	}

	public int DoFinal(byte[] output, int outOff)
	{
		Check.OutputLength(output, outOff, DIGEST_BYTES, "output buffer too short");
		byte[] buffer = message.GetBuffer();
		int num = (int)message.Length;
		int num2 = 0;
		uint[] array = Pack.LE_To_UInt32(buffer, 0, num >> 2);
		uint num3;
		uint num4;
		int i;
		while (num > RATE_BYTES)
		{
			num3 = 0u;
			num4 = 0u;
			for (i = 0; i < RATE_WORDS; i += 2)
			{
				num3 ^= array[i + (num2 >> 2)];
				num4 ^= array[i + 1 + (num2 >> 2)];
			}
			num3 = ELL(num3);
			num4 = ELL(num4);
			for (i = 0; i < RATE_WORDS; i += 2)
			{
				state[i] ^= array[i + (num2 >> 2)] ^ num4;
				state[i + 1] ^= array[i + 1 + (num2 >> 2)] ^ num3;
			}
			for (i = RATE_WORDS; i < STATE_WORDS / 2; i += 2)
			{
				state[i] ^= num4;
				state[i + 1] ^= num3;
			}
			sparkle_opt(state, STATE_BRANS, SPARKLE_STEPS_SLIM);
			num -= RATE_BYTES;
			num2 += RATE_BYTES;
		}
		state[STATE_BRANS - 1] ^= (uint)((num < RATE_BYTES) ? 16777216 : 33554432);
		uint[] array2 = new uint[RATE_WORDS];
		for (i = 0; i < num; i++)
		{
			array2[i >> 2] |= (uint)((buffer[num2++] & 0xFF) << ((i & 3) << 3));
		}
		if (num < RATE_BYTES)
		{
			array2[i >> 2] |= (uint)(128 << ((i & 3) << 3));
		}
		num3 = 0u;
		num4 = 0u;
		for (i = 0; i < RATE_WORDS; i += 2)
		{
			num3 ^= array2[i];
			num4 ^= array2[i + 1];
		}
		num3 = ELL(num3);
		num4 = ELL(num4);
		for (i = 0; i < RATE_WORDS; i += 2)
		{
			state[i] ^= array2[i] ^ num4;
			state[i + 1] ^= array2[i + 1] ^ num3;
		}
		for (i = RATE_WORDS; i < STATE_WORDS / 2; i += 2)
		{
			state[i] ^= num4;
			state[i + 1] ^= num3;
		}
		sparkle_opt(state, STATE_BRANS, SPARKLE_STEPS_BIG);
		Pack.UInt32_To_LE(state, 0, RATE_WORDS, output, outOff);
		int num5 = RATE_BYTES;
		outOff += RATE_BYTES;
		while (num5 < DIGEST_BYTES)
		{
			sparkle_opt(state, STATE_BRANS, SPARKLE_STEPS_SLIM);
			Pack.UInt32_To_LE(state, 0, RATE_WORDS, output, outOff);
			num5 += RATE_BYTES;
			outOff += RATE_BYTES;
		}
		return DIGEST_BYTES;
	}

	public void Reset()
	{
		message.SetLength(0L);
		Arrays.Fill(state, 0u);
	}

	private void sparkle_opt(uint[] state, int brans, int steps)
	{
		for (uint num = 0u; num < steps; num++)
		{
			state[1] ^= RCON[num & 7];
			state[3] ^= num;
			for (uint num2 = 0u; num2 < 2 * brans; num2 += 2)
			{
				uint num3 = RCON[num2 >> 1];
				state[num2] += Integers.RotateRight(state[num2 + 1], 31);
				state[num2 + 1] ^= Integers.RotateRight(state[num2], 24);
				state[num2] ^= num3;
				state[num2] += Integers.RotateRight(state[num2 + 1], 17);
				state[num2 + 1] ^= Integers.RotateRight(state[num2], 17);
				state[num2] ^= num3;
				state[num2] += state[num2 + 1];
				state[num2 + 1] ^= Integers.RotateRight(state[num2], 31);
				state[num2] ^= num3;
				state[num2] += Integers.RotateRight(state[num2 + 1], 24);
				state[num2 + 1] ^= Integers.RotateRight(state[num2], 16);
				state[num2] ^= num3;
			}
			uint num5;
			uint num4 = (num5 = state[0]);
			uint num7;
			uint num6 = (num7 = state[1]);
			for (uint num2 = 2u; num2 < brans; num2 += 2)
			{
				num4 ^= state[num2];
				num6 ^= state[num2 + 1];
			}
			num4 = ELL(num4);
			num6 = ELL(num6);
			for (uint num2 = 2u; num2 < brans; num2 += 2)
			{
				state[num2 - 2] = state[num2 + brans] ^ state[num2] ^ num6;
				state[num2 + brans] = state[num2];
				state[num2 - 1] = state[num2 + brans + 1] ^ state[num2 + 1] ^ num4;
				state[num2 + brans + 1] = state[num2 + 1];
			}
			state[brans - 2] = state[brans] ^ num5 ^ num6;
			state[brans] = num5;
			state[brans - 1] = state[brans + 1] ^ num7 ^ num4;
			state[brans + 1] = num7;
		}
	}

	private static uint ELL(uint x)
	{
		return Integers.RotateRight(x ^ (x << 16), 16);
	}
}
