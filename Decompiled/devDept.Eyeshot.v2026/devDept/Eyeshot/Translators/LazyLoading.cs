using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class LazyLoading : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiFileData[] _0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003DzHIZvtvXiyOCgyZnCkp_0024n1bk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DznCUVnf0cii3qp_7YyxLTmb0_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly HashSet<string> _0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D = new HashSet<string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FileSerializer _0023_003DzYGQF6PlDuJWb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzG0N8_kgQl29N;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ReadFile _0023_003DzFyF33NNf6BAn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private fileType _0023_003DzNukoB12SjkQD;

	public bool Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = value;
		}
	}

	public MultiFileData[] TreeItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzYAIKONIEm5jrj1jkQCtlVuM_003D = value;
		}
	}

	public string[] LoadedBlockNames
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzHIZvtvXiyOCgyZnCkp_0024n1bk_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzHIZvtvXiyOCgyZnCkp_0024n1bk_003D = value;
		}
	}

	public bool SkipLoadedBlocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DznCUVnf0cii3qp_7YyxLTmb0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DznCUVnf0cii3qp_7YyxLTmb0_003D = value;
		}
	}

	public bool Parallel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzbnZ1sRYQbPlE7KxmKg_003D_003D = value;
		}
	}

	public HashSet<string> AllLoadedBlockNames => _0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D;

	public string BlockName => _0023_003DzG0N8_kgQl29N;

	public Camera Camera
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = value;
		}
	}

	public LazyLoading(MultiFileData[] treeItems, FileSerializer fileSerializer)
	{
		TreeItems = treeItems;
		_0023_003DzYGQF6PlDuJWb = fileSerializer;
	}

	public void SetBlockName(string blockName)
	{
		_0023_003DzG0N8_kgQl29N = blockName;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		if (string.IsNullOrEmpty(_0023_003DzG0N8_kgQl29N))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998724));
		}
		if (SkipLoadedBlocks && _0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D.Contains(_0023_003DzG0N8_kgQl29N))
		{
			return;
		}
		LoadedBlockNames = null;
		string filePath = string.Empty;
		bool flag = false;
		HashSet<MultiFileItem> hashSet = new HashSet<MultiFileItem>();
		MultiFileData[] treeItems = TreeItems;
		foreach (MultiFileData multiFileData in treeItems)
		{
			if (multiFileData.BlockName.Equals(_0023_003DzG0N8_kgQl29N, StringComparison.OrdinalIgnoreCase))
			{
				_0023_003DzNukoB12SjkQD = multiFileData.FileType;
				filePath = multiFileData.FullPath;
				flag = true;
				_ = multiFileData.Items.LongLength;
				break;
			}
			MultiFileItem[] items = multiFileData.Items;
			foreach (MultiFileItem item in items)
			{
				hashSet.Add(item);
			}
		}
		if (!flag)
		{
			foreach (MultiFileItem item2 in hashSet)
			{
				if (item2.BlockName.Equals(_0023_003DzG0N8_kgQl29N, StringComparison.OrdinalIgnoreCase))
				{
					_0023_003DzNukoB12SjkQD = item2.FileType;
					filePath = item2.FullPath;
					flag = true;
					break;
				}
			}
		}
		hashSet.Clear();
		if (flag)
		{
			FileSerializer fileSerializer = FileSerializer._0023_003Dzh8CFbARXgKhypdBv6g_003D_003D(_0023_003DzYGQF6PlDuJWb, ReadFile.GetVersion(filePath));
			if (_0023_003DzNukoB12SjkQD == fileType.Standard)
			{
				_0023_003DzFyF33NNf6BAn = new ReadFile(filePath, fileSerializer);
			}
			else
			{
				_0023_003DzFyF33NNf6BAn = new ReadMultiFile(filePath, fileSerializer)
				{
					Parallel = Parallel
				};
				if (SkipLoadedBlocks)
				{
					((ReadMultiFile)_0023_003DzFyF33NNf6BAn)._0023_003DzU3RI4flfDNy0LTUMug_003D_003D = _0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D;
				}
			}
			_0023_003DzFyF33NNf6BAn.DoWork(progress, ct);
			if (_0023_003DzNukoB12SjkQD == fileType.Standard)
			{
				ReadMultiFile._0023_003Dz8LKgfokLtD7X(_0023_003DzFyF33NNf6BAn.Blocks[0], _0023_003DzFyF33NNf6BAn.FilePath);
			}
			Result = _0023_003DzFyF33NNf6BAn.Result;
			log.Append(_0023_003DzFyF33NNf6BAn.Log);
		}
		else
		{
			Result = false;
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998666) + _0023_003DzG0N8_kgQl29N);
		}
	}

	public override void WorkCancelled(object sender)
	{
		_0023_003Dzd7C1Wi4_003D();
	}

	public override void WorkFailed(object sender)
	{
		_0023_003Dzd7C1Wi4_003D();
	}

	public void AddTo(IDesign design)
	{
		AddTo(design.Document);
	}

	public virtual void AddTo(DesignDocument design)
	{
		if (_0023_003DzFyF33NNf6BAn == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999421));
		}
		conflictPolicy _0023_003DzkDT_0024HYsJqA7X = conflictPolicy.KeepExisting;
		Document._0023_003DzBlcGo_o_003D(_0023_003DzFyF33NNf6BAn.Materials, design.Materials, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzFyF33NNf6BAn.LineTypes, design.LineTypes, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzFyF33NNf6BAn.HatchPatterns, design.HatchPatterns, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzFyF33NNf6BAn.TextStyles, design.TextStyles, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzFyF33NNf6BAn.Layers, design.Layers, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		bool isOffline = design.Blocks.isOffline;
		if (!isOffline)
		{
			design.Blocks.TakeOffline();
		}
		if (_0023_003DzNukoB12SjkQD == fileType.Standard)
		{
			_0023_003DzxYnq_arPnJL_0024(design, _0023_003DzFyF33NNf6BAn.Blocks[0]);
			LoadedBlockNames = new string[1] { _0023_003DzFyF33NNf6BAn.Blocks[0].Name };
			_0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D.Add(_0023_003DzFyF33NNf6BAn.Blocks[0].Name);
		}
		else
		{
			LoadedBlockNames = new string[_0023_003DzFyF33NNf6BAn.Blocks.Count];
			for (int i = 0; i < _0023_003DzFyF33NNf6BAn.Blocks.Count; i++)
			{
				Block block = _0023_003DzFyF33NNf6BAn.Blocks[i];
				_0023_003DzxYnq_arPnJL_0024(design, block);
				LoadedBlockNames[i] = block.Name;
				_0023_003DztVZ7cWPxm21Qn9WaBA_003D_003D.Add(block.Name);
			}
		}
		if (!isOffline)
		{
			design.Blocks.BringOnline();
		}
		Camera = _0023_003DzFyF33NNf6BAn.Camera;
		_0023_003Dzd7C1Wi4_003D();
	}

	private static void _0023_003DzxYnq_arPnJL_0024(DesignDocument _0023_003DzDh_00246Paw_003D, Block _0023_003Dz9oKx7_0024pbzPfS)
	{
		if (_0023_003DzDh_00246Paw_003D.Blocks.Contains(_0023_003Dz9oKx7_0024pbzPfS))
		{
			_0023_003DzDh_00246Paw_003D.Blocks.ReplaceItem(_0023_003Dz9oKx7_0024pbzPfS);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999349));
	}

	private void _0023_003Dzd7C1Wi4_003D()
	{
		_0023_003DzFyF33NNf6BAn?.Dispose();
		_0023_003DzFyF33NNf6BAn = null;
	}
}
