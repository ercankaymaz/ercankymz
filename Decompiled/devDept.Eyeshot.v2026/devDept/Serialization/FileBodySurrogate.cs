using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public sealed class FileBodySurrogate : Surrogate<FileBody>
{
	private sealed class _0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D
	{
		public View _0023_003Dzc24p_0024Tg_003D;

		internal bool _0023_003DzUZgIQjKRXZoie2QaKg_003D_003D(Block _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Name == _0023_003Dzc24p_0024Tg_003D.BlockName;
		}

		internal bool _0023_003DzXLuxaLdtoa3RB6ep3g_003D_003D(Block _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Name == _0023_003Dzc24p_0024Tg_003D.BlockName;
		}
	}

	public contentType DeserializedContent;

	public IList<Entity> Entities;

	public IList<Entity> RootBlockEntities;

	public IList<Block> Blocks;

	public string RootBlockName;

	public IList<Material> Materials;

	public IList<Layer> Layers;

	public IList<LineType> LineTypes;

	public IList<HatchPattern> HatchPatterns;

	public IList<TextStyle> TextStyles;

	public Camera Camera;

	public float LineTypeScale;

	public string DrawingSilhouettesLayerName;

	public string DrawingEdgesLayerName;

	public string DrawingWiresLayerName;

	public string DrawingHiddenSilhouettesLayerName;

	public string DrawingHiddenEdgesLayerName;

	public string DrawingHiddenWiresLayerName;

	public string DrawingSectionsLayerName;

	public string DrawingGhostCirclesLayerName;

	public string DrawingCenterlinesLayerName;

	public string DrawingHiddenSegmentsLineTypeName;

	public string DrawingCenterlinesLineTypeName;

	public IList<Sheet> DrawingSheets;

	public List<Block> DrawingBlocks;

	public string DrawingRootBlockName;

	public IList<Entity> DrawingRootBlockEntities;

	public IList<Layer> DrawingLayers;

	public IList<LineType> DrawingLineTypes;

	public IList<HatchPattern> DrawingHatchPatterns;

	public IList<TextStyle> DrawingTextStyles;

	public string[] Paths;

	public fileType[] Types;

	public FileBodySurrogate(FileBody fileBody)
		: base(fileBody)
	{
	}

	protected override FileBody ConvertToObject()
	{
		FileBody fileBody = new FileBody(Entities);
		CopyDataToObject(fileBody);
		return fileBody;
	}

	private void _0023_003DzEhVgpIU0rFpv3xAFLiEiLQQ_003D(FileBody _0023_003Dz_00240xgmnpmFbP4)
	{
		if (base.Version > 7 || _0023_003Dz_00240xgmnpmFbP4.DrawingSheets == null || _0023_003Dz_00240xgmnpmFbP4.DrawingBlocks == null)
		{
			return;
		}
		foreach (Sheet drawingSheet in _0023_003Dz_00240xgmnpmFbP4.DrawingSheets)
		{
			if (drawingSheet.Entities == null)
			{
				continue;
			}
			using List<Entity>.Enumerator enumerator2 = drawingSheet.Entities.GetEnumerator();
			Block value;
			while (enumerator2.MoveNext() && (!(enumerator2.Current is VectorView vectorView) || !_0023_003Dz_00240xgmnpmFbP4.DrawingBlocks.TryGetValue(vectorView.BlockName, out value) || _0023_003Dz9A_00242ZzgSmGBdRX9aLw_003D_003D(value)))
			{
			}
		}
	}

	private static bool _0023_003Dz9A_00242ZzgSmGBdRX9aLw_003D_003D(Block _0023_003DzLeyHB00_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (Entity entity in _0023_003DzLeyHB00_003D.Entities)
		{
			if (entity is Line line)
			{
				list.Add(line._0023_003DzERE6p7JEcywKj0t_00247Q_003D_003D());
				continue;
			}
			if (entity is LinearPath)
			{
				list = null;
				break;
			}
			list.Add(entity);
		}
		if (list == null)
		{
			return false;
		}
		_0023_003DzLeyHB00_003D.Entities.Clear();
		_0023_003DzLeyHB00_003D.Entities.AddRange(list);
		return true;
	}

	private void _0023_003DzwyRatKpa1DsK<T>(IList<T> _0023_003DzcDEsV8s_003D, EyeshotKeyedCollection<T> _0023_003DzcrILBXg_003D) where T : IKeyedCollectionItem<T>
	{
		if (_0023_003DzcDEsV8s_003D == null)
		{
			return;
		}
		foreach (T item in _0023_003DzcDEsV8s_003D)
		{
			_0023_003DzcrILBXg_003D.Add(item);
		}
	}

	private void _0023_003DzwyRatKpa1DsK(IList<Block> _0023_003DzcDEsV8s_003D, BlockKeyedCollection _0023_003DzcrILBXg_003D, string _0023_003DzvjIPlKM5C5r_0024, IList<Entity> _0023_003Dz_0024ywH7T9vjrRt)
	{
		_0023_003DzwyRatKpa1DsK(_0023_003DzcDEsV8s_003D, _0023_003DzcrILBXg_003D);
		_0023_003DzcrILBXg_003D.SetRootBlock(_0023_003DzvjIPlKM5C5r_0024);
		if (_0023_003Dz_0024ywH7T9vjrRt != null)
		{
			_0023_003DzcrILBXg_003D.RootBlock.Entities.AddRange(_0023_003Dz_0024ywH7T9vjrRt);
		}
	}

	protected override void CopyDataToObject(FileBody fileBody)
	{
		_0023_003DzwyRatKpa1DsK(Blocks, fileBody.Blocks, RootBlockName, RootBlockEntities);
		_0023_003DzwyRatKpa1DsK(Materials, fileBody.Materials);
		_0023_003DzwyRatKpa1DsK(Layers, fileBody.Layers);
		_0023_003DzwyRatKpa1DsK(LineTypes, fileBody.LineTypes);
		_0023_003DzwyRatKpa1DsK(HatchPatterns, fileBody.HatchPatterns);
		_0023_003DzwyRatKpa1DsK(TextStyles, fileBody.TextStyles);
		fileBody.DrawingSilhouettesLayerName = DrawingSilhouettesLayerName;
		fileBody.DrawingEdgesLayerName = DrawingEdgesLayerName;
		fileBody.DrawingWiresLayerName = DrawingWiresLayerName;
		fileBody.DrawingHiddenSilhouettesLayerName = DrawingHiddenSilhouettesLayerName;
		fileBody.DrawingHiddenEdgesLayerName = DrawingHiddenEdgesLayerName;
		fileBody.DrawingHiddenWiresLayerName = DrawingHiddenWiresLayerName;
		if (base.Version >= 19)
		{
			fileBody.DrawingSectionsLayerName = DrawingSectionsLayerName;
		}
		fileBody.DrawingCenterlinesLayerName = DrawingCenterlinesLayerName;
		fileBody.DrawingHiddenSegmentsLineTypeName = DrawingHiddenSegmentsLineTypeName;
		fileBody.DrawingCenterlinesLineTypeName = DrawingCenterlinesLineTypeName;
		_0023_003DzwyRatKpa1DsK(DrawingSheets, fileBody.DrawingSheets);
		_0023_003DzwyRatKpa1DsK(DrawingBlocks, fileBody.DrawingBlocks, DrawingRootBlockName, DrawingRootBlockEntities);
		_0023_003DzwyRatKpa1DsK(DrawingLayers, fileBody.DrawingLayers);
		_0023_003DzwyRatKpa1DsK(DrawingLineTypes, fileBody.DrawingLineTypes);
		_0023_003DzwyRatKpa1DsK(DrawingHatchPatterns, fileBody.DrawingHatchPatterns);
		_0023_003DzwyRatKpa1DsK(DrawingTextStyles, fileBody.DrawingTextStyles);
		_0023_003DzEhVgpIU0rFpv3xAFLiEiLQQ_003D(fileBody);
		fileBody.Paths = Paths;
		fileBody.Types = Types;
		fileBody.Camera = Camera;
		fileBody.LineTypeScale = ((base.Version >= 19) ? LineTypeScale : 1f);
		fileBody._0023_003DzbT1s7HaLJi_a(DeserializedContent);
	}

	protected override void CopyDataFromObject(FileBody fileBody)
	{
		Entities = fileBody.Entities;
		Blocks = fileBody.Blocks._0023_003Dz7GC5mgNtxbGh();
		RootBlockName = fileBody.Blocks.RootBlockName;
		if (fileBody.Blocks.hasRootBlock)
		{
			Block rootBlock = fileBody.Blocks.RootBlock;
			RootBlockEntities = rootBlock.Entities;
			rootBlock._0023_003DzhYfvCOi6649X(new EntityList());
		}
		Materials = fileBody.Materials._0023_003Dz7GC5mgNtxbGh();
		Layers = fileBody.Layers._0023_003Dz7GC5mgNtxbGh();
		LineTypes = fileBody.LineTypes._0023_003Dz7GC5mgNtxbGh();
		HatchPatterns = fileBody.HatchPatterns._0023_003Dz7GC5mgNtxbGh();
		TextStyles = fileBody.TextStyles._0023_003Dz7GC5mgNtxbGh();
		Camera = fileBody.Camera;
		LineTypeScale = fileBody.LineTypeScale;
		DeserializedContent = fileBody._0023_003Dza7hr5mLPdEIJ();
		DrawingSilhouettesLayerName = fileBody.DrawingSilhouettesLayerName;
		DrawingEdgesLayerName = fileBody.DrawingEdgesLayerName;
		DrawingWiresLayerName = fileBody.DrawingWiresLayerName;
		DrawingHiddenSilhouettesLayerName = fileBody.DrawingHiddenSilhouettesLayerName;
		DrawingHiddenEdgesLayerName = fileBody.DrawingHiddenEdgesLayerName;
		DrawingHiddenWiresLayerName = fileBody.DrawingHiddenWiresLayerName;
		DrawingSectionsLayerName = fileBody.DrawingSectionsLayerName;
		DrawingCenterlinesLayerName = fileBody.DrawingCenterlinesLayerName;
		DrawingHiddenSegmentsLineTypeName = fileBody.DrawingHiddenSegmentsLineTypeName;
		DrawingCenterlinesLineTypeName = fileBody.DrawingCenterlinesLineTypeName;
		DrawingSheets = fileBody.DrawingSheets._0023_003Dz7GC5mgNtxbGh();
		DrawingBlocks = fileBody.DrawingBlocks._0023_003Dz7GC5mgNtxbGh();
		DrawingRootBlockName = fileBody.DrawingBlocks.RootBlockName;
		if (fileBody.DrawingBlocks.hasRootBlock)
		{
			Block rootBlock2 = fileBody.DrawingBlocks.RootBlock;
			DrawingRootBlockEntities = rootBlock2.Entities;
			rootBlock2._0023_003DzhYfvCOi6649X(new EntityList());
		}
		DrawingLayers = fileBody.DrawingLayers._0023_003Dz7GC5mgNtxbGh();
		DrawingLineTypes = fileBody.DrawingLineTypes._0023_003Dz7GC5mgNtxbGh();
		DrawingHatchPatterns = fileBody.DrawingHatchPatterns._0023_003Dz7GC5mgNtxbGh();
		DrawingTextStyles = fileBody.DrawingTextStyles._0023_003Dz7GC5mgNtxbGh();
		Paths = fileBody.Paths;
		Types = fileBody.Types;
	}

	public static implicit operator FileBody(FileBodySurrogate bodySurrogate)
	{
		return bodySurrogate?.ConvertToObject();
	}

	public static implicit operator FileBodySurrogate(FileBody source)
	{
		return source?.ConvertToSurrogate();
	}

	private new void AfterDeserialize(SerializationContext _0023_003Dz3jD9hLs_003D)
	{
		if (!(_0023_003Dz3jD9hLs_003D.Context is FileSerializer fileSerializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669432));
		}
		DeserializedContent = fileSerializer.Content;
		if (DrawingSheets == null)
		{
			return;
		}
		foreach (Sheet drawingSheet in DrawingSheets)
		{
			foreach (Entity entity in drawingSheet.Entities)
			{
				_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D _0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2 = new _0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D();
				_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003Dzc24p_0024Tg_003D = entity as View;
				if (_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003Dzc24p_0024Tg_003D == null)
				{
					continue;
				}
				if (DeserializedContent == contentType.Geometry)
				{
					int? num = DrawingBlocks?.FindIndex(_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003DzUZgIQjKRXZoie2QaKg_003D_003D);
					if (num.HasValue && num != -1)
					{
						DrawingBlocks.RemoveAt(num.Value);
					}
					_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003Dzc24p_0024Tg_003D._0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
				}
				else if (!_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003Dzc24p_0024Tg_003D.HasChanged)
				{
					View _0023_003Dzc24p_0024Tg_003D = _0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003Dzc24p_0024Tg_003D;
					List<Block> drawingBlocks = DrawingBlocks;
					_0023_003Dzc24p_0024Tg_003D._0023_003DzDaxeAiK9rC4V(drawingBlocks != null && drawingBlocks.Count(_0023_003DzZcbl0vBU0pWtSKfsMsT3iFg_003D2._0023_003DzXLuxaLdtoa3RB6ep3g_003D_003D) == 0);
				}
			}
		}
	}
}
