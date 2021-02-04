using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIXamarin.Data
{
    public interface INetworkConnection{
        bool isConnected { get; }
        void CheckNetworkConnection();
    }
}
