using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string[] arrayOfEffectsAttributes= new string[13];

        public string[] arrayOfSpeedSynonym = new string[1];
        public string[] arrayOfAccelerationSynonym = new string[1];
        public string[] arrayOfDecelerationSynonym = new string[1];
        public string[] arrayOfManeuveringSynonym = new string[1];
        public string[] arrayOfEnergyConsumptionSynonym = new string[1];
        public string[] arrayOfEnergyProductionSynonym = new string[1];
        public string[] arrayOfCruisingSynonym = new string[1];
        public string[] arrayOfWarpingSynonym = new string[1];

        public int numberOfXMLToCreate;
        private static readonly Random newRandom = new Random();
        Random rnd = new Random();
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public Form1()
        {
            InitializeComponent();

            //EFFECTS
            arrayOfEffectsAttributes[0] = "speed_max_value";
            arrayOfEffectsAttributes[1] = "acceleration_value"; 
            arrayOfEffectsAttributes[2] = "maneuvering_value";
            arrayOfEffectsAttributes[3] = "energy_consumption_engine_value";
            arrayOfEffectsAttributes[4] = "speed_cruising_special"; 
            arrayOfEffectsAttributes[5] = "warp_recharge_value";
            arrayOfEffectsAttributes[6] = "speed_strafe_special";
            arrayOfEffectsAttributes[7] = "deceleration_special";
            arrayOfEffectsAttributes[8] = "maneuvering_percent";
            arrayOfEffectsAttributes[9] = "energy_production_generator_value";
            arrayOfEffectsAttributes[10] = "speed_max_percent"; 
            arrayOfEffectsAttributes[11] = "warp_distance_percent";
            arrayOfEffectsAttributes[12] = "warp_recharge_percent";

            arrayOfSpeedSynonym[0] = "speed";
            arrayOfAccelerationSynonym[0] = "acceleration";
            arrayOfDecelerationSynonym[0] = "deceleration";
            arrayOfManeuveringSynonym[0] = "maneuvering";
            arrayOfEnergyConsumptionSynonym[0] = "energy_consumption";
            arrayOfEnergyProductionSynonym[0] = "energy_production";
            arrayOfCruisingSynonym[0] = "cruise";
            arrayOfWarpingSynonym[0] = "warp";
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            /*for (int i = 0;i < 100;i++)
            {
                int num = GetRandomNumber(0,10); // never including 10
                Console.WriteLine(num);
            }*/

            //ReactorBasicSingle BasicReactors = new ReactorBasicSingle();
            //engine_thrusters reactor3dSingle = new engine_thrusters();

            for (int i = 0; i < numberOfXMLToCreate; i++)
            {
                int newWidth = 24;
                int newHeight = 24;

                int randomGeneratorOrTank = RandomNumber(0, 3);
                var resultForRandomShipType = RandomNumber(0, 2);
                var resultForRandomPropsFin = RandomNumber(0, 2);
                var resultForRandomPropsScrews = 1;// RandomNumber(0, 2);
                var resultForRandomPropsArmor = RandomNumber(0, 2);
                var resultForTank = RandomNumber(0, 2);
                var resultForTankGeneratorPipe = RandomNumber(0, 2);

                //engine_thrusters reactor3dSingle = new engine_thrusters();
                //reactor3dSingle.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 2) + i, randomGeneratorOrTank, 1, resultForRandomShipType, resultForRandomPropsFin, resultForRandomPropsScrews, resultForRandomPropsArmor, resultForTank, resultForTankGeneratorPipe);

                string path = Program.VEBOOSTERSFORSHOPREACTOR3DSINGLEXML + @"\" + i + ".xml"; // "c:\\Users\\steve\\onedrive\\Desktop\\testXML\\" + i + ".xml";
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(path, settings);
                writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

                writer.WriteStartElement("root");

                //HEADER PORTION
                writer.WriteStartElement("header");
                writer.WriteStartElement("id");
                //writer.WriteString("2"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteStartElement("title");
                //writer.WriteString("2"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteStartElement("description");
                //writer.WriteString("2"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteStartElement("enabled");
                writer.WriteString("1");
                writer.WriteFullEndElement();
                writer.WriteEndElement();
                //HEADER PORTION

                writer.WriteStartElement("gfx");
                writer.WriteStartElement("icon");
                //writer.WriteString("items/engines/engine_civilian.png"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("data");
                writer.WriteStartElement("type");
                writer.WriteString("2");
                writer.WriteFullEndElement();

                writer.WriteStartElement("shops");
                writer.WriteStartElement("shops_level");
                //writer.WriteString("1"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteStartElement("faction_filter");
                writer.WriteFullEndElement();
                writer.WriteStartElement("price");
                //writer.WriteString("0"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("flags");
                writer.WriteStartElement("flag");
                //writer.WriteString("civilian"); //TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("upgrades_max");
                writer.WriteString("0");
                writer.WriteFullEndElement();
                writer.WriteStartElement("upgrades");
                writer.WriteComment("none");
                writer.WriteEndElement();

                writer.WriteStartElement("requirements");
                writer.WriteComment("none"); //TO BE INSERTED
                writer.WriteEndElement();

                writer.WriteStartElement("effects");
                writer.WriteStartElement("effect");//TO BE INSERTED
                writer.WriteStartElement("effect_type");
                writer.WriteFullEndElement();
                writer.WriteStartElement("effect_base");
                writer.WriteFullEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteStartElement("item_data"); //TO BE INSERTED
                writer.WriteStartElement("durability");
                writer.WriteString("25000");
                writer.WriteFullEndElement();
                writer.WriteStartElement("trail_color");
                //writer.WriteString(""); /TO BE INSERTED
                writer.WriteFullEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement(); //rOOT

                writer.Close();

                var someExtraEnergy = "";
                var someExtraFuel = "";










                var randomres = GetRandomNumber(0, 3);
                var randomPropsFin = GetRandomNumber(0, 2);
                var ranForReactorPropsScrews = 1;// GetRandomNumber(0, 1);
                var resultsForRandomPropsArmor = GetRandomNumber(0, 2);

                //NO XML FILES ARE BEING GENERATED YET HERE.
                //NO XML FILES ARE BEING GENERATED YET HERE.
                //NO XML FILES ARE BEING GENERATED YET HERE.
                engine_combat_thrusters dualReactors = new engine_combat_thrusters();
                dualReactors.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                dualReactors.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                dualReactors.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);


                engine_thrusters singleReactor = new engine_thrusters();
                singleReactor.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                singleReactor.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                singleReactor.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                //NO XML FILES ARE BEING GENERATED YET HERE.
                //NO XML FILES ARE BEING GENERATED YET HERE.
                //NO XML FILES ARE BEING GENERATED YET HERE.




                engine_ion engine_ion = new engine_ion();
                engine_ion.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_ion.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_ion.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);

                engine_plasma engine_plasma = new engine_plasma();
                engine_plasma.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_plasma.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_plasma.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);

                engine_powerboss engine_powerboss = new engine_powerboss();
                engine_powerboss.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_powerboss.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_powerboss.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);

                engine_combat_thrustersadvanced engine_combat_thrustersadvanced = new engine_combat_thrustersadvanced();
                engine_combat_thrustersadvanced.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_combat_thrustersadvanced.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_combat_thrustersadvanced.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);

                engine_cruise engine_cruise = new engine_cruise();
                engine_cruise.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_cruise.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_cruise.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);



                engine_neutron engine_neutron = new engine_neutron();
                engine_neutron.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 3) + i, someExtraEnergy, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_neutron.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 4) + i, someExtraFuel, 0, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);
                engine_neutron.createPNG(newWidth, newHeight, (numberOfXMLToCreate * 5) + i, someExtraFuel, 1, randomres, randomPropsFin, ranForReactorPropsScrews, resultsForRandomPropsArmor);



            }


















            MessageBox.Show("XML File(s) created!");
            //writer.WriteComment("");
            //writer.WriteString(string.Empty);
        }

        private Random randomer = new Random();
        private object syncLocker = new object();
        public int RandomNumber(int min, int max)
        {
            lock (syncLocker)
            { // synchronize
                return randomer.Next(min, max);
            }
        }

        public void createGFXNode(XmlTextWriter writer)
        {
            writer.WriteStartElement("gfx");
            writer.WriteStartElement("icon");
            writer.WriteString("items/engines/engine_civilian.png");

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void createDATAnode(XmlTextWriter writer)
        {
            writer.WriteStartElement("data");
            writer.WriteEndElement();
        }

        public float GetDistance(PointF a, PointF b)
        {
            return (float)(Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)));
        }

        public float GetDistanceX(PointF a, PointF b)
        {
            return (float)(((a.X - b.X) * (a.X - b.X)));
        }

        public float GetDistanceY(PointF a, PointF b)
        {
            return (float)(((a.Y - b.Y) * (a.Y - b.Y)));
        }















        public PointF RotatePoint(PointF pointToRotate, PointF centerPoint, float angleInDegrees)
        {
            var angleInRadians = angleInDegrees * (Math.PI / 180);
            var cosTheta = Math.Cos(angleInRadians);
            var sinTheta = Math.Sin(angleInRadians);

            var newX = (float)(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X);
            var newY = (float)(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y);

            var newPos = new PointF(newX, newY);

            return newPos;
        }

        // Make random polygons inside the bounding rectangle.
        public Random rand = new Random();

        /*public PointF[] MakeRandomPolygon(int num_vertices, Rectangle bounds)
        {
            // Pick random radii.
            double[] radii = new double[num_vertices];
            const double min_radius = 0.5;
            const double max_radius = 1.0;
            for (int i = 0; i < num_vertices; i++)
            {
                radii[i] = NextDouble(rand,min_radius, max_radius);
            }

            // Pick random angle weights.
            double[] angle_weights = new double[num_vertices];
            const double min_weight = 1.0;
            const double max_weight = 10.0;
            double total_weight = 0;
            for (int i = 0; i < num_vertices; i++)
            {
                angle_weights[i] = NextDouble(rand,min_weight, max_weight);
                total_weight += angle_weights[i];
            }

            // Convert the weights into fractions of 2 * Pi radians.
            double[] angles = new double[num_vertices];
            double to_radians = 2 * Math.PI / total_weight;
            for (int i = 0; i < num_vertices; i++)
            {
                angles[i] = angle_weights[i] * to_radians;
            }

            // Calculate the points' locations.
            PointF[] points = new PointF[num_vertices];
            float rx = bounds.Width / 2f;
            float ry = bounds.Height / 2f;

            float cx = MidX(bounds);
            float cy = MidY(bounds);
            //float cx = bounds.MidX();
            //float cy = bounds.MidY();
            double theta = 0;
            for (int i = 0; i < num_vertices; i++)
            {
                points[i] = new PointF(
                    cx + (int)(rx * radii[i] * Math.Cos(theta)),
                    cy + (int)(ry * radii[i] * Math.Sin(theta)));
                theta += angles[i];
            }

            // Return the points.
            return points;
        }*/

        public double NextDouble(Random r, double lower, double upper, int scale = int.MaxValue - 1)
        {
            var d = lower + ((r.Next(scale + 1)) * (upper - lower) / scale);
            return d;
        }


        /*public Point Center(Rectangle rect)
        {
            return new Point(rect.MidX(), rect.MidY());
        }*/


        public double NextFloat(float min, float middle, float max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }          

        public int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(numericUpDown1.Value + " ");

            numberOfXMLToCreate = (int)numericUpDown1.Value;



            /*if (numericUpDown1.DecimalPlaces > 0)
            {
                numericUpDown1.DecimalPlaces = 0;
                numericUpDown1.Value = Decimal.Round(numericUpDown1.Value, 0);
            }
            else
            {
                numericUpDown1.DecimalPlaces = 2;
                numericUpDown1.Increment = 0.25M;
            }*/
            //numberOfXMLToCreate
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    
}





/*public PointF[] MakeHALFCIRCLE(int radius, int num_vertices, Rectangle bounds)
{
    PointF[] vertexList = new PointF[num_vertices];
    float x;
    float y;

    float cx = MidX(bounds);
    float cy = MidY(bounds);
    //vertexList.Add(new PointF(0, 0f));
    vertexList[0] = new PointF(0, 0f);
    for (int i = 0; i < num_vertices - 4; i++)
    {
        x = cx + (float)(radius * Math.Sin((2 * Math.PI * i) / num_vertices));
        y = cy + (float)(radius * Math.Cos((2 * Math.PI * i) / num_vertices));
        vertexList[i] = new PointF(x, y);
    }
    var xx = cx + (float)(radius * Math.Sin((2 * Math.PI * 5) / num_vertices));
    var yy = cy + (float)(radius * Math.Cos((2 * Math.PI * 5) / num_vertices));

    vertexList[vertexList.Length - 1] = new PointF(xx, yy);

    return vertexList;
}*/



/*public PointF[] MakeReactorEdge(int radius, int num_vertices, Rectangle bounds)
{
    PointF[] vertexList = new PointF[num_vertices];
    float x;
    float y;

    float cx = MidX(bounds);
    float cy = MidY(bounds);
    //vertexList.Add(new PointF(0, 0f));
    vertexList[0] = new PointF(0, 0f);
    for (int i = num_vertices - 7; i < num_vertices; i++)
    {
        x = cx + (float)(radius * Math.Sin((2 * Math.PI * i) / num_vertices));
        y = cy + (float)(radius * Math.Cos((2 * Math.PI * i) / num_vertices));
        vertexList[i] = new PointF(x, y);
    }

    var xx = cx + (float)(radius * Math.Sin((2 * Math.PI * 3) / num_vertices));
    var yy = cy + (float)(radius * Math.Cos((2 * Math.PI * 3) / num_vertices));
    vertexList[vertexList.Length - 1] = new PointF(xx, yy);

    return vertexList;
}*/





















































































/*//SPEED SYNONYMS
arrayOfSpeedSynonym[0] = "alacrity";
arrayOfSpeedSynonym[1] = "rapidity";
arrayOfSpeedSynonym[2] = "celerity";
arrayOfSpeedSynonym[3] = "speediness";
arrayOfSpeedSynonym[4] = "quickness";
arrayOfSpeedSynonym[5] = "flash";
arrayOfSpeedSynonym[6] = "speed";

//ACCELERATION SYNONYMS
arrayOfAccelerationSynonym[0] = "boost"; //trust//throttle
arrayOfAccelerationSynonym[0] = "expedite";
arrayOfAccelerationSynonym[0] = "quickeness";
arrayOfAccelerationSynonym[0] = "hastiness";
arrayOfAccelerationSynonym[0] = "throttling";
arrayOfAccelerationSynonym[0] = "promptness";
arrayOfAccelerationSynonym[0] = "precipitousness";
arrayOfAccelerationSynonym[0] = "acceleration";

//DECELERATION SYNONYMS
arrayOfDecelerationSynonym[0] = "slowing";
arrayOfDecelerationSynonym[0] = "deceleration";
arrayOfDecelerationSynonym[0] = "braking";*/





















/*static double NextFloat(float min,float middle,float max)
      {
          //double mantissa = (random.NextDouble() * 2.0) - 1.0;
          //double exponent = Math.Pow(2.0, random.Next(-126, 128));
          //return (float)(mantissa * exponent);

          Random rnd = new Random();
          double randomFloat = 0;

          for (var ctr = min; ctr < max; ctr++)
          {
              //randomFloat = ctr + rnd.NextDouble();
              randomFloat = ctr+(rnd.NextDouble() * (max - min) + min);

          }

          return randomFloat;
      }*/



//writer.WriteStartDocument(true);
//writer.WriteEndDocument();




//createNodeHeader(i + "", " This is an Energy Weapon from the" + " "  +".", "Energy Weapon", "1", writer);
/*private void createNodeHeader(string pID, string pTitle, string pDescription, string enabled, XmlTextWriter writer)
{
    writer.WriteStartElement("header");
    writer.WriteStartElement("id");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("title");
    writer.WriteString(pTitle);
    writer.WriteEndElement();
    writer.WriteStartElement("description");
    writer.WriteString(pDescription);
    writer.WriteEndElement();
    writer.WriteStartElement("enabled");
    writer.WriteString(enabled);
    writer.WriteEndElement();
    writer.WriteEndElement();
}*/















/*private void button2_Click(object sender, EventArgs e)
{
    Image firstImage0 = Image.FromFile(@"C:\Users\ninekorn\Desktop\LAYERS\PNG\DARKBLUE.png");
    Image firstImage1 = Image.FromFile(@"C:\Users\ninekorn\Desktop\LAYERS\PNG\BULLETION.png");
    Image firstImage2 = Image.FromFile(@"C:\Users\ninekorn\Desktop\LAYERS\PNG\WEAPONCIVILIAN.png");

    var target = new Bitmap(firstImage0.Width, firstImage0.Height, PixelFormat.Format32bppArgb);
    var graphics = Graphics.FromImage(target);

    int newWidth = 128;
    int newHeight = 128;

    Bitmap bmp = new Bitmap(firstImage1);

    for (int x = 0; x < bmp.Width; x++)
    {
        for (int y = 0; y < bmp.Height; y++)
        {
            Color gotColor = bmp.GetPixel(x, y);

            if (gotColor != Color.FromArgb(0, 0, 0, 0))
            {

                int a = 255;
                int r = gotColor.R;
                int g = gotColor.G;
                int b = gotColor.B;

                Color newColor = Color.FromArgb(a, r, g, b);
                bmp.SetPixel(x, y, newColor);
            }
        }
    }

    var graphics0 = Graphics.FromImage(firstImage0);
    var graphics1 = Graphics.FromImage(bmp);
    var graphics2 = Graphics.FromImage(firstImage2);

    graphics.DrawImage(firstImage0, new Rectangle(0, 0, newWidth, newHeight));
    graphics.DrawImage(bmp, new Rectangle(0, 0, newWidth, newHeight));
    graphics.DrawImage(firstImage2, new Rectangle(0, 0, newWidth, newHeight));

    target.Save(@"C:\Users\ninekorn\Desktop\LAYERS\PNG\newImage.png", System.Drawing.Imaging.ImageFormat.Png);
}*/







/*private string chooseBulletShotMode()
{
    weaponSize = new string[]
    {
        "bur",
        "one",
        "aut",
    };

    int arrayLength = weaponSize.Length;
    int index = GetRandomNumber(0, arrayLength);
    return weaponSize[index];
}*/







/*private bool predicate_FileMatch(string fileName)
       {
           if (fileName.EndsWith(".png"))
               return true;
           return false;
       }*/







/*private void button1_Click(object sender, EventArgs e)
{

    string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML18.xml";

    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = Encoding.UTF8;
    settings.Indent = true;
    XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
    //writer.WriteStartDocument(true);
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2;
    writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

    writer.WriteStartElement("root");
    createNode("1", "header", "", writer);
    writer.WriteEndElement();
    createNode("1", "gfx", "", writer);
    writer.WriteEndElement();
    createNode("3", "data", "", writer);
    writer.WriteEndElement();
    writer.Close();
    MessageBox.Show("XML File created ! ");

    /*createNode("1", "header", "", writer);
    writer.WriteEndElement();
    createNode("2", "gfx", "", writer);
    writer.WriteEndElement();
    createNode("3", "data", "", writer);
    writer.WriteEndElement();
    //writer.WriteEndElement();
    //writer.WriteEndDocument();
    writer.Close();
    MessageBox.Show("XML File created ! ");
}
private void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
{
    writer.WriteStartElement("header");
    writer.WriteStartElement("gfx");
    writer.WriteStartElement("data");

    writer.WriteString(pID);
    writer.WriteEndElement();

    //writer.WriteString(pID);
    //writer.WriteEndElement();

    writer.WriteStartElement("Product_name");
    writer.WriteString(pName);
    writer.WriteEndElement();
    writer.WriteStartElement("Product_price");
    writer.WriteString(pPrice);
    writer.WriteEndElement();
    writer.WriteEndElement();
}*/















//XmlDeclaration xmldecl;
//xmldecl = newDocument.CreateXmlDeclaration("1.0", null, null);
//xmldecl.Encoding = "UTF-8";

/*XmlDocument doc = new XmlDocument();
string xmlString = "<book><title>Oberon's Legacy</title></book>";
doc.Load(new StringReader(xmlString));

XmlDeclaration xmldecl;
xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
xmldecl.Encoding = "UTF-8";*/



// Add the new node to the document.
//XmlElement root = doc.DocumentElement;
//doc.InsertBefore(xmldecl, root);





//XmlDeclaration xmldecl;
//xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
//xmldecl.Encoding = "UTF-8";


/*XmlDocument doc = new XmlDocument();
string xmlString = "<book><title>Oberon's Legacy</title></book>";
doc.Load(new StringReader(xmlString));

string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML12.xml";
// Create an XML declaration. 
XmlDeclaration xmldecl;
xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
xmldecl.Encoding = "UTF-8";
//xmldecl.Standalone = "yes";

// Add the new node to the document.
XmlElement root = doc.DocumentElement;
doc.InsertBefore(xmldecl, root);

// Display the modified XML document 
//Console.WriteLine(doc.OuterXml);*/



//XmlDocument xDoc = new XmlDocument();

//String headerForXml = "<? xml version = '1.0' encoding = 'utf-8' ?> ";
//byte[] bytes = Encoding.Default.GetBytes(headerForXml);
//headerForXml = Encoding.UTF8.GetString(bytes);





/*string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML12.xml";
XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);



XmlWriterSettings settings = new XmlWriterSettings();
settings.OmitXmlDeclaration = true;




writer.Formatting = Formatting.Indented;
xDoc.Save(writer);*/


/*XmlDeclaration xDecl = xDoc.CreateXmlDeclaration("1.0", null, null);
if (xDoc.FirstChild.NodeType != null)
{
    if (xDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
    {
        xDoc.ReplaceChild(xDecl, xDoc.FirstChild);
    }
    else
    {
        xDoc.InsertBefore(xDecl, xDoc.DocumentElement);
    }
}*/



/*XmlDocument doc = new XmlDocument();
// Create a procesing instruction.
XmlProcessingInstruction newPI;
String PItext = "type='text/xsl' href='book.xsl'";
newPI = doc.CreateProcessingInstruction("xml-stylesheet", PItext);
// Display the target and data information.
//Console.WriteLine("<?{0} {1}?>", newPI.Target, newPI.Data);
// Add the processing instruction node to the document.
doc.AppendChild(newPI);*/


/*XmlDocument doc = new XmlDocument();
XmlProcessingInstruction newPI;
String PItext = "type='text/xsl' href='book.xsl'";
newPI = doc.CreateProcessingInstruction("xml-stylesheet", PItext);

string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML10.xml";
XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
//XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);

createNode("1", "Product 1", "1000", writer);
createNode("2", "Product 2", "2000", writer);
createNode("3", "Product 3", "3000", writer);
createNode("4", "Product 4", "4000", writer);*/


/*writer.WriteStartDocument(true);
writer.Formatting = Formatting.Indented;
writer.Indentation = 2;
writer.WriteStartElement("Table");
createNode("1", "Product 1", "1000", writer);
createNode("2", "Product 2", "2000", writer);
createNode("3", "Product 3", "3000", writer);
createNode("4", "Product 4", "4000", writer);
writer.WriteEndElement();
writer.WriteEndDocument();
writer.Close();
MessageBox.Show("XML File created ! ");*/


/*// Create the XmlDocument.
XmlDocument doc = new XmlDocument();
doc.LoadXml("<item><name>wrench</name></item>"); //Your string here

string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\XMLTEST01.xml";

// Save the document to a file and auto-indent the output.
XmlTextWriter writer = new XmlTextWriter(path, null);
writer.Formatting = Formatting.Indented;
doc.Save(writer);*/







/*private void button1_Click(object sender, EventArgs e)
{
    string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML.xml";
    XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
    writer.WriteStartDocument(true);
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2;
    writer.WriteStartElement("Table");
    createNode("1", "Product 1", "1000", writer);
    createNode("2", "Product 2", "2000", writer);
    createNode("3", "Product 3", "3000", writer);
    createNode("4", "Product 4", "4000", writer);
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();
    MessageBox.Show("XML File created ! ");


    // Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<item><name>wrench</name></item>"); //Your string here

    string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\XMLTEST01.xml";

    // Save the document to a file and auto-indent the output.
    XmlTextWriter writer = new XmlTextWriter(path, null);
    writer.Formatting = Formatting.Indented;
    doc.Save(writer);

}
private void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
{
    writer.WriteStartElement("Product");
    writer.WriteStartElement("Product_id");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("Product_name");
    writer.WriteString(pName);
    writer.WriteEndElement();
    writer.WriteStartElement("Product_price");
    writer.WriteString(pPrice);
    writer.WriteEndElement();
    writer.WriteEndElement();
}*/













//doc.Save("c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\");
//doc.Save("c:\\");


//XmlTextWriter writer = new XmlTextWriter(path, null);





/*XmlDocument doc = new XmlDocument();
XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
doc.AppendChild(docNode);

XmlNode productsNode = doc.CreateElement("products");
doc.AppendChild(productsNode);

XmlNode productNode = doc.CreateElement("product");
XmlAttribute productAttribute = doc.CreateAttribute("id");
productAttribute.Value = "01";
productNode.Attributes.Append(productAttribute);
productsNode.AppendChild(productNode);

XmlNode nameNode = doc.CreateElement("Name");
nameNode.AppendChild(doc.CreateTextNode("Java"));
productNode.AppendChild(nameNode);
XmlNode priceNode = doc.CreateElement("Price");
priceNode.AppendChild(doc.CreateTextNode("Free"));
productNode.AppendChild(priceNode);

// Create and add another product node.
productNode = doc.CreateElement("product");
productAttribute = doc.CreateAttribute("id");
productAttribute.Value = "02";
productNode.Attributes.Append(productAttribute);
productsNode.AppendChild(productNode);
nameNode = doc.CreateElement("Name");
nameNode.AppendChild(doc.CreateTextNode("C#"));
productNode.AppendChild(nameNode);
priceNode = doc.CreateElement("Price");
priceNode.AppendChild(doc.CreateTextNode("Free"));
productNode.AppendChild(priceNode);

doc.Save(Console.Out);     */









/*private void button1_Click(object sender, EventArgs e)
{


    string path = "c:\\Users\\ninekorn\\Desktop\\XMLTESTS\\testingXML20.xml";

    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = Encoding.UTF8;
    settings.Indent = true;
    XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
    //writer.WriteStartDocument(true);
    writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

    writer.Formatting = Formatting.Indented;
    writer.Indentation = 2;

    writer.WriteStartElement("root");
    createNodeHEADER("1000", "1000", "1000", writer);
    writer.WriteEndElement();
    //writer.WriteEndDocument();
    writer.Close();
    MessageBox.Show("XML File created !");
}

private void createNodeHEADER(string pID, string pName, string pPrice, XmlTextWriter writer)
{
    writer.WriteStartElement("header");
    writer.WriteString(pID);

    writer.WriteStartElement("id");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("title");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("description");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("enabled");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteEndElement();

    /*writer.WriteStartElement("gfx");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("description");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("enabled");
    writer.WriteString(pID);
    //writer.WriteEndElement();
    writer.WriteEndElement();
}


private void createNodeGFX(string pID, string pName, string pPrice, XmlTextWriter writer)
{

    writer.WriteStartElement("id");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("title");
    writer.WriteString(pID);
    writer.WriteEndElement();
    writer.WriteStartElement("description");
    writer.WriteString(pName);
    writer.WriteEndElement();
    writer.WriteStartElement("enabled");
    writer.WriteString(pPrice);
    //writer.WriteEndElement();
    writer.WriteEndElement();
}
*/
