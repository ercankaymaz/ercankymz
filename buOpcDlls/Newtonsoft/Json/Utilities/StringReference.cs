// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.StringReference
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
[IsReadOnly]
internal struct StringReference(char[] chars, int startIndex, int length)
{
  private readonly char[] _chars = chars;
  private readonly int _startIndex = startIndex;
  private readonly int _length = length;

  public char this[int i] => this._chars[i];

  public char[] Chars => this._chars;

  public int StartIndex => this._startIndex;

  public int Length => this._length;

  public override string ToString() => new string(this._chars, this._startIndex, this._length);
}
