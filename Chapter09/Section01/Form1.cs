using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            //DateTime date = dtpDate.Value;
            //tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
            DateTime birth = dtpBirth.Value;
            DateTime today = DateTime.Today;
            tbOut2.Text = (today.Date - birth.Date).ToString();
            int age = today.Year - birth.Year;
            if (today < birth.AddYears(age)) {
                age--;
            }
            tbOut.Text = $"‚ ‚È‚½‚Í{age}Î‚Å‚·";
        }

        private void tbOut_TextChanged(object sender, EventArgs e) {

        }
    }
}
