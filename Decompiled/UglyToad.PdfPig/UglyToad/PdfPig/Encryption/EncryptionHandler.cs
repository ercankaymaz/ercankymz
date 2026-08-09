using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.CrossReference;
using UglyToad.PdfPig.Exceptions;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Encryption;

internal sealed class EncryptionHandler : IEncryptionHandler
{
	private static readonly byte[] PaddingBytes = new byte[32]
	{
		40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
		78, 86, 255, 250, 1, 8, 46, 46, 0, 182,
		208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
		105, 122
	};

	private readonly HashSet<IndirectReference> previouslyDecrypted = new HashSet<IndirectReference>();

	private readonly EncryptionDictionary encryptionDictionary;

	private readonly CryptHandler cryptHandler;

	private readonly byte[] encryptionKey;

	private readonly bool useAes;

	public EncryptionHandler(EncryptionDictionary encryptionDictionary, TrailerDictionary trailerDictionary, IReadOnlyList<string> passwords)
	{
		this.encryptionDictionary = encryptionDictionary;
		if (passwords == null)
		{
			passwords = new _003C_003Ez__ReadOnlySingleElementList<string>(string.Empty);
		}
		if (!passwords.Contains(string.Empty))
		{
			passwords = new List<string>(passwords) { string.Empty };
		}
		byte[] array;
		if (trailerDictionary.Identifier != null && trailerDictionary.Identifier.Count == 2)
		{
			IDataToken<string> dataToken = trailerDictionary.Identifier[0];
			array = ((dataToken is HexToken { Bytes: var bytes }) ? bytes.ToArray() : ((!(dataToken is StringToken stringToken)) ? OtherEncodings.StringAsLatin1Bytes(dataToken.Data) : stringToken.GetBytes()));
		}
		else
		{
			array = Array.Empty<byte>();
		}
		if (encryptionDictionary == null)
		{
			return;
		}
		useAes = false;
		if (encryptionDictionary.EncryptionAlgorithmCode == EncryptionAlgorithmCode.SecurityHandlerInDocument || encryptionDictionary.EncryptionAlgorithmCode == EncryptionAlgorithmCode.SecurityHandlerInDocument256)
		{
			if (!encryptionDictionary.TryGetCryptHandler(out CryptHandler cryptHandler))
			{
				throw new PdfDocumentEncryptedException("Document encrypted with security handler in document but no crypt dictionary found.", encryptionDictionary);
			}
			this.cryptHandler = cryptHandler;
			useAes = cryptHandler.StreamDictionary.Name == CryptDictionary.Method.AesV2 || cryptHandler.StreamDictionary.Name == CryptDictionary.Method.AesV3;
		}
		Encoding encoding = OtherEncodings.Iso88591;
		if (encryptionDictionary.Revision == 5 || encryptionDictionary.Revision == 6)
		{
			encoding = Encoding.UTF8;
		}
		int num;
		if (encryptionDictionary.EncryptionAlgorithmCode == EncryptionAlgorithmCode.Rc4OrAes40BitKey)
		{
			num = 5;
			goto IL_01e0;
		}
		if (encryptionDictionary.KeyLength.HasValue)
		{
			goto IL_01c9;
		}
		int num2;
		if (encryptionDictionary.EncryptionAlgorithmCode == EncryptionAlgorithmCode.Rc4OrAesGreaterThan40BitKey)
		{
			num2 = 40;
		}
		else if (encryptionDictionary.EncryptionAlgorithmCode == EncryptionAlgorithmCode.UnpublishedAlgorithm40To128BitKey)
		{
			num2 = 40;
		}
		else
		{
			CryptHandler obj = this.cryptHandler;
			if (obj != null && obj.StreamDictionary.Name == CryptDictionary.Method.AesV2)
			{
				num2 = 128;
			}
			else
			{
				CryptHandler obj2 = this.cryptHandler;
				if (obj2 == null || obj2.StreamDictionary.Name != CryptDictionary.Method.AesV3)
				{
					goto IL_01c9;
				}
				num2 = 256;
			}
		}
		goto IL_01da;
		IL_01e0:
		int length = num;
		bool flag = false;
		foreach (string password2 in passwords)
		{
			byte[] bytes2 = encoding.GetBytes(password2);
			bool isUserPassword = false;
			byte[] password;
			if (IsOwnerPassword(bytes2, encryptionDictionary, length, array, out var userPassword))
			{
				password = ((encryptionDictionary.Revision != 5 && encryptionDictionary.Revision != 6) ? userPassword : bytes2);
			}
			else
			{
				if (!IsUserPassword(bytes2, encryptionDictionary, length, array))
				{
					continue;
				}
				password = bytes2;
				isUserPassword = true;
			}
			encryptionKey = CalculateEncryptionKey(password, encryptionDictionary, length, array, isUserPassword);
			flag = true;
			break;
		}
		if (!flag)
		{
			throw new PdfDocumentEncryptedException("The document was encrypted and none of the provided passwords were the user or owner password.", encryptionDictionary);
		}
		return;
		IL_01c9:
		num2 = encryptionDictionary.KeyLength.GetValueOrDefault();
		goto IL_01da;
		IL_01da:
		num = num2 / 8;
		goto IL_01e0;
	}

	private static bool IsUserPassword(byte[] passwordBytes, EncryptionDictionary encryptionDictionary, int length, byte[] documentIdBytes)
	{
		if (encryptionDictionary.Revision == 5 || encryptionDictionary.Revision == 6)
		{
			return IsUserPasswordRevision5And6(passwordBytes, encryptionDictionary);
		}
		byte[] array = CalculateKeyRevisions2To4(passwordBytes, encryptionDictionary, length, documentIdBytes);
		byte[] array3;
		if (encryptionDictionary.Revision >= 3)
		{
			using MD5 mD = MD5.Create();
			UpdateMd5(mD, PaddingBytes);
			UpdateMd5(mD, documentIdBytes);
			mD.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			byte[] hash = mD.Hash;
			byte[] array2 = RC4.Encrypt(array, hash);
			byte i;
			for (i = 1; i <= 19; i++)
			{
				array2 = RC4.Encrypt(array.Select((byte x) => (byte)(x ^ i)).ToArray(), array2);
			}
			array3 = array2;
		}
		else
		{
			array3 = RC4.Encrypt(array, PaddingBytes);
		}
		if (encryptionDictionary.Revision >= 3)
		{
			return encryptionDictionary.UserBytes.AsSpan(0, 16).SequenceEqual(array3.AsSpan(0, 16));
		}
		return encryptionDictionary.UserBytes.AsSpan().SequenceEqual(array3);
	}

	private static bool IsUserPasswordRevision5And6(byte[] passwordBytes, EncryptionDictionary encryptionDictionary)
	{
		byte[] array = TruncatePasswordTo127Bytes(passwordBytes);
		byte[] array2 = new byte[32];
		byte[] array3 = new byte[8];
		Array.Copy(encryptionDictionary.UserBytes, array2, 32);
		Array.Copy(encryptionDictionary.UserBytes, 32, array3, 0, 8);
		byte[] first = ((encryptionDictionary.Revision != 6) ? ComputeSha256Hash(array, array3) : ComputeStupidIsoHash(array, array3, null));
		return Enumerable.SequenceEqual(first, array2);
	}

	private static bool IsOwnerPassword(byte[] passwordBytes, EncryptionDictionary encryptionDictionary, int length, byte[] documentIdBytes, out byte[] userPassword)
	{
		userPassword = null;
		if (encryptionDictionary.Revision == 5 || encryptionDictionary.Revision == 6)
		{
			return IsOwnerPasswordRevision5And6(passwordBytes, encryptionDictionary);
		}
		byte[] paddedPassword = GetPaddedPassword(passwordBytes);
		using MD5 mD = MD5.Create();
		byte[] array = mD.ComputeHash(paddedPassword);
		if (encryptionDictionary.Revision >= 3)
		{
			for (int i = 0; i < 50; i++)
			{
				array = mD.ComputeHash(mD.Hash);
			}
		}
		byte[] array2 = array.AsSpan(0, length).ToArray();
		if (encryptionDictionary.Revision == 2)
		{
			userPassword = RC4.Encrypt(array2, encryptionDictionary.OwnerBytes);
		}
		else
		{
			byte[] array3 = null;
			int j;
			for (j = 0; j < 20; j++)
			{
				byte[] array4 = array2.Select((byte x) => (byte)(x ^ (19 - j))).ToArray();
				if (j == 0)
				{
					array3 = encryptionDictionary.OwnerBytes;
				}
				array3 = RC4.Encrypt(array4, array3);
			}
			userPassword = array3;
		}
		return IsUserPassword(userPassword, encryptionDictionary, length, documentIdBytes);
	}

	private static bool IsOwnerPasswordRevision5And6(byte[] passwordBytes, EncryptionDictionary encryptionDictionary)
	{
		byte[] array = TruncatePasswordTo127Bytes(passwordBytes);
		byte[] array2 = new byte[32];
		byte[] array3 = new byte[8];
		Array.Copy(encryptionDictionary.OwnerBytes, array2, array2.Length);
		Array.Copy(encryptionDictionary.OwnerBytes, array2.Length, array3, 0, array3.Length);
		byte[] first = ((encryptionDictionary.Revision != 6) ? ComputeSha256Hash(array, array3, encryptionDictionary.UserBytes) : ComputeStupidIsoHash(array, array3, encryptionDictionary.UserBytes));
		return Enumerable.SequenceEqual(first, array2);
	}

	public IToken Decrypt(IndirectReference reference, IToken token)
	{
		if (token == null)
		{
			throw new ArgumentNullException("token");
		}
		try
		{
			token = DecryptInternal(reference, token);
			previouslyDecrypted.Add(reference);
			return token;
		}
		catch (Exception inner)
		{
			throw new PdfDocumentEncryptedException($"The document was encrypted and decryption of a token failed. Token was: {token}.", encryptionDictionary, inner);
		}
	}

	private IToken DecryptInternal(IndirectReference reference, IToken token)
	{
		if (!(token is StreamToken streamToken))
		{
			if (!(token is StringToken stringToken))
			{
				if (!(token is HexToken { Bytes: var bytes }))
				{
					DictionaryToken dictionaryToken = token as DictionaryToken;
					if (dictionaryToken == null)
					{
						if (token is ArrayToken arrayToken)
						{
							IToken[] array = new IToken[arrayToken.Length];
							for (int i = 0; i < arrayToken.Length; i++)
							{
								array[i] = DecryptInternal(reference, arrayToken.Data[i]);
							}
							token = new ArrayToken(array);
						}
					}
					else
					{
						if (dictionaryToken.TryGet(NameToken.Cf, out var token2))
						{
							return token;
						}
						NameToken token3;
						bool flag = dictionaryToken.TryGet(NameToken.Type, out token3) && (token3.Equals(NameToken.Sig) || token3.Equals(NameToken.DocTimeStamp));
						foreach (KeyValuePair<string, IToken> datum in dictionaryToken.Data)
						{
							if (!flag || !(datum.Key == NameToken.Contents.Data))
							{
								token2 = datum.Value;
								if ((token2 is StringToken || token2 is ArrayToken || token2 is DictionaryToken || token2 is HexToken) ? true : false)
								{
									IToken value = DecryptInternal(reference, datum.Value);
									dictionaryToken = dictionaryToken.With(datum.Key, value);
								}
							}
						}
						token = dictionaryToken;
					}
				}
				else
				{
					byte[] data = bytes.ToArray();
					token = new HexToken(Hex.GetString(DecryptData(data, reference)).AsSpan());
				}
				goto IL_0348;
			}
			CryptHandler obj = cryptHandler;
			if (obj == null || obj.StringDictionary?.IsIdentity != true)
			{
				CryptHandler obj2 = cryptHandler;
				if (obj2 == null || obj2.StringDictionary?.Name != CryptDictionary.Method.None)
				{
					byte[] bytes2 = stringToken.GetBytes();
					token = GetStringTokenFromDecryptedData(DecryptData(bytes2, reference));
					goto IL_0348;
				}
			}
			return token;
		}
		CryptHandler obj3 = cryptHandler;
		if (obj3 == null || obj3.StreamDictionary?.IsIdentity != true)
		{
			CryptHandler obj4 = cryptHandler;
			if (obj4 == null || obj4.StreamDictionary?.Name != CryptDictionary.Method.None)
			{
				if (streamToken.StreamDictionary.TryGet(NameToken.Type, out NameToken token4))
				{
					if (NameToken.Xref.Equals(token4))
					{
						return token;
					}
					if (!encryptionDictionary.EncryptMetadata && NameToken.Metadata.Equals(token4))
					{
						return token;
					}
				}
				DictionaryToken streamDictionary = (DictionaryToken)DecryptInternal(reference, streamToken.StreamDictionary);
				byte[] data2 = DecryptData(streamToken.Data.ToArray(), reference);
				token = new StreamToken(streamDictionary, data2);
				goto IL_0348;
			}
		}
		return token;
		IL_0348:
		return token;
	}

	private static StringToken GetStringTokenFromDecryptedData(ReadOnlySpan<byte> data)
	{
		if (data.Length >= 2)
		{
			if (data[0] == 254 && data[1] == byte.MaxValue)
			{
				return new StringToken(Encoding.BigEndianUnicode.GetString(data).Substring(1), StringToken.Encoding.Utf16BE);
			}
			if (data[0] == byte.MaxValue && data[1] == 254)
			{
				return new StringToken(Encoding.Unicode.GetString(data).Substring(1), StringToken.Encoding.Utf16);
			}
		}
		return new StringToken(OtherEncodings.BytesAsLatin1String(data));
	}

	private byte[] DecryptData(byte[] data, IndirectReference reference)
	{
		if (useAes && encryptionKey.Length == 32)
		{
			return AesEncryptionHelper.Decrypt(data, encryptionKey);
		}
		byte[] objectKey = GetObjectKey(reference);
		if (useAes)
		{
			return AesEncryptionHelper.Decrypt(data, objectKey);
		}
		return RC4.Encrypt(objectKey, data);
	}

	private byte[] GetObjectKey(IndirectReference reference)
	{
		byte[] array = new byte[encryptionKey.Length + 5 + (useAes ? 4 : 0)];
		Array.Copy(encryptionKey, array, encryptionKey.Length);
		array[encryptionKey.Length] = (byte)reference.ObjectNumber;
		array[encryptionKey.Length + 1] = (byte)(reference.ObjectNumber >> 8);
		array[encryptionKey.Length + 2] = (byte)(reference.ObjectNumber >> 16);
		array[encryptionKey.Length + 3] = (byte)reference.Generation;
		array[encryptionKey.Length + 4] = (byte)(reference.Generation >> 8);
		if (useAes)
		{
			array[encryptionKey.Length + 5] = 115;
			array[encryptionKey.Length + 6] = 65;
			array[encryptionKey.Length + 7] = 108;
			array[encryptionKey.Length + 8] = 84;
		}
		using MD5 mD = MD5.Create();
		mD.ComputeHash(array);
		int num = Math.Min(16, encryptionKey.Length + 5);
		byte[] array2 = new byte[num];
		Array.Copy(mD.Hash, array2, num);
		return array2;
	}

	private static byte[] CalculateEncryptionKey(byte[] password, EncryptionDictionary encryptionDictionary, int length, byte[] documentId, bool isUserPassword)
	{
		if (encryptionDictionary.Revision >= 2 && encryptionDictionary.Revision <= 4)
		{
			return CalculateKeyRevisions2To4(password, encryptionDictionary, length, documentId);
		}
		if (encryptionDictionary.Revision <= 6)
		{
			return CalculateKeyRevisions5And6(password, encryptionDictionary, isUserPassword);
		}
		throw new PdfDocumentEncryptedException($"PDF encrypted with unrecognized revision: {encryptionDictionary}.");
	}

	private static byte[] CalculateKeyRevisions2To4(byte[] password, EncryptionDictionary encryptionDictionary, int length, byte[] documentId)
	{
		byte[] paddedPassword = GetPaddedPassword(password);
		int revision = encryptionDictionary.Revision;
		using MD5 mD = MD5.Create();
		UpdateMd5(mD, paddedPassword);
		UpdateMd5(mD, encryptionDictionary.OwnerBytes);
		uint num = (uint)encryptionDictionary.UserAccessPermissions;
		UpdateMd5(mD, new byte[1] { (byte)num });
		UpdateMd5(mD, new byte[1] { (byte)(num >> 8) });
		UpdateMd5(mD, new byte[1] { (byte)(num >> 16) });
		UpdateMd5(mD, new byte[1] { (byte)(num >> 24) });
		UpdateMd5(mD, documentId);
		if (revision >= 4 && !encryptionDictionary.EncryptMetadata)
		{
			UpdateMd5(mD, new byte[4] { 255, 255, 255, 255 });
		}
		if ((uint)(revision - 3) <= 1u)
		{
			mD.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			byte[] array = mD.Hash;
			using (MD5 mD2 = MD5.Create())
			{
				for (int i = 0; i < 50; i++)
				{
					array = mD2.ComputeHash(array.AsSpan(0, length).ToArray());
				}
			}
			byte[] array2 = new byte[length];
			Array.Copy(array, array2, length);
			return array2;
		}
		mD.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
		byte[] array3 = new byte[length];
		Array.Copy(mD.Hash, array3, length);
		return array3;
	}

	private static byte[] CalculateKeyRevisions5And6(byte[] password, EncryptionDictionary encryptionDictionary, bool isUserPassword)
	{
		password = TruncatePasswordTo127Bytes(password);
		byte[] array2;
		byte[] buffer;
		if (!isUserPassword)
		{
			byte[] array = new byte[8];
			Array.Copy(encryptionDictionary.OwnerBytes, 40, array, 0, array.Length);
			array2 = ((encryptionDictionary.Revision != 6) ? ComputeSha256Hash(password, array, encryptionDictionary.UserBytes) : ComputeStupidIsoHash(password, array, encryptionDictionary.UserBytes));
			buffer = encryptionDictionary.OwnerEncryptionBytes;
		}
		else
		{
			byte[] array3 = new byte[8];
			Array.Copy(encryptionDictionary.UserBytes, 40, array3, 0, 8);
			array2 = ((encryptionDictionary.Revision != 6) ? ComputeSha256Hash(password, array3) : ComputeStupidIsoHash(password, array3, null));
			buffer = encryptionDictionary.UserEncryptionBytes;
		}
		byte[] array4 = new byte[16];
		using Aes aes = Aes.Create();
		aes.Key = array2;
		aes.IV = array4;
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.None;
		using MemoryStream stream = new MemoryStream(buffer);
		using MemoryStream memoryStream = new MemoryStream();
		using CryptoStream cryptoStream = new CryptoStream(stream, aes.CreateDecryptor(array2, array4), CryptoStreamMode.Read);
		cryptoStream.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}

	private static byte[] ComputeSha256Hash(byte[] input1, byte[] input2, byte[] input3 = null)
	{
		using SHA256 sHA = SHA256.Create();
		sHA.TransformBlock(input1, 0, input1.Length, null, 0);
		sHA.TransformBlock(input2, 0, input2.Length, null, 0);
		if (input3 != null)
		{
			sHA.TransformFinalBlock(input3, 0, input3.Length);
		}
		else
		{
			sHA.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
		}
		return sHA.Hash;
	}

	private static void UpdateMd5(MD5 md5, byte[] data)
	{
		md5.TransformBlock(data, 0, data.Length, null, 0);
	}

	private static byte[] GetPaddedPassword(byte[] password)
	{
		if (password == null || password.Length == 0)
		{
			return PaddingBytes;
		}
		byte[] array = new byte[32];
		int num = ((password.Length <= 32) ? password.Length : 32);
		int num2 = 32 - num;
		Array.ConstrainedCopy(password, 0, array, 0, num);
		if (num2 > 0)
		{
			Array.ConstrainedCopy(PaddingBytes, 0, array, num, num2);
		}
		return array;
	}

	private static byte[] TruncatePasswordTo127Bytes(byte[] password)
	{
		if (password.Length <= 127)
		{
			return password;
		}
		byte[] array = new byte[127];
		Array.Copy(password, array, 127);
		return array;
	}

	private static byte[] ComputeStupidIsoHash(byte[] password, byte[] salt, byte[] vector)
	{
		if (vector == null)
		{
			vector = Array.Empty<byte>();
		}
		else
		{
			if (vector.Length != 0 && vector.Length < 48)
			{
				throw new PdfDocumentEncryptedException($"Vector for revision 6 owner password check (/U) is the wrong length, expected 48 bytes got {vector.Length} bytes.");
			}
			if (vector.Length > 48)
			{
				byte[] array = new byte[48];
				Array.Copy(vector, array, array.Length);
				vector = array;
			}
		}
		password = TruncatePasswordTo127Bytes(password);
		byte[] array2;
		using (SHA256 sHA = SHA256.Create())
		{
			sHA.TransformBlock(password, 0, password.Length, null, 0);
			sHA.TransformBlock(salt, 0, salt.Length, null, 0);
			sHA.TransformBlock(vector, 0, vector.Length, null, 0);
			sHA.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			array2 = sHA.Hash;
		}
		byte[] array3 = new byte[16];
		Array.Copy(array2, array3, 16);
		byte[] array4 = new byte[16];
		Array.Copy(array2, 16, array4, 0, array4.Length);
		byte[] array5 = null;
		HashAlgorithm hashAlgorithm;
		for (int i = 0; i < 64 || i < array5[array5.Length - 1] + 32; array2 = hashAlgorithm.ComputeHash(array5), Array.Copy(array2, array3, 16), Array.Copy(array2, 16, array4, 0, 16), i++)
		{
			byte[] array6 = new byte[64 * (password.Length + array2.Length + vector.Length)];
			int num = 0;
			for (int j = 0; j < 64; j++)
			{
				Array.Copy(password, 0, array6, num, password.Length);
				num += password.Length;
				Array.Copy(array2, 0, array6, num, array2.Length);
				num += array2.Length;
				if (vector.Length != 0)
				{
					Array.Copy(vector, 0, array6, num, vector.Length);
					num += vector.Length;
				}
			}
			using (Aes aes = Aes.Create())
			{
				aes.Key = array3;
				aes.IV = array4;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.None;
				using ICryptoTransform cryptoTransform = aes.CreateEncryptor();
				array5 = cryptoTransform.TransformFinalBlock(array6, 0, array6.Length);
			}
			long num2 = array5.Take(16).Sum((Func<byte, long>)((byte v) => v)) % 3;
			if ((ulong)num2 <= 2uL)
			{
				switch ((int)num2)
				{
				case 0:
					hashAlgorithm = SHA256.Create();
					continue;
				case 1:
					hashAlgorithm = SHA384.Create();
					continue;
				case 2:
					hashAlgorithm = SHA512.Create();
					continue;
				}
			}
			throw new PdfDocumentEncryptedException("Invalid remainder from summing first sixteen bytes of this round's hash.");
		}
		if (array2.Length > 32)
		{
			byte[] array7 = new byte[32];
			Array.Copy(array2, array7, array7.Length);
			return array7;
		}
		return array2;
	}
}
