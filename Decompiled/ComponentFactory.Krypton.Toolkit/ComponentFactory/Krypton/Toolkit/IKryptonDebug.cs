namespace ComponentFactory.Krypton.Toolkit;

public interface IKryptonDebug
{
	int KryptonLayoutCounter { get; }

	int KryptonPaintCounter { get; }

	void KryptonResetCounters();
}
