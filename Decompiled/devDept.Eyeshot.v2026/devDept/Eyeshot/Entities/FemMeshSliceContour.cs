using System.Diagnostics;
using System.Drawing;
using devDept.Graphics;

namespace devDept.Eyeshot.Entities;

public class FemMeshSliceContour : FemMeshSlice
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Color[] _0023_003Dz5hMtsIJK5NGw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzC1YgzwxjBfvS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D;

	public FemMeshSliceContour(ILegend legend, bool contourPlot)
		: base(natureType.RichPlain)
	{
		_0023_003Dz5hMtsIJK5NGw = legend.GetColorTable();
		_0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D = contourPlot;
	}

	public FemMeshSliceContour(FemMeshSliceContour another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003Dz5hMtsIJK5NGw = another._0023_003Dz5hMtsIJK5NGw;
	}

	public override object Clone()
	{
		return new FemMeshSliceContour(this);
	}

	public override object CloneWithTessellation()
	{
		return new FemMeshSliceContour(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Dispose()
	{
		_0023_003DzC1YgzwxjBfvS.Dispose();
		base.Dispose();
	}

	public override void Compile(CompileParams data)
	{
		textureFilteringFunctionType textureFilteringFunctionType2 = ((!_0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D) ? textureFilteringFunctionType.Linear : textureFilteringFunctionType.Nearest);
		_0023_003DzC1YgzwxjBfvS = data.RenderContext.CreateTexture1D(_0023_003Dz5hMtsIJK5NGw, textureFilteringFunctionType2, textureFilteringFunctionType2, anisotropicFiltering: false, repeatX: false);
		base.Compile(data);
	}

	protected internal override void SetShader(DrawParams data)
	{
		if (data.Selected || data.ForceGray)
		{
			base.SetShader(data);
			return;
		}
		data.ShaderParams.Texture1D = true;
		base.SetShader(data);
		data.ShaderParams.Texture1D = false;
	}

	protected internal override void Draw(DrawParams data)
	{
		FemMesh._0023_003DzJEiCNqlYb39U(_0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D, _0023_003DzC1YgzwxjBfvS, data, _0023_003DzpdX56LA_003D: false, out var _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, out var _0023_003DzQjF9MKbOP7L, out var _0023_003DzHHapgdI86YwJ);
		base.Draw(data);
		FemMesh._0023_003DzabFld05zU9Mg(_0023_003DzC1YgzwxjBfvS, data, _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, _0023_003DzQjF9MKbOP7L, _0023_003DzHHapgdI86YwJ);
	}

	protected internal override void Render(RenderParams data)
	{
		data.RenderContext.SetTexture(_0023_003DzC1YgzwxjBfvS);
		FemMesh._0023_003DzJEiCNqlYb39U(_0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D, _0023_003DzC1YgzwxjBfvS, data, _0023_003DzpdX56LA_003D: false, out var _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, out var _0023_003DzQjF9MKbOP7L, out var _0023_003DzHHapgdI86YwJ);
		base.Render(data);
		FemMesh._0023_003DzabFld05zU9Mg(_0023_003DzC1YgzwxjBfvS, data, _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, _0023_003DzQjF9MKbOP7L, _0023_003DzHHapgdI86YwJ);
		data.RenderContext.CloseTexture();
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		if (data.ShaderParams != null || data.RenderContext.IsDirect3D)
		{
			data.ShaderParams.RenderContext.PushShader();
			SetShader(data);
		}
		FemMesh._0023_003DzJEiCNqlYb39U(_0023_003DzVydn8qi2scQvvDR7RnP7aeA_003D, _0023_003DzC1YgzwxjBfvS, data, _0023_003DzpdX56LA_003D: true, out var _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, out var _0023_003DzQjF9MKbOP7L, out var _0023_003DzHHapgdI86YwJ);
		base.Draw(data);
		FemMesh._0023_003DzabFld05zU9Mg(_0023_003DzC1YgzwxjBfvS, data, _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, _0023_003DzQjF9MKbOP7L, _0023_003DzHHapgdI86YwJ);
		if (data.ShaderParams != null || data.RenderContext.IsDirect3D)
		{
			data.ShaderParams.RenderContext.PopShader();
		}
	}
}
