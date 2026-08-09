namespace QUT.Gppg;

public class LexLocation : IMerge<LexLocation>
{
	private int startLine;

	private int startColumn;

	private int endLine;

	private int endColumn;

	public int StartLine => startLine;

	public int StartColumn => startColumn;

	public int EndLine => endLine;

	public int EndColumn => endColumn;

	public LexLocation()
	{
	}

	public LexLocation(int sl, int sc, int el, int ec)
	{
		startLine = sl;
		startColumn = sc;
		endLine = el;
		endColumn = ec;
	}

	public LexLocation Merge(LexLocation last)
	{
		return new LexLocation(startLine, startColumn, last.endLine, last.endColumn);
	}
}
