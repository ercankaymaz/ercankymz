using System.Drawing;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using DevAge.IO;
using DevAge.IO.IsolatedStorage;

namespace DevAge.Windows.Forms;

public class PositionRecorderIsolatedStorage : IsolatedStorageSettingVersionBase
{
	private Point point_0;

	private Size size_0;

	private FormWindowState formWindowState_0;

	private RestoreFlags restoreFlags_0 = RestoreFlags.WindowState | RestoreFlags.Size | RestoreFlags.Location;

	private SaveFlags saveFlags_0 = SaveFlags.ActiveMDIMaximized;

	public RestoreFlags RestoreFlags
	{
		get
		{
			return restoreFlags_0;
		}
		set
		{
			restoreFlags_0 = value;
		}
	}

	public SaveFlags SaveFlags
	{
		get
		{
			return saveFlags_0;
		}
		set
		{
			saveFlags_0 = value;
		}
	}

	public Point Location
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
		}
	}

	public Size Size
	{
		get
		{
			return size_0;
		}
		set
		{
			size_0 = value;
		}
	}

	public FormWindowState WindowState
	{
		get
		{
			return formWindowState_0;
		}
		set
		{
			formWindowState_0 = value;
		}
	}

	public PositionRecorderIsolatedStorage()
		: base(1)
	{
	}

	protected override void OnLoad(IsolatedStorageFileStream p_File, int p_CurrentVersion)
	{
		if (p_CurrentVersion != Version)
		{
			throw new InvalidDataException();
		}
		int x = StreamPersistence.ReadInt32(p_File);
		int y = StreamPersistence.ReadInt32(p_File);
		int width = StreamPersistence.ReadInt32(p_File);
		int height = StreamPersistence.ReadInt32(p_File);
		int num = StreamPersistence.ReadInt32(p_File);
		point_0.X = x;
		point_0.Y = y;
		size_0.Width = width;
		size_0.Height = height;
		formWindowState_0 = (FormWindowState)num;
	}

	protected override void OnSave(IsolatedStorageFileStream p_File)
	{
		base.OnSave(p_File);
		StreamPersistence.Write(p_File, point_0.X);
		StreamPersistence.Write(p_File, point_0.Y);
		StreamPersistence.Write(p_File, size_0.Width);
		StreamPersistence.Write(p_File, size_0.Height);
		StreamPersistence.Write(p_File, (int)formWindowState_0);
	}

	protected override void OnCreate()
	{
		point_0 = new Point(int.MinValue, int.MinValue);
		size_0 = new Size(int.MinValue, int.MinValue);
		formWindowState_0 = (FormWindowState)(-1);
	}

	public virtual void Save(Control p_Control)
	{
		if (p_Control is Form)
		{
			Form form = (Form)p_Control;
			if ((saveFlags_0 & SaveFlags.ActiveMDIMaximized) != SaveFlags.ActiveMDIMaximized || !form.IsMdiChild)
			{
				WindowState = form.WindowState;
			}
			else if (form.MdiParent.ActiveMdiChild == null || form.MdiParent.ActiveMdiChild.WindowState != FormWindowState.Maximized)
			{
				WindowState = form.WindowState;
			}
			else
			{
				WindowState = FormWindowState.Maximized;
			}
		}
		if (WindowState != FormWindowState.Minimized)
		{
			Location = p_Control.Location;
			Size = p_Control.Size;
		}
		Save();
	}

	public virtual void Load(Control p_Control)
	{
		Load();
		if ((RestoreFlags & RestoreFlags.WindowState) == RestoreFlags.WindowState && p_Control is Form && WindowState != (FormWindowState)(-1) && (WindowState != FormWindowState.Minimized || (RestoreFlags & RestoreFlags.Minimized) == RestoreFlags.Minimized))
		{
			((Form)p_Control).WindowState = WindowState;
		}
		if (!(p_Control is Form) || ((Form)p_Control).WindowState != FormWindowState.Minimized)
		{
			if ((RestoreFlags & RestoreFlags.Location) == RestoreFlags.Location && Location.X != int.MinValue)
			{
				p_Control.Location = Location;
			}
			if ((RestoreFlags & RestoreFlags.Size) == RestoreFlags.Size && Size.Width != int.MinValue)
			{
				p_Control.Size = Size;
			}
		}
	}
}
