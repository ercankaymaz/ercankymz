using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities.Encoders;

namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal abstract class LowmcConstants
{
	internal Dictionary<string, string> _matrixToHex;

	internal uint[] linearMatrices;

	internal uint[] roundConstants;

	internal uint[] keyMatrices;

	internal KMatrices _LMatrix;

	internal KMatrices _KMatrix;

	internal KMatrices RConstants;

	internal uint[] linearMatrices_full;

	internal uint[] keyMatrices_full;

	internal uint[] keyMatrices_inv;

	internal uint[] linearMatrices_inv;

	internal uint[] roundConstants_full;

	internal KMatrices LMatrix_full;

	internal KMatrices LMatrix_inv;

	internal KMatrices KMatrix_full;

	internal KMatrices KMatrix_inv;

	internal KMatrices RConstants_full;

	internal static uint[] ReadFromProperty(string s, int intSize)
	{
		byte[] array = Hex.Decode(s);
		uint[] array2 = new uint[intSize];
		for (int i = 0; i < array.Length / 4; i++)
		{
			array2[i] = Pack.LE_To_UInt32(array, i * 4);
		}
		return array2;
	}

	private KMatricesWithPointer GET_MAT(KMatrices m, int r)
	{
		KMatricesWithPointer kMatricesWithPointer = new KMatricesWithPointer(m);
		kMatricesWithPointer.SetMatrixPointer(r * kMatricesWithPointer.GetSize());
		return kMatricesWithPointer;
	}

	internal KMatricesWithPointer LMatrix(PicnicEngine engine, int round)
	{
		if (engine.stateSizeBits == 128)
		{
			return GET_MAT(_LMatrix, round);
		}
		if (engine.stateSizeBits == 129)
		{
			return GET_MAT(LMatrix_full, round);
		}
		if (engine.stateSizeBits == 192)
		{
			if (engine.numRounds == 4)
			{
				return GET_MAT(LMatrix_full, round);
			}
			return GET_MAT(_LMatrix, round);
		}
		if (engine.stateSizeBits == 255)
		{
			return GET_MAT(LMatrix_full, round);
		}
		if (engine.stateSizeBits == 256)
		{
			return GET_MAT(_LMatrix, round);
		}
		return null;
	}

	internal KMatricesWithPointer LMatrixInv(PicnicEngine engine, int round)
	{
		if (engine.stateSizeBits == 129)
		{
			return GET_MAT(LMatrix_inv, round);
		}
		if (engine.stateSizeBits == 192 && engine.numRounds == 4)
		{
			return GET_MAT(LMatrix_inv, round);
		}
		if (engine.stateSizeBits == 255)
		{
			return GET_MAT(LMatrix_inv, round);
		}
		return null;
	}

	internal KMatricesWithPointer KMatrix(PicnicEngine engine, int round)
	{
		if (engine.stateSizeBits == 128)
		{
			return GET_MAT(_KMatrix, round);
		}
		if (engine.stateSizeBits == 129)
		{
			return GET_MAT(KMatrix_full, round);
		}
		if (engine.stateSizeBits == 192)
		{
			if (engine.numRounds == 4)
			{
				return GET_MAT(KMatrix_full, round);
			}
			return GET_MAT(_KMatrix, round);
		}
		if (engine.stateSizeBits == 255)
		{
			return GET_MAT(KMatrix_full, round);
		}
		if (engine.stateSizeBits == 256)
		{
			return GET_MAT(_KMatrix, round);
		}
		return null;
	}

	internal KMatricesWithPointer KMatrixInv(PicnicEngine engine, int round)
	{
		if (engine.stateSizeBits == 129)
		{
			return GET_MAT(KMatrix_inv, round);
		}
		if (engine.stateSizeBits == 192 && engine.numRounds == 4)
		{
			return GET_MAT(KMatrix_inv, round);
		}
		if (engine.stateSizeBits == 255)
		{
			return GET_MAT(KMatrix_inv, round);
		}
		return null;
	}

	internal KMatricesWithPointer RConstant(PicnicEngine engine, int round)
	{
		if (engine.stateSizeBits == 128)
		{
			return GET_MAT(RConstants, round);
		}
		if (engine.stateSizeBits == 129)
		{
			return GET_MAT(RConstants_full, round);
		}
		if (engine.stateSizeBits == 192)
		{
			if (engine.numRounds == 4)
			{
				return GET_MAT(RConstants_full, round);
			}
			return GET_MAT(RConstants, round);
		}
		if (engine.stateSizeBits == 255)
		{
			return GET_MAT(RConstants_full, round);
		}
		if (engine.stateSizeBits == 256)
		{
			return GET_MAT(RConstants, round);
		}
		return null;
	}
}
