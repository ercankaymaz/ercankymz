namespace Microsoft.Isam.Esent.Interop;

public class Table : EsentResource
{
	private JET_SESID sesid;

	private JET_TABLEID tableid;

	private string name;

	public string Name
	{
		get
		{
			CheckObjectIsNotDisposed();
			return name;
		}
	}

	public JET_TABLEID JetTableid
	{
		get
		{
			CheckObjectIsNotDisposed();
			return tableid;
		}
	}

	public Table(JET_SESID sesid, JET_DBID dbid, string name, OpenTableGrbit grbit)
	{
		this.sesid = sesid;
		this.name = name;
		Api.JetOpenTable(this.sesid, dbid, this.name, null, 0, grbit, out tableid);
		ResourceWasAllocated();
	}

	public static implicit operator JET_TABLEID(Table table)
	{
		return table.JetTableid;
	}

	public override string ToString()
	{
		return name;
	}

	public void Close()
	{
		CheckObjectIsNotDisposed();
		ReleaseResource();
	}

	protected override void ReleaseResource()
	{
		Api.JetCloseTable(sesid, tableid);
		sesid = JET_SESID.Nil;
		tableid = JET_TABLEID.Nil;
		name = null;
		ResourceWasReleased();
	}
}
