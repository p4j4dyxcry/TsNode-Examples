﻿﻿using TsNode.Interface;

  namespace Example_Node_Size_Changed
{
    public class MainWindowViewModel
    {
        public INodeDataContext[] Nodes { get; } = 
        {
            new GripNodeVm()
            {
                X = 50,
                Y = 50,
                H = 50,
                W = 50,
            }
        };
    }
}