// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

public abstract class CObject : ICloneable
{
  object ICloneable.Clone() => (object) this.Copy();

  public CObject Clone() => this.Copy();

  protected virtual CObject Copy() => (CObject) this.MemberwiseClone();

  internal abstract void WriteObject(ContentWriter writer);
}
