using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

internal struct _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003Dz19V87tw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzaKmBh2M_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzFrc_0024oLQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzDw__wI8_003D;

	[IndexerName("#=zEwKyw5s=")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float this[int _0023_003DzSordH9w_003D] => _0023_003DzSordH9w_003D switch
	{
		0 => _0023_003Dz19V87tw_003D, 
		1 => _0023_003DzaKmBh2M_003D, 
		2 => _0023_003DzFrc_0024oLQ_003D, 
		3 => _0023_003DzDw__wI8_003D, 
		_ => throw new IndexOutOfRangeException(), 
	};

	public _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(Color _0023_003DzKni9bTk_003D)
	{
		_0023_003Dz19V87tw_003D = (float)(int)_0023_003DzKni9bTk_003D.R / 255f;
		_0023_003DzaKmBh2M_003D = (float)(int)_0023_003DzKni9bTk_003D.G / 255f;
		_0023_003DzFrc_0024oLQ_003D = (float)(int)_0023_003DzKni9bTk_003D.B / 255f;
		_0023_003DzDw__wI8_003D = (float)(int)_0023_003DzKni9bTk_003D.A / 255f;
	}

	public _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(float[] _0023_003Dzhpb8QNg_003D)
	{
		this = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(_0023_003Dzhpb8QNg_003D[0], _0023_003Dzhpb8QNg_003D[1], _0023_003Dzhpb8QNg_003D[2], (_0023_003Dzhpb8QNg_003D.Length > 3) ? _0023_003Dzhpb8QNg_003D[3] : 1f);
	}

	public _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(float _0023_003DzpGw_0024feA_003D, float _0023_003DzVC9FBdo_003D, float _0023_003Dz5PxKZP0_003D)
	{
		this = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(_0023_003DzpGw_0024feA_003D, _0023_003DzVC9FBdo_003D, _0023_003Dz5PxKZP0_003D, 1f);
	}

	public _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(float _0023_003DzpGw_0024feA_003D, float _0023_003DzVC9FBdo_003D, float _0023_003Dz5PxKZP0_003D, float _0023_003Dz6It9KyA_003D)
	{
		_0023_003Dz19V87tw_003D = _0023_003DzpGw_0024feA_003D;
		_0023_003DzaKmBh2M_003D = _0023_003DzVC9FBdo_003D;
		_0023_003DzFrc_0024oLQ_003D = _0023_003Dz5PxKZP0_003D;
		_0023_003DzDw__wI8_003D = _0023_003Dz6It9KyA_003D;
	}

	public float[] _0023_003DzE1Ph3_00248_003D()
	{
		return new float[4] { _0023_003Dz19V87tw_003D, _0023_003DzaKmBh2M_003D, _0023_003DzFrc_0024oLQ_003D, _0023_003DzDw__wI8_003D };
	}

	public Color _0023_003DzfJHJIE4_003D()
	{
		return Color.FromArgb(_0023_003Dqm9Qen2poOiNf9TyuByqPFZYgYfcLErtqhUSgRxrTEyg_003D(_0023_003DzDw__wI8_003D), _0023_003Dqm9Qen2poOiNf9TyuByqPFZYgYfcLErtqhUSgRxrTEyg_003D(_0023_003Dz19V87tw_003D), _0023_003Dqm9Qen2poOiNf9TyuByqPFZYgYfcLErtqhUSgRxrTEyg_003D(_0023_003DzaKmBh2M_003D), _0023_003Dqm9Qen2poOiNf9TyuByqPFZYgYfcLErtqhUSgRxrTEyg_003D(_0023_003DzFrc_0024oLQ_003D));
	}

	public static bool operator ==(_0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D _0023_003Dz6It9KyA_003D, _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D _0023_003Dz5PxKZP0_003D)
	{
		if ((double)Math.Abs(_0023_003Dz6It9KyA_003D._0023_003DzDw__wI8_003D - _0023_003Dz5PxKZP0_003D._0023_003DzDw__wI8_003D) < 1E-12 && (double)Math.Abs(_0023_003Dz6It9KyA_003D._0023_003Dz19V87tw_003D - _0023_003Dz5PxKZP0_003D._0023_003Dz19V87tw_003D) < 1E-12 && (double)Math.Abs(_0023_003Dz6It9KyA_003D._0023_003DzaKmBh2M_003D - _0023_003Dz5PxKZP0_003D._0023_003DzaKmBh2M_003D) < 1E-12)
		{
			return (double)Math.Abs(_0023_003Dz6It9KyA_003D._0023_003DzFrc_0024oLQ_003D - _0023_003Dz5PxKZP0_003D._0023_003DzFrc_0024oLQ_003D) < 1E-12;
		}
		return false;
	}

	public static bool operator !=(_0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D _0023_003Dz6It9KyA_003D, _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D _0023_003Dz5PxKZP0_003D)
	{
		return !(_0023_003Dz6It9KyA_003D == _0023_003Dz5PxKZP0_003D);
	}

	public override string ToString()
	{
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609009), _0023_003Dz19V87tw_003D, _0023_003DzaKmBh2M_003D, _0023_003DzFrc_0024oLQ_003D, _0023_003DzDw__wI8_003D);
	}

	internal static int _0023_003Dqm9Qen2poOiNf9TyuByqPFZYgYfcLErtqhUSgRxrTEyg_003D(float _0023_003Dz8GBMuoM_003D)
	{
		return (int)Math.Floor(_0023_003Dz8GBMuoM_003D * 255f);
	}
}
