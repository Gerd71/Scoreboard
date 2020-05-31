using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Scoreboard
{

    public partial class ControlCenter : Form
    {
        Scoreboard scb;
        Boolean timerstarted = false;
        Boolean playershown = false;
        Boolean TDshown = false;
        Boolean FirstDownshown = false;
        Boolean BigHit = false;
        Boolean PlayVideo=false;
        Boolean first = true;
        string imagepath = "";
        string playerimagepath = "";
        string homelogopath = "";
        string guestlogopath = "";
        string bgcolor = "";
        string fontcolor = "";
        string videopath = "";
        System.Media.SoundPlayer ExamplePlayer = new System.Media.SoundPlayer();

        public ControlCenter()
        {
            try
            { 
            InitializeComponent();
            imagepath = getImagePath();
            playerimagepath = getPlayerImagePath();
            Screen[] screens = Screen.AllScreens;
            scb = new Scoreboard();
            if (screens.Length > 1)
            {
                scb.Location = screens[1].WorkingArea.Location;               

            }
            scb.WindowState = FormWindowState.Maximized;
            scb.Show();
            try
            {
                homelogopath = getHomeLogoPath();
                guestlogopath = getGuestLogoPath();
            }
            catch (Exception ex)
            {
                homelogopath = "Images.dummy.jpg";
                guestlogopath = "Images.dummy.jpg";
            }

            try
            {
                bgcolor = getBGColor();                
                scb.BackColor = System.Drawing.Color.FromName(bgcolor);
                
            }
            catch (Exception ex)
            {
                bgcolor = "LightGray";
               
            }

            try
            {
                fontcolor = getFontColor();
                scb.lbTextDown.ForeColor = System.Drawing.Color.FromName(fontcolor);
                scb.lbTextQuarter.ForeColor = System.Drawing.Color.FromName(fontcolor);
                scb.lbTime.ForeColor = System.Drawing.Color.FromName(fontcolor);
                scb.lbTextHome.ForeColor = System.Drawing.Color.FromName(fontcolor);
                scb.lbTextGuest.ForeColor = System.Drawing.Color.FromName(fontcolor);
                scb.lbTitle.ForeColor = System.Drawing.Color.FromName(fontcolor);
            }
            catch (Exception ex)
            {
               
                fontcolor = "White";
            }

            timer1.Tick += new EventHandler(_timer_Tick);
           
            FileStream imageStreamHome = new FileStream(homelogopath, FileMode.Open, FileAccess.Read);
            scb.pBHome.Image = System.Drawing.Image.FromStream(imageStreamHome);
            FileStream imageStreamGuest = new FileStream(guestlogopath, FileMode.Open, FileAccess.Read);
            scb.pBGuest.Image = System.Drawing.Image.FromStream(imageStreamGuest);
            }
            catch(Exception ex)
            { }

        }

        private string getVideoPath()
        {
            string path = "";
            StreamReader objstream = new StreamReader(".c:/temp/videopfad.txt");
            path = objstream.ReadLine();
            objstream.Close();
            objstream.Dispose();

            return path;
        }

        private string getImagePath()
        {
            string path = "";
            StreamReader objstream = new StreamReader("c:/temp/pfad.txt");
            path = objstream.ReadLine();
            return path;
        }


        private string getPlayerImagePath()
        {
            string path = "";
            StreamReader objstream = new StreamReader("c:/temp/pfadplayer.txt");
            path = objstream.ReadLine();
            return path;
        }
        
        private string getHomeLogoPath()
        {
            string path = "";
            StreamReader objstream = new StreamReader("c:/temp/homepfad.txt");
            path = objstream.ReadLine();
            return path;
        }

        private string getGuestLogoPath()
        {
            string path = "";
            StreamReader objstream = new StreamReader("c:/temp/guestpfad.txt");
            path = objstream.ReadLine();
            return path;
        }

        //private void btLaunchScoreboard_Click(object sender, EventArgs e)
        //{
        //    scb = new Scoreboard();
        //    scb.Show();
        //}

        private string getBGColor()
        {
            string color = "";
            StreamReader objstream = new StreamReader("c:/temp/bgcolor.txt");
            color = objstream.ReadLine();          
            return color;
        }

        private string getFontColor()
        {
            string color = "";
            StreamReader objstream = new StreamReader("c:/temp/fontcolor.txt");
            color = objstream.ReadLine();
            return color;
        }

        private void btStartStopTimer_Click(object sender, EventArgs e)
        {
            if (timerstarted == false)
            {
                timer1.Start();
                timerstarted = true;
                btStartStopTimer.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                timer1.Stop();
                timerstarted = false;
                btStartStopTimer.BackColor = System.Drawing.Color.Green;

            }

        }

        void _timer_Tick(object sender, EventArgs e)
        {
            TimeSpan tick = new TimeSpan(0, 0, 1);
            string timertext = lbTime.Text;
            DateTime timertime = Convert.ToDateTime("00:" + timertext);
            timertime = timertime.Subtract(tick);
            string minute = timertime.Minute.ToString();
            string second = timertime.Second.ToString();
            if (timertime.Minute < 10)
            {
                minute = "0" + timertime.Minute;
            }
            if (timertime.Second < 10)
            {
                second = "0" + timertime.Second;
            }

            lbTime.Text = Convert.ToString(minute + ":" + second);
            scb.lbTimeScoreboard.Text = lbTime.Text;
            if (minute == "00" && second == "00")
            {
                timer1.Stop();
                timerstarted = false;
                lbTime.Text = "12:00";
                btStartStopTimer.BackColor = System.Drawing.Color.Green;
                int aktquarter = Convert.ToInt16(lbQuarter.Text);
                if (aktquarter < 4)
                {
                    aktquarter += 1;
                    lbQuarter.Text = Convert.ToString(aktquarter);
                    scb.lbQuarter.Text = lbQuarter.Text;
                }
            }
        }
        private void ControlCenter_Load(object sender, EventArgs e)
        {

        }

        private void btResetTimer_Click(object sender, EventArgs e)
        {
            string minutes = nuMin.Text;
            string seconds = nuSec.Text;
            if (Convert.ToInt32(minutes) < 10)
            {
                minutes = "0" + nuMin.Text;
            }
            if (Convert.ToInt32(seconds) < 10)
            {
                seconds = "0" + nuSec.Text;
            }
            lbTime.Text = minutes + ":" + seconds;
            scb.lbTimeScoreboard.Text = lbTime.Text;
        }

        private void btQuarterPlus_Click(object sender, EventArgs e)
        {
            int aktquarter = Convert.ToInt16(lbQuarter.Text);
            if (aktquarter < 4)
            {
                aktquarter += 1;
                lbQuarter.Text = Convert.ToString(aktquarter);
                scb.lbQuarter.Text = lbQuarter.Text;
            }
        }

        private void btQuarterMinus_Click(object sender, EventArgs e)
        {
            int aktquarter = Convert.ToInt16(lbQuarter.Text);
            if (aktquarter > 1)
            {
                aktquarter -= 1;
                lbQuarter.Text = Convert.ToString(aktquarter);
                scb.lbQuarter.Text = lbQuarter.Text;
            }
        }

        private void btDownPlus_Click(object sender, EventArgs e)
        {
            int aktdown = Convert.ToInt16(lbDown.Text);
            if (aktdown < 4)
            {
                aktdown += 1;
                lbDown.Text = Convert.ToString(aktdown);
                scb.lbDown.Text = lbDown.Text;
            }
            else
            {
                lbDown.Text = Convert.ToString(1);
                scb.lbDown.Text = lbDown.Text;
            }

        }

        private void btDownMinus_Click(object sender, EventArgs e)
        {
            int aktdown = Convert.ToInt16(lbDown.Text);
            if (aktdown > 1)
            {
                aktdown -= 1;
                lbDown.Text = Convert.ToString(aktdown);
                scb.lbDown.Text = lbDown.Text;
            }
            else
            {
                lbDown.Text = Convert.ToString(4);
                scb.lbDown.Text = lbDown.Text;
            }
        }

        private void btResetDown_Click(object sender, EventArgs e)
        {
            lbDown.Text = Convert.ToString(1);
            scb.lbDown.Text = lbDown.Text;
        }

        private void btTDHomePlus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            scorehome += 6;
            lbScoreHome.Text = Convert.ToString(scorehome);
            scb.lbScoreHome.Text = lbScoreHome.Text;
        }

        private void bt2ptHomePlus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            scorehome += 2;
            lbScoreHome.Text = Convert.ToString(scorehome);
            scb.lbScoreHome.Text = lbScoreHome.Text;
        }

        private void bt1ptHomePlus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            scorehome += 1;
            lbScoreHome.Text = Convert.ToString(scorehome);
            scb.lbScoreHome.Text = lbScoreHome.Text;
        }

        private void bt1ptHomeMinus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            if (scorehome >= 1)
            {
                scorehome -= 1;
                lbScoreHome.Text = Convert.ToString(scorehome);
                scb.lbScoreHome.Text = lbScoreHome.Text;
            }

        }

        private void bt3ptHomePlus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            scorehome += 3;
            lbScoreHome.Text = Convert.ToString(scorehome);
            scb.lbScoreHome.Text = lbScoreHome.Text;
        }

        private void btTDGuestPlus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            scoreguest += 6;
            lbScoreGuest.Text = Convert.ToString(scoreguest);
            scb.lbScoreGuest.Text = lbScoreGuest.Text;
        }

        private void bt2ptGuestPlus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            scoreguest += 2;
            lbScoreGuest.Text = Convert.ToString(scoreguest);
            scb.lbScoreGuest.Text = lbScoreGuest.Text;
        }

        private void bt1ptGuestPlus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            scoreguest += 1;
            lbScoreGuest.Text = Convert.ToString(scoreguest);
            scb.lbScoreGuest.Text = lbScoreGuest.Text;
        }

        private void bt1ptGuestMinus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            if (scoreguest >= 1)
            {
                scoreguest -= 1;
                lbScoreGuest.Text = Convert.ToString(scoreguest);
                scb.lbScoreGuest.Text = lbScoreGuest.Text;
            }

        }

        private void bt3ptGuestPlus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            scoreguest += 3;
            lbScoreGuest.Text = Convert.ToString(scoreguest);
            scb.lbScoreGuest.Text = lbScoreGuest.Text;
        }

        private void btTDHomeMinus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            if (scorehome >= 6)
            {
                scorehome -= 6;
                lbScoreHome.Text = Convert.ToString(scorehome);
                scb.lbScoreHome.Text = lbScoreHome.Text;

            }

        }

        private void btTDGuestMinus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            if (scoreguest >= 6)
            {
                scoreguest -= 6;
                lbScoreGuest.Text = Convert.ToString(scoreguest);
                scb.lbScoreGuest.Text = lbScoreGuest.Text;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            if (scorehome >= 2)
            {
                scorehome -= 2;
                lbScoreHome.Text = Convert.ToString(scorehome);
                scb.lbScoreHome.Text = lbScoreHome.Text;
            }

        }

        private void bt2ptGuestMinus_Click(object sender, EventArgs e)
        {
            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            if (scoreguest >= 2)
            {
                scoreguest -= 2;
                lbScoreGuest.Text = Convert.ToString(scoreguest);
                scb.lbScoreGuest.Text = lbScoreGuest.Text;
            }
        }

        private void bt3ptHomeMinus_Click(object sender, EventArgs e)
        {
            int scorehome = Convert.ToInt16(lbScoreHome.Text);
            if (scorehome >= 3)
            {
                scorehome -= 3;
                lbScoreHome.Text = Convert.ToString(scorehome);
                scb.lbScoreHome.Text = lbScoreHome.Text;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int scoreguest = Convert.ToInt16(lbScoreGuest.Text);
            if (scoreguest >= 3)
            {
                scoreguest -= 3;
                lbScoreGuest.Text = Convert.ToString(scoreguest);
                scb.lbScoreGuest.Text = lbScoreGuest.Text;
            }

        }

        private void btSetTitle_Click(object sender, EventArgs e)
        {
            scb.lbTitle.Text = tbTitle.Text;
        }

        private void btResetTitle_Click(object sender, EventArgs e)
        {
            scb.lbTitle.Text = "Salzburg Ducks Homefield";
        }

        private void btFormTitle_Click(object sender, EventArgs e)
        {
            if (scb.FormBorderStyle == FormBorderStyle.Sizable)
            {

                scb.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {

                scb.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void btPlayer1_Click(object sender, EventArgs e)
        {
            showPlayerPicture(1);


        }

        private void showPlayerPicture(int number)
        {
            Button bt = (Button)Controls.Find("btPlayer" + Convert.ToString(number), true)[0];
            if (playershown == false)
            {
                bt.BackColor = System.Drawing.Color.Green;
                string projectpath = AppDomain.CurrentDomain.BaseDirectory;
                FileStream imageStream;
                try
                {
                    imageStream = new FileStream(playerimagepath + "/" + number + ".jpg", FileMode.Open, FileAccess.Read);
                }
                catch (Exception ex)
                {
                    imageStream = new FileStream(playerimagepath + "/unbekannt.jpg", FileMode.Open, FileAccess.Read);
                }
                scb.pBPlayer.Image = System.Drawing.Image.FromStream(imageStream);
                scb.pBPlayer.BringToFront();
                scb.pBPlayer.Visible = true;
                playershown = true;
            }
            else
            {
                bt.BackColor = SystemColors.Control;
                scb.pBPlayer.SendToBack();
                scb.pBPlayer.Visible = false;
                playershown = false;
            }
        }

        private void btTouchDownPicture_Click(object sender, EventArgs e)
        {
            Button bt = (Button)Controls.Find("btTouchDownPicture", true)[0];
            if (TDshown == false)
            {
                
                ExamplePlayer.SoundLocation = imagepath + "/TDDucks.wav";
                ExamplePlayer.Play();
                bt.BackColor = System.Drawing.Color.Green;
                TDshown = true;
                string projectpath = AppDomain.CurrentDomain.BaseDirectory;
                FileStream imageStream = new FileStream(imagepath + "/TD.gif", FileMode.Open, FileAccess.Read);
                scb.pBPlayer.Image = System.Drawing.Image.FromStream(imageStream);
                scb.pBPlayer.BringToFront();
                scb.pBPlayer.Visible = true;

            }
            else
            {
                bt.BackColor = SystemColors.Control;
                TDshown = false;
                scb.pBPlayer.SendToBack();
                scb.pBPlayer.Visible = false;
                ExamplePlayer.Stop();
            }

        }

        private void btBigHit_Click(object sender, EventArgs e)
        {
            Button bt = (Button)Controls.Find("btBigHit", true)[0];
            if (BigHit == false)
            {
                ExamplePlayer.SoundLocation = imagepath + "/Boom.wav";
                ExamplePlayer.Play();
                bt.BackColor = System.Drawing.Color.Green;
                BigHit = true;
                string projectpath = AppDomain.CurrentDomain.BaseDirectory;
                FileStream imageStream = new FileStream(imagepath + "/BigHit.gif", FileMode.Open, FileAccess.Read);
                scb.pBPlayer.Image = System.Drawing.Image.FromStream(imageStream);
                scb.pBPlayer.BringToFront();
                scb.pBPlayer.Visible = true;

            }
            else
            {
                bt.BackColor = SystemColors.Control;
                BigHit = false;
                scb.pBPlayer.SendToBack();
                scb.pBPlayer.Visible = false;
                ExamplePlayer.Stop();
            }
        }

        private void btPlayer2_Click(object sender, EventArgs e)
        {
            showPlayerPicture(2);
        }

        private void btPlayer3_Click(object sender, EventArgs e)
        {
            showPlayerPicture(3);
        }

        private void btPlayer4_Click(object sender, EventArgs e)
        {
            showPlayerPicture(4);

        }

        private void btPlayer5_Click(object sender, EventArgs e)
        {
            showPlayerPicture(5);
        }

        private void btPlayer6_Click(object sender, EventArgs e)
        {
            showPlayerPicture(6);
        }

        private void btPlayer7_Click(object sender, EventArgs e)
        {
            showPlayerPicture(7);
        }

        private void btPlayer8_Click(object sender, EventArgs e)
        {
            showPlayerPicture(8);
        }

        private void btPlayer9_Click(object sender, EventArgs e)
        {
            showPlayerPicture(9);
        }

        private void btPlayer10_Click(object sender, EventArgs e)
        {
            showPlayerPicture(10);
        }

        private void btPlayer11_Click(object sender, EventArgs e)
        {
            showPlayerPicture(11);
        }

        private void btPlayer12_Click(object sender, EventArgs e)
        {
            showPlayerPicture(12);
        }

        private void btPlayer13_Click(object sender, EventArgs e)
        {
            showPlayerPicture(13);
        }

        private void btPlayer14_Click(object sender, EventArgs e)
        {
            showPlayerPicture(14);
        }

        private void btPlayer15_Click(object sender, EventArgs e)
        {
            showPlayerPicture(15);
        }

        private void btPlayer16_Click(object sender, EventArgs e)
        {
            showPlayerPicture(16);
        }

        private void btPlayer17_Click(object sender, EventArgs e)
        {
            showPlayerPicture(17);
        }

        private void btPlayer18_Click(object sender, EventArgs e)
        {
            showPlayerPicture(18);
        }

        private void btPlayer19_Click(object sender, EventArgs e)
        {
            showPlayerPicture(19);
        }

        private void btPlayer20_Click(object sender, EventArgs e)
        {
            showPlayerPicture(20);
        }

        private void btPlayer21_Click(object sender, EventArgs e)
        {
            showPlayerPicture(21);
        }

        private void btPlayer22_Click(object sender, EventArgs e)
        {
            showPlayerPicture(22);
        }

        private void btPlayer23_Click(object sender, EventArgs e)
        {
            showPlayerPicture(23);
        }

        private void btPlayer24_Click(object sender, EventArgs e)
        {
            showPlayerPicture(24);
        }

        private void btPlayer25_Click(object sender, EventArgs e)
        {
            showPlayerPicture(25);
        }

        private void btPlayer26_Click(object sender, EventArgs e)
        {
            showPlayerPicture(26);
        }

        private void btPlayer27_Click(object sender, EventArgs e)
        {
            showPlayerPicture(27);
        }

        private void btPlayer28_Click(object sender, EventArgs e)
        {
            showPlayerPicture(28);
        }

        private void btPlayer29_Click(object sender, EventArgs e)
        {
            showPlayerPicture(29);
        }

        private void btPlayer30_Click(object sender, EventArgs e)
        {
            showPlayerPicture(30);
        }

        private void btPlayer31_Click(object sender, EventArgs e)
        {
            showPlayerPicture(31);
        }

        private void btPlayer32_Click(object sender, EventArgs e)
        {
            showPlayerPicture(32);
        }

        private void btPlayer33_Click(object sender, EventArgs e)
        {
            showPlayerPicture(33);
        }

        private void btPlayer34_Click(object sender, EventArgs e)
        {
            showPlayerPicture(34);
        }

        private void btPlayer35_Click(object sender, EventArgs e)
        {
            showPlayerPicture(35);
        }

        private void btPlayer36_Click(object sender, EventArgs e)
        {
            showPlayerPicture(36);
        }

        private void btPlayer37_Click(object sender, EventArgs e)
        {
            showPlayerPicture(37);
        }

        private void btPlayer38_Click(object sender, EventArgs e)
        {
            showPlayerPicture(38);
        }

        private void btPlayer39_Click(object sender, EventArgs e)
        {
            showPlayerPicture(39);
        }

        private void btPlayer40_Click(object sender, EventArgs e)
        {
            showPlayerPicture(40);
        }

        private void btPlayer41_Click(object sender, EventArgs e)
        {
            showPlayerPicture(41);
        }

        private void btPlayer42_Click(object sender, EventArgs e)
        {
            showPlayerPicture(42);
        }

        private void btPlayer43_Click(object sender, EventArgs e)
        {
            showPlayerPicture(43);
        }

        private void btPlayer44_Click(object sender, EventArgs e)
        {
            showPlayerPicture(44);
        }

        private void btPlayer45_Click(object sender, EventArgs e)
        {
            showPlayerPicture(45);
        }

        private void btPlayer46_Click(object sender, EventArgs e)
        {
            showPlayerPicture(46);
        }

        private void btPlayer47_Click(object sender, EventArgs e)
        {
            showPlayerPicture(47);
        }

        private void btPlayer48_Click(object sender, EventArgs e)
        {
            showPlayerPicture(48);
        }

        private void btPlayer49_Click(object sender, EventArgs e)
        {
            showPlayerPicture(49);
        }

        private void btPlayer50_Click(object sender, EventArgs e)
        {
            showPlayerPicture(50);
        }

        private void btPlayer51_Click(object sender, EventArgs e)
        {
            showPlayerPicture(51);
        }

        private void btPlayer52_Click(object sender, EventArgs e)
        {
            showPlayerPicture(52);
        }

        private void btPlayer53_Click(object sender, EventArgs e)
        {
            showPlayerPicture(53);
        }

        private void btPlayer54_Click(object sender, EventArgs e)
        {
            showPlayerPicture(54);
        }

        private void btPlayer55_Click(object sender, EventArgs e)
        {
            showPlayerPicture(55);
        }

        private void btPlayer56_Click(object sender, EventArgs e)
        {
            showPlayerPicture(56);
        }

        private void btPlayer57_Click(object sender, EventArgs e)
        {
            showPlayerPicture(57);
        }

        private void btPlayer58_Click(object sender, EventArgs e)
        {
            showPlayerPicture(58);
        }

        private void btPlayer59_Click(object sender, EventArgs e)
        {
            showPlayerPicture(59);
        }

        private void btPlayer60_Click(object sender, EventArgs e)
        {
            showPlayerPicture(60);
        }

        private void btPlayer61_Click(object sender, EventArgs e)
        {
            showPlayerPicture(61);
        }

        private void btPlayer62_Click(object sender, EventArgs e)
        {
            showPlayerPicture(62);
        }

        private void btPlayer63_Click(object sender, EventArgs e)
        {
            showPlayerPicture(63);
        }

        private void btPlayer64_Click(object sender, EventArgs e)
        {
            showPlayerPicture(64);
        }

        private void btPlayer65_Click(object sender, EventArgs e)
        {
            showPlayerPicture(65);
        }

        private void btPlayer66_Click(object sender, EventArgs e)
        {
            showPlayerPicture(66);
        }

        private void btPlayer67_Click(object sender, EventArgs e)
        {
            showPlayerPicture(67);
        }

        private void btPlayer68_Click(object sender, EventArgs e)
        {
            showPlayerPicture(68);
        }

        private void btPlayer69_Click(object sender, EventArgs e)
        {
            showPlayerPicture(69);
        }

        private void btPlayer70_Click(object sender, EventArgs e)
        {
            showPlayerPicture(70);
        }

        private void btPlayer71_Click(object sender, EventArgs e)
        {
            showPlayerPicture(71);
        }

        private void btPlayer72_Click(object sender, EventArgs e)
        {
            showPlayerPicture(72);
        }

        private void btPlayer73_Click(object sender, EventArgs e)
        {
            showPlayerPicture(73);
        }

        private void btPlayer74_Click(object sender, EventArgs e)
        {
            showPlayerPicture(74);
        }

        private void btPlayer75_Click(object sender, EventArgs e)
        {
            showPlayerPicture(75);
        }

        private void btPlayer76_Click(object sender, EventArgs e)
        {
            showPlayerPicture(76);
        }

        private void btPlayer77_Click(object sender, EventArgs e)
        {
            showPlayerPicture(77);
        }

        private void btPlayer78_Click(object sender, EventArgs e)
        {
            showPlayerPicture(78);
        }

        private void btPlayer79_Click(object sender, EventArgs e)
        {
            showPlayerPicture(79);
        }

        private void btPlayer80_Click(object sender, EventArgs e)
        {
            showPlayerPicture(80);
        }

        private void btPlayer81_Click(object sender, EventArgs e)
        {
            showPlayerPicture(81);
        }

        private void btPlayer82_Click(object sender, EventArgs e)
        {
            showPlayerPicture(82);
        }

        private void btPlayer83_Click(object sender, EventArgs e)
        {
            showPlayerPicture(83);
        }

        private void btPlayer84_Click(object sender, EventArgs e)
        {
            showPlayerPicture(84);
        }

        private void btPlayer85_Click(object sender, EventArgs e)
        {
            showPlayerPicture(85);
        }

        private void btPlayer86_Click(object sender, EventArgs e)
        {
            showPlayerPicture(86);
        }

        private void btPlayer87_Click(object sender, EventArgs e)
        {
            showPlayerPicture(87);
        }

        private void btPlayer88_Click(object sender, EventArgs e)
        {
            showPlayerPicture(88);
        }

        private void btPlayer89_Click(object sender, EventArgs e)
        {
            showPlayerPicture(89);
        }

        private void btPlayer90_Click(object sender, EventArgs e)
        {
            showPlayerPicture(90);
        }

        private void btPlayer91_Click(object sender, EventArgs e)
        {
            showPlayerPicture(91);
        }

        private void btPlayer92_Click(object sender, EventArgs e)
        {
            showPlayerPicture(92);
        }

        private void btPlayer93_Click(object sender, EventArgs e)
        {
            showPlayerPicture(93);
        }

        private void btPlayer94_Click(object sender, EventArgs e)
        {
            showPlayerPicture(94);
        }

        private void btPlayer95_Click(object sender, EventArgs e)
        {
            showPlayerPicture(95);
        }

        private void btPlayer96_Click(object sender, EventArgs e)
        {
            showPlayerPicture(96);
        }

        private void btPlayer97_Click(object sender, EventArgs e)
        {
            showPlayerPicture(97);
        }

        private void btPlayer98_Click(object sender, EventArgs e)
        {
            showPlayerPicture(98);
        }

        private void btPlayer99_Click(object sender, EventArgs e)
        {
            showPlayerPicture(99);
        }

        private void setImagePathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Custom Description";
            string sSelectedPath = "";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedPath = fbd.SelectedPath;
                imagepath = sSelectedPath;
                System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/pfad.txt");
                writer.Write(sSelectedPath);
                writer.Close();
                writer.Dispose();
            }

        }

        private void setHomeLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();

            string sSelectedFile = "";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedFile = fbd.FileName;
                homelogopath = sSelectedFile;
                System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/homepfad.txt");
                writer.Write(sSelectedFile);
                writer.Close();
                writer.Dispose();
                FileStream imageStreamHome = new FileStream(homelogopath, FileMode.Open, FileAccess.Read);
                scb.pBHome.Image = System.Drawing.Image.FromStream(imageStreamHome);

            }

        }

        private void setGuestLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();

            string sSelectedFile = "";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedFile = fbd.FileName;
                guestlogopath = sSelectedFile;
                System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/guestpfad.txt");
                writer.Write(sSelectedFile);
                writer.Close();
                writer.Dispose();

                FileStream imageStreamGuest = new FileStream(guestlogopath, FileMode.Open, FileAccess.Read);
                scb.pBGuest.Image = System.Drawing.Image.FromStream(imageStreamGuest);
            }
        }

        private void setBGColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            scb.BackColor = MyDialog.Color;
            System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/bgcolor.txt");
            writer.Write(MyDialog.Color.Name);
            writer.Close();
            writer.Dispose();

        }

        private void setFontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            scb.lbTextDown.ForeColor = MyDialog.Color;
            scb.lbTextQuarter.ForeColor = MyDialog.Color;
            scb.lbTime.ForeColor = MyDialog.Color;
            scb.lbTextHome.ForeColor = MyDialog.Color;
            scb.lbTextGuest.ForeColor = MyDialog.Color;
            scb.lbTitle.ForeColor = MyDialog.Color;
            System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/fontcolor.txt");
            writer.Write(MyDialog.Color.Name);
            writer.Close();
            writer.Dispose();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Button bt = (Button)Controls.Find("btPlayVideo", true)[0];
            if (PlayVideo == false)
            {
                if (first == true)
                {
                    first = false;
                     videopath = getVideoPath();
                }
              
                bt.BackColor = System.Drawing.Color.Green;
                PlayVideo = true;
                scb.MediaPlayer.BringToFront();
                scb.MediaPlayer.Visible = true;
                scb.MediaPlayer.URL = videopath;
                scb.MediaPlayer.Width = scb.Width;
                scb.MediaPlayer.Height = scb.Height;
                scb.MediaPlayer.uiMode = "none";
                
                

            }
            else
            {
                bt.BackColor = SystemColors.Control;
                PlayVideo = false;
                scb.MediaPlayer.SendToBack();
                scb.MediaPlayer.Visible = false;
                scb.MediaPlayer.close();
            }
        }

        private void btOpenVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();            
            string sSelectedPath = "";

            

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                videopath = fbd.FileName;
                System.IO.StreamWriter writer=null;
                try
                {
                    writer = new System.IO.StreamWriter("c:/temp/videopfad.txt");
                    writer.Write(videopath);
                    writer.Close();
                    writer.Dispose();
                    fbd.Dispose();
                }
                catch(Exception ex)
                {
                    string fehler = ex.Message;
                }
                
                
                
            }
        }

        private void btSetPause_Click(object sender, EventArgs e)
        {
            lbTime.Text = "15:00";
            scb.lbTimeScoreboard.Text = lbTime.Text;
        }

        private void setPlayerImagePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Custom Description";
            string sSelectedPath = "";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sSelectedPath = fbd.SelectedPath;
                imagepath = sSelectedPath;               
                System.IO.StreamWriter writer = new System.IO.StreamWriter("c:/temp/pfadplayer.txt", false);                
                writer.Write(sSelectedPath);
                writer.Close();
                writer.Dispose();
            }
        }

        private void btFirstDown_Click(object sender, EventArgs e)
        {
            Button bt = (Button)Controls.Find("btFirstDown", true)[0];
            if (FirstDownshown == false)
            {

                ExamplePlayer.SoundLocation = imagepath + "/FirstDownLaddiesWav.wav";
                ExamplePlayer.Play();
                bt.BackColor = System.Drawing.Color.Green;
                FirstDownshown = true;
                string projectpath = AppDomain.CurrentDomain.BaseDirectory;
                FileStream imageStream = new FileStream(imagepath + "/FirstDownGif.gif", FileMode.Open, FileAccess.Read);
                scb.pBPlayer.Image = System.Drawing.Image.FromStream(imageStream);
                scb.pBPlayer.BringToFront();
                scb.pBPlayer.Visible = true;

            }
            else
            {
                bt.BackColor = SystemColors.Control;
                FirstDownshown = false;
                scb.pBPlayer.SendToBack();
                scb.pBPlayer.Visible = false;
                ExamplePlayer.Stop();
            }
        }
    }
}
