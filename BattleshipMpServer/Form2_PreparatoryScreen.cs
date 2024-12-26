using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipMp
{
    public partial class Form2_PreparatoryScreen : Form
    {
        
        public Form2_PreparatoryScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;            
        }

        //  Create a drawing to select ship positions starting with a mouse click. Get selected buttons when mouse is released.
        //  This region also includes the GetSelectedButtons() method. However, since other operations are done in this method, I did not include it in the region.
        #region ****************************************************** 2D Drawing ******************************************************
        private Point selectionStart;
        private Point selectionEnd;
        private Rectangle selection;
        private bool mouseDown;


        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            selectionStart = PointToClient(MousePosition);
            mouseDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;

            SetSelectionRect();
            Invalidate();

            GetSelectedButtons();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!mouseDown)
            {
                return;
            }

            selectionEnd = PointToClient(MousePosition);
            SetSelectionRect();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mouseDown)
            {
                using (Pen pen = new Pen(Color.Black, 1F))
                {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, selection);
                }
            }
        }

        private void SetSelectionRect()
        {
            int x, y;
            int width, height;

            x = selectionStart.X > selectionEnd.X ? selectionEnd.X : selectionStart.X;
            y = selectionStart.Y > selectionEnd.Y ? selectionEnd.Y : selectionStart.Y;

            width = selectionStart.X > selectionEnd.X ? selectionStart.X - selectionEnd.X : selectionEnd.X - selectionStart.X;
            height = selectionStart.Y > selectionEnd.Y ? selectionStart.Y - selectionEnd.Y : selectionEnd.Y - selectionStart.Y;

            selection = new Rectangle(x, y, width, height);
        }

        #endregion

        public static Dictionary<string, int> shipsCount = new Dictionary<string, int>()
        {
            {"Battleship", 1 },{"Cruiser", 2},{"Destroyer", 1}
        };

        public static List<Ship> shipList = new List<Ship>();

        List<string> AllSelectedButtonList = new List<string>();

        bool isPanelActive = true;


        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            shipList = null;
            CreateShipList();
            RemainingShips();
        }

        // 1 // In the first step, create ships derived from the "Ship" model (class) and list these ships.
        private void CreateShipList()
        {
            if (shipList == null)
            {
                shipList = new List<Ship>();
            }
            foreach (var item in shipsCount)
            {
                Ship _ship = new Ship();
                _ship.shipName = item.Key;
                _ship.remShips = item.Value;

                shipList.Add(_ship);
            }
        }

        private void GetSelectedButtons()
        {
            // 2 // Put the buttons selected with the mouse into the list.

            List<Button> selected = new List<Button>();

            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    if (selection.IntersectsWith(c.Bounds))
                    {
                        selected.Add((Button)c);
                    }
                }
            }

            List<string> buttonsNames = new List<string>();

            foreach (Control c in selected)
            {
                buttonsNames.Add(c.Name);
            }

            buttonsNames.Sort();

            // 3 // After the selected buttons are put in the list and sorted alphabetically. Check if the selected boxes are consecutive.
            // After separating the characters of the box names and adding the ascii values ​​one by one, make sure that there is 1 difference between them and the next box.

            List<int> totalAsciiList = new List<int>();
            foreach (var item in buttonsNames)
            {
                char ch1 = char.Parse(item.Substring(0, 1));
                char ch2 = char.Parse(item.Substring(item.Length - 1));
                totalAsciiList.Add((int)ch1 + (int)ch2);
            }

            if (totalAsciiList.Count > 1)
            {
                for (int i = 0; i < totalAsciiList.Count - 1; i++)
                {
                    if (totalAsciiList[i] + 1 != totalAsciiList[i + 1])
                    {
                        MessageBox.Show("The area where the ship will be located must be consecutive boxes.");
                        return;
                    }
                }
            }

            // 4 //  If the color of any of the selected buttons is "DarkGray" i.e. it contains part of a predefined ship.
            // Call the "DeleteShip" method.
            foreach (var item in selected)
            {
                if (item.BackColor == Color.DarkGray)
                {
                    DeleteShip(selected);
                    return;
                }
            }

            // 6 // If the buttons are selected for the first time, bring up Form3 as a dialog window listing the ship that matches the number of buttons selected.
            // 7 // If it returns with a "Save" result, save the returning ship and related buttons according to the Ship model. + Decrease "remShip" in model.
            //  Call the RemainingShip() method after registration.
            if (selected.Count > 0 && !selected.Any(btn => btn.Name == "buttonStart"))
            {
                using (var frm3 = new Form3_ShipSelectScreen(buttonsNames))
                {
                    var res = frm3.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        string val = frm3.returnValue;
                        foreach (var item in shipList)
                        {
                            if (item.shipName == val)
                            {
                                item.remShips--;

                                if (item.shipPerButton == null)
                                    item.shipPerButton = new List<ShipButtons>();

                                ShipButtons sb = new ShipButtons() { buttonNames = new List<string>() };
                                foreach (var item2 in selected)
                                {
                                    item2.BackColor = Color.DarkGray;
                                    sb.buttonNames.Add(item2.Name);
                                }
                                item.shipPerButton.Add(sb);

                                RemainingShips();
                                break;
                            }
                        }
                    }
                }
            }
        }

        // 5 // If the deletion is confirmed, find which ship the button belongs to and delete that ship from the list. + Increase "remShip" in the model.
        // After saving, call the RemainingShip() method.
        private void DeleteShip(List<Button> selected)
        {
            DialogResult dres = MessageBox.Show("Are you sure you want to delete the ship?", "Delete Ship", MessageBoxButtons.YesNo);
            if (dres == DialogResult.Yes)
            {
                foreach (var item1 in shipList)
                {
                    if (item1.shipPerButton != null)
                    {
                        foreach (var item2 in item1.shipPerButton)
                        {
                            foreach (var item3 in selected)
                            {
                                if (item2.buttonNames.FirstOrDefault(x => x.Equals(item3.Name)) != null)
                                {
                                    item1.remShips++;
                                    foreach (var item4 in item2.buttonNames)
                                    {
                                        this.Controls.Find(item4, true)[0].BackColor = Color.Transparent;
                                    }
                                    item1.shipPerButton.Remove(item2);
                                    RemainingShips();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        // 8 // Print the number of ships that need to be added according to the ship list. If there are no missing ships, activate the Ready/Start button.
        private void RemainingShips()
        {
            //{"Battleship", 1 },{"Cruiser", 2},{"Destroyer", 3},{"Submarine", 4}
            lblBattleship.Text = lblBattleship.Text.Substring(0, lblBattleship.Text.Length - 1);
            lblBattleship.Text += shipList.FirstOrDefault(x => x.shipName == "Battleship").remShips.ToString();

            lblCruiser.Text = lblCruiser.Text.Substring(0, lblCruiser.Text.Length - 1);
            lblCruiser.Text += shipList.FirstOrDefault(x => x.shipName == "Cruiser").remShips.ToString();

            lblDestroyer.Text = lblDestroyer.Text.Substring(0, lblDestroyer.Text.Length - 1);
            lblDestroyer.Text += shipList.FirstOrDefault(x => x.shipName == "Destroyer").remShips.ToString();


            foreach (var item in shipList)
            {
                if (item.remShips == 0)
                {
                    isPanelActive = true;
                }
                else
                {
                    isPanelActive = false;
                    break;
                }
            }
            if (isPanelActive == true)
            {
                buttonStart.Enabled = true;
                buttonStart.Text = "Ready.\nStart";
            }
            else
            {
                buttonStart.Enabled = false;
                buttonStart.Text = "Preparatory";
            }
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1- Hold down the mouse LC and select the location where you want to place the ships.\n\n" +
                "2- \r\nSelect from the page listing the ships that can be placed in the selected location.\n\n" +
                "3- Click 'Ready' when you have placed all your ships.\n\n" +
                "Notice: The game will start after both players 'Continue'.");
        }

        
        //  Oyun ekranına geçerken oyuncunun kendi gemilerini görebilmesi için constructor methoda seçilen gemileri içeren buton listesini gönder.
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            Form4_GameScreen frm4 = new Form4_GameScreen(FillAllButtonList());
            this.Visible = false;
            frm4.Show();
        }

        private List<string> FillAllButtonList()
        {
            foreach (var item1 in shipList)
            {
                foreach(var item2 in item1.shipPerButton)
                {
                    foreach (var item3 in item2.buttonNames)
                    {
                        AllSelectedButtonList.Add(item3);
                    }
                }
            }
            return AllSelectedButtonList;
        }

        //  Check every 1 second if the client is disconnected.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Server.listener != null && (Server.client == null && !Server.client.Connected))
            {
                MessageBox.Show("Client connection failed.");
            }
        }

        private void Form2_PreparatoryScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            Form1_ServerScreen frm1 = new Form1_ServerScreen();
            frm1.Show();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void A1_Click(object sender, EventArgs e)
        {

        }

        private void B1_Click(object sender, EventArgs e)
        {

        }

        private void C1_Click(object sender, EventArgs e)
        {

        }

        private void D1_Click(object sender, EventArgs e)
        {

        }

        private void E1_Click(object sender, EventArgs e)
        {

        }

        private void F1_Click(object sender, EventArgs e)
        {

        }

        private void G1_Click(object sender, EventArgs e)
        {

        }

        private void H1_Click(object sender, EventArgs e)
        {

        }

        private void I1_Click(object sender, EventArgs e)
        {

        }

        private void J1_Click(object sender, EventArgs e)
        {

        }

        private void J2_Click(object sender, EventArgs e)
        {

        }

        private void I2_Click(object sender, EventArgs e)
        {

        }

        private void H2_Click(object sender, EventArgs e)
        {

        }

        private void G2_Click(object sender, EventArgs e)
        {

        }

        private void E2_Click(object sender, EventArgs e)
        {

        }

        private void D2_Click(object sender, EventArgs e)
        {

        }

        private void C2_Click(object sender, EventArgs e)
        {

        }

        private void F2_Click(object sender, EventArgs e)
        {

        }

        private void B2_Click(object sender, EventArgs e)
        {

        }

        private void A2_Click(object sender, EventArgs e)
        {

        }

        private void J3_Click(object sender, EventArgs e)
        {

        }

        private void I3_Click(object sender, EventArgs e)
        {

        }

        private void J4_Click(object sender, EventArgs e)
        {

        }

        private void H3_Click(object sender, EventArgs e)
        {

        }

        private void I4_Click(object sender, EventArgs e)
        {

        }

        private void G3_Click(object sender, EventArgs e)
        {

        }

        private void H4_Click(object sender, EventArgs e)
        {

        }

        private void E3_Click(object sender, EventArgs e)
        {

        }

        private void G4_Click(object sender, EventArgs e)
        {

        }

        private void D3_Click(object sender, EventArgs e)
        {

        }

        private void E4_Click(object sender, EventArgs e)
        {

        }

        private void C3_Click(object sender, EventArgs e)
        {

        }

        private void D4_Click(object sender, EventArgs e)
        {

        }

        private void F3_Click(object sender, EventArgs e)
        {

        }

        private void C4_Click(object sender, EventArgs e)
        {

        }

        private void B3_Click(object sender, EventArgs e)
        {

        }

        private void F4_Click(object sender, EventArgs e)
        {

        }

        private void A3_Click(object sender, EventArgs e)
        {

        }

        private void B4_Click(object sender, EventArgs e)
        {

        }

        private void A4_Click(object sender, EventArgs e)
        {

        }

        private void J5_Click(object sender, EventArgs e)
        {

        }

        private void I5_Click(object sender, EventArgs e)
        {

        }

        private void J7_Click(object sender, EventArgs e)
        {

        }

        private void J6_Click(object sender, EventArgs e)
        {

        }

        private void I7_Click(object sender, EventArgs e)
        {

        }

        private void H5_Click(object sender, EventArgs e)
        {

        }

        private void J8_Click(object sender, EventArgs e)
        {

        }

        private void I6_Click(object sender, EventArgs e)
        {

        }

        private void H7_Click(object sender, EventArgs e)
        {

        }

        private void G5_Click(object sender, EventArgs e)
        {

        }

        private void I8_Click(object sender, EventArgs e)
        {

        }

        private void H6_Click(object sender, EventArgs e)
        {

        }

        private void G7_Click(object sender, EventArgs e)
        {

        }

        private void E5_Click(object sender, EventArgs e)
        {

        }

        private void H8_Click(object sender, EventArgs e)
        {

        }

        private void G6_Click(object sender, EventArgs e)
        {

        }

        private void E7_Click(object sender, EventArgs e)
        {

        }

        private void D5_Click(object sender, EventArgs e)
        {

        }

        private void G8_Click(object sender, EventArgs e)
        {

        }

        private void E6_Click(object sender, EventArgs e)
        {

        }

        private void D7_Click(object sender, EventArgs e)
        {

        }

        private void C5_Click(object sender, EventArgs e)
        {

        }

        private void E8_Click(object sender, EventArgs e)
        {

        }

        private void D6_Click(object sender, EventArgs e)
        {

        }

        private void C7_Click(object sender, EventArgs e)
        {

        }

        private void F5_Click(object sender, EventArgs e)
        {

        }

        private void D8_Click(object sender, EventArgs e)
        {

        }

        private void C6_Click(object sender, EventArgs e)
        {

        }

        private void F7_Click(object sender, EventArgs e)
        {

        }

        private void B5_Click(object sender, EventArgs e)
        {

        }

        private void C8_Click(object sender, EventArgs e)
        {

        }

        private void F6_Click(object sender, EventArgs e)
        {

        }

        private void B7_Click(object sender, EventArgs e)
        {

        }

        private void A5_Click(object sender, EventArgs e)
        {

        }

        private void F8_Click(object sender, EventArgs e)
        {

        }

        private void A7_Click(object sender, EventArgs e)
        {

        }

        private void B6_Click(object sender, EventArgs e)
        {

        }

        private void B8_Click(object sender, EventArgs e)
        {

        }

        private void A6_Click(object sender, EventArgs e)
        {

        }

        private void A8_Click(object sender, EventArgs e)
        {

        }

        private void J9_Click(object sender, EventArgs e)
        {

        }

        private void I9_Click(object sender, EventArgs e)
        {

        }

        private void J0_Click(object sender, EventArgs e)
        {

        }

        private void H9_Click(object sender, EventArgs e)
        {

        }

        private void I0_Click(object sender, EventArgs e)
        {

        }

        private void G9_Click(object sender, EventArgs e)
        {

        }

        private void H0_Click(object sender, EventArgs e)
        {

        }

        private void E9_Click(object sender, EventArgs e)
        {

        }

        private void G0_Click(object sender, EventArgs e)
        {

        }

        private void D9_Click(object sender, EventArgs e)
        {

        }

        private void E0_Click(object sender, EventArgs e)
        {

        }

        private void C9_Click(object sender, EventArgs e)
        {

        }

        private void D0_Click(object sender, EventArgs e)
        {

        }

        private void F9_Click(object sender, EventArgs e)
        {

        }

        private void C0_Click(object sender, EventArgs e)
        {

        }

        private void B9_Click(object sender, EventArgs e)
        {

        }

        private void F0_Click(object sender, EventArgs e)
        {

        }

        private void A9_Click(object sender, EventArgs e)
        {

        }

        private void B0_Click(object sender, EventArgs e)
        {

        }

        private void A0_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void yardımToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblBattleship_Click(object sender, EventArgs e)
        {

        }

        private void lblSubmarine_Click(object sender, EventArgs e)
        {

        }

        private void lblCruiser_Click(object sender, EventArgs e)
        {

        }

        private void lblDestroyer_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void A0_Click_1(object sender, EventArgs e)
        {

        }
    }
}
