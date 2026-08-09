using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Memory;
using SharpGLTF.Runtime;
using SharpGLTF.Schema2;

namespace SharpGLTF.IO;

internal class WavefrontWriter
{
	[DebuggerDisplay("{DiffuseColor} {DiffuseTexture.ToDebuggerDisplay()}")]
	public struct Material : IEquatable<Material>
	{
		public Vector3 DiffuseColor;

		public Vector3 SpecularColor;

		public float Opacity;

		public MemoryImage DiffuseTexture;

		public override readonly int GetHashCode()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			int num = ((object)DiffuseColor/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)SpecularColor/*cast due to constrained. prefix*/).GetHashCode() ^ DiffuseTexture.GetHashCode();
			float opacity = Opacity;
			return num ^ opacity.GetHashCode();
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is Material other)
			{
				return Equals(other);
			}
			return false;
		}

		public readonly bool Equals(Material other)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			if (DiffuseColor != other.DiffuseColor)
			{
				return false;
			}
			if (SpecularColor != other.SpecularColor)
			{
				return false;
			}
			if (Opacity != other.Opacity)
			{
				return false;
			}
			if (DiffuseTexture != other.DiffuseTexture)
			{
				return false;
			}
			return true;
		}
	}

	private static readonly Encoding FILEENCODING = Encoding.ASCII;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly MeshBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> _Mesh = new MeshBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty>();

	public void AddTriangle(Material material, in VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> a, in VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> b, in VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> c)
	{
		_Mesh.UsePrimitive(material).AddTriangle(a, b, c);
	}

	public void WriteFiles(string filePath)
	{
		SharpGLTF.Guard.NotNullOrEmpty(filePath, "filePath");
		string directoryName = Path.GetDirectoryName(filePath);
		foreach (KeyValuePair<string, Action<Stream>> item in _GetFileGenerators(Path.GetFileNameWithoutExtension(filePath)))
		{
			string path = Path.Combine(directoryName, item.Key);
			using FileStream obj = File.OpenWrite(path);
			item.Value(obj);
		}
	}

	public IReadOnlyDictionary<string, ArraySegment<byte>> GetFiles(string baseName)
	{
		SharpGLTF.Guard.IsFalse(baseName.Any((char c) => char.IsWhiteSpace(c)), "baseName", "Whitespace characters not allowed in filename");
		Dictionary<string, ArraySegment<byte>> dictionary = new Dictionary<string, ArraySegment<byte>>();
		foreach (KeyValuePair<string, Action<Stream>> item in _GetFileGenerators(baseName))
		{
			using MemoryStream memoryStream = new MemoryStream();
			item.Value(memoryStream);
			memoryStream.TryGetBuffer(out var buffer);
			dictionary[item.Key] = buffer;
		}
		return dictionary;
	}

	private Dictionary<string, Action<Stream>> _GetFileGenerators(string baseName)
	{
		SharpGLTF.Guard.IsFalse(baseName.Any((char c) => char.IsWhiteSpace(c)), "baseName", "Whitespace characters not allowed in filename");
		Dictionary<string, Action<Stream>> dictionary = new Dictionary<string, Action<Stream>>();
		Dictionary<Material, string> materials = _GetMaterialsFileGenerator(dictionary, baseName, _Mesh.Primitives.Select((PrimitiveBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> item) => item.Material));
		dictionary[baseName + ".obj"] = delegate(Stream fs)
		{
			_WriteGeometryFile(fs, materials, baseName + ".mtl");
		};
		return dictionary;
	}

	private static Dictionary<Material, string> _GetMaterialsFileGenerator(IDictionary<string, Action<Stream>> fileGenerators, string baseName, IEnumerable<Material> materials)
	{
		if (!(materials is List<Material>))
		{
			materials = materials.ToList();
		}
		IEnumerable<MemoryImage> enumerable = (from item in materials
			select item.DiffuseTexture into item
			where item.IsValid
			select item).Distinct();
		bool flag = true;
		Dictionary<MemoryImage, string> imageNameByImage = new Dictionary<MemoryImage, string>();
		foreach (MemoryImage img in enumerable)
		{
			string text = (flag ? (baseName + "." + img.FileExtension) : $"{baseName}_{fileGenerators.Count}.{img.FileExtension}");
			fileGenerators[text] = delegate(Stream fs)
			{
				byte[] array = img.Content.ToArray();
				fs.Write(array, 0, array.Length);
			};
			flag = false;
			imageNameByImage[img] = text;
		}
		Dictionary<Material, string> mmap = new Dictionary<Material, string>();
		foreach (Material material in materials)
		{
			mmap[material] = $"Material_{mmap.Count}";
		}
		fileGenerators[baseName + ".mtl"] = delegate(Stream fs)
		{
			_WriteMaterialsFile(fs, materials, mmap, imageNameByImage);
		};
		return mmap;
	}

	private static void _WriteMaterialsFile(Stream fs, IEnumerable<Material> materials, Dictionary<Material, string> mmap, Dictionary<MemoryImage, string> imageNameByImage)
	{
		using StreamWriter sw = new StreamWriter(fs, FILEENCODING);
		_WriteMaterialsFile(sw, materials, mmap, imageNameByImage);
	}

	private static void _WriteMaterialsFile(StreamWriter sw, IEnumerable<Material> materials, Dictionary<Material, string> mmap, Dictionary<MemoryImage, string> imageNameByImage)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		foreach (Material material in materials)
		{
			sw.WriteLine("newmtl " + mmap[material]);
			sw.WriteLine("illum 2");
			sw.WriteLine(FormattableString.Invariant($"Ka {material.DiffuseColor.X} {material.DiffuseColor.Y} {material.DiffuseColor.Z}"));
			sw.WriteLine(FormattableString.Invariant($"Kd {material.DiffuseColor.X} {material.DiffuseColor.Y} {material.DiffuseColor.Z}"));
			sw.WriteLine(FormattableString.Invariant($"Ks {material.SpecularColor.X} {material.SpecularColor.Y} {material.SpecularColor.Z}"));
			if (material.Opacity != 1f)
			{
				sw.WriteLine(FormattableString.Invariant($"d {material.Opacity}"));
				sw.WriteLine(FormattableString.Invariant($"Tr {1f - material.Opacity}"));
			}
			if (material.DiffuseTexture.IsValid)
			{
				string text = imageNameByImage[material.DiffuseTexture];
				sw.WriteLine("map_Kd " + text);
			}
			sw.WriteLine();
		}
	}

	private void _WriteGeometryFile(Stream s, IReadOnlyDictionary<Material, string> materials, string mtlLib)
	{
		using StreamWriter sw = new StreamWriter(s, FILEENCODING);
		_WriteGeometryFile(sw, materials, mtlLib);
	}

	private void _WriteGeometryFile(StreamWriter sw, IReadOnlyDictionary<Material, string> materials, string mtlLib)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		sw.WriteLine("mtllib " + mtlLib);
		sw.WriteLine();
		foreach (PrimitiveBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> primitive in _Mesh.Primitives)
		{
			foreach (VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> vertex in primitive.Vertices)
			{
				Vector3 position = vertex.Position;
				sw.WriteLine(FormattableString.Invariant($"v {position.X} {position.Y} {position.Z}"));
			}
		}
		sw.WriteLine();
		foreach (PrimitiveBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> primitive2 in _Mesh.Primitives)
		{
			foreach (VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> vertex2 in primitive2.Vertices)
			{
				Vector3 normal = vertex2.Geometry.Normal;
				sw.WriteLine(FormattableString.Invariant($"vn {normal.X} {normal.Y} {normal.Z}"));
			}
		}
		sw.WriteLine();
		foreach (PrimitiveBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> primitive3 in _Mesh.Primitives)
		{
			foreach (VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty> vertex3 in primitive3.Vertices)
			{
				Vector2 texCoord = vertex3.Material.TexCoord;
				texCoord.Y = 1f - texCoord.Y;
				sw.WriteLine(FormattableString.Invariant($"vt {texCoord.X} {texCoord.Y}"));
			}
		}
		sw.WriteLine();
		sw.WriteLine("g default");
		int num = 1;
		foreach (PrimitiveBuilder<Material, VertexPositionNormal, VertexTexture1, VertexEmpty> primitive4 in _Mesh.Primitives)
		{
			string text = materials[primitive4.Material];
			sw.WriteLine("usemtl " + text);
			foreach (var triangle in primitive4.Triangles)
			{
				int num2 = triangle.A + num;
				int num3 = triangle.B + num;
				int num4 = triangle.C + num;
				sw.WriteLine(FormattableString.Invariant($"f {num2}/{num2}/{num2} {num3}/{num3}/{num3} {num4}/{num4}/{num4}"));
			}
			num += primitive4.Vertices.Count;
		}
	}

	public void AddModel(ModelRoot model)
	{
		IEnumerable<EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty>> triangles = model.DefaultScene.EvaluateTriangles<VertexPositionNormal, VertexTexture1>();
		triangles = EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty>.TransformTextureCoordsByMaterial(triangles);
		foreach (EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty> item in triangles)
		{
			EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty> current = item;
			Material materialFromTriangle = GetMaterialFromTriangle(current.Material);
			AddTriangle(materialFromTriangle, in current.A, in current.B, in current.C);
		}
	}

	public void AddModel(ModelRoot model, Animation animation, float time)
	{
		RuntimeOptions runtimeOptions = new RuntimeOptions();
		runtimeOptions.IsolateMemory = false;
		runtimeOptions.GpuMeshInstancing = MeshInstancing.SingleMesh;
		IEnumerable<EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty>> triangles = model.DefaultScene.EvaluateTriangles<VertexPositionNormal, VertexTexture1>(runtimeOptions, animation, time);
		triangles = EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty>.TransformTextureCoordsByMaterial(triangles, animation, time);
		foreach (EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty> item in triangles)
		{
			EvaluatedTriangle<VertexPositionNormal, VertexTexture1, VertexEmpty> current = item;
			Material materialFromTriangle = GetMaterialFromTriangle(current.Material);
			AddTriangle(materialFromTriangle, in current.A, in current.B, in current.C);
		}
	}

	private static Material GetMaterialFromTriangle(SharpGLTF.Schema2.Material srcMaterial)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (srcMaterial == null)
		{
			return default(Material);
		}
		Vector4 diffuseColor = srcMaterial.GetDiffuseColor(Vector4.One);
		Material result = new Material
		{
			DiffuseColor = new Vector3(diffuseColor.X, diffuseColor.Y, diffuseColor.Z),
			SpecularColor = new Vector3(0.2f),
			Opacity = 1f
		};
		if (srcMaterial.Alpha == AlphaMode.BLEND && diffuseColor.W < 1f)
		{
			result.Opacity = Math.Max(0f, diffuseColor.W);
		}
		result.DiffuseTexture = (srcMaterial.GetDiffuseTexture()?.PrimaryImage?.Content).GetValueOrDefault();
		return result;
	}
}
