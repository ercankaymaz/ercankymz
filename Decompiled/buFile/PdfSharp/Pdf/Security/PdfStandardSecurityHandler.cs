#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Security;

public sealed class PdfStandardSecurityHandler : PdfSecurityHandler
{
	internal new sealed class Keys : PdfSecurityHandler.Keys
	{
		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string R = "/R";

		[KeyInfo(KeyType.String | KeyType.Required)]
		public const string O = "/O";

		[KeyInfo(KeyType.String | KeyType.Required)]
		public const string U = "/U";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string P = "/P";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string EncryptMetadata = "/EncryptMetadata";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal string _userPassword;

	internal string _ownerPassword;

	private static readonly byte[] PasswordPadding = new byte[32]
	{
		40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
		78, 86, 255, 250, 1, 8, 46, 46, 0, 182,
		208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
		105, 122
	};

	private byte[] _encryptionKey;

	private readonly MD5 _md5 = new MD5CryptoServiceProvider();

	private readonly byte[] _state = new byte[256];

	private byte[] _ownerKey = new byte[32];

	private readonly byte[] _userKey = new byte[32];

	private byte[] _key;

	private int _keySize;

	public string UserPassword
	{
		set
		{
			if (_document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
			{
				_document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
			}
			_userPassword = value;
		}
	}

	public string OwnerPassword
	{
		set
		{
			if (_document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
			{
				_document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
			}
			_ownerPassword = value;
		}
	}

	internal PdfUserAccessPermission Permission
	{
		get
		{
			PdfUserAccessPermission pdfUserAccessPermission = (PdfUserAccessPermission)base.Elements.GetInteger("/P");
			if (pdfUserAccessPermission == (PdfUserAccessPermission)0)
			{
				pdfUserAccessPermission = PdfUserAccessPermission.PermitAll;
			}
			return pdfUserAccessPermission;
		}
		set
		{
			base.Elements.SetInteger("/P", (int)value);
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfStandardSecurityHandler(PdfDocument document)
		: base(document)
	{
	}

	internal PdfStandardSecurityHandler(PdfDictionary dict)
		: base(dict)
	{
	}

	public void EncryptDocument()
	{
		PdfReference[] allReferences = _document._irefTable.AllReferences;
		foreach (PdfReference pdfReference in allReferences)
		{
			if (pdfReference.Value != this)
			{
				EncryptObject(pdfReference.Value);
			}
		}
	}

	internal void EncryptObject(PdfObject value)
	{
		Debug.Assert(value.Reference != null);
		SetHashKey(value.ObjectID);
		if (value.ObjectID.ObjectNumber == 10)
		{
			GetType();
		}
		if (value is PdfDictionary dict)
		{
			EncryptDictionary(dict);
		}
		else if (value is PdfArray array)
		{
			EncryptArray(array);
		}
		else if (value is PdfStringObject { Length: not 0, EncryptionValue: var encryptionValue } pdfStringObject)
		{
			PrepareKey();
			EncryptRC4(encryptionValue);
			pdfStringObject.EncryptionValue = encryptionValue;
		}
	}

	private void EncryptDictionary(PdfDictionary dict)
	{
		PdfName[] keyNames = dict.Elements.KeyNames;
		foreach (KeyValuePair<string, PdfItem> element in dict.Elements)
		{
			if (element.Value is PdfString value)
			{
				EncryptString(value);
			}
			else if (element.Value is PdfDictionary dict2)
			{
				EncryptDictionary(dict2);
			}
			else if (element.Value is PdfArray array)
			{
				EncryptArray(array);
			}
		}
		if (dict.Stream != null)
		{
			byte[] value2 = dict.Stream.Value;
			if (value2.Length != 0)
			{
				PrepareKey();
				EncryptRC4(value2);
				dict.Stream.Value = value2;
			}
		}
	}

	private void EncryptArray(PdfArray array)
	{
		int count = array.Elements.Count;
		for (int i = 0; i < count; i++)
		{
			PdfItem pdfItem = array.Elements[i];
			if (pdfItem is PdfString value)
			{
				EncryptString(value);
			}
			else if (pdfItem is PdfDictionary dict)
			{
				EncryptDictionary(dict);
			}
			else if (pdfItem is PdfArray array2)
			{
				EncryptArray(array2);
			}
		}
	}

	private void EncryptString(PdfString value)
	{
		if (value.Length != 0)
		{
			byte[] encryptionValue = value.EncryptionValue;
			PrepareKey();
			EncryptRC4(encryptionValue);
			value.EncryptionValue = encryptionValue;
		}
	}

	internal byte[] EncryptBytes(byte[] bytes)
	{
		if (bytes != null && bytes.Length != 0)
		{
			PrepareKey();
			EncryptRC4(bytes);
		}
		return bytes;
	}

	public PasswordValidity ValidatePassword(string inputPassword)
	{
		string name = base.Elements.GetName("/Filter");
		int integer = base.Elements.GetInteger("/V");
		if (name != "/Standard" || integer < 1 || integer > 3)
		{
			throw new PdfReaderException(PSSR.UnknownEncryption);
		}
		byte[] bytes = PdfEncoders.RawEncoding.GetBytes(Owner.Internals.FirstDocumentID);
		byte[] bytes2 = PdfEncoders.RawEncoding.GetBytes(base.Elements.GetString("/O"));
		byte[] bytes3 = PdfEncoders.RawEncoding.GetBytes(base.Elements.GetString("/U"));
		int integer2 = base.Elements.GetInteger("/P");
		int integer3 = base.Elements.GetInteger("/R");
		if (inputPassword == null)
		{
			inputPassword = "";
		}
		bool flag = integer3 == 3;
		int length = (flag ? 16 : 32);
		InitWithOwnerPassword(bytes, inputPassword, bytes2, integer2, flag);
		if (EqualsKey(bytes3, length))
		{
			_document.SecuritySettings._hasOwnerPermissions = true;
			return PasswordValidity.OwnerPassword;
		}
		_document.SecuritySettings._hasOwnerPermissions = false;
		InitWithUserPassword(bytes, inputPassword, bytes2, integer2, flag);
		if (EqualsKey(bytes3, length))
		{
			return PasswordValidity.UserPassword;
		}
		return PasswordValidity.Invalid;
	}

	[Conditional("DEBUG")]
	private static void DumpBytes(string tag, byte[] bytes)
	{
		string text = tag + ": ";
		for (int i = 0; i < bytes.Length; i++)
		{
			text += $"{bytes[i]:X2}";
		}
		Debug.WriteLine(text);
	}

	private static byte[] PadPassword(string password)
	{
		byte[] array = new byte[32];
		if (password == null)
		{
			Array.Copy(PasswordPadding, 0, array, 0, 32);
		}
		else
		{
			int length = password.Length;
			Array.Copy(PdfEncoders.RawEncoding.GetBytes(password), 0, array, 0, Math.Min(length, 32));
			if (length < 32)
			{
				Array.Copy(PasswordPadding, 0, array, length, 32 - length);
			}
		}
		return array;
	}

	private void InitWithUserPassword(byte[] documentID, string userPassword, byte[] ownerKey, int permissions, bool strongEncryption)
	{
		InitEncryptionKey(documentID, PadPassword(userPassword), ownerKey, permissions, strongEncryption);
		SetupUserKey(documentID);
	}

	private void InitWithOwnerPassword(byte[] documentID, string ownerPassword, byte[] ownerKey, int permissions, bool strongEncryption)
	{
		byte[] userPad = ComputeOwnerKey(ownerKey, PadPassword(ownerPassword), strongEncryption);
		InitEncryptionKey(documentID, userPad, ownerKey, permissions, strongEncryption);
		SetupUserKey(documentID);
	}

	private byte[] ComputeOwnerKey(byte[] userPad, byte[] ownerPad, bool strongEncryption)
	{
		byte[] array = new byte[32];
		byte[] array2 = _md5.ComputeHash(ownerPad);
		if (strongEncryption)
		{
			byte[] array3 = new byte[16];
			for (int i = 0; i < 50; i++)
			{
				array2 = _md5.ComputeHash(array2);
			}
			Array.Copy(userPad, 0, array, 0, 32);
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = (byte)(array2[k] ^ j);
				}
				PrepareRC4Key(array3);
				EncryptRC4(array);
			}
		}
		else
		{
			PrepareRC4Key(array2, 0, 5);
			EncryptRC4(userPad, array);
		}
		return array;
	}

	private void InitEncryptionKey(byte[] documentID, byte[] userPad, byte[] ownerKey, int permissions, bool strongEncryption)
	{
		_ownerKey = ownerKey;
		_encryptionKey = new byte[strongEncryption ? 16 : 5];
		_md5.Initialize();
		_md5.TransformBlock(userPad, 0, userPad.Length, userPad, 0);
		_md5.TransformBlock(ownerKey, 0, ownerKey.Length, ownerKey, 0);
		byte[] array = new byte[4]
		{
			(byte)permissions,
			(byte)(permissions >> 8),
			(byte)(permissions >> 16),
			(byte)(permissions >> 24)
		};
		_md5.TransformBlock(array, 0, 4, array, 0);
		_md5.TransformBlock(documentID, 0, documentID.Length, documentID, 0);
		_md5.TransformFinalBlock(array, 0, 0);
		byte[] array2 = _md5.Hash;
		_md5.Initialize();
		if (_encryptionKey.Length == 16)
		{
			for (int i = 0; i < 50; i++)
			{
				array2 = _md5.ComputeHash(array2);
				_md5.Initialize();
			}
		}
		Array.Copy(array2, 0, _encryptionKey, 0, _encryptionKey.Length);
	}

	private void SetupUserKey(byte[] documentID)
	{
		if (_encryptionKey.Length == 16)
		{
			_md5.TransformBlock(PasswordPadding, 0, PasswordPadding.Length, PasswordPadding, 0);
			_md5.TransformFinalBlock(documentID, 0, documentID.Length);
			byte[] hash = _md5.Hash;
			_md5.Initialize();
			Array.Copy(hash, 0, _userKey, 0, 16);
			for (int i = 16; i < 32; i++)
			{
				_userKey[i] = 0;
			}
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < _encryptionKey.Length; k++)
				{
					hash[k] = (byte)(_encryptionKey[k] ^ j);
				}
				PrepareRC4Key(hash, 0, _encryptionKey.Length);
				EncryptRC4(_userKey, 0, 16);
			}
		}
		else
		{
			PrepareRC4Key(_encryptionKey);
			EncryptRC4(PasswordPadding, _userKey);
		}
	}

	private void PrepareKey()
	{
		if (_key != null && _keySize > 0)
		{
			PrepareRC4Key(_key, 0, _keySize);
		}
	}

	private void PrepareRC4Key(byte[] key)
	{
		PrepareRC4Key(key, 0, key.Length);
	}

	private void PrepareRC4Key(byte[] key, int offset, int length)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			_state[i] = (byte)i;
		}
		for (int j = 0; j < 256; j++)
		{
			num2 = (key[num + offset] + _state[j] + num2) & 0xFF;
			byte b = _state[j];
			_state[j] = _state[num2];
			_state[num2] = b;
			num = (num + 1) % length;
		}
	}

	private void EncryptRC4(byte[] data)
	{
		EncryptRC4(data, 0, data.Length, data);
	}

	private void EncryptRC4(byte[] data, int offset, int length)
	{
		EncryptRC4(data, offset, length, data);
	}

	private void EncryptRC4(byte[] inputData, byte[] outputData)
	{
		EncryptRC4(inputData, 0, inputData.Length, outputData);
	}

	private void EncryptRC4(byte[] inputData, int offset, int length, byte[] outputData)
	{
		length += offset;
		int num = 0;
		int num2 = 0;
		for (int i = offset; i < length; i++)
		{
			num = (num + 1) & 0xFF;
			num2 = (_state[num] + num2) & 0xFF;
			byte b = _state[num];
			_state[num] = _state[num2];
			_state[num2] = b;
			outputData[i] = (byte)(inputData[i] ^ _state[(_state[num] + _state[num2]) & 0xFF]);
		}
	}

	private bool EqualsKey(byte[] value, int length)
	{
		for (int i = 0; i < length; i++)
		{
			if (_userKey[i] != value[i])
			{
				return false;
			}
		}
		return true;
	}

	internal void SetHashKey(PdfObjectID id)
	{
		byte[] array = new byte[5];
		_md5.Initialize();
		array[0] = (byte)id.ObjectNumber;
		array[1] = (byte)(id.ObjectNumber >> 8);
		array[2] = (byte)(id.ObjectNumber >> 16);
		array[3] = (byte)id.GenerationNumber;
		array[4] = (byte)(id.GenerationNumber >> 8);
		_md5.TransformBlock(_encryptionKey, 0, _encryptionKey.Length, _encryptionKey, 0);
		_md5.TransformFinalBlock(array, 0, array.Length);
		_key = _md5.Hash;
		_md5.Initialize();
		_keySize = _encryptionKey.Length + 5;
		if (_keySize > 16)
		{
			_keySize = 16;
		}
	}

	public void PrepareEncryption()
	{
		Debug.Assert(_document._securitySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None);
		int permission = (int)Permission;
		bool flag = _document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.Encrypted128Bit;
		PdfInteger value;
		PdfInteger value2;
		PdfInteger value3;
		if (flag)
		{
			value = new PdfInteger(2);
			value2 = new PdfInteger(128);
			value3 = new PdfInteger(3);
		}
		else
		{
			value = new PdfInteger(1);
			value2 = new PdfInteger(40);
			value3 = new PdfInteger(2);
		}
		if (string.IsNullOrEmpty(_userPassword))
		{
			_userPassword = "";
		}
		if (string.IsNullOrEmpty(_ownerPassword))
		{
			_ownerPassword = _userPassword;
		}
		permission |= (flag ? (-3904) : (-64));
		permission &= -4;
		PdfInteger value4 = new PdfInteger(permission);
		Debug.Assert(_ownerPassword.Length > 0, "Empty owner password.");
		byte[] userPad = PadPassword(_userPassword);
		byte[] ownerPad = PadPassword(_ownerPassword);
		_md5.Initialize();
		_ownerKey = ComputeOwnerKey(userPad, ownerPad, flag);
		byte[] bytes = PdfEncoders.RawEncoding.GetBytes(_document.Internals.FirstDocumentID);
		InitWithUserPassword(bytes, _userPassword, _ownerKey, permission, flag);
		PdfString value5 = new PdfString(PdfEncoders.RawEncoding.GetString(_ownerKey, 0, _ownerKey.Length));
		PdfString value6 = new PdfString(PdfEncoders.RawEncoding.GetString(_userKey, 0, _userKey.Length));
		base.Elements["/Filter"] = new PdfName("/Standard");
		base.Elements["/V"] = value;
		base.Elements["/Length"] = value2;
		base.Elements["/R"] = value3;
		base.Elements["/O"] = value5;
		base.Elements["/U"] = value6;
		base.Elements["/P"] = value4;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
		writer.SecurityHandler = null;
		base.WriteObject(writer);
		writer.SecurityHandler = securityHandler;
	}
}
