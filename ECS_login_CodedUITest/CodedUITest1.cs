using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls; // need this for creating HtmlDocument
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace ECS_login_CodedUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            //this.UIMap.ECS_login_RecordedMethod1();
            ecs_login_test();
        }

        public static void ecs_login_test()
        {
            BrowserWindow browser = BrowserWindow.Launch("https://www.ecs.csus.edu/index.php?content=ecs_portal");
            browser.Maximized = true;

            HtmlDocument doc = new HtmlDocument(browser);
            doc.FilterProperties[HtmlDocument.PropertyNames.Title] = "ECS Portal | Sacramento State | College of Engineering & Computer Science | Sacra" +
                "mento State";

            HtmlEdit loginTxt = new HtmlEdit(doc);
            loginTxt.SearchProperties[HtmlEdit.PropertyNames.Name] = "username";
            Keyboard.SendKeys(loginTxt, "Type your ECS username here");

            HtmlEdit passwordTxt = new HtmlEdit(doc);
            passwordTxt.SearchProperties[HtmlEdit.PropertyNames.Name] = "passwd";
            Keyboard.SendKeys(passwordTxt, "Type your ECS password here");

            HtmlInputButton loginButton = new HtmlInputButton(doc);
            loginButton.SearchProperties[HtmlButton.PropertyNames.Name] = "/portal_login";
            Mouse.Click(loginButton);

            Playback.Wait(10000);
            browser.Close();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
