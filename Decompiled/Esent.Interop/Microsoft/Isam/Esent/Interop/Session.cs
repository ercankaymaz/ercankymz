using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class Session : EsentResource
{
	private JET_SESID sesid;

	public JET_SESID JetSesid
	{
		get
		{
			CheckObjectIsNotDisposed();
			return sesid;
		}
	}

	public Session(JET_INSTANCE instance)
	{
		Api.JetBeginSession(instance, out sesid, null, null);
		ResourceWasAllocated();
	}

	public static implicit operator JET_SESID(Session session)
	{
		return session.JetSesid;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Session (0x{0:x})", sesid.Value);
	}

	public void End()
	{
		CheckObjectIsNotDisposed();
		ReleaseResource();
	}

	protected override void ReleaseResource()
	{
		if (!sesid.IsInvalid)
		{
			Api.JetEndSession(JetSesid, EndSessionGrbit.None);
		}
		sesid = JET_SESID.Nil;
		ResourceWasReleased();
	}
}
