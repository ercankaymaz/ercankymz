using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DefaultToolBarButtonConverter<ToolBarSeparator>))]
public sealed class ToolBarSeparator : DefaultToolBarButton
{
	public ToolBarSeparator()
		: this(_0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D(), _0023_003DzCp6SpVT8Q9QG(), DefaultToolBarButton._0023_003DzndG2TcxO_tb_0024(), DefaultToolBarButton._0023_003DzlAUaJg4N2d6h())
	{
	}

	public ToolBarSeparator(string toolTipText, styleType style, bool visible, bool enabled)
		: base(null, _0023_003DzMqaGBuFvboj9(), toolTipText, style, visible, enabled)
	{
	}

	private ToolBarSeparator(ToolBarSeparator _0023_003DzsmgIqeCnnRrL)
		: base(_0023_003DzsmgIqeCnnRrL)
	{
	}

	private new static string _0023_003DzMqaGBuFvboj9()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593934);
	}

	private new static string _0023_003DzMaRWbtcDrjE7JsYNuA_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593934);
	}

	private new static styleType _0023_003DzCp6SpVT8Q9QG()
	{
		return styleType.Separator;
	}

	public override object Clone()
	{
		return new ToolBarSeparator(this);
	}
}
