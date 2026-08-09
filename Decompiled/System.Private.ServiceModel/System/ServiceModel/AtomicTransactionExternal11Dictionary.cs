using System.Xml;

namespace System.ServiceModel;

internal class AtomicTransactionExternal11Dictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString CompletionUri;

	public XmlDictionaryString Durable2PCUri;

	public XmlDictionaryString Volatile2PCUri;

	public XmlDictionaryString CommitAction;

	public XmlDictionaryString RollbackAction;

	public XmlDictionaryString CommittedAction;

	public XmlDictionaryString AbortedAction;

	public XmlDictionaryString PrepareAction;

	public XmlDictionaryString PreparedAction;

	public XmlDictionaryString ReadOnlyAction;

	public XmlDictionaryString ReplayAction;

	public XmlDictionaryString FaultAction;

	public XmlDictionaryString UnknownTransaction;

	public AtomicTransactionExternal11Dictionary(XmlDictionary dictionary)
	{
		Namespace = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06");
		CompletionUri = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Completion");
		Durable2PCUri = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Durable2PC");
		Volatile2PCUri = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Volatile2PC");
		CommitAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Commit");
		RollbackAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Rollback");
		CommittedAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Committed");
		AbortedAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Aborted");
		PrepareAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Prepare");
		PreparedAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Prepared");
		ReadOnlyAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/ReadOnly");
		ReplayAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/Replay");
		FaultAction = dictionary.Add("http://docs.oasis-open.org/ws-tx/wsat/2006/06/fault");
		UnknownTransaction = dictionary.Add("UnknownTransaction");
	}
}
