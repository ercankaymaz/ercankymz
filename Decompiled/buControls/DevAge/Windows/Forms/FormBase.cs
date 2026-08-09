#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

public class FormBase : Form
{
	internal Container container_0 = null;

	private PositionRecorderIsolatedStorage positionRecorderIsolatedStorage_0 = new PositionRecorderIsolatedStorage();

	[Description("Isolated Storage FileName where the form save the position information")]
	public virtual string StorageFileName
	{
		get
		{
			return positionRecorderIsolatedStorage_0.StorageFileName;
		}
		set
		{
			positionRecorderIsolatedStorage_0.StorageFileName = value;
		}
	}

	[Description("Restore flags")]
	public virtual RestoreFlags RestoreFlags
	{
		get
		{
			return positionRecorderIsolatedStorage_0.RestoreFlags;
		}
		set
		{
			positionRecorderIsolatedStorage_0.RestoreFlags = value;
		}
	}

	[Description("Save flags")]
	public virtual SaveFlags SaveFlags
	{
		get
		{
			return positionRecorderIsolatedStorage_0.SaveFlags;
		}
		set
		{
			positionRecorderIsolatedStorage_0.SaveFlags = value;
		}
	}

	public FormBase()
	{
		Class76.smethod_724(this);
		string text = AppDomain.CurrentDomain.FriendlyName + "." + GetType().ToString() + ".frp";
		char[] invalidPathChars = Path.GetInvalidPathChars();
		for (int i = 0; i < invalidPathChars.Length; i++)
		{
			text = text.Replace(new string(invalidPathChars[i], 1), "");
		}
		StorageFileName = text;
		RestoreFlags = RestoreFlags.None;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		try
		{
			if (!base.DesignMode && (Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				positionRecorderIsolatedStorage_0.Load(this);
			}
		}
		catch (Exception ex)
		{
			Debug.Assert(condition: false, ex.Message);
		}
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
		try
		{
			if (!base.DesignMode && (Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				positionRecorderIsolatedStorage_0.Save(this);
			}
		}
		catch (Exception ex)
		{
			Debug.Assert(condition: false, ex.Message);
		}
	}
}
