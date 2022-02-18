using BOTLIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;




namespace GermaniBot
{


    public partial class Form1 : Form
    {
        public struct S_ImageSearching
        {
            public string name;
            public int tolerance;
            public Point regionBegin;
            public Point regionEnd;
            public Bitmap[] imagesToFind;
        }

        public delegate void delegateUpdateRichTextBox(string text, RichTextBox richbox, Color color);
        public delegate void delegateUpdateLabelBox(string text, Label label);

        delegateUpdateRichTextBox DelegateUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
        delegateUpdateLabelBox DelegateUpdateLabelBox = new delegateUpdateLabelBox(SetLabelText);

        bool process;
        bool is_qwerty = false;
        bool is_azerty = true;

        int antistuck = 0;
        int antistuck_limit = 100;

        //Time Variable
        int hh;
        int mm;
        int ss;

        IntPtr gameHandle;

        BotUtilityNative bot = new BotUtilityNative();

        S_ImageSearching fishing_blob = new S_ImageSearching
        {
            name = "fishingBlob",
            tolerance = 100,
            regionBegin = new Point(1275, 680),
            regionEnd = new Point(1301, 721),
            imagesToFind = new Bitmap[] { Resource1.fishing_blob, Resource1.fishing_blob2 }
        };

        S_ImageSearching exclamPoint = new S_ImageSearching
        {
            name = "exclamPoint",
            tolerance = 20,
            regionBegin = new Point(1270, 620),
            regionEnd = new Point(1288, 666),
            imagesToFind = new Bitmap[] { Resource1.Exclam, Resource1.exclam2 }
        };

        S_ImageSearching combat_icon = new S_ImageSearching
        {
            name = "combat_mode",
            tolerance = 50,
            regionBegin = new Point(800, 1320),
            regionEnd = new Point(890, 1405),
            imagesToFind = new Bitmap[] { Resource1.combat_mode, Resource1.combat_mode2, Resource1.combat_mode3 }
        };

        S_ImageSearching harvest_icon = new S_ImageSearching
        {
            name = "harvest_mode",
            tolerance = 20,
            regionBegin = new Point(730, 1320),
            regionEnd = new Point(820, 1405),
            imagesToFind = new Bitmap[] { Resource1.harvest_icon, Resource1.harvest_icon2 }
        };

        S_ImageSearching nofish_message = new S_ImageSearching
        {
            name = "nofish_message",
            tolerance = 0,
            regionBegin = new Point(1119, 1043),
            regionEnd = new Point(1121, 1055),
            imagesToFind = new Bitmap[] { Resource1.nofish_message }
        };

        private bool debug = true;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            gameHandle = bot.GetGameHandle();

        }

        #region Testing
        private void Test()
        {
            ////bot.SetForgroundWindow(gameHandle);
            //TestWorker.RunWorkerAsync();
        }
        private void TestingWorker(object sender, DoWorkEventArgs e)
        {
           // delegateUpdateRichTextBox DelUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
            // MultiSearchImageInRegion(meleeIconUnit1);
        }
        #endregion

        private void Start_Button(object sender, EventArgs e)
        {
            //  backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
            process = true;

            if (bot.SetForgroundWindow(gameHandle))
            {
                SetConsoleText("************START*************", richTextBox, Color.Green);
                Thread.Sleep(500);
                timer1.Enabled = true;
                timer1.Start();

                //CheckFaction();

              
                backgroundWorker.RunWorkerAsync();
                SetConsoleText("************START2*************", richTextBox, Color.Green);

            }
            else
            {
                SetConsoleText("Game Not Detected", richTextBox, Color.Red);
            }
        }
        private void Stop_Button(object sender, EventArgs e)
        {
            richTextBox.Clear();
            SetConsoleText("Stoping", richTextBox, Color.Black);

            process = false;
            backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();
            

            button1.Enabled = true;
            SetConsoleText("Stoped", richTextBox, Color.Black);
        }
        public void PrintToConsole(string text)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, text, richTextBox, Color.Black);
        }
        public void PrintToConsoleWithColor(string text, Color color)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, text, richTextBox, color);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            int catchedFish = 0; 
            delegateUpdateRichTextBox DelUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
            delegateUpdateLabelBox DelUpdateLabelBox = new delegateUpdateLabelBox(SetLabelText);

        begin:

            antistuck = 0;
            bool isInHarvestMode = false;
            bool isFishing = false;
            bool can_drag = false;
            
            while (!backgroundWorker.CancellationPending && process)
            {
                antistuck = 0;
                while (!isInHarvestMode)
                {
                    if (MultiSearchAndClickInRegion(harvest_icon))
                    {
                        isInHarvestMode = false;
                        PrintToConsole("isInHarvestMode = false");

                        Point p =  new Point(bot.mousePosition.X + 20, bot.mousePosition.Y + 20);
                      bot.moveMouse(p, false);
                    }
                        
                    else if (MultiSearchImageInRegion(combat_icon))
                    {
                        isInHarvestMode = true;  
                        break;
                       
                    }
                   
                    antistuck++;
                    if (antistuck >= antistuck_limit)
                    {
                        antistuck = 0;
                        PrintToConsoleWithColor("-------ANTI STUCK -------", Color.Purple);
                        goto begin;
                    }
                    Thread.Sleep(500);
                }

                bot.sendKeysWait("e");
                Thread.Sleep(100);
                bot.sendKeysWait("e");
                Thread.Sleep(100);
                bot.sendKeysWait("e");
                Thread.Sleep(2000);
                antistuck = 0;
                while (!isFishing)
                {

                    if (MultiSearchImageInRegion(fishing_blob))
                    {
                        isFishing = true;
                        PrintToConsole("isFishing = true");
                    }

                    antistuck++;
                    if (antistuck >= antistuck_limit)
                    {
                        antistuck = 0;
                        PrintToConsoleWithColor("-------ANTI STUCK -------", Color.Purple);
                        goto begin;
                    }

                    Thread.Sleep(150);
                }
                antistuck = 0;

                while (!can_drag)
                {
                    
                    if (MultiSearchImageInRegion(exclamPoint))
                    {
                        can_drag = true;
                        PrintToConsole("can_drag = true");
                    }
                    antistuck++;
                    if (antistuck >= antistuck_limit)
                    {
                        antistuck = 0;
                        PrintToConsole("antistuck");
                        goto begin;
                    }
                    Thread.Sleep(150);
                }

                bot.sendKeysWait("e");
                Thread.Sleep(100);
                bot.sendKeysWait("e");
                Thread.Sleep(100);
                bot.sendKeysWait("e");
                catchedFish++;


                GamePlayed.BeginInvoke(DelegateUpdateLabelBox, catchedFish.ToString(), GamePlayed);

                can_drag = false;
                isFishing = false;

                Thread.Sleep(5000);
            }
        }
        
        
        public static void SetConsoleText(string t, RichTextBox richbox, Color color)
        {
            richbox.SelectionColor = color;
            richbox.AppendText("\n" + t);
            richbox.ScrollToCaret();
        }
        public static void SetLabelText(string t, Label label)
        {
            label.Text = t;
        }
        public bool MultiSearchAndClickInRegion(S_ImageSearching searchUi)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {

                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out location, searchUi.tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(location.X + searchUi.regionBegin.X, location.Y + searchUi.regionBegin.Y);
                    bot.moveMouse(newPos, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);
                }
            }
            return false;
        }
        public bool MultiSearchAndClickInRegion(S_ImageSearching searchUi, out Point location)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);

            Point temp_location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {

                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    bot.moveMouse(newPos, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    location = newPos;
                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);

                }


            }

            location = Point.Empty;
            return false;



        }
        public bool MultiSearchImageInRegion(S_ImageSearching searchUi, bool moveMouse = false)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point temp_location;
            Color c = screenshot.GetPixel(1, 1);


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {
                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    if (moveMouse)
                        bot.moveMouse(newPos, false);
                    //Thread.Sleep(500);
                    //bot.leftClick();


                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);

                    return true;
                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);
                }


            }


            return false;
        }
        public bool MultiSearchImageInRegion(S_ImageSearching searchUi, out Point globalLocation, out Point localLocation, bool moveMouse = false)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point temp_location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {
                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    Point localPos = new Point(temp_location.X, temp_location.Y);

                    if (moveMouse)
                        bot.moveMouse(newPos, false);

                    //Thread.Sleep(500);
                    //bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    globalLocation = newPos;
                    localLocation = localPos;
                    return true;
                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);

                }
            }

            globalLocation = Point.Empty;
            localLocation = Point.Empty;
            return false;
        }
        public bool MultiSearchAndClickAllScreen(Bitmap[] imagesToFind, int tolerance, string arrayName)
        {

            Thread.Sleep(500);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(bot.GetGameHandle());
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point location;

            for (int i = 0; i < imagesToFind.Length; i++)
            {

                Bitmap find = imagesToFind[i];

                PrintToConsole("Searching for " + arrayName + " " + i);

                if (bot.findImage(find, screenshot, out location, tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    bot.moveMouse(location, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, arrayName + " " + i + " Found", richTextBox, Color.Green);
                    return true;
                }
                else
                {
                    if (debug)
                    {
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + arrayName + " " + i + " not Found", richTextBox, Color.Red);

                    }

                }
            }
            return false;
        }
        public bool MultiSearchImageAllScreen(Bitmap[] imagesToFind, int tolerance, string ArrayName)
        {
            Thread.Sleep(500);
            Point location;

            for (int i = 0; i < imagesToFind.Length; i++)
            {
                Bitmap find = imagesToFind[i];
                Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(gameHandle);


                if (bot.findImage(find, screenshot, out location, tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(gameHandle));
                    // bot.moveMouse(location, false);
                    Thread.Sleep(500);
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image" + ArrayName + " " + i + " Found", richTextBox, Color.Green);

                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image" + ArrayName + " " + i + " not Found", richTextBox, Color.Red);

                }


            }
            return false;



        }
        public bool MultiSearchImageAllScreen(Bitmap[] imagesToFind, int tolerance, out Point location, string ArrayName)
        {
            Thread.Sleep(500);
            Point templocation;

            for (int i = 0; i < imagesToFind.Length; i++)
            {
                Bitmap find = imagesToFind[i];
                Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(gameHandle);
                PrintToConsole("Searching for " + ArrayName + " " + i);

                if (bot.findImage(find, screenshot, out templocation, tolerance))
                {
                    templocation.Offset(bot.GetWindowsUpperLetftCorner(gameHandle));
                    bot.moveMouse(templocation, false);
                    Thread.Sleep(500);
                    location = templocation;
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, " Image" + ArrayName + " " + i + " Found ! ", richTextBox, Color.Green);

                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, " Image" + ArrayName + " " + i + " not Found ! ", richTextBox, Color.Red);


                }


            }
            location = Point.Empty;
            return false;



        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {

            ss += 1;

            if (ss >= 60)
            {
                ss = 0;
                mm += 1;
            }
            if (mm >= 60)
            {
                mm = 0;
                hh += 1;
            }
            if (hh >= 24)
            {
                hh = 0;
            }

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }



            ElapsedTime.Text = time;




        }
        private void showStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aZERTYToolStripMenuItem.CheckOnClick = true;
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void aZERTYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (aZERTYToolStripMenuItem.Checked)
            {
                is_azerty = true;
                is_qwerty = false;
                qWERTYToolStripMenuItem.Checked = false;
            }
            else
            {
                is_azerty = false;
                is_qwerty = true;
                qWERTYToolStripMenuItem.Checked = true;
            }

        }
        private void qWERTYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (qWERTYToolStripMenuItem.Checked)
            {
                is_qwerty = true;
                is_azerty = false;
                aZERTYToolStripMenuItem.Checked = false;
            }
            else
            {
                is_qwerty = false;
                is_azerty = true;
                aZERTYToolStripMenuItem.Checked = true;
            }

        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Debug_CheckBox(object sender, EventArgs e)
        {
            debug = !debug;
            PrintToConsole("debug is " + debug);
        }






        //private void ScrollInLateralMenu()
        //{
        //    MultiSearchImage(ScrollButton, 20, out Point ScrollPoint, "ScrollButton");

        //    Point DownPoint = new Point(ScrollPoint.X, ScrollPoint.Y + 200);
        //    Point UpPoint = new Point(ScrollPoint.X, ScrollPoint.Y - 200);
        //    Size winsize = bot.GetWindowSize(gameHandle);

        //    float PositionOnScreenRatio = ((float)ScrollPoint.Y / (float)winsize.Height);

        //    if (PositionOnScreenRatio > 0.6)
        //    {
        //        bot.dragMouse(ScrollPoint, UpPoint, true);
        //    }

        //    if (PositionOnScreenRatio < 0.6)
        //    {
        //        bot.dragMouse(ScrollPoint, DownPoint, true);
        //    }
        //}


    }
}
