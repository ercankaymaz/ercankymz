using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DefaultToolBarButtonConverter<CancelToolBarButton>))]
public sealed class CancelToolBarButton : DefaultToolBarButton
{
	public CancelToolBarButton()
		: this(_0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D(), DefaultToolBarButton._0023_003DzCp6SpVT8Q9QG(), DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024(), DefaultToolBarButton._0023_003DzlAUaJg4N2d6h())
	{
	}

	public CancelToolBarButton(string toolTipText, styleType style, bool visible, bool enabled)
		: base(_0023_003DznYWOeKNePhve(), _0023_003DzMqaGBuFvboj9(), toolTipText, style, visible, enabled)
	{
		_0023_003DzVCRPD_0024GbQNCA = true;
	}

	private CancelToolBarButton(CancelToolBarButton _0023_003DzsmgIqeCnnRrL)
		: base(_0023_003DzsmgIqeCnnRrL)
	{
	}

	private static Image _0023_003DznYWOeKNePhve()
	{
		return null;
	}

	private new static string _0023_003DzMqaGBuFvboj9()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651381);
	}

	private new static string _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651381);
	}

	public override object Clone()
	{
		return new CancelToolBarButton(this);
	}

	protected override void DrawImage(System.Drawing.Graphics g, Workspace workspace, int x, int y, int width, int height)
	{
		Viewport viewport = workspace._0023_003DzipBYly6zFKAp();
		bool isDark = viewport.Background.IsDark;
		switch (viewport.Background.ColorTheme)
		{
		case colorThemeType.Light:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dzte1JBsN5AhZU(), x, y, width, height);
			return;
		case colorThemeType.Dark:
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz7rsYJypMtXGZ(), x, y, width, height);
			return;
		}
		if (isDark)
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dzte1JBsN5AhZU(), x, y, width, height);
		}
		else
		{
			DrawImage(g, _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz7rsYJypMtXGZ(), x, y, width, height);
		}
	}

	internal override bool _0023_003DzA_0024ihSwbmVYvs(ToolBarButton _0023_003DzDx8rGzwxy0Do, ClickEventHandler _0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D)
	{
		bool result = base._0023_003DzA_0024ihSwbmVYvs(_0023_003DzDx8rGzwxy0Do, _0023_003DzasRZnI9H_0024UR1BGGw3w_003D_003D);
		if ((object)this == _0023_003DzDx8rGzwxy0Do)
		{
			_0023_003Dz4iBK5_0024N3N5g7.ParentViewport._0023_003Dz0TvaYNo_003D.CancelWork();
		}
		return result;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Image == _0023_003DznYWOeKNePhve() && !(base.Name != _0023_003DzMqaGBuFvboj9()) && !(base.ToolTipText != _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()) && base.StyleMode == DefaultToolBarButton._0023_003DzCp6SpVT8Q9QG() && base.Visible == DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024())
		{
			return base.Enabled != DefaultToolBarButton._0023_003DzlAUaJg4N2d6h();
		}
		return true;
	}
}
