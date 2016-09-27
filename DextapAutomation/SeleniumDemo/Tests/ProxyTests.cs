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
        private static string client = DataParser.Getclient();

        [Category("Regression")]
        [Category("WorkStride")]
        
        [Test]
        public void WS_1062()
        {
            if (!DataParser.ReturnExecution("WS_1062"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1062.xml";
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
                _file = "Resources\\" + client + "\\TestsData\\WS_1063.xml";
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
        [Category("Regression")]
        [Category("WorkStride")]

        [Test]
        public void WS_1064()
        {
            if (!DataParser.ReturnExecution("WS_1064"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1064.xml";
                username = ProxyData.GetProxyUserName(_file);
                string username2 = ProxyData.GetProxySecondUserName(_file), preferedName = RegisterData.GetRegisterPreferedName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                Assert.IsTrue(home.IsAdmLnkPresent(), "Admin link is present");
                ProxyHomePage adminPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username2);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username2, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                Assert.IsFalse(home.IsAdmLnkPresent(), "Admin link is present");
                adminPage = home.ExitProxy();
                Assert.IsTrue(adminPage.IsAdminLoginUsernameLevel(preferedName), "You are not in the login leveled like support,admin or proxy");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Test]
        public void Proxy_TestSearch_WS_1210()
        {
            if (!DataParser.ReturnExecution("WS_1210"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1210.xml";
                string username1 = ProxyData.GetProxySecondUserName(_file),
                    username = ProxyData.GetProxyUserName(_file),
                    username2 = ProxyData.GetProxyThirdUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username + " Ahsing", home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                home = home.ExitProxy().EnterUserName(username1).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + "Aaron " + username1, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                home = home.ClosePopUp().ExitProxy().EnterUserName(username2).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username2, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }


        [Category("Regression")]
        [Category("Sungard")]

        [Test]
        public void Proxy_StandardFunctionality_WS_1062()
        {
            if (!DataParser.ReturnExecution("WS_1062"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1062.xml";
                username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }


    }
}
