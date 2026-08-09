using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using OpenGL;

namespace devDept.Graphics;

public class OGLEntityBuffer : IDisposable
{
	internal struct _0023_003DzfWJA13KyF5kq
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D;

		public _0023_003DzfWJA13KyF5kq()
			: this(3)
		{
		}

		public _0023_003DzfWJA13KyF5kq(int _0023_003Dz0ERMHbg_003D, int _0023_003DzhklmJFQ_003D = 5126)
		{
			_0023_003DzYcnVJ_00240_003D(_0023_003Dz0ERMHbg_003D);
			_0023_003Dzq1RAjF4_003D(_0023_003DzhklmJFQ_003D);
		}

		public readonly int _0023_003DzL2jAKGI_003D()
		{
			return _0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D;
		}

		private void _0023_003DzYcnVJ_00240_003D(int _0023_003DzsLHxXyo_003D)
		{
			_0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		public readonly int _0023_003Dz_CUuhJU_003D()
		{
			return _0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D;
		}

		private void _0023_003Dzq1RAjF4_003D(int _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz_tCK3pkthC8AJ6DdHg_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		public override string ToString()
		{
			return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609158), _0023_003DzL2jAKGI_003D(), _0023_003Dz_CUuhJU_003D());
		}
	}

	[DefaultMember("Item")]
	internal struct _0023_003DzvOg1ehyRaBmw
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzfWJA13KyF5kq[] _0023_003Dz_0024AE2Y_s_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IntPtr[] _0023_003Dz15L3YLsynFxahkMFuw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;

		public _0023_003DzvOg1ehyRaBmw(params _0023_003DzfWJA13KyF5kq[] _0023_003DzzNEWOmE_003D)
		{
			_0023_003Dz15L3YLsynFxahkMFuw_003D_003D = null;
			_0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D = 0;
			_0023_003Dz_0024AE2Y_s_003D = _0023_003DzzNEWOmE_003D;
			_0023_003DzXkFkuX_0024T7lH9();
		}

		public _0023_003DzvOg1ehyRaBmw(int _0023_003DzwElSrB0KT3wi)
		{
			_0023_003Dz15L3YLsynFxahkMFuw_003D_003D = null;
			_0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D = 0;
			switch (_0023_003DzwElSrB0KT3wi)
			{
			case 3:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[1]
				{
					new _0023_003DzfWJA13KyF5kq()
				};
				break;
			case 4:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[2]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(1)
				};
				break;
			case 6:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[2]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq()
				};
				break;
			case 7:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[2]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(4)
				};
				break;
			case 8:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[3]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(2)
				};
				break;
			case 9:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[3]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq()
				};
				break;
			case 10:
				_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzfWJA13KyF5kq[3]
				{
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(),
					new _0023_003DzfWJA13KyF5kq(4)
				};
				break;
			default:
				throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603707));
			}
			_0023_003DzXkFkuX_0024T7lH9();
		}

		public _0023_003DzfWJA13KyF5kq _0023_003DzEUTT7_0024c_003D(int _0023_003DzSordH9w_003D)
		{
			return _0023_003Dz_0024AE2Y_s_003D[_0023_003DzSordH9w_003D];
		}

		public int _0023_003DzIotLfKlF8dGb()
		{
			return _0023_003Dz_0024AE2Y_s_003D.Length;
		}

		public readonly int _0023_003DzXeW6cikb01JX()
		{
			return _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;
		}

		private void _0023_003DzIaOBTwcZYZsO(int _0023_003DzsLHxXyo_003D)
		{
			_0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D = _0023_003DzsLHxXyo_003D;
		}

		private int _0023_003Dzeast84JWI0qB(int _0023_003DzhklmJFQ_003D)
		{
			switch (_0023_003DzhklmJFQ_003D)
			{
			case 5126:
				return 4;
			case 5120:
			case 5121:
				return 1;
			case 5122:
				return 2;
			case 5123:
				return 2;
			case 5124:
				return 4;
			case 5125:
				return 4;
			default:
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603758));
			}
		}

		private void _0023_003DzXkFkuX_0024T7lH9()
		{
			_0023_003Dz15L3YLsynFxahkMFuw_003D_003D = new IntPtr[_0023_003Dz_0024AE2Y_s_003D.Length];
			int num = 0;
			for (int i = 0; i < _0023_003Dz_0024AE2Y_s_003D.Length; i++)
			{
				_0023_003DzfWJA13KyF5kq _0023_003DzfWJA13KyF5kq2 = _0023_003Dz_0024AE2Y_s_003D[i];
				_0023_003Dz15L3YLsynFxahkMFuw_003D_003D[i] = (IntPtr)num;
				num += _0023_003DzfWJA13KyF5kq2._0023_003DzL2jAKGI_003D() * _0023_003Dzeast84JWI0qB(_0023_003DzfWJA13KyF5kq2._0023_003Dz_CUuhJU_003D());
			}
			_0023_003DzIaOBTwcZYZsO(num);
		}

		public IntPtr _0023_003DzjtWKfUXgg_0024Xr(int _0023_003DzSordH9w_003D)
		{
			return _0023_003Dz15L3YLsynFxahkMFuw_003D_003D[_0023_003DzSordH9w_003D];
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DztcxMNNjxBFu6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzFrThlsECtjr503rdhpAOQ5c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D;

	protected List<int> VertexBuffer;

	protected List<int> IndexBuffer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<vertexBufferData> _0023_003Dzz8j8G7g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<List<int>> _0023_003DzVQdby4Uk73jo52ylew_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<List<float>> _0023_003Dz6ym_OKwKktrt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int[] _0023_003DzE5oFKs4_003D;

	protected bool _resetLayout = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzvOg1ehyRaBmw? _0023_003Dz_0024AE2Y_s_003D;

	public int currPartToDraw
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D = value;
		}
	}

	public int Stride
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D = value;
		}
	}

	protected int FloatPerVertex
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFrThlsECtjr503rdhpAOQ5c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFrThlsECtjr503rdhpAOQ5c_003D = value;
		}
	}

	protected int MaxVerticesForChunk
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D;
		}
	}

	public OGLEntityBuffer()
	{
		_0023_003Dzz8j8G7g_003D = new List<vertexBufferData>();
	}

	public OGLEntityBuffer(int maxVertexBufferSize, float[] data, int[] indices, primitiveType topology, int nVertices)
		: this()
	{
		_0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		if (indices != null && indices.Length != 0)
		{
			_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
		}
		_0023_003DzgWaA5Nc_003D(maxVertexBufferSize, data, indices, topology, nVertices, (indices != null) ? indices.Length : 0, _0023_003Dzp_0024qFwgs_003D: true);
		Create(_0023_003Dz6ym_OKwKktrt, _0023_003DzVQdby4Uk73jo52ylew_003D_003D);
		_0023_003Dz6ym_OKwKktrt = null;
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
	}

	public void Dispose()
	{
		if (VertexBuffer != null)
		{
			gl.DeleteBuffersARB(VertexBuffer.ToArray());
			VertexBuffer = null;
		}
		if (IndexBuffer != null)
		{
			gl.DeleteBuffersARB(IndexBuffer.ToArray());
			IndexBuffer = null;
		}
		if (_0023_003DzE5oFKs4_003D != null)
		{
			gl.DeleteVertexArrays(_0023_003DzE5oFKs4_003D);
			_0023_003DzE5oFKs4_003D = null;
		}
	}

	public void Draw(RenderContextBase renderContext, bool nextPart)
	{
		if (nextPart)
		{
			Draw((OglRenderContext)renderContext, currPartToDraw + 1);
		}
		else
		{
			Draw((OglRenderContext)renderContext, currPartToDraw);
		}
	}

	public void Draw(RenderContextBase renderContext, int part)
	{
		Draw((OglRenderContext)renderContext, part);
	}

	public virtual void Draw(OglRenderContext renderContext, int part, uint? indexOffset = null, uint? indexCount = null)
	{
		if (_0023_003Dzz8j8G7g_003D.Count == 0)
		{
			return;
		}
		renderContext.UpdateConstantBufferPerObject();
		currPartToDraw = part;
		vertexBufferData vertexBufferData2 = _0023_003Dzz8j8G7g_003D[part];
		for (int i = vertexBufferData2.firstChunk; i <= vertexBufferData2.lastChunk; i++)
		{
			gl.BindVertexArrays_(_0023_003DzE5oFKs4_003D[i]);
			if (IndexBuffer != null && vertexBufferData2.startIndex >= 0)
			{
				bool flag = indexCount.HasValue && indexOffset.HasValue;
				gl.DrawElementsBaseVertex(vertexBufferData2._0023_003DzDX_IlROkgDgt()._0023_003DzbCW6hty7CJbs(), flag ? ((int)indexCount.Value) : vertexBufferData2.nElementsPerChunk[0], 5125, (flag ? ((int)indexOffset.Value) : vertexBufferData2.startIndex) * 4, vertexBufferData2.startVertex);
			}
			else
			{
				gl.DrawArrays(vertexBufferData2._0023_003DzDX_IlROkgDgt()._0023_003DzbCW6hty7CJbs(), (i == 0) ? vertexBufferData2.startVertex : 0, vertexBufferData2.nElementsPerChunk[i]);
			}
		}
		gl.BindVertexArrays_(0);
	}

	public void Draw(OglRenderContext renderContext)
	{
		Draw(renderContext, 0);
	}

	private void _0023_003DzK07cR4sQBofVr2yb5_YNFgY_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	protected void Create(List<List<float>> data, List<List<int>> indices, bool forceBuffersCreation = true)
	{
		if (data.Count == 0)
		{
			return;
		}
		bool flag = forceBuffersCreation || VertexBuffer == null || data.Count != VertexBuffer.Count;
		int num = data.Count;
		if (flag)
		{
			VertexBuffer = new List<int>(data.Count);
		}
		if (indices != null && indices.Count > 0)
		{
			num += indices.Count;
			if (flag)
			{
				IndexBuffer = new List<int>(indices.Count);
			}
		}
		if (flag)
		{
			int[] array = new int[num];
			gl.GenBuffersARB(num, array);
			int num2 = 0;
			int num3 = 0;
			while (num3 < data.Count)
			{
				VertexBuffer.Add(array[num2]);
				num3++;
				num2++;
			}
			if (indices != null)
			{
				int num4 = 0;
				while (num4 < indices.Count)
				{
					IndexBuffer.Add(array[num2]);
					num4++;
					num2++;
				}
			}
		}
		if (_0023_003DzE5oFKs4_003D == null)
		{
			_0023_003DzE5oFKs4_003D = new int[data.Count];
			gl.GenVertexArrays(data.Count, _0023_003DzE5oFKs4_003D);
		}
		else if (_0023_003DzE5oFKs4_003D.Length != data.Count)
		{
			gl.DeleteVertexArrays(_0023_003DzE5oFKs4_003D);
			_0023_003DzE5oFKs4_003D = new int[data.Count];
			gl.GenVertexArrays(data.Count, _0023_003DzE5oFKs4_003D);
		}
		for (int i = 0; i < data.Count; i++)
		{
			gl.BindVertexArrays_(_0023_003DzE5oFKs4_003D[i]);
			float[] array2 = data[i].ToArray();
			gl.BindBufferARB(34962, VertexBuffer[i]);
			gl.BufferData(34962, array2.Length * 4, array2, 35044);
			if (indices != null && indices.Count > 0 && indices[i] != null && indices[i].Count > 0)
			{
				int[] array3 = indices[i].ToArray();
				gl.BindBufferARB(34963, IndexBuffer[i]);
				gl.BufferData(34963, array3.Length * 4, array3, 35044);
			}
			_0023_003DzWhbM6r2Mqaf3();
		}
		gl.BindVertexArrays_(0);
	}

	private void _0023_003DzWhbM6r2Mqaf3()
	{
		if (!_0023_003Dz_0024AE2Y_s_003D.HasValue)
		{
			_0023_003Dz_0024AE2Y_s_003D = new _0023_003DzvOg1ehyRaBmw(FloatPerVertex);
		}
		_0023_003DzvOg1ehyRaBmw value = _0023_003Dz_0024AE2Y_s_003D.Value;
		for (int i = 0; i < value._0023_003DzIotLfKlF8dGb(); i++)
		{
			_0023_003DzfWJA13KyF5kq _0023_003DzfWJA13KyF5kq2 = value._0023_003DzEUTT7_0024c_003D(i);
			gl.EnableVertexAttribArrayARB(i);
			gl.VertexAttribPointerARB(i, _0023_003DzfWJA13KyF5kq2._0023_003DzL2jAKGI_003D(), _0023_003DzfWJA13KyF5kq2._0023_003Dz_CUuhJU_003D(), normalized: false, _0023_003Dz_0024AE2Y_s_003D.Value._0023_003DzXeW6cikb01JX(), _0023_003Dz_0024AE2Y_s_003D.Value._0023_003DzjtWKfUXgg_0024Xr(i));
		}
		if (_resetLayout)
		{
			_0023_003Dz_0024AE2Y_s_003D = null;
		}
	}

	internal void _0023_003DzrloDkpQ_003D()
	{
		Create(_0023_003Dz6ym_OKwKktrt, _0023_003DzVQdby4Uk73jo52ylew_003D_003D);
		_0023_003Dz6ym_OKwKktrt = null;
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
	}

	internal void _0023_003DzXkFkuX_0024T7lH9(int _0023_003DzWPCO3aE_003D, int _0023_003Dz0VB11flmJi_0024i, int _0023_003DzRbrcOgQ_003D)
	{
		Stride = _0023_003DzXkFkuX_0024T7lH9(_0023_003Dz0VB11flmJi_0024i, _0023_003DzRbrcOgQ_003D);
		FloatPerVertex = Stride / 4;
		_0023_003DzK07cR4sQBofVr2yb5_YNFgY_003D(_0023_003DzWPCO3aE_003D / FloatPerVertex);
	}

	private static int _0023_003DzXkFkuX_0024T7lH9(int _0023_003Dz0VB11flmJi_0024i, int _0023_003DzRbrcOgQ_003D)
	{
		return _0023_003Dz0VB11flmJi_0024i / _0023_003DzRbrcOgQ_003D * 4;
	}

	internal void _0023_003DzgWaA5Nc_003D(int _0023_003DzHXE4tItuJJ_U, float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003Dzp_0024qFwgs_003D)
	{
		if (_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length == 0)
		{
			return;
		}
		if (_0023_003Dz6ym_OKwKktrt.Count == 0)
		{
			_0023_003DzXkFkuX_0024T7lH9(_0023_003DzHXE4tItuJJ_U, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D);
			_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D = 0;
			if (_0023_003Dzz8j8G7g_003D.Count > 0)
			{
				int index = _0023_003Dzz8j8G7g_003D.Count - 1;
				vertexBufferData obj = _0023_003Dzz8j8G7g_003D[index];
				obj._0023_003Dz_002475wn_0024QGlEFt(_0023_003DzQZ1JmC0_003D);
				obj.startIndex = ((_0023_003Dzdo7ctlc_003D == null) ? (-1) : 0);
			}
			_0023_003Dz6ym_OKwKktrt.Add(new List<float>());
		}
		int num = _0023_003Dz6ym_OKwKktrt.Count - 1;
		if (_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D < MaxVerticesForChunk || _0023_003Dzdo7ctlc_003D != null)
		{
			int _0023_003DzivjwkyA_003D = _0023_003DzHT7laFFWe738(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, num, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
			_0023_003DzhBa6N7vF9w1t(num, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D, _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D, _0023_003DzivjwkyA_003D);
		}
		else
		{
			SplitInChunks(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D, num);
		}
	}

	protected void SplitInChunks(float[] vertices, int[] indices, primitiveType topology, int nVertices, int nIndices, bool newPart, int currChunk)
	{
		int num = nVertices - _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;
		int num2 = Math.Min(MaxVerticesForChunk, nVertices);
		int _0023_003Dz7OF_4JtEUKui = _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;
		int num3 = 0;
		while (num2 > 0)
		{
			if (nIndices == 0)
			{
				switch (topology)
				{
				case primitiveType.LineList:
					if (num2 % 2 == 1)
					{
						num2--;
					}
					break;
				case primitiveType.TriangleList:
					num2 -= num2 % 3;
					break;
				case primitiveType.TriangleStrip:
					if (num2 < 3)
					{
						num2 = 0;
					}
					break;
				}
				if (num2 == 0)
				{
					break;
				}
			}
			if (currChunk >= _0023_003Dz6ym_OKwKktrt.Count)
			{
				_0023_003Dz6ym_OKwKktrt.Add(new List<float>());
				_0023_003Dz7OF_4JtEUKui = 0;
			}
			int num4 = num2 * FloatPerVertex;
			int _0023_003DzivjwkyA_003D = _0023_003DzHT7laFFWe738(vertices, indices, currChunk, num3, num4);
			_0023_003DzhBa6N7vF9w1t(currChunk, topology, num2, nIndices, newPart, _0023_003Dz7OF_4JtEUKui, _0023_003DzivjwkyA_003D);
			currChunk++;
			if (newPart)
			{
				newPart = false;
			}
			num3 += num4;
			num -= num2;
			num2 = Math.Min(num, MaxVerticesForChunk);
			if (nIndices > 0)
			{
				break;
			}
		}
	}

	private int _0023_003DzHT7laFFWe738(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, int _0023_003Dz_0024Hi2ziW1e3rR, int _0023_003Dzgzqb1hl60HQU, int _0023_003Dz8UEy_0024xy_F4JX)
	{
		int num = _0023_003Dzgzqb1hl60HQU + _0023_003Dz8UEy_0024xy_F4JX;
		if (_0023_003Dzgzqb1hl60HQU == 0 && _0023_003Dz8UEy_0024xy_F4JX == _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length)
		{
			_0023_003Dz6ym_OKwKktrt[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D);
		}
		else
		{
			float[] array = new float[num - _0023_003Dzgzqb1hl60HQU];
			Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzgzqb1hl60HQU, array, 0, array.Length);
			_0023_003Dz6ym_OKwKktrt[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(array);
		}
		int result = -1;
		if (_0023_003Dzdo7ctlc_003D != null)
		{
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D == null)
			{
				_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
			}
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Count < _0023_003Dz_0024Hi2ziW1e3rR + 1)
			{
				_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Add(new List<int>());
			}
			result = _0023_003DzVQdby4Uk73jo52ylew_003D_003D[_0023_003Dz_0024Hi2ziW1e3rR].Count;
			_0023_003DzVQdby4Uk73jo52ylew_003D_003D[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(_0023_003Dzdo7ctlc_003D);
		}
		return result;
	}

	private void _0023_003DzhBa6N7vF9w1t(int _0023_003DzZdM3PQA_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003Dzp_0024qFwgs_003D, int _0023_003Dz7OF_4JtEUKui, int _0023_003DzivjwkyA_003D)
	{
		int num = ((_0023_003Dz4Im51Qk_003D == 0) ? _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D : _0023_003Dz4Im51Qk_003D);
		if (_0023_003Dzp_0024qFwgs_003D || _0023_003Dzz8j8G7g_003D.Count == 0)
		{
			vertexBufferData obj = new vertexBufferData();
			obj._0023_003Dz_002475wn_0024QGlEFt(_0023_003DzQZ1JmC0_003D);
			obj.startVertex = _0023_003Dz7OF_4JtEUKui;
			obj.startIndex = _0023_003DzivjwkyA_003D;
			vertexBufferData vertexBufferData2 = obj;
			vertexBufferData2.nElementsPerChunk.Add(num);
			_0023_003Dzz8j8G7g_003D.Add(vertexBufferData2);
		}
		else
		{
			vertexBufferData vertexBufferData3 = _0023_003Dzz8j8G7g_003D[_0023_003Dzz8j8G7g_003D.Count - 1];
			if (_0023_003DzZdM3PQA_003D > vertexBufferData3.lastChunk)
			{
				vertexBufferData3.lastChunk = _0023_003DzZdM3PQA_003D;
				vertexBufferData3.nElementsPerChunk.Add(num);
			}
			else
			{
				vertexBufferData3.nElementsPerChunk[vertexBufferData3.nElementsPerChunk.Count - 1] += num;
			}
		}
		_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D += _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D;
	}
}
