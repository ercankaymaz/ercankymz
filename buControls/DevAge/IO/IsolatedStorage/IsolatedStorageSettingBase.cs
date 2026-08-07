// Decompiled with JetBrains decompiler
// Type: DevAge.IO.IsolatedStorage.IsolatedStorageSettingBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.IO;
using System.IO.IsolatedStorage;

#nullable disable
namespace DevAge.IO.IsolatedStorage;

public abstract class IsolatedStorageSettingBase
{
  private string string_0;

  public virtual string StorageFileName
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public IsolatedStorageSettingBase() => this.string_0 = (string) null;

  protected virtual IsolatedStorageFile GetStorage()
  {
    return IsolatedStorageFile.GetUserStoreForAssembly();
  }

  public virtual void Load()
  {
    if (this.string_0 == null)
      throw new ApplicationException("Invalid filename");
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      IsolatedStorageFileStream p_File;
      try
      {
        p_File = new IsolatedStorageFileStream(this.StorageFileName, FileMode.Open, FileAccess.Read, storage);
      }
      catch (FileNotFoundException ex)
      {
        p_File = (IsolatedStorageFileStream) null;
      }
      if (p_File == null)
      {
        this.OnCreate();
      }
      else
      {
        try
        {
          this.OnLoad(p_File);
        }
        finally
        {
          p_File.Close();
        }
      }
      storage.Close();
    }
  }

  public virtual void Reset()
  {
    if (this.string_0 == null)
      throw new ApplicationException("Invalid filename");
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      try
      {
        storage.DeleteFile(this.StorageFileName);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        this.OnCreate();
      }
      storage.Close();
    }
  }

  public virtual void Save()
  {
    if (this.string_0 == null)
      throw new ApplicationException("Invalid filename");
    using (IsolatedStorageFile storage = this.GetStorage())
    {
      using (IsolatedStorageFileStream p_File = new IsolatedStorageFileStream(this.StorageFileName, FileMode.Create, FileAccess.Write, storage))
      {
        this.OnSave(p_File);
        p_File.Close();
      }
      storage.Close();
    }
  }

  protected abstract void OnCreate();

  protected abstract void OnLoad(IsolatedStorageFileStream p_File);

  protected abstract void OnSave(IsolatedStorageFileStream p_File);
}
