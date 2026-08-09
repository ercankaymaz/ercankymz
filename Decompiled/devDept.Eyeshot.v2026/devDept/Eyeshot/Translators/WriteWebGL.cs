using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteWebGL : WriteFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_gyQhjMISgFN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color? _0023_003Dzq24tZCmNrra_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzMeUW4ys2yBDJ;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public WriteWebGL(IWorkspace workspace, string filePath, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(workspace.Document, filePath, selectedOnly, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(Document document, string filePath, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(IWorkspace workspace, Stream stream, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(workspace.Document, stream, selectedOnly, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(Document document, Stream stream, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(IWorkspace workspace, string filePath, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(workspace.Document, filePath, deviation, selectedOnly, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(Document document, string filePath, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath, deviation, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(IWorkspace workspace, Stream stream, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(workspace.Document, stream, deviation, selectedOnly, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(Document document, Stream stream, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream, deviation, pageBackgroundColor, htmlTemplate)
	{
	}

	public WriteWebGL(WriteParamsWithMaterials writeParams, string filePath, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(writeParams, filePath)
	{
		_0023_003DztGdcVOA_003D(writeParams, 0.0, pageBackgroundColor, htmlTemplate);
	}

	public WriteWebGL(WriteParamsWithMaterials writeParams, Stream stream, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(writeParams, stream)
	{
		_0023_003DztGdcVOA_003D(writeParams, 0.0, pageBackgroundColor, htmlTemplate);
	}

	public WriteWebGL(WriteParamsWithMaterials writeParams, string filePath, double deviation, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(writeParams, filePath)
	{
		_0023_003DztGdcVOA_003D(writeParams, deviation, pageBackgroundColor, htmlTemplate);
	}

	public WriteWebGL(WriteParamsWithMaterials writeParams, Stream stream, double deviation, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(writeParams, stream)
	{
		_0023_003DztGdcVOA_003D(writeParams, deviation, pageBackgroundColor, htmlTemplate);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteWebGL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, string filePath, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(entList, layerList, blockDict, filePath)
	{
		_0023_003DztGdcVOA_003D(matDict, selectedOnly, 0.0, pageBackgroundColor, htmlTemplate);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteWebGL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, Stream stream, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(entList, layerList, blockDict, stream)
	{
		_0023_003DztGdcVOA_003D(matDict, selectedOnly, 0.0, pageBackgroundColor, htmlTemplate);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteWebGL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, string filePath, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(entList, layerList, blockDict, filePath)
	{
		_0023_003DztGdcVOA_003D(matDict, selectedOnly, deviation, pageBackgroundColor, htmlTemplate);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteWebGL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, Stream stream, double deviation, bool selectedOnly = false, Color? pageBackgroundColor = null, string htmlTemplate = null)
		: base(entList, layerList, blockDict, stream)
	{
		_0023_003DztGdcVOA_003D(matDict, selectedOnly, deviation, pageBackgroundColor, htmlTemplate);
	}

	private void _0023_003DztGdcVOA_003D(IDictionary<string, Material> _0023_003Dz50RKVBfLAo0H, bool _0023_003Dz9rsu4TwhLBvn, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, Color? _0023_003DzuFWc2hSRgAAp, string _0023_003DzohyB38VxsNnz)
	{
		MaterialKeyedCollection materialKeyedCollection = new MaterialKeyedCollection();
		foreach (KeyValuePair<string, Material> item in _0023_003Dz50RKVBfLAo0H)
		{
			materialKeyedCollection.Add(item.Value);
		}
		selectedOnly = _0023_003Dz9rsu4TwhLBvn;
		_0023_003DztGdcVOA_003D(materialKeyedCollection, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003DzuFWc2hSRgAAp, _0023_003DzohyB38VxsNnz);
	}

	private void _0023_003DztGdcVOA_003D(WriteParamsWithMaterials _0023_003DzX6XgSWkagNXc, double _0023_003Dzm0CYiiE_003D, Color? _0023_003DzSvobsfM_003D, string _0023_003DzohyB38VxsNnz)
	{
		_0023_003DztGdcVOA_003D(_0023_003DzX6XgSWkagNXc.Materials, _0023_003Dzm0CYiiE_003D, _0023_003DzSvobsfM_003D, _0023_003DzohyB38VxsNnz);
	}

	private void _0023_003DztGdcVOA_003D(MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, double _0023_003Dzm0CYiiE_003D, Color? _0023_003DzSvobsfM_003D, string _0023_003DzohyB38VxsNnz)
	{
		base.Deviation = _0023_003Dzm0CYiiE_003D;
		_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = new MaterialKeyedCollection(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
		_0023_003Dzq24tZCmNrra_ = _0023_003DzSvobsfM_003D;
		_0023_003Dz_gyQhjMISgFN = _0023_003DzohyB38VxsNnz;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D(ref _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		try
		{
			_0023_003DzznnbUuA_003D(progress, ct);
			UpdateProgressTo100(base.ComposingText, progress);
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
		}
	}

	private void _0023_003DzznnbUuA_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		string text = _0023_003Dz_gyQhjMISgFN;
		if (string.IsNullOrEmpty(text))
		{
			text = _0023_003DzZfWSk3KwxsvIw8xu6yP7kfBCKxK7._0023_003DzOz1QEnNxEX_0024_0024IR6JKQ_003D_003D();
		}
		else
		{
			try
			{
				text = File.ReadAllText(text);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015876) + ex.Message);
			}
		}
		TextWriter textWriter = new StreamWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write), Encoding.ASCII);
		SetWriter(textWriter);
		int num = 0;
		IList<Entity> list = GetEntities();
		int count = list.Count;
		RegenParams regenParams = new RegenParams(base.Deviation, blocks);
		regenParams.SkipTexts = true;
		List<Entity> list2 = new List<Entity>();
		foreach (Entity item in list)
		{
			if (!(item is Text))
			{
				if (item.RegenMode == regenType.RegenAndCompile)
				{
					item.Regen(regenParams);
				}
				list2.Add(item);
			}
		}
		Utility._0023_003DzEtuso7_p35ZOEjCHBg_003D_003D(list2, layers, out var _0023_003DzDPcjoBJLcqli, out var _0023_003Dz_0024N_0024yKptW9BoC, out var _0023_003DzZkSIjE9P7t5u);
		if (count == 0 || _0023_003DzZkSIjE9P7t5u)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015852));
			return;
		}
		Point3D point3D = Point3D.MidPoint(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		Size3D size3D = new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		double num2 = _0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzO8EKqG0_003D.Diagonal / size3D.Diagonal;
		Transformation _0023_003Dz9ZUzIX4xmsyA = new Rotation(Utility.DegToRad(-90.0), Vector3D.AxisY, Point3D.Origin) * new Rotation(Utility.DegToRad(-90.0), Vector3D.AxisX, Point3D.Origin) * new Scaling(num2, num2, num2) * new Translation(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015548), LicenseManager._0023_003DzUcMv_pQ_003D(out var _, out var _, _0023_003Dzwan3TY08r56P: true, _0023_003DzCBmgGLZOgR_0024E: true)));
		_0023_003DzMeUW4ys2yBDJ = new _0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D(stringBuilder, _0023_003Dz9ZUzIX4xmsyA, layers, _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D, base.Deviation, base.Angle, blocks, new Dictionary<Material, int>());
		GfxAttributesRendered other = (GfxAttributesRendered)_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Clone();
		for (int i = 0; i < count; i++)
		{
			Entity entity = list[i];
			if (IsVisible(entity, out var layer))
			{
				_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Assign(other);
				if (layer != null)
				{
					_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Propagate(entity, layer, _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D);
				}
				try
				{
					stringBuilder.Append(Environment.NewLine);
					_0023_003Dz5v26jTE_003D(entity);
				}
				catch (Exception ex2)
				{
					log.AppendLine(ex2.Message);
				}
			}
			if (!UpdateProgressAndCheckCancelled(++num, count, base.ComposingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		UpdateProgressTo100(base.ComposingText, _0023_003DzmHS7frs_003D);
		string text2 = text.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015491), _0023_003DzZfWSk3KwxsvIw8xu6yP7kfBCKxK7._0023_003DzPCX_WT0p6k2XbtzaAA_003D_003D()).Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015457), stringBuilder.ToString());
		if (_0023_003Dzq24tZCmNrra_.HasValue && !_0023_003Dzq24tZCmNrra_.Value.IsEmpty)
		{
			text2 = text2.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015426), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015438) + _0023_003DzPFhno7FNyyDO(_0023_003Dzq24tZCmNrra_.Value) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951434));
		}
		textWriter.Write(text2);
	}

	private string _0023_003DzPFhno7FNyyDO(Color _0023_003Dz1MMYB1g_003D)
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) + _0023_003Dz1MMYB1g_003D.R.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011905)) + _0023_003Dz1MMYB1g_003D.G.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011905)) + _0023_003Dz1MMYB1g_003D.B.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011905));
	}

	private void _0023_003Dz8VL9aMphUV0A_DWqMQ_003D_003D(Brep.Face[] _0023_003DzEtn4dIEPKCsi, Entity _0023_003Dzalvl9z8_003D, _0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D _0023_003DzmPmPjCPqZ3T3)
	{
		bool _0023_003DzPzO_0024GUk_003D = _0023_003DzmPmPjCPqZ3T3._0023_003DzyZN9fhDsHlGQ();
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			if (i == 1)
			{
				_0023_003DzmPmPjCPqZ3T3._0023_003DzSiTufa33KU54(_0023_003DzPzO_0024GUk_003D: true);
			}
			Brep.Face face = _0023_003DzEtn4dIEPKCsi[i];
			float[] pointArray = face.Tessellation.PointArray;
			if (pointArray == null || pointArray.Length == 0)
			{
				continue;
			}
			double _0023_003Dzm0CYiiE_003D = _0023_003DzmPmPjCPqZ3T3._0023_003Dzm0CYiiE_003D;
			double _0023_003Dz0mZ4_0024fFWxsTX = _0023_003DzmPmPjCPqZ3T3._0023_003Dz0mZ4_0024fFWxsTX;
			string materialName = (_0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.MaterialName = face.MaterialName);
			_0023_003DzmPmPjCPqZ3T3._0023_003Dzm0CYiiE_003D = 0.0;
			_0023_003DzmPmPjCPqZ3T3._0023_003Dz0mZ4_0024fFWxsTX = 0.0;
			_0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.MaterialName = face.MaterialName;
			Mesh mesh = Utility._0023_003DzqTukDnG3QxvA22yeWQ_003D_003D(face.Tessellation.GetPoints(), face.Tessellation.GetTriangles(), Mesh.natureType.RichSmooth, face.TextureOffsetU, face.TextureScaleU, face.TextureOffsetV, face.TextureScaleV, face.TextureRotationAngle, _0023_003Dzalvl9z8_003D, face.Color, _0023_003DzTJ4ZjnpzOkzX: false, face.MaterialName, null);
			if (face.Color.HasValue)
			{
				for (int j = 0; j < mesh.Vertices.Length; j++)
				{
					Point3D point3D = mesh.Vertices[j];
					mesh.Vertices[j] = new PointRGB(point3D.X, point3D.Y, point3D.Z, face.Color.Value);
				}
				mesh.Color = face.Color.Value;
			}
			_0023_003Dz5v26jTE_003D(mesh);
			_0023_003DzmPmPjCPqZ3T3._0023_003Dzm0CYiiE_003D = _0023_003Dzm0CYiiE_003D;
			_0023_003DzmPmPjCPqZ3T3._0023_003Dz0mZ4_0024fFWxsTX = _0023_003Dz0mZ4_0024fFWxsTX;
			_0023_003DzmPmPjCPqZ3T3._0023_003DzqP5lTto_003D.MaterialName = materialName;
		}
		_0023_003DzmPmPjCPqZ3T3._0023_003DzSiTufa33KU54(_0023_003DzPzO_0024GUk_003D);
	}

	private void _0023_003Dz5v26jTE_003D(Entity _0023_003Dz9j7EUB0_003D)
	{
		Mesh mesh = new Mesh();
		if (!(_0023_003Dz9j7EUB0_003D is Bar) && !(_0023_003Dz9j7EUB0_003D is Joint))
		{
			if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
			{
				if (!(_0023_003Dz9j7EUB0_003D is FastMesh fastMesh))
				{
					if (!(_0023_003Dz9j7EUB0_003D is FastPointCloud fastPointCloud))
					{
						if (!(_0023_003Dz9j7EUB0_003D is FemMesh femMesh))
						{
							if (!(_0023_003Dz9j7EUB0_003D is Mesh mesh2))
							{
								if (!(_0023_003Dz9j7EUB0_003D is Brep brep))
								{
									if (!(_0023_003Dz9j7EUB0_003D is Surface surface))
									{
										if (!(_0023_003Dz9j7EUB0_003D is Picture _0023_003DzWXcU6Os_003D))
										{
											if (!(_0023_003Dz9j7EUB0_003D is PointCloud) && !(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Point))
											{
												if (!(_0023_003Dz9j7EUB0_003D is Quad quad))
												{
													if (!(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Region region))
													{
														if (!(_0023_003Dz9j7EUB0_003D is Solid solid))
														{
															if (!(_0023_003Dz9j7EUB0_003D is Triangle triangle))
															{
																if (!(_0023_003Dz9j7EUB0_003D is Leader) && !(_0023_003Dz9j7EUB0_003D is Balloon) && !(_0023_003Dz9j7EUB0_003D is Dimension) && !(_0023_003Dz9j7EUB0_003D is SectionLine) && !(_0023_003Dz9j7EUB0_003D is Text) && !(_0023_003Dz9j7EUB0_003D is Hatch) && !(_0023_003Dz9j7EUB0_003D is Table))
																{
																	_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzniXL2KDLitBX(_0023_003DzMeUW4ys2yBDJ, _0023_003Dz9j7EUB0_003D);
																}
															}
															else
															{
																_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003Dzkyv9axSJ96BJ(_0023_003DzMeUW4ys2yBDJ, triangle.Vertices, new Vector3D[1] { triangle.Normal }, new IndexTriangle[1]
																{
																	new IndexTriangle(0, 1, 2)
																}, null);
															}
														}
														else
														{
															mesh = solid.ConvertToMesh();
															mesh.Regen(0.0);
															_0023_003Dz5v26jTE_003D(mesh);
														}
													}
													else
													{
														mesh = region.ConvertToMesh(_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D, 0.0, Mesh.natureType.Plain, weld: false);
														mesh.CopyAttributes(region);
														mesh.Regen(0.0);
														_0023_003Dz5v26jTE_003D(mesh);
													}
												}
												else
												{
													_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003Dzkyv9axSJ96BJ(_0023_003DzMeUW4ys2yBDJ, quad.Vertices, new Vector3D[2] { quad.Normal, quad.Normal }, new IndexTriangle[2]
													{
														new IndexTriangle(0, 1, 2),
														new IndexTriangle(0, 2, 3)
													}, null);
												}
											}
											else
											{
												_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzZ7IrhryCzDPgsLyK4A_003D_003D(_0023_003DzMeUW4ys2yBDJ, _0023_003Dz9j7EUB0_003D.Vertices);
											}
										}
										else
										{
											_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzhQedXNzFzzR2(_0023_003DzMeUW4ys2yBDJ, _0023_003DzWXcU6Os_003D);
										}
									}
									else
									{
										_0023_003Dz5v26jTE_003D(surface.ConvertToMesh(_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D, Math.PI / 6.0, Mesh.natureType.RichSmooth));
									}
								}
								else if (_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D == 0.0)
								{
									_0023_003Dz8VL9aMphUV0A_DWqMQ_003D_003D(brep.Faces, brep, _0023_003DzMeUW4ys2yBDJ);
									for (int i = 0; i < brep.Inners.Length; i++)
									{
										_0023_003Dz8VL9aMphUV0A_DWqMQ_003D_003D(brep.Inners[i], brep, _0023_003DzMeUW4ys2yBDJ);
									}
								}
								else
								{
									Brep brep2 = (Brep)brep.Clone();
									brep2.Regen(new RegenParams(_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D, _0023_003DzMeUW4ys2yBDJ._0023_003Dz0mZ4_0024fFWxsTX));
									double _0023_003Dzm0CYiiE_003D = _0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D;
									_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D = 0.0;
									_0023_003Dz5v26jTE_003D(brep2);
									_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D = _0023_003Dzm0CYiiE_003D;
								}
							}
							else
							{
								if (mesh2 != null && (mesh2.Normals == null || mesh2.Normals.Length == 0))
								{
									mesh2.Regen(base.Deviation);
								}
								_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003Dzkyv9axSJ96BJ(_0023_003DzMeUW4ys2yBDJ, mesh2.Vertices, mesh2.Normals, mesh2.Triangles, mesh2.TextureCoords);
							}
						}
						else
						{
							mesh = femMesh.ConvertToMesh(includeDisplacements: false);
							mesh.Regen(0.0);
							_0023_003Dz5v26jTE_003D(mesh);
						}
					}
					else
					{
						_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzZ7IrhryCzDPgsLyK4A_003D_003D(_0023_003DzMeUW4ys2yBDJ, fastPointCloud.PointArray, fastPointCloud.ColorArray);
					}
				}
				else if (fastMesh.TriangleArray != null)
				{
					_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzcWQwCzqUaihGvo7GI4WUJx8_003D(_0023_003DzMeUW4ys2yBDJ, fastMesh.PointArray, fastMesh.NormalArray, fastMesh.TriangleArray, fastMesh.ColorArray);
				}
				else
				{
					_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzNn5xfzPGwemnPlUh6w_003D_003D(_0023_003DzMeUW4ys2yBDJ, fastMesh.PointArray, fastMesh.NormalArray, fastMesh.TriangleArray, fastMesh.ColorArray);
				}
				return;
			}
			bool flag = _0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D == 0.0;
			Entity[] array = blockReference.Explode(_0023_003DzMeUW4ys2yBDJ.Blocks, resolveByParent: true, flag);
			GfxAttributes other = (GfxAttributes)_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Clone();
			StringBuilder stringBuilder = new StringBuilder();
			Entity[] array2 = array;
			foreach (Entity entity in array2)
			{
				if ((entity is Joint || entity is Bar || entity.RegenMode == regenType.RegenAndCompile || entity is Solid || (!flag && (entity is Circle || entity is Ellipse || entity is Curve || entity is Surface || entity is Brep))) && !(entity is BlockReference) && !(entity is Hatch) && !(entity is Table) && !(entity is Text) && !(entity is Leader))
				{
					entity.Regen(_0023_003DzMeUW4ys2yBDJ._0023_003Dzm0CYiiE_003D);
				}
				_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Assign(other);
				_0023_003DzMeUW4ys2yBDJ._0023_003DzqP5lTto_003D.Propagate(entity, _0023_003DzMeUW4ys2yBDJ._0023_003DzeWJg3NJnk3WA[entity.LayerName], _0023_003DzMeUW4ys2yBDJ._0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
				try
				{
					_0023_003Dz5v26jTE_003D(entity);
				}
				catch (Exception ex)
				{
					stringBuilder.AppendLine(ex.Message);
				}
			}
			if (stringBuilder.Length > 0)
			{
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015652), blockReference.BlockName, Environment.NewLine, stringBuilder));
			}
		}
		else
		{
			ITriangles triangles = (ITriangles)_0023_003Dz9j7EUB0_003D;
			float[] _0023_003DzrH1N0x4_003D;
			if (_0023_003Dz9j7EUB0_003D is Bar)
			{
				Vector3D[] _0023_003DzztJY0_0024dXEFMk = ((Bar)_0023_003Dz9j7EUB0_003D)._0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out _0023_003DzrH1N0x4_003D);
				_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzqvY7kwQPqWGI82uuJKHwZYs_003D(_0023_003DzMeUW4ys2yBDJ, _0023_003Dz9j7EUB0_003D.Vertices, _0023_003DzztJY0_0024dXEFMk, triangles.Triangles, null);
			}
			else
			{
				Vector3D[] _0023_003DzztJY0_0024dXEFMk2 = ((Joint)_0023_003Dz9j7EUB0_003D)._0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out _0023_003DzrH1N0x4_003D);
				_0023_003DzFlfTSukx_fDjCwZcSJrLpJyD5Z8_EjEIbQ_003D_003D._0023_003DzqvY7kwQPqWGI82uuJKHwZYs_003D(_0023_003DzMeUW4ys2yBDJ, _0023_003Dz9j7EUB0_003D.Vertices, _0023_003DzztJY0_0024dXEFMk2, triangles.Triangles, null);
			}
		}
	}
}
