namespace QUT.Gppg;

public abstract class AbstractScanner<TValue, TSpan> where TSpan : IMerge<TSpan>
{
	public TValue yylval;

	public virtual TSpan yylloc
	{
		get
		{
			return default(TSpan);
		}
		set
		{
		}
	}

	public abstract int yylex();

	public virtual void yyerror(string format, params object[] args)
	{
	}
}
