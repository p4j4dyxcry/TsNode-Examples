using TsNode.Preset.ViewModels;

namespace Example_Node_Size_Changed
{
    public class GripNodeVm : PresetNodeViewModel
    {
        private double _w;

        public double W
        {
            get => _w;
            set => RaisePropertyChangedIfSet(ref _w, value);
        }

        private double _h;

        public double H
        {
            get => _h;
            set => RaisePropertyChangedIfSet(ref _h, value);
        }

        public GripNodeVm()
        {
        }
    }
}