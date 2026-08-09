using System.Drawing;

namespace devDept.Eyeshot.Control;

public abstract class DefaultToolBarButton : ToolBarButton
{
	public override Image Image
	{
		get
		{
			return null;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589244));
		}
	}

	public override Image DownImage
	{
		get
		{
			return null;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589244));
		}
	}

	public override Image HoverImage
	{
		get
		{
			return null;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589244));
		}
	}

	protected DefaultToolBarButton(string toolTipText, styleType style, bool visible, bool enabled)
	{
	}

	protected DefaultToolBarButton(Image buttonImage, string name, string toolTipText, styleType style, bool visible, bool enabled)
		: base(buttonImage, name, toolTipText, style, visible, enabled)
	{
	}

	protected DefaultToolBarButton(DefaultToolBarButton another)
		: base(another)
	{
	}

	internal static string _0023_003DzMqaGBuFvboj9()
	{
		return string.Empty;
	}

	internal static string _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()
	{
		return string.Empty;
	}

	internal static styleType _0023_003DzCp6SpVT8Q9QG()
	{
		return styleType.ToggleButton;
	}

	internal static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	internal static bool _0023_003DzlAUaJg4N2d6h()
	{
		return true;
	}

	protected internal override bool IsDefaultButton()
	{
		return true;
	}

	internal virtual bool _0023_003DzN1MCycjcfHnNXgRZrliT_Ns_003D()
	{
		return false;
	}

	internal virtual bool _0023_003DznD4RJAAzruL6()
	{
		return false;
	}
}
