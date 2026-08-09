using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace DevAge.IO.IsolatedStorage;

public abstract class IsolatedStorageSettingBase
{
	private string string_0;

	public virtual string StorageFileName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public IsolatedStorageSettingBase()
	{
		string_0 = null;
	}

	protected virtual IsolatedStorageFile GetStorage()
	{
		return IsolatedStorageFile.GetUserStoreForAssembly();
	}

	public virtual void Load()
	{
		if (string_0 != null)
		{
			using (IsolatedStorageFile isolatedStorageFile = GetStorage())
			{
				IsolatedStorageFileStream isolatedStorageFileStream = null;
				try
				{
					isolatedStorageFileStream = new IsolatedStorageFileStream(StorageFileName, FileMode.Open, FileAccess.Read, isolatedStorageFile);
				}
				catch (FileNotFoundException)
				{
					isolatedStorageFileStream = null;
				}
				if (isolatedStorageFileStream != null)
				{
					try
					{
						OnLoad(isolatedStorageFileStream);
					}
					finally
					{
						isolatedStorageFileStream.Close();
					}
				}
				else
				{
					OnCreate();
				}
				isolatedStorageFile.Close();
				return;
			}
		}
		throw new ApplicationException("Invalid filename");
	}

	public virtual void Reset()
	{
		if (string_0 != null)
		{
			using (IsolatedStorageFile isolatedStorageFile = GetStorage())
			{
				try
				{
					isolatedStorageFile.DeleteFile(StorageFileName);
				}
				catch (Exception)
				{
				}
				finally
				{
					OnCreate();
				}
				isolatedStorageFile.Close();
				return;
			}
		}
		throw new ApplicationException("Invalid filename");
	}

	public virtual void Save()
	{
		if (string_0 != null)
		{
			using (IsolatedStorageFile isolatedStorageFile = GetStorage())
			{
				using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(StorageFileName, FileMode.Create, FileAccess.Write, isolatedStorageFile))
				{
					OnSave(isolatedStorageFileStream);
					isolatedStorageFileStream.Close();
				}
				isolatedStorageFile.Close();
				return;
			}
		}
		throw new ApplicationException("Invalid filename");
	}

	protected abstract void OnCreate();

	protected abstract void OnLoad(IsolatedStorageFileStream p_File);

	protected abstract void OnSave(IsolatedStorageFileStream p_File);
}
