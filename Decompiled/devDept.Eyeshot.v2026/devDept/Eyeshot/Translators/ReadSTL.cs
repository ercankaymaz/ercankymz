using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadSTL : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Mesh.natureType _0023_003DzdrczDxRNw9e1LWcg0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dz1BYRPRvcj_0024zq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzTAbaxOclmTeRUxzzXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzYIqZca3Y7z3lRzk5Ow_003D_003D = true;

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

	public ReadSTL(string filePath, bool lightWeight, bool splitDisjoint, Mesh.natureType meshNature)
		: base(filePath)
	{
		_0023_003Dz1BYRPRvcj_0024zq = lightWeight;
		_0023_003DzTAbaxOclmTeRUxzzXQ_003D_003D = splitDisjoint;
		_0023_003DzdrczDxRNw9e1LWcg0A_003D_003D = meshNature;
	}

	public ReadSTL(string filePath, bool lightWeight, Mesh.natureType meshNature)
		: this(filePath, lightWeight, splitDisjoint: false, meshNature)
	{
	}

	public ReadSTL(string filePath, Mesh.natureType meshNature)
		: this(filePath, lightWeight: false, splitDisjoint: false, meshNature)
	{
	}

	public ReadSTL(string filePath, bool lightWeight)
		: this(filePath, lightWeight, lightWeight ? Mesh.natureType.Plain : Mesh.natureType.Smooth)
	{
	}

	public ReadSTL(string filePath)
		: this(filePath, lightWeight: false, Mesh.natureType.Smooth)
	{
	}

	public ReadSTL(Stream stream)
		: this(stream, lightWeight: false)
	{
	}

	public ReadSTL(Stream stream, bool lightWeight)
		: this(stream, lightWeight, splitDisjoint: false, lightWeight ? Mesh.natureType.Plain : Mesh.natureType.Smooth)
	{
	}

	public ReadSTL(Stream stream, Mesh.natureType meshNature)
		: this(stream, lightWeight: false, splitDisjoint: false, meshNature)
	{
	}

	public ReadSTL(Stream stream, bool lightWeight, Mesh.natureType meshNature)
		: this(stream, lightWeight, splitDisjoint: true, meshNature)
	{
	}

	public ReadSTL(Stream stream, bool lightWeight, bool splitDisjoint, Mesh.natureType meshNature)
		: base(stream)
	{
		_0023_003Dz1BYRPRvcj_0024zq = lightWeight;
		_0023_003DzTAbaxOclmTeRUxzzXQ_003D_003D = splitDisjoint;
		_0023_003DzdrczDxRNw9e1LWcg0A_003D_003D = meshNature;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzzPdB5kCtbvl9(progress, ct);
		if (base.Entities != null && _0023_003Dz1BYRPRvcj_0024zq)
		{
			foreach (Mesh entity in base.Entities)
			{
				entity.LightWeight = true;
				entity.UpdateBoundingBox(null);
				entity.RegenMode = regenType.CompileOnly;
			}
		}
		UpdateProgressTo100(base.ParsingText, progress);
	}

	private void _0023_003DzzPdB5kCtbvl9(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
			string text = textReader.ReadLine();
			string text2 = textReader.ReadLine();
			base.Stream.Position = 0L;
			if (text != null)
			{
				text = text.ToLower(CultureInfo.InvariantCulture);
			}
			if (text2 != null)
			{
				text2 = text2.ToLower(CultureInfo.InvariantCulture);
			}
			if (text != null)
			{
				if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011837)) && text2 != null && text2.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011817)))
				{
					_0023_003DzSr7BXMK_brmp(textReader, base.Stream, _0023_003DzdrczDxRNw9e1LWcg0A_003D_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
				}
				else
				{
					_0023_003DzChJyXR2h4Vtc(base.Stream, _0023_003DzdrczDxRNw9e1LWcg0A_003D_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
				}
			}
			else
			{
				base.Result = true;
			}
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

	private void _0023_003DzSr7BXMK_brmp(TextReader _0023_003Dz63vmKM0_003D, Stream _0023_003DzdLqTRfo_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool flag = true;
		_0023_003DzdLqTRfo_003D.Position = 0L;
		((StreamReader)_0023_003Dz63vmKM0_003D).DiscardBufferedData();
		int num = 0;
		int num2 = (int)_0023_003DzdLqTRfo_003D.Length;
		List<Entity> list = new List<Entity>();
		int num3 = 0;
		Mesh mesh = new Mesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		List<Vector3D> list2 = new List<Vector3D>();
		Point3D[] array = new Point3D[3];
		List<Point3D> list3 = new List<Point3D>();
		bool flag2 = _0023_003DzwSoVQpU_003D(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		string text;
		while ((text = _0023_003Dz63vmKM0_003D.ReadLine()) != null)
		{
			if (text.Length == 0)
			{
				continue;
			}
			num += text.Length + 2;
			text = text.Trim();
			string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			array2[0] = array2[0].ToLower(CultureInfo.InvariantCulture);
			if (array2[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011797))
			{
				_0023_003Dzujg5TYtavEsh(list3.ToArray(), _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, Compact, mesh);
				if (list2.Count > 0)
				{
					mesh.Normals = list2.ToArray();
				}
				list.Add(mesh);
				list3.Clear();
				mesh = new Mesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			else if (array2[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011782))
			{
				num3 = 0;
			}
			else if (array2[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011762))
			{
				array[num3++] = new Point3D(Utility.FloatParse(array2[1]), Utility.FloatParse(array2[2]), Utility.FloatParse(array2[3]));
			}
			else if (array2[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011773))
			{
				list3.AddRange(array);
				if (!UpdateProgressAndCheckCancelled(num, num2, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					flag = false;
					break;
				}
			}
			else if (array2[0] == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011817) && array2[1].ToLower() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011755) && flag2)
			{
				list2.Add(new Vector3D(Utility.FloatParse(array2[2]), Utility.FloatParse(array2[3]), Utility.FloatParse(array2[4])));
			}
		}
		UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
		if (flag)
		{
			if (_0023_003DzTAbaxOclmTeRUxzzXQ_003D_003D)
			{
				List<Entity> list4 = new List<Entity>();
				foreach (Mesh item2 in list)
				{
					Mesh[] array3 = item2.SplitDisjoint();
					foreach (Mesh item in array3)
					{
						list4.Add(item);
					}
				}
				base.Entities.AddRange(list4);
			}
			else
			{
				base.Entities.AddRange(list);
			}
		}
		base.Result = flag;
	}

	private bool _0023_003DzwSoVQpU_003D(Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		if (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D != Mesh.natureType.ColorPlain && _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D != Mesh.natureType.MulticolorPlain && _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D != Mesh.natureType.Plain)
		{
			return _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.RichPlain;
		}
		return true;
	}

	private void _0023_003Dzujg5TYtavEsh(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003Dzs5WRo8eBvjs90jFvmw_003D_003D, Mesh _0023_003Dzls7uEA0Dd3WU)
	{
		if (_0023_003Dzs5WRo8eBvjs90jFvmw_003D_003D)
		{
			Utility.TrianglesToIndexedTriangles(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var uniqueVertices, out var cleanedTriangles, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			_0023_003Dzls7uEA0Dd3WU.Vertices = uniqueVertices;
			_0023_003Dzls7uEA0Dd3WU.Triangles = cleanedTriangles;
			return;
		}
		_0023_003Dzls7uEA0Dd3WU.Vertices = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		int num = _0023_003Dzls7uEA0Dd3WU.Vertices.Length / 3;
		IndexTriangle[] array = new IndexTriangle[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new IndexTriangle(i * 3, i * 3 + 1, i * 3 + 2);
		}
		_0023_003Dzls7uEA0Dd3WU.Triangles = array;
		_0023_003Dzls7uEA0Dd3WU.LightWeight = true;
	}

	private void _0023_003DzChJyXR2h4Vtc(Stream _0023_003DzdLqTRfo_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool flag = true;
		BinaryReader binaryReader = new BinaryReader(_0023_003DzdLqTRfo_003D, Encoding.ASCII);
		Mesh mesh = null;
		new string(binaryReader.ReadChars(80));
		int num = binaryReader.ReadInt32();
		if (num > 0)
		{
			mesh = new Mesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			int num2 = 0;
			bool flag2 = _0023_003DzwSoVQpU_003D(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			if (flag2)
			{
				mesh.Normals = new Vector3D[num];
			}
			Point3D[] array = new Point3D[num * 3];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				Vector3D vector3D = new Vector3D();
				Point3D point3D = new Point3D();
				Point3D point3D2 = new Point3D();
				Point3D point3D3 = new Point3D();
				vector3D.X = binaryReader.ReadSingle();
				vector3D.Y = binaryReader.ReadSingle();
				vector3D.Z = binaryReader.ReadSingle();
				point3D.X = binaryReader.ReadSingle();
				point3D.Y = binaryReader.ReadSingle();
				point3D.Z = binaryReader.ReadSingle();
				point3D2.X = binaryReader.ReadSingle();
				point3D2.Y = binaryReader.ReadSingle();
				point3D2.Z = binaryReader.ReadSingle();
				point3D3.X = binaryReader.ReadSingle();
				point3D3.Y = binaryReader.ReadSingle();
				point3D3.Z = binaryReader.ReadSingle();
				binaryReader.ReadUInt16();
				if (flag2)
				{
					mesh.Normals[num2++] = vector3D;
				}
				array[num3++] = point3D;
				array[num3++] = point3D2;
				array[num3++] = point3D3;
				if (!UpdateProgressAndCheckCancelled(i, num, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					flag = false;
					break;
				}
			}
			UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
			if (flag)
			{
				_0023_003Dzujg5TYtavEsh(array, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, Compact, mesh);
				if (_0023_003DzTAbaxOclmTeRUxzzXQ_003D_003D)
				{
					Mesh[] collection = mesh.SplitDisjoint();
					base.Entities.AddRange(collection);
				}
				else
				{
					base.Entities.Add(mesh);
				}
			}
		}
		base.Result = flag;
	}
}
