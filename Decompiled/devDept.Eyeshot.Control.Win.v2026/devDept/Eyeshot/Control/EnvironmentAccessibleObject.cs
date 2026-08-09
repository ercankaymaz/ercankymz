using System.Diagnostics;
using System.Windows.Forms;
using Accessibility;

namespace devDept.Eyeshot.Control;

public class EnvironmentAccessibleObject : System.Windows.Forms.Control.ControlAccessibleObject, IAccessible
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzzO4Z6lTYD_0024NCCyyJkZj4H4gV_yAeKNSUMQ_003D_003D _0023_003Dzq_0024f5HHj3xeR_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzKNaTZYA_003D;

	public override string Value
	{
		get
		{
			return _0023_003Dzq_0024f5HHj3xeR_0024._0023_003Dzt_0024trzXE_003D();
		}
		set
		{
			_0023_003Dzq_0024f5HHj3xeR_0024._0023_003DztWrPwvo_003D(value);
		}
	}

	public override string Name
	{
		get
		{
			string text = _0023_003DzKNaTZYA_003D;
			if (text != null)
			{
				return text;
			}
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public EnvironmentAccessibleObject(Workspace workspace)
		: base(workspace)
	{
		_0023_003Dzq_0024f5HHj3xeR_0024 = new _0023_003DzzO4Z6lTYD_0024NCCyyJkZj4H4gV_yAeKNSUMQ_003D_003D(workspace);
		_0023_003DzKNaTZYA_003D = workspace.Name;
	}
}
