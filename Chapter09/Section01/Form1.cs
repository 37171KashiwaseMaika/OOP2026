namespace Section01 {
    public partial class btGet : Form {
        public btGet() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            DateTime dt1 = dtpDate.Value;
            DayOfWeek dayOfWeek = dt1.DayOfWeek;

            if (DateTime.IsLeapYear(dt1.Year)) {
                tbOut.Text = "‚¤‚é‚¤”N‚Å‚·";
            } else {
                tbOut.Text = "‚¤‚é‚¤”N‚Å‚Í‚ ‚è‚Ü‚¹‚ñ";
            }

            switch (dt1.DayOfWeek) {
                case DayOfWeek.Saturday:
                    tbOut.Text = "¡“ú‚Í“y—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Sunday:
                    tbOut.Text = "¡“ú‚Í“ú—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Monday:
                    tbOut.Text = "¡“ú‚ÍŒ—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Tuesday:
                    tbOut.Text = "¡“ú‚Í‰Î—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Wednesday:
                    tbOut.Text = "¡“ú‚Í…—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Thursday:
                    tbOut.Text = "¡“ú‚Í–Ø—j“ú‚Å‚·";
                    break;
                case DayOfWeek.Friday:
                    tbOut.Text = "¡“ú‚Í‹à—j“ú‚Å‚·";
                    break;
            }
        }
    }
}
