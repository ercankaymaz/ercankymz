using System.CodeDom.Compiler;
using QUT.Gppg;

namespace Xbim.IO.Parser;

[GeneratedCode("Gardens Point Parser Generator", "1.5.2")]
public class ScanObj
{
	public int token;

	public ValueType yylval;

	public LexLocation yylloc;

	public ScanObj(int t, ValueType val, LexLocation loc)
	{
		token = t;
		yylval = val;
		yylloc = loc;
	}
}
