using System.Windows;
using System.Windows.Media;
using TsNode.Preset;
using TsNode.Preset.Models;

namespace Example_NodeEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var nodeEngine = new NodeEngine();
            
            // 組み込み用のViewModelを生成する。
            // ViewModelの実装などをすべて自前で行いたい場合は別のサンプルなどを参照してください。
            DataContext = nodeEngine.BuildViewModel();
            
            //新規ノードの追加
            var root = nodeEngine.GetOrCreateNode("Root")
                .SetColor(Colors.IndianRed)// ヘッダカラーを設定する
                .AddInputPlug("Plug1", 0); // int型の入力プラグを追加する
            
            // NodeEngine.Connect()を使ってノードを接続
            // (存在しないノードは自動的に生成される。)
            nodeEngine.Connect("Root","Child1");
            nodeEngine.Connect("Root","Child2");
            nodeEngine.Connect("Root","Child3");
            nodeEngine.Connect("Child2","Child4");
            nodeEngine.Connect("Child2","Child5");
            nodeEngine.Connect("Child3","Child6");
            nodeEngine.Connect("Child3","Child10");
            nodeEngine.Connect("Child4","Child7");
            nodeEngine.Connect("Child7","Child8");
            nodeEngine.Connect("Child7","Child9");
            
            // 自動整列を行う ※自動配置されている場合は破棄される
            nodeEngine.AutoArrange();

            // ルートノードだけ座標を変える。
            root.SetPos(-50, -200);
            
            // ノード全体がViewに収める
            NetworkView.FitToSelectionNode(0);
            
            // NodeEngineで作成したネットワークをファイルとして出力する
            nodeEngine.SerializeToFile("output.json",SerializeFormat.Json);
        }
    }
}