using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using SharpGLTF.Schema2;
using SharpGLTF.Validation;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadGLTF : ReadFileAsync
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<MaterialChannel, bool> _0023_003Dz38_WZBhyB43pPpxcCQ_003D_003D;

		public static Func<MaterialChannel, bool> _0023_003DzkiMeGQi_0024daIiqK5jTg_003D_003D;

		public static Func<MaterialChannel, bool> _0023_003DzGh82OGe6rRnz7c6USw_003D_003D;

		public static Func<IMaterialParameter, bool> _0023_003Dzh4eYwkowUq8A1IkKBQ_003D_003D;

		public static Func<IMaterialParameter, bool> _0023_003DzMGSkL41Iz67qyzk8FA_003D_003D;

		internal bool _0023_003Dzd7rvFGoSdZ58TX_5vOujJ1vVFULg(MaterialChannel _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.Key.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004683));
		}

		internal bool _0023_003DzYcbpB8q_WBoq_iXMK_zEp3YjvSn4(MaterialChannel _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.Key.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004683));
		}

		internal bool _0023_003DzO_00240sQpUtWy_0024jqnKna5doItvo_0024uuY(MaterialChannel _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.Key.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004923));
		}

		internal bool _0023_003Dz5ifDDochyGxQqA5rpD1z7BKiXvGK(IMaterialParameter _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Name.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004883));
		}

		internal bool _0023_003DzwTrXgheG3pf9ZXj1sUP0Vf1OcDRM(IMaterialParameter _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Name.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004874));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz5sKXm5rhr59eUyByYsUtm64LOhN6FR_OuA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004864);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzABva_z9jvKyh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz6jO4SQA2QhtX;

	public string ParsingMaterialsText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5sKXm5rhr59eUyByYsUtm64LOhN6FR_OuA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5sKXm5rhr59eUyByYsUtm64LOhN6FR_OuA_003D_003D = value;
		}
	}

	public override supportedLinearUnitsType SupportedLinearUnitsType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public ReadGLTF(string filePath)
	{
		base.Path = System.IO.Path.GetDirectoryName(filePath);
		base.FilePath = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dzz6JDud_0024u1ojF(filePath, _0023_003Dzmyw8uNw_003D: true);
	}

	public ReadGLTF(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzDYPoUc_0024QFtfu(progress, ct);
		UpdateProgressTo100(base.ParsingText, progress);
	}

	private void _0023_003DzDYPoUc_0024QFtfu(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			base.Blocks.Clear();
			StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D);
			ReadSettings settings = new ReadSettings
			{
				Validation = ValidationMode.Skip
			};
			ModelRoot modelRoot = ((base.FilePath != null) ? ModelRoot.Load(base.FilePath, settings) : ModelRoot.ReadGLB(base.Stream, settings));
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
			_0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(modelRoot.LogicalMaterials, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			_0023_003DzABva_z9jvKyh = 0;
			_0023_003Dz6jO4SQA2QhtX = modelRoot.LogicalNodes.Count;
			bool flag = modelRoot.LogicalScenes.Count == 1 && modelRoot.LogicalScenes[0].VisualChildren.Count() == 1 && modelRoot.LogicalScenes[0].VisualChildren.ElementAt(0).Mesh == null;
			string text = null;
			if (flag)
			{
				text = string.Concat(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(DateTime.Now.ToString())));
				base.Blocks.Add(new Block(text));
				base.Blocks.SetRootBlock(text);
			}
			else
			{
				base.Blocks._0023_003Dz2tUjc04_003D();
			}
			foreach (Scene logicalScene in modelRoot.LogicalScenes)
			{
				_0023_003DzRIemS4o_003D(logicalScene, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			}
			if (flag)
			{
				BlockReference blockReference = (BlockReference)base.Blocks[text].Entities[0];
				base.Blocks.SetRootBlock(blockReference.BlockName);
				base.Blocks.Remove(text);
				foreach (Entity entity in base.Blocks.RootBlock.Entities)
				{
					entity.TransformBy(blockReference.Transformation);
				}
			}
			RotateEverythingAroundX();
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

	private void _0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(IReadOnlyList<SharpGLTF.Schema2.Material> _0023_003Dz82RVFLukNM0GhVqkag_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		foreach (SharpGLTF.Schema2.Material item in _0023_003Dz82RVFLukNM0GhVqkag_003D_003D)
		{
			string text = (string.IsNullOrEmpty(item.Name) ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004825), item.LogicalIndex) : item.Name);
			try
			{
				Material material = new Material(text);
				byte[] array = item.Channels.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzd7rvFGoSdZ58TX_5vOujJ1vVFULg).Texture?.PrimaryImage?.Content.Content.ToArray();
				Vector4? vector = item.Channels.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzYcbpB8q_WBoq_iXMK_zEp3YjvSn4).Color;
				MaterialChannel? materialChannel = item.Channels.FirstOrDefault((MaterialChannel _0023_003Dzt_m8zV0_003D) => _0023_003Dzt_m8zV0_003D.Key.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004923)));
				if (array != null)
				{
					material.TextureImage = array;
				}
				if (vector.HasValue)
				{
					Color diffuse = Color.FromArgb((int)(vector.Value.W * 255f), (int)(vector.Value.X * 255f), (int)(vector.Value.Y * 255f), (int)(vector.Value.Z * 255f));
					material.Diffuse = diffuse;
				}
				if (materialChannel.HasValue)
				{
					_ = (float)(materialChannel.Value.Parameters.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz5ifDDochyGxQqA5rpD1z7BKiXvGK)?.Value ?? ((object)0));
					float num = (float)(materialChannel.Value.Parameters.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzwTrXgheG3pf9ZXj1sUP0Vf1OcDRM)?.Value ?? ((object)0));
					material.Shininess = (float)(1.66 * Math.Log10(num + 1f));
				}
				if (!UpdateProgressAndCheckCancelled(item.LogicalIndex, _0023_003Dz82RVFLukNM0GhVqkag_003D_003D.Count, ParsingMaterialsText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					break;
				}
				base.Materials.TryAdd(material);
			}
			catch (Exception ex)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005558) + text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + ex.Message);
				throw;
			}
		}
	}

	private void _0023_003DzRIemS4o_003D(Scene _0023_003DzI_IQ4m0_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		foreach (Node visualChild in _0023_003DzI_IQ4m0_003D.VisualChildren)
		{
			List<Entity>[] _0023_003DzIIuKCj1NK1q = new List<Entity>[_0023_003DzI_IQ4m0_003D.LogicalParent.LogicalMeshes.Count];
			_0023_003DzDmukAG_0024soutX(visualChild, base.Blocks.RootBlock, _0023_003DzIIuKCj1NK1q, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
	}

	private bool _0023_003Dz20gGgNrTGHvMX9X0kb_kA4E_003D(Node _0023_003DzRXJWLHs_003D)
	{
		if (_0023_003DzRXJWLHs_003D.LocalMatrix.IsIdentity)
		{
			return string.IsNullOrEmpty(_0023_003DzRXJWLHs_003D.Name);
		}
		return false;
	}

	private void _0023_003DzDmukAG_0024soutX(Node _0023_003DzRXJWLHs_003D, Block _0023_003Dzalvl9z8_003D, List<Entity>[] _0023_003DzIIuKCj1NK1q5, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		string text = _0023_003DzRXJWLHs_003D.Name ?? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005523), _0023_003DzRXJWLHs_003D.LogicalIndex);
		if (base.Blocks.TryGetValue(text, out var _))
		{
			text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005505), text, _0023_003DzRXJWLHs_003D.LogicalIndex);
		}
		Block block = _0023_003Dzalvl9z8_003D;
		Block block2 = null;
		if (_0023_003DzRXJWLHs_003D.Mesh != null)
		{
			if (!_0023_003Dz20gGgNrTGHvMX9X0kb_kA4E_003D(_0023_003DzRXJWLHs_003D))
			{
				block2 = _0023_003DzF_0024H_GSQ_003D(_0023_003DzRXJWLHs_003D, _0023_003Dzalvl9z8_003D, text);
				block = block2;
			}
			try
			{
				if (_0023_003DzIIuKCj1NK1q5[_0023_003DzRXJWLHs_003D.Mesh.LogicalIndex] == null)
				{
					_0023_003DzIIuKCj1NK1q5[_0023_003DzRXJWLHs_003D.Mesh.LogicalIndex] = _0023_003DzdGQvDPEWTAYN(_0023_003DzRXJWLHs_003D.Mesh);
				}
				block.Entities.AddRange(_0023_003DzIIuKCj1NK1q5[_0023_003DzRXJWLHs_003D.Mesh.LogicalIndex]);
			}
			catch (Exception ex)
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005491), _0023_003DzRXJWLHs_003D.LogicalIndex, ex.Message));
			}
		}
		if (!UpdateProgressAndCheckCancelled(++_0023_003DzABva_z9jvKyh, _0023_003Dz6jO4SQA2QhtX, base.ParsingBlocksText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D) || !_0023_003DzRXJWLHs_003D.VisualChildren.Any())
		{
			return;
		}
		if (block2 == null)
		{
			block2 = _0023_003DzF_0024H_GSQ_003D(_0023_003DzRXJWLHs_003D, _0023_003Dzalvl9z8_003D, text);
		}
		foreach (Node visualChild in _0023_003DzRXJWLHs_003D.VisualChildren)
		{
			_0023_003DzDmukAG_0024soutX(visualChild, block2, _0023_003DzIIuKCj1NK1q5, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
	}

	private Block _0023_003DzF_0024H_GSQ_003D(Node _0023_003DzRXJWLHs_003D, Block _0023_003Dzalvl9z8_003D, string _0023_003DznkMU43c_003D)
	{
		Block block = new Block(_0023_003DznkMU43c_003D);
		base.Blocks.Add(block);
		BlockReference item = _0023_003Dzf3zXHzk_003D(_0023_003DzRXJWLHs_003D, _0023_003DznkMU43c_003D);
		_0023_003Dzalvl9z8_003D.Entities.Add(item);
		return block;
	}

	private BlockReference _0023_003Dzf3zXHzk_003D(Node _0023_003DzjomPQW0_003D, string _0023_003DznkMU43c_003D)
	{
		BlockReference blockReference = new BlockReference(_0023_003DznkMU43c_003D);
		blockReference.Transformation = new Transformation(new double[16]
		{
			_0023_003DzjomPQW0_003D.LocalMatrix.M11,
			_0023_003DzjomPQW0_003D.LocalMatrix.M12,
			_0023_003DzjomPQW0_003D.LocalMatrix.M13,
			_0023_003DzjomPQW0_003D.LocalMatrix.M14,
			_0023_003DzjomPQW0_003D.LocalMatrix.M21,
			_0023_003DzjomPQW0_003D.LocalMatrix.M22,
			_0023_003DzjomPQW0_003D.LocalMatrix.M23,
			_0023_003DzjomPQW0_003D.LocalMatrix.M24,
			_0023_003DzjomPQW0_003D.LocalMatrix.M31,
			_0023_003DzjomPQW0_003D.LocalMatrix.M32,
			_0023_003DzjomPQW0_003D.LocalMatrix.M33,
			_0023_003DzjomPQW0_003D.LocalMatrix.M34,
			_0023_003DzjomPQW0_003D.LocalMatrix.M41,
			_0023_003DzjomPQW0_003D.LocalMatrix.M42,
			_0023_003DzjomPQW0_003D.LocalMatrix.M43,
			_0023_003DzjomPQW0_003D.LocalMatrix.M44
		}, byRow: false);
		blockReference.TranslationID = new TranslationIdentifier(_0023_003DzjomPQW0_003D.LogicalIndex, _0023_003DzjomPQW0_003D.Extras?.ToJsonString());
		return blockReference;
	}

	private List<Entity> _0023_003DzdGQvDPEWTAYN(SharpGLTF.Schema2.Mesh _0023_003DzElED8mGILuBt)
	{
		List<Entity> list = new List<Entity>();
		List<MeshPrimitive> list2 = new List<MeshPrimitive>();
		foreach (MeshPrimitive primitive in _0023_003DzElED8mGILuBt.Primitives)
		{
			switch (primitive.DrawPrimitiveType)
			{
			case PrimitiveType.POINTS:
				_0023_003DzU3Uf5h0_003D(primitive, list, _0023_003DzElED8mGILuBt.Name);
				break;
			case PrimitiveType.LINES:
				_0023_003DzPhoZ010_003D(primitive, list, _0023_003DzElED8mGILuBt.Name);
				break;
			case PrimitiveType.TRIANGLES:
			{
				devDept.Eyeshot.Entities.Mesh.natureType natureType = _0023_003DzZTr16fkQpUZHJpROCQ_003D_003D(primitive);
				if (natureType == devDept.Eyeshot.Entities.Mesh.natureType.Smooth)
				{
					list2.Add(primitive);
					break;
				}
				_0023_003Dz2c0mzPQ_003D(new MeshPrimitive[1] { primitive }, list, natureType, _0023_003DzElED8mGILuBt.Name, _0023_003DzElED8mGILuBt.Extras?.ToString());
				break;
			}
			}
		}
		_0023_003Dz2c0mzPQ_003D(list2, list, devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth, _0023_003DzElED8mGILuBt.Name, _0023_003DzElED8mGILuBt.Extras?.ToString());
		return list;
	}

	private void _0023_003DzU3Uf5h0_003D(MeshPrimitive _0023_003DzIBX6nBGZUJRL, List<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzrr_0024BW5A_003D)
	{
		Vector3[] array = _0023_003DzIBX6nBGZUJRL.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
		Vector4[] array2 = _0023_003DzIBX6nBGZUJRL.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005685))?.AsColorArray().ToArray();
		int[] array3 = _0023_003DzIBX6nBGZUJRL.GetPointIndices().ToArray();
		float[] array4 = new float[3 * array3.Length];
		byte[] array5 = new byte[4 * array3.Length];
		bool flag = false;
		for (int i = 0; i < array3.Length; i++)
		{
			Vector3 vector = array[array3[i]];
			array4[3 * i] = vector.X;
			array4[3 * i + 1] = vector.Y;
			array4[3 * i + 2] = vector.Z;
			if (array2 != null && array2.Length != 0)
			{
				Vector4 vector2 = array2[array3[i]];
				array5[4 * i] = (byte)(vector2.X * 255f);
				array5[4 * i + 1] = (byte)(vector2.Y * 255f);
				array5[4 * i + 2] = (byte)(vector2.Z * 255f);
				array5[4 * i + 3] = (byte)(vector2.W * 255f);
			}
			else if (_0023_003DzIBX6nBGZUJRL.Material != null)
			{
				Color diffuse = base.Materials[_0023_003DzIBX6nBGZUJRL.Material.Name].Diffuse;
				array5[4 * i] = diffuse.R;
				array5[4 * i + 1] = diffuse.G;
				array5[4 * i + 2] = diffuse.B;
				array5[4 * i + 3] = diffuse.A;
			}
			if (array5[4 * i + 3] < byte.MaxValue)
			{
				flag = true;
			}
		}
		if (flag)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005667));
		}
		FastPointCloud item = new FastPointCloud(array4, array5)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = Color.FromArgb(flag ? 254 : 255, Color.White),
			TranslationID = new TranslationIdentifier(_0023_003DzIBX6nBGZUJRL.LogicalIndex, _0023_003Dzrr_0024BW5A_003D),
			EntityData = _0023_003DzIBX6nBGZUJRL.Extras?.ToJsonString()
		};
		_0023_003Dzv7xH9gk_003D.Add(item);
	}

	private void _0023_003DzPhoZ010_003D(MeshPrimitive _0023_003Dz6r7sk8u8KMgK, List<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzrr_0024BW5A_003D)
	{
		Vector3[] array = _0023_003Dz6r7sk8u8KMgK.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
		Vector4[] array2 = _0023_003Dz6r7sk8u8KMgK.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005685))?.AsColorArray().ToArray();
		(int, int)[] array3 = _0023_003Dz6r7sk8u8KMgK.GetLineIndices().ToArray();
		for (int i = 0; i < array3.Length; i++)
		{
			Vector3 vector = array[array3[i].Item1];
			Vector3 vector2 = array[array3[i].Item2];
			Line line = new Line(vector.X, vector.Y, vector.Z, vector2.X, vector2.Y, vector2.Z);
			if (array2 != null && array2.Length != 0)
			{
				Vector4 vector3 = array2[array3[i].Item1];
				line.ColorMethod = colorMethodType.byEntity;
				line.Color = Color.FromArgb((int)(vector3.W * 255f), (int)(vector3.X * 255f), (int)(vector3.Y * 255f), (int)(vector3.Z * 255f));
			}
			else if (_0023_003Dz6r7sk8u8KMgK.Material != null)
			{
				line.ColorMethod = colorMethodType.byEntity;
				line.Color = base.Materials[_0023_003Dz6r7sk8u8KMgK.Material.Name].Diffuse;
			}
			line.TranslationID = new TranslationIdentifier(_0023_003Dz6r7sk8u8KMgK.LogicalIndex, string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005277), i));
			line.EntityData = _0023_003Dz6r7sk8u8KMgK.Extras?.ToJsonString();
			_0023_003Dzv7xH9gk_003D.Add(line);
		}
	}

	private devDept.Eyeshot.Entities.Mesh.natureType _0023_003DzZTr16fkQpUZHJpROCQ_003D_003D(MeshPrimitive _0023_003DzrFwzsDvdgir6)
	{
		_0023_003DzrFwzsDvdgir6.GetTriangleIndices().Count();
		_ = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.Count;
		_ = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005234))?.Count;
		int? num = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005685))?.Count;
		if (_0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005245))?.Count > 0)
		{
			return devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth;
		}
		if (num > 0)
		{
			return devDept.Eyeshot.Entities.Mesh.natureType.MulticolorSmooth;
		}
		return devDept.Eyeshot.Entities.Mesh.natureType.Smooth;
	}

	private devDept.Eyeshot.Entities.Mesh _0023_003DzX2UW58R6hH_0024RIq_0024XJQ_003D_003D(MeshPrimitive _0023_003DzrFwzsDvdgir6)
	{
		Vector3[] array = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
		Vector3[] array2 = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005234))?.AsVector3Array().ToArray();
		(int, int, int)[] array3 = _0023_003DzrFwzsDvdgir6.GetTriangleIndices().ToArray();
		devDept.Eyeshot.Entities.Mesh mesh = new devDept.Eyeshot.Entities.Mesh(array.Length, array3.Length, devDept.Eyeshot.Entities.Mesh.natureType.Smooth)
		{
			Normals = ((array2 != null) ? new Vector3D[array2.Length] : null)
		};
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 vector = array[i];
			mesh.Vertices[i] = new Point3D(vector.X, vector.Y, vector.Z);
			if (array2 != null)
			{
				mesh.Normals[i] = new Vector3D(array2[i].X, array2[i].Y, array2[i].Z);
			}
		}
		for (int j = 0; j < array3.Length; j++)
		{
			(int, int, int) tuple = array3[j];
			if (array2 == null)
			{
				mesh.Triangles[j] = new SmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3);
			}
			else
			{
				mesh.Triangles[j] = new SmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item3);
			}
		}
		mesh.MaterialName = _0023_003DzrFwzsDvdgir6.Material?.Name;
		return mesh;
	}

	private devDept.Eyeshot.Entities.Mesh _0023_003DznCw05vZxVCiwgIYKmw_003D_003D(IList<MeshPrimitive> _0023_003DzYHmBe7R_0024Rdkk)
	{
		List<Point3D> list = new List<Point3D>();
		List<Vector3D> list2 = new List<Vector3D>();
		List<IndexTriangle> list3 = new List<IndexTriangle>();
		Vector4 defaultColor = ReadFileAsync.DEFAULT_COLOR._0023_003DzjBHxFu7sXBku();
		foreach (MeshPrimitive item in _0023_003DzYHmBe7R_0024Rdkk)
		{
			int count = list.Count;
			Vector3[] array = item.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
			Vector3[] array2 = item.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005234))?.AsVector3Array().ToArray();
			(int, int, int)[] array3 = item.GetTriangleIndices().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 vector = array[i];
				list.Add(new Point3D(vector.X, vector.Y, vector.Z));
				if (array2 != null)
				{
					list2.Add(new Vector3D(array2[i].X, array2[i].Y, array2[i].Z));
				}
			}
			Color color = item.Material.GetDiffuseColor(defaultColor)._0023_003DzwZbJhvk_003D();
			for (int j = 0; j < array3.Length; j++)
			{
				(int, int, int) tuple = array3[j];
				if (array2 == null)
				{
					list3.Add(new ColorSmoothTriangle(tuple.Item1 + count, tuple.Item2 + count, tuple.Item3 + count, color));
				}
				else
				{
					list3.Add(new ColorSmoothTriangle(tuple.Item1 + count, tuple.Item2 + count, tuple.Item3 + count, tuple.Item1 + count, tuple.Item2 + count, tuple.Item3 + count, color));
				}
			}
		}
		devDept.Eyeshot.Entities.Mesh mesh = new devDept.Eyeshot.Entities.Mesh(list, list3);
		if (list2.Count > 0)
		{
			mesh.Normals = list2.ToArray();
		}
		return mesh;
	}

	private devDept.Eyeshot.Entities.Mesh _0023_003DzK9yTD3QUneFt65VWcSIDIXptrv1r(MeshPrimitive _0023_003DzrFwzsDvdgir6)
	{
		Vector3[] array = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
		Vector3[] array2 = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005234))?.AsVector3Array().ToArray();
		Vector4[] array3 = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005685))?.AsColorArray().ToArray();
		(int, int, int)[] array4 = _0023_003DzrFwzsDvdgir6.GetTriangleIndices().ToArray();
		devDept.Eyeshot.Entities.Mesh mesh = new devDept.Eyeshot.Entities.Mesh(array.Length, array4.Length, devDept.Eyeshot.Entities.Mesh.natureType.MulticolorSmooth)
		{
			Normals = ((array2 != null) ? new Vector3D[array2.Length] : null)
		};
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 vector = array[i];
			Color color = Color.FromArgb((int)(array3[i].W * 255f), (int)(array3[i].X * 255f), (int)(array3[i].Y * 255f), (int)(array3[i].Z * 255f));
			mesh.Vertices[i] = new PointRGB(vector.X, vector.Y, vector.Z, color);
			if (array2 != null)
			{
				mesh.Normals[i] = new Vector3D(array2[i].X, array2[i].Y, array2[i].Z);
			}
		}
		for (int j = 0; j < array4.Length; j++)
		{
			(int, int, int) tuple = array4[j];
			if (array2 == null)
			{
				mesh.Triangles[j] = new SmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3);
			}
			else
			{
				mesh.Triangles[j] = new SmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item3);
			}
		}
		mesh.MaterialName = _0023_003DzrFwzsDvdgir6.Material?.Name;
		return mesh;
	}

	private devDept.Eyeshot.Entities.Mesh _0023_003Dz3kEV1_0024rVVULLhS6VLQ_003D_003D(MeshPrimitive _0023_003DzrFwzsDvdgir6)
	{
		Vector3[] array = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005448))?.AsVector3Array().ToArray();
		Vector3[] array2 = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005234))?.AsVector3Array().ToArray();
		Vector2[] array3 = _0023_003DzrFwzsDvdgir6.GetVertexAccessor(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005245))?.AsVector2Array().ToArray();
		(int, int, int)[] array4 = _0023_003DzrFwzsDvdgir6.GetTriangleIndices().ToArray();
		devDept.Eyeshot.Entities.Mesh mesh = new devDept.Eyeshot.Entities.Mesh(array.Length, array4.Length, devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth)
		{
			Normals = ((array2 != null) ? new Vector3D[array2.Length] : null)
		};
		mesh.TextureCoords = new PointF[array3.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 vector = array[i];
			mesh.Vertices[i] = new Point3D(vector.X, vector.Y, vector.Z);
			mesh.TextureCoords[i] = new PointF(array3[i].X, 1f - array3[i].Y);
			if (array2 != null)
			{
				mesh.Normals[i] = new Vector3D(array2[i].X, array2[i].Y, array2[i].Z);
			}
		}
		for (int j = 0; j < array4.Length; j++)
		{
			(int, int, int) tuple = array4[j];
			if (array2 == null)
			{
				mesh.Triangles[j] = new RichSmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3);
			}
			else
			{
				mesh.Triangles[j] = new RichSmoothTriangle(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item1, tuple.Item2, tuple.Item3);
			}
		}
		mesh.MaterialName = _0023_003DzrFwzsDvdgir6.Material?.Name;
		return mesh;
	}

	private void _0023_003Dz2c0mzPQ_003D(IList<MeshPrimitive> _0023_003DzrFwzsDvdgir6, List<Entity> _0023_003Dzv7xH9gk_003D, devDept.Eyeshot.Entities.Mesh.natureType _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D, string _0023_003Dzrr_0024BW5A_003D, string _0023_003DzGhyL7osTCA_00240)
	{
		if (_0023_003DzrFwzsDvdgir6.Count != 0)
		{
			devDept.Eyeshot.Entities.Mesh mesh = null;
			mesh = _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D switch
			{
				devDept.Eyeshot.Entities.Mesh.natureType.Smooth => _0023_003DzX2UW58R6hH_0024RIq_0024XJQ_003D_003D(_0023_003DzrFwzsDvdgir6[0]), 
				devDept.Eyeshot.Entities.Mesh.natureType.MulticolorSmooth => _0023_003DzK9yTD3QUneFt65VWcSIDIXptrv1r(_0023_003DzrFwzsDvdgir6[0]), 
				devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth => _0023_003Dz3kEV1_0024rVVULLhS6VLQ_003D_003D(_0023_003DzrFwzsDvdgir6[0]), 
				devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth => (_0023_003DzrFwzsDvdgir6.Count != 1) ? _0023_003DznCw05vZxVCiwgIYKmw_003D_003D(_0023_003DzrFwzsDvdgir6) : _0023_003DzX2UW58R6hH_0024RIq_0024XJQ_003D_003D(_0023_003DzrFwzsDvdgir6[0]), 
				_ => throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005232), _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D)), 
			};
			mesh.ColorMethod = colorMethodType.byEntity;
			mesh.TranslationID = new TranslationIdentifier(_0023_003Dzrr_0024BW5A_003D);
			mesh.EntityData = _0023_003DzGhyL7osTCA_00240;
			_0023_003Dzv7xH9gk_003D.Add(mesh);
		}
	}
}
