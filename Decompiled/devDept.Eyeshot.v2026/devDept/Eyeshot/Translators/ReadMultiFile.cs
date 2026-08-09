using System;
using System.Collections;
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

public class ReadMultiFile : ReadFile
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		internal bool _0023_003Dz4KGwdTkvLJpwcS27J0wjOH0_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is BlockReference;
		}
	}

	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public ReadMultiFile _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public Hashtable _0023_003DzV3JyKruiUPjq;

		internal bool _0023_003DzqXU4HCODMdEWWKNgsA_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D is BlockReference blockReference)
			{
				return _0023_003DzV3JyKruiUPjq.ContainsValue(blockReference.BlockName);
			}
			return false;
		}
	}

	private sealed class _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D
	{
		public object _0023_003DziQHIey0_003D;

		public HashSet<string> _0023_003DzcVuV_VjChE2u;

		public _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003DzDAPpG7P4CYUuw_Qlig_003D_003D(string _0023_003Dzsuiz4uo_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			FileSerializer fileSerializer;
			lock (_0023_003DziQHIey0_003D)
			{
				fileSerializer = FileSerializer._0023_003Dzh8CFbARXgKhypdBv6g_003D_003D(_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DziOZRUZtU2Dib ?? _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.FileSerializer, ReadFile.GetVersion(_0023_003Dzsuiz4uo_003D));
			}
			ReadFile readFile = new ReadFile(_0023_003Dzsuiz4uo_003D, fileSerializer);
			readFile.DoWork();
			lock (_0023_003DziQHIey0_003D)
			{
				_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs._0023_003DzPLA25heFyQvn1PK3USm2ZZY_003D(readFile);
			}
			if (_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzV3JyKruiUPjq.Count > 0)
			{
				readFile.Blocks.RootBlock.Entities.RemoveAll(_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzqXU4HCODMdEWWKNgsA_003D_003D);
			}
			_0023_003Dz8LKgfokLtD7X(readFile.Blocks.RootBlock, readFile.FilePath);
			lock (_0023_003DziQHIey0_003D)
			{
				_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.Blocks.Add(readFile.Blocks.RootBlock);
			}
			if (!_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003DzcVuV_VjChE2u.Count, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.ReadingText, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzmHS7frs_003D, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dzjvn7P10_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + System.IO.Path.GetFileName(readFile.FilePath)))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	private sealed class _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D
	{
		public MultiFileItem _0023_003DzUBZd570_003D;

		internal bool _0023_003DzTdNy6ssIO8X9D5jzuQ_003D_003D(BlockReference _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.BlockName.Equals(_0023_003DzUBZd570_003D.BlockName, StringComparison.OrdinalIgnoreCase);
		}

		internal bool _0023_003DzLDfHmob3SPEVkK13LQ_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D is BlockReference blockReference)
			{
				return blockReference.BlockName == _0023_003DzUBZd570_003D.BlockName;
			}
			return false;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiFileItem[] _0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiFileData[] _0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D;

	public bool StructureOnly;

	public bool Parallel = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal HashSet<string> _0023_003DzU3RI4flfDNy0LTUMug_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal FileSerializer _0023_003DziOZRUZtU2Dib;

	public MultiFileItem[] SubItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D;
		}
	}

	public MultiFileData[] TreeItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D;
		}
	}

	public ReadMultiFile(string filePath, bool headerOnly = false, contentType deserializationType = contentType.GeometryAndTessellation)
		: base(filePath, headerOnly, deserializationType)
	{
	}

	public ReadMultiFile(string filePath, contentType deserializationType)
		: base(filePath, deserializationType)
	{
	}

	public ReadMultiFile(string filePath, FileSerializer fileSerializer, bool headerOnly = false)
		: base(filePath, fileSerializer, headerOnly)
	{
	}

	private void _0023_003DzzRu2NInfrDHg(MultiFileItem[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzE0n8NhQViHA4(MultiFileData[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal string _0023_003DzOE0kLQA7rpUO()
	{
		return System.IO.Path.GetDirectoryName(base.FilePath);
	}

	internal bool _0023_003DzgeyMxAXyBuRB()
	{
		return _0023_003DziOZRUZtU2Dib != null;
	}

	private bool _0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D()
	{
		if (!StructureOnly)
		{
			return Parallel;
		}
		return false;
	}

	internal static bool _0023_003Dz8LKgfokLtD7X(Block _0023_003DzLeyHB00_003D, string _0023_003DzS5vi7RU_003D)
	{
		if (string.IsNullOrWhiteSpace(_0023_003DzLeyHB00_003D.FilePath))
		{
			return false;
		}
		bool num = string.Equals(System.IO.Path.GetExtension(_0023_003DzLeyHB00_003D.FilePath), System.IO.Path.GetExtension(_0023_003DzS5vi7RU_003D), StringComparison.OrdinalIgnoreCase);
		if (num)
		{
			_0023_003DzLeyHB00_003D.FilePath = _0023_003DzS5vi7RU_003D;
		}
		return num;
	}

	internal override void _0023_003DziovQPjxLLGlj(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		base._0023_003DziovQPjxLLGlj(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzjvn7P10_003D);
		if (base.HeaderOnly || base.FileSerializer.FileHeader.FileMode != fileType.Assembly)
		{
			return;
		}
		if (base.Result)
		{
			BlockKeyedCollection blocks = base.Blocks;
			if (blocks == null || blocks.Count != 1)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010175));
			}
			_0023_003Dz8LKgfokLtD7X(base.Blocks[0], base.FilePath);
			string text = base.FileSerializer.FileBody.Paths[0];
			if (!_0023_003DzgeyMxAXyBuRB())
			{
				_0023_003DzU3RI4flfDNy0LTUMug_003D_003D = new HashSet<string>();
			}
			List<MultiFileData> list = new List<MultiFileData>();
			_0023_003DzzRu2NInfrDHg(new MultiFileItem[base.FileSerializer.FileBody.Paths.Length - 1]);
			for (int i = 1; i < base.FileSerializer.FileBody.Paths.Length; i++)
			{
				MultiFileItem multiFileItem = new MultiFileItem(base.FileSerializer.FileBody.Paths[i], base.FileSerializer.FileBody.Types[i]);
				if (!multiFileItem._0023_003DzcNcumvBppeDS)
				{
					MultiFileItem multiFileItem2 = new MultiFileItem(multiFileItem._0023_003Dz1HT_00242y8qARt9(_0023_003DzOE0kLQA7rpUO()), multiFileItem.FileType);
					if (multiFileItem2._0023_003DzcNcumvBppeDS)
					{
						multiFileItem = multiFileItem2;
					}
					else if (!string.IsNullOrEmpty(text))
					{
						multiFileItem2 = new MultiFileItem(multiFileItem.FullPath.Replace(System.IO.Path.GetDirectoryName(text), _0023_003DzOE0kLQA7rpUO()), multiFileItem.FileType);
						if (multiFileItem2._0023_003DzcNcumvBppeDS)
						{
							multiFileItem = multiFileItem2;
						}
					}
				}
				SubItems[i - 1] = multiFileItem;
			}
			list.Add(new MultiFileData(base.FilePath, fileType.Assembly, SubItems));
			List<BlockReference> list2 = base.Entities.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz4KGwdTkvLJpwcS27J0wjOH0_003D).Cast<BlockReference>().ToList();
			_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzV3JyKruiUPjq = new Hashtable();
			for (int j = 0; j < SubItems.Length; j++)
			{
				_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2 = new _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D();
				_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D = SubItems[j];
				if (!_0023_003DzgeyMxAXyBuRB() && !_0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D())
				{
					if (SubItems.Length == 1)
					{
						StartContinuousAnimation(base.ReadingText, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + System.IO.Path.GetFileName(base.FilePath));
					}
					else if (!UpdateProgressAndCheckCancelled(j, SubItems.Length, base.ReadingText, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzjvn7P10_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + System.IO.Path.GetFileName(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FullPath)))
					{
						return;
					}
				}
				BlockReference[] array = list2.Where(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzTdNy6ssIO8X9D5jzuQ_003D_003D).ToArray();
				foreach (BlockReference item in array)
				{
					list2.Remove(item);
				}
				if (!_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D._0023_003DzcNcumvBppeDS)
				{
					base.Entities.RemoveAll(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzLDfHmob3SPEVkK13LQ_003D_003D);
					_0023_003DzAfC8_OT2b166(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FullPath, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzV3JyKruiUPjq);
				}
				else
				{
					if (base.Blocks.Contains(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.BlockName) || _0023_003DzU3RI4flfDNy0LTUMug_003D_003D.Contains(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.BlockName))
					{
						continue;
					}
					_0023_003DzU3RI4flfDNy0LTUMug_003D_003D.Add(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.BlockName);
					if (_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FileType == fileType.Standard && StructureOnly)
					{
						base.Blocks.Add(new Block(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.BlockName));
					}
					else if (_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FileType != fileType.Standard || !_0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D())
					{
						FileSerializer fileSerializer = FileSerializer._0023_003Dzh8CFbARXgKhypdBv6g_003D_003D(_0023_003DziOZRUZtU2Dib ?? base.FileSerializer, ReadFile.GetVersion(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FullPath));
						ReadFile readFile = ((_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FileType == fileType.Assembly) ? new ReadMultiFile(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FullPath, fileSerializer)
						{
							StructureOnly = (StructureOnly || Parallel),
							Parallel = false,
							_0023_003DziOZRUZtU2Dib = (_0023_003DziOZRUZtU2Dib ?? base.FileSerializer),
							_0023_003DzU3RI4flfDNy0LTUMug_003D_003D = _0023_003DzU3RI4flfDNy0LTUMug_003D_003D
						} : new ReadFile(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FullPath, fileSerializer));
						readFile.DoWork();
						if (!_0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D())
						{
							_0023_003DzPLA25heFyQvn1PK3USm2ZZY_003D(readFile);
						}
						if (_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzUBZd570_003D.FileType == fileType.Assembly)
						{
							list.AddRange(((ReadMultiFile)readFile).TreeItems);
						}
						else
						{
							_0023_003Dz8LKgfokLtD7X(readFile.Blocks[0], readFile.FilePath);
						}
					}
				}
			}
			_0023_003DzE0n8NhQViHA4(list.ToArray());
			if (!_0023_003DzgeyMxAXyBuRB() && _0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D())
			{
				_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2 = new _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D();
				_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2;
				_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzcVuV_VjChE2u = new HashSet<string> { base.FilePath };
				MultiFileData[] treeItems = TreeItems;
				foreach (MultiFileData multiFileData in treeItems)
				{
					_0023_003DzmLPoG7VMMMxJ(_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzcVuV_VjChE2u, multiFileData.FullPath, _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzV3JyKruiUPjq);
					MultiFileItem[] items = multiFileData.Items;
					foreach (MultiFileItem multiFileItem3 in items)
					{
						_0023_003DzmLPoG7VMMMxJ(_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzcVuV_VjChE2u, multiFileItem3.FullPath, _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzV3JyKruiUPjq);
					}
				}
				_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzcVuV_VjChE2u.Remove(base.FilePath);
				ResetProgressParallel();
				_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DziQHIey0_003D = new object();
				System.Threading.Tasks.Parallel.ForEach(_0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzcVuV_VjChE2u, _0023_003DzD1_Kzrkge0HP4ZGbhF4kma4_003D2._0023_003DzDAPpG7P4CYUuw_Qlig_003D_003D);
			}
			if (!_0023_003DzgeyMxAXyBuRB())
			{
				base.FileSerializer._0023_003Dz29IIb3Mk_i5NEhByLA_003D_003D();
				UpdateProgressTo100(base.ReadingText, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D);
			}
		}
		_0023_003DziOZRUZtU2Dib = null;
	}

	private void _0023_003DzAfC8_OT2b166(string _0023_003DzS5vi7RU_003D, Hashtable _0023_003DzV3JyKruiUPjq)
	{
		if (!_0023_003DzV3JyKruiUPjq.Contains(_0023_003DzS5vi7RU_003D))
		{
			_0023_003DzV3JyKruiUPjq.Add(_0023_003DzS5vi7RU_003D, System.IO.Path.GetFileNameWithoutExtension(_0023_003DzS5vi7RU_003D));
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010107) + _0023_003DzS5vi7RU_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984499));
		}
	}

	private void _0023_003DzmLPoG7VMMMxJ(HashSet<string> _0023_003DzcVuV_VjChE2u, string _0023_003DzS5vi7RU_003D, Hashtable _0023_003DzV3JyKruiUPjq)
	{
		if (!_0023_003DzcVuV_VjChE2u.Contains(_0023_003DzS5vi7RU_003D))
		{
			if (File.Exists(_0023_003DzS5vi7RU_003D))
			{
				_0023_003DzcVuV_VjChE2u.Add(_0023_003DzS5vi7RU_003D);
			}
			else
			{
				_0023_003DzAfC8_OT2b166(_0023_003DzS5vi7RU_003D, _0023_003DzV3JyKruiUPjq);
			}
		}
	}

	private void _0023_003DzPLA25heFyQvn1PK3USm2ZZY_003D(ReadFile _0023_003DzHzX2wew_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003DzHzX2wew_003D.Log))
		{
			log.AppendLine(_0023_003DzHzX2wew_003D.FilePath);
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			log.AppendLine(_0023_003DzHzX2wew_003D.Log);
		}
		conflictPolicy _0023_003DzkDT_0024HYsJqA7X = conflictPolicy.KeepExisting;
		Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.LineTypes, base.LineTypes, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.TextStyles, base.TextStyles, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.Materials, base.Materials, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.HatchPatterns, base.HatchPatterns, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.Layers, base.Layers, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		if (!_0023_003DzcohQ5kkFEmIHdb_0024aHg_003D_003D())
		{
			Document._0023_003DzBlcGo_o_003D(_0023_003DzHzX2wew_003D.Blocks, base.Blocks, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		}
	}
}
