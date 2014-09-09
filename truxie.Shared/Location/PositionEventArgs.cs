using System;

namespace truxie.Shared
{
	public class PositionEventArgs : EventArgs {
		public Position Position { get; private set; }


		public PositionEventArgs(Position position) {
			this.Position = position;
		}
	}
}

