using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

[Serializable]
public class BlockKeyedCollection : EyeshotDisposableKeyedCollection<Block>
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Block, string> _0023_003DzSl85g4Gc4QTO7lkJgQ_003D_003D;

		internal string _0023_003DzHs2K9IFpehsjtS6Cbg_003D_003D(Block _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003Dz1v6oPQk_003D.Name;
		}
	}

	private sealed class _0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D
	{
		public HashSet<string> _0023_003DzitPFQjPDoJC7;

		internal bool _0023_003Dza4MsG5BaKQCA(Block _0023_003Dz1v6oPQk_003D)
		{
			return !_0023_003DzitPFQjPDoJC7.Contains(_0023_003Dz1v6oPQk_003D.Name);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzKVvJNchirHZDPo2dBYe8BN4_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public BlockKeyedCollection _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			BlockKeyedCollection blockKeyedCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					blockKeyedCollection.isOffline = false;
					IEnumerator<Block> enumerator = blockKeyedCollection.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							Block current = enumerator.Current;
							blockKeyedCollection.CheckAndFixIntegrity(current, blockKeyedCollection.Document);
						}
					}
					finally
					{
						if (num < 0)
						{
							enumerator?.Dispose();
						}
					}
					blockKeyedCollection.Document.Entities._0023_003DzwKw7out1Wc_qZ0PKW_VXjgZOPo59g52tvCdKm_4_003D();
					awaiter = blockKeyedCollection.Document.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(blockKeyedCollection.Document.Entities, null, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	private sealed class _0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D
	{
		public BlockReference _0023_003Dz5I3b_GM_003D;

		internal bool _0023_003DzQOuyFmRy76c7oNjsJacbQgr0lE9t(Block _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003Dz1v6oPQk_003D.Name == _0023_003Dz5I3b_GM_003D.BlockName;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzSO9ILTDhT5eqbj_0024i1VsnJDQ_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public BlockKeyedCollection _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Block _0023_003DzUBZd570_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzjhyg1Go_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			BlockKeyedCollection blockKeyedCollection = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_00b1;
				}
				if (blockKeyedCollection._0023_003DzcGPwwO1_0024N4cL(_0023_003DzUBZd570_003D) && blockKeyedCollection.hasRootBlock && blockKeyedCollection.IndexOf(blockKeyedCollection.RootBlock) == _0023_003Dzjhyg1Go_003D)
				{
					awaiter = _0023_003DzUBZd570_003D.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(_0023_003DzUBZd570_003D.Entities, null, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00b1;
				}
				goto end_IL_000e;
				IL_00b1:
				awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	private sealed class _0023_003DzdhvCo056XFDY94r2_00244pyZWI_003D
	{
		public Block _0023_003DzLeyHB00_003D;

		internal bool _0023_003Dz76YPUdhfRA_0024YCvnzKEv0E5dSiiD5(Block _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003Dz1v6oPQk_003D.Name == _0023_003DzLeyHB00_003D.Name;
		}
	}

	public static string DefaultRootBlockName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951860);

	internal bool isOffline;

	public string RootBlockName { get; }

	internal bool hasRootBlock => !string.IsNullOrEmpty(RootBlockName);

	internal Block RootBlock => this[RootBlockName];

	public BlockKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public BlockKeyedCollection(StringComparer comparer)
		: base((IEqualityComparer<string>)comparer)
	{
	}

	public BlockKeyedCollection(IEnumerable<Block> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	internal BlockKeyedCollection(IEnumerable<Block> _0023_003DzcrILBXg_003D, StringComparer _0023_003Dz4zn204U_003D)
		: base(_0023_003DzcrILBXg_003D, (IEqualityComparer<string>)_0023_003Dz4zn204U_003D)
	{
	}

	public new void Clear()
	{
		ClearInternal(base.Document != null);
	}

	public void Clear(bool addRootBlock)
	{
		ClearInternal(base.Document != null || addRootBlock);
	}

	internal void ClearInternal(bool _0023_003DzVDbVnWQyuPCb = true)
	{
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid(_0023_003Dzo60vEkkaRGxX().RenderContext))
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			_0023_003Dzo60vEkkaRGxX().RenderContext.ClearDynamicBuffers();
		}
		using (IEnumerator<Block> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Block current = enumerator.Current;
				if (base.DisposeItems)
				{
					current.Dispose();
					current.Entities.SetDocument(null);
				}
			}
		}
		base.Clear();
		_0023_003DzsEhiJowLp1sN(null);
		if (_0023_003DzVDbVnWQyuPCb)
		{
			_0023_003Dz2tUjc04_003D();
			_0023_003Dzo60vEkkaRGxX()?.InitializeRootBlock();
		}
	}

	internal override void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D == null)
		{
			foreach (Block item in base.Items)
			{
				item.Dispose();
				item.Entities.SetDocument(_0023_003DzoPlwCJA_003D);
			}
			base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
			return;
		}
		if (base.Count == 0)
		{
			_0023_003Dz2tUjc04_003D();
		}
		else if (!hasRootBlock || !Contains(RootBlockName))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951844));
		}
		base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
		foreach (Block item2 in base.Items)
		{
			item2.Entities.SetDocument(_0023_003DzoPlwCJA_003D);
		}
		_0023_003Dzo60vEkkaRGxX()?.InitializeRootBlock();
	}

	internal void _0023_003Dz2tUjc04_003D()
	{
		Block item = new Block(DefaultRootBlockName);
		Add(item);
		_0023_003DzsEhiJowLp1sN(DefaultRootBlockName);
	}

	internal void _0023_003DzsEhiJowLp1sN(string _0023_003DzPzO_0024GUk_003D)
	{
		RootBlockName = _0023_003DzPzO_0024GUk_003D;
	}

	internal bool _0023_003Dzm6dsCMpMVy24(Block _0023_003DzLeyHB00_003D)
	{
		if (hasRootBlock)
		{
			return _0023_003DzLeyHB00_003D.Name.Equals(RootBlockName);
		}
		return false;
	}

	public void SetRootBlock(string key)
	{
		if (base.Document != null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951513));
		}
		_0023_003DzsEhiJowLp1sN(key);
	}

	public void TakeOffline()
	{
		isOffline = true;
	}

	public void BringOnline()
	{
		_0023_003DzZZyHHbYfXKAk(_0023_003DzyGOerBkWPM27: true);
	}

	internal void _0023_003DzZZyHHbYfXKAk(bool _0023_003DzyGOerBkWPM27)
	{
		isOffline = false;
		using (IEnumerator<Block> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Block current = enumerator.Current;
				CheckAndFixIntegrity(current, base.Document);
			}
		}
		if (_0023_003DzyGOerBkWPM27)
		{
			base.Document.Entities._0023_003DzwKw7out1Wc_qZ0PKW_VXjgZOPo59g52tvCdKm_4_003D();
			base.Document.Entities._0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(base.Document.Entities, null);
		}
	}

	public async Task BringOnlineAsync()
	{
		isOffline = false;
		using (IEnumerator<Block> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Block current = enumerator.Current;
				CheckAndFixIntegrity(current, base.Document);
			}
		}
		base.Document.Entities._0023_003DzwKw7out1Wc_qZ0PKW_VXjgZOPo59g52tvCdKm_4_003D();
		await base.Document.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(base.Document.Entities, null, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0);
	}

	protected override string GetKeyForItem(Block item)
	{
		return item.Name;
	}

	protected override void InsertItem(int index, Block block)
	{
		_0023_003DznvxBzE3KPAch(block, null, -1);
		base.InsertItem(index, block);
	}

	internal void CheckAndFixIntegrity(Block _0023_003DzLeyHB00_003D, Document _0023_003DzoPlwCJA_003D, bool _0023_003DzR_0024c_H4M_003D = false)
	{
		CheckBlockName(_0023_003DzLeyHB00_003D.Name, _0023_003DzoPlwCJA_003D.workspace);
		bool value = _0023_003DzoPlwCJA_003D.Layers._0023_003DzswaTj8gEDyWc();
		bool value2 = _0023_003DzoPlwCJA_003D.TextStyles._0023_003DzOU5UUm8kRh6c();
		foreach (Entity entity in _0023_003DzLeyHB00_003D.Entities)
		{
			_0023_003DzoPlwCJA_003D.Layers.CheckAndFixDefaultLayerName(entity, value);
			_0023_003DzoPlwCJA_003D.TextStyles._0023_003Dzzv3gdukD06Co7c8MLQ_003D_003D(entity, value2);
			if (entity is BlockReference blockReference && TryGetValue(blockReference.BlockName, out var value3))
			{
				value3.referencesToMe.Add(blockReference);
			}
		}
		if (!_0023_003DzR_0024c_H4M_003D)
		{
			return;
		}
		using IEnumerator<Block> enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			foreach (Entity entity2 in enumerator2.Current.Entities)
			{
				if (entity2 is BlockReference blockReference2 && blockReference2.BlockName.Equals(_0023_003DzLeyHB00_003D.Name))
				{
					_0023_003DzLeyHB00_003D.referencesToMe.Add(blockReference2);
				}
			}
		}
	}

	[Obsolete("Use the method that accepts the block only instead.")]
	public int Add(string name, Block block)
	{
		block.Name = name;
		return Add(block);
	}

	internal static void CheckBlockName(string _0023_003DzS_00246o7tc_003D, IWorkspaceInternal _0023_003DzImQx0os_003D)
	{
		if (_0023_003DzImQx0os_003D != null)
		{
			if (_0023_003DzImQx0os_003D.ParentBlocks.Contains(_0023_003DzS_00246o7tc_003D))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951434) + _0023_003DzS_00246o7tc_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951666));
			}
			if (_0023_003DzImQx0os_003D.HiddenBlocks.Contains(_0023_003DzS_00246o7tc_003D))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951434) + _0023_003DzS_00246o7tc_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951589));
			}
		}
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			foreach (string name in names)
			{
				if (entity is BlockReference blockReference && EyeshotKeyedCollection<Block>.AreEqualStrings(blockReference.BlockName, name))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal override void _0023_003DzTwVWSL0_003D(Block _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		CheckBlockName(_0023_003Dzf92bGaE_003D, base.Document?.workspace);
		if (EyeshotKeyedCollection<Block>.AreEqualStrings(RootBlockName, name))
		{
			_0023_003DzsEhiJowLp1sN(_0023_003Dzf92bGaE_003D);
		}
		if (base.Document != null)
		{
			foreach (Block block in base.Document.Blocks)
			{
				_0023_003Dz0aIF4fUkRDL1(block.Entities, _0023_003Dzf92bGaE_003D, name);
			}
		}
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
	}

	protected internal override bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string blockName)
	{
		if (entities == null)
		{
			return false;
		}
		bool result = false;
		foreach (Entity entity in entities)
		{
			if (entity is BlockReference blockReference && EyeshotKeyedCollection<Block>.AreEqualStrings(blockReference.BlockName, blockName))
			{
				blockReference.transformedEntityBoxes.Clear();
				blockReference.RegenMode = regenType.RegenAndCompile;
				result = true;
			}
		}
		return result;
	}

	private static void _0023_003Dz0aIF4fUkRDL1(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is BlockReference blockReference && EyeshotKeyedCollection<Block>.AreEqualStrings(blockReference.BlockName, _0023_003DzyriMxps_003D))
			{
				regenType regenMode = blockReference.RegenMode;
				blockReference.BlockName = _0023_003Dzf92bGaE_003D;
				blockReference.RegenMode = regenMode;
			}
		}
	}

	internal override bool _0023_003DzKDPkfqhjl63a(Block _0023_003DzAhotMQs_003D, bool _0023_003Dzmyw8uNw_003D = true)
	{
		HashSet<BlockReference> hashSet = null;
		int num = _0023_003Dzjl3pzGA_003D(_0023_003DzAhotMQs_003D);
		if (num != -1)
		{
			hashSet = new HashSet<BlockReference>(base.Items[num].referencesToMe);
		}
		bool result = base._0023_003DzKDPkfqhjl63a(_0023_003DzAhotMQs_003D, _0023_003Dzmyw8uNw_003D);
		if (hashSet != null)
		{
			_0023_003DzAhotMQs_003D.referencesToMe = hashSet;
		}
		return result;
	}

	protected override void SetItem(int index, Block item)
	{
		_0023_003DznvxBzE3KPAch(item, null, index);
		_0023_003DzgS08WmH_P7At(index, item);
	}

	internal void _0023_003DzgS08WmH_P7At(int _0023_003DzyzK8swU_003D, Block _0023_003DzUBZd570_003D)
	{
		bool flag = hasRootBlock && IndexOf(RootBlock) == _0023_003DzyzK8swU_003D;
		this[_0023_003DzyzK8swU_003D].Entities.SetDocument(null);
		base.SetItem(_0023_003DzyzK8swU_003D, _0023_003DzUBZd570_003D);
		if (base.Document != null && flag)
		{
			_0023_003DzsEhiJowLp1sN(_0023_003DzUBZd570_003D.Name);
			_0023_003Dzo60vEkkaRGxX()?.InitializeRootBlock();
		}
	}

	private void _0023_003DznvxBzE3KPAch(Block _0023_003DzUBZd570_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, int _0023_003Dzjhyg1Go_003D)
	{
		if (_0023_003DzcGPwwO1_0024N4cL(_0023_003DzUBZd570_003D) && hasRootBlock && IndexOf(RootBlock) == _0023_003Dzjhyg1Go_003D)
		{
			_0023_003DzUBZd570_003D.Entities._0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(_0023_003DzUBZd570_003D.Entities, _0023_003DzZcrk_0024oE_003D);
		}
	}

	private async Task _0023_003Dzv_0024SDojzUBin_0024(Block _0023_003DzUBZd570_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D, int _0023_003Dzjhyg1Go_003D)
	{
		if (_0023_003DzcGPwwO1_0024N4cL(_0023_003DzUBZd570_003D) && hasRootBlock && IndexOf(RootBlock) == _0023_003Dzjhyg1Go_003D)
		{
			await _0023_003DzUBZd570_003D.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(_0023_003DzUBZd570_003D.Entities, null, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0);
		}
	}

	private bool _0023_003DzcGPwwO1_0024N4cL(Block _0023_003DzUBZd570_003D)
	{
		if (base.Document == null)
		{
			return false;
		}
		_0023_003DzUBZd570_003D.Entities.SetDocument(base.Document);
		if (isOffline)
		{
			return false;
		}
		CheckAndFixIntegrity(_0023_003DzUBZd570_003D, base.Document, _0023_003DzR_0024c_H4M_003D: true);
		return true;
	}

	public override void Remove(IEnumerable<Block> blocks)
	{
		_0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D _0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D2 = new _0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D();
		HashSet<Block> hashSet = ((blocks is HashSet<Block> hashSet2) ? hashSet2 : blocks.ToHashSet());
		_0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D2._0023_003DzitPFQjPDoJC7 = new HashSet<string>(hashSet.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzHs2K9IFpehsjtS6Cbg_003D_003D));
		List<Block> _0023_003Dzi5suo2xo0iQa = this.Where(_0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D2._0023_003Dza4MsG5BaKQCA).ToList();
		_0023_003DzJQbMRdSB1Qyt6_8aZQ_003D_003D(hashSet);
		_0023_003Dzzc8NWvD9Ri5EYFtPSQ_003D_003D(_0023_003DzEnRepaMQtrtoHy7cFU8_00240i0_003D2._0023_003DzitPFQjPDoJC7, _0023_003DzqPpkIDhR7en_: true, _0023_003Dzi5suo2xo0iQa);
		_skipRemovingChecks = true;
		foreach (Block item in hashSet)
		{
			Remove(item);
		}
		_skipRemovingChecks = false;
	}

	protected override void RemoveItem(int index)
	{
		Block block = this[index];
		string name = block.Name;
		if (!_skipRemovingChecks)
		{
			_0023_003DzJQbMRdSB1Qyt6_8aZQ_003D_003D(new HashSet<Block> { block });
			_0023_003Dzzc8NWvD9Ri5EYFtPSQ_003D_003D(new HashSet<string> { name }, _0023_003DzqPpkIDhR7en_: true, this);
		}
		base.RemoveItem(index);
		if (base.Document != null)
		{
			block.Entities.SetDocument(null);
		}
	}

	private void _0023_003DzJQbMRdSB1Qyt6_8aZQ_003D_003D(HashSet<Block> _0023_003Dz5W3U0Uw_003D)
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			return;
		}
		using (Stack<BlockReference>.Enumerator enumerator = _0023_003Dzo60vEkkaRGxX().Parents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D _0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D2 = new _0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D();
				_0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D2._0023_003Dz5I3b_GM_003D = enumerator.Current;
				if (_0023_003Dz5W3U0Uw_003D.Any(_0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D2._0023_003DzQOuyFmRy76c7oNjsJacbQgr0lE9t))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951562) + _0023_003DzN1IQbmR_0024iRQqwtZAn2SmpJA_003D2._0023_003Dz5I3b_GM_003D.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952291));
				}
			}
		}
		using Stack<Block>.Enumerator enumerator2 = _0023_003Dzo60vEkkaRGxX().OpenParents.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			_0023_003DzdhvCo056XFDY94r2_00244pyZWI_003D CS_0024_003C_003E8__locals3 = new _0023_003DzdhvCo056XFDY94r2_00244pyZWI_003D();
			CS_0024_003C_003E8__locals3._0023_003DzLeyHB00_003D = enumerator2.Current;
			if (_0023_003Dz5W3U0Uw_003D.Any((Block _0023_003Dz1v6oPQk_003D) => _0023_003Dz1v6oPQk_003D.Name == CS_0024_003C_003E8__locals3._0023_003DzLeyHB00_003D.Name))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951562) + CS_0024_003C_003E8__locals3._0023_003DzLeyHB00_003D.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952228));
			}
		}
	}

	private void _0023_003Dzzc8NWvD9Ri5EYFtPSQ_003D_003D(HashSet<string> _0023_003DzitPFQjPDoJC7, bool _0023_003DzqPpkIDhR7en_, IEnumerable<Block> _0023_003Dzi5suo2xo0iQa)
	{
		foreach (string item in _0023_003DzitPFQjPDoJC7)
		{
			if (!TryGetValue(item, out var _) || !_0023_003DzqPpkIDhR7en_)
			{
				continue;
			}
			foreach (Block item2 in _0023_003Dzi5suo2xo0iQa)
			{
				_0023_003Dzzc8NWvD9Ri5EYFtPSQ_003D_003D(item2.Entities, _0023_003DzitPFQjPDoJC7, _0023_003Dz42XvoYOTL2J4: true);
			}
		}
	}

	internal void _0023_003Dzzc8NWvD9Ri5EYFtPSQ_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, HashSet<string> _0023_003DzitPFQjPDoJC7, bool _0023_003Dz42XvoYOTL2J4)
	{
		for (int num = _0023_003Dzv7xH9gk_003D.Count - 1; num >= 0; num--)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[num];
			if (entity is BlockReference)
			{
				BlockReference blockReference = (BlockReference)entity;
				if (_0023_003DzitPFQjPDoJC7.Contains(blockReference.BlockName))
				{
					if (_0023_003Dz42XvoYOTL2J4 && base.DisposeItems)
					{
						blockReference.Dispose();
					}
					_0023_003Dzv7xH9gk_003D.RemoveAt(num);
				}
			}
		}
	}

	internal Dictionary<string, Block> _0023_003DzJW4Y0uY_003D(string _0023_003DzaROjBYA_003D)
	{
		Dictionary<string, Block> dictionary = new Dictionary<string, Block>();
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			foreach (Block parentBlock in _0023_003Dzo60vEkkaRGxX().ParentBlocks)
			{
				IList<Entity> entities = parentBlock.Entities;
				for (int num = entities.Count - 1; num >= 0; num--)
				{
					if (entities[num].LayerName == _0023_003DzaROjBYA_003D)
					{
						entities.RemoveAt(num);
					}
				}
			}
		}
		using IEnumerator<Block> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Block current = enumerator.Current;
			IList<Entity> entities2 = current.Entities;
			for (int num2 = entities2.Count - 1; num2 >= 0; num2--)
			{
				Entity entity = entities2[num2];
				if (entity.LayerName == _0023_003DzaROjBYA_003D)
				{
					if (base.DisposeItems)
					{
						entity.Dispose();
					}
					entities2.RemoveAt(num2);
					if (!dictionary.ContainsKey(current.Name))
					{
						dictionary.Add(current.Name, current);
					}
				}
				else
				{
					EntityList._0023_003DzrBeU_f_Ge5Om(_0023_003DzaROjBYA_003D, entity);
				}
			}
		}
		return dictionary;
	}
}
