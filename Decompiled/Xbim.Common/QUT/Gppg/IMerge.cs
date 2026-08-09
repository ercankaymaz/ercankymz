namespace QUT.Gppg;

public interface IMerge<TSpan>
{
	TSpan Merge(TSpan last);
}
