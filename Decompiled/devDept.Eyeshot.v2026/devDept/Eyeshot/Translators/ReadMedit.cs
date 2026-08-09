using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadMedit : ReadFileAsync
{
	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public ReadMedit(string filePath)
		: base(filePath)
	{
	}

	public ReadMedit(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DznFuWTkHLfCZd(progress, ct);
	}

	private void _0023_003DznFuWTkHLfCZd(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
			List<Point3D> list = new List<Point3D>();
			List<Element> list2 = new List<Element>();
			string text;
			while ((text = textReader.ReadLine()) != null)
			{
				if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
				{
					continue;
				}
				string[] array = text.Trim().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 3)
				{
					list.Add(new Node(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2])));
				}
				else if (array.Length == 4 && array[0] != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388))
				{
					list.Add(new Node(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2])));
				}
				else if (array.Length == 5)
				{
					if (array[4] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746))
					{
						list2.Add(new Tetra4(int.Parse(array[0]) - 1, int.Parse(array[1]) - 1, int.Parse(array[3]) - 1, int.Parse(array[2]) - 1, Material.Aluminium));
					}
					else if (array[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388))
					{
						list2.Add(new Tetra4(int.Parse(array[1]) - 1, int.Parse(array[2]) - 1, int.Parse(array[3]) - 1, int.Parse(array[4]) - 1, Material.Aluminium));
					}
				}
				else if (array.Length == 11 && array[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388))
				{
					list2.Add(new Tetra10(int.Parse(array[1]) - 1, int.Parse(array[2]) - 1, int.Parse(array[3]) - 1, int.Parse(array[4]) - 1, int.Parse(array[5]) - 1, int.Parse(array[6]) - 1, int.Parse(array[7]) - 1, int.Parse(array[8]) - 1, int.Parse(array[9]) - 1, int.Parse(array[10]) - 1, Material.Aluminium));
				}
			}
			base.Entities.Add(new FemMesh(list, list2));
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
}
