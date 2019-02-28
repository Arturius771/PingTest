using System;

namespace PingTest {
    class static LastFailTime {
        string lastFailTimeGetSetString = " start Last Fail Time";
        public string lastFailTimeGetSet {
            get {
                return (lastFailTimeGetSetString);
            }
            set {
                lastFailTimeGetSetString = value;
            }
        }
    }
}
