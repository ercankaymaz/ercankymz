using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using _0002;
using Opc.Ua;
using Opc.Ua.Client;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buOpcUA;

public class OpcClient
{
	[CompilerGenerated]
	private sealed class _0001 : IAsyncStateMachine
	{
		public int _0001;

		public AsyncTaskMethodBuilder<Session> _0001;

		public OpcClient _0001;

		private ApplicationConfiguration m__0001;

		private EndpointDescription m__0001;

		private EndpointConfiguration m__0001;

		private ConfiguredEndpoint m__0001;

		private Session m__0001;

		private Exception m__0001;

		private TaskAwaiter<Session> m__0001;

		[NonSerialized]
		internal static GetString _0008;

		private void _0001()
		{
			do
			{
				int num = this._0001;
				Session session;
				try
				{
					if (num != 0)
					{
					}
					while (5 == 0)
					{
					}
					try
					{
						int num2 = num;
						while (true)
						{
							if (num2 == 0)
							{
								goto IL_0116;
							}
							this.m__0001 = global::_0002._0003._0001(this._0001);
							this.m__0001 = _0087._008E(this._0001.m__0002, false, 120000);
							this.m__0001 = _0088._008F(this.m__0001);
							this.m__0001 = new ConfiguredEndpoint(null, this.m__0001, this.m__0001);
							TaskAwaiter<Session> awaiter = _0089._0090(this.m__0001, this.m__0001, false, this._0001._0001, 120000u, new UserIdentity(new AnonymousIdentityToken()), null, default(CancellationToken)).GetAwaiter();
							num2 = (awaiter.IsCompleted ? 1 : 0);
							if (false)
							{
								continue;
							}
							if (num2 == 0)
							{
								num = (this._0001 = 0);
								this.m__0001 = awaiter;
								_0001 stateMachine = this;
								this._0001.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								break;
							}
							goto IL_0132;
							IL_0132:
							if (false)
							{
								goto IL_0116;
							}
							this.m__0001 = awaiter.GetResult();
							this._0001.Session = this.m__0001;
							this.m__0001 = null;
							this.m__0001 = null;
							this.m__0001 = null;
							this.m__0001 = null;
							this.m__0001 = null;
							goto end_IL_001f;
							IL_0116:
							awaiter = this.m__0001;
							this.m__0001 = default(TaskAwaiter<Session>);
							num = (this._0001 = -1);
							goto IL_0132;
						}
						goto end_IL_000f;
						end_IL_001f:;
					}
					catch (Exception ex)
					{
						this.m__0001 = ex;
						_0019._001F(_0011._007E_0014(this.m__0001));
						throw new Exception(_0012._0016(_0008(107395714), _0011._007E_0014(this.m__0001)), this.m__0001);
					}
					_008A._007E_0091(this._0001.Session, this._0001._0001);
					session = this._0001.Session;
					goto IL_0258;
					end_IL_000f:;
				}
				catch (Exception ex)
				{
					this._0001 = -2;
					this._0001.SetException(ex);
				}
				goto IL_026d;
				IL_0258:
				this._0001 = -2;
				this._0001.SetResult(session);
				goto IL_026d;
				IL_026d:
				while (false)
				{
				}
			}
			while (1 == 0);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001();
		}

		private void _0001(IAsyncStateMachine P_0)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001(P_0);
		}

		static _0001()
		{
			Strings.CreateGetStringDelegate(typeof(_0001));
		}
	}

	[CompilerGenerated]
	private sealed class _0002 : IAsyncStateMachine
	{
		public int _0001;

		public AsyncTaskMethodBuilder _0001;

		public OpcClient _0001;

		private TaskAwaiter<StatusCode> m__0001;

		private void _0001()
		{
			int num = this._0001;
			try
			{
				TaskAwaiter<StatusCode> awaiter;
				if (num == 0)
				{
					awaiter = this.m__0001;
					goto IL_00ad;
				}
				if (this._0001.Session != null && global::_0001._007E_0002(this._0001.Session))
				{
					awaiter = Task.Run(() => global::_0006._007E_0008(this._0001.Session)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						if (0 == 0)
						{
							num = (this._0001 = 0);
							this.m__0001 = awaiter;
							_0002 stateMachine = this;
							this._0001.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00ad;
					}
					goto IL_00c2;
				}
				goto end_IL_000f;
				IL_00ad:
				this.m__0001 = default(TaskAwaiter<StatusCode>);
				num = (this._0001 = -1);
				goto IL_00c2;
				IL_00c2:
				awaiter.GetResult();
				global::_0005._007E_0006(this._0001.Session);
				this._0001.Session = null;
				end_IL_000f:;
			}
			catch (Exception exception)
			{
				this._0001 = -2;
				this._0001.SetException(exception);
				return;
			}
			this._0001 = -2;
			this._0001.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001();
		}

		private void _0001(IAsyncStateMachine P_0)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class _0003 : IAsyncStateMachine
	{
		public int _0001;

		public AsyncTaskMethodBuilder _0001;

		public OpcClient _0001;

		private TaskAwaiter m__0001;

		private TaskAwaiter<Session> m__0001;

		private void _0001()
		{
			if (0 == 0)
			{
				int num = this._0001;
				try
				{
					int num2 = num;
					TaskAwaiter<Session> awaiter;
					while (true)
					{
						if (num2 != 0)
						{
							if (num == 1)
							{
								awaiter = this.m__0001;
								this.m__0001 = default(TaskAwaiter<Session>);
								num = (this._0001 = -1);
								break;
							}
							goto IL_0026;
						}
						goto IL_00b1;
						IL_00d6:
						if (true)
						{
							awaiter = this._0001.ConnectAsync().GetAwaiter();
							if (awaiter.IsCompleted)
							{
								break;
							}
							num = (this._0001 = 1);
							this.m__0001 = awaiter;
							_0003 stateMachine = this;
							if (5 == 0)
							{
								goto IL_0026;
							}
							this._0001.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							if (0 == 0)
							{
								return;
							}
						}
						goto IL_00b1;
						IL_0026:
						if (5 == 0)
						{
							goto IL_00b1;
						}
						bool flag = this._0001.Session != null && global::_0001._007E_0002(this._0001.Session);
						num2 = (flag ? 1 : 0);
						if (false)
						{
							continue;
						}
						TaskAwaiter awaiter2;
						if (num2 != 0)
						{
							awaiter2 = _008B._007E_0092(this._0001.DisconnectAsync());
							if (!awaiter2.IsCompleted)
							{
								num = (this._0001 = 0);
								this.m__0001 = awaiter2;
								_0003 stateMachine = this;
								this._0001.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00cd;
						}
						goto IL_00d6;
						IL_00b1:
						awaiter2 = this.m__0001;
						this.m__0001 = default(TaskAwaiter);
						num = (this._0001 = -1);
						goto IL_00cd;
						IL_00cd:
						awaiter2.GetResult();
						goto IL_00d6;
					}
					awaiter.GetResult();
				}
				catch (Exception exception)
				{
					this._0001 = -2;
					this._0001.SetException(exception);
					return;
				}
				if (3 == 0)
				{
					return;
				}
				this._0001 = -2;
			}
			this._0001.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001();
		}

		private void _0001(IAsyncStateMachine P_0)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in 
			this._0001(P_0);
		}
	}

	internal readonly string _0001;

	private readonly string m__0002;

	public readonly NodeId _firstNode;

	[CompilerGenerated]
	private Session m__0001;

	[CompilerGenerated]
	private bool m__0001;

	[NonSerialized]
	internal static GetString _0004;

	public Session Session
	{
		[CompilerGenerated]
		get
		{
			return this.m__0001;
		}
		[CompilerGenerated]
		private set
		{
			this.m__0001 = session;
		}
	}

	public bool IsConnected
	{
		[CompilerGenerated]
		get
		{
			return this.m__0001;
		}
		[CompilerGenerated]
		set
		{
			this.m__0001 = value;
		}
	}

	public OpcClient(string applicationName, string serverUrl, string firstNode)
	{
		this._0001 = applicationName;
		this.m__0002 = serverUrl;
		_firstNode = new NodeId(firstNode);
	}

	private void _0001(ISession P_0, KeepAliveEventArgs P_1)
	{
		int num;
		while (true)
		{
			if (P_0 == null)
			{
				if (4 == 0)
				{
					continue;
				}
				num = ((!global::_0001._007E_0001(P_0)) ? 1 : 0);
				break;
			}
			num = 0;
			break;
		}
		bool flag = (byte)num != 0;
		bool num2 = flag;
		if (false)
		{
			goto IL_006f;
		}
		if (num2)
		{
			goto IL_00aa;
		}
		if (global::_0002._007E_0003(P_1) != null)
		{
			goto IL_0052;
		}
		int num3 = 0;
		goto IL_006a;
		IL_0052:
		num3 = (global::_0003._0004(global::_0002._007E_0003(P_1)) ? 1 : 0);
		goto IL_006a;
		IL_006f:
		if (!num2)
		{
			IsConnected = true;
			return;
		}
		goto IL_0072;
		IL_0072:
		IsConnected = false;
		if (4 == 0)
		{
			goto IL_00aa;
		}
		return;
		IL_006a:
		bool flag2 = (byte)num3 != 0;
		if (8u != 0)
		{
			num2 = flag2;
			goto IL_006f;
		}
		goto IL_0072;
		IL_00aa:
		IsConnected = false;
		if (7u != 0)
		{
			return;
		}
		goto IL_0052;
	}

	[AsyncStateMachine(typeof(_0001))]
	[DebuggerStepThrough]
	public Task<Session> ConnectAsync()
	{
		_0001 stateMachine;
		if (true)
		{
			stateMachine = new _0001();
			do
			{
				stateMachine._0001 = AsyncTaskMethodBuilder<Session>.Create();
			}
			while (false);
			if (6 == 0)
			{
				goto IL_0032;
			}
			stateMachine._0001 = this;
			stateMachine._0001 = -1;
		}
		stateMachine._0001.Start(ref stateMachine);
		goto IL_0032;
		IL_0032:
		return stateMachine._0001.Task;
	}

	[AsyncStateMachine(typeof(_0002))]
	[DebuggerStepThrough]
	public Task DisconnectAsync()
	{
		_0002 stateMachine = new _0002();
		do
		{
			stateMachine._0001 = global::_0004._0005();
			do
			{
				stateMachine._0001 = this;
			}
			while (-1 == 0);
			stateMachine._0001 = -1;
			stateMachine._0001.Start(ref stateMachine);
		}
		while (false);
		return stateMachine._0001.Task;
	}

	[AsyncStateMachine(typeof(_0003))]
	[DebuggerStepThrough]
	public Task ReconnectAsync()
	{
		_0003 stateMachine = new _0003();
		do
		{
			stateMachine._0001 = global::_0004._0005();
			do
			{
				stateMachine._0001 = this;
			}
			while (-1 == 0);
			stateMachine._0001 = -1;
			stateMachine._0001.Start(ref stateMachine);
		}
		while (false);
		return stateMachine._0001.Task;
	}

	public Dictionary<string, string> BrowseAllNodes(NodeId startNodeId)
	{
		Dictionary<string, string> dictionary2 = default(Dictionary<string, string>);
		bool flag2 = default(bool);
		while (true)
		{
			Queue<NodeId> queue = new Queue<NodeId>();
			Queue<NodeId> queue2;
			if (4u != 0)
			{
				queue2 = queue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (0 == 0)
			{
				dictionary2 = dictionary;
			}
			queue2.Enqueue(startNodeId);
			while (true)
			{
				int num = queue2.Count;
				while (true)
				{
					bool flag = num > 0;
					if (false)
					{
						break;
					}
					num = (flag ? 1 : 0);
					if (false)
					{
						continue;
					}
					goto IL_018f;
				}
				break;
				IL_018f:
				if (num != 0)
				{
					if (0 == 0)
					{
						NodeId nodeId = queue2.Dequeue();
						try
						{
							do
							{
								BrowseDescription item = new BrowseDescription
								{
									NodeId = nodeId,
									BrowseDirection = BrowseDirection.Forward,
									ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
									IncludeSubtypes = true,
									NodeClassMask = 3u,
									ResultMask = 63u
								};
								BrowseResultCollection results;
								do
								{
									Session.Browse(null, null, 0u, new BrowseDescriptionCollection { item }, out results, out var _);
								}
								while (8 == 0);
								int num2;
								if (results != null)
								{
									if (7 == 0)
									{
										goto IL_00b5;
									}
									num2 = ((results.Count > 0) ? 1 : 0);
								}
								else
								{
									num2 = 0;
								}
								flag2 = (byte)num2 != 0;
								goto IL_00b5;
								IL_00b5:
								if (!flag2)
								{
									continue;
								}
								foreach (ReferenceDescription reference in results[0].References)
								{
									NodeId nodeId2 = ExpandedNodeId.ToNodeId(reference.NodeId, Session.NamespaceUris);
									dictionary2.Add(reference.BrowseName.Name, nodeId2.ToString());
									if (nodeId2 != null)
									{
										queue2.Enqueue(nodeId2);
									}
								}
							}
							while (8 == 0);
						}
						catch (Exception ex)
						{
							Console.WriteLine(_0004(107396247) + ex.Message);
							if (false)
							{
							}
						}
						continue;
					}
					Dictionary<string, string> result;
					return result;
				}
				return dictionary2;
			}
		}
	}

	public void Dispose()
	{
		Session?.Dispose();
	}

	[CompilerGenerated]
	private StatusCode _0001()
	{
		return global::_0006._007E_0008(Session);
	}

	static OpcClient()
	{
		Strings.CreateGetStringDelegate(typeof(OpcClient));
	}
}
