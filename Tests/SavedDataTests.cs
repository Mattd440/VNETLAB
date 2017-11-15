using System;
using NUnit.Framework;

using NetworkConfigurator.Model;
using NetworkConfigurator.DataManager;
namespace NetworkConfigurator.Tests
{
    [TestFixture]
    public class SavedDataTests
    {
        PeopleContext context = new DataManager.PeopleContext();
      

        [Test]
        public void GetSwitchByIDReturnsCorrectID()
        {
            
            var switchName = "sw1234";
            var actualSwitchID = context.getSwitchID(switchName);
            var expectedSwitchID = 1;

            Assert.AreEqual(expectedSwitchID,actualSwitchID);
        }

        [Test]
        public void GetNetworkIDReturnsCorrectID()
        {
            
            var netName = "net1212";
            var actualNetID = context.getSwitchID(netName);
            var expectedNetID = 41;

            Assert.AreEqual(expectedNetID, actualNetID);
        }

        [Test]
        public void GetNetworkHasCorrectNumberofHosts()
        {

            var savedNetwork = SavedDataManager.GetNetwork(context, 41);
            var host = savedNetwork.Hosts;
            var hostCount = 0;
            var expectedHostCount = 1;
            foreach(var h in host){
                hostCount += 1;
            }
            Assert.AreEqual(expectedHostCount, hostCount);
        }

        [Test]
        public void GetNetworkHasCorrectNumberofSwitchs()
        {

            var savedNetwork = SavedDataManager.GetNetwork(context, 41);
            var netSwitchs = savedNetwork.Switchs;
            var switchCount = 0;
            var expectedSwitchCount = 1;
            foreach (var h in netSwitchs)
            {
                switchCount += 1;
            }
            Assert.AreEqual(expectedSwitchCount, switchCount);
        }

        [Test]
        public void HostConstructorCreatesHost()
        {
            Host host = null;

            host = new Host("host123", "192.12.12.12");

           
            Assert.IsNotNull(host);
        }

        [Test]
        public void SwitchConstructorCreatesSwitch()
        {
            Switch sw = null;

            sw = new Switch("host123", "192.12.12.12",19);


            Assert.IsNotNull(sw);
        }

        [Test]
        public void NetworkConstructorCreatesNetwork()
        {
            Network network = null;

            network = new Network("net123");


            Assert.IsNotNull(network);
        }

        [Test]
        public void SavedViewModelConstructorCreatesSavedViewModel()
        {
            SavedViewModel svm = null;
            svm = new SavedViewModel(SavedDataTestsSetup.Network);
            Assert.IsNotNull(svm);
        }

        [Test]
        public void AddingHostsToSavedViewModelAddsHosts()
        {
            SavedViewModel svm = null;
            svm = new SavedViewModel(SavedDataTestsSetup.Network);
            svm.Hosts = SavedDataTestsSetup.Hosts;

            Assert.IsNotNull(svm.Hosts);
            Assert.IsNotEmpty(svm.Hosts);
        }

        [Test]
        public void AddingSwitchsToSavedViewModelAddsSwitchs()
        {
            SavedViewModel svm = null;
            svm = new SavedViewModel(SavedDataTestsSetup.Network);
            svm.Switchs = SavedDataTestsSetup.Switchs;

            Assert.IsNotNull(svm.Switchs);
            Assert.IsNotEmpty(svm.Switchs);
        }


    }
}

public static class SavedDataTestsSetup
{
    public static Network Network {
        get{
            return new Network("net123");
        }
    }


    public static Host[] Hosts
    {
            get
            {
                return new Host[]{
                    new Host("host1","192.168.0.2"),
                    new Host("host2", "192.168.0.3")
                };
            }
    }

        public static Switch[] Switchs
{
    get
    {
        return new Switch[]{
                    new Switch("switch1","192.143.12.12",10),
                    new Switch("switch2","192.143.12.13",10),
                    new Switch("switch3","192.143.12.13",10),
                };
    }
}

public static Network[] Networks
{
        get{
            return new Network[]
        {
                    new Network("net1"),
                    new Network("net2"),
                    new Network("net3"),
                    new Network("net4")
        };

        }
}



}