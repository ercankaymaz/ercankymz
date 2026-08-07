// Decompiled with JetBrains decompiler
// Type: DevAge.IO.IsolatedStorage.IsolatedStorageSettingVersionBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

#nullable disable
namespace DevAge.IO.IsolatedStorage;

public abstract class IsolatedStorageSettingVersionBase : IsolatedStorageSettingBase
{
  private int p_Version;

  public IsolatedStorageSettingVersionBase(int p_Version) => this.p_Version = p_Version;

  public virtual int Version => this.p_Version;

  protected override void OnLoad(IsolatedStorageFileStream p_File)
  {
    int p_CurrentVersion = !(StreamPersistence.ReadString((Stream) p_File, Encoding.UTF8) != "BINSETTING") ? StreamPersistence.ReadInt32((Stream) p_File) : throw new DevAge.IO.InvalidDataException();
    this.OnLoad(p_File, p_CurrentVersion);
  }

  protected abstract void OnLoad(IsolatedStorageFileStream p_File, int p_CurrentVersion);

  protected override void OnSave(IsolatedStorageFileStream p_File)
  {
    StreamPersistence.Write((Stream) p_File, "BINSETTING", Encoding.UTF8);
    StreamPersistence.Write((Stream) p_File, this.Version);
  }
}
