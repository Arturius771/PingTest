using System;

namespace PingTest {
    class LastFailTime {
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
