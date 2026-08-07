// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonContainerAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(2)]
[Nullable(0)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
public abstract class JsonContainerAttribute : Attribute
{
  internal bool? _isReference;
  internal bool? _itemIsReference;
  internal ReferenceLoopHandling? _itemReferenceLoopHandling;
  internal TypeNameHandling? _itemTypeNameHandling;
  private Type _namingStrategyType;
  [Nullable(new byte[] {2, 1})]
  private object[] _namingStrategyParameters;

  public string Id { get; set; }

  public string Title { get; set; }

  public string Description { get; set; }

  public Type ItemConverterType { get; set; }

  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public object[] ItemConverterParameters { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  public Type NamingStrategyType
  {
    get => this._namingStrategyType;
    set
    {
      this._namingStrategyType = value;
      this.NamingStrategyInstance = (NamingStrategy) null;
    }
  }

  [Nullable(new byte[] {2, 1})]
  public object[] NamingStrategyParameters
  {
    [return: Nullable(new byte[] {2, 1})] get => this._namingStrategyParameters;
    [param: Nullable(new byte[] {2, 1})] set
    {
      this._namingStrategyParameters = value;
      this.NamingStrategyInstance = (NamingStrategy) null;
    }
  }

  internal NamingStrategy NamingStrategyInstance { get; set; }

  public bool IsReference
  {
    get => this._isReference.GetValueOrDefault();
    set => this._isReference = new bool?(value);
  }

  public bool ItemIsReference
  {
    get => this._itemIsReference.GetValueOrDefault();
    set => this._itemIsReference = new bool?(value);
  }

  public ReferenceLoopHandling ItemReferenceLoopHandling
  {
    get => this._itemReferenceLoopHandling.GetValueOrDefault();
    set => this._itemReferenceLoopHandling = new ReferenceLoopHandling?(value);
  }

  public TypeNameHandling ItemTypeNameHandling
  {
    get => this._itemTypeNameHandling.GetValueOrDefault();
    set => this._itemTypeNameHandling = new TypeNameHandling?(value);
  }

  protected JsonContainerAttribute()
  {
  }

  [NullableContext(1)]
  protected JsonContainerAttribute(string id) => this.Id = id;
}
