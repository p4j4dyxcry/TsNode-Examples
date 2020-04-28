using TsNode.Preset;
using TsOperationHistory;

namespace WpfApp1
{
    public class ConnectionViewModel : PresetConnectionViewModel
    {
        public int Name { get; set; }

        public ConnectionViewModel( IOperationController controller )
        {

        }
    }
}
