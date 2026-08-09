using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteSTL : WriteFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzuFpePe0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextWriter _0023_003DzO8GrQfI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz_9ZL2Pyk6uph;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public WriteSTL(IWorkspace workspace, string filePath, bool ascii = false, bool selectedOnly = false)
		: this(workspace.Document, filePath, ascii, selectedOnly)
	{
	}

	public WriteSTL(Document document, string filePath, bool ascii = false, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), filePath, ascii)
	{
	}

	public WriteSTL(IWorkspace workspace, Stream stream, bool ascii = false, bool selectedOnly = false)
		: this(workspace.Document, stream, ascii, selectedOnly)
	{
	}

	public WriteSTL(Document document, Stream stream, bool ascii = false, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), stream, ascii)
	{
	}

	public WriteSTL(IWorkspace workspace, string filePath, double deviation, bool ascii = false, bool selectedOnly = false)
		: this(workspace.Document, filePath, deviation, ascii, selectedOnly)
	{
	}

	public WriteSTL(Document document, string filePath, double deviation, bool ascii = false, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), filePath, deviation, ascii)
	{
	}

	public WriteSTL(IWorkspace workspace, Stream stream, double deviation, bool ascii = false, bool selectedOnly = false)
		: this(workspace.Document, stream, deviation, ascii, selectedOnly)
	{
	}

	public WriteSTL(Document document, Stream stream, double deviation, bool ascii = false, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), stream, deviation, ascii)
	{
	}

	public WriteSTL(WriteParams writeParams, string filePath, bool ascii = false)
		: base(writeParams, filePath)
	{
		_0023_003DzuFpePe0_003D = ascii;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	public WriteSTL(WriteParams writeParams, Stream stream, bool ascii = false)
		: base(writeParams, stream)
	{
		_0023_003DzuFpePe0_003D = ascii;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	public WriteSTL(WriteParams writeParams, string filePath, double deviation, bool ascii = false)
		: base(writeParams, filePath)
	{
		base.Deviation = deviation;
		_0023_003DzuFpePe0_003D = ascii;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	public WriteSTL(WriteParams writeParams, Stream stream, double deviation, bool ascii = false)
		: base(writeParams, stream)
	{
		base.Deviation = deviation;
		_0023_003DzuFpePe0_003D = ascii;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, double deviation, bool ascii = false, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath)
	{
		base.selectedOnly = selectedOnly;
		base.Deviation = deviation;
		_0023_003DzuFpePe0_003D = ascii;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTL(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, double deviation, bool ascii = false, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream)
	{
		base.selectedOnly = selectedOnly;
		base.Deviation = deviation;
		_0023_003DzuFpePe0_003D = ascii;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		try
		{
			if (_0023_003DzuFpePe0_003D)
			{
				_0023_003DzxJ1DZ4vb2LFx(progress, ct);
			}
			else
			{
				_0023_003DzTSiRp5ydsJZN(progress, ct);
			}
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

	private void _0023_003DzxJ1DZ4vb2LFx(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Stream stream = base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write);
		_0023_003DzO8GrQfI_003D = new StreamWriter(stream, Encoding.ASCII);
		SetWriter(_0023_003DzO8GrQfI_003D);
		_0023_003Dz_9ZL2Pyk6uph = 0;
		IList<Entity> list = GetEntities();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = list[i];
			if (IsVisible(entity, out var _))
			{
				_0023_003DzGffnggmcb6Ef(entity);
			}
			if (!UpdateProgressAndCheckCancelled(++_0023_003Dz_9ZL2Pyk6uph, count, base.ComposingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		UpdateProgressTo100(base.ComposingText, _0023_003DzmHS7frs_003D);
	}

	private void _0023_003DzTSiRp5ydsJZN(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		BinaryWriter binaryWriter = new BinaryWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create));
		SetWriter(binaryWriter);
		IList<Entity> list = GetEntities();
		int count = list.Count;
		List<double[,]> list2 = new List<double[,]>();
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			Entity entity = list[i];
			if (IsVisible(entity, out var _))
			{
				double[,] array = _0023_003DzhhuvU7XMk7yU(entity);
				list2.Add(array);
				num += array.GetLength(0);
			}
			if (!UpdateProgressAndCheckCancelled(i, count, base.ComposingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		UpdateProgressTo100(base.ComposingEntitiesText, _0023_003DzmHS7frs_003D);
		double[,] array2 = new double[num, 9];
		int num2 = 0;
		foreach (double[,] item in list2)
		{
			Array.Copy(item, 0, array2, num2, item.Length);
			num2 += item.Length;
		}
		int length = array2.GetLength(0);
		char[] chars = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015806).ToCharArray();
		binaryWriter.Write(chars);
		int value = length;
		binaryWriter.Write(value);
		Point3D origin = Point3D.Origin;
		Point3D origin2 = Point3D.Origin;
		Point3D origin3 = Point3D.Origin;
		for (int j = 0; j < length; j++)
		{
			origin.X = array2[j, 0];
			origin.Y = array2[j, 1];
			origin.Z = array2[j, 2];
			origin2.X = array2[j, 3];
			origin2.Y = array2[j, 4];
			origin2.Z = array2[j, 5];
			origin3.X = array2[j, 6];
			origin3.Y = array2[j, 7];
			origin3.Z = array2[j, 8];
			Vector3D vector3D = new Vector3D(origin, origin2, origin3);
			if (vector3D.IsZero)
			{
				vector3D.X = 1.0;
				vector3D.Y = 0.0;
				vector3D.Z = 0.0;
			}
			vector3D.WriteAsFloat(binaryWriter);
			origin.WriteAsFloat(binaryWriter);
			origin2.WriteAsFloat(binaryWriter);
			origin3.WriteAsFloat(binaryWriter);
			binaryWriter.Write((short)0);
			if (!UpdateProgressAndCheckCancelled(j, length, base.WritingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				break;
			}
		}
		UpdateProgressTo100(base.WritingText, _0023_003DzmHS7frs_003D);
	}

	internal void _0023_003Dzd_6sXLg_003D(TextWriter _0023_003DzzvTcRNc_003D, int _0023_003DzcUJIm54_003D)
	{
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015699) + _0023_003DzcUJIm54_003D);
	}

	internal void _0023_003DzJ676xB8_003D(TextWriter _0023_003DzzvTcRNc_003D)
	{
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011797));
	}

	internal void _0023_003Dz9svUtfr4iaEa(Point3D _0023_003DzffqPLNQ_003D, Point3D _0023_003Dz5Azd7L8_003D, Point3D _0023_003DzZe6oCrQ_003D, Vector3D _0023_003DzoMNiNRw_003D, TextWriter _0023_003DzzvTcRNc_003D)
	{
		if (_0023_003DzoMNiNRw_003D.IsZero)
		{
			_0023_003DzoMNiNRw_003D = Vector3D.AxisX;
		}
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015682) + _0023_003DzoMNiNRw_003D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzoMNiNRw_003D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzoMNiNRw_003D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015926));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015909) + _0023_003DzffqPLNQ_003D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzffqPLNQ_003D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzffqPLNQ_003D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015909) + _0023_003Dz5Azd7L8_003D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dz5Azd7L8_003D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dz5Azd7L8_003D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015909) + _0023_003DzZe6oCrQ_003D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzZe6oCrQ_003D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzZe6oCrQ_003D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011773));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015891));
	}

	private void _0023_003DzGffnggmcb6Ef(Entity _0023_003Dz9j7EUB0_003D)
	{
		Mesh mesh = new Mesh();
		if (!(_0023_003Dz9j7EUB0_003D is Bar) && !(_0023_003Dz9j7EUB0_003D is Brep) && !(_0023_003Dz9j7EUB0_003D is Solid))
		{
			if (!(_0023_003Dz9j7EUB0_003D is Joint) && !(_0023_003Dz9j7EUB0_003D is Region))
			{
				if (!(_0023_003Dz9j7EUB0_003D is Triangle) && !(_0023_003Dz9j7EUB0_003D is Quad))
				{
					if (!(_0023_003Dz9j7EUB0_003D is Surface surface))
					{
						if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
						{
							if (!(_0023_003Dz9j7EUB0_003D is FemMesh femMesh))
							{
								if (!(_0023_003Dz9j7EUB0_003D is Mesh mesh2))
								{
									if (_0023_003Dz9j7EUB0_003D is SimulationStock simulationStock)
									{
										mesh = simulationStock.ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Plain, weld: false);
										_0023_003DzGffnggmcb6Ef(mesh);
									}
									return;
								}
								_0023_003Dzd_6sXLg_003D(_0023_003DzO8GrQfI_003D, _0023_003Dz_9ZL2Pyk6uph);
								for (int i = 0; i < mesh2.Triangles.Length; i++)
								{
									IndexTriangle indexTriangle = mesh2.Triangles[i];
									Mesh.natureType meshNature = mesh2.MeshNature;
									this._0023_003Dz9svUtfr4iaEa((meshNature - 1 > Mesh.natureType.MulticolorPlain) ? new Vector3D(mesh2.Vertices[indexTriangle.V1], mesh2.Vertices[indexTriangle.V2], mesh2.Vertices[indexTriangle.V3]) : mesh2.Normals[i], mesh2.Vertices[indexTriangle.V1], mesh2.Vertices[indexTriangle.V2], mesh2.Vertices[indexTriangle.V3], _0023_003DzO8GrQfI_003D);
								}
								_0023_003DzJ676xB8_003D(_0023_003DzO8GrQfI_003D);
							}
							else
							{
								Mesh mesh3 = femMesh._0023_003DzjwyQTVXErsM0(_0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D: true, null);
								mesh3.UpdateNormals();
								_0023_003DzGffnggmcb6Ef(mesh3);
							}
							return;
						}
						bool flag = base.Deviation == 0.0;
						Entity[] array = blockReference.Explode(blocks, resolveByParent: true, flag);
						foreach (Entity entity in array)
						{
							if ((entity is Joint || entity is Bar || entity.RegenMode == regenType.RegenAndCompile || entity is Solid || (!flag && (entity is Circle || entity is Ellipse || entity is Curve || entity is Surface || entity is Brep))) && !(entity is BlockReference) && !(entity is Hatch) && !(entity is Table) && !(entity is Text))
							{
								entity.Regen(base.Deviation);
							}
							_0023_003DzGffnggmcb6Ef(entity);
						}
					}
					else
					{
						Surface surface2 = surface;
						if (base.Deviation != 0.0)
						{
							surface2 = (Surface)surface.Clone();
							surface2._0023_003DzcX3lwu4d7umF(base.Deviation, base.Angle, null, 0.0, null);
						}
						mesh = surface2.ConvertToMesh(base.Deviation, base.Angle);
						_0023_003DzGffnggmcb6Ef(mesh);
					}
				}
				else
				{
					mesh = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Plain, weld: true);
					mesh.Regen(0.0);
					_0023_003DzGffnggmcb6Ef(mesh);
				}
				return;
			}
			ITriangles triangles = (ITriangles)_0023_003Dz9j7EUB0_003D;
			_0023_003Dzd_6sXLg_003D(_0023_003DzO8GrQfI_003D, _0023_003Dz_9ZL2Pyk6uph);
			for (int k = 0; k < triangles.Triangles.Length; k++)
			{
				IndexTriangle indexTriangle2 = triangles.Triangles[k];
				if (_0023_003Dz9j7EUB0_003D is Joint)
				{
					Vector3D _0023_003DzoMNiNRw_003D = new Vector3D(_0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V1], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V2], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V3]);
					_0023_003Dz9svUtfr4iaEa(_0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V1], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V2], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V3], _0023_003DzoMNiNRw_003D, _0023_003DzO8GrQfI_003D);
				}
				else
				{
					_0023_003Dz9svUtfr4iaEa(_0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V1], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V2], _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle2.V3], ((Region)_0023_003Dz9j7EUB0_003D).Plane.AxisZ, _0023_003DzO8GrQfI_003D);
				}
			}
			_0023_003DzJ676xB8_003D(_0023_003DzO8GrQfI_003D);
		}
		else
		{
			mesh = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Smooth, weld: true);
			mesh.Regen(0.0);
			_0023_003DzGffnggmcb6Ef(mesh);
		}
	}

	private double[,] _0023_003DzhhuvU7XMk7yU(Entity _0023_003Dz9j7EUB0_003D)
	{
		Mesh mesh = new Mesh();
		double[,] array = null;
		if (!(_0023_003Dz9j7EUB0_003D is Bar) && !(_0023_003Dz9j7EUB0_003D is Joint) && !(_0023_003Dz9j7EUB0_003D is Region) && !(_0023_003Dz9j7EUB0_003D is Mesh))
		{
			if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
			{
				if (!(_0023_003Dz9j7EUB0_003D is FastMesh) && !(_0023_003Dz9j7EUB0_003D is Brep))
				{
					if (!(_0023_003Dz9j7EUB0_003D is FemMesh femMesh))
					{
						if (!(_0023_003Dz9j7EUB0_003D is Surface surface))
						{
							if (!(_0023_003Dz9j7EUB0_003D is Quad) && !(_0023_003Dz9j7EUB0_003D is Triangle))
							{
								if (_0023_003Dz9j7EUB0_003D is Solid solid)
								{
									if (solid.portions.Count > 0 && solid.portions[0].Triangles == null)
									{
										solid.Regen(1E-12);
									}
									mesh = solid.ConvertToMesh(0.0, 0.0, Mesh.natureType.Smooth, weld: false);
									return _0023_003DzhhuvU7XMk7yU(mesh);
								}
								return new double[0, 9];
							}
							mesh = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Plain, weld: true);
							return _0023_003DzhhuvU7XMk7yU(mesh);
						}
						Surface surface2 = surface;
						if (base.Deviation != 0.0)
						{
							surface2 = (Surface)surface.Clone();
							surface2._0023_003DzcX3lwu4d7umF(base.Deviation, base.Angle, null, 0.0, null);
						}
						mesh = surface2.ConvertToMesh(base.Deviation, base.Angle);
						return _0023_003DzhhuvU7XMk7yU(mesh);
					}
					Mesh mesh2 = femMesh._0023_003DzjwyQTVXErsM0(_0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D: true, null);
					return (mesh2 == null) ? new double[0, 0] : _0023_003DzhhuvU7XMk7yU(mesh2);
				}
				mesh = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Smooth, weld: true);
				return _0023_003DzhhuvU7XMk7yU(mesh);
			}
			bool flag = base.Deviation == 0.0;
			Entity[] array2 = blockReference.Explode(blocks, resolveByParent: true, flag);
			double[,] array3 = new double[0, 9];
			Entity[] array4 = array2;
			foreach (Entity entity in array4)
			{
				if ((entity is Joint || entity is Bar || entity.RegenMode == regenType.RegenAndCompile || entity is Solid || (!flag && (entity is Circle || entity is Ellipse || entity is Curve || entity is Surface || entity is Brep))) && !(entity is BlockReference) && !(entity is Hatch) && !(entity is Table) && !(entity is Text))
				{
					entity.Regen(base.Deviation);
				}
				double[,] second = _0023_003DzhhuvU7XMk7yU(entity);
				array3 = Utility.Append(array3, second);
			}
			return array3;
		}
		if (_0023_003Dz9j7EUB0_003D is Stock)
		{
			mesh = ((Stock)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.Plain, weld: false);
			return _0023_003DzhhuvU7XMk7yU(mesh);
		}
		ITriangles triangles = (ITriangles)_0023_003Dz9j7EUB0_003D;
		double[,] array5 = new double[triangles.Triangles.Length, 9];
		for (int j = 0; j < triangles.Triangles.Length; j++)
		{
			IndexTriangle indexTriangle = triangles.Triangles[j];
			array5[j, 0] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V1].X;
			array5[j, 1] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V1].Y;
			array5[j, 2] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V1].Z;
			array5[j, 3] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V2].X;
			array5[j, 4] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V2].Y;
			array5[j, 5] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V2].Z;
			array5[j, 6] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V3].X;
			array5[j, 7] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V3].Y;
			array5[j, 8] = _0023_003Dz9j7EUB0_003D.Vertices[indexTriangle.V3].Z;
		}
		return array5;
	}
}
