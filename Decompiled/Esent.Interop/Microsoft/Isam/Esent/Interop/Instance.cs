using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using Microsoft.Isam.Esent.Interop.Vista;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Isam.Esent.Interop;

public class Instance : SafeHandleZeroOrMinusOneIsInvalid
{
	private readonly InstanceParameters parameters;

	private readonly string name;

	private readonly string displayName;

	private TermGrbit termGrbit;

	public JET_INSTANCE JetInstance
	{
		[SecurityPermission(SecurityAction.LinkDemand)]
		get
		{
			CheckObjectIsNotDisposed();
			return CreateInstanceFromHandle();
		}
	}

	public InstanceParameters Parameters
	{
		[SecurityPermission(SecurityAction.LinkDemand)]
		get
		{
			CheckObjectIsNotDisposed();
			return parameters;
		}
	}

	public TermGrbit TermGrbit
	{
		[SecurityPermission(SecurityAction.LinkDemand)]
		get
		{
			CheckObjectIsNotDisposed();
			return termGrbit;
		}
		[SecurityPermission(SecurityAction.LinkDemand)]
		set
		{
			CheckObjectIsNotDisposed();
			termGrbit = value;
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public Instance(string name)
		: this(name, name, TermGrbit.None)
	{
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public Instance(string name, string displayName)
		: this(name, displayName, TermGrbit.None)
	{
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public Instance(string name, string displayName, TermGrbit termGrbit)
		: base(ownsHandle: true)
	{
		this.name = name;
		this.displayName = displayName;
		this.termGrbit = termGrbit;
		RuntimeHelpers.PrepareConstrainedRegions();
		JET_INSTANCE instance;
		try
		{
			SetHandle(JET_INSTANCE.Nil.Value);
		}
		finally
		{
			Api.JetCreateInstance2(out instance, this.name, this.displayName, CreateInstanceGrbit.None);
			SetHandle(instance.Value);
		}
		parameters = new InstanceParameters(instance);
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public static implicit operator JET_INSTANCE(Instance instance)
	{
		return instance.JetInstance;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", displayName, name);
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public void Init()
	{
		Init(InitGrbit.None);
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public void Init(InitGrbit grbit)
	{
		CheckObjectIsNotDisposed();
		JET_INSTANCE instance = JetInstance;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			Api.JetInit2(ref instance, grbit);
		}
		finally
		{
			SetHandle(instance.Value);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public void Init(JET_RSTINFO recoveryOptions, InitGrbit grbit)
	{
		CheckObjectIsNotDisposed();
		JET_INSTANCE instance = JetInstance;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			VistaApi.JetInit3(ref instance, recoveryOptions, grbit);
		}
		finally
		{
			SetHandle(instance.Value);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	public void Term()
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
		}
		finally
		{
			try
			{
				Api.JetTerm2(JetInstance, termGrbit);
			}
			catch (EsentDirtyShutdownException)
			{
				SetHandleAsInvalid();
				throw;
			}
			SetHandleAsInvalid();
		}
	}

	protected override bool ReleaseHandle()
	{
		JET_INSTANCE instance = CreateInstanceFromHandle();
		return Api.Impl.JetTerm2(instance, termGrbit) == 0;
	}

	private JET_INSTANCE CreateInstanceFromHandle()
	{
		return new JET_INSTANCE
		{
			Value = handle
		};
	}

	[SecurityPermission(SecurityAction.LinkDemand)]
	private void CheckObjectIsNotDisposed()
	{
		if (IsInvalid || base.IsClosed)
		{
			throw new ObjectDisposedException("Instance");
		}
	}
}
