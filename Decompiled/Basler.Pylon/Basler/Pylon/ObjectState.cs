namespace Basler.Pylon;

internal class ObjectState(object master_)
{
	public EObjectState m_state = EObjectState.Closed;

	public int m_entryCount = 0;

	public bool m_flagInUse = false;

	public string m_name;

	private object m_master = master_;
}
