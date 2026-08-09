using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buOpcUA;

public class OpcUaConnector
{
	[CompilerGenerated]
	private sealed class _0001 : IAsyncStateMachine
	{
		public int _0001;

		public AsyncTaskMethodBuilder<Session> _0001;

		public string _0001;

		public OpcUaConnector _0001;

		private ApplicationConfiguration m__0001;

		private EndpointDescription m__0001;

		private EndpointConfiguration m__0001;

		private ConfiguredEndpoint m__0001;

		private Session m__0001;

		private Session _0002;

		private Exception m__0001;

		private TaskAwaiter m__0001;

		private TaskAwaiter<Session> m__0001;

		[NonSerialized]
		internal static GetString _0007;

		private void _0001()
		{
			int num = this._0001;
			int num2;
			if (7u != 0)
			{
				num2 = num;
			}
			Session result;
			try
			{
				if ((uint)num2 > 1u)
				{
				}
				try
				{
					while (true)
					{
						TaskAwaiter<Session> awaiter;
						if (num2 != 0)
						{
							if (num2 != 1)
							{
								this.m__0001 = new ApplicationConfiguration
								{
									ApplicationName = _0007(107395724),
									ApplicationType = ApplicationType.Client,
									SecurityConfiguration = new SecurityConfiguration
									{
										ApplicationCertificate = new CertificateIdentifier(),
										AutoAcceptUntrustedCertificates = true
									},
									TransportQuotas = new TransportQuotas
									{
										OperationTimeout = 15000
									},
									ClientConfiguration = new ClientConfiguration
									{
										DefaultSessionTimeout = 60000
									}
								};
								goto IL_00b9;
							}
							awaiter = this.m__0001;
							this.m__0001 = default(TaskAwaiter<Session>);
							num2 = (this._0001 = -1);
							goto IL_020c;
						}
						if (8 == 0)
						{
							continue;
						}
						TaskAwaiter awaiter2 = this.m__0001;
						this.m__0001 = default(TaskAwaiter);
						num2 = (this._0001 = -1);
						goto IL_0124;
						IL_0124:
						awaiter2.GetResult();
						goto IL_012c;
						IL_020c:
						_0002 = awaiter.GetResult();
						this.m__0001 = _0002;
						if (0 == 0)
						{
							break;
						}
						goto IL_01be;
						IL_01be:
						if (!awaiter.IsCompleted)
						{
							num2 = (this._0001 = 1);
							this.m__0001 = awaiter;
							_0001 stateMachine = this;
							this._0001.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_020c;
						IL_012c:
						this.m__0001 = _0095._009E(this._0001, false);
						this.m__0001 = _0088._008F(this.m__0001);
						if (1 == 0)
						{
							goto IL_00b9;
						}
						this.m__0001 = new ConfiguredEndpoint(null, this.m__0001, this.m__0001);
						awaiter = _0089._0090(this.m__0001, this.m__0001, false, _0007(107395675), 60000u, new UserIdentity(new AnonymousIdentityToken()), null, default(CancellationToken)).GetAwaiter();
						goto IL_01be;
						IL_00b9:
						awaiter2 = _008B._007E_0092(_0094._007E_009D(this.m__0001, ApplicationType.Client));
						if (awaiter2.IsCompleted)
						{
							goto IL_0124;
						}
						num2 = (this._0001 = 0);
						if (uint.MaxValue != 0)
						{
							this.m__0001 = awaiter2;
							_0001 stateMachine = this;
							this._0001.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_012c;
					}
					_0002 = null;
					_0096._009F(_0007(107395690));
					result = this.m__0001;
				}
				catch (Exception ex)
				{
					this.m__0001 = ex;
					_0096._009F(_0012._0016(_0007(107395661), _0011._007E_0014(this.m__0001)));
					result = null;
				}
			}
			catch (Exception ex)
			{
				if (true)
				{
					this._0001 = -2;
					this._0001.SetException(ex);
				}
				return;
			}
			this._0001 = -2;
			this._0001.SetResult(result);
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

	[AsyncStateMachine(typeof(_0001))]
	[DebuggerStepThrough]
	public Task<Session> ConnectAsync(string endpointUrl)
	{
		_0001 stateMachine;
		do
		{
			stateMachine = new _0001();
			stateMachine._0001 = AsyncTaskMethodBuilder<Session>.Create();
		}
		while (false);
		stateMachine._0001 = this;
		stateMachine._0001 = endpointUrl;
		stateMachine._0001 = -1;
		stateMachine._0001.Start(ref stateMachine);
		return stateMachine._0001.Task;
	}
}
