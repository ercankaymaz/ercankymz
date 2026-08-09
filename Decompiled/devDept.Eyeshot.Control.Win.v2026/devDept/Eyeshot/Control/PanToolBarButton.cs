using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DefaultToolBarButtonConverter<PanToolBarButton>))]
public sealed class PanToolBarButton : DefaultToolBarButton
{
	public PanToolBarButton()
		: this(_0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D(), DefaultToolBarButton._0023_003DzCp6SpVT8Q9QG(), DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024(), DefaultToolBarButton._0023_003DzlAUaJg4N2d6h())
	{
	}

	public PanToolBarButton(string toolTipText, styleType style, bool visible, bool enabled)
		: base(null, _0023_003DzMqaGBuFvboj9(), toolTipText, style, visible, enabled)
	{
	}

	private PanToolBarButton(PanToolBarButton _0023_003DzsmgIqeCnnRrL)
		: base(_0023_003DzsmgIqeCnnRrL)
	{
	}

	private new static string _0023_003DzMqaGBuFvboj9()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587282);
	}

	private new static string _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587282);
	}

	public override object Clone()
	{
		return new PanToolBarButton(this);
	}

	protected override void DrawImage(System.Drawing.Graphics g, Workspace workspace, int x, int y, int width, int height)
	{
		Viewport viewport = workspace._0023_003DzipBYly6zFKAp();
		bool isDark = viewport.Background.IsDark;
		switch (viewport.Background.ColorTheme)
		{
		case colorThemeType.Light:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzlyVVhZSu9o2a(), x, y, width, height);
			return;
		case colorThemeType.Dark:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYlnAGNDosS9t(), x, y, width, height);
			return;
		}
		if (isDark)
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzlyVVhZSu9o2a(), x, y, width, height);
		}
		else
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYlnAGNDosS9t(), x, y, width, height);
		}
	}
}
