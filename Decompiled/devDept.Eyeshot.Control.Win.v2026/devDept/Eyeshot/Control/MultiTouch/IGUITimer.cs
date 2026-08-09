using System;

namespace devDept.Eyeshot.Control.MultiTouch;

public interface IGUITimer : IDisposable
{
	bool Enabled { get; set; }

	int Interval { get; set; }

	event EventHandler Tick;

	void Start();

	void Stop();
}
