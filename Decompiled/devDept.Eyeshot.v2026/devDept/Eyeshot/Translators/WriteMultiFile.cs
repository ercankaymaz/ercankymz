using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class WriteMultiFile : WriteFile, IDisposable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<KeyValuePair<Block, MultiFileData>, Block> _0023_003DzAHkUQ25JJUbtOJ8wYQ_003D_003D;

		public static Func<KeyValuePair<Block, MultiFileData>, MultiFileData> _0023_003DzrF3VrLeDHDKjx755jA_003D_003D;

		internal Block _0023_003Dz2RnN77AtFmaLxGRKEFiDrdc_003D(KeyValuePair<Block, MultiFileData> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal MultiFileData _0023_003DzpsW4dPvxFefJ0VaE4KG6PIw_003D(KeyValuePair<Block, MultiFileData> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value;
		}
	}

	private sealed class _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D
	{
		public WriteMultiFile _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public string _0023_003Dzw4HFuLkAwJqJ;

		public string _0023_003DzMGUyiVg_003D;

		public int _0023_003Dzyc7GeCc_003D;

		public int _0023_003DzQAdLXfc_003D;

		internal void _0023_003DzS9ocMkVejO5WtwXP0w_003D_003D(KeyValuePair<Block, MultiFileData> _0023_003DzYYa3aQ4_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			if (!_0023_003DzopRx0_MBcTQs._0023_003Dzg7BEJXVoKNDc(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003DzYYa3aQ4_003D, _0023_003Dzw4HFuLkAwJqJ, _0023_003DzMGUyiVg_003D, ref _0023_003Dzyc7GeCc_003D, _0023_003DzQAdLXfc_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzG0N8_kgQl29N;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzkgAA_0024fsthtTi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003Dz_9gqaAPhJqoG;

	protected internal bool updateThubmnails;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzNLDeJPs6uARDbdr4z7FrTixH6XcxePt0GA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013182);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzHXt_0024dOQszyr_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _0023_003DzJPqIE9I_003D = new object();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IViewport _0023_003Dz_9x7ldA5ikQCKtjHBrNEYNk_003D;

	protected internal bool parallel;

	public string[] WrittenFiles => _0023_003DzHXt_0024dOQszyr_.ToArray();

	public string UpdatingThumbnailsText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNLDeJPs6uARDbdr4z7FrTixH6XcxePt0GA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzNLDeJPs6uARDbdr4z7FrTixH6XcxePt0GA_003D_003D = value;
		}
	}

	public WriteMultiFile(DesignDocument designDocument, string filePath, FileSerializer fileSerializer = null)
		: this(new WriteMultiFileParams(designDocument), filePath, fileSerializer)
	{
	}

	public WriteMultiFile(IDesign design, string filePath, FileSerializer fileSerializer = null)
		: this(design.Document, filePath, fileSerializer)
	{
	}

	public WriteMultiFile(WriteMultiFileParams writeMultiFileParams, string filePath, FileSerializer fileSerializer = null)
		: base(writeMultiFileParams, filePath, fileSerializer)
	{
		updateThubmnails = writeMultiFileParams.SaveThumbnail && writeMultiFileParams.UpdateThumbnails;
		parallel = writeMultiFileParams.Parallel;
		_0023_003DzG0N8_kgQl29N = writeMultiFileParams.BlockName;
		_0023_003DzkgAA_0024fsthtTi = writeMultiFileParams.StandardExtension;
		_0023_003Dz_9gqaAPhJqoG = writeMultiFileParams.AssemblyExtension;
		if (_0023_003DzcoG1S4w_003D?.workspace?.ActiveViewport != null)
		{
			_0023_003Dz_9x7ldA5ikQCKtjHBrNEYNk_003D = (IViewport)_0023_003DzcoG1S4w_003D.workspace.ActiveViewport.Clone();
		}
	}

	public void Dispose()
	{
		_0023_003Dz_9x7ldA5ikQCKtjHBrNEYNk_003D?.Dispose();
		_0023_003Dz_9x7ldA5ikQCKtjHBrNEYNk_003D = null;
	}

	internal override void _0023_003DzyypUlU_QQEqN(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2 = new _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D();
		_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		try
		{
			if (string.IsNullOrEmpty(base.FilePath))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013150) + base.FilePath + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013361));
			}
			if (_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D == null)
			{
				PrepareEnvironmentData();
			}
			IList<Entity> list = _0023_003Dz2C9s0fA51oG9W2QlBcjjQew_003D();
			SynchronizeAttributeReference(blocks, list);
			if (FileSerializer == null)
			{
				FileSerializer = new FileSerializer();
			}
			Dictionary<Block, MultiFileData> dictionary = new Dictionary<Block, MultiFileData>();
			string text = Path.GetDirectoryName(base.FilePath);
			if (string.IsNullOrEmpty(text))
			{
				text = Directory.GetCurrentDirectory();
			}
			_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D = Path.GetExtension(base.FilePath);
			_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzw4HFuLkAwJqJ = Path.GetFileNameWithoutExtension(base.FilePath);
			string _0023_003DzP3NJE_0024vsAbl;
			if (list.Count > 0)
			{
				string fullPath = _0023_003DzwQphWG9dpgmb(fileType.Standard, text, base.FilePath, null, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D, out _0023_003DzP3NJE_0024vsAbl);
				dictionary.Add(null, new MultiFileData(fullPath, fileType.Standard, _0023_003DzT81qQ6jIZ4r_(list, dictionary, base.FilePath, text, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D)));
			}
			foreach (Block block in blocks)
			{
				if (!dictionary.ContainsKey(block))
				{
					string text2 = (blocks._0023_003Dzm6dsCMpMVy24(block) ? _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzw4HFuLkAwJqJ : block.Name);
					string fullPath2 = _0023_003DzwQphWG9dpgmb(fileType.Assembly, text, text2, block.FilePath, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D, out _0023_003DzP3NJE_0024vsAbl);
					dictionary.Add(block, new MultiFileData(fullPath2, fileType.Assembly, _0023_003DzT81qQ6jIZ4r_(block.Entities, dictionary, text2, text, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D)));
				}
			}
			dictionary = dictionary.Reverse().ToDictionary(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz2RnN77AtFmaLxGRKEFiDrdc_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzpsW4dPvxFefJ0VaE4KG6PIw_003D);
			HashSet<string> hashSet = new HashSet<string>();
			foreach (KeyValuePair<Block, MultiFileData> item in dictionary)
			{
				MultiFileData value = item.Value;
				hashSet.Add(value.FullPath);
				MultiFileItem[] items = value.Items;
				foreach (MultiFileItem multiFileItem in items)
				{
					if (multiFileItem.FileType == fileType.Assembly)
					{
						hashSet.Add(multiFileItem.FullPath);
					}
				}
			}
			_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzQAdLXfc_003D = hashSet.Count;
			hashSet.Clear();
			_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzyc7GeCc_003D = 0;
			_0023_003DzHXt_0024dOQszyr_ = new List<string>(_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzQAdLXfc_003D);
			FileSerializer._0023_003DzPiptok69u2x3(content, tag, version);
			if (parallel)
			{
				Parallel.ForEach(dictionary, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzS9ocMkVejO5WtwXP0w_003D_003D);
			}
			else
			{
				foreach (KeyValuePair<Block, MultiFileData> item2 in dictionary)
				{
					if (!_0023_003Dzg7BEJXVoKNDc(_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzmHS7frs_003D, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzjvn7P10_003D, item2, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzw4HFuLkAwJqJ, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzMGUyiVg_003D, ref _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzyc7GeCc_003D, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzQAdLXfc_003D))
					{
						break;
					}
				}
			}
			_0023_003DzcoG1S4w_003D?.workspace?.UpdateThumbnails(this, FileSerializer, _0023_003DzHXt_0024dOQszyr_, _0023_003Dz_9x7ldA5ikQCKtjHBrNEYNk_003D, updateThubmnails, thumbnailBackgroundColor, log, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzmHS7frs_003D, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003Dzjvn7P10_003D);
			UpdateProgressTo100(base.WritingText, _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D2._0023_003DzmHS7frs_003D);
		}
		catch (Exception ex)
		{
			if (FileSerializer != null && !string.IsNullOrEmpty(FileSerializer.Log))
			{
				log.AppendLine(FileSerializer.Log);
			}
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
		}
	}

	private bool _0023_003Dzg7BEJXVoKNDc(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, KeyValuePair<Block, MultiFileData> _0023_003DzYYa3aQ4_003D, string _0023_003Dzw4HFuLkAwJqJ, string _0023_003DzMGUyiVg_003D, ref int _0023_003Dzyc7GeCc_003D, int _0023_003DzQAdLXfc_003D)
	{
		MultiFileData value = _0023_003DzYYa3aQ4_003D.Value;
		fileType fileType2 = value.FileType;
		FileSerializer fileSerializer = FileSerializer._0023_003Dzh8CFbARXgKhypdBv6g_003D_003D(FileSerializer, FileSerializer.HeaderVersion);
		if (!string.IsNullOrEmpty(value._0023_003DzL4vDcS6n01rR()) && !Directory.Exists(value._0023_003DzL4vDcS6n01rR()))
		{
			Directory.CreateDirectory(value._0023_003DzL4vDcS6n01rR());
		}
		if (fileType2 == fileType.Assembly)
		{
			_0023_003DzNy4zP1N5OROK(value, out var _0023_003Dzv7xH9gk_003D, out var _0023_003DzCULckQQ_003D, out var _0023_003DzTLd6lkE_003D);
			bool flag = Block.IsLeaf(_0023_003Dzv7xH9gk_003D);
			Block key = _0023_003DzYYa3aQ4_003D.Key;
			BlockKeyedCollection blockKeyedCollection = null;
			bool flag2 = blocks._0023_003Dzm6dsCMpMVy24(key);
			if (!string.IsNullOrEmpty(_0023_003DzG0N8_kgQl29N) && !key.Name.Equals(_0023_003DzG0N8_kgQl29N, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			string dirtyFilePath = (_0023_003DzIdAw6eeptKzR(key.FilePath) ? Path.GetFileNameWithoutExtension(key.FilePath) : ((!flag2) ? key.Name : _0023_003Dzw4HFuLkAwJqJ));
			string text = WriteFileAsync.RemoveInvalidChars(dirtyFilePath);
			bool num = !text.Equals(key.Name, StringComparison.OrdinalIgnoreCase);
			Block block = key;
			if (num)
			{
				Block block2 = new Block(key, _0023_003DzQmmjROxvNJdJ: false, _0023_003Dzu9oxwJ_zKlMt: false);
				block2.CustomData = key.CustomData;
				block2._0023_003Dzp6_0024ma46EnjuJk7zPtQ_003D_003D(key.MatesList);
				block = block2;
				if (flag)
				{
					block.Entities.AddRange(_0023_003Dzv7xH9gk_003D);
				}
			}
			else if (!flag)
			{
				Block block3 = new Block(key, _0023_003DzQmmjROxvNJdJ: false, _0023_003Dzu9oxwJ_zKlMt: false);
				block3.CustomData = key.CustomData;
				block3._0023_003Dzp6_0024ma46EnjuJk7zPtQ_003D_003D(key.MatesList);
				block = block3;
			}
			if (flag)
			{
				_0023_003Dzv7xH9gk_003D = null;
			}
			if (num)
			{
				block.Name = text;
			}
			blockKeyedCollection = new BlockKeyedCollection(new List<Block> { block });
			blockKeyedCollection.SetRootBlock(block.Name);
			WriteFileParams writeFileParams = new WriteFileParams(_0023_003Dzv7xH9gk_003D, layers, blockKeyedCollection, materials, textStyles, lineTypes, content, serializationMode, (!flag) ? fileType2 : fileType.Standard, key.Units, _0023_003Dz9rsu4TwhLBvn: false, null, hatchPatterns)
			{
				Author = author,
				Organization = organization,
				OriginatingSystem = originatingSystem,
				Tag = tag,
				Purge = true
			};
			string text2 = (flag ? Path.ChangeExtension(value.FullPath, _0023_003DzkgAA_0024fsthtTi) : value.FullPath);
			if (_0023_003DzIdAw6eeptKzR(block.FilePath))
			{
				block.FilePath = text2;
			}
			WriteFile writeFile = ((!flag) ? new _0023_003DzyfpgbkoqJF24YFxVKu2FD0mBwXw2xTILyn_ppCVbzxH1(writeFileParams, text2, block, flag2 ? _0023_003Dz10qtbIGWAWjL : null, flag2 ? _0023_003Dzes3OoosNHoOi6yRH1w_003D_003D : null, _0023_003DzCULckQQ_003D.ToArray(), _0023_003DzTLd6lkE_003D.ToArray(), fileSerializer) : new WriteFile(writeFileParams, text2, fileSerializer)
			{
				_0023_003DzK8Kwyo8MF5AD = block,
				_0023_003Dz10qtbIGWAWjL = (flag2 ? _0023_003Dz10qtbIGWAWjL : null),
				_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D = (flag2 ? _0023_003Dzes3OoosNHoOi6yRH1w_003D_003D : null)
			});
			writeFile.DoWork();
			lock (_0023_003DzJPqIE9I_003D)
			{
				_0023_003DzHXt_0024dOQszyr_.Add(writeFile.FilePath);
			}
			if (!string.IsNullOrEmpty(writeFile.Log))
			{
				log.AppendLine(value.FullPath);
				log.AppendLine(writeFile.Log);
			}
			if (!UpdateProgressAndCheckCancelled(++_0023_003Dzyc7GeCc_003D, _0023_003DzQAdLXfc_003D, base.WritingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, Path.GetFileName(text2)))
			{
				return false;
			}
			return true;
		}
		string text3 = value.Items[0]._0023_003Dz9j7EUB0_003D.GetType().ToString().Split('.')
			.LastOrDefault();
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013352) + value.FullPath + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013343) + text3);
	}

	private void _0023_003DzNy4zP1N5OROK(MultiFileData _0023_003DzgcqOrQB1rYcH, out List<Entity> _0023_003Dzv7xH9gk_003D, out List<string> _0023_003DzCULckQQ_003D, out List<fileType> _0023_003DzTLd6lkE_003D)
	{
		_0023_003Dzv7xH9gk_003D = new List<Entity>();
		_0023_003DzCULckQQ_003D = new List<string> { _0023_003DzgcqOrQB1rYcH.FullPath };
		_0023_003DzTLd6lkE_003D = new List<fileType> { _0023_003DzgcqOrQB1rYcH.FileType };
		MultiFileItem[] items = _0023_003DzgcqOrQB1rYcH.Items;
		foreach (MultiFileItem multiFileItem in items)
		{
			bool flag = false;
			bool flag2 = false;
			if (multiFileItem._0023_003Dz9j7EUB0_003D is BlockReference blockReference)
			{
				flag2 = true;
				_0023_003Dzv7xH9gk_003D.Add(blockReference);
				flag = blocks[blockReference.BlockName].IsLeaf();
			}
			else
			{
				_0023_003Dzv7xH9gk_003D.Add(multiFileItem._0023_003Dz9j7EUB0_003D);
			}
			if (flag2)
			{
				if (flag)
				{
					_0023_003DzCULckQQ_003D.Add(Path.ChangeExtension(multiFileItem.FullPath, _0023_003DzkgAA_0024fsthtTi));
					_0023_003DzTLd6lkE_003D.Add(fileType.Standard);
				}
				else
				{
					_0023_003DzCULckQQ_003D.Add(multiFileItem.FullPath);
					_0023_003DzTLd6lkE_003D.Add(multiFileItem.FileType);
				}
			}
		}
	}

	private string _0023_003DzwQphWG9dpgmb(fileType _0023_003DzEKSHIVc_003D, string _0023_003Dzg5oC_Hs_003D, string _0023_003DznkMU43c_003D, string _0023_003DzOWQYS7a76_00243n, string _0023_003DzMGUyiVg_003D, out string _0023_003DzP3NJE_0024vsAbl2)
	{
		if (_0023_003DzIdAw6eeptKzR(_0023_003DzOWQYS7a76_00243n))
		{
			_0023_003DzP3NJE_0024vsAbl2 = WriteFileAsync.RemoveInvalidChars(Path.GetFileNameWithoutExtension(_0023_003DzOWQYS7a76_00243n));
			string text = _0023_003Dz_9gqaAPhJqoG;
			return Path.Combine(Path.GetDirectoryName(_0023_003DzOWQYS7a76_00243n), _0023_003DzP3NJE_0024vsAbl2) + text;
		}
		_0023_003DzP3NJE_0024vsAbl2 = WriteFileAsync.RemoveInvalidChars(_0023_003DznkMU43c_003D);
		_0023_003DzMGUyiVg_003D = ((_0023_003DzEKSHIVc_003D == fileType.Standard) ? _0023_003DzkgAA_0024fsthtTi : _0023_003Dz_9gqaAPhJqoG);
		return Path.Combine(_0023_003Dzg5oC_Hs_003D, _0023_003DzP3NJE_0024vsAbl2) + _0023_003DzMGUyiVg_003D;
	}

	private bool _0023_003DzIdAw6eeptKzR(string _0023_003DzOWQYS7a76_00243n)
	{
		if (string.IsNullOrEmpty(_0023_003DzOWQYS7a76_00243n))
		{
			return false;
		}
		string extension = Path.GetExtension(_0023_003DzOWQYS7a76_00243n);
		if (!extension.Equals(_0023_003Dz_9gqaAPhJqoG, StringComparison.OrdinalIgnoreCase))
		{
			return extension.Equals(_0023_003DzkgAA_0024fsthtTi, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private MultiFileItem[] _0023_003DzT81qQ6jIZ4r_(IList<Entity> _0023_003Dzv7xH9gk_003D, Dictionary<Block, MultiFileData> _0023_003Dz_0024C5IoiWd8PC5, string _0023_003DzvjIPlKM5C5r_0024, string _0023_003Dzsuiz4uo_003D, string _0023_003DzMGUyiVg_003D)
	{
		List<MultiFileItem> list = new List<MultiFileItem>();
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is BlockReference blockReference)
			{
				if (!blocks.TryGetValue(blockReference.BlockName, out var value))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013300) + blockReference.BlockName);
				}
				fileType fileType2 = fileType.Assembly;
				string _0023_003DzP3NJE_0024vsAbl = (blocks._0023_003Dzm6dsCMpMVy24(value) ? Path.GetFileNameWithoutExtension(base.FilePath) : value.Name);
				string text = _0023_003DzwQphWG9dpgmb(fileType2, _0023_003Dzsuiz4uo_003D, _0023_003DzP3NJE_0024vsAbl, value.FilePath, _0023_003DzMGUyiVg_003D, out _0023_003DzP3NJE_0024vsAbl);
				if (!_0023_003DzP3NJE_0024vsAbl.Equals(value.Name, StringComparison.OrdinalIgnoreCase))
				{
					value.blockNameForExport = _0023_003DzP3NJE_0024vsAbl;
					blockReference.blockNameForExport = _0023_003DzP3NJE_0024vsAbl;
				}
				list.Add(new MultiFileItem(item, text, fileType2));
				if (!_0023_003Dz_0024C5IoiWd8PC5.ContainsKey(value))
				{
					_0023_003Dz_0024C5IoiWd8PC5.Add(value, new MultiFileData(text, fileType2, _0023_003DzT81qQ6jIZ4r_(value.Entities, _0023_003Dz_0024C5IoiWd8PC5, _0023_003DzP3NJE_0024vsAbl, Path.GetDirectoryName(text), _0023_003DzMGUyiVg_003D)));
				}
			}
			else
			{
				list.Add(new MultiFileItem(item, null, fileType.Standard));
			}
		}
		return list.ToArray();
	}
}
