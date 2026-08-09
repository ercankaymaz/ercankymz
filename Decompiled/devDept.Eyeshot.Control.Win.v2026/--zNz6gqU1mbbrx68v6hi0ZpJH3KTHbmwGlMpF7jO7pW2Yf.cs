using System.Drawing;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzNz6gqU1mbbrx68v6hi0ZpJH3KTHbmwGlMpF7jO7pW2Yf : _0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D
{
	public _0023_003DzNz6gqU1mbbrx68v6hi0ZpJH3KTHbmwGlMpF7jO7pW2Yf(Point3D _0023_003Dz1444P10Wa9OXHN1_AA_003D_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ, MaterialKeyedCollection _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D)
		: base(_0023_003Dz1444P10Wa9OXHN1_AA_003D_003D, _0023_003DzjDdbnzc6miMJ, _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D)
	{
	}

	public override int Compare(Entity _0023_003DzJgB4fbA_003D, Entity _0023_003DzvbseIi4_003D)
	{
		Color color = _0023_003DzJgB4fbA_003D.GetColor(_0023_003DzRj39t48_003D);
		Color color2 = _0023_003DzvbseIi4_003D.GetColor(_0023_003DzRj39t48_003D);
		return _0023_003DzS5KVJ48_003D(_0023_003DzJgB4fbA_003D, _0023_003DzvbseIi4_003D, color, color2);
	}
}
