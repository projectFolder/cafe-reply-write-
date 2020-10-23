using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Class;
using Keys = OpenQA.Selenium.Keys;

namespace aiswing_product.Class
{
    public class naverSelenium
    {

        MainForm main;
        public IWebDriver driver;
        private ChromeDriverService driverS;
        private ChromeOptions driver0;
        String AccountId = "";
        public List<String> _lst;

        #region [ Construct ]
        public naverSelenium(MainForm main, String AccountId, List<String> _lst)
        {
            this.main = main;
            this.AccountId = AccountId;
            this._lst = _lst;
        }

        #endregion

        #region [ open Chrome ]

        public bool openChrome(int idx, String id, String pw)
        {

            do
            {
                try
                {
                    driverS = ChromeDriverService.CreateDefaultService();
                    driverS.HideCommandPromptWindow = true;
                    driver0 = new ChromeOptions();

                    driver0.AddArgument("--incognito");
                    driver0.AddArgument("--window-position=0,0");
                    driver0.AddExcludedArgument("enable-automation");
                    driver0.AddAdditionalCapability("useAutomationExtension", false);
                    driver0.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36");
                    driver0.AddArguments("--window-size=1000,1000");
                    driver0.AddArguments("--user-data-dir=C:\\Users\\" + GetUserName() + "\\AppData\\Local\\Google\\Chrome\\User Data\\");
                    driver = new ChromeDriver(driverS, driver0);
                    break;
                }
                catch (WebDriverException ex)
                {
                    MessageBox.Show("크롬이 실행중인 상태에서 프로그램 실행이 불가능합니다. 크롬을 모두 닫고 다시 시도해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } while (true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("https://www.naver.com/");
            driver.FindElement(By.XPath("//*[@id=\"account\"]/a")).Click();

            waitElement();
            DelayOp.Delay(1500);
            IJavaScriptExecutor jsx = (IJavaScriptExecutor)driver;
            if (driver.Url.Contains("https://nid.naver.com/nidlogin.login?") && driver.FindElement(By.XPath("/html")).Displayed)
            {
                driver.FindElement(By.XPath("//*[@id=\"label_ip_on\"]")).Click();

                driver.FindElement(By.XPath("//*[@id=\"id\"]")).Click();
                jsx.ExecuteScript("document.getElementById('id').setAttribute('value', '" + id + "')");
                DelayOp.Delay(DelayOp.GetRandomNumber(2, 3) * 1000);

                jsx.ExecuteScript("document.getElementById('pw').setAttribute('value', '" + pw + "')");
                DelayOp.Delay(DelayOp.GetRandomNumber(2, 3) * 1000);

                driver.FindElement(By.XPath("//*[@id=\"log.login\"]")).Click();

                #region [ Login Process ]

                ListView customListView = main.customListView2;

                try
                {
                    waitElement();
                    if (driver.PageSource.Contains("예전에 사용했던 연락처라면"))
                    {
                        main.display(AccountId + " 계정이 로그인에 성공하였습니다.");
                        return true;
                    }
                    else if (driver.PageSource.Contains("minime"))
                    {
                        main.display(AccountId + " 계정이 로그인에 성공하였습니다.");
                        return true;
                    }
                    else if (driver.PageSource.Contains("휴대 전화번호"))
                    {
                        main.display(AccountId + " 계정이 로그인에 성공하였습니다.");
                        return true;
                    }
                    else if (driver.PageSource.Contains("잘못 입력하셨습니다."))
                    {
                        main.display(AccountId + " 계정이 로그인에 실패하였습니다. - 비밀번호 오류");
                        return false;
                    }
                    else if (driver.PageSource.Contains("image_captcha"))
                    {
                        main.display(AccountId + " 계정이 로그인에 실패하였습니다. - 보안문자 발생");
                        return false;
                    }
                    else if (driver.PageSource.Contains("회원님의 아이디를 보호하고 있습니다."))
                    {
                        main.display(AccountId + " 계정이 로그인에 실패하였습니다. - 보호조치");
                        return false;
                    }
                    else if (driver.PageSource.Contains("대량생성 ID"))
                    {
                        main.display(AccountId + " 계정이 로그인에 실패하였습니다. - 대량생성");
                        return false;
                    }
                    else
                    {
                        main.display(AccountId + " 계정이 로그인에 실패하였습니다.");
                        return false;
                    }
                }
                catch (Exception e)
                {
                    main.display(AccountId + " 계정이 로그인에 실패하였습니다.");
                    return false;
                }

                #endregion

            }

            return false;

        }

        #endregion

        #region [ Cafe Write ]

        Random _rnd = new Random();

        public void cafeWrite(int cur, int total)
        {

            waitNavigate(main.customTextbox1.val);
            _lst.Add(main.customTextbox1.val);

            String _clubid = Regex.Split(Regex.Split(driver.PageSource, "var g_sClubId = \"")[1], "\"")[0];

            driver.SwitchTo().Frame("cafe_main");

            DelayOp.Delay(2500);

            IWebElement _elementTitle = null;
            IWebElement _elementSubject = null;

            do
            {
                String _num = _lst[0].Split('/')[_lst[0].Split('/').Length - 1];

                int _index = _rnd.Next(0, main.customListView1.Items.Count - 1);

                String _title = main.customListView1.Items[_index].SubItems[2].Text;
                String _subject = main.customListView1.Items[_index].SubItems[3].Text;

                try
                {
                    waitNavigate("https://cafe.naver.com/ca-fe/cafes/" + _clubid + "/articles/" + _num + "/reply");
                    DelayOp.Delay(1500);

                    _elementTitle = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/section/div/div[2]/div[1]/div[1]/div[2]/div/textarea"));
                    _elementSubject = driver.FindElement(By.XPath("//*[@id=\"SmartEditor\"]/div/div[1]/div/div[1]/div[2]/section/div[3]"));

                    _elementTitle.Clear();

                    inputKeys(_elementTitle, _title, 50, 250);

                    DelayOp.Delay(DelayOp.GetRandomNumber(int.Parse(main.customTextbox3.val), int.Parse(main.customTextbox4.val)) * 1024);

                    _elementSubject.Click();

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", _elementSubject);

                    Actions actionProvider = new Actions(driver);
                    actionProvider.KeyDown(Keys.Control).SendKeys("a").Build().Perform();
                    DelayOp.Delay(1500);

                    actionProvider.SendKeys(Keys.Delete).Build().Perform();
                    DelayOp.Delay(1500);

                    Clipboard.SetText(_subject);

                    new Actions(driver).KeyDown(Keys.Control).SendKeys("v").Build().Perform();

                    if (Clipboard.GetText().Equals(_subject))

                        DelayOp.Delay(DelayOp.GetRandomNumber(int.Parse(main.customTextbox3.val), int.Parse(main.customTextbox4.val)) * 1024);

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/section/div/div[1]/div/a")).Click();

                    DelayOp.Delay(2000);

                    try
                    {
                        String _val = driver.SwitchTo().Alert().Text;
                        driver.SwitchTo().Alert().Accept();
                        if (driver.SwitchTo().Alert().Text.Contains("등록 제한을 초과해"))
                            return;
                    }
                    catch (Exception ex)
                    {
                        if (driver.PageSource.Contains("/CafeMemberInfo.nhn?clubid="))
                        {
                            cur += 1;
                            main.display(AccountId + " 계정이 성공적으로 답글을 작성하였습니다. [" + cur + "/" + total + "]");
                            _lst.Add(driver.Url.ToString());
                        }
                        else
                        {
                            main.display(AccountId + " 계정이 답글작성에 실패하였습니다.");
                        }
                    }

                    if (cur >= total) break;

                }
                catch (Exception ex)
                {
                    _lst.RemoveAt(0);
                }

            } while (true);

            DelayOp.Delay(DelayOp.GetRandomNumber(int.Parse(main.customTextbox6.val), int.Parse(main.customTextbox5.val)) * 1024);

        }

        #endregion

        #region [ Selenium Method ]

        private void inputKeys(IWebElement element, String str, int delay1, int delay2)
        {
            char[] charArray = str.ToCharArray();
            foreach (char word in charArray)
            {
                element.SendKeys(word.ToString());
                DelayOp.Delay(DelayOp.GetRandomNumber(delay1, delay2));
            }
        }

        public Tuple<String, String> waitNavigate(String Url)
        {
            if (driver.Url.ToString() != Url)
            {
                driver.Navigate().GoToUrl(Url);
                DelayOp.Delay(1500);
                try
                {
                    driver.SwitchTo().Alert().Accept();
                }
                catch (Exception ex) { }
                waitElement();
            }

            return Tuple.Create(getCookies(), driver.PageSource);
        }

        public String getCookies()
        {
            int index = 0;
            do
            {
                try
                {
                    var info = driver.Manage().Cookies.AllCookies;
                    StringBuilder cinfo = new StringBuilder();
                    for (; index < info.Count - 1; index++)
                    {
                        cinfo.Append(info[index].Name);
                        cinfo.Append("=");
                        cinfo.Append(info[index].Value);
                        cinfo.Append("; ");
                    }
                    return cinfo.ToString();
                }
                catch (Exception e)
                {

                }
            } while (true);
        }

        public void waitElement()
        {
            try
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex) { }

            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElement.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            DelayOp.Delay(3000);

        }

        private String GetUserName()
        {
            String str = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] result = str.Split(new string[] { "\\" }, StringSplitOptions.None);
            return result[1];
        }

        #endregion

    }
}
