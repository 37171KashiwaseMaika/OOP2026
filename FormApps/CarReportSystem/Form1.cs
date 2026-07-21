using System.ComponentModel;
using System.Windows.Forms;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listcarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listcarReports;
        }
        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {
            tsslbMessage.Text = String.Empty;//メッセージ領域クリア
            if (cbAuthor.Text == String.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }


            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listcarReports.Add(carReport);

            //入力履歴を登録
            SetCbAuthor(cbAuthor.Text);
            SetCbName(cbCarName.Text);
            ImputItemsUpdate();//データグリッドビューを更新したら呼ぶメリット


            ImputltemsAllClear();//入力項目の全クリ
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;
            else return MakerGroup.その他;
        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            ImputltemsAllClear();
        }

        //
        private void ImputltemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private void dgvRecords_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected))return;
            
            //一覧選択時の表示
            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

            ImputItemsUpdate();
        }

        private void SetRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);//Itemsに格納
            }
        }

        //車名の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void ImputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                ImputltemsAllClear();
        }

        //修正
        private void btModifyRecord_Click(object sender, EventArgs e) {            
            if ((dgvRecords.CurrentRow is null) ||
                    (!dgvRecords.CurrentRow.Selected)) return;

            int sel = dgvRecords.CurrentRow.Index;            
            listcarReports[sel].Date = dtpDate.Value;
            listcarReports[sel].Author = cbAuthor.Text;
            listcarReports[sel].Maker = GetRadioButtonMaker();
            listcarReports[sel].CarName = cbCarName.Text;
            listcarReports[sel].Report = tbReport.Text;
            listcarReports[sel].Picture = pbPicture.Image;

            dgvRecords.Refresh();//データグリッドビューの更新

        }

        //選択・削除
        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null) || 
                    (!dgvRecords.CurrentRow.Selected)) return;
            
            listcarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            
            dgvRecords.Refresh();//データグリッドビューの更新
        }
    }
}