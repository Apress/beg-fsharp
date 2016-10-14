using System;
using System.Windows.Forms;
using Strangelights;

namespace CSApp {
	public partial class FibForm : Form {
		public FibForm() {
			InitializeComponent();
		}

		private void calculate_Click(object sender, EventArgs e) {
			// convert input to an integer
			int n = Convert.ToInt32(input.Text);
			// caculate the apropreate fibonacci number
			n = Fibonacci.get(n);
			// display result to user
			result.Text = n.ToString();
		}
	}
}