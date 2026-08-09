using System;
using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(MultiTouchConverter))]
public class MultiTouchSettings
{
	internal bool UseWindowsMessages = true;

	private bool _enableMultiTouchMovements = true;

	private bool _rotate = true;

	private bool _zoom = true;

	private bool _pan = true;

	internal Workspace Parent;

	[Description("Indicates whether the movements are enabled.")]
	public bool Enabled
	{
		get
		{
			return _enableMultiTouchMovements;
		}
		set
		{
			_enableMultiTouchMovements = value;
			if (Parent != null)
			{
				Parent._0023_003DzoOUvN_zrx2mU0zQebQ_003D_003D();
			}
		}
	}

	[Description("Enables or disables the rotation with two fingers")]
	public bool Rotate
	{
		get
		{
			return _rotate;
		}
		set
		{
			_rotate = value;
		}
	}

	[Description("Enables or disables the zoom with two fingers")]
	public bool Zoom
	{
		get
		{
			return _zoom;
		}
		set
		{
			_zoom = value;
		}
	}

	[Description("Enables or disables the pan with two fingers")]
	public bool Pan
	{
		get
		{
			return _pan;
		}
		set
		{
			_pan = value;
		}
	}

	public MultiTouchSettings(bool enableMultiTouchMovements)
	{
		Enabled = enableMultiTouchMovements;
	}

	public MultiTouchSettings(bool enableMultiTouchMovements, bool zoom, bool pan, bool rotate)
	{
		Enabled = enableMultiTouchMovements;
		Zoom = zoom;
		Pan = pan;
		Rotate = rotate;
	}

	private bool _0023_003DzcY1SwfFv_M8s()
	{
		return !Enabled;
	}

	internal void _0023_003DzNSayyTKTSOmA()
	{
		Enabled = true;
	}

	private bool _0023_003DzDw3dPMSFPic7()
	{
		return !Rotate;
	}

	internal void _0023_003DzT8Dz_kXi1epc()
	{
		Rotate = true;
	}

	private bool _0023_003Dz1YUE9kaauEs4()
	{
		return !Zoom;
	}

	internal void _0023_003DzAayHMIGXjKXe()
	{
		Zoom = true;
	}

	private bool _0023_003DziPKUPI5CE5JW()
	{
		return !Pan;
	}

	internal void _0023_003Dz9gF9bIOJ0t7e()
	{
		Pan = true;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(MultiTouchSettings _0023_003DzAbAO3f4_003D)
	{
		if (Enabled == _0023_003DzAbAO3f4_003D.Enabled && Zoom == _0023_003DzAbAO3f4_003D.Zoom && Pan == _0023_003DzAbAO3f4_003D.Pan)
		{
			return Rotate != _0023_003DzAbAO3f4_003D.Rotate;
		}
		return true;
	}
}
