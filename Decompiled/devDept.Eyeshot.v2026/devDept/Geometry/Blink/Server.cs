using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink;

internal class Server : IDisposable
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzB55d4iIiz4QQyasdhAvMewU_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Server _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D _0023_003DzLFBzTF8Iawncx951IQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Server server = _0023_003DzopRx0_MBcTQs;
			try
			{
				if (num == 0)
				{
					goto IL_0022;
				}
				_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = new _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D();
				goto IL_00e2;
				IL_0022:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = server._configurationPipe.WaitForConnectionAsync(server._tokenSource.Token).GetAwaiter();
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
					_0023_003DzLFBzTF8Iawncx951IQ_003D_003D._0023_003Dz18lsJP2p7ers(server._configurationPipe, server.ClientConfiguration, 1);
					_0023_003DzLFBzTF8Iawncx951IQ_003D_003D._0023_003DzUal_0024ApYHAIaM();
				}
				catch (OperationCanceledException)
				{
					goto end_IL_000e;
				}
				catch (IOException ex2)
				{
					Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655330), ex2.Message);
					goto end_IL_000e;
				}
				finally
				{
					if (num < 0)
					{
						server._configurationPipe.Disconnect();
					}
				}
				goto IL_00e2;
				IL_00e2:
				if (!server._tokenSource.IsCancellationRequested)
				{
					goto IL_0022;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = null;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = null;
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
	private struct _0023_003DzCM0C72W97P3aEu9rvuH4JEE_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Server _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D _0023_003DzLFBzTF8Iawncx951IQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MemoryStream _0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Server server = _0023_003DzopRx0_MBcTQs;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_0023;
				}
				_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = new _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D();
				goto IL_01a5;
				IL_0023:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						if (num == 1)
						{
							goto IL_00a1;
						}
						awaiter = server._mainPipe.WaitForConnectionAsync(server._tokenSource.Token).GetAwaiter();
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
					_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D = new MemoryStream();
					goto IL_00a1;
					IL_00a1:
					try
					{
						if (num != 1)
						{
							awaiter = server._mainPipe.CopyToAsync(_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D).GetAwaiter();
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
						_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D.Position = 0L;
						BlinkMsg[] messages = _0023_003DzLFBzTF8Iawncx951IQ_003D_003D._0023_003DzpjtaAFYywh9r<BlinkMsg>(_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D, 1);
						_0023_003DzLFBzTF8Iawncx951IQ_003D_003D._0023_003DzUal_0024ApYHAIaM();
						server.OnDataIn(new BlinkServerArgs(messages));
					}
					finally
					{
						if (num < 0 && _0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D != null)
						{
							((IDisposable)_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D).Dispose();
						}
					}
					_0023_003Dzo3_ytAI5pa3IofIPgw_003D_003D = null;
				}
				catch (OperationCanceledException)
				{
					goto end_IL_000e;
				}
				catch (IOException ex2)
				{
					Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655330), ex2.Message);
					goto end_IL_000e;
				}
				catch (Exception ex3)
				{
					server.OnError(new BlinkServerArgs(ex3));
				}
				finally
				{
					if (num < 0)
					{
						server._mainPipe.Disconnect();
					}
				}
				goto IL_01a5;
				IL_01a5:
				if (!server._tokenSource.IsCancellationRequested)
				{
					goto IL_0023;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = null;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzLFBzTF8Iawncx951IQ_003D_003D = null;
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

	private NamedPipeServerStream _mainPipe;

	private NamedPipeServerStream _configurationPipe;

	private CancellationTokenSource _tokenSource;

	public ClientConfiguration ClientConfiguration = new ClientConfiguration();

	public event EventHandler<BlinkServerArgs> DataIn;

	public event EventHandler<BlinkServerArgs> Error;

	private void OnDataIn(BlinkServerArgs e)
	{
		this.DataIn?.Invoke(this, e);
	}

	private void OnError(BlinkServerArgs e)
	{
		this.Error?.Invoke(this, e);
	}

	private void Init()
	{
		_mainPipe = new NamedPipeServerStream(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654853), PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
		_configurationPipe = new NamedPipeServerStream(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654560), PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
		_tokenSource = new CancellationTokenSource();
	}

	internal static bool AlreadyRunning()
	{
		NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654853), PipeDirection.Out, PipeOptions.None);
		try
		{
			namedPipeClientStream.Connect(100);
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			((IDisposable)namedPipeClientStream).Dispose();
		}
		return true;
	}

	private async Task RunMainPipe()
	{
		_0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2 = new _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D();
		while (!_tokenSource.IsCancellationRequested)
		{
			try
			{
				await _mainPipe.WaitForConnectionAsync(_tokenSource.Token);
				using MemoryStream memoryStream = new MemoryStream();
				await _mainPipe.CopyToAsync(memoryStream);
				memoryStream.Position = 0L;
				BlinkMsg[] messages = _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2._0023_003DzpjtaAFYywh9r<BlinkMsg>(memoryStream, 1);
				_0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2._0023_003DzUal_0024ApYHAIaM();
				OnDataIn(new BlinkServerArgs(messages));
			}
			catch (OperationCanceledException)
			{
				break;
			}
			catch (IOException ex2)
			{
				Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655330), ex2.Message);
				break;
			}
			catch (Exception ex3)
			{
				OnError(new BlinkServerArgs(ex3));
			}
			finally
			{
				_mainPipe.Disconnect();
			}
		}
	}

	private async Task RunConfigurationPipe()
	{
		_0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2 = new _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D();
		while (!_tokenSource.IsCancellationRequested)
		{
			try
			{
				await _configurationPipe.WaitForConnectionAsync(_tokenSource.Token);
				_0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2._0023_003Dz18lsJP2p7ers(_configurationPipe, ClientConfiguration, 1);
				_0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D2._0023_003DzUal_0024ApYHAIaM();
			}
			catch (OperationCanceledException)
			{
				break;
			}
			catch (IOException ex2)
			{
				Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655330), ex2.Message);
				break;
			}
			finally
			{
				_configurationPipe.Disconnect();
			}
		}
	}

	public void Dispose()
	{
		_mainPipe.Dispose();
		_configurationPipe.Dispose();
		_tokenSource.Dispose();
	}

	public void Start()
	{
		Init();
		Task.WhenAll(RunMainPipe(), RunConfigurationPipe()).ContinueWith(delegate
		{
			Dispose();
		});
	}

	public void Stop()
	{
		_tokenSource.Cancel();
	}
}
