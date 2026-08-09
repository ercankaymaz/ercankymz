using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteNastran : WriteFileAsync
{
	private sealed class _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D
	{
		public Material _0023_003DzpTpEYVPSUMbR;

		internal bool _0023_003DzFfM9E04YdE9HIYwomDjqquI_003D(Element _0023_003Dzx63Fsgc_003D)
		{
			return _0023_003Dzx63Fsgc_003D.Material.Equals(_0023_003DzpTpEYVPSUMbR);
		}
	}

	protected MaterialKeyedCollection materials;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public WriteNastran(IWorkspace workspace, string filePath, bool selectedOnly = false)
		: this(workspace.Document, filePath, selectedOnly)
	{
	}

	public WriteNastran(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath)
	{
	}

	public WriteNastran(IWorkspace workspace, Stream stream, bool selectedOnly = false)
		: this(workspace.Document, stream, selectedOnly)
	{
	}

	public WriteNastran(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream)
	{
	}

	public WriteNastran(WriteParamsWithMaterials writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
	}

	public WriteNastran(WriteParamsWithMaterials writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
	}

	private void _0023_003DzFbxKPRlUPcpd(WriteParamsWithMaterials _0023_003DzX6XgSWkagNXc)
	{
		materials = _0023_003DzX6XgSWkagNXc.Materials;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzKIsoyICI2gzJT6A2eA_003D_003D(progress, ct);
	}

	private void _0023_003DzKIsoyICI2gzJT6A2eA_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Stream stream = null;
		TextWriter textWriter = null;
		try
		{
			stream = base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write);
			textWriter = new StreamWriter(stream, Encoding.ASCII);
			SetWriter(textWriter);
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013845));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013836));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013763));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013468));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013395));
			FemMesh[] array = GetEntities().OfType<FemMesh>().ToArray();
			int num = array.Length;
			int num2 = 0;
			int num3 = 1;
			int num4 = 1;
			int num5 = 1;
			List<Material> list = new List<Material>();
			list.Add(null);
			FemMesh[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Element[] elements = array2[i].Elements;
				foreach (Element element in elements)
				{
					if (!list.Contains(element.Material))
					{
						list.Add(element.Material);
					}
				}
			}
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013382));
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
			for (int k = 1; k < list.Count; k++)
			{
				Material material = list[k];
				textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013624), k, _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(material.Young), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(material.ShearModulus), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(material.Poisson), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(material.Density), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(material.CoeffOfThermalExp)));
			}
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
			List<string> list2 = new List<string>();
			array2 = array;
			foreach (FemMesh femMesh in array2)
			{
				int num6 = num3;
				Point3D[] vertices = femMesh.Vertices;
				for (int j = 0; j < vertices.Length; j++)
				{
					Node node = (Node)vertices[j];
					string text = string.Empty;
					if (node.Restrained)
					{
						text = (node.Restraints[0] ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388) : string.Empty) + (node.Restraints[1] ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937047) : string.Empty) + (node.Restraints[2] ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937055) : string.Empty);
					}
					textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013593), num3, _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.X), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.Y), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.Z)) + ((text == string.Empty) ? string.Empty : (_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013557) + text)));
					if (node.Loaded)
					{
						list2.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013568), num3, _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.Load[0]), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.Load[1]), _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(node.Load[2])));
					}
					num3++;
				}
				List<Material> list3 = new List<Material>();
				Element[] elements = femMesh.Elements;
				foreach (Element element2 in elements)
				{
					if (!list3.Contains(element2.Material))
					{
						list3.Add(element2.Material);
					}
				}
				using (List<Material>.Enumerator enumerator = list3.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2 = new _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D();
						_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DzpTpEYVPSUMbR = enumerator.Current;
						bool flag = true;
						elements = femMesh.Elements.Where(_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DzFfM9E04YdE9HIYwomDjqquI_003D).ToArray();
						foreach (Element element3 in elements)
						{
							if (flag)
							{
								int num7 = list.IndexOf(element3.Material);
								if (element3 is Tria3 || element3 is Tria6 || element3 is Quad4 || element3 is Quad8)
								{
									textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013505), num5, num7, 1));
									num5++;
								}
								else if (element3 is Truss truss)
								{
									textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014268), num5, num7, _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(truss.SectionArea)));
									num5++;
								}
								else
								{
									textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014225), num5, num7));
									num5++;
								}
								flag = false;
							}
							if (element3 is Tria3)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014216), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[1] + num6, element3.Connection[2] + num6));
							}
							else if (element3 is Tria6)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014183), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[2] + num6, element3.Connection[4] + num6, element3.Connection[1] + num6, element3.Connection[3] + num6, element3.Connection[5] + num6));
							}
							else if (element3 is Quad4)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014390), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[1] + num6, element3.Connection[2] + num6, element3.Connection[3] + num6));
							}
							else if (element3 is Quad8)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014361), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[2] + num6, element3.Connection[4] + num6, element3.Connection[6] + num6, element3.Connection[1] + num6, element3.Connection[3] + num6, element3.Connection[5] + num6, element3.Connection[7] + num6));
							}
							else if (element3 is Truss)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014320), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[1] + num6));
							}
							else if (element3 is Tetra10)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014281), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[2] + num6, element3.Connection[4] + num6, element3.Connection[9] + num6, element3.Connection[1] + num6, element3.Connection[3] + num6, element3.Connection[5] + num6, element3.Connection[6] + num6, element3.Connection[7] + num6, element3.Connection[8] + num6));
							}
							else if (element3 is Tetra4)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013962), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[1] + num6, element3.Connection[2] + num6, element3.Connection[3] + num6));
							}
							else if (element3 is Penta15)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013933), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[2] + num6, element3.Connection[4] + num6, element3.Connection[9] + num6, element3.Connection[11] + num6, element3.Connection[13] + num6, element3.Connection[1] + num6, element3.Connection[3] + num6, element3.Connection[5] + num6, element3.Connection[6] + num6, element3.Connection[7] + num6, element3.Connection[8] + num6, element3.Connection[10] + num6, element3.Connection[12] + num6, element3.Connection[14] + num6));
							}
							else if (element3 is Penta6)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014085), num4, num5 - 1, element3.Connection[0] + num6, element3.Connection[1] + num6, element3.Connection[2] + num6, element3.Connection[3] + num6, element3.Connection[4] + num6, element3.Connection[5] + num6));
							}
							else if (element3 is Hexa20)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014036), num4, num5 - 1, element3.Connection[2] + num6, element3.Connection[4] + num6, element3.Connection[6] + num6, element3.Connection[0] + num6, element3.Connection[14] + num6, element3.Connection[16] + num6, element3.Connection[18] + num6, element3.Connection[12] + num6, element3.Connection[3] + num6, element3.Connection[5] + num6, element3.Connection[7] + num6, element3.Connection[1] + num6, element3.Connection[9] + num6, element3.Connection[10] + num6, element3.Connection[11] + num6, element3.Connection[8] + num6, element3.Connection[15] + num6, element3.Connection[17] + num6, element3.Connection[19] + num6, element3.Connection[13] + num6));
							}
							else if (element3 is Hexa8)
							{
								textWriter.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014692), num4, num5 - 1, element3.Connection[1] + num6, element3.Connection[2] + num6, element3.Connection[3] + num6, element3.Connection[0] + num6, element3.Connection[5] + num6, element3.Connection[6] + num6, element3.Connection[7] + num6, element3.Connection[4] + num6));
							}
							num4++;
						}
					}
				}
				textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
				if (!UpdateProgressAndCheckCancelled(num2, num, base.ComposingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return;
				}
				num2++;
			}
			if (list2.Count > 0)
			{
				textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014904));
				textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772));
				textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014886));
			}
			foreach (string item in list2)
			{
				textWriter.WriteLine(item);
			}
			textWriter.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014873));
			UpdateProgressTo100(base.ComposingText, _0023_003DzmHS7frs_003D);
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
			if (writeFileCloseStream)
			{
				textWriter?.Close();
				stream?.Close();
			}
		}
	}

	private string _0023_003DzDLkC88wcmAYEa7YNug_003D_003D(double _0023_003DzoMNiNRw_003D)
	{
		string text = _0023_003DzoMNiNRw_003D.ToString(CultureInfo.InvariantCulture);
		if (!text.Contains('.'))
		{
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290);
		}
		return text;
	}
}
