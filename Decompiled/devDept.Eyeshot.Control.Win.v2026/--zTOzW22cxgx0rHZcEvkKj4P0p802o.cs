using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;

internal sealed class _0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> where _0023_003DzWoS2eJk_003D : GLShader, new()
{
	private sealed class _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D
	{
		public HashSet<string> _0023_003DzJULyN5iyjAK5;

		internal string _0023_003Dzf_DWEDpb3d3O8tBouw_003D_003D(Match _0023_003DzNSxy50o_003D)
		{
			_0023_003DzJULyN5iyjAK5.Add(_0023_003DzNSxy50o_003D.Groups[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602422)].Value);
			return string.Empty;
		}
	}

	private struct _0023_003DzSghSVvc_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzVY08dPp_0024xLC_zE_00240nGkTNB3IAXmw _0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D;

		public readonly _0023_003DzVY08dPp_0024xLC_zE_00240nGkTNB3IAXmw _0023_003Dz_CUuhJU_003D()
		{
			return _0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D;
		}

		public void _0023_003Dzq1RAjF4_003D(_0023_003DzVY08dPp_0024xLC_zE_00240nGkTNB3IAXmw _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		public readonly string _0023_003DzE5r8YUs_003D()
		{
			return _0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D;
		}

		public void _0023_003Dzxuq_ufc_003D(string _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz0CfEix0xAK9hoK7BNg_003D_003D = _0023_003DzsLHxXyo_003D;
		}
	}

	private string _0023_003Dz76ZQ5LY_003D;

	private HashSet<string> _0023_003DznfOsuUeAnfhVpmzSpw_003D_003D = new HashSet<string>();

	private HashSet<string> _0023_003DzzQrFpj85lULFneJyog_003D_003D = new HashSet<string>();

	private HashSet<string> _0023_003DzID3o4iwQnG14y9sOuw_003D_003D = new HashSet<string>();

	private string _0023_003DzKwWywyGlu51H_NPUhw_003D_003D;

	private string _0023_003DzsztYRIlToo5X;

	private string _0023_003DzfSSw_pniXlRZ;

	private ShaderParameters _0023_003DziZ4Ix4lcekJL;

	private List<_0023_003DzSghSVvc_003D> _0023_003Dz31ZydLXZfcGE = new List<_0023_003DzSghSVvc_003D>();

	public _0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o(OglRenderContext _0023_003DzmNZD0Zs_003D = null)
	{
		_0023_003DziZ4Ix4lcekJL = new ShaderParameters(_0023_003DzmNZD0Zs_003D);
	}

	public _0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o(OglRenderContext _0023_003DzmNZD0Zs_003D, _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzWFEd6nzQJyMe)
	{
		_0023_003DziZ4Ix4lcekJL = new ShaderParameters(_0023_003DzmNZD0Zs_003D)
		{
			Lighting = _0023_003DzWFEd6nzQJyMe.Lighting,
			Multicolor = _0023_003DzWFEd6nzQJyMe._0023_003DzGJ_Tn_0024EAKXCXFLh_HbhyHU0_003D(),
			ShadowMode = _0023_003DzWFEd6nzQJyMe._0023_003DzCjUlAcTjqEDL(),
			ColorsModulatedByIntensity = _0023_003DzWFEd6nzQJyMe._0023_003DzVN1nvI3DqMA2dnttRXyWjCqYCGK76SA33A_003D_003D(),
			AlphaMap = _0023_003DzWFEd6nzQJyMe._0023_003Dz5QEgmA1bHJlJ(),
			TextureEnvironment = _0023_003DzWFEd6nzQJyMe._0023_003DzA0wWpuFALvSD(),
			TextureOverExposure = _0023_003DzWFEd6nzQJyMe._0023_003DzdgD2ty_bamaCCChq6bLWIT5ciZew(),
			Background = new BackgroundSettings
			{
				StyleMode = _0023_003DzWFEd6nzQJyMe._0023_003DzEZgLHYAPuuUJ()
			}
		};
		_0023_003DzKwWywyGlu51H_NPUhw_003D_003D = _0023_003DzhXGR6Kw_003D(_0023_003DzWODUWW4_003D(_0023_003DzWFEd6nzQJyMe.vertexCode), _0023_003DznfOsuUeAnfhVpmzSpw_003D_003D);
		_0023_003DzsztYRIlToo5X = _0023_003DzhXGR6Kw_003D(_0023_003DzWODUWW4_003D(_0023_003DzWFEd6nzQJyMe.fragmentCode), _0023_003DzzQrFpj85lULFneJyog_003D_003D);
		_0023_003DzfSSw_pniXlRZ = _0023_003DzhXGR6Kw_003D(_0023_003DzWODUWW4_003D(_0023_003DzWFEd6nzQJyMe.geometryCode), _0023_003DzID3o4iwQnG14y9sOuw_003D_003D);
	}

	private string _0023_003Dz99DM_r_wJuV2(byte[] _0023_003DzoGWN5VA_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzoGWN5VA_003D);
		try
		{
			StreamReader streamReader = new StreamReader(memoryStream);
			try
			{
				return _0023_003DzWODUWW4_003D(_0023_003DzI2tE0CuQGPGs(streamReader.ReadToEnd()));
			}
			finally
			{
				((IDisposable)streamReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private string _0023_003DzhXGR6Kw_003D(string _0023_003DzGLZ7VmE_003D, HashSet<string> _0023_003DzJULyN5iyjAK5)
	{
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2 = new _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D();
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzJULyN5iyjAK5 = _0023_003DzJULyN5iyjAK5;
		_0023_003DzGLZ7VmE_003D = new Regex(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602436)).Replace(_0023_003DzGLZ7VmE_003D, _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003Dzf_DWEDpb3d3O8tBouw_003D_003D);
		return _0023_003DzGLZ7VmE_003D;
	}

	private string _0023_003DzWODUWW4_003D(string _0023_003DzGLZ7VmE_003D)
	{
		_0023_003DzGLZ7VmE_003D = new Regex(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602753)).Replace(_0023_003DzGLZ7VmE_003D, _0023_003DzdIHgepQ_003D);
		return _0023_003DzGLZ7VmE_003D;
	}

	public string _0023_003DzdIHgepQ_003D(Match _0023_003DzNSxy50o_003D)
	{
		string value = _0023_003DzNSxy50o_003D.Groups[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602803)].Value;
		if (_0023_003Dz76ZQ5LY_003D != null && _0023_003Dz76ZQ5LY_003D != value)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602821));
		}
		_0023_003Dz76ZQ5LY_003D = value;
		return string.Empty;
	}

	private string _0023_003DzI2tE0CuQGPGs(string _0023_003DzGLZ7VmE_003D)
	{
		_0023_003DzGLZ7VmE_003D = new Regex(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602654)).Replace(_0023_003DzGLZ7VmE_003D, delegate(Match _0023_003DzNSxy50o_003D)
		{
			string value = _0023_003DzNSxy50o_003D.Groups[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602676)].Value;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(value);
			if (fileNameWithoutExtension.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602693)))
			{
				return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602713) + value;
			}
			object obj = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYu3sZE9FUelB().GetObject(fileNameWithoutExtension);
			if (obj == null)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602726));
			}
			return _0023_003Dz99DM_r_wJuV2((byte[])obj);
		});
		return _0023_003DzGLZ7VmE_003D;
	}

	public string _0023_003DzwvqCQfhEumE_0024(Match _0023_003DzNSxy50o_003D)
	{
		string value = _0023_003DzNSxy50o_003D.Groups[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602676)].Value;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(value);
		if (fileNameWithoutExtension.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602693)))
		{
			return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602713) + value;
		}
		object obj = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzYu3sZE9FUelB().GetObject(fileNameWithoutExtension);
		if (obj == null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602726));
		}
		return _0023_003Dz99DM_r_wJuV2((byte[])obj);
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzfwY11io_003D(byte[] _0023_003DzH_00245CVxUqi4x6eR0sgQ_003D_003D, byte[] _0023_003DzhRsOXg6xNt5N, byte[] _0023_003Dz_vlAVbtJHwte)
	{
		if (_0023_003DzH_00245CVxUqi4x6eR0sgQ_003D_003D != null)
		{
			_0023_003DzKwWywyGlu51H_NPUhw_003D_003D = _0023_003Dz99DM_r_wJuV2(_0023_003DzH_00245CVxUqi4x6eR0sgQ_003D_003D);
		}
		if (_0023_003DzhRsOXg6xNt5N != null)
		{
			_0023_003DzsztYRIlToo5X = _0023_003Dz99DM_r_wJuV2(_0023_003DzhRsOXg6xNt5N);
		}
		if (_0023_003Dz_vlAVbtJHwte != null)
		{
			_0023_003DzfSSw_pniXlRZ = _0023_003Dz99DM_r_wJuV2(_0023_003Dz_vlAVbtJHwte);
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzXw1OC4M_Susv(string _0023_003DzJAPulHh_0024ZCQm, string _0023_003DzA6IZ0w8jCOst, bool _0023_003DzDtXVHeT2L0fZ, bool _0023_003DzVFxDO4Q_003D, bool _0023_003DzRvwMBy0_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003DzJAPulHh_0024ZCQm) && !string.IsNullOrEmpty(_0023_003DzA6IZ0w8jCOst))
		{
			string item = _0023_003DzJAPulHh_0024ZCQm + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338) + _0023_003DzA6IZ0w8jCOst;
			if (_0023_003DzDtXVHeT2L0fZ)
			{
				_0023_003DznfOsuUeAnfhVpmzSpw_003D_003D.Add(item);
			}
			if (_0023_003DzVFxDO4Q_003D)
			{
				_0023_003DzzQrFpj85lULFneJyog_003D_003D.Add(item);
			}
			if (_0023_003DzRvwMBy0_003D)
			{
				_0023_003DzID3o4iwQnG14y9sOuw_003D_003D.Add(item);
			}
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003Dz1ddwdKX3_E2Z(string _0023_003Dz4ijVb6S6Y_0024bf, bool _0023_003DzDtXVHeT2L0fZ, bool _0023_003DzVFxDO4Q_003D, bool _0023_003DzRvwMBy0_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dz4ijVb6S6Y_0024bf))
		{
			if (_0023_003DzDtXVHeT2L0fZ)
			{
				_0023_003DznfOsuUeAnfhVpmzSpw_003D_003D.Add(_0023_003Dz4ijVb6S6Y_0024bf);
			}
			if (_0023_003DzVFxDO4Q_003D)
			{
				_0023_003DzzQrFpj85lULFneJyog_003D_003D.Add(_0023_003Dz4ijVb6S6Y_0024bf);
			}
			if (_0023_003DzRvwMBy0_003D)
			{
				_0023_003DzID3o4iwQnG14y9sOuw_003D_003D.Add(_0023_003Dz4ijVb6S6Y_0024bf);
			}
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzwDicxufX3sjj(string[] _0023_003DzQlQ3qLG8zWrX, bool _0023_003DzDtXVHeT2L0fZ, bool _0023_003DzVFxDO4Q_003D, bool _0023_003DzRvwMBy0_003D)
	{
		foreach (string _0023_003Dz4ijVb6S6Y_0024bf in _0023_003DzQlQ3qLG8zWrX)
		{
			_0023_003Dz1ddwdKX3_E2Z(_0023_003Dz4ijVb6S6Y_0024bf, _0023_003DzDtXVHeT2L0fZ, _0023_003DzVFxDO4Q_003D, _0023_003DzRvwMBy0_003D);
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003Dzh7zNW_66FLsv(string _0023_003Dz4ijVb6S6Y_0024bf, bool _0023_003DzDtXVHeT2L0fZ, bool _0023_003DzVFxDO4Q_003D, bool _0023_003DzRvwMBy0_003D)
	{
		if (_0023_003DzDtXVHeT2L0fZ && _0023_003DznfOsuUeAnfhVpmzSpw_003D_003D.Contains(_0023_003Dz4ijVb6S6Y_0024bf))
		{
			_0023_003DznfOsuUeAnfhVpmzSpw_003D_003D.Remove(_0023_003Dz4ijVb6S6Y_0024bf);
		}
		if (_0023_003DzVFxDO4Q_003D && _0023_003DzzQrFpj85lULFneJyog_003D_003D.Contains(_0023_003Dz4ijVb6S6Y_0024bf))
		{
			_0023_003DzzQrFpj85lULFneJyog_003D_003D.Remove(_0023_003Dz4ijVb6S6Y_0024bf);
		}
		if (_0023_003DzRvwMBy0_003D && _0023_003DzID3o4iwQnG14y9sOuw_003D_003D.Contains(_0023_003Dz4ijVb6S6Y_0024bf))
		{
			_0023_003DzID3o4iwQnG14y9sOuw_003D_003D.Remove(_0023_003Dz4ijVb6S6Y_0024bf);
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzhNRfEHIyuxe1(string[] _0023_003DzQlQ3qLG8zWrX, bool _0023_003DzDtXVHeT2L0fZ, bool _0023_003DzVFxDO4Q_003D, bool _0023_003DzRvwMBy0_003D)
	{
		foreach (string _0023_003Dz4ijVb6S6Y_0024bf in _0023_003DzQlQ3qLG8zWrX)
		{
			_0023_003Dzh7zNW_66FLsv(_0023_003Dz4ijVb6S6Y_0024bf, _0023_003DzDtXVHeT2L0fZ, _0023_003DzVFxDO4Q_003D, _0023_003DzRvwMBy0_003D);
		}
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzkCWmFuLh323G(_0023_003DzVY08dPp_0024xLC_zE_00240nGkTNB3IAXmw _0023_003DzhklmJFQ_003D, string _0023_003Dz0HnJkWm8N4AD5PqOnA_003D_003D)
	{
		List<_0023_003DzSghSVvc_003D> list = _0023_003Dz31ZydLXZfcGE;
		_0023_003DzSghSVvc_003D item = default(_0023_003DzSghSVvc_003D);
		item._0023_003Dzq1RAjF4_003D(_0023_003DzhklmJFQ_003D);
		item._0023_003Dzxuq_ufc_003D(_0023_003Dz0HnJkWm8N4AD5PqOnA_003D_003D);
		list.Add(item);
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003Dz0sjiFr1qEVW_NIYOITr1JBw_003D(bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D)
	{
		_0023_003DziZ4Ix4lcekJL.Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003Dzn4ocQiJMJ_koYqPzD6yjqm4_003D(bool _0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D)
	{
		_0023_003DziZ4Ix4lcekJL.Multicolor = _0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzmIJrH9oyspyVkfhALQ_003D_003D(shadowType _0023_003DzknwPvth7T6DE)
	{
		_0023_003DziZ4Ix4lcekJL.ShadowMode = _0023_003DzknwPvth7T6DE;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003Dz6T6SGzyLIcmoG1Fpk5oLbqez7d6xtlV1wQgPfCI_003D(bool _0023_003DzUzAVfXobhl6ZcwqSj359vZlPnQLdzkkBQ2kC_IQ_003D)
	{
		_0023_003DziZ4Ix4lcekJL.ColorsModulatedByIntensity = _0023_003DzUzAVfXobhl6ZcwqSj359vZlPnQLdzkkBQ2kC_IQ_003D;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzNlxQpuFW3t1sKU40_g_003D_003D(bool _0023_003DzxAshdwOYgM5J)
	{
		_0023_003DziZ4Ix4lcekJL.AlphaMap = _0023_003DzxAshdwOYgM5J;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DziMn5o2lqAxolhuYB9Q_003D_003D(textureEnvironmentType _0023_003Dz0KvOmLFGDMfX)
	{
		_0023_003DziZ4Ix4lcekJL.TextureEnvironment = _0023_003Dz0KvOmLFGDMfX;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzHUyQn20UFO3TFog1WKP_kBfPzAHU(bool _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D)
	{
		_0023_003DziZ4Ix4lcekJL.TextureOverExposure = _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D;
		return this;
	}

	public global::_0023_003DzTOzW22cxgx0rHZcEvkKj4P0p802o<_0023_003DzWoS2eJk_003D> _0023_003DzS32mBs5DphkeAh2HzQ_003D_003D(IBackgroundSettings _0023_003Dz2bwAPoQwFwzX)
	{
		_0023_003DziZ4Ix4lcekJL.Background = _0023_003Dz2bwAPoQwFwzX;
		return this;
	}

	private string _0023_003DzFQnygoIqE_00245q(HashSet<string> _0023_003DzQlQ3qLG8zWrX, List<_0023_003DzSghSVvc_003D> _0023_003DzVlP_0024teIwcCrIJvIX_g_003D_003D, string _0023_003Dzlkeu5a_0024G3zlW)
	{
		if (string.IsNullOrWhiteSpace(_0023_003Dzlkeu5a_0024G3zlW))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(_0023_003Dz76ZQ5LY_003D))
		{
			stringBuilder.AppendLine(_0023_003Dz76ZQ5LY_003D);
			stringBuilder.AppendLine();
		}
		foreach (string item in _0023_003DzQlQ3qLG8zWrX)
		{
			stringBuilder.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604032) + item);
		}
		if (_0023_003DzQlQ3qLG8zWrX.Count > 0)
		{
			stringBuilder.AppendLine();
		}
		if (_0023_003DzVlP_0024teIwcCrIJvIX_g_003D_003D != null)
		{
			for (int i = 0; i < _0023_003DzVlP_0024teIwcCrIJvIX_g_003D_003D.Count; i++)
			{
				_0023_003DzSghSVvc_003D _0023_003DzSghSVvc_003D2 = _0023_003DzVlP_0024teIwcCrIJvIX_g_003D_003D[i];
				stringBuilder.AppendLine(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604049), i, _0023_003DzSghSVvc_003D2._0023_003Dz_CUuhJU_003D(), _0023_003DzSghSVvc_003D2._0023_003DzE5r8YUs_003D()));
			}
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine(_0023_003Dzlkeu5a_0024G3zlW);
		return stringBuilder.ToString();
	}

	public _0023_003DzWoS2eJk_003D _0023_003DzwIVeLsk_003D()
	{
		string vertexCode = _0023_003DzFQnygoIqE_00245q(_0023_003DznfOsuUeAnfhVpmzSpw_003D_003D, _0023_003Dz31ZydLXZfcGE, _0023_003DzKwWywyGlu51H_NPUhw_003D_003D);
		string fragmentCode = _0023_003DzFQnygoIqE_00245q(_0023_003DzzQrFpj85lULFneJyog_003D_003D, null, _0023_003DzsztYRIlToo5X);
		string geometryCode = _0023_003DzFQnygoIqE_00245q(_0023_003DzID3o4iwQnG14y9sOuw_003D_003D, null, _0023_003DzfSSw_pniXlRZ);
		_0023_003DzWoS2eJk_003D obj = new _0023_003DzWoS2eJk_003D
		{
			vertexCode = vertexCode,
			fragmentCode = fragmentCode,
			geometryCode = geometryCode
		};
		if (obj is _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2)
		{
			_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2._0023_003DzUMSSRSw_003D(_0023_003DziZ4Ix4lcekJL);
		}
		return obj;
	}
}
