using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public abstract class WriteFileAsync : WorkUnit
{
	private sealed class _0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D
	{
		public KeyValuePair<string, AttributeReference> _0023_003DzYYa3aQ4_003D;

		internal bool _0023_003Dzpox__0024kTT49JtKzoG3A_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D is devDept.Eyeshot.Entities.Attribute attribute)
			{
				return attribute.Tag == _0023_003DzYYa3aQ4_003D.Key;
			}
			return false;
		}
	}

	private sealed class _0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D
	{
		public Block _0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D;

		internal bool _0023_003DzpX8V1Np4_0024L_MVw_aJQ_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D is Dimension)
			{
				return _0023_003DzBJFJHwk_003D.EntityData == _0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.sketchEntity;
			}
			return false;
		}
	}

	private sealed class _0023_003DzTuVpKOmn_0024_JKUgymcsOOPVA_003D
	{
		public char[] _0023_003Dz_noZGudieQMBDynTTA_003D_003D;

		internal string _0023_003Dz7_0024yOVyS92RRIMtaslw_003D_003D(char _0023_003Dzt_m8zV0_003D)
		{
			if (!_0023_003Dz_noZGudieQMBDynTTA_003D_003D.Contains(_0023_003Dzt_m8zV0_003D))
			{
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), _0023_003Dzt_m8zV0_003D);
			}
			return _0023_003Dqpzzh9v4WpaIPnVWvcTB2AbHruQW6AvGVPXBMxEXCrj1MLMOs4J4mgNVxpd44Amo5(_0023_003Dzt_m8zV0_003D);
		}
	}

	protected readonly IList<Entity> entities;

	protected BlockKeyedCollection blocks;

	protected LayerKeyedCollection layers;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DziOkx2W0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IDisposable _0023_003DzFSa8eGE_003D;

	protected bool writeFileCloseStream;

	protected bool selectedOnly;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzCwX4mA970fxgnASt2Q_003D_003D = Math.PI / 6.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzwwfkd5mORqI1nODhuw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012217);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpsPx3LreLOUFbm4kSw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012208);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzmsJ8W56kpsg_1Q_0024Z7w_0024VHNc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012161);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzwI_XzcTITpsz53gu1jZBgdM_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012155);

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;
		}
	}

	public Stream Stream => _0023_003DziOkx2W0_003D;

	protected string OpenBlockName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D;
		}
	}

	public double Deviation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = value;
		}
	}

	public double Angle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = value;
		}
	}

	public string WritingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzwwfkd5mORqI1nODhuw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzwwfkd5mORqI1nODhuw_003D_003D = value;
		}
	}

	public string ComposingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpsPx3LreLOUFbm4kSw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpsPx3LreLOUFbm4kSw_003D_003D = value;
		}
	}

	public string ComposingBlocksText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmsJ8W56kpsg_1Q_0024Z7w_0024VHNc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzmsJ8W56kpsg_1Q_0024Z7w_0024VHNc_003D = value;
		}
	}

	public string ComposingEntitiesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwI_XzcTITpsz53gu1jZBgdM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwI_XzcTITpsz53gu1jZBgdM_003D = value;
		}
	}

	internal WriteFileAsync(string _0023_003Dzg5oC_Hs_003D, bool _0023_003Dz9rsu4TwhLBvn = false)
	{
		_0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dzz6JDud_0024u1ojF(_0023_003Dzg5oC_Hs_003D, _0023_003Dzmyw8uNw_003D: true);
		selectedOnly = _0023_003Dz9rsu4TwhLBvn;
		writeFileCloseStream = true;
	}

	protected WriteFileAsync(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), filePath)
	{
	}

	protected WriteFileAsync(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParams(document, selectedOnly), stream)
	{
	}

	protected WriteFileAsync(WriteParams writeParams, string filePath)
		: this(filePath, writeParams.SelectedOnly)
	{
		if (writeParams.Blocks.hasRootBlock && writeParams.Entities == writeParams.Blocks.RootBlock.Entities)
		{
			entities = new List<Entity>();
		}
		else
		{
			entities = writeParams.Entities.ToList();
		}
		_0023_003Dz15Wz9EHE0jMD(writeParams.Blocks);
		InitLayers(writeParams.Layers);
		_0023_003DzZtTRSqEnW97m(writeParams.OpenBlockName);
	}

	protected WriteFileAsync(WriteParams writeParams, Stream stream)
	{
		if (writeParams.Blocks.hasRootBlock && writeParams.Entities == writeParams.Blocks.RootBlock.Entities)
		{
			entities = new List<Entity>();
		}
		else
		{
			entities = writeParams.Entities.ToList();
		}
		_0023_003Dz15Wz9EHE0jMD(writeParams.Blocks);
		InitLayers(writeParams.Layers);
		selectedOnly = writeParams.SelectedOnly;
		_0023_003DzZtTRSqEnW97m(writeParams.OpenBlockName);
		_0023_003DziOkx2W0_003D = stream;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	protected WriteFileAsync(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath)
	{
		entities = entList;
		_0023_003Dz15Wz9EHE0jMD(blockDict);
		_0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dzz6JDud_0024u1ojF(filePath, _0023_003Dzmyw8uNw_003D: true);
		writeFileCloseStream = true;
		_0023_003DzY1qpE85kRYVX(layerList);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	protected WriteFileAsync(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream)
	{
		entities = entList;
		_0023_003Dz15Wz9EHE0jMD(blockDict);
		_0023_003DziOkx2W0_003D = stream;
		_0023_003DzY1qpE85kRYVX(layerList);
	}

	private void _0023_003DzZtTRSqEnW97m(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D = _0023_003DzPzO_0024GUk_003D;
	}

	protected void PurgeCollectionsForOpenBlock(ref MaterialKeyedCollection materials, ref TextStyleKeyedCollection textStyles, ref LineTypeKeyedCollection lineTypes, ref HatchPatternKeyedCollection hatchPatterns)
	{
		if (!string.IsNullOrEmpty(OpenBlockName))
		{
			Block block = blocks[OpenBlockName];
			blocks.SetRootBlock(OpenBlockName);
			Utility.Purge(block.Entities, layers, blocks, materials, textStyles, lineTypes, hatchPatterns, out var _0023_003DzfchAzPg_003D, out var _0023_003DzTKSsuc0_003D, out var _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, out var _0023_003DzIm3oyxMBrWGo, out var _0023_003Dzl0O9h6oxpm0u, out var _0023_003Dz3b479cSvol0G);
			layers = _0023_003DzfchAzPg_003D;
			blocks = _0023_003DzTKSsuc0_003D;
			materials = _0023_003DzvEAegzCu5KMnKFso0g_003D_003D;
			textStyles = _0023_003DzIm3oyxMBrWGo;
			lineTypes = _0023_003Dzl0O9h6oxpm0u;
			hatchPatterns = _0023_003Dz3b479cSvol0G;
		}
	}

	private protected void _0023_003DzrtB0QILXyS1kXboL7g_003D_003D(ref MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		TextStyleKeyedCollection textStyles = new TextStyleKeyedCollection();
		LineTypeKeyedCollection lineTypes = new LineTypeKeyedCollection();
		HatchPatternKeyedCollection hatchPatterns = new HatchPatternKeyedCollection();
		PurgeCollectionsForOpenBlock(ref _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, ref textStyles, ref lineTypes, ref hatchPatterns);
	}

	private protected void _0023_003DzrtB0QILXyS1kXboL7g_003D_003D()
	{
		MaterialKeyedCollection materials = new MaterialKeyedCollection();
		TextStyleKeyedCollection textStyles = new TextStyleKeyedCollection();
		LineTypeKeyedCollection lineTypes = new LineTypeKeyedCollection();
		HatchPatternKeyedCollection hatchPatterns = new HatchPatternKeyedCollection();
		PurgeCollectionsForOpenBlock(ref materials, ref textStyles, ref lineTypes, ref hatchPatterns);
	}

	protected void SynchronizeAttributeReference(BlockKeyedCollection blocks, IList<Entity> entities)
	{
		foreach (Entity entity2 in entities)
		{
			if (!(entity2 is BlockReference blockReference))
			{
				continue;
			}
			using Dictionary<string, AttributeReference>.Enumerator enumerator2 = blockReference.Attributes.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D CS_0024_003C_003E8__locals3 = new _0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D();
				CS_0024_003C_003E8__locals3._0023_003DzYYa3aQ4_003D = enumerator2.Current;
				AttributeReference value = CS_0024_003C_003E8__locals3._0023_003DzYYa3aQ4_003D.Value;
				if (value.needsSynchronization)
				{
					Entity entity = blocks[blockReference.BlockName].Entities.FirstOrDefault((Entity _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D is devDept.Eyeshot.Entities.Attribute attribute && attribute.Tag == CS_0024_003C_003E8__locals3._0023_003DzYYa3aQ4_003D.Key);
					if (entity != null)
					{
						value.SynchronizeAttributes(entity as devDept.Eyeshot.Entities.Attribute);
					}
				}
			}
		}
	}

	protected void SynchronizeAttributeReference(Document document)
	{
		if (document == null)
		{
			return;
		}
		SynchronizeAttributeReference(document.Blocks, document.Entities);
		foreach (Block block in document.Blocks)
		{
			SynchronizeAttributeReference(document.Blocks, block.Entities);
		}
		if (!(document is DrawingDocument drawingDocument))
		{
			return;
		}
		foreach (Sheet sheet in drawingDocument.Sheets)
		{
			SynchronizeAttributeReference(document.Blocks, sheet.Entities);
		}
	}

	protected virtual void InitLayers(LayerKeyedCollection layerCollection)
	{
		layers = new LayerKeyedCollection();
		foreach (Layer item in layerCollection)
		{
			if (item.Exportable)
			{
				layers.Add(item);
			}
		}
	}

	private void _0023_003Dz15Wz9EHE0jMD(BlockKeyedCollection _0023_003DzRaNcRo8_003D)
	{
		blocks = new BlockKeyedCollection();
		foreach (Block item in _0023_003DzRaNcRo8_003D)
		{
			_0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D CS_0024_003C_003E8__locals7 = new _0023_003DzQVgboVAKG9fYzrG7yImT3Uk_003D();
			if (item.Name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012119)))
			{
				continue;
			}
			CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D = item.GetShallowCopy();
			if (CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.sketchEntity != null)
			{
				CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.Entities.Remove(CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.sketchEntity);
				CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.Entities.RemoveAll((Entity _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D is Dimension && _0023_003DzBJFJHwk_003D.EntityData == CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D.sketchEntity);
			}
			blocks.Add(CS_0024_003C_003E8__locals7._0023_003Dz4MJbOGmRn_0024hs0JaJjw_003D_003D);
		}
		blocks.SetRootBlock(_0023_003DzRaNcRo8_003D.RootBlockName);
	}

	private void _0023_003Dz15Wz9EHE0jMD(IDictionary<string, Block> _0023_003DzUf8_iZ90pWPR)
	{
		_0023_003Dz15Wz9EHE0jMD(new BlockKeyedCollection(_0023_003DzUf8_iZ90pWPR.Values));
	}

	private void _0023_003DzY1qpE85kRYVX(IEnumerable<Layer> _0023_003DzdiNLm7igEUlp)
	{
		layers = new LayerKeyedCollection();
		foreach (Layer item in _0023_003DzdiNLm7igEUlp)
		{
			layers.Add(item);
		}
	}

	protected IList<Entity> GetEntities()
	{
		if (entities.Count == 0 && blocks.hasRootBlock)
		{
			return blocks.RootBlock.Entities;
		}
		return entities;
	}

	protected Size3D ComputeBoundingBox(out Point3D min, out Point3D max)
	{
		min = Point3D.MaxValue;
		max = Point3D.MinValue;
		bool flag = true;
		IList<Entity> list = GetEntities();
		int count = list.Count;
		foreach (Entity item in list)
		{
			if (item.Visible && item.BoxMin != null && layers.TryGetValue(item.LayerName, out var value) && value.Visible)
			{
				item.CombineBoundingBox(null, min, max);
				flag = false;
			}
		}
		if (count == 0 || flag)
		{
			Utility.ResetBBox(out min, out max);
		}
		return new Size3D(min, max);
	}

	public override void WorkCancelled(object sender)
	{
		CloseStream();
		if (!string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
		{
			File.Delete(FilePath);
		}
	}

	protected internal void SetWriter(IDisposable writer)
	{
		_0023_003DzFSa8eGE_003D = writer;
	}

	protected internal virtual void CloseStream()
	{
		if (_0023_003DzFSa8eGE_003D == null)
		{
			return;
		}
		if (writeFileCloseStream)
		{
			_0023_003DzFSa8eGE_003D.Dispose();
			if (_0023_003DziOkx2W0_003D != null)
			{
				_0023_003DziOkx2W0_003D.Close();
			}
		}
		else if (_0023_003DzFSa8eGE_003D is StreamWriter)
		{
			((StreamWriter)_0023_003DzFSa8eGE_003D).Flush();
		}
		else if (_0023_003DzFSa8eGE_003D is TextWriter)
		{
			((TextWriter)_0023_003DzFSa8eGE_003D).Flush();
		}
		else if (_0023_003DzFSa8eGE_003D is BinaryWriter)
		{
			((BinaryWriter)_0023_003DzFSa8eGE_003D).Flush();
		}
		else
		{
			if (!(_0023_003DzFSa8eGE_003D is XmlWriter))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012104));
			}
			((XmlWriter)_0023_003DzFSa8eGE_003D).Flush();
		}
	}

	protected bool IsVisible(Entity ent, out Layer layer)
	{
		layer = null;
		if (!ent.Visible || (selectedOnly && !ent.Selected) || layers.Count != 0)
		{
			if (ent.Visible && (!selectedOnly || ent.Selected) && layers.TryGetValue(ent.LayerName, out layer))
			{
				return layer.Visible;
			}
			return false;
		}
		return true;
	}

	public static string RemoveInvalidChars(string dirtyFilePath)
	{
		_0023_003DzTuVpKOmn_0024_JKUgymcsOOPVA_003D CS_0024_003C_003E8__locals2 = new _0023_003DzTuVpKOmn_0024_JKUgymcsOOPVA_003D();
		CS_0024_003C_003E8__locals2._0023_003Dz_noZGudieQMBDynTTA_003D_003D = new char[13]
		{
			'<', '>', '/', '\\', '"', ';', ':', '?', '*', '|',
			',', '=', '\''
		};
		return string.Join(string.Empty, dirtyFilePath.Select((char _0023_003Dzt_m8zV0_003D) => (!CS_0024_003C_003E8__locals2._0023_003Dz_noZGudieQMBDynTTA_003D_003D.Contains(_0023_003Dzt_m8zV0_003D)) ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), _0023_003Dzt_m8zV0_003D) : _0023_003Dqpzzh9v4WpaIPnVWvcTB2AbHruQW6AvGVPXBMxEXCrj1MLMOs4J4mgNVxpd44Amo5(_0023_003Dzt_m8zV0_003D)));
	}

	internal static string _0023_003Dqpzzh9v4WpaIPnVWvcTB2AbHruQW6AvGVPXBMxEXCrj1MLMOs4J4mgNVxpd44Amo5(char _0023_003Dzt_m8zV0_003D)
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941671) + ((_0023_003Dzt_m8zV0_003D > 'ÿ') ? string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012314), (uint)_0023_003Dzt_m8zV0_003D) : string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012331), (uint)_0023_003Dzt_m8zV0_003D)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679);
	}
}
