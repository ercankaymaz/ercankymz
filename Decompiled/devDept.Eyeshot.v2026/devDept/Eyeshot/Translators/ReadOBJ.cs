using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadOBJ : ReadFileAsync
{
	private sealed class _0023_003Dz7sLr1fMiCJis
	{
		public string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D;

		public List<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;

		public HashSet<int> _0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D;

		public HashSet<int> _0023_003DzZM_CIYWEw7yANTXyfA_003D_003D;

		public HashSet<int> _0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D;

		public Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D;

		public Color _0023_003Dzaa_0024mmAo_003D;

		public object _0023_003DzOqDotZs_003D;

		public _0023_003Dz7sLr1fMiCJis(string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D, int _0023_003DzNJ4Ismb2xHW7)
		{
			this._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D;
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new List<IndexTriangle>(_0023_003DzNJ4Ismb2xHW7);
			_0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D = new HashSet<int>();
			_0023_003DzZM_CIYWEw7yANTXyfA_003D_003D = new HashSet<int>();
			_0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D = new HashSet<int>();
			_0023_003Dzaa_0024mmAo_003D = Color.Beige;
		}
	}

	private sealed class _0023_003DzPD_Puf0_003D
	{
		public entityNatureType _0023_003DzL3kjwgWK1Hcy;

		public Mesh.edgeStyleType _0023_003DzzqOf1IF2wxNe;

		public object _0023_003DzOqDotZs_003D;

		public List<Mesh> _0023_003DzIIuKCj1NK1q5;

		public List<_0023_003Dz7sLr1fMiCJis> _0023_003DzqDQVyJdyH7eY;

		public _0023_003DzPD_Puf0_003D()
		{
			_0023_003DzIIuKCj1NK1q5 = new List<Mesh>();
			_0023_003DzqDQVyJdyH7eY = new List<_0023_003Dz7sLr1fMiCJis>();
		}

		public _0023_003Dz7sLr1fMiCJis _0023_003Dzmax8cT5_IKhs(string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D)
		{
			foreach (_0023_003Dz7sLr1fMiCJis item in _0023_003DzqDQVyJdyH7eY)
			{
				if (item._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D == _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D)
				{
					return item;
				}
			}
			return null;
		}

		public void _0023_003DzgLmLM40_003D(_0023_003Dz7sLr1fMiCJis _0023_003DzauU_W6_S0tjE)
		{
			if (_0023_003DzauU_W6_S0tjE != null)
			{
				_0023_003Dz7sLr1fMiCJis _0023_003Dz7sLr1fMiCJis2 = _0023_003Dzmax8cT5_IKhs(_0023_003DzauU_W6_S0tjE._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D);
				if (_0023_003Dz7sLr1fMiCJis2 != null)
				{
					_0023_003Dz7sLr1fMiCJis2._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.AddRange(_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
					_0023_003Dz7sLr1fMiCJis2._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D.UnionWith(_0023_003DzauU_W6_S0tjE._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D);
					_0023_003Dz7sLr1fMiCJis2._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D.UnionWith(_0023_003DzauU_W6_S0tjE._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D);
					_0023_003Dz7sLr1fMiCJis2._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D.UnionWith(_0023_003DzauU_W6_S0tjE._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D);
				}
				else if (_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count > 0)
				{
					_0023_003DzqDQVyJdyH7eY.Add(_0023_003DzauU_W6_S0tjE);
				}
			}
		}

		internal IEnumerable<Entity> _0023_003DzROQTjn5Yve4K(Document _0023_003DzoPlwCJA_003D, List<Point3D> _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, List<Vector3D> _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, List<PointF> _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D, Mesh.edgeStyleType _0023_003Dzp4s_iREqDk59, bool _0023_003Dz_0024_mpWHbeukqh, bool _0023_003Dzs5WRo8eBvjs90jFvmw_003D_003D)
		{
			List<Entity> list = new List<Entity>();
			TraversalParams data = new TraversalParams(_0023_003DzoPlwCJA_003D);
			foreach (_0023_003Dz7sLr1fMiCJis item in _0023_003DzqDQVyJdyH7eY)
			{
				if (item._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count == 0)
				{
					continue;
				}
				bool flag = _0023_003DzerPXTI59l6IWZMLwxA_003D_003D[item._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[0].V1] is PointRGB && string.IsNullOrEmpty(item._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D);
				Mesh.natureType natureType = ((item._0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D != Mesh.natureType.Undefined) ? item._0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D : ((!flag) ? ((_0023_003DzL3kjwgWK1Hcy == entityNatureType.Polygon) ? Mesh.natureType.Smooth : Mesh.natureType.RichSmooth) : Mesh.natureType.MulticolorSmooth));
				if (item._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count <= 0)
				{
					continue;
				}
				_0023_003DzhSzMHvbCt4ch _0023_003DzhSzMHvbCt4ch2 = (_0023_003DzhSzMHvbCt4ch)((item._0023_003DzOqDotZs_003D != null) ? item._0023_003DzOqDotZs_003D : _0023_003DzOqDotZs_003D);
				List<PointF> list2 = (_0023_003DzhSzMHvbCt4ch2._0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D ? _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D : null);
				List<Vector3D> _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D2 = (_0023_003DzhSzMHvbCt4ch2._0023_003DzYoy99to_BAZcMoB9Lg_003D_003D ? _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D : null);
				if (list2 == null || list2.Count == 0)
				{
					switch (natureType)
					{
					case Mesh.natureType.RichPlain:
						natureType = Mesh.natureType.Plain;
						break;
					case Mesh.natureType.RichSmooth:
						natureType = Mesh.natureType.Smooth;
						break;
					}
				}
				Mesh mesh = new Mesh(natureType);
				mesh.EdgeStyle = _0023_003Dzp4s_iREqDk59;
				mesh.Triangles = item._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.ToArray();
				mesh.MaterialName = item._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D;
				mesh._0023_003DzDzdRty4_003D(_0023_003DzerPXTI59l6IWZMLwxA_003D_003D, list2, _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D2, item._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D.Count, item._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D.Count, item._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D.Count);
				if (_0023_003Dzs5WRo8eBvjs90jFvmw_003D_003D)
				{
					mesh.Weld();
					mesh.UpdateNormals();
				}
				else if (!_0023_003DzhSzMHvbCt4ch2._0023_003DzYoy99to_BAZcMoB9Lg_003D_003D || _0023_003DzhSzMHvbCt4ch2._0023_003DzGuj5_7rbVAcbSd1tuQ_003D_003D)
				{
					mesh.UpdateNormals();
				}
				mesh.ComputeEdges();
				mesh.RegenMode = regenType.CompileOnly;
				mesh.UpdateBoundingBox(data);
				mesh.TranslationID = new TranslationIdentifier(_0023_003DzhSzMHvbCt4ch2._0023_003Dz2tLFTBU_003D);
				if (!_0023_003Dz_0024_mpWHbeukqh)
				{
					mesh.ColorMethod = colorMethodType.byEntity;
				}
				if (!flag && !string.IsNullOrEmpty(item._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D))
				{
					mesh.Color = item._0023_003Dzaa_0024mmAo_003D;
					mesh.MaterialName = item._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D;
				}
				list.Add(mesh);
			}
			return list;
		}
	}

	private sealed class _0023_003DzhSzMHvbCt4ch : ICloneable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly string _0023_003Dz2tLFTBU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzb8fU8pCQeU_0024N;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzwYpqy2PFYeuP = -1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<int> _0023_003Dz2IFGCrg7oQk4rDll53vHpGI_003D = new List<int>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<int> _0023_003DzLDPkY6mM_0024WD7cOh05rShrLs_003D = new List<int>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<int> _0023_003DzMbxrlBQVi0Rge9Wsjw_003D_003D = new List<int>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzGuj5_7rbVAcbSd1tuQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzYoy99to_BAZcMoB9Lg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = -1;

		public _0023_003DzhSzMHvbCt4ch(string _0023_003DzS_00246o7tc_003D)
		{
			_0023_003Dz2tLFTBU_003D = _0023_003DzS_00246o7tc_003D;
		}

		public _0023_003DzhSzMHvbCt4ch(_0023_003DzhSzMHvbCt4ch _0023_003DzySgeilxprQOK)
		{
			_0023_003Dz2tLFTBU_003D = _0023_003DzySgeilxprQOK._0023_003Dz2tLFTBU_003D;
			_0023_003Dzb8fU8pCQeU_0024N = _0023_003DzySgeilxprQOK._0023_003Dzb8fU8pCQeU_0024N;
			_0023_003DzYoy99to_BAZcMoB9Lg_003D_003D = _0023_003DzySgeilxprQOK._0023_003DzYoy99to_BAZcMoB9Lg_003D_003D;
			_0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D = _0023_003DzySgeilxprQOK._0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D;
			_0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = _0023_003DzySgeilxprQOK._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D;
			_0023_003DzGuj5_7rbVAcbSd1tuQ_003D_003D = _0023_003DzySgeilxprQOK._0023_003DzGuj5_7rbVAcbSd1tuQ_003D_003D;
			_0023_003DzwYpqy2PFYeuP = _0023_003DzySgeilxprQOK._0023_003DzwYpqy2PFYeuP;
			_0023_003Dz2IFGCrg7oQk4rDll53vHpGI_003D = new List<int>(_0023_003DzySgeilxprQOK._0023_003Dz2IFGCrg7oQk4rDll53vHpGI_003D);
			_0023_003DzLDPkY6mM_0024WD7cOh05rShrLs_003D = new List<int>(_0023_003DzySgeilxprQOK._0023_003DzLDPkY6mM_0024WD7cOh05rShrLs_003D);
			_0023_003DzMbxrlBQVi0Rge9Wsjw_003D_003D = new List<int>(_0023_003DzySgeilxprQOK._0023_003DzMbxrlBQVi0Rge9Wsjw_003D_003D);
		}

		public object Clone()
		{
			return new _0023_003DzhSzMHvbCt4ch(this);
		}

		public void _0023_003Dzz4Y82DIr3BJ8()
		{
			_0023_003DzwYpqy2PFYeuP++;
		}

		public void _0023_003DzJT7Ap1XtxRwhsxfKuQ_003D_003D(int _0023_003DzfBEBL_o_003D)
		{
			_0023_003Dz2IFGCrg7oQk4rDll53vHpGI_003D.Add(_0023_003DzfBEBL_o_003D);
		}

		public int _0023_003DzU2DqFP1CjQPLFwTExQ_003D_003D()
		{
			return _0023_003Dz2IFGCrg7oQk4rDll53vHpGI_003D[_0023_003DzwYpqy2PFYeuP];
		}

		public void _0023_003DzqziWr8V3B38VWlnU_0024Q_003D_003D(int _0023_003DzfBEBL_o_003D)
		{
			_0023_003DzMbxrlBQVi0Rge9Wsjw_003D_003D.Add(_0023_003DzfBEBL_o_003D);
		}

		public int _0023_003DzkCOZFXsmIQsOjUjsuw_003D_003D()
		{
			return _0023_003DzMbxrlBQVi0Rge9Wsjw_003D_003D[_0023_003DzwYpqy2PFYeuP];
		}

		public void _0023_003DzubKn_0024ShLeh24mUj9epw6UIc_003D(int _0023_003DzfBEBL_o_003D)
		{
			_0023_003DzLDPkY6mM_0024WD7cOh05rShrLs_003D.Add(_0023_003DzfBEBL_o_003D);
		}

		public int _0023_003Dz9OUwFbGPoML_Jby9Dq2ud5w_003D()
		{
			return _0023_003DzLDPkY6mM_0024WD7cOh05rShrLs_003D[_0023_003DzwYpqy2PFYeuP];
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzYIqZca3Y7z3lRzk5Ow_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DztXUtytIj1zJ7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh.edgeStyleType _0023_003Dzp4s_iREqDk59;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, Stream> _0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_bKJrUqsFUYO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzSFdDDwbzwE4l;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public bool Compact
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYIqZca3Y7z3lRzk5Ow_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYIqZca3Y7z3lRzk5Ow_003D_003D = value;
		}
	}

	public ReadOBJ(string filePath, string matName, Mesh.edgeStyleType edgeStyle)
		: base(filePath)
	{
		_0023_003Dz_bKJrUqsFUYO = false;
		_0023_003Dzp4s_iREqDk59 = edgeStyle;
		base.Materials.Add(new Material(matName));
	}

	public ReadOBJ(string filePath, bool plain, Mesh.edgeStyleType edgeStyle)
		: base(filePath)
	{
		_0023_003Dz_bKJrUqsFUYO = plain;
		_0023_003Dzp4s_iREqDk59 = edgeStyle;
	}

	public ReadOBJ(Stream stream, Mesh.edgeStyleType edgeStyle)
		: base(stream)
	{
		_0023_003Dz_bKJrUqsFUYO = true;
		_0023_003Dzp4s_iREqDk59 = edgeStyle;
	}

	public ReadOBJ(Stream objStream, Stream materialStream, Dictionary<string, Stream> texturesStream, Mesh.edgeStyleType edgeStyle)
		: base(objStream)
	{
		_0023_003Dz_bKJrUqsFUYO = false;
		_0023_003Dzp4s_iREqDk59 = edgeStyle;
		_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D = materialStream;
		_0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D = texturesStream;
	}

	public ReadOBJ(string filePath, bool plain)
		: this(filePath, plain, Mesh.edgeStyleType.Sharp)
	{
	}

	public ReadOBJ(string filePath, Mesh.edgeStyleType edgeStyle)
		: this(filePath, plain: false, edgeStyle)
	{
	}

	public ReadOBJ(string filePath)
		: this(filePath, plain: false, Mesh.edgeStyleType.Sharp)
	{
	}

	protected internal override void CloseStream()
	{
		if (readFileCloseStream)
		{
			if (_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D != null)
			{
				_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D.Close();
			}
			if (_0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D != null)
			{
				foreach (KeyValuePair<string, Stream> item in _0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D)
				{
					item.Value.Close();
				}
			}
		}
		base.CloseStream();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzMGZxzbWNdVO7(progress, ct);
	}

	private void _0023_003DzMGZxzbWNdVO7(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextReader _0023_003Dz63vmKM0_003D = new StreamReader(base.Stream, Encoding.ASCII);
			if (base.Materials.Count > 0)
			{
				_0023_003DzSFdDDwbzwE4l = true;
			}
			if (!_0023_003Dz_bKJrUqsFUYO && !_0023_003DzSKs5gYHX1Tf4ghn7zQ_003D_003D(_0023_003Dz63vmKM0_003D, base.Path) && !_0023_003DzSFdDDwbzwE4l)
			{
				_0023_003Dz_bKJrUqsFUYO = true;
			}
			_0023_003DzDAxZ0kgBhP3f(_0023_003Dz63vmKM0_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
	}

	private bool _0023_003DzSKs5gYHX1Tf4ghn7zQ_003D_003D(TextReader _0023_003Dz63vmKM0_003D, string _0023_003DzxKdbQ48_003D)
	{
		base.Stream.Position = 0L;
		((StreamReader)_0023_003Dz63vmKM0_003D).DiscardBufferedData();
		string text;
		while ((text = _0023_003Dz63vmKM0_003D.ReadLine()) != null)
		{
			string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0 || !array[0].StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010531)))
			{
				continue;
			}
			string text2 = text.Substring(6).Trim(' ');
			string[] array2 = new string[5]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010514),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010524),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010502),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010509),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982007)
			};
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < array2.Length; i++)
				{
					if (text2.StartsWith(array2[i]))
					{
						text2 = text2.Substring(array2[i].Length);
						flag = true;
						break;
					}
				}
			}
			string text3 = text2;
			if (!string.IsNullOrEmpty(_0023_003DzxKdbQ48_003D) && !System.IO.Path.IsPathRooted(text2))
			{
				text3 = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(_0023_003DzxKdbQ48_003D, new string[1] { text3 });
			}
			bool flag2 = _0023_003DzsqoYzryBd_0024bm(text3);
			if (!flag2)
			{
				text3 = System.IO.Path.Combine(_0023_003DzxKdbQ48_003D, System.IO.Path.GetFileName(text2));
				flag2 = _0023_003DzsqoYzryBd_0024bm(text3);
			}
			return flag2;
		}
		return false;
	}

	private void _0023_003DzDAxZ0kgBhP3f(TextReader _0023_003Dz63vmKM0_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		base.Stream.Position = 0L;
		((StreamReader)_0023_003Dz63vmKM0_003D).DiscardBufferedData();
		List<Entity> list = new List<Entity>();
		Dictionary<string, _0023_003DzPD_Puf0_003D> dictionary = new Dictionary<string, _0023_003DzPD_Puf0_003D>();
		int num = 0;
		_0023_003DzPD_Puf0_003D _0023_003DzPD_Puf0_003D2 = new _0023_003DzPD_Puf0_003D();
		_0023_003DzPD_Puf0_003D2._0023_003DzL3kjwgWK1Hcy = (_0023_003Dz_bKJrUqsFUYO ? entityNatureType.Polygon : entityNatureType.RichPolygon);
		_0023_003DzhSzMHvbCt4ch _0023_003DzhSzMHvbCt4ch2 = (_0023_003DzhSzMHvbCt4ch)(_0023_003DzPD_Puf0_003D2._0023_003DzOqDotZs_003D = new _0023_003DzhSzMHvbCt4ch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968747)));
		_0023_003DzPD_Puf0_003D2._0023_003DzzqOf1IF2wxNe = _0023_003Dzp4s_iREqDk59;
		dictionary[((_0023_003DzhSzMHvbCt4ch)_0023_003DzPD_Puf0_003D2._0023_003DzOqDotZs_003D)._0023_003Dz2tLFTBU_003D] = _0023_003DzPD_Puf0_003D2;
		List<Point3D> list2 = new List<Point3D>();
		List<Vector3D> list3 = new List<Vector3D>();
		List<PointF> list4 = new List<PointF>();
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool flag = false;
		string text;
		while ((text = _0023_003Dz63vmKM0_003D.ReadLine()) != null)
		{
			string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				continue;
			}
			string text2 = array[0];
			if (text2 == null)
			{
				continue;
			}
			switch (text2.Length)
			{
			case 1:
				switch (text2[0])
				{
				case 'v':
				{
					num2++;
					double x = Utility.DoubleParse(array[1]);
					double y = Utility.DoubleParse(array[2]);
					double z = Utility.DoubleParse(array[3]);
					if (array.Length == 7)
					{
						byte red = Convert.ToByte(Utility.DoubleParse(array[4]) * 255.0);
						byte green = Convert.ToByte(Utility.DoubleParse(array[5]) * 255.0);
						byte blue = Convert.ToByte(Utility.DoubleParse(array[6]) * 255.0);
						list2.Add(new PointRGB(x, y, z, Color.FromArgb(255, red, green, blue)));
					}
					else
					{
						list2.Add(new Point3D(x, y, z));
					}
					break;
				}
				case 'g':
				case 'o':
					if (array.Length > 1)
					{
						string text3 = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382), array.Skip(1));
						if (dictionary.ContainsKey(text3))
						{
							_0023_003DzhSzMHvbCt4ch _0023_003DzhSzMHvbCt4ch3 = (_0023_003DzhSzMHvbCt4ch)dictionary[text3]._0023_003DzOqDotZs_003D;
							if (_0023_003DzhSzMHvbCt4ch3._0023_003Dz2tLFTBU_003D == text3)
							{
								_0023_003DzhSzMHvbCt4ch3._0023_003DzJT7Ap1XtxRwhsxfKuQ_003D_003D(num2);
								_0023_003DzhSzMHvbCt4ch3._0023_003DzqziWr8V3B38VWlnU_0024Q_003D_003D(num3);
								_0023_003DzhSzMHvbCt4ch3._0023_003DzubKn_0024ShLeh24mUj9epw6UIc_003D(num4);
							}
						}
						else
						{
							_0023_003DzPD_Puf0_003D2 = new _0023_003DzPD_Puf0_003D();
							_0023_003DzPD_Puf0_003D2._0023_003DzL3kjwgWK1Hcy = (_0023_003Dz_bKJrUqsFUYO ? entityNatureType.Polygon : entityNatureType.RichPolygon);
							_0023_003DzhSzMHvbCt4ch2 = new _0023_003DzhSzMHvbCt4ch(text3);
							_0023_003DzhSzMHvbCt4ch2._0023_003DzJT7Ap1XtxRwhsxfKuQ_003D_003D(num2);
							_0023_003DzhSzMHvbCt4ch2._0023_003DzqziWr8V3B38VWlnU_0024Q_003D_003D(num3);
							_0023_003DzhSzMHvbCt4ch2._0023_003DzubKn_0024ShLeh24mUj9epw6UIc_003D(num4);
							_0023_003DzPD_Puf0_003D2._0023_003DzOqDotZs_003D = _0023_003DzhSzMHvbCt4ch2;
							_0023_003DzPD_Puf0_003D2._0023_003DzzqOf1IF2wxNe = _0023_003Dzp4s_iREqDk59;
							dictionary[((_0023_003DzhSzMHvbCt4ch)_0023_003DzPD_Puf0_003D2._0023_003DzOqDotZs_003D)._0023_003Dz2tLFTBU_003D] = _0023_003DzPD_Puf0_003D2;
						}
					}
					else
					{
						_0023_003DzhSzMHvbCt4ch2._0023_003DzJT7Ap1XtxRwhsxfKuQ_003D_003D(num2);
						_0023_003DzhSzMHvbCt4ch2._0023_003DzqziWr8V3B38VWlnU_0024Q_003D_003D(num3);
						_0023_003DzhSzMHvbCt4ch2._0023_003DzubKn_0024ShLeh24mUj9epw6UIc_003D(num4);
					}
					break;
				case 'f':
					if (_0023_003DzhSzMHvbCt4ch2._0023_003Dzb8fU8pCQeU_0024N == 0)
					{
						string[] array2 = array[1].Split('/');
						bool flag2 = array2.Length > 1 && string.IsNullOrEmpty(array2[1]);
						bool flag3 = array2.Length > 2 && string.IsNullOrEmpty(array2[2]);
						switch (array2.Length)
						{
						case 1:
							_0023_003DzhSzMHvbCt4ch2._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = 0;
							break;
						case 2:
							_0023_003DzhSzMHvbCt4ch2._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = 2;
							_0023_003DzhSzMHvbCt4ch2._0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D = true;
							break;
						case 3:
							if (flag2 && flag3)
							{
								_0023_003DzhSzMHvbCt4ch2._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = 1;
							}
							else if (flag3)
							{
								_0023_003DzhSzMHvbCt4ch2._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = 3;
								_0023_003DzhSzMHvbCt4ch2._0023_003DzYoy99to_BAZcMoB9Lg_003D_003D = true;
							}
							else
							{
								_0023_003DzhSzMHvbCt4ch2._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = 4;
								_0023_003DzhSzMHvbCt4ch2._0023_003DzWUyXsLzQu0WJt4BD_0024Q_003D_003D = true;
								_0023_003DzhSzMHvbCt4ch2._0023_003DzYoy99to_BAZcMoB9Lg_003D_003D = true;
							}
							break;
						default:
							throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010474));
						}
					}
					_0023_003DzhSzMHvbCt4ch2._0023_003Dzb8fU8pCQeU_0024N++;
					num++;
					break;
				case 'l':
					if (array.Length == 3)
					{
						int index = int.Parse(array[1]) - 1;
						int index2 = int.Parse(array[2]) - 1;
						list.Add(new Line((Point3D)list2[index].Clone(), (Point3D)list2[index2].Clone()));
						break;
					}
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010474));
				}
				break;
			case 2:
				switch (text2[1])
				{
				case 't':
					if (!(text2 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010488)))
					{
						break;
					}
					num4++;
					if (!_0023_003Dz_bKJrUqsFUYO)
					{
						PointF item = default(PointF);
						try
						{
							item = new PointF((float)Utility.DoubleParse(array[1]), (float)Utility.DoubleParse(array[2]));
						}
						catch (Exception)
						{
						}
						list4.Add(item);
					}
					break;
				case 'n':
				{
					if (!(text2 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010495)))
					{
						break;
					}
					num3++;
					Vector3D vector3D = new Vector3D(Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), Utility.DoubleParse(array[3]));
					if (flag || !vector3D.IsUnit)
					{
						if (!vector3D.Normalize())
						{
							vector3D = Vector3D.AxisX;
						}
						flag = true;
					}
					list3.Add(vector3D);
					break;
				}
				}
				break;
			}
		}
		if (_0023_003DzBrFH_vXemG8q(_0023_003Dz63vmKM0_003D, _0023_003DzhSzMHvbCt4ch2, dictionary, list2, list3, list4, num, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			for (int i = 0; i < dictionary.Values.Count; i++)
			{
				_0023_003DzPD_Puf0_003D _0023_003DzPD_Puf0_003D3 = dictionary.Values.ElementAt(i);
				list.AddRange(_0023_003DzPD_Puf0_003D3._0023_003DzROQTjn5Yve4K(null, list2, list3, list4, _0023_003Dzp4s_iREqDk59, _0023_003Dz_bKJrUqsFUYO, Compact));
				if (!UpdateProgressAndCheckCancelled(i, dictionary.Values.Count, base.ParsingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					break;
				}
			}
			UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzmHS7frs_003D);
			base.Entities.AddRange(list);
			result = true;
		}
		base.Result = result;
	}

	private bool _0023_003DzBrFH_vXemG8q(TextReader _0023_003Dz63vmKM0_003D, _0023_003DzhSzMHvbCt4ch _0023_003Dzifq_QG8_003D, Dictionary<string, _0023_003DzPD_Puf0_003D> _0023_003Dzmx_DYUk_003D, List<Point3D> _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, List<Vector3D> _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, List<PointF> _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D, int _0023_003DzNJ4Ismb2xHW7, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		base.Stream.Position = 0L;
		_0023_003Dz7sLr1fMiCJis _0023_003Dz7sLr1fMiCJis2 = new _0023_003Dz7sLr1fMiCJis(null, _0023_003DzNJ4Ismb2xHW7);
		int num = 0;
		string text = string.Empty;
		_0023_003DzPD_Puf0_003D _0023_003DzPD_Puf0_003D2 = _0023_003Dzmx_DYUk_003D.First().Value;
		string text2 = string.Empty;
		if (_0023_003Dzmx_DYUk_003D.Count > 0)
		{
			string text3;
			while ((text3 = _0023_003Dz63vmKM0_003D.ReadLine()) != null)
			{
				string[] array = text3.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 0)
				{
					continue;
				}
				string text4 = array[0];
				if (!(text4 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010443)) && !(text4 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425)))
				{
					if (!(text4 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011187)))
					{
						if (!(text4 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011195)) || _0023_003Dz_bKJrUqsFUYO)
						{
							continue;
						}
						_0023_003DzPD_Puf0_003D2._0023_003DzgLmLM40_003D(_0023_003Dz7sLr1fMiCJis2);
						if (_0023_003DzSFdDDwbzwE4l)
						{
							text2 = base.Materials.First().Name;
						}
						else if (array.Length > 1)
						{
							string text5 = _0023_003DzTCTy0_00244a3sPg(text3);
							if (!base.Materials.TryGetValue(text5, out var _))
							{
								base.Materials.Add(new Material(text5));
								log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011178) + text5 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011139));
							}
							text2 = text5;
						}
						_0023_003Dz7sLr1fMiCJis2 = new _0023_003Dz7sLr1fMiCJis(text2, _0023_003Dzifq_QG8_003D._0023_003Dzb8fU8pCQeU_0024N);
						_0023_003Dz7sLr1fMiCJis2._0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = text2;
						continue;
					}
					string text6 = text3;
					while (text6.IndexOf('\\') > -1)
					{
						text6 = text6.Substring(0, text6.Length - 1);
						text6 = text6 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dz63vmKM0_003D.ReadLine();
					}
					if (_0023_003Dz_bKJrUqsFUYO)
					{
						_0023_003DzFyF0fLIuQY_4(text6, _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, _0023_003Dz7sLr1fMiCJis2, _0023_003Dz_0024_mpWHbeukqh: true, _0023_003Dzifq_QG8_003D);
					}
					else
					{
						if (!string.IsNullOrEmpty(text2) && text2 != text)
						{
							base.Materials.TryGetValue(text2, out var value2);
							if (value2 != null && _0023_003Dz7sLr1fMiCJis2 != null)
							{
								_0023_003Dz7sLr1fMiCJis2._0023_003Dzaa_0024mmAo_003D = value2.Diffuse;
							}
							text = text2;
						}
						bool _0023_003Dz_0024_mpWHbeukqh = _0023_003Dz7sLr1fMiCJis2._0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.Smooth || _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Count == 0;
						_0023_003DzFyF0fLIuQY_4(text6, _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, _0023_003Dz7sLr1fMiCJis2, _0023_003Dz_0024_mpWHbeukqh, _0023_003Dzifq_QG8_003D);
					}
					_0023_003DztXUtytIj1zJ7 = false;
					if (UpdateProgressAndCheckCancelled(++num, _0023_003DzNJ4Ismb2xHW7, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						continue;
					}
					return false;
				}
				_0023_003DzPD_Puf0_003D2._0023_003DzgLmLM40_003D(_0023_003Dz7sLr1fMiCJis2);
				_0023_003Dz7sLr1fMiCJis2 = null;
				if (array.Length > 1)
				{
					string key = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382), array.Skip(1));
					if (_0023_003Dzmx_DYUk_003D.ContainsKey(key))
					{
						_0023_003DzPD_Puf0_003D obj = _0023_003Dzmx_DYUk_003D[key];
						_0023_003Dzifq_QG8_003D = (_0023_003DzhSzMHvbCt4ch)obj._0023_003DzOqDotZs_003D;
						_0023_003Dzifq_QG8_003D._0023_003Dzz4Y82DIr3BJ8();
						_0023_003DzPD_Puf0_003D2 = obj;
						text = string.Empty;
						_0023_003Dz7sLr1fMiCJis2 = new _0023_003Dz7sLr1fMiCJis(text2, _0023_003Dzifq_QG8_003D._0023_003Dzb8fU8pCQeU_0024N);
					}
				}
				else
				{
					_0023_003Dzifq_QG8_003D._0023_003Dzz4Y82DIr3BJ8();
				}
			}
			UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
			_0023_003DzPD_Puf0_003D2._0023_003DzgLmLM40_003D(_0023_003Dz7sLr1fMiCJis2);
		}
		return true;
	}

	private void _0023_003DzFyF0fLIuQY_4(string _0023_003DzQ9zpGF0_003D, IList<Point3D> _0023_003DzNfbkdJU_003D, _0023_003Dz7sLr1fMiCJis _0023_003DzauU_W6_S0tjE, bool _0023_003Dz_0024_mpWHbeukqh, _0023_003DzhSzMHvbCt4ch _0023_003Dzifq_QG8_003D)
	{
		int _0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D = _0023_003Dzifq_QG8_003D._0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D;
		string[] array = _0023_003DzQ9zpGF0_003D.TrimStart('f').Trim().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		List<int> list = new List<int>(3);
		List<int> list2 = new List<int>(3);
		List<int> list3 = new List<int>(3);
		for (int i = 0; i < array.Length; i++)
		{
			switch (_0023_003Dza0BHUUKQFx3kz3B_kA_003D_003D)
			{
			case 0:
			case 1:
			{
				string[] array2 = array[i].Split('/');
				_0023_003DzH0tF8GpjHqbP(_0023_003Dzifq_QG8_003D, array2[0], list, ref _0023_003DztXUtytIj1zJ7);
				list3.Add(-1);
				list2.Add(-1);
				break;
			}
			case 2:
			{
				string[] array2 = array[i].Split('/');
				_0023_003DzH0tF8GpjHqbP(_0023_003Dzifq_QG8_003D, array2[0], list, ref _0023_003DztXUtytIj1zJ7);
				if (!_0023_003Dz_0024_mpWHbeukqh)
				{
					_0023_003DzkF6w65Vrh_v9(_0023_003Dzifq_QG8_003D, array2[1], list3);
				}
				else
				{
					list3.Add(-1);
				}
				list2.Add(-1);
				break;
			}
			case 3:
			{
				string[] array2 = array[i].Split('/');
				_0023_003DzH0tF8GpjHqbP(_0023_003Dzifq_QG8_003D, array2[0], list, ref _0023_003DztXUtytIj1zJ7);
				list3.Add(-1);
				_0023_003DzwPuJjvGZQJii(_0023_003Dzifq_QG8_003D, array2[2], list2);
				break;
			}
			case 4:
			{
				string[] array2 = array[i].Split('/');
				_0023_003DzH0tF8GpjHqbP(_0023_003Dzifq_QG8_003D, array2[0], list, ref _0023_003DztXUtytIj1zJ7);
				if (!_0023_003Dz_0024_mpWHbeukqh)
				{
					if (array2.Length > 1)
					{
						if (array2[1] == string.Empty)
						{
							_0023_003DzkF6w65Vrh_v9(_0023_003Dzifq_QG8_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011125), list3);
						}
						else
						{
							_0023_003DzkF6w65Vrh_v9(_0023_003Dzifq_QG8_003D, array2[1], list3);
						}
					}
					else
					{
						list3.Add(0);
					}
				}
				else
				{
					list3.Add(-1);
				}
				if (array2.Length > 2)
				{
					_0023_003DzwPuJjvGZQJii(_0023_003Dzifq_QG8_003D, array2[2], list2);
					break;
				}
				_0023_003Dzifq_QG8_003D._0023_003DzGuj5_7rbVAcbSd1tuQ_003D_003D = true;
				list2.Add(-1);
				break;
			}
			}
		}
		if (_0023_003DztXUtytIj1zJ7 && array.Length < 5)
		{
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = j + 1; k < list.Count; k++)
				{
					if (list[j] == list[k])
					{
						list.RemoveAt(k);
					}
				}
			}
		}
		if (list.Count < 3)
		{
			return;
		}
		switch (array.Length)
		{
		case 0:
		case 1:
		case 2:
			return;
		case 3:
		{
			SmoothTriangle item = _0023_003DzPq45nGk_003D(list[0], list[1], list[2], list2[0], list2[1], list2[2], list3[0], list3[1], list3[2], _0023_003Dz_0024_mpWHbeukqh, _0023_003DzauU_W6_S0tjE);
			_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(item);
			return;
		}
		case 4:
		{
			SmoothTriangle item = _0023_003DzPq45nGk_003D(list[0], list[1], list[2], list2[0], list2[1], list2[2], list3[0], list3[1], list3[2], _0023_003Dz_0024_mpWHbeukqh, _0023_003DzauU_W6_S0tjE);
			_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(item);
			if (list.Count >= 4)
			{
				item = _0023_003DzPq45nGk_003D(list[0], list[2], list[3], list2[0], list2[2], list2[3], list3[0], list3[2], list3[3], _0023_003Dz_0024_mpWHbeukqh, _0023_003DzauU_W6_S0tjE);
				_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(item);
			}
			return;
		}
		}
		Point3D[] array3 = new Point3D[list.Count];
		for (int l = 0; l < list.Count; l++)
		{
			array3[l] = _0023_003DzNfbkdJU_003D[list[l]];
		}
		Plane xY = Plane.XY;
		Plane plane = Utility.FitPlane(array3);
		Transformation transformation = new Transformation();
		transformation.Rotation(plane.Origin, plane.AxisX, plane.AxisY, plane.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
		Point2D[] array4 = new Point2D[array3.Length + 1];
		for (int m = 0; m < array3.Length; m++)
		{
			Point3D point3D = transformation * array3[m];
			array4[m] = new Point2D(point3D.X, point3D.Y);
		}
		array4[^1] = (Point2D)array4[0].Clone();
		Point2D[] _0023_003DzoWY20dYyIIW = (Point2D[])array4.Clone();
		bool flag = Utility.IsOrientedClockwise(array4);
		if (flag)
		{
			Array.Reverse(array4);
		}
		try
		{
			array4 = Utility.RemoveDuplicates(array4, out var indices);
			if (array4.Length < 3)
			{
				return;
			}
			List<int> _0023_003Dzm9UDyB2B5vYF = new List<int>(indices.Count);
			List<int> list4 = new List<int>(indices.Count);
			List<int> list5 = new List<int>(indices.Count);
			for (int n = 0; n < indices.Count - 1; n++)
			{
				int index = indices[n];
				_0023_003Dzm9UDyB2B5vYF.Add(list[index]);
				list4.Add(list2[index]);
				list5.Add(list3[index]);
			}
			_0023_003Dzm9UDyB2B5vYF.Add(list[indices[0]]);
			list4.Add(list2[indices[0]]);
			list5.Add(list3[indices[0]]);
			array4 = new List<Point2D>(array4).ToArray();
			Point2D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D;
			IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D;
			if (_0023_003DztXUtytIj1zJ7)
			{
				_0023_003Dzmai4AuZiegPYQ2tLlSdUGXc_003D(array4, _0023_003DzoWY20dYyIIW, list, out _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out _0023_003DzXT3BRSZezblHON7QOg_003D_003D, out _0023_003Dzm9UDyB2B5vYF);
			}
			else
			{
				Utility.Triangulate(array4, null, fixOrientation: false, checkValidity: false, out _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out _0023_003DzXT3BRSZezblHON7QOg_003D_003D);
			}
			if (_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D.Length > array4.Length)
			{
				return;
			}
			if (flag && !_0023_003DztXUtytIj1zJ7)
			{
				_0023_003Dzm9UDyB2B5vYF.Reverse();
				list4.Reverse();
				list5.Reverse();
				foreach (IndexTriangle indexTriangle in _0023_003DzXT3BRSZezblHON7QOg_003D_003D)
				{
					int v = indexTriangle.V1;
					indexTriangle.V1 = indexTriangle.V2;
					indexTriangle.V2 = v;
				}
			}
			for (int num2 = 0; num2 < _0023_003DzXT3BRSZezblHON7QOg_003D_003D.Length; num2++)
			{
				int v2 = _0023_003DzXT3BRSZezblHON7QOg_003D_003D[num2].V1;
				int v3 = _0023_003DzXT3BRSZezblHON7QOg_003D_003D[num2].V2;
				int v4 = _0023_003DzXT3BRSZezblHON7QOg_003D_003D[num2].V3;
				SmoothTriangle item = _0023_003DzPq45nGk_003D(_0023_003Dzm9UDyB2B5vYF[v2], _0023_003Dzm9UDyB2B5vYF[v3], _0023_003Dzm9UDyB2B5vYF[v4], list4[v2], list4[v3], list4[v4], list5[v2], list5[v3], list5[v4], _0023_003Dz_0024_mpWHbeukqh, _0023_003DzauU_W6_S0tjE);
				_0023_003DzauU_W6_S0tjE._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(item);
			}
		}
		catch (Exception)
		{
		}
	}

	private void _0023_003Dzmai4AuZiegPYQ2tLlSdUGXc_003D(Point2D[] _0023_003Dz9KfPrzVPEGNp, Point2D[] _0023_003DzoWY20dYyIIW7, List<int> _0023_003DzfB65z6vhM2L8, out Point2D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D, out List<int> _0023_003Dzm9UDyB2B5vYF)
	{
		List<ICurve> list = new List<ICurve>(new LinearPath(Plane.XY, _0023_003Dz9KfPrzVPEGNp).ConvertToLines());
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				if ((list[i].StartPoint == list[j].StartPoint && list[i].EndPoint == list[j].EndPoint) || (list[i].StartPoint == list[j].EndPoint && list[i].EndPoint == list[j].StartPoint))
				{
					list.RemoveAt(j);
					list.RemoveAt(i);
				}
			}
		}
		Utility.ComputeBoundingRect(_0023_003Dz9KfPrzVPEGNp, out var boxMin, out var boxMax);
		Size2D size2D = new Size2D(boxMin, boxMax);
		devDept.Eyeshot.Entities.Region[] array = Utility.DetectRegionsFromContours(Utility.GetConnectedCurves(list, size2D.Diagonal * Utility._0023_003Dzjyaz_Vfaky9X));
		List<Point2D> list2 = new List<Point2D>();
		List<IndexTriangle> list3 = new List<IndexTriangle>();
		devDept.Eyeshot.Entities.Region[] array2 = array;
		foreach (devDept.Eyeshot.Entities.Region region in array2)
		{
			region.Regen(0.0);
			Point3D[] vertices = region.Vertices;
			foreach (Point3D point3D in vertices)
			{
				list2.Add(new Point2D(point3D.X, point3D.Y));
			}
			list3.AddRange(region.Triangles);
		}
		_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D = list2.ToArray();
		_0023_003DzXT3BRSZezblHON7QOg_003D_003D = list3.ToArray();
		_0023_003Dzm9UDyB2B5vYF = new List<int>(list2.Count + 1);
		for (int m = 0; m < list2.Count; m++)
		{
			for (int n = 0; n < _0023_003DzoWY20dYyIIW7.Length - 1; n++)
			{
				if (list2[m] == _0023_003DzoWY20dYyIIW7[n])
				{
					_0023_003Dzm9UDyB2B5vYF.Add(_0023_003DzfB65z6vhM2L8[n]);
					break;
				}
			}
		}
	}

	private static void _0023_003DzkF6w65Vrh_v9(_0023_003DzhSzMHvbCt4ch _0023_003Dzifq_QG8_003D, string _0023_003DzrDPdIjQ_003D, List<int> _0023_003Dz49DwYunFoHZ4)
	{
		int num = int.Parse(_0023_003DzrDPdIjQ_003D);
		num = ((num >= 0) ? (num - 1) : (_0023_003Dzifq_QG8_003D._0023_003Dz9OUwFbGPoML_Jby9Dq2ud5w_003D() + num));
		_0023_003Dz49DwYunFoHZ4.Add(num);
	}

	private static void _0023_003DzwPuJjvGZQJii(_0023_003DzhSzMHvbCt4ch _0023_003Dzifq_QG8_003D, string _0023_003DzrDPdIjQ_003D, List<int> _0023_003Dzcaz0etUZnCUu)
	{
		int num = int.Parse(_0023_003DzrDPdIjQ_003D);
		num = ((num >= 0) ? (num - 1) : (_0023_003Dzifq_QG8_003D._0023_003DzkCOZFXsmIQsOjUjsuw_003D_003D() + num));
		_0023_003Dzcaz0etUZnCUu.Add(num);
	}

	private static void _0023_003DzH0tF8GpjHqbP(_0023_003DzhSzMHvbCt4ch _0023_003Dzifq_QG8_003D, string _0023_003DzrDPdIjQ_003D, List<int> _0023_003DzfB65z6vhM2L8, ref bool _0023_003DztXUtytIj1zJ7)
	{
		int num = int.Parse(_0023_003DzrDPdIjQ_003D);
		num = ((num >= 0) ? (num - 1) : (_0023_003Dzifq_QG8_003D._0023_003DzU2DqFP1CjQPLFwTExQ_003D_003D() + num));
		if (_0023_003DzfB65z6vhM2L8.Contains(num))
		{
			_0023_003DztXUtytIj1zJ7 = true;
		}
		_0023_003DzfB65z6vhM2L8.Add(num);
	}

	private SmoothTriangle _0023_003DzPq45nGk_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, int _0023_003Dz0wAkCmM_003D, int _0023_003Dz_0024eRdUwQ_003D, int _0023_003Dz5cbO6Ls_003D, int _0023_003DzsK_Xndk_003D, int _0023_003Dz0ADyCos_003D, int _0023_003DzoCDsmWk_003D, bool _0023_003Dz_0024_mpWHbeukqh, _0023_003Dz7sLr1fMiCJis _0023_003DzauU_W6_S0tjE)
	{
		if (_0023_003Dz0wAkCmM_003D < 0)
		{
			_0023_003Dz0wAkCmM_003D = 0;
		}
		if (_0023_003Dz_0024eRdUwQ_003D < 0)
		{
			_0023_003Dz_0024eRdUwQ_003D = 0;
		}
		if (_0023_003Dz5cbO6Ls_003D < 0)
		{
			_0023_003Dz5cbO6Ls_003D = 0;
		}
		_0023_003DzauU_W6_S0tjE._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D.Add(_0023_003DzffqPLNQ_003D);
		_0023_003DzauU_W6_S0tjE._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D.Add(_0023_003Dz5Azd7L8_003D);
		_0023_003DzauU_W6_S0tjE._0023_003Dz0MdUkgYwWERvKoo3CQ_003D_003D.Add(_0023_003DzZe6oCrQ_003D);
		_0023_003DzauU_W6_S0tjE._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D.Add(_0023_003Dz0wAkCmM_003D);
		_0023_003DzauU_W6_S0tjE._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D.Add(_0023_003Dz_0024eRdUwQ_003D);
		_0023_003DzauU_W6_S0tjE._0023_003DzZM_CIYWEw7yANTXyfA_003D_003D.Add(_0023_003Dz5cbO6Ls_003D);
		SmoothTriangle result;
		if (_0023_003Dz_0024_mpWHbeukqh)
		{
			result = new SmoothTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D);
		}
		else
		{
			result = new RichSmoothTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzsK_Xndk_003D, _0023_003Dz0ADyCos_003D, _0023_003DzoCDsmWk_003D);
			_0023_003DzauU_W6_S0tjE._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D.Add(_0023_003DzsK_Xndk_003D);
			_0023_003DzauU_W6_S0tjE._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D.Add(_0023_003Dz0ADyCos_003D);
			_0023_003DzauU_W6_S0tjE._0023_003DzOcBif_0024mbcCfrYyijfQ_003D_003D.Add(_0023_003DzoCDsmWk_003D);
		}
		return result;
	}

	private bool _0023_003DzsqoYzryBd_0024bm(string _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D)
	{
		if (!_0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003DzaWKgHquahf_0024G(ref _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D, _0023_003Dzmyw8uNw_003D: false))
		{
			return false;
		}
		if (_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D == null)
		{
			if (!File.Exists(_0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D))
			{
				return false;
			}
			_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D = File.Open(_0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
		_0023_003DzUSIikiV9VQj9(_0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D);
		return true;
	}

	private void _0023_003DzUSIikiV9VQj9(string _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D)
	{
		Material material = null;
		string text = null;
		TextReader textReader = new StreamReader(_0023_003DzV13_MDdbrAvL6TWzMQ_003D_003D);
		string text2;
		while ((text2 = textReader.ReadLine()) != null)
		{
			text2 = text2.TrimStart('\t');
			string[] array = text2.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				continue;
			}
			string text3 = array[0];
			if (text3 == null)
			{
				continue;
			}
			switch (text3.Length)
			{
			case 6:
			{
				char c = text3[5];
				if (c != 'a')
				{
					if (c != 'd')
					{
						if (c == 'l' && text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011136))
						{
							if (text != null && !base.Materials.Contains(text))
							{
								base.Materials.Add(material);
							}
							text = _0023_003DzTCTy0_00244a3sPg(text2);
							material = new Material(text);
						}
						continue;
					}
					if (!(text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011115)))
					{
						continue;
					}
				}
				else if (!(text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011098)))
				{
					continue;
				}
				material.TextureImage = _0023_003Dz6e8pxv8_003D(array, _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D);
				continue;
			}
			case 2:
				switch (text3[1])
				{
				case 's':
					if (!(text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011077)))
					{
						if (text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011088))
						{
							material.Specular = Utility.FloatArrayToColor(_0023_003DzQtwezNc_003D(array));
						}
					}
					else
					{
						material.Shininess = 0.25f;
					}
					break;
				case 'd':
					if (text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011319))
					{
						byte b = byte.MaxValue;
						if (material != null && material.Diffuse.A != byte.MaxValue)
						{
							b = material.Diffuse.A;
						}
						material.Diffuse = Utility.FloatArrayToColor(_0023_003DzQtwezNc_003D(array));
						if (b != byte.MaxValue)
						{
							material.Diffuse = Color.FromArgb(b, material.Diffuse);
						}
					}
					break;
				case 'a':
					if (text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011298))
					{
						material.Ambient = Utility.FloatArrayToColor(_0023_003DzQtwezNc_003D(array));
					}
					break;
				}
				continue;
			case 1:
				if (text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011305))
				{
					float num = (float)Utility.DoubleParse(array[1]);
					material.Diffuse = Color.FromArgb((byte)(num * 255f), material.Diffuse);
				}
				continue;
			case 5:
				if (text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011281))
				{
					material.AlphaMapImage = _0023_003Dz6e8pxv8_003D(array, _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D);
				}
				continue;
			case 4:
				if (!(text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011293)))
				{
					continue;
				}
				break;
			case 8:
				if (!(text3 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011274)))
				{
					continue;
				}
				break;
			default:
				continue;
			}
			byte[] array2 = _0023_003Dz6e8pxv8_003D(array, _0023_003DzCjA3RTIZqbDOK3ho_0024A_003D_003D);
			if (array2 != null)
			{
				material.EnvironmentMappingImage = array2;
				material.Environment = 0.5f;
			}
		}
		if (text != null && !base.Materials.Contains(text))
		{
			base.Materials.Add(material);
		}
	}

	private byte[] _0023_003Dz6e8pxv8_003D(string[] _0023_003DzrDPdIjQ_003D, string _0023_003Dz_HZ81V0_003D)
	{
		if (_0023_003DzrDPdIjQ_003D.Length > 1)
		{
			string text = _0023_003DzrDPdIjQ_003D[1];
			int num = 2;
			while (num < _0023_003DzrDPdIjQ_003D.Length)
			{
				text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzrDPdIjQ_003D[num++];
			}
			if (_0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D != null)
			{
				string[] array = _0023_003DzrDPdIjQ_003D[^1].Split(new string[2]
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934509),
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636)
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 0)
				{
					text = array[^1].Trim();
				}
				if (_0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D.ContainsKey(text))
				{
					return Utility._0023_003DzIpZE2cw6usPZ(_0023_003Dzd2BxAy3X32InIo7E_0024Q_003D_003D[text]);
				}
			}
			string directoryName = System.IO.Path.GetDirectoryName(_0023_003Dz_HZ81V0_003D);
			string _0023_003Dzsuiz4uo_003D = (string.IsNullOrEmpty(directoryName) ? text : _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(directoryName, new string[1] { text }));
			if (_0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003DzaWKgHquahf_0024G(ref _0023_003Dzsuiz4uo_003D, _0023_003Dzmyw8uNw_003D: false) && File.Exists(_0023_003Dzsuiz4uo_003D))
			{
				byte[] array2 = Utility._0023_003DzIpZE2cw6usPZ(_0023_003Dzsuiz4uo_003D);
				if (array2 == null)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011255));
				}
				return array2;
			}
			_0023_003Dzsuiz4uo_003D = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_0023_003Dzsuiz4uo_003D), path3: System.IO.Path.GetFileName(_0023_003Dzsuiz4uo_003D), path2: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011225));
			if (_0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003DzaWKgHquahf_0024G(ref _0023_003Dzsuiz4uo_003D, _0023_003Dzmyw8uNw_003D: false) && File.Exists(_0023_003Dzsuiz4uo_003D))
			{
				byte[] array3 = Utility._0023_003DzIpZE2cw6usPZ(_0023_003Dzsuiz4uo_003D);
				if (array3 == null)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011255));
				}
				return array3;
			}
		}
		return null;
	}

	internal float[] _0023_003DzQtwezNc_003D(string[] _0023_003DzrDPdIjQ_003D)
	{
		if (_0023_003DzrDPdIjQ_003D.Length != 4)
		{
			return new float[4]
			{
				(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[1]),
				(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[2]),
				(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[3]),
				(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[4])
			};
		}
		return new float[4]
		{
			(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[1]),
			(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[2]),
			(float)Utility.DoubleParse(_0023_003DzrDPdIjQ_003D[3]),
			1f
		};
	}

	private string _0023_003DzTCTy0_00244a3sPg(string _0023_003DzQ9zpGF0_003D)
	{
		int num = _0023_003DzQ9zpGF0_003D.IndexOf(' ') + 1;
		return _0023_003DzQ9zpGF0_003D.Substring(num, _0023_003DzQ9zpGF0_003D.Length - num).Trim();
	}
}
