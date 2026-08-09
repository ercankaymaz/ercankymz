using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DefaultToolBarButtonConverter<PauseToolBarButton>))]
public sealed class PauseToolBarButton : DefaultToolBarButton
{
	public PauseToolBarButton()
		: this(_0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D(), _0023_003DzCp6SpVT8Q9QG(), DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024(), DefaultToolBarButton._0023_003DzlAUaJg4N2d6h())
	{
	}

	public PauseToolBarButton(string toolTipText, styleType style, bool visible, bool enabled)
		: base(_0023_003DznYWOeKNePhve(), _0023_003DzMqaGBuFvboj9(), toolTipText, style, visible, enabled)
	{
	}

	private PauseToolBarButton(PauseToolBarButton _0023_003DzsmgIqeCnnRrL)
		: base(_0023_003DzsmgIqeCnnRrL)
	{
	}

	private static Image _0023_003DznYWOeKNePhve()
	{
		return null;
	}

	private new static string _0023_003DzMqaGBuFvboj9()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648910);
	}

	private new static string _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587304);
	}

	private new static styleType _0023_003DzCp6SpVT8Q9QG()
	{
		return styleType.PushButton;
	}

	internal override bool _0023_003DzN1MCycjcfHnNXgRZrliT_Ns_003D()
	{
		return true;
	}

	internal override bool _0023_003DznD4RJAAzruL6()
	{
		return true;
	}

	public override object Clone()
	{
		return new PauseToolBarButton(this);
	}

	protected override void DrawImage(System.Drawing.Graphics g, Workspace workspace, int x, int y, int width, int height)
	{
		Viewport viewport = workspace._0023_003DzipBYly6zFKAp();
		bool isDark = viewport.Background.IsDark;
		switch (viewport.Background.ColorTheme)
		{
		case colorThemeType.Light:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz7lur5v_XFTKw(), x, y, width, height);
			return;
		case colorThemeType.Dark:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYv0YNl9wdjVx(), x, y, width, height);
			return;
		}
		if (isDark)
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz7lur5v_XFTKw(), x, y, width, height);
		}
		else
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYv0YNl9wdjVx(), x, y, width, height);
		}
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Image == _0023_003DznYWOeKNePhve() && !(base.Name != _0023_003DzMqaGBuFvboj9()) && !(base.ToolTipText != _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()) && base.StyleMode == _0023_003DzCp6SpVT8Q9QG() && base.Visible == DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024())
		{
			return base.Enabled != DefaultToolBarButton._0023_003DzlAUaJg4N2d6h();
		}
		return true;
	}
}
