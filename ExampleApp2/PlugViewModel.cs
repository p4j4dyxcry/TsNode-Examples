﻿using TsNode.Interface;
using TsNode.Preset.ViewModels;
using TsOperationHistory;

namespace WpfApp1
{
    public class PlugViewModel : PresentPlugViewModel
    {
        private IOperationController _operationController;
        public PlugViewModel(IOperationController controller)
        {
            _operationController = controller;
        }

        public override IConnectionDataContext StartConnectionOverride()
        {
            return new ConnectionViewModel(_operationController);
        }
    }

    public class PlugViewModel2 : PlugViewModel
    {
        public PlugViewModel2(IOperationController controller) : base(controller)
        {
        }
    }

    public class PlugViewModel3 : PlugViewModel
    {
        public int Data { get; set; }

        public PlugViewModel3(IOperationController controller) : base(controller)
        {
        }
    }
}