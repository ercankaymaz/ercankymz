// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Security.PdfStandardSecurityHandler
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

#nullable disable
namespace PdfSharp.Pdf.Security;

public sealed class PdfStandardSecurityHandler : PdfSecurityHandler
{
  internal string _userPassword;
  internal string _ownerPassword;
  private static readonly byte[] PasswordPadding = new byte[32 /*0x20*/]
  {
    (byte) 40,
    (byte) 191,
    (byte) 78,
    (byte) 94,
    (byte) 78,
    (byte) 117,
    (byte) 138,
    (byte) 65,
    (byte) 100,
    (byte) 0,
    (byte) 78,
    (byte) 86,
    byte.MaxValue,
    (byte) 250,
    (byte) 1,
    (byte) 8,
    (byte) 46,
    (byte) 46,
    (byte) 0,
    (byte) 182,
    (byte) 208 /*0xD0*/,
    (byte) 104,
    (byte) 62,
    (byte) 128 /*0x80*/,
    (byte) 47,
    (byte) 12,
    (byte) 169,
    (byte) 254,
    (byte) 100,
    (byte) 83,
    (byte) 105,
    (byte) 122
  };
  private byte[] _encryptionKey;
  private readonly MD5 _md5 = (MD5) new MD5CryptoServiceProvider();
  private readonly byte[] _state = new byte[256 /*0x0100*/];
  private byte[] _ownerKey = new byte[32 /*0x20*/];
  private readonly byte[] _userKey = new byte[32 /*0x20*/];
  private byte[] _key;
  private int _keySize;

  internal PdfStandardSecurityHandler(PdfDocument document)
    : base(document)
  {
  }

  internal PdfStandardSecurityHandler(PdfDictionary dict)
    : base(dict)
  {
  }

  public string UserPassword
  {
    set
    {
      if (this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
        this._document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
      this._userPassword = value;
    }
  }

  public string OwnerPassword
  {
    set
    {
      if (this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
        this._document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
      this._ownerPassword = value;
    }
  }

  internal PdfUserAccessPermission Permission
  {
    get
    {
      PdfUserAccessPermission permission = (PdfUserAccessPermission) this.Elements.GetInteger("/P");
      if (permission == (PdfUserAccessPermission) 0)
        permission = PdfUserAccessPermission.PermitAll;
      return permission;
    }
    set => this.Elements.SetInteger("/P", (int) value);
  }

  public void EncryptDocument()
  {
    foreach (PdfReference allReference in this._document._irefTable.AllReferences)
    {
      if (allReference.Value != this)
        this.EncryptObject(allReference.Value);
    }
  }

  internal void EncryptObject(PdfObject value)
  {
    Debug.Assert(value.Reference != null);
    this.SetHashKey(value.ObjectID);
    if (value.ObjectID.ObjectNumber == 10)
      this.GetType();
    switch (value)
    {
      case PdfDictionary dict:
        this.EncryptDictionary(dict);
        break;
      case PdfArray array:
        this.EncryptArray(array);
        break;
      case PdfStringObject pdfStringObject:
        if (pdfStringObject.Length == 0)
          break;
        byte[] encryptionValue = pdfStringObject.EncryptionValue;
        this.PrepareKey();
        this.EncryptRC4(encryptionValue);
        pdfStringObject.EncryptionValue = encryptionValue;
        break;
    }
  }

  private void EncryptDictionary(PdfDictionary dict)
  {
    PdfName[] keyNames = dict.Elements.KeyNames;
    foreach (KeyValuePair<string, PdfItem> element in dict.Elements)
    {
      if (element.Value is PdfString pdfString)
        this.EncryptString(pdfString);
      else if (element.Value is PdfDictionary dict1)
        this.EncryptDictionary(dict1);
      else if (element.Value is PdfArray array)
        this.EncryptArray(array);
    }
    if (dict.Stream == null)
      return;
    byte[] data = dict.Stream.Value;
    if (data.Length == 0)
      return;
    this.PrepareKey();
    this.EncryptRC4(data);
    dict.Stream.Value = data;
  }

  private void EncryptArray(PdfArray array)
  {
    int count = array.Elements.Count;
    for (int index = 0; index < count; ++index)
    {
      switch (array.Elements[index])
      {
        case PdfString pdfString:
          this.EncryptString(pdfString);
          break;
        case PdfDictionary dict:
          this.EncryptDictionary(dict);
          break;
        case PdfArray array1:
          this.EncryptArray(array1);
          break;
      }
    }
  }

  private void EncryptString(PdfString value)
  {
    if (value.Length == 0)
      return;
    byte[] encryptionValue = value.EncryptionValue;
    this.PrepareKey();
    this.EncryptRC4(encryptionValue);
    value.EncryptionValue = encryptionValue;
  }

  internal byte[] EncryptBytes(byte[] bytes)
  {
    if ((bytes == null ? 0 : (bytes.Length != 0 ? 1 : 0)) != 0)
    {
      this.PrepareKey();
      this.EncryptRC4(bytes);
    }
    return bytes;
  }

  public PasswordValidity ValidatePassword(string inputPassword)
  {
    string name = this.Elements.GetName("/Filter");
    int integer1 = this.Elements.GetInteger("/V");
    if ((name != "/Standard" ? 1 : (integer1 < 1 ? 1 : (integer1 > 3 ? 1 : 0))) != 0)
      throw new PdfReaderException(PSSR.UnknownEncryption);
    byte[] bytes1 = PdfEncoders.RawEncoding.GetBytes(this.Owner.Internals.FirstDocumentID);
    byte[] bytes2 = PdfEncoders.RawEncoding.GetBytes(this.Elements.GetString("/O"));
    byte[] bytes3 = PdfEncoders.RawEncoding.GetBytes(this.Elements.GetString("/U"));
    int integer2 = this.Elements.GetInteger("/P");
    int integer3 = this.Elements.GetInteger("/R");
    if (inputPassword == null)
      inputPassword = "";
    bool strongEncryption;
    int length = (strongEncryption = integer3 == 3) ? 16 /*0x10*/ : 32 /*0x20*/;
    this.InitWithOwnerPassword(bytes1, inputPassword, bytes2, integer2, strongEncryption);
    PasswordValidity passwordValidity;
    if (this.EqualsKey(bytes3, length))
    {
      this._document.SecuritySettings._hasOwnerPermissions = true;
      passwordValidity = PasswordValidity.OwnerPassword;
    }
    else
    {
      this._document.SecuritySettings._hasOwnerPermissions = false;
      this.InitWithUserPassword(bytes1, inputPassword, bytes2, integer2, strongEncryption);
      passwordValidity = !this.EqualsKey(bytes3, length) ? PasswordValidity.Invalid : PasswordValidity.UserPassword;
    }
    return passwordValidity;
  }

  [Conditional("DEBUG")]
  private static void DumpBytes(string tag, byte[] bytes)
  {
    string message = tag + ": ";
    for (int index = 0; index < bytes.Length; ++index)
      message += $"{bytes[index]:X2}";
    Debug.WriteLine(message);
  }

  private static byte[] PadPassword(string password)
  {
    byte[] destinationArray = new byte[32 /*0x20*/];
    if (password == null)
    {
      Array.Copy((Array) PdfStandardSecurityHandler.PasswordPadding, 0, (Array) destinationArray, 0, 32 /*0x20*/);
    }
    else
    {
      int length = password.Length;
      Array.Copy((Array) PdfEncoders.RawEncoding.GetBytes(password), 0, (Array) destinationArray, 0, Math.Min(length, 32 /*0x20*/));
      if (length < 32 /*0x20*/)
        Array.Copy((Array) PdfStandardSecurityHandler.PasswordPadding, 0, (Array) destinationArray, length, 32 /*0x20*/ - length);
    }
    return destinationArray;
  }

  private void InitWithUserPassword(
    byte[] documentID,
    string userPassword,
    byte[] ownerKey,
    int permissions,
    bool strongEncryption)
  {
    this.InitEncryptionKey(documentID, PdfStandardSecurityHandler.PadPassword(userPassword), ownerKey, permissions, strongEncryption);
    this.SetupUserKey(documentID);
  }

  private void InitWithOwnerPassword(
    byte[] documentID,
    string ownerPassword,
    byte[] ownerKey,
    int permissions,
    bool strongEncryption)
  {
    byte[] ownerKey1 = this.ComputeOwnerKey(ownerKey, PdfStandardSecurityHandler.PadPassword(ownerPassword), strongEncryption);
    this.InitEncryptionKey(documentID, ownerKey1, ownerKey, permissions, strongEncryption);
    this.SetupUserKey(documentID);
  }

  private byte[] ComputeOwnerKey(byte[] userPad, byte[] ownerPad, bool strongEncryption)
  {
    byte[] ownerKey = new byte[32 /*0x20*/];
    byte[] hash = this._md5.ComputeHash(ownerPad);
    if (strongEncryption)
    {
      byte[] key = new byte[16 /*0x10*/];
      for (int index = 0; index < 50; ++index)
        hash = this._md5.ComputeHash(hash);
      Array.Copy((Array) userPad, 0, (Array) ownerKey, 0, 32 /*0x20*/);
      for (int index1 = 0; index1 < 20; ++index1)
      {
        for (int index2 = 0; index2 < key.Length; ++index2)
          key[index2] = (byte) ((uint) hash[index2] ^ (uint) index1);
        this.PrepareRC4Key(key);
        this.EncryptRC4(ownerKey);
      }
    }
    else
    {
      this.PrepareRC4Key(hash, 0, 5);
      this.EncryptRC4(userPad, ownerKey);
    }
    return ownerKey;
  }

  private void InitEncryptionKey(
    byte[] documentID,
    byte[] userPad,
    byte[] ownerKey,
    int permissions,
    bool strongEncryption)
  {
    this._ownerKey = ownerKey;
    this._encryptionKey = new byte[strongEncryption ? 16 /*0x10*/ : 5];
    this._md5.Initialize();
    this._md5.TransformBlock(userPad, 0, userPad.Length, userPad, 0);
    this._md5.TransformBlock(ownerKey, 0, ownerKey.Length, ownerKey, 0);
    byte[] numArray = new byte[4]
    {
      (byte) permissions,
      (byte) (permissions >> 8),
      (byte) (permissions >> 16 /*0x10*/),
      (byte) (permissions >> 24)
    };
    this._md5.TransformBlock(numArray, 0, 4, numArray, 0);
    this._md5.TransformBlock(documentID, 0, documentID.Length, documentID, 0);
    this._md5.TransformFinalBlock(numArray, 0, 0);
    byte[] hash = this._md5.Hash;
    this._md5.Initialize();
    if (this._encryptionKey.Length == 16 /*0x10*/)
    {
      for (int index = 0; index < 50; ++index)
      {
        hash = this._md5.ComputeHash(hash);
        this._md5.Initialize();
      }
    }
    Array.Copy((Array) hash, 0, (Array) this._encryptionKey, 0, this._encryptionKey.Length);
  }

  private void SetupUserKey(byte[] documentID)
  {
    if (this._encryptionKey.Length == 16 /*0x10*/)
    {
      this._md5.TransformBlock(PdfStandardSecurityHandler.PasswordPadding, 0, PdfStandardSecurityHandler.PasswordPadding.Length, PdfStandardSecurityHandler.PasswordPadding, 0);
      this._md5.TransformFinalBlock(documentID, 0, documentID.Length);
      byte[] hash = this._md5.Hash;
      this._md5.Initialize();
      Array.Copy((Array) hash, 0, (Array) this._userKey, 0, 16 /*0x10*/);
      for (int index = 16 /*0x10*/; index < 32 /*0x20*/; ++index)
        this._userKey[index] = (byte) 0;
      for (int index1 = 0; index1 < 20; ++index1)
      {
        for (int index2 = 0; index2 < this._encryptionKey.Length; ++index2)
          hash[index2] = (byte) ((uint) this._encryptionKey[index2] ^ (uint) index1);
        this.PrepareRC4Key(hash, 0, this._encryptionKey.Length);
        this.EncryptRC4(this._userKey, 0, 16 /*0x10*/);
      }
    }
    else
    {
      this.PrepareRC4Key(this._encryptionKey);
      this.EncryptRC4(PdfStandardSecurityHandler.PasswordPadding, this._userKey);
    }
  }

  private void PrepareKey()
  {
    if ((this._key == null ? 0 : (this._keySize > 0 ? 1 : 0)) == 0)
      return;
    this.PrepareRC4Key(this._key, 0, this._keySize);
  }

  private void PrepareRC4Key(byte[] key) => this.PrepareRC4Key(key, 0, key.Length);

  private void PrepareRC4Key(byte[] key, int offset, int length)
  {
    int num1 = 0;
    int index1 = 0;
    for (int index2 = 0; index2 < 256 /*0x0100*/; ++index2)
      this._state[index2] = (byte) index2;
    for (int index3 = 0; index3 < 256 /*0x0100*/; ++index3)
    {
      index1 = (int) key[num1 + offset] + (int) this._state[index3] + index1 & (int) byte.MaxValue;
      byte num2 = this._state[index3];
      this._state[index3] = this._state[index1];
      this._state[index1] = num2;
      num1 = (num1 + 1) % length;
    }
  }

  private void EncryptRC4(byte[] data) => this.EncryptRC4(data, 0, data.Length, data);

  private void EncryptRC4(byte[] data, int offset, int length)
  {
    this.EncryptRC4(data, offset, length, data);
  }

  private void EncryptRC4(byte[] inputData, byte[] outputData)
  {
    this.EncryptRC4(inputData, 0, inputData.Length, outputData);
  }

  private void EncryptRC4(byte[] inputData, int offset, int length, byte[] outputData)
  {
    length += offset;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = offset; index3 < length; ++index3)
    {
      index1 = index1 + 1 & (int) byte.MaxValue;
      index2 = (int) this._state[index1] + index2 & (int) byte.MaxValue;
      byte num = this._state[index1];
      this._state[index1] = this._state[index2];
      this._state[index2] = num;
      outputData[index3] = (byte) ((uint) inputData[index3] ^ (uint) this._state[(int) this._state[index1] + (int) this._state[index2] & (int) byte.MaxValue]);
    }
  }

  private bool EqualsKey(byte[] value, int length)
  {
    bool flag;
    for (int index = 0; index < length; ++index)
    {
      if ((int) this._userKey[index] != (int) value[index])
      {
        flag = false;
        goto label_6;
      }
    }
    flag = true;
label_6:
    return flag;
  }

  internal void SetHashKey(PdfObjectID id)
  {
    byte[] inputBuffer = new byte[5];
    this._md5.Initialize();
    inputBuffer[0] = (byte) id.ObjectNumber;
    inputBuffer[1] = (byte) (id.ObjectNumber >> 8);
    inputBuffer[2] = (byte) (id.ObjectNumber >> 16 /*0x10*/);
    inputBuffer[3] = (byte) id.GenerationNumber;
    inputBuffer[4] = (byte) (id.GenerationNumber >> 8);
    this._md5.TransformBlock(this._encryptionKey, 0, this._encryptionKey.Length, this._encryptionKey, 0);
    this._md5.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
    this._key = this._md5.Hash;
    this._md5.Initialize();
    this._keySize = this._encryptionKey.Length + 5;
    if (this._keySize <= 16 /*0x10*/)
      return;
    this._keySize = 16 /*0x10*/;
  }

  public void PrepareEncryption()
  {
    Debug.Assert(this._document._securitySettings.DocumentSecurityLevel != 0);
    int permission = (int) this.Permission;
    bool strongEncryption;
    PdfInteger pdfInteger1;
    PdfInteger pdfInteger2;
    PdfInteger pdfInteger3;
    if (strongEncryption = this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.Encrypted128Bit)
    {
      pdfInteger1 = new PdfInteger(2);
      pdfInteger2 = new PdfInteger(128 /*0x80*/);
      pdfInteger3 = new PdfInteger(3);
    }
    else
    {
      pdfInteger1 = new PdfInteger(1);
      pdfInteger2 = new PdfInteger(40);
      pdfInteger3 = new PdfInteger(2);
    }
    if (string.IsNullOrEmpty(this._userPassword))
      this._userPassword = "";
    if (string.IsNullOrEmpty(this._ownerPassword))
      this._ownerPassword = this._userPassword;
    int permissions = (permission | (strongEncryption ? -3904 : -64)) & -4;
    PdfInteger pdfInteger4 = new PdfInteger(permissions);
    Debug.Assert(this._ownerPassword.Length > 0, "Empty owner password.");
    byte[] userPad = PdfStandardSecurityHandler.PadPassword(this._userPassword);
    byte[] ownerPad = PdfStandardSecurityHandler.PadPassword(this._ownerPassword);
    this._md5.Initialize();
    this._ownerKey = this.ComputeOwnerKey(userPad, ownerPad, strongEncryption);
    this.InitWithUserPassword(PdfEncoders.RawEncoding.GetBytes(this._document.Internals.FirstDocumentID), this._userPassword, this._ownerKey, permissions, strongEncryption);
    PdfString pdfString1 = new PdfString(PdfEncoders.RawEncoding.GetString(this._ownerKey, 0, this._ownerKey.Length));
    PdfString pdfString2 = new PdfString(PdfEncoders.RawEncoding.GetString(this._userKey, 0, this._userKey.Length));
    this.Elements["/Filter"] = (PdfItem) new PdfName("/Standard");
    this.Elements["/V"] = (PdfItem) pdfInteger1;
    this.Elements["/Length"] = (PdfItem) pdfInteger2;
    this.Elements["/R"] = (PdfItem) pdfInteger3;
    this.Elements["/O"] = (PdfItem) pdfString1;
    this.Elements["/U"] = (PdfItem) pdfString2;
    this.Elements["/P"] = (PdfItem) pdfInteger4;
  }

  internal override void WriteObject(PdfWriter writer)
  {
    PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
    writer.SecurityHandler = (PdfStandardSecurityHandler) null;
    base.WriteObject(writer);
    writer.SecurityHandler = securityHandler;
  }

  internal override DictionaryMeta Meta => PdfStandardSecurityHandler.Keys.Meta;

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

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfStandardSecurityHandler.Keys._meta ?? (PdfStandardSecurityHandler.Keys._meta = KeysBase.CreateMeta(typeof (PdfStandardSecurityHandler.Keys)));
      }
    }
  }
}
