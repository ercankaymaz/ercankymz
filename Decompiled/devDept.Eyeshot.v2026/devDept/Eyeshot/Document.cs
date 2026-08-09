using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

public abstract class Document
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz7G_AZTP_0024gSGz6U_00249jRM1SiI_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzYwIE4oHHd7Xy;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003DzY8C49ueFTJMU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFile _0023_003DzQZpgnjI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<BlockReference> _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			try
			{
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<BlockReference> awaiter;
					switch (num)
					{
					default:
						_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile(clear: true);
						_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile(clear: true);
						if (_0023_003DzYwIE4oHHd7Xy?.workspace != null)
						{
							awaiter2 = _0023_003DzYwIE4oHHd7Xy.workspace.DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(_0023_003DzQZpgnjI_003D)).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 0);
								_0023_003DzpVK748zcYJ8u = awaiter2;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
							goto IL_00d0;
						}
						awaiter2 = _0023_003DzQZpgnjI_003D.DoWorkAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_0023_003DzU7pGb3X7Zp4G = 1);
							_0023_003DzpVK748zcYJ8u = awaiter2;
							_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
						goto IL_013d;
					case 0:
						awaiter2 = _0023_003DzpVK748zcYJ8u;
						_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
						goto IL_00d0;
					case 1:
						awaiter2 = _0023_003DzpVK748zcYJ8u;
						_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
						goto IL_013d;
					case 2:
						{
							awaiter = _0023_003DzFYvRpuzB_RuY;
							_0023_003DzFYvRpuzB_RuY = default(TaskAwaiter<BlockReference>);
							num = (_0023_003DzU7pGb3X7Zp4G = -1);
							goto IL_01ad;
						}
						IL_013d:
						awaiter2.GetResult();
						goto IL_0144;
						IL_00d0:
						awaiter2.GetResult();
						goto IL_0144;
						IL_01ad:
						awaiter.GetResult();
						_0023_003DzYwIE4oHHd7Xy.Units = _0023_003DzQZpgnjI_003D.Units;
						break;
						IL_0144:
						if (_0023_003DzYwIE4oHHd7Xy == null)
						{
							break;
						}
						awaiter = _0023_003DzQZpgnjI_003D.OpenToAsync(_0023_003DzYwIE4oHHd7Xy).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0023_003DzU7pGb3X7Zp4G = 2);
							_0023_003DzFYvRpuzB_RuY = awaiter;
							_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_01ad;
					}
					if (_0023_003DzY8C49ueFTJMU != null)
					{
						_0023_003DzQZpgnjI_003D.OpenTo(_0023_003DzY8C49ueFTJMU);
					}
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception ex2)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953628) + ex2, ex2);
				}
				finally
				{
					if (num < 0)
					{
						_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
						_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
					}
				}
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

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzOJj_0024_YXCl726pylQgQ_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Document _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzQZpgnjI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Document document = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					document._0023_003Dzgl9SetDdL7_S(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS);
					awaiter = document.Entities.AddRangeAsync(_0023_003DzQZpgnjI_003D.Entities, _0023_003DzZcrk_0024oE_003D).GetAwaiter();
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

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzpwtw7_0024KdYXBKEHQmKg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Document _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzQZpgnjI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003DzJPR4E5ZNOD6H;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DznkMU43c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BlockReference _0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Document document = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D = document._0023_003DzVxi5CT0E93WQ(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS, _0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D);
					awaiter = document.Entities.AddAsync(_0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D, _0023_003DzZcrk_0024oE_003D).GetAwaiter();
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
				if (_0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
				{
					document.workspace?.RemoveJittering(_0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D);
				}
				result = _0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D = null;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003Dz2WY_HR3j8nRi8vwfzk_4Gk0_003D = null;
			_0023_003DzCodHnSRJkAEg.SetResult(result);
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

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzwXhx9XZ1jij_I1euLJ5LZbg_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzYwIE4oHHd7Xy;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003DzY8C49ueFTJMU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Stream _0023_003DzdLqTRfo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dzg5oC_Hs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public contentType _0023_003DzB5M5dYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzqCbQjE_0024V12fc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			try
			{
				if ((uint)num > 1u)
				{
					_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile();
					_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile();
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _0023_003DzpVK748zcYJ8u;
						_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
						goto IL_00f5;
					}
					if (num != 1)
					{
						WriteFile writeFile = _0023_003DzKirAf1MMcNHGfFk0_0024Q_003D_003D(_0023_003DzdLqTRfo_003D, _0023_003Dzg5oC_Hs_003D, _0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D, _0023_003DzqCbQjE_0024V12fc);
						if (_0023_003DzYwIE4oHHd7Xy?.workspace != null)
						{
							awaiter = _0023_003DzYwIE4oHHd7Xy.workspace.DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(writeFile)).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 0);
								_0023_003DzpVK748zcYJ8u = awaiter;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
							goto IL_00f5;
						}
						awaiter = writeFile.DoWorkAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0023_003DzU7pGb3X7Zp4G = 1);
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
					goto end_IL_0046;
					IL_00f5:
					awaiter.GetResult();
					end_IL_0046:;
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception ex2)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954355) + ex2);
				}
				finally
				{
					if (num < 0)
					{
						_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
						_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
					}
				}
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

	[NonSerialized]
	internal IWorkspaceInternal workspace;

	[NonSerialized]
	internal FontDataDictionary fontDefs = new FontDataDictionary();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003Dz_0024_ydENQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003Dzs5cWkr1MAiCu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzlP7wLX5zLYH9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003Dz_fFa6y8YB5GDihsN_0024w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzRC3I89ZoZVeK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D;

	internal string internalElementsLayerName = Layer.DefaultLayerName;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private attributeReferenceVisibilityType _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D = attributeReferenceVisibilityType.Normal;

	[NonSerialized]
	internal bool isBoundingBoxDirty = true;

	public const int DEFAULT_MAX_PATTERN_REPETITIONS = 1000;

	public const int DEFAULT_MAX_HATCH_PATTERN_LINES = 1000000;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzMUPYtqY1175nD8b3rqKu4iHhLEGP = 1000000;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D = 1000;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzqDg1K0IJ49zJ8V_8Vw_003D_003D = Color.Black;

	public bool IsLoaded => workspace != null;

	public Block RootBlock => Blocks[Blocks.RootBlockName];

	public EntityList Entities => _0023_003DzLnvwYhzuV1KC().Entities;

	public Block OpenBlock => workspace?.OpenBlock ?? RootBlock;

	internal MaterialKeyedCollection Materials
	{
		get
		{
			return _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D?._0023_003DzOcZnt98_003D(null);
			_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = value;
			_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D._0023_003DzOcZnt98_003D(this);
			_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D.InitializeGraphicsResources();
		}
	}

	internal linearUnitsType Units
	{
		get
		{
			return _0023_003DzLnvwYhzuV1KC().Units;
		}
		set
		{
			_0023_003DzLnvwYhzuV1KC().Units = value;
		}
	}

	public BlockKeyedCollection Blocks
	{
		get
		{
			return _0023_003Dz_0024_ydENQ_003D;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			foreach (Block item in value)
			{
				value.CheckAndFixIntegrity(item, this);
			}
			_0023_003Dz_0024_ydENQ_003D._0023_003DzOcZnt98_003D(null);
			_0023_003Dz_0024_ydENQ_003D = value;
			_0023_003Dz_0024_ydENQ_003D._0023_003DzOcZnt98_003D(this);
			RootBlock.Entities._0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(RootBlock.Entities, null);
		}
	}

	public LayerKeyedCollection Layers
	{
		get
		{
			return _0023_003Dzs5cWkr1MAiCu;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003Dzs5cWkr1MAiCu?._0023_003DzOcZnt98_003D(null);
			_0023_003Dzs5cWkr1MAiCu = value;
			_0023_003Dzs5cWkr1MAiCu._0023_003DzOcZnt98_003D(this);
			_0023_003Dz3SpdW_0024LY5XiBspsUyw_003D_003D();
		}
	}

	public LineTypeKeyedCollection LineTypes
	{
		get
		{
			return _0023_003DzlP7wLX5zLYH9;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003DzlP7wLX5zLYH9?._0023_003DzOcZnt98_003D(null);
			_0023_003DzlP7wLX5zLYH9 = value;
			_0023_003DzlP7wLX5zLYH9._0023_003DzOcZnt98_003D(this);
		}
	}

	public float LineTypeScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = value;
		}
	}

	public HatchPatternKeyedCollection HatchPatterns
	{
		get
		{
			return _0023_003Dz_fFa6y8YB5GDihsN_0024w_003D_003D;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003Dz_fFa6y8YB5GDihsN_0024w_003D_003D?._0023_003DzOcZnt98_003D(null);
			_0023_003Dz_fFa6y8YB5GDihsN_0024w_003D_003D = value;
			_0023_003Dz_fFa6y8YB5GDihsN_0024w_003D_003D._0023_003DzOcZnt98_003D(this);
		}
	}

	public TextStyleKeyedCollection TextStyles
	{
		get
		{
			return _0023_003DzRC3I89ZoZVeK;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003DzRC3I89ZoZVeK?._0023_003DzOcZnt98_003D(null);
			_0023_003DzRC3I89ZoZVeK = value;
			_0023_003DzRC3I89ZoZVeK._0023_003DzOcZnt98_003D(this);
		}
	}

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D = value;
		}
	}

	public int MaxHatchPatternLines
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMUPYtqY1175nD8b3rqKu4iHhLEGP;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMUPYtqY1175nD8b3rqKu4iHhLEGP = value;
		}
	}

	public int MaxPatternRepetitions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D = value;
		}
	}

	public Color DefaultColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqDg1K0IJ49zJ8V_8Vw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzqDg1K0IJ49zJ8V_8Vw_003D_003D = value;
		}
	}

	protected Document()
	{
		_0023_003Dz_0024_ydENQ_003D = new BlockKeyedCollection();
		_0023_003Dz_0024_ydENQ_003D._0023_003DzOcZnt98_003D(this);
		Layers = new LayerKeyedCollection();
		TextStyles = new TextStyleKeyedCollection();
		LineTypes = new LineTypeKeyedCollection();
		HatchPatterns = new HatchPatternKeyedCollection();
		Materials = new MaterialKeyedCollection();
	}

	internal virtual void SetWorkspace(IWorkspaceInternal _0023_003DzImQx0os_003D)
	{
		if (_0023_003DzImQx0os_003D == null)
		{
			FreeGraphicsResources();
		}
		workspace = _0023_003DzImQx0os_003D;
		if (workspace != null)
		{
			ClearCharDefs();
			workspace.InitializeRootBlock();
			_0023_003Dz3SpdW_0024LY5XiBspsUyw_003D_003D();
			Materials.InitializeGraphicsResources();
			Entities.Regen();
		}
	}

	internal void FreeGraphicsResources()
	{
		Layers._0023_003DzhM3qURBkRYYd();
		Blocks._0023_003DzhM3qURBkRYYd();
		Materials._0023_003DzhM3qURBkRYYd();
		FinalClearCharDefs();
	}

	internal bool _0023_003Dzz77R4jydnmt8hZDOvQ_003D_003D()
	{
		return workspace?.IsOpenRootLevel ?? true;
	}

	internal Block _0023_003DzLnvwYhzuV1KC()
	{
		return workspace?.CurrentBlock ?? RootBlock;
	}

	internal void FinalClearCharDefs()
	{
		foreach (FontData value in fontDefs.Values)
		{
			value.Dispose();
		}
		fontDefs.Clear();
	}

	internal void ClearCharDefs()
	{
		if (workspace != null && workspace.IsRenderingContextValid())
		{
			Logger.Instance.Trace(workspace.InstanceId, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954350));
			FinalClearCharDefs();
			TextStyle textStyle = TextStyles[TextStyles._0023_003Dz_I9l_0024rpzA7Cb()];
			fontDefs.Add(textStyle.FontFamilyName, new FontData());
			Logger.Instance.Info(workspace.InstanceId, string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954318), textStyle.FontFamilyName, textStyle.Style, workspace.RenderContext.IsValid(), workspace.RenderContext.HasDeviceContext(), workspace.RenderContext.DeviceContext()));
			fontDefs[textStyle.FontFamilyName]._0023_003Dz2QgzNYs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911525), textStyle, workspace.RenderContext, _0023_003DzbamQ1mQWVhT9: false);
			Logger.Instance.Trace(workspace.InstanceId, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954453));
		}
	}

	private void _0023_003Dz3SpdW_0024LY5XiBspsUyw_003D_003D()
	{
		if (!_0023_003Dzs5cWkr1MAiCu.Contains(internalElementsLayerName))
		{
			workspace?.UpdateLayerNameForInternalElements(_0023_003Dzs5cWkr1MAiCu[0].Name);
		}
	}

	public void UpdateBoundingBox()
	{
		OpenBlock.Entities.UpdateBoundingBox();
	}

	public virtual RegenParams GetVisualRefinement()
	{
		return new RegenParams(Utility.ComputeTolerance(new Size3D(OpenBlock.Entities.BoxMin, OpenBlock.Entities.BoxMax).Diagonal));
	}

	public virtual void Clear()
	{
		_0023_003Dz_0024_ydENQ_003D.Clear();
		_0023_003Dzs5cWkr1MAiCu.Clear();
		TextStyles.Clear();
		LineTypes.Clear();
		HatchPatterns.Clear();
		_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D.Clear();
		ClearCharDefs();
	}

	public virtual void CopyTo(Document destination, bool replaceRootBlock = true, bool keepTessellation = false)
	{
		foreach (LineType lineType in LineTypes)
		{
			if (!destination.LineTypes.Contains(lineType.Name))
			{
				destination.LineTypes.Add((LineType)lineType.Clone());
			}
		}
		foreach (HatchPattern hatchPattern in HatchPatterns)
		{
			if (!destination.HatchPatterns.Contains(hatchPattern.Name))
			{
				destination.HatchPatterns.Add((HatchPattern)hatchPattern.Clone());
			}
		}
		foreach (TextStyle textStyle in TextStyles)
		{
			if (!destination.TextStyles.Contains(textStyle.Name))
			{
				destination.TextStyles.Add((TextStyle)textStyle.Clone());
			}
		}
		foreach (Material material in Materials)
		{
			if (!destination.Materials.Contains(material.Name))
			{
				destination.Materials.Add((Material)material.Clone());
			}
		}
		foreach (Layer layer in Layers)
		{
			if (!destination.Layers.Contains(layer.Name))
			{
				destination.Layers.Add((Layer)layer.Clone());
			}
		}
		foreach (Block block in Blocks)
		{
			if (!(block.Name.Equals(Blocks.RootBlockName) && replaceRootBlock) && !destination.Blocks.Contains(block.Name))
			{
				Block item = (Block)(keepTessellation ? block.CloneWithTessellation() : block.Clone());
				destination.Blocks.Add(item);
			}
		}
		destination.LineTypeScale = LineTypeScale;
		if (replaceRootBlock)
		{
			destination.Blocks[destination.Blocks.IndexOf(destination.RootBlock)] = (Block)(keepTessellation ? Blocks.RootBlock.CloneWithTessellation() : Blocks.RootBlock.Clone());
		}
		if (destination.workspace != null)
		{
			destination.workspace.UpdateBoundingBox();
		}
		else
		{
			destination.UpdateBoundingBox();
		}
	}

	public void Purge()
	{
		_0023_003Dz_JVSrE__e8Wu();
	}

	private protected virtual void _0023_003Dz_JVSrE__e8Wu()
	{
		Utility.Purge(Entities, Layers, Blocks, Materials, TextStyles, LineTypes, HatchPatterns, out var _0023_003DzfchAzPg_003D, out var _0023_003DzTKSsuc0_003D, out var _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, out var _0023_003DzIm3oyxMBrWGo, out var _0023_003Dzl0O9h6oxpm0u, out var _0023_003Dz3b479cSvol0G, _0023_003DzkiaObrihH2G4: true, _0023_003DzVUweAlrIUUDr: true);
		Layers = _0023_003DzfchAzPg_003D;
		Blocks = _0023_003DzTKSsuc0_003D;
		TextStyles = _0023_003DzIm3oyxMBrWGo;
		LineTypes = _0023_003Dzl0O9h6oxpm0u;
		HatchPatterns = _0023_003Dz3b479cSvol0G;
		Materials = _0023_003DzvEAegzCu5KMnKFso0g_003D_003D;
	}

	private static WriteFile _0023_003DzKirAf1MMcNHGfFk0_0024Q_003D_003D(Stream _0023_003DzdLqTRfo_003D, string _0023_003Dzg5oC_Hs_003D, DesignDocument _0023_003DzYwIE4oHHd7Xy, DrawingDocument _0023_003DzY8C49ueFTJMU, contentType _0023_003DzB5M5dYA_003D, FileSerializer _0023_003DzqCbQjE_0024V12fc)
	{
		if (_0023_003DzdLqTRfo_003D != null)
		{
			return new WriteFile(new WriteFileParams(_0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D), _0023_003DzdLqTRfo_003D, _0023_003DzqCbQjE_0024V12fc);
		}
		return new WriteFile(new WriteFileParams(_0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D), _0023_003Dzg5oC_Hs_003D, _0023_003DzqCbQjE_0024V12fc);
	}

	internal static void _0023_003DzRiqmF0HlYfrG(Stream _0023_003DzdLqTRfo_003D, string _0023_003Dzg5oC_Hs_003D, DesignDocument _0023_003DzYwIE4oHHd7Xy, DrawingDocument _0023_003DzY8C49ueFTJMU, contentType _0023_003DzB5M5dYA_003D, FileSerializer _0023_003DzqCbQjE_0024V12fc)
	{
		_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile();
		_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile();
		try
		{
			_0023_003DzKirAf1MMcNHGfFk0_0024Q_003D_003D(_0023_003DzdLqTRfo_003D, _0023_003Dzg5oC_Hs_003D, _0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D, _0023_003DzqCbQjE_0024V12fc).DoWork();
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954355) + ex);
		}
		finally
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
			_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
		}
	}

	internal static async Task _0023_003DzMw_yAWQaLtwK(Stream _0023_003DzdLqTRfo_003D, string _0023_003Dzg5oC_Hs_003D, DesignDocument _0023_003DzYwIE4oHHd7Xy, DrawingDocument _0023_003DzY8C49ueFTJMU, contentType _0023_003DzB5M5dYA_003D, FileSerializer _0023_003DzqCbQjE_0024V12fc)
	{
		_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile();
		_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile();
		try
		{
			WriteFile writeFile = _0023_003DzKirAf1MMcNHGfFk0_0024Q_003D_003D(_0023_003DzdLqTRfo_003D, _0023_003Dzg5oC_Hs_003D, _0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D, _0023_003DzqCbQjE_0024V12fc);
			if (_0023_003DzYwIE4oHHd7Xy?.workspace != null)
			{
				await _0023_003DzYwIE4oHHd7Xy.workspace.DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(writeFile));
			}
			else
			{
				await writeFile.DoWorkAsync();
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954355) + ex2);
		}
		finally
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
			_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
		}
	}

	internal static void _0023_003DzEnNVXbF4jXkn(ReadFile _0023_003DzQZpgnjI_003D, DesignDocument _0023_003DzYwIE4oHHd7Xy, DrawingDocument _0023_003DzY8C49ueFTJMU)
	{
		try
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile(clear: true);
			_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile(clear: true);
			_0023_003DzQZpgnjI_003D.DoWork();
			if (_0023_003DzYwIE4oHHd7Xy != null)
			{
				_0023_003DzQZpgnjI_003D.OpenTo(_0023_003DzYwIE4oHHd7Xy);
				_0023_003DzYwIE4oHHd7Xy.Units = _0023_003DzQZpgnjI_003D.Units;
			}
			if (_0023_003DzY8C49ueFTJMU != null)
			{
				_0023_003DzQZpgnjI_003D.OpenTo(_0023_003DzY8C49ueFTJMU);
			}
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953628) + ex, ex);
		}
		finally
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
			_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
		}
	}

	internal static async Task _0023_003DzQRSCQfCaOAvS(ReadFile _0023_003DzQZpgnjI_003D, DesignDocument _0023_003DzYwIE4oHHd7Xy, DrawingDocument _0023_003DzY8C49ueFTJMU)
	{
		try
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PreSaveOpenFile(clear: true);
			_0023_003DzY8C49ueFTJMU?.workspace?.PreSaveOpenFile(clear: true);
			if (_0023_003DzYwIE4oHHd7Xy?.workspace == null)
			{
				await _0023_003DzQZpgnjI_003D.DoWorkAsync();
			}
			else
			{
				await _0023_003DzYwIE4oHHd7Xy.workspace.DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(_0023_003DzQZpgnjI_003D));
			}
			if (_0023_003DzYwIE4oHHd7Xy != null)
			{
				await _0023_003DzQZpgnjI_003D.OpenToAsync(_0023_003DzYwIE4oHHd7Xy);
				_0023_003DzYwIE4oHHd7Xy.Units = _0023_003DzQZpgnjI_003D.Units;
			}
			if (_0023_003DzY8C49ueFTJMU != null)
			{
				_0023_003DzQZpgnjI_003D.OpenTo(_0023_003DzY8C49ueFTJMU);
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953628) + ex2, ex2);
		}
		finally
		{
			_0023_003DzYwIE4oHHd7Xy?.workspace?.PostSaveOpenFile();
			_0023_003DzY8C49ueFTJMU?.workspace?.PostSaveOpenFile();
		}
	}

	internal BlockReference _0023_003DzwVFSvec_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS, Point3D _0023_003DzJPR4E5ZNOD6H, string _0023_003DznkMU43c_003D, bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
	{
		BlockReference blockReference = _0023_003DzVxi5CT0E93WQ(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS, _0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D);
		Entities.Add(blockReference, _0023_003DzZcrk_0024oE_003D);
		if (_0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
		{
			workspace?.RemoveJittering(blockReference);
		}
		return blockReference;
	}

	internal async Task<BlockReference> _0023_003DzVsWbKGE_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS, Point3D _0023_003DzJPR4E5ZNOD6H, string _0023_003DznkMU43c_003D, bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
	{
		BlockReference blockReference = _0023_003DzVxi5CT0E93WQ(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS, _0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D);
		await Entities.AddAsync(blockReference, _0023_003DzZcrk_0024oE_003D);
		if (_0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
		{
			workspace?.RemoveJittering(blockReference);
		}
		return blockReference;
	}

	private BlockReference _0023_003DzVxi5CT0E93WQ(ReadFileAsync _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS, Point3D _0023_003DzJPR4E5ZNOD6H, string _0023_003DznkMU43c_003D)
	{
		_0023_003DznkMU43c_003D = Utility._0023_003DzMnXK_AcQrfN3(_0023_003DznkMU43c_003D ?? _0023_003DzQZpgnjI_003D.Blocks.RootBlockName, Blocks, _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D: true);
		if (_0023_003DznkMU43c_003D != _0023_003DzQZpgnjI_003D.Blocks.RootBlockName)
		{
			_0023_003DzQZpgnjI_003D.Blocks.RootBlock.Name = _0023_003DznkMU43c_003D;
			_0023_003DzQZpgnjI_003D.Blocks.SetRootBlock(_0023_003DznkMU43c_003D);
		}
		_0023_003DztOK9RejsWMws(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzKE_FpisulC8D: true);
		if ((object)_0023_003DzJPR4E5ZNOD6H == null)
		{
			_0023_003DzJPR4E5ZNOD6H = Point3D.Origin;
		}
		if (!_0023_003DzhP_0024tv07jE_0024LS)
		{
			return new BlockReference(_0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D, 0.0);
		}
		return new BlockReference(_0023_003DzJPR4E5ZNOD6H.X, _0023_003DzJPR4E5ZNOD6H.Y, _0023_003DzJPR4E5ZNOD6H.Z, _0023_003DznkMU43c_003D, Units, Blocks, 0.0);
	}

	internal void _0023_003DzVpMLeQA_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS)
	{
		_0023_003Dzgl9SetDdL7_S(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS);
		Entities.AddRange(_0023_003DzQZpgnjI_003D.Entities, _0023_003DzZcrk_0024oE_003D);
	}

	internal async Task _0023_003DzYIDN7QA_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS)
	{
		_0023_003Dzgl9SetDdL7_S(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS);
		await Entities.AddRangeAsync(_0023_003DzQZpgnjI_003D.Entities, _0023_003DzZcrk_0024oE_003D);
	}

	private void _0023_003Dzgl9SetDdL7_S(ReadFileAsync _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzhP_0024tv07jE_0024LS)
	{
		_0023_003DztOK9RejsWMws(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzKE_FpisulC8D: false);
		if (_0023_003DzhP_0024tv07jE_0024LS)
		{
			double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_0023_003DzQZpgnjI_003D.Units, Units);
			_0023_003DzQZpgnjI_003D.Entities.Scale(linearUnitsConversionFactor);
		}
	}

	private protected void _0023_003DztOK9RejsWMws(ReadFileAsync _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzKE_FpisulC8D)
	{
		_0023_003DzAA7nAE5oH2H3(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzKE_FpisulC8D);
		if (_0023_003DzkDT_0024HYsJqA7X == conflictPolicy.Overwrite)
		{
			_0023_003DzQZpgnjI_003D.ImportSettings(this);
		}
	}

	internal void _0023_003DzAA7nAE5oH2H3(ReadFileAsync _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, bool _0023_003DzKE_FpisulC8D)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		if (Blocks.hasRootBlock && _0023_003DzkDT_0024HYsJqA7X != conflictPolicy.Rename && _0023_003DzQZpgnjI_003D.Blocks.Contains(Blocks.RootBlockName) && _0023_003DzQZpgnjI_003D.Blocks.RootBlockName != Blocks.RootBlockName)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954104) + Blocks.RootBlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954056));
		}
		bool isOffline = Blocks.isOffline;
		if (!isOffline)
		{
			Blocks.TakeOffline();
		}
		Dictionary<string, string> _0023_003Dz3NG5ssEa1dcm = new Dictionary<string, string>();
		if (this is DesignDocument)
		{
			_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.Materials, Materials, _0023_003DzkDT_0024HYsJqA7X, out _0023_003Dz3NG5ssEa1dcm, null);
		}
		_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.LineTypes, LineTypes, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm2, null);
		_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.HatchPatterns, HatchPatterns, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm3, null);
		_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.TextStyles, TextStyles, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm4, null);
		_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.Layers, Layers, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm5, null);
		_0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.Blocks, Blocks, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm6, _0023_003DzKE_FpisulC8D ? null : _0023_003DzQZpgnjI_003D.Blocks.RootBlockName);
		if (_0023_003DzkDT_0024HYsJqA7X == conflictPolicy.Rename)
		{
			foreach (Block block in _0023_003DzQZpgnjI_003D.Blocks)
			{
				foreach (Entity entity in block.Entities)
				{
					_0023_003DzmyAS8bZ2UOeQ(entity, _0023_003Dz3NG5ssEa1dcm, _0023_003Dz3NG5ssEa1dcm2, _0023_003Dz3NG5ssEa1dcm3, _0023_003Dz3NG5ssEa1dcm5, _0023_003Dz3NG5ssEa1dcm4, _0023_003Dz3NG5ssEa1dcm6);
				}
			}
			foreach (Layer layer in _0023_003DzQZpgnjI_003D.Layers)
			{
				if (!string.IsNullOrEmpty(layer.MaterialName) && _0023_003Dz3NG5ssEa1dcm.TryGetValue(layer.MaterialName, out var value))
				{
					layer.MaterialName = value;
				}
				if (!string.IsNullOrEmpty(layer.LineTypeName) && _0023_003Dz3NG5ssEa1dcm2.TryGetValue(layer.LineTypeName, out value))
				{
					layer.LineTypeName = value;
				}
			}
		}
		if (!isOffline)
		{
			Blocks._0023_003DzZZyHHbYfXKAk(_0023_003DzyGOerBkWPM27: false);
		}
	}

	private protected static void _0023_003DzmyAS8bZ2UOeQ(Entity _0023_003Dzs_0024uS8LA_003D, Dictionary<string, string> _0023_003DzLzxS1JhwpkaHqfL0Yw_003D_003D, Dictionary<string, string> _0023_003Dzal3U5scJRzUp, Dictionary<string, string> _0023_003Dz_0024bqMo3OjF85byBrASg_003D_003D, Dictionary<string, string> _0023_003DzBkp4pOp3_J2xE3PVig_003D_003D, Dictionary<string, string> _0023_003DzFPKg_FIWBvDb, Dictionary<string, string> _0023_003DzFNJloxDP07vc)
	{
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.MaterialName) && _0023_003DzLzxS1JhwpkaHqfL0Yw_003D_003D.TryGetValue(_0023_003Dzs_0024uS8LA_003D.MaterialName, out var value))
		{
			_0023_003Dzs_0024uS8LA_003D.MaterialName = value;
		}
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.LineTypeName) && _0023_003Dzal3U5scJRzUp.TryGetValue(_0023_003Dzs_0024uS8LA_003D.LineTypeName, out value))
		{
			_0023_003Dzs_0024uS8LA_003D.LineTypeName = value;
		}
		if (_0023_003Dzs_0024uS8LA_003D is Hatch hatch && _0023_003Dz_0024bqMo3OjF85byBrASg_003D_003D.TryGetValue(hatch.PatternName, out value))
		{
			hatch.PatternName = value;
		}
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.LayerName) && _0023_003DzBkp4pOp3_J2xE3PVig_003D_003D.TryGetValue(_0023_003Dzs_0024uS8LA_003D.LayerName, out value))
		{
			_0023_003Dzs_0024uS8LA_003D.LayerName = value;
		}
		if (_0023_003Dzs_0024uS8LA_003D is Text text)
		{
			if (!string.IsNullOrEmpty(text.StyleName) && _0023_003DzFPKg_FIWBvDb.TryGetValue(text.StyleName, out value))
			{
				text.StyleName = value;
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Table table)
		{
			double num = table.RowsNum;
			double num2 = table.ColumnsNum;
			for (int i = 0; (double)i < num; i++)
			{
				for (int j = 0; (double)j < num2; j++)
				{
					string styleName = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName) && _0023_003DzFPKg_FIWBvDb.TryGetValue(styleName, out value))
					{
						table.SetStyleName(i, j, value);
					}
				}
			}
		}
		else
		{
			if (!(_0023_003Dzs_0024uS8LA_003D is BlockReference blockReference))
			{
				return;
			}
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				string styleName2 = attribute.Value.StyleName;
				if (!string.IsNullOrEmpty(styleName2) && _0023_003DzFPKg_FIWBvDb.TryGetValue(styleName2, out value))
				{
					attribute.Value.StyleName = value;
				}
				string layerName = attribute.Value.LayerName;
				if (!string.IsNullOrEmpty(layerName) && _0023_003DzBkp4pOp3_J2xE3PVig_003D_003D.TryGetValue(layerName, out value))
				{
					attribute.Value.LayerName = value;
				}
			}
			if (_0023_003DzFNJloxDP07vc.TryGetValue(blockReference.BlockName, out value))
			{
				blockReference.BlockName = value;
			}
		}
	}

	internal static void _0023_003DzBlcGo_o_003D<T>(EyeshotKeyedCollection<T> _0023_003DzqjMrmuo_003D, EyeshotKeyedCollection<T> _0023_003DzaoQTclc_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X, out Dictionary<string, string> _0023_003Dz3NG5ssEa1dcm, string _0023_003DzVXBB_0024GpDdlbb) where T : IKeyedCollectionItem<T>
	{
		_0023_003Dz3NG5ssEa1dcm = new Dictionary<string, string>();
		foreach (T item in _0023_003DzqjMrmuo_003D)
		{
			string key = item.GetKey();
			if (key.Equals(_0023_003DzVXBB_0024GpDdlbb))
			{
				continue;
			}
			if (_0023_003DzaoQTclc_003D.Contains(key))
			{
				switch (_0023_003DzkDT_0024HYsJqA7X)
				{
				case conflictPolicy.Rename:
				{
					string text = Utility._0023_003DzMnXK_AcQrfN3(key, _0023_003DzaoQTclc_003D, _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D: false);
					_0023_003Dz3NG5ssEa1dcm.Add(key, text);
					item.SetKey(text);
					_0023_003DzaoQTclc_003D.Add(item);
					break;
				}
				case conflictPolicy.Overwrite:
					_0023_003DzaoQTclc_003D.ReplaceItem(item);
					break;
				}
			}
			else
			{
				_0023_003DzaoQTclc_003D.AddItemFast(item);
			}
		}
	}

	public void SynchronizeAttributes(string blockName)
	{
		RegenParams _0023_003DzNBd9QxQErh = new RegenParams(GetVisualRefinement().Deviation, this);
		CompileParams _0023_003Dz_0024erWB3Y_003D = ((workspace != null) ? new CompileParams(workspace) : null);
		bool flag = false;
		foreach (Block block in Blocks)
		{
			if (block.Name != blockName)
			{
				flag |= _0023_003DzYKBTnSG5IAa0(blockName, block, _0023_003DzNBd9QxQErh, _0023_003Dz_0024erWB3Y_003D);
			}
		}
		if (flag)
		{
			UpdateBoundingBox();
		}
	}

	public void SynchronizeAttributes(IList<BlockReference> blockReferences)
	{
		RegenParams regenParams = new RegenParams(GetVisualRefinement().Deviation, this);
		CompileParams compileParams = ((workspace != null) ? new CompileParams(workspace) : null);
		List<Entity> list = new List<Entity>();
		foreach (BlockReference blockReference in blockReferences)
		{
			if (blockReference._0023_003DzsQAoLomWIpW0(Blocks, _0023_003DzEkR_P10_003D: true))
			{
				blockReference._0023_003DzH5_UUBjbwiJl(regenParams);
				blockReference.UpdateBoundingBox(regenParams);
				if (compileParams != null)
				{
					blockReference._0023_003DzUT1EWEp6G6S4(compileParams);
				}
				list.Add(blockReference);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Block block in Blocks)
		{
			block._0023_003DzfRP9c1V6cvLS(list);
		}
		UpdateBoundingBox();
	}

	private bool _0023_003DzYKBTnSG5IAa0(string _0023_003DznkMU43c_003D, Block _0023_003DzLeyHB00_003D, RegenParams _0023_003DzNBd9QxQErh13, CompileParams _0023_003Dz_0024erWB3Y_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (Entity entity in _0023_003DzLeyHB00_003D.Entities)
		{
			if (!(entity is BlockReference))
			{
				continue;
			}
			BlockReference blockReference = (BlockReference)entity;
			if (blockReference.BlockName == _0023_003DznkMU43c_003D && blockReference._0023_003DzsQAoLomWIpW0(Blocks, _0023_003DzEkR_P10_003D: true))
			{
				blockReference._0023_003DzH5_UUBjbwiJl(_0023_003DzNBd9QxQErh13);
				blockReference.UpdateBoundingBox(_0023_003DzNBd9QxQErh13);
				if (_0023_003Dz_0024erWB3Y_003D != null)
				{
					blockReference._0023_003DzUT1EWEp6G6S4(_0023_003Dz_0024erWB3Y_003D);
				}
				list.Add(blockReference);
			}
		}
		if (list.Count == 0)
		{
			return false;
		}
		_0023_003DzLeyHB00_003D._0023_003DzfRP9c1V6cvLS(list);
		return true;
	}
}
