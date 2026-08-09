namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal abstract class Benes
{
	protected int SYS_N;

	protected int SYS_T;

	protected int GFBITS;

	internal Benes(int n, int t, int m)
	{
		SYS_N = n;
		SYS_T = t;
		GFBITS = m;
	}

	internal static void Transpose64x64(ulong[] output, ulong[] input)
	{
		ulong[,] array = new ulong[6, 2]
		{
			{ 6148914691236517205uL, 12297829382473034410uL },
			{ 3689348814741910323uL, 14757395258967641292uL },
			{ 1085102592571150095uL, 17361641481138401520uL },
			{ 71777214294589695uL, 18374966859414961920uL },
			{ 281470681808895uL, 18446462603027742720uL },
			{ 4294967295uL, 18446744069414584320uL }
		};
		for (int i = 0; i < 64; i++)
		{
			output[i] = input[i];
		}
		for (int num = 5; num >= 0; num--)
		{
			int num2 = 1 << num;
			for (int i = 0; i < 64; i += num2 * 2)
			{
				for (int j = i; j < i + num2; j++)
				{
					ulong num3 = (output[j] & array[num, 0]) | ((output[j + num2] & array[num, 0]) << num2);
					ulong num4 = ((output[j] & array[num, 1]) >> num2) | (output[j + num2] & array[num, 1]);
					output[j] = num3;
					output[j + num2] = num4;
				}
			}
		}
	}

	internal static void Transpose64x64(ulong[] output, ulong[] input, int offset)
	{
		ulong[,] array = new ulong[6, 2]
		{
			{ 6148914691236517205uL, 12297829382473034410uL },
			{ 3689348814741910323uL, 14757395258967641292uL },
			{ 1085102592571150095uL, 17361641481138401520uL },
			{ 71777214294589695uL, 18374966859414961920uL },
			{ 281470681808895uL, 18446462603027742720uL },
			{ 4294967295uL, 18446744069414584320uL }
		};
		for (int i = 0; i < 64; i++)
		{
			output[i + offset] = input[i + offset];
		}
		for (int num = 5; num >= 0; num--)
		{
			int num2 = 1 << num;
			for (int i = 0; i < 64; i += num2 * 2)
			{
				for (int j = i; j < i + num2; j++)
				{
					ulong num3 = (output[j + offset] & array[num, 0]) | ((output[j + num2 + offset] & array[num, 0]) << num2);
					ulong num4 = ((output[j + offset] & array[num, 1]) >> num2) | (output[j + num2 + offset] & array[num, 1]);
					output[j + offset] = num3;
					output[j + num2 + offset] = num4;
				}
			}
		}
	}

	internal abstract void SupportGen(ushort[] s, byte[] c);
}
