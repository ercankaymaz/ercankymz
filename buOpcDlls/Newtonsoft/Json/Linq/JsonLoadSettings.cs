// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonLoadSettings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json.Linq;

public class JsonLoadSettings
{
  private CommentHandling _commentHandling;
  private LineInfoHandling _lineInfoHandling;
  private DuplicatePropertyNameHandling _duplicatePropertyNameHandling;

  public JsonLoadSettings()
  {
    this._lineInfoHandling = LineInfoHandling.Load;
    this._commentHandling = CommentHandling.Ignore;
    this._duplicatePropertyNameHandling = DuplicatePropertyNameHandling.Replace;
  }

  public CommentHandling CommentHandling
  {
    get => this._commentHandling;
    set
    {
      this._commentHandling = value >= CommentHandling.Ignore && value <= CommentHandling.Load ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public LineInfoHandling LineInfoHandling
  {
    get => this._lineInfoHandling;
    set
    {
      this._lineInfoHandling = value >= LineInfoHandling.Ignore && value <= LineInfoHandling.Load ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public DuplicatePropertyNameHandling DuplicatePropertyNameHandling
  {
    get => this._duplicatePropertyNameHandling;
    set
    {
      this._duplicatePropertyNameHandling = value >= DuplicatePropertyNameHandling.Replace && value <= DuplicatePropertyNameHandling.Error ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }
}
