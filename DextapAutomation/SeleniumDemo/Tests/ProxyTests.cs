using System;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    class ProxyTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("WorkStride")]
        
        [Test]
        public void WS_1062()
        {
            if (!DataParser.ReturnExecution("WS_1062"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1062.xml";
                username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }

        [Category("Regression")]
        [Category("WorkStride")]
        
        [Test]
        public void WS_1063()
        {
            if (!DataParser.ReturnExecution("WS_1063"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1063.xml";
                username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                Assert.IsFalse(home.IsAdmLnkPresent(),"Admin link is present");
            }
        }
        
    }
}
