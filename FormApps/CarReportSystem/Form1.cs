using SQLiteProductSample;
using System.ComponentModel;

using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        private readonly BindingList<CarReport> _carreports = new();

        //設定クラスのオブジェクトを生成
        //Settings settings = Settings.Instance;

        // DataGridViewへ表示する商品の一覧
        //private readonly BindingList<CarReport> _carreports = new();
        // DB操作を担当するRepository
        private readonly CarReportRepository _repository = new();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = _carreports;


            //ProductsクラスのプロパティからDataGriDView列を自動生成する
            dgvRecords.AutoGenerateColumns = true;
            //DataGridViewの元データとしてBindingListを設定する
            dgvRecords.DataSource = _carreports;
            //起動直後にDBから商品一覧を読み込む
            ReloadCarReports();

            //使用中のDBファイルの場所をステータスバーへ表示する
            //tsslbMessage.Text = $"DB:{Database.FilePath}";
        }





        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {
            tsslbMessage.Text = String.Empty;//メッセージ領域クリア


            if (cbAuthor.Text == String.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }
            // if (!dgvRecords(out DateTime date, out string author, out MakerGroup maker, out string carname, out string report, out Image? picture))
            //    return;

            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text.Trim(),
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            _carreports.Add(carReport);


            try {
                _repository.Add(carReport);
                ReloadCarReports();
                ClearInput();

                tsslbMessage.Text = "商品を登録しました。";
            }
            catch (Exception ex) {
                ShowError("登録エラー", ex);
            }







            //入力履歴を登録
            SetCbAuthor(cbAuthor.Text);
            SetCbCarName(cbCarName.Text);

            dgvRecords.ClearSelection();//未選択にする
            InputItemsUpdate();//データグリッドビューを更新したら呼ぶメリット


            ImputltemsAllClear();//入力項目の全クリア

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

            dgvRecords.ClearSelection();//未選択にする
           
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
        private void SetCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            //設定ファイルを読み込み背景色を設定する（逆シリアル化）

            try {
                Settings.Instance.Load();
                BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
            }
            catch (Exception ex) {
                tsslbMessage.Text = "設定ファイル読み込みエラー";
                MessageBox.Show(ex.Message);//より具体的なエラーを出力

            }




            //P286以降を参考にする（ファイル名:setting.xml）

            //ファイルが存在するか？
            //if (File.Exists("setting.xml")) {
            //    try {

            //        using (var reader = XmlReader.Create("setting.xml")) {
            //            var serializer = new XmlSerializer(typeof(Settings));
            //            //settings = serializer.Deserialize(reader) as Settings;P109
            //            if (serializer.Deserialize(reader) is Settings loadedSettings) {
            //                 = loadedSettings;


            //                //背景色設定
            //                //[検索]　C# 整数からARGBに変換
            //                BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
            //            }
            //        }

            //        }
            //        catch (Exception ex) {
            //            tsslbMessage.Text = "設定ファイル読み込みエラー";
            //            MessageBox.Show(ex.Message);//より具体的なエラーを出力
            //        }
            //    } else {
            //        tsslbMessage.Text = "設定ファイルがありません";
            //    }
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void InputItemsUpdate() {
            if (dgvRecords.CurrentRow is null || !dgvRecords.CurrentRow.Selected)
                ImputltemsAllClear();
        }

        //修正
        private void btModifyRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }


            int sel = dgvRecords.CurrentRow.Index;
            _carreports[sel].Date = dtpDate.Value;
            _carreports[sel].Author = cbAuthor.Text.Trim();
            _carreports[sel].Maker = GetRadioButtonMaker();
            _carreports[sel].CarName = cbCarName.Text.Trim();
            _carreports[sel].Report = tbReport.Text;
            _carreports[sel].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh();//データグリッドビューの更新
            tsslbMessage.Text = "レポートを修正しました";
            _repository.Update()
        }

        //選択・削除
        
            
        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null) ||
                    (!dgvRecords.CurrentRow.Selected)) return;

            //削除したいインデックスを指定してリストから削除
            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport) {
                tsslbMessage.Text = "削除するレポートを選択してください";
                return;
            }
           // _carreports.Remove(carReport);
           // ReloadCarReports();


            //ImputltemsAllClear();
           // dgvRecords.Refresh();//データグリッドビューの更新

            InputItemsUpdate();//データグリッドビューを更新したら呼ぶメソッド

            try {
                //idを使ってDBから1件削除する
                _repository.Delete(carReport.Id);

                ReloadCarReports();
                ClearInput();
                //tsslMessage.Text = "商品を削除しました。";
            }
            catch (Exception ex) {
                ShowError("削除エラー", ex);
            }
        }
        

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;

            //一覧選択時の表示
            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate();
        }

        //終了
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
            //this.Close();
        }

        //色設定
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            //cdColor = new ColorDialog();
            if (cdColor.ShowDialog() == DialogResult.OK) {
                //Color selectedColor = cdColor.Color;
                BackColor = cdColor.Color;

                //変更されtライロの情報を保存
                Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();
            }
        }


        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            //P284以降を参考にする
            //using (var writer = XmlWriter.Create("setting.Xml")) {
            //    var serializer = new XmlSerializer(Settings.Instance.GetType());
            //    serializer.Serialize(writer,Settings.Instance);
            //}
            Settings.Instance.Save();
        }

       

       

        private void ClearInput() {
            tbReport.Clear();
        }


       
        //ファイルオープン処理
       
        
        private void ShowError(string title, Exception ex) {
            tsslbMessage.Text = title;
            MessageBox.Show(
                ex.Message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        //SQLiteから全レポートを読み直す
        private void ReloadCarReports() {

            _carreports.Clear();

            cbAuthor.Items.Clear();
            cbCarName.Items.Clear();

            foreach (var carReport in _repository.GetAll()) {
                _carreports.Add(carReport);

                SetCbAuthor(carReport.Author);
                SetCbCarName(carReport.CarName);
            }
            dgvRecords.ClearSelection();

        }

        
    }

}
