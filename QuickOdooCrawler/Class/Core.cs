using CefSharp;
using CefSharp.WinForms;
using Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickOdooCrawler
{
    class Core
    {
        public readonly string SettingPath = Environment.CurrentDirectory + "\\Setting.ini";
        public const string CommandToken = "8032";
        public const char SplitSymbol = ';';
        private readonly ChromiumWebBrowser browser;
        private readonly Action<bool> isBusyStatusChange;
        //Dictionary<标题, Tuple<对应网页, 搜索标签[], Tuple<排序标签, 升降, 爬取个数>, Tuple<HTML标签, 内部文字, 位置, 标签换名>[]>[]>
        public readonly Dictionary<string, Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]>[]> SearchListInfoFlow = new Dictionary<string, Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]>[]>();
        //Dictionary<标题, Tuple<搜索标签[], Tuple<排序标签, 升降>, 相同标签[], Tuple<排序标签, 升降>, Tuple<HTML标签, 内部文字, 位置, 标签换名>[]>>
        //public readonly Dictionary<string, Tuple<string, string[], Tuple<string, string>, Tuple<string, string, string, string>[]>[]> SearchListCompare = new Dictionary<string, Tuple<string, string[], Tuple<string, string>, Tuple<string, string, string, string>[]>[]>();

        public Core(ChromiumWebBrowser Browser, Action<bool> IsBusyStatusChange)
        {
            var total = (List<object>)JsonParser.FromJson(File.ReadAllText(SettingPath, Encoding.GetEncoding("gb2312"))).ElementAt(0).Value;
            {
                List<Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]>> container = new List<Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]>>();
                string website = null;
                var Searchlabels = new List<string>();
                Tuple<string, string, int> SearchSortLabel = null;
                var CrawlerLabels = new List<Tuple<string, string, string, string>>();
                var Index = 0;
                foreach (var group in (Dictionary<string, object>)total.ElementAt(0))
                {
                    container.Clear();
                    foreach (var InfoSingle0 in (ICollection<object>)group.Value)
                    {
                        Searchlabels.Clear();
                        CrawlerLabels.Clear();
                        Index = 0;
                        foreach (var InfoSingle1 in (ICollection<object>)InfoSingle0)
                        {
                            switch (Index++)
                            {
                                case 0:
                                    website = InfoSingle1.ToString();
                                    break;
                                case 1:
                                    {
                                        var InfoSingleElements = ((List<object>)InfoSingle1);
                                        foreach (var InfoSingleElementsString in InfoSingleElements)
                                        {
                                            Searchlabels.Add(InfoSingleElementsString.ToString().Trim());
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        var InfoSingleElements = ((List<object>)InfoSingle1);
                                        SearchSortLabel = new Tuple<string, string, int>(InfoSingleElements[0].ToString().Trim(), InfoSingleElements[1].ToString().Trim(), Convert.ToInt32(InfoSingleElements[2].ToString()));
                                    }
                                    break;
                                default:
                                    {
                                        var InfoSingleElements = ((List<object>)InfoSingle1);
                                        CrawlerLabels.Add(new Tuple<string, string, string, string>(InfoSingleElements[0].ToString().Trim(), InfoSingleElements[1].ToString().Trim(), InfoSingleElements[2].ToString().Trim(), InfoSingleElements[3].ToString().Trim()));
                                    }
                                    break;
                            }
                        }
                        container.Add(new Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]>(website, Searchlabels.ToArray(), SearchSortLabel, CrawlerLabels.ToArray()));
                    }
                    SearchListInfoFlow.Add(group.Key.Trim(), container.ToArray());
                }
            }
            isBusyStatusChange = IsBusyStatusChange;
            browser = Browser;
            browser.LoadingStateChanged += Browser_LoadingStateChanged;

            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private Tuple<string, string, Dictionary<string, string>> TextToJson(string Text)
        {
            string Command = null, CommandType = null;
            Dictionary<string, string> Result = new Dictionary<string, string>();
            string[] temp;
            string label, value;
            foreach (var i in Text.Split(SplitSymbol).Reverse())
            {
                try
                {
                    temp = i.Split(':');
                    label = temp[0].Trim();
                    value = temp[1].Trim();
                    if (label == CommandToken)
                    {
                        CommandType = label;
                        Command = value;
                    }
                    else
                    {
                        DictionaryAdd(Result, temp[0].Trim(), temp[1].Trim());
                    }
                }
                catch { }
            }
            return new Tuple<string, string, Dictionary<string, string>>(CommandType, Command, Result);
        }

        private Dictionary<string, string> DictionaryAdd(Dictionary<string, string> Json, string Label, string Value)
        {
            Value = Value.Replace("&nbsp;", "").Trim();
            if (Value.Length > 0)
            {
                if (Json.ContainsKey(Label))
                {
                    Json.Remove(Label);
                }
                Json.Add(Label, Value);
            }
            else
            {
                /*
                if(Json.ContainsKey("注意")== false)
                {
                    Json.Add("注意", "");
                }
                Json["注意"] += string.Format(" !{0}为空", Label).TrimStart();
                */
            }
            return Json;
        }

        private string JsontoText(Dictionary<string, string> Json)
        {
            string Text = "";
            foreach (var i in Json)
            {
                Text = string.Format("{0}:{1}{2}  {3}", i.Key, i.Value, SplitSymbol, Text);
            }
            Text = Text.TrimEnd(' ');
            Text = Text.TrimEnd(SplitSymbol);
            return Text.ToString();
        }

        public void Run(string Info, Action<string> Result)
        {
            var InfoJsonTemp = TextToJson(Info);
            switch (InfoJsonTemp.Item1)
            {
                case CommandToken:
                    //爬出当前设备信息
                    if (SearchListInfoFlow[InfoJsonTemp.Item2].Length > 0)
                    {
                        var Index = 0;
                        Action<string> ActionTemp = null;
                        ActionTemp = new Action<string>((value) =>
                        {
                            Result(value);
                            if (++Index < SearchListInfoFlow[InfoJsonTemp.Item2].Length) {
                                CoreCrawler(TextToJson(value).Item3, SearchListInfoFlow[InfoJsonTemp.Item2][Index], ActionTemp, true);
                            }
                        });
                        CoreCrawler(InfoJsonTemp.Item3, SearchListInfoFlow[InfoJsonTemp.Item2][Index], ActionTemp, false);
                    }
                    break;
            }
            Timer_Tick(null, null);
        }

        public void CoreCrawler(Dictionary<string, string> InfoValues, Tuple<string, string[], Tuple<string, string, int>, Tuple<string, string, string, string>[]> CrawlItems, Action<string> Result, bool JumpQueue)
        {
            var Delay = new Action<int>((delay) =>
            {
                DateTime TimeStamp = DateTime.Now;
                while ((DateTime.Now - TimeStamp).TotalMilliseconds < delay)
                {
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
            });
            try
            {
                var CrawlCompareItemLabelsAndValues = new Dictionary<string, string>();
                foreach(var i in CrawlItems.Item2)
                {
                    if (InfoValues.ContainsKey(i))
                    {
                        CrawlCompareItemLabelsAndValues.Add(i, InfoValues[i]);
                        InfoValues.Remove(i);
                    }
                }
                var ReturnCount = 0;
                var SearchPageIndex = 0;
                var SearchPageTempIndex = 0;
                var SearchPageToEnd = false;
                var JSCheckDataLoaded = "(function(){let e = document.getElementsByClassName('o_loading'); return e.length > 0 && e[0].style.display == 'none'})()";
                var InsertItem = new Tuple<int, string, Func<int>>[] {
                new Tuple<int, string, Func<int>>(  //开始页面
                    50,
                    null, 
                    new Func<int>(() => {
                        //Main Page
                        BrowserLoad(CrawlItems.Item1);
                        return 1;
                    }
                )),
                new Tuple<int, string, Func<int>>(  //清理搜索
                    50,
                    JSCheckDataLoaded,
                    new Func<int>(() => {
                        //Main Page
                       return (bool)BrowserExeJS("(function(){let e=document.getElementsByClassName('o_facet_remove');switch(e.length){case 0:return true; case 1:e[0].click();return true;default:e[0].click();return false;}})()") ? 2 : 1;
                    }
                )),
                new Tuple<int, string, Func<int>>( //输入搜索内容
                    50,
                    JSCheckDataLoaded,
                    new Func<int>(() =>
                    {
                        //var index = 0;
                        foreach(var LabelsAndValues in CrawlCompareItemLabelsAndValues){
                            //Input S/N
                            BrowserExeJS("(function(){" +
                                "function fireKeyEvent(a,b,c){var d=a.ownerDocument,win=d.defaultView||d.parentWindow,evtObj;if(d.createEvent){if(win.KeyEvent){evtObj=d.createEvent('KeyEvents');evtObj.initKeyEvent(b,true,true,win,false,false,false,false,c,0)}else{evtObj=d.createEvent('UIEvents');Object.defineProperty(evtObj,'keyCode',{get:function(){return this.keyCodeVal}});Object.defineProperty(evtObj,'which',{get:function(){return this.keyCodeVal}});evtObj.initUIEvent(b,true,true,win,1);evtObj.keyCodeVal=c}a.dispatchEvent(evtObj)}else if(d.createEventObject){evtObj=d.createEventObject();evtObj.keyCode=c;a.fireEvent('on'+b,evtObj)}}" +
                                "let e0=document.getElementsByClassName('o_searchview_input')[0];" +
                                "e0.value='" + LabelsAndValues.Value + "';" +
                                "fireKeyEvent(e0,'keyup',0);" +
                                "let index=[...document.getElementsByClassName('o_searchview_autocomplete')[0].children].map(e=>(e.lastChild.children[0].innerText)).indexOf('" + LabelsAndValues.Key + "');" +
                                "for(let i=0;i<index;i++){" +
                                    "fireKeyEvent(e0,'keydown',40);" +
                                "}" +
                                "fireKeyEvent(e0,'keydown',13);" +
                                "})()");
                        }
                        return 3;
                    }
                )),
                new Tuple<int, string, Func<int>>( //点击,并达到 Nth 页()
                   50,
                   JSCheckDataLoaded,
                    new Func<int>(() => {
                        if(SearchPageTempIndex == 0 && (bool)BrowserExeJS("(function(){return document.getElementsByClassName('o_list_view')[0].style.display == 'none'})()"))
                        {
                            return int.MaxValue;
                        }
                        //Select S/N Search
                        if(SearchPageTempIndex++ != SearchPageIndex)
                        {
                            BrowserExeJS("(function(){document.getElementsByClassName('o_pager_next')[0].click();})()");
                            return 3;
                        }
                        SearchPageTempIndex = 0;
                        return 4;
                })),
                new Tuple<int, string, Func<int>>( //排序
                    50,
                    JSCheckDataLoaded,
                    new Func<int>(() => {
                        return (bool)BrowserExeJS("(function(){let e = [...document.getElementsByClassName('o_column_sortable')].filter(e=>e.innerText.trim()=='" + CrawlItems.Item3.Item1 + "')[0];if(!e.classList.contains('" + CrawlItems.Item3.Item2 + "')){e.click();return e.classList.contains('" + CrawlItems.Item3.Item2 + "');}else{return true;}})()")?5:4;
                })),
                new Tuple<int, string, Func<int>>( //点击页面中的第一个文档
                    100,
                    JSCheckDataLoaded,
                    new Func<int>(() => {
                        //最后一页?
                        SearchPageToEnd = (bool)BrowserExeJS("(function(){" +
                            "let result = document.getElementsByClassName('o_pager_value')[0].innerText.indexOf('-' + document.getElementsByClassName('o_pager_limit')[0].innerText) != -1;" +
                            "document.getElementsByTagName('tbody')[0].children[0].click();" + //打开文档
                            "return result;" +
                            "})()");
                        return 6;
                })),
                new Tuple<int, string, Func<int>>( //文档信息爬取
                    50,
                    JSCheckDataLoaded,
                    new Func<int>(() => {
                        // + Next
                        // - Before
                        // > Child
                        // < Parent
                        string inputs = "[";
                        foreach(var i in CrawlItems.Item4){
                            inputs += string.Format("['{0}','{1}','{2}'],", i.Item1, i.Item2, i.Item3);
                        }
                        inputs = inputs.TrimEnd(',') + "]";
                        string[] results = ((string)BrowserExeJS("(function(){" +
                            "let results=[];" +
                            //Extra Information
                            "function Extract(e0,e1,e2){let e=[...document.getElementsByTagName(e0)].filter(ele=>ele.innerText==e1);if(e.length==0){return''}else{e=e[0]}e2.split('').forEach(fin=>{switch(fin){case'+':e=e.nextElementSibling;break;case'-':e=e.previousElementSibling;break;case'>':e=e.firstElementChild;break;case'<':e=e.parentElement;break}});return e.innerText}" +
                            "let inputs=" + inputs + ";" +
                            "for(let input of inputs){results.push(Extract(input[0],input[1],input[2]))}" +
                            //Next Page
                            "let nextPageAvaible = document.getElementsByClassName('o_pager_value')[0].innerText != document.getElementsByClassName('o_pager_limit')[0].innerText;" +
                            "if(nextPageAvaible){document.getElementsByClassName('o_pager_next')[0].click();}" +
                            "results.push(nextPageAvaible);" + 
                            //Return Result
                            "return results.join(';')})()")).Split(';');
                        var temp = new Dictionary<string,string>(InfoValues);
                        for (int i =  CrawlItems.Item4.Length - 1; i >= 0; i--)
                        {
                            DictionaryAdd(temp, CrawlItems.Item4[i].Item4,results[i]);
                        }
                        Result(JsontoText(temp));
                        ReturnCount++;
                        //最大爬取个数
                        if(CrawlItems.Item3.Item3 != -1 && ReturnCount >= CrawlItems.Item3.Item3)
                        {
                            return int.MaxValue;
                        }
                        //最后一页
                        if(!Convert.ToBoolean(results[results.Length - 1])){
                            if (SearchPageToEnd) {
                                return int.MaxValue;
                            }
                            else {
                                SearchPageIndex++;
                                return 0;
                            }
                        }
                        else {
                            return 6;
                        }
                    }
                )) };
                if (JumpQueue && TaskList.Count > 0){
                    TaskList.Insert(1, InsertItem);
                }
                else{
                    TaskList.Add(InsertItem);
                }
            }
            catch(Exception E)
            {
                Result(E.Message);
            }
        }

        private bool BrowserIsBusy = false;
        private bool TaskIsBusy = false;

        private readonly Timer timer = new Timer();
        //Tuple<下一个任务索引, 执行当前任务条件, 方法<Timer Interval>>
        private List<Tuple<int, string, Func<int>>[]> TaskList = new List<Tuple<int, string, Func<int>>[]>();

        private int TaskIndex = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (TaskList.Count > 0)
            {
                if (TaskIsBusy != true)
                {
                    isBusyStatusChange(true);
                    TaskIsBusy = true;
                }
                var Task = TaskList[0][TaskIndex];
                try
                {
                    if (BrowserIsBusy == false && (Task.Item2 == null || (bool)BrowserExeJS(Task.Item2)))
                    {
                        TaskIndex = Task.Item3();
                        timer.Interval = Task.Item1;
                        if (TaskIndex >= TaskList[0].Length)
                        {
                            TaskList.RemoveAt(0);
                            TaskIndex = 0;
                        }
                    }
                }
                catch { }
            }
            if (TaskList.Count == 0 && TaskIsBusy != false)
            {
                isBusyStatusChange(false);
                TaskIsBusy = false;
            }
            timer.Start();
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                BrowserIsBusy = false;
            }
        }

        private void BrowserLoad(string URL)
        {
            BrowserIsBusy = true;
            browser.Load(URL);
        }

        public void EndTask()
        {
            TaskList.Clear();
            TaskIndex = 0;
            Timer_Tick(null, null);
        }

        private object BrowserExeJS(string JS)
        {
            return browser.EvaluateScriptAsync(JS).Result.Result;
        }
    }
}
