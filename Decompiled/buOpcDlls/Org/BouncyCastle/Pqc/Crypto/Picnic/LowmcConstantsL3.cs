using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class LowmcConstantsL3 : LowmcConstants
{
	public LowmcConstantsL3()
	{
		_matrixToHex = new Dictionary<string, string>();
		using (Stream stream = typeof(LowmcConstants).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.picnic.lowmcL3.bz2"))
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
		linearMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices"], 138240);
		roundConstants = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants"], 720);
		keyMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices"], 142848);
		_LMatrix = new KMatrices(30, 192, 6, linearMatrices);
		_KMatrix = new KMatrices(31, 192, 6, keyMatrices);
		RConstants = new KMatrices(30, 1, 6, roundConstants);
		linearMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_full"], 18432);
		linearMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_inv"], 18432);
		roundConstants_full = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants_full"], 96);
		keyMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_full"], 23040);
		keyMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_inv"], 4608);
		LMatrix_full = new KMatrices(4, 192, 6, linearMatrices_full);
		LMatrix_inv = new KMatrices(4, 192, 6, linearMatrices_inv);
		KMatrix_full = new KMatrices(5, 192, 6, keyMatrices_full);
		KMatrix_inv = new KMatrices(1, 192, 6, keyMatrices_inv);
		RConstants_full = new KMatrices(4, 1, 6, roundConstants_full);
	}
}
