using System.IO.IsolatedStorage;
using System.Text;

namespace DevAge.IO.IsolatedStorage;

public abstract class IsolatedStorageSettingVersionBase : IsolatedStorageSettingBase
{
	private int p_Version;

	public virtual int Version => p_Version;

	public IsolatedStorageSettingVersionBase(int p_Version)
	{
		this.p_Version = p_Version;
	}

	protected override void OnLoad(IsolatedStorageFileStream p_File)
	{
		string text = StreamPersistence.ReadString(p_File, Encoding.UTF8);
		if (text != "BINSETTING")
		{
			throw new InvalidDataException();
		}
		int p_CurrentVersion = StreamPersistence.ReadInt32(p_File);
		OnLoad(p_File, p_CurrentVersion);
	}

	protected abstract void OnLoad(IsolatedStorageFileStream p_File, int p_CurrentVersion);

	protected override void OnSave(IsolatedStorageFileStream p_File)
	{
		StreamPersistence.Write(p_File, "BINSETTING", Encoding.UTF8);
		StreamPersistence.Write(p_File, Version);
	}
}
