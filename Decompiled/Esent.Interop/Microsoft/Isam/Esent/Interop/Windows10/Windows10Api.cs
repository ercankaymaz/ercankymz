using Microsoft.Isam.Esent.Interop.Windows8;

namespace Microsoft.Isam.Esent.Interop.Windows10;

public static class Windows10Api
{
	public static void JetGetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, out JET_OPERATIONCONTEXT operationContext)
	{
		Api.Check(Api.Impl.JetGetSessionParameter(sesid, sesparamid, out operationContext));
	}

	public static void JetSetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, JET_OPERATIONCONTEXT operationContext)
	{
		Api.Check(Api.Impl.JetSetSessionParameter(sesid, sesparamid, operationContext));
	}

	public static void JetGetThreadStats(out JET_THREADSTATS2 threadstats)
	{
		Api.Check(Api.Impl.JetGetThreadStats(out threadstats));
	}
}
