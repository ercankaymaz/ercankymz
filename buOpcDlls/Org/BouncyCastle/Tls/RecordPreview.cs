// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.RecordPreview
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class RecordPreview
{
  private readonly int recordSize;
  private readonly int contentLimit;

  internal static RecordPreview CombineAppData(RecordPreview a, RecordPreview b)
  {
    return new RecordPreview(a.RecordSize + b.RecordSize, a.ContentLimit + b.ContentLimit);
  }

  internal static RecordPreview ExtendRecordSize(RecordPreview a, int recordSize)
  {
    return new RecordPreview(a.RecordSize + recordSize, a.ContentLimit);
  }

  internal RecordPreview(int recordSize, int contentLimit)
  {
    this.recordSize = recordSize;
    this.contentLimit = contentLimit;
  }

  public int ContentLimit => this.contentLimit;

  public int RecordSize => this.recordSize;
}
