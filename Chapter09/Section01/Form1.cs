using Microsoft.VisualBasic;
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
            //int age = today.Year - birth.Year;
            //if (today < birth.AddYears(age)) {
            //    age--;
            //}
            //var age = GetAge(birth, today);

            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth, today)}Î‚Å‚·";
            //TimeSpan ts = today.Date - birth.Date;
            tbOut2.Text = ($"¶‚Ü‚ê‚Ä‚©‚ç{(today.Date - birth.Date).Days}“ú").ToString();


            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);

            tbOut3.Text = $"¶‚Ü‚ê‚½{birth.Month}ŒŽ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{dayOfWeek}‚Å‚·";

            DateTime thisYearBirthday = new DateTime(today.Year,birth.Month, birth.Day);
            //Šù‚É’a¶“ú‚ª‰ß‚¬‚½‚©
            if (thisYearBirthday < today) {
                //–¢—ˆ‚Ì’a¶“ú‚ðì¬
                thisYearBirthday = thisYearBirthday.AddYears(1);
            }
            var span = thisYearBirthday - today;

            if (span.Days == 0) {
                tbOut04.Text = $"’a¶“ú‚Ü‚Å‚ ‚Æ{span.Days}“ú‚Å‚·";
            }



        }

        //”N—î‚ð‹‚ß‚éƒƒ\ƒbƒh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //Žw’è‚µ‚½“ú‚ª‘æ‰½T‚©‹‚ß‚é
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

        

        //static int NextB(DateTime birth, DateTime today) {
        //    if (birth.Date < today.Date) {

        //        return birth.Day + (today.Day +;
        //    } else {
        //        return birth.Day - today.Day;
        //    }
        //}

        #region
        private void label5_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
        #endregion
    }
}
