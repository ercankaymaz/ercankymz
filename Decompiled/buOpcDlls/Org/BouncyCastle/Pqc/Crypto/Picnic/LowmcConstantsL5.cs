using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class LowmcConstantsL5 : LowmcConstants
{
	public LowmcConstantsL5()
	{
		_matrixToHex = new Dictionary<string, string>();
		using (Stream stream = typeof(LowmcConstants).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.picnic.lowmcL5.bz2"))
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
		linearMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices"], 311296);
		roundConstants = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants"], 1216);
		keyMatrices = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices"], 319488);
		_LMatrix = new KMatrices(38, 256, 8, linearMatrices);
		_KMatrix = new KMatrices(39, 256, 8, keyMatrices);
		RConstants = new KMatrices(38, 1, 8, roundConstants);
		linearMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_full"], 32768);
		linearMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["linearMatrices_inv"], 32768);
		roundConstants_full = LowmcConstants.ReadFromProperty(_matrixToHex["roundConstants_full"], 128);
		keyMatrices_full = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_full"], 40960);
		keyMatrices_inv = LowmcConstants.ReadFromProperty(_matrixToHex["keyMatrices_inv"], 8160);
		LMatrix_full = new KMatrices(4, 255, 8, linearMatrices_full);
		LMatrix_inv = new KMatrices(4, 255, 8, linearMatrices_inv);
		KMatrix_full = new KMatrices(5, 255, 8, keyMatrices_full);
		KMatrix_inv = new KMatrices(1, 255, 8, keyMatrices_inv);
		RConstants_full = new KMatrices(4, 1, 8, roundConstants_full);
	}
}
