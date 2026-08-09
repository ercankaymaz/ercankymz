using System.Xml;

namespace System.Speech.Recognition.SrgsGrammar;

public abstract class SrgsElement : MarshalByRefObject
{
	protected SrgsElement()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	internal abstract string DebuggerDisplayString();

	internal abstract void WriteSrgs(XmlWriter writer);
}
