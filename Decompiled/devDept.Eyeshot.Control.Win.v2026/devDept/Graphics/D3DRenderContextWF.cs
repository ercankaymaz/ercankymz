using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Eyeshot;

namespace devDept.Graphics;

public class D3DRenderContextWF : D3DRenderContext
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SwapChain _0023_003DzgysN8KCDFYaw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Texture2D _0023_003DzoyxR2jj9zjVDxhpBSQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RenderTargetView _0023_003DzfIJXGx0_003D;

	public D3DRenderContextWF(Size size, ControlData data, IWorkspace parentWorkspace)
		: base(size, data, parentWorkspace)
	{
	}

	[SpecialName]
	internal override Texture2D _0023_003DzxPP8x2119RobVE2x5A_003D_003D()
	{
		return _0023_003DzoyxR2jj9zjVDxhpBSQ_003D_003D;
	}

	private void _0023_003DzssZON_OawVNv()
	{
		Format format = Format.R8G8B8A8_UNorm;
		_0023_003DzoZFDtSI_003D = _0023_003DzENoa3feOVaqa(format);
		Rational refreshRate = new Rational(60, 1);
		_0023_003DzSTDofQueqO4i = new SwapChainDescription
		{
			BufferCount = 1,
			ModeDescription = new ModeDescription(base.ControlData.ControlSize.Width, base.ControlData.ControlSize.Height, refreshRate, format),
			IsWindowed = true,
			OutputHandle = base.ControlData.controlHandle,
			SampleDescription = _0023_003DzoZFDtSI_003D,
			SwapEffect = SwapEffect.Discard,
			Usage = Usage.RenderTargetOutput
		};
		if (_0023_003DzgysN8KCDFYaw != null)
		{
			_0023_003DzgysN8KCDFYaw.Dispose();
		}
		_0023_003DzgysN8KCDFYaw = new SwapChain(_0023_003Dz3DjOiC4_003D, _0023_003DzTzFVZ_00240_003D, _0023_003DzSTDofQueqO4i);
	}

	public override void UpdateAntialiasing()
	{
		_0023_003DzssZON_OawVNv();
		base.UpdateAntialiasing();
	}

	public override bool InitProgDrawCompositing()
	{
		base.InitProgDrawCompositing();
		ProgDrawCompositingBase = new _0023_003DzTOfXQNfI27qj6JHJXJa5xVYs_Q3t6vKgExftf_0024Bcf_4c();
		return ProgDrawCompositingBase.Init(this);
	}

	public override void Dispose()
	{
		if (_0023_003DzfIJXGx0_003D != null)
		{
			_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzgysN8KCDFYaw);
			base.Dispose();
		}
	}

	public override void EndDraw(bool swapBuffer)
	{
		if (swapBuffer)
		{
			try
			{
				_0023_003DzgysN8KCDFYaw.Present(0, PresentFlags.None);
			}
			catch (SharpDXException)
			{
				throw new GraphicsException(_0023_003DzkXcljqUGbfkt(_0023_003DzTzFVZ_00240_003D.DeviceRemovedReason));
			}
		}
	}

	protected override void InitResourceBuffers(Size size)
	{
		base.InitResourceBuffers(size);
	}

	protected override void InitSwapChainAndBackBufferTexture()
	{
		_0023_003DzssZON_OawVNv();
		_0023_003Dz3DjOiC4_003D.MakeWindowAssociation(base.ControlData.controlHandle, WindowAssociationFlags.IgnoreAll);
		_0023_003DzoyxR2jj9zjVDxhpBSQ_003D_003D = SharpDX.Direct3D11.Resource.FromSwapChain<Texture2D>(_0023_003DzgysN8KCDFYaw, 0);
		_0023_003DzfIJXGx0_003D = new RenderTargetView(_0023_003DzTzFVZ_00240_003D, _0023_003DzxPP8x2119RobVE2x5A_003D_003D());
	}

	internal override Texture2DDescription _0023_003Dz44KfZ5g_003D(int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D)
	{
		return _0023_003DzxPP8x2119RobVE2x5A_003D_003D().Description;
	}

	private protected override void _0023_003DzeIRNKbDi61Y_0024(Texture2DDescription _0023_003DzPsUSx4D2yz6n)
	{
		if (base.ControlData.isFsaaAvailable)
		{
			_0023_003DzJhCjKSkYMq6V = new Texture2D(_0023_003DzTzFVZ_00240_003D, _0023_003DzPsUSx4D2yz6n);
			_0023_003DzipqsQZ_p852_0024 = new RenderTargetView(_0023_003DzTzFVZ_00240_003D, _0023_003DzJhCjKSkYMq6V);
		}
	}

	protected internal override void ResetRenderTarget()
	{
		_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(_0023_003DzfIJXGx0_003D, _0023_003Dz52pY7YIbaCdt));
	}

	public override void Resize(Size size)
	{
		base.Resize(size);
		if (_0023_003DzfIJXGx0_003D != null && size.Width > 2 && size.Height > 2)
		{
			ClearBuffers();
			_0023_003DzgysN8KCDFYaw.ResizeBuffers(_0023_003DzSTDofQueqO4i.BufferCount, size.Width, size.Height, Format.Unknown, SwapChainFlags.None);
			InitResourceBuffers(size);
		}
	}

	protected override void ClearBuffers()
	{
		if (_0023_003DzxPP8x2119RobVE2x5A_003D_003D() != null)
		{
			_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzoyxR2jj9zjVDxhpBSQ_003D_003D);
			_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzfIJXGx0_003D);
			base.ClearBuffers();
		}
	}
}
