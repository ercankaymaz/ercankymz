using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteComputingObjects : WriteFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D;

	public int[] Colors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D = value;
		}
	}

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public WriteComputingObjects(IWorkspace workspace, string filePath, bool selectedOnly = false)
		: this(workspace.Document, filePath, selectedOnly)
	{
	}

	public WriteComputingObjects(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath)
	{
	}

	public WriteComputingObjects(IWorkspace workspace, Stream stream, bool selectedOnly = false)
		: this(workspace.Document, stream, selectedOnly)
	{
	}

	public WriteComputingObjects(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream)
	{
	}

	public WriteComputingObjects(WriteParamsWithMaterials writeParams, string filePath)
		: base(writeParams, filePath)
	{
	}

	public WriteComputingObjects(WriteParamsWithMaterials writeParams, Stream stream)
		: base(writeParams, stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzxXDadRsbbYp9mw8IkrkNbU0_003D(progress, ct);
	}

	private void _0023_003DzxXDadRsbbYp9mw8IkrkNbU0_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextWriter textWriter = new StreamWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write), Encoding.ASCII);
			SetWriter(textWriter);
			int count = entities.Count;
			for (int i = 0; i < count; i++)
			{
				Entity entity = entities[i];
				if (entity is Mesh)
				{
					Mesh mesh = (Mesh)entity;
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011411));
					textWriter.WriteLine(mesh.Vertices.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011421));
					Point3D point3D;
					for (int j = 0; j < mesh.Vertices.Length - 1; j++)
					{
						point3D = mesh.Vertices[j];
						textWriter.WriteLine(point3D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)));
					}
					point3D = mesh.Vertices.Last();
					textWriter.WriteLine(point3D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
					textWriter.WriteLine(string.Empty);
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011385));
					textWriter.WriteLine(mesh.Triangles.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011421));
					IndexTriangle indexTriangle;
					for (int k = 0; k < mesh.Triangles.Length - 1; k++)
					{
						indexTriangle = mesh.Triangles[k];
						textWriter.WriteLine(indexTriangle.V1 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + indexTriangle.V2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + indexTriangle.V3);
					}
					indexTriangle = mesh.Triangles.Last();
					textWriter.WriteLine(indexTriangle.V1 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + indexTriangle.V2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + indexTriangle.V3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
				}
				else if (entity is FemMesh)
				{
					FemMesh femMesh = (FemMesh)entity;
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011411));
					textWriter.WriteLine(femMesh.Vertices.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011421));
					Point3D point3D2;
					for (int l = 0; l < femMesh.Vertices.Length - 1; l++)
					{
						point3D2 = femMesh.Vertices[l];
						textWriter.WriteLine(point3D2.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)));
					}
					point3D2 = femMesh.Vertices.Last();
					textWriter.WriteLine(point3D2.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011399)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
					textWriter.WriteLine(string.Empty);
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011385));
					textWriter.WriteLine(femMesh.Elements.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446) + femMesh.Elements.First().Connection.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
					Element[] elements = femMesh.Elements;
					foreach (Element element in elements)
					{
						if (element.Connection.Length == 6)
						{
							int num;
							for (int n = 0; n < element.Connection.Length; n += 2)
							{
								num = element.Connection[n];
								textWriter.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
							}
							num = element.Connection[3];
							textWriter.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
							num = element.Connection[5];
							textWriter.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
							num = element.Connection[1];
							textWriter.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
						}
						else
						{
							for (int num2 = 0; num2 < element.Connection.Length; num2++)
							{
								int num = element.Connection[num2];
								textWriter.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
							}
						}
						textWriter.Write(Environment.NewLine);
					}
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
				}
				if (Colors != null && Colors.Length != 0)
				{
					textWriter.WriteLine(string.Empty);
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011370));
					textWriter.WriteLine(Colors.Length + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
					for (int num3 = 0; num3 < Colors.Length; num3++)
					{
						if (num3 % 21 != 0)
						{
							textWriter.Write(Colors[num3] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
						}
						else if (num3 > 0)
						{
							textWriter.WriteLine(string.Empty);
						}
					}
					textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
				}
				if (!UpdateProgressAndCheckCancelled(i, count, base.ComposingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return;
				}
			}
			UpdateProgressTo100(base.ComposingText, _0023_003DzmHS7frs_003D);
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			throw new EyeshotException(ex.Message, ex);
		}
		finally
		{
			CloseStream();
		}
	}
}
