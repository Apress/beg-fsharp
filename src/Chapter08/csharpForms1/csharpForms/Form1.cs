using System;
using System.Windows.Forms;

namespace Strangelights.Forms {
	public partial class FibForm : Form {
		// public constructor for the form
		public FibForm() {
			InitializeComponent();
		}

		// expose the calculate button
		public Button Calculate {
			get { return calculate; }
		}

		// expose the results label
		public Label Result {
			get { return result; }
		}

		// expose the inputs text box
		public TextBox Input {
			get { return input; }
		}
	}
}