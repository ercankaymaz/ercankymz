using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class LowmcConstantsL1 : LowmcConstants
{
	public LowmcConstantsL1()
	{
		_matrixToHex = new Dictionary<string, string>();
		using (Stream stream = typeof(LowmcConstants).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.picnic.lowmcL1.bz2"))
		{
			using StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(stream));
			for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
			{
				string text2 = text;
				if (text2 != "")
				{
					text2 = text2.Replace(",", "");
					int num = text2.IndexOf('=');
					string key = text2.Substring(0, num).Trim();
					string value = text2.Substring(num + 1).Trim();
					_matrixToHex.Add(key, value);
				}
			}
		}
		linearMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices"], 40960);
		roundConstants = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants"], 320);
		keyMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices"], 43008);
		_LMatrix = new KMatrices(20, 128, 4, linearMatrices);
		_KMatrix = new KMatrices(21, 128, 4, keyMatrices);
		RConstants = new KMatrices(0, 1, 4, roundConstants);
		linearMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_full"], 12800);
		keyMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_full"], 12900);
		keyMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_inv"], 2850);
		linearMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_inv"], 12800);
		roundConstants_full = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants_full"], 80);
		LMatrix_full = new KMatrices(4, 129, 5, linearMatrices_full);
		LMatrix_inv = new KMatrices(4, 129, 5, linearMatrices_inv);
		KMatrix_full = new KMatrices(5, 129, 5, keyMatrices_full);
		KMatrix_inv = new KMatrices(1, 129, 5, keyMatrices_inv);
		RConstants_full = new KMatrices(4, 1, 5, roundConstants_full);
	}
}
