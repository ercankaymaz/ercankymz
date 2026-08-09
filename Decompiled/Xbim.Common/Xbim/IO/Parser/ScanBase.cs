using System.CodeDom.Compiler;
using QUT.Gppg;

namespace Xbim.IO.Parser;

[GeneratedCode("Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType, LexLocation>
{
	private LexLocation __yylloc = new LexLocation();

	public override LexLocation yylloc
	{
		get
		{
			return __yylloc;
		}
		set
		{
			__yylloc = value;
		}
	}

	protected virtual bool yywrap()
	{
		return true;
	}
}
