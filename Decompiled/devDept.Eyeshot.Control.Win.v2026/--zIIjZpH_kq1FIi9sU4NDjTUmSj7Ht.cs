using System;
using System.Diagnostics;
using SharpDX;
using devDept.Graphics;

internal sealed class _0023_003DzIIjZpH_kq1FIi9sU4NDjTUmSj7Ht : IDataPerObject
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzVwxwk_0024qz784R958faR_00243oCc_003D _0023_003DzbYnfewY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Color4 _0023_003DzSuWnN8cReU69x11R3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Color4 _0023_003DzSwMpccLliBEx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Matrix _0023_003Dz4z8deDYk1AZbE4pGbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Matrix _0023_003DzRnVYe9ghkuB4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Matrix _0023_003DzFE6jbtQii0Cz7u97U95BJ3s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color4 _0023_003Dzso6bfpA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Matrix _0023_003DzdtsZO00Hgb_0024Rj0ipkg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzUTdFkSI_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzIt9jKuJG8ncE = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003Dzyz_0024bfF2zwT8WPfon7g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public uint _0023_003DzdM7iTrCiMP954JENCg_003D_003D = 65535u;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzRVNtcj0ilKIsW3W5qA_003D_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzHtNbVaLv1tw6oApvlY6grW0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzOnHva6wpqpFv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzcLeF_4uietaA = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzYRbzTAwIoBjDBgji_0024g_003D_003D = 1f;

	public Matrix _0023_003DzopCFvVqKl3ge()
	{
		return _0023_003Dz4z8deDYk1AZbE4pGbQ_003D_003D;
	}

	public void _0023_003DzcU0HDYHnAnzt(Matrix _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz4z8deDYk1AZbE4pGbQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	public Matrix _0023_003Dzyn1R7qHoISU_0024()
	{
		return _0023_003DzRnVYe9ghkuB4;
	}

	public void _0023_003DzhgwyyOSliKf6(Matrix _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzRnVYe9ghkuB4 = _0023_003DzsLHxXyo_003D;
		float[] array = _0023_003DzRnVYe9ghkuB4.ToArray();
		array[3] = (array[7] = (array[11] = 0f));
		Matrix matrix = new Matrix(array);
		matrix.Invert();
		matrix.Transpose();
		_0023_003DzFE6jbtQii0Cz7u97U95BJ3s_003D = matrix;
	}

	public Matrix _0023_003DzZRHpJNLdA0uc()
	{
		return _0023_003DzdtsZO00Hgb_0024Rj0ipkg_003D_003D;
	}

	public void _0023_003DzUXELlntdw96H(Matrix _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzdtsZO00Hgb_0024Rj0ipkg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	public Color4 _0023_003Dzg5_0024NsAY_003D()
	{
		return _0023_003Dzso6bfpA_003D;
	}

	public void _0023_003DzodM54I0_003D(Color4 _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzso6bfpA_003D = _0023_003DzsLHxXyo_003D;
	}

	private float[] _0023_003DzoJv_0024hPprb4X1dU_OwzhoiODbtxEmfnNNBg_003D_003D()
	{
		return _0023_003DzopCFvVqKl3ge().ToArray();
	}

	float[] IDataPerObject.get_WorldViewProj()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoJv$hPprb4X1dU_OwzhoiODbtxEmfnNNBg==
		return this._0023_003DzoJv_0024hPprb4X1dU_OwzhoiODbtxEmfnNNBg_003D_003D();
	}

	private float[] _0023_003DzQ5abzZ3x1QxJvSuL3yxO9yeJNfUEx0lHCw_003D_003D()
	{
		return _0023_003Dzyn1R7qHoISU_0024().ToArray();
	}

	float[] IDataPerObject.get_WorldView()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQ5abzZ3x1QxJvSuL3yxO9yeJNfUEx0lHCw==
		return this._0023_003DzQ5abzZ3x1QxJvSuL3yxO9yeJNfUEx0lHCw_003D_003D();
	}

	private float[] _0023_003DzQ5abzZ3x1QxJvSuL3yxO97WLXdLY_0IU91yROqcGNZx6n5slVw_003D_003D()
	{
		return _0023_003DzFE6jbtQii0Cz7u97U95BJ3s_003D.ToArray();
	}

	float[] IDataPerObject.get_WorldViewInvTranspose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQ5abzZ3x1QxJvSuL3yxO97WLXdLY_0IU91yROqcGNZx6n5slVw==
		return this._0023_003DzQ5abzZ3x1QxJvSuL3yxO97WLXdLY_0IU91yROqcGNZx6n5slVw_003D_003D();
	}

	private float[] _0023_003DzftFmZfoy65OrBC2XC5R8Q9HfWIOK()
	{
		return _0023_003DzZRHpJNLdA0uc().ToArray();
	}

	float[] IDataPerObject.get_Model()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zftFmZfoy65OrBC2XC5R8Q9HfWIOK
		return this._0023_003DzftFmZfoy65OrBC2XC5R8Q9HfWIOK();
	}

	private float[] _0023_003DzeSNUyqu79YoddCtAU9IZWWpidqya()
	{
		throw new Exception();
	}

	float[] IDataPerObject.get_View()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zeSNUyqu79YoddCtAU9IZWWpidqya
		return this._0023_003DzeSNUyqu79YoddCtAU9IZWWpidqya();
	}

	private float[] _0023_003DzftFmZfoy65OrBC2XC5R8Q_Bk8bI786yzTQ_003D_003D()
	{
		throw new Exception();
	}

	float[] IDataPerObject.get_Projection()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zftFmZfoy65OrBC2XC5R8Q_Bk8bI786yzTQ==
		return this._0023_003DzftFmZfoy65OrBC2XC5R8Q_Bk8bI786yzTQ_003D_003D();
	}

	private float[] _0023_003DzAqbJGNwjcRJ4wGsCt1p0kPXVycjQpRUM_0024A_003D_003D()
	{
		throw new Exception();
	}

	float[] IDataPerObject.get_InverseModel()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAqbJGNwjcRJ4wGsCt1p0kPXVycjQpRUM$A==
		return this._0023_003DzAqbJGNwjcRJ4wGsCt1p0kPXVycjQpRUM_0024A_003D_003D();
	}

	private float[] _0023_003DzmDwTfek6J_0024i5pJLwCwAarnWpnGPsSVVjMQ_003D_003D()
	{
		throw new Exception();
	}

	float[] IDataPerObject.get_InverseView()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zmDwTfek6J$i5pJLwCwAarnWpnGPsSVVjMQ==
		return this._0023_003DzmDwTfek6J_0024i5pJLwCwAarnWpnGPsSVVjMQ_003D_003D();
	}

	private float[] _0023_003DzWycR0jJJeiiWU6fQtIEF_IUi8rWD1KjZsA_003D_003D()
	{
		throw new Exception();
	}

	float[] IDataPerObject.get_InverseProjection()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zWycR0jJJeiiWU6fQtIEF_IUi8rWD1KjZsA==
		return this._0023_003DzWycR0jJJeiiWU6fQtIEF_IUi8rWD1KjZsA_003D_003D();
	}

	private IGraphicMaterial _0023_003DzwEvUhM3u12cbu0HtKr6CYVEEa6hKVC5ABg_003D_003D()
	{
		return _0023_003DzbYnfewY_003D;
	}

	IGraphicMaterial IDataPerObject.get_FrontMaterial()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zwEvUhM3u12cbu0HtKr6CYVEEa6hKVC5ABg==
		return this._0023_003DzwEvUhM3u12cbu0HtKr6CYVEEa6hKVC5ABg_003D_003D();
	}

	private IGraphicMaterial _0023_003DzQnc0_n3Pq1gqwS0NJA05Ph8m0vXOUeFoVA_003D_003D()
	{
		return new _0023_003DzVwxwk_0024qz784R958faR_00243oCc_003D
		{
			_0023_003Dz0rG_3k0_003D = _0023_003DzSwMpccLliBEx,
			_0023_003DzXN4q_0024zeq8iDq = _0023_003DzSuWnN8cReU69x11R3A_003D_003D,
			_0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = _0023_003DzbYnfewY_003D._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D
		};
	}

	IGraphicMaterial IDataPerObject.get_BackMaterial()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQnc0_n3Pq1gqwS0NJA05Ph8m0vXOUeFoVA==
		return this._0023_003DzQnc0_n3Pq1gqwS0NJA05Ph8m0vXOUeFoVA_003D_003D();
	}

	private float[] _0023_003Dz2grTyBMugUkN_0024H5B70Szad83IlVJ()
	{
		return _0023_003Dzg5_0024NsAY_003D().ToArray();
	}

	float[] IDataPerObject.get_Color()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z2grTyBMugUkN$H5B70Szad83IlVJ
		return this._0023_003Dz2grTyBMugUkN_0024H5B70Szad83IlVJ();
	}

	private bool _0023_003DzZ0oFnJudImniulRwDCoNUw3thCJDDguV1s7D_0024P0_003D()
	{
		return _0023_003DzYRbzTAwIoBjDBgji_0024g_003D_003D > 0f;
	}

	bool IDataPerObject.get_Clippable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zZ0oFnJudImniulRwDCoNUw3thCJDDguV1s7D$P0=
		return this._0023_003DzZ0oFnJudImniulRwDCoNUw3thCJDDguV1s7D_0024P0_003D();
	}
}
