using System.IO;

namespace HEDS;

internal class HedsSign
{
	private class Header
	{
		public int ulMagic = 1396983112;

		public int ulCount = 0;
	}

	private class Signature
	{
		public int iGeneration = 0;

		public int iSignatureLen = 0;

		public byte[] bSignature;
	}

	private Header hdr = new Header();

	private Signature[] sign;

	private bool IsValidMagic()
	{
		if (hdr.ulMagic == 1396983112)
		{
			return true;
		}
		return false;
	}

	public bool LoadSignature(Stream s)
	{
		BinaryReader binaryReader = new BinaryReader(s);
		hdr.ulMagic = binaryReader.ReadInt32();
		if (!IsValidMagic())
		{
			return false;
		}
		hdr.ulCount = binaryReader.ReadInt32();
		if (hdr.ulCount > 16)
		{
			return false;
		}
		sign = new Signature[hdr.ulCount];
		for (int i = 0; i < hdr.ulCount; i++)
		{
			sign[i] = new Signature();
			sign[i].iGeneration = binaryReader.ReadInt32();
			sign[i].iSignatureLen = binaryReader.ReadInt32();
			sign[i].bSignature = new byte[sign[i].iSignatureLen];
			binaryReader.Read(sign[i].bSignature, 0, sign[i].bSignature.Length);
		}
		return true;
	}

	public byte[] GetSignature(int iGen)
	{
		for (int i = 0; i < hdr.ulCount; i++)
		{
			if (sign[i].iGeneration == iGen)
			{
				return sign[i].bSignature;
			}
		}
		return null;
	}
}
