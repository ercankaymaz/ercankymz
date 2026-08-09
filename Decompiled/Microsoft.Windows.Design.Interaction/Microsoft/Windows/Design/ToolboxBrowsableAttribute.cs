using System;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ToolboxBrowsableAttribute : Attribute
{
	private static ToolboxBrowsableAttribute _yes;

	private static ToolboxBrowsableAttribute _no;

	private bool _browsable;

	public bool Browsable => _browsable;

	public static ToolboxBrowsableAttribute Yes
	{
		get
		{
			if (_yes == null)
			{
				_yes = new ToolboxBrowsableAttribute(browsable: true);
			}
			return _yes;
		}
	}

	public static ToolboxBrowsableAttribute No
	{
		get
		{
			if (_no == null)
			{
				_no = new ToolboxBrowsableAttribute(browsable: false);
			}
			return _no;
		}
	}

	public ToolboxBrowsableAttribute(bool browsable)
	{
		_browsable = browsable;
	}
}
