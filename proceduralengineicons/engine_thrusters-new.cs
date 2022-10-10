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
    public class engine_thrusters
    {
        Random getrandom = new Random();
        public void createPNG(int newWidth, int newHeight, int i, int randomGeneratorOrTank, int isBasic, int resultForRandom, int resultForRandomPropsFin, int randForReactorPropsScrews, int resultForRandomPropsArmor,int resultForTank,int resultForTankGeneratorPipe)
        {





            //SC_Utilities someUtilities = new SC_Utilities();
            Image lightBlue = Image.FromFile(@"LAYERS\PNG\LIGHTBLUE.png");
            Image lightOrange = Image.FromFile(@"LAYERS\PNG\ORANGE.png");

            Image firstImage0 = Image.FromFile(@"LAYERS\PNG\GREY01.png");
            //Image firstImage0 = Image.FromFile(@"LAYERS\PNG\DARKBLUEE.png");
            Image whiteBackgroundWep = null;
            Image greyBackgroundWep = Image.FromFile(@"LAYERS\PNG\GREY.png");
            Image dgreyBackgroundWep0 = Image.FromFile(@"LAYERS\PNG\DARKGREY.png");
            Image dgreyBackgroundWep = Image.FromFile(@"LAYERS\PNG\DARKGREY02.png");
            Image orangeBackgroundWep = Image.FromFile(@"LAYERS\PNG\THRUSTERFIRE.png");
            Image copperPipeBackground = Image.FromFile(@"LAYERS\PNG\COPPERPIPE.png");
            //Image copperHeatBackground = Image.FromFile(@"LAYERS\PNG\COPPERHEAT.png");
            Image copperHeatBackground = Image.FromFile(@"LAYERS\PNG\COPPERHEAT01.png");
            Image someCircuitry = Image.FromFile(@"LAYERS\PNG\someCircuitry.png");
            Image circuitry01 = Image.FromFile(@"LAYERS\PNG\circuitry01.png");

            Image metalPlates = Image.FromFile(@"LAYERS\PNG\metalPlates.png");
            Image metalPlates01 = Image.FromFile(@"LAYERS\PNG\metalPlates01.png");

            Image circuitryVE = Image.FromFile(@"LAYERS\PNG\circuitryVE.png");


            if (resultForRandomPropsArmor == 1)
            {
                //whiteBackgroundWep = Image.FromFile(@"LAYERS\PNG\ArmorPlatingPale.png");
                whiteBackgroundWep = Image.FromFile(@"LAYERS\PNG\ArmorPlatingPale.png");
            }
            else
            {
                whiteBackgroundWep = Image.FromFile(@"LAYERS\PNG\test.png");
            }

            Image LIGHTVIOLET = null;// = Image.FromFile(@"LAYERS\PNG\LIGHTVIOLET.png");

            Color colPipeFuel = Color.FromArgb(255, 0, 0, 0);
            if (randomGeneratorOrTank == 0)
            {
                colPipeFuel = Color.FromArgb(200, 255, 255, 0);
                LIGHTVIOLET = Image.FromFile(@"LAYERS\PNG\ENERGY.png");
            }
            else if (randomGeneratorOrTank == 1)
            {
                colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                LIGHTVIOLET = Image.FromFile(@"LAYERS\PNG\FUEL.png");
            }
            else if (randomGeneratorOrTank == 2)
            {
                colPipeFuel = Color.FromArgb(200, 0, 255, 255);
                LIGHTVIOLET = Image.FromFile(@"LAYERS\PNG\SHIELD.png");
            }


            TextureBrush texture1 = new TextureBrush(LIGHTVIOLET);
            texture1.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            var graphics = Graphics.FromImage(firstImage0);
            var target = new Bitmap(24, 24, PixelFormat.Format32bppArgb);

            //REACTOR BODY
            Rectangle recter0 = new Rectangle(76, 52, newWidth, newHeight);

            //int randomer1 = GetRandomNumber(5, 10);
            //int randomer2 = GetRandomNumber(5, 10);
            //int randomer3 = GetRandomNumber(0, 5);
            //int randomer4 = GetRandomNumber(5, 10);

            //int randomer5 = GetRandomNumber(0, 5);
            //int randomer6 = GetRandomNumber(5, 9);
            //int randomer7 = GetRandomNumber(0, 5);
            //int randomer8 = GetRandomNumber(3, 7);

            int randomer1 = GetRandomNumber(0, 0);
            int randomer2 = GetRandomNumber(0, 0);
            int randomer3 = GetRandomNumber(0, 0);
            int randomer4 = GetRandomNumber(0, 0);

            int randomer5 = GetRandomNumber(0, 0);
            int randomer6 = GetRandomNumber(0, 0);
            int randomer7 = GetRandomNumber(0, 0);
            int randomer8 = GetRandomNumber(0, 0);

            var someOtherPoints = MakeReactorBody(randomer1, randomer2, randomer3, randomer4, randomer5, randomer6, randomer7, randomer8, recter0, resultForRandom);
            PointF centerPointReactorBody = Center(recter0);
            //REACTOR BODY

            //REACTOR BEFORE THRUSTER BEZIER CURVE
            TextureBrush texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
      


            var diffX = (int)Math.Abs(someOtherPoints[0].Y - someOtherPoints[someOtherPoints.Count-1].Y);
            var offsetX = (int)Math.Abs(someOtherPoints[0].X);

            var pointOffsetAX1 = someOtherPoints[0].X + 20;
            var pointOffsetAY1 = someOtherPoints[0].Y - 4;
            var pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            var pointOffsetBX1 = someOtherPoints[someOtherPoints.Count - 1].X + 20;
            var pointOffsetBY1 = someOtherPoints[someOtherPoints.Count - 1].Y + 4;
            var pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var pointerAX = someOtherPoints[0].X+4;
            var pointerAY = someOtherPoints[0].Y+4;
            PointF pointerA = new PointF(pointerAX, pointerAY);

            var pointerBX = someOtherPoints[someOtherPoints.Count - 1].X+4;
            var pointerBY = someOtherPoints[someOtherPoints.Count - 1].Y-4;
            PointF pointerB = new PointF(pointerBX, pointerBY);


            //BEZIER FOR START OF CIRCUITRY TO THE RIGHT
            var somePoints0 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            somePoints0.Reverse();
            var tempArray0 = new List<PointF>();
            var tempArray000 = new List<PointF>();

            for (int y = 0; y < somePoints0.Count; y++)
            {
                tempArray0.Add(somePoints0[y]);

                tempArray000.Add(somePoints0[y]);
            }









            /*var tempArray0 = new List<PointF>();
            var tempArray1 = new List<PointF>();
            var tempArray5 = new List<PointF>();
            for (int y = 0; y < somePoints0.Count; y++)
            {
                tempArray0.Add(somePoints0[y]);
                tempArray1.Add(somePoints0[y]);
                tempArray5.Add(somePoints0[y]);
            }*/

            /*for (int y = someOtherPoints.Count-1; y >=0; y--)
            {
                somePoints0.Add(someOtherPoints[y]);
            }*/


            pointOffsetAX1 = someOtherPoints[1].X - 24;
            pointOffsetAY1 = someOtherPoints[1].Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = someOtherPoints[4].X - 24;
            pointOffsetBY1 = someOtherPoints[4].Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

           
            //BEZIER THAT IS TO THE COMPLETE LEFT EDGE OF THE ENGINE PART.
            var somePoints5 = DrawBezier(0.1f, someOtherPoints[1], pointOffsetA, pointOffsetB, someOtherPoints[4]);

            /*var graphPather1 = new GraphicsPath();
            graphPather1.AddLines(somePoints5.ToArray());
            var col1 = Color.FromArgb(200, 255, 25, 25);
            var blackPen1 = new Pen(col1, 2);
            graphics.DrawPath(blackPen1, graphPather1);*/
            
            //somePoints0.Add(somePoints5[0]);
            //somePoints0.Add(somePoints5[1]);
            //somePoints0.Add(somePoints5[2]);

            var tempArray1 = new List<PointF>();

            tempArray1.Add(somePoints5[0]);
            tempArray1.Add(somePoints5[1]);
            tempArray1.Add(somePoints5[2]);

            //tempArray1.Add(tempArray0[tempArray0.Count-1]);


            pointOffsetAX1 = someOtherPoints[2].X + 28;
            pointOffsetAY1 = someOtherPoints[2].Y + 1;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = someOtherPoints[3].X + 28;
            pointOffsetBY1 = someOtherPoints[3].Y - 1;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            //BEZIER THAT IS TO THE COMPLETE RIGHT EDGE OF THE ENGINE.
            var somePoints2 = DrawBezier(0.1f, someOtherPoints[2], pointOffsetA, pointOffsetB, someOtherPoints[3]);

            somePoints0.Add(someOtherPoints[0]);
            somePoints0.Add(someOtherPoints[1]);
            somePoints0.Add(someOtherPoints[2]);





            var tempArray2 = new List<PointF>();

            //tempArray2.Add(someOtherPoints[0]);
            tempArray2.Add(someOtherPoints[1]);
            tempArray2.Add(someOtherPoints[2]);

            for (int y = 0; y < somePoints2.Count; y++)
            {
                somePoints0.Add(somePoints2[y]);                
            }

            somePoints0.Add(someOtherPoints[someOtherPoints.Count - 3]);
            somePoints0.Add(someOtherPoints[someOtherPoints.Count - 2]);
            somePoints0.Add(someOtherPoints[someOtherPoints.Count - 1]);


            var tempArray3 = new List<PointF>();

            tempArray3.Add(someOtherPoints[someOtherPoints.Count - 3]);
            tempArray3.Add(someOtherPoints[someOtherPoints.Count - 2]);
            //tempArray3.Add(someOtherPoints[someOtherPoints.Count - 1]);


            //somePoints0.Add(somePoints5[somePoints5.Count - 3]);
            //somePoints0.Add(somePoints5[somePoints5.Count - 2]);
            //somePoints0.Add(somePoints5[somePoints5.Count - 1]);

            var tempArray4 = new List<PointF>();

            //tempArray4.Add(tempArray0[0]);
            tempArray4.Add(somePoints5[somePoints5.Count - 3]);
            tempArray4.Add(somePoints5[somePoints5.Count - 2]);
            tempArray4.Add(somePoints5[somePoints5.Count - 1]);
             


            //REACTOR BODY TEXTURE FILL   
            graphics.FillPolygon(texture, somePoints0.ToArray());

            var col0 = Color.FromArgb(200, 25, 25, 25);
            var blackPen0 = new Pen(col0, 2);
            var graphPather0 = new GraphicsPath();

     
            //RIGHT EDGE OF REACTOR BODY
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints2.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);

            pointOffsetAX1 = someOtherPoints[1].X + 23;
            pointOffsetAY1 = someOtherPoints[1].Y - 8;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = someOtherPoints[4].X + 23;
            pointOffsetBY1 = someOtherPoints[4].Y + 8;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            //BEZIER THAT IS TO THE LEFT EDGE OF THE ENGINE PART.
            var somePoints6 = DrawBezier(0.1f, someOtherPoints[1], pointOffsetA, pointOffsetB, someOtherPoints[4]);


            var tempstuff000 = new List<PointF>();
            for (int y = 0; y < somePoints5.Count; y++)
            {
                tempstuff000.Add(somePoints5[y]);
            }

            for (int y = 0; y < somePoints6.Count; y++)
            {
                tempstuff000.Add(somePoints6[somePoints6.Count - 1 - y]);
            }




            var someRand = GetRandomNumber(0, 4);
            if (someRand == 0)
            {
                //someRand = 0;
            }
            else if (someRand == 1)
            {
                //someRand = 90;
                copperPipeBackground.RotateFlip(RotateFlipType.Rotate90FlipNone);
                metalPlates.RotateFlip(RotateFlipType.Rotate90FlipNone);
                metalPlates01.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (someRand == 2)
            {
                //someRand = 180;
                copperPipeBackground.RotateFlip(RotateFlipType.Rotate180FlipNone);
                metalPlates.RotateFlip(RotateFlipType.Rotate180FlipNone);
                metalPlates01.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (someRand == 3)
            {
                //someRand = 270;
                copperPipeBackground.RotateFlip(RotateFlipType.Rotate270FlipNone);
                metalPlates.RotateFlip(RotateFlipType.Rotate270FlipNone);
                metalPlates01.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }


            //circuitryVE = rotateImage(circuitryVE, 180);
            Bitmap resized = new Bitmap(circuitryVE, new Size(circuitryVE.Width / 3, circuitryVE.Height / 3));

            texture = new TextureBrush(dgreyBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempstuff000.ToArray());

            texture = new TextureBrush(resized);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempstuff000.ToArray());




            resized = new Bitmap(metalPlates, new Size(metalPlates.Width / 4, metalPlates.Height / 4));

            texture = new TextureBrush(resized);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempstuff000.ToArray());
            
            resized = new Bitmap(metalPlates01, new Size(metalPlates01.Width / 4, metalPlates01.Height / 4));

            texture = new TextureBrush(resized);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempstuff000.ToArray());
            
            var tempstuff00 = new List<PointF>();

            for (int y = 0; y < tempArray0.Count; y++)
            {
                tempstuff00.Add(tempArray0[y]);
            }

            for (int y = 0; y < tempArray1.Count; y++)
            {
                tempstuff00.Add(tempArray1[tempArray1.Count-1-y]);
            }

            for (int y = 0; y < somePoints6.Count; y++)
            {
                tempstuff00.Add(somePoints6[y]);
            }

            for (int y = 0; y < tempArray4.Count; y++)
            {
                tempstuff00.Add(tempArray4[tempArray4.Count-1-y]);
            }

            /*tempstuff00.Add(tempArray0[0]);
            //linkBETWEEN BODY AND START OF THRUSTER
            texture = new TextureBrush(greyBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempstuff00.ToArray());
            */

            /*//INSIDE CURVE FOR BODY ENGINE TO THE LEFT
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(tempArray000.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);
            */

            //OUTSIDE CURVE FOR BODY ENGINE TO THE LEFT
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints6.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);


            //CURVE BOTTOM
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(tempArray1.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);
            
            //BOTTOM HORIZONTAL
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(tempArray2.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);

            //TOP HORIZONTAL
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(tempArray3.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);
            
            //curveTOP
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(tempArray4.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);


            var tempArray6 = new List<PointF>();

            for (int y = 0; y < tempArray0.Count; y++)
            {
                tempArray6.Add(tempArray0[y]);
            }

            for (int y = 0; y < tempArray0.Count; y++)
            {
                var someNewPointX = tempArray0[tempArray0.Count - 1 - y].X - 20;
                tempArray6.Add(new PointF(someNewPointX, tempArray0[tempArray0.Count - 1 - y].Y));
            }
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            //graphics.DrawPath(blackPen0, graphPather0);

            texture = new TextureBrush(dgreyBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture, tempArray6.ToArray());
            graphics.DrawPolygon(blackPen0, tempArray6.ToArray());



            pointerAX = someOtherPoints[0].X - 20;
            pointerAY = someOtherPoints[0].Y + 4;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = someOtherPoints[someOtherPoints.Count - 1].X - 20;
            pointerBY = someOtherPoints[someOtherPoints.Count - 1].Y - 4;
            pointerB = new PointF(pointerBX, pointerBY);


            diffX = (int)Math.Abs(someOtherPoints[0].Y - someOtherPoints[someOtherPoints.Count - 1].Y);
            offsetX = (int)Math.Abs(someOtherPoints[0].X);

            pointOffsetAX1 = pointerA.X - 20;
            pointOffsetAY1 = pointerA.Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X - 20;
            pointOffsetBY1 = pointerB.Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

        
            //BEZIER FOR START OF CIRCUITRY TO THE RIGHT
            var somePoints7 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            /*//MIRROR CURVE OF CURVE tempArray0
            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints7.ToArray());
            col0 = Color.FromArgb(200, 255, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);
            */

            var tempArray7 = new List<PointF>();

            for (int y = 0; y < somePoints7.Count; y++)
            {
                //var someNewPointX = tempArray0[tempArray0.Count - 1 - y].X - 20;
                tempArray7.Add(somePoints7[y]);
            }

            for (int y = 0; y < tempArray0.Count; y++)
            {
                var someNewPointX = tempArray0[y].X - 20;
                tempArray0[y] = new PointF(someNewPointX, tempArray0[y].Y);
                tempArray7.Add(new PointF(someNewPointX, tempArray0[y].Y));
            }

            //THRUSTER FIRE
            orangeBackgroundWep = SetImageOpacity(orangeBackgroundWep, 1);
            TextureBrush texture888 = new TextureBrush(orangeBackgroundWep);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, tempArray7.ToArray());
            graphics.DrawPolygon(blackPen0, tempArray7.ToArray());
            //THRUSTER FIRE







            pointerAX = someOtherPoints[0].X - 40;
            pointerAY = someOtherPoints[0].Y + 12;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = someOtherPoints[someOtherPoints.Count - 1].X - 40;
            pointerBY = someOtherPoints[someOtherPoints.Count - 1].Y - 12;
            pointerB = new PointF(pointerBX, pointerBY);


            diffX = (int)Math.Abs(someOtherPoints[0].Y - someOtherPoints[someOtherPoints.Count - 1].Y);
            offsetX = (int)Math.Abs(someOtherPoints[0].X);

            pointOffsetAX1 = pointerA.X + 20;
            pointOffsetAY1 = pointerA.Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X + 20;
            pointOffsetBY1 = pointerB.Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            //BEZIER FOR START OF CIRCUITRY TO THE RIGHT
            var somePoints8 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints8.ToArray());
            col0 = Color.FromArgb(200, 255, 25, 25);
            blackPen0 = new Pen(col0, 2);
            //graphics.DrawPath(blackPen0, graphPather0);

            diffX = (int)Math.Abs(someOtherPoints[0].Y - someOtherPoints[someOtherPoints.Count - 1].Y);
            offsetX = (int)Math.Abs(someOtherPoints[0].X);

            pointOffsetAX1 = pointerA.X - 20;
            pointOffsetAY1 = pointerA.Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X - 20;
            pointOffsetBY1 = pointerB.Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var somePoints9 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            /*graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints7.ToArray());
            col0 = Color.FromArgb(255, 255, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);*/

            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);

            //THRUSTER FIRE

            /*pointerAX = somePoints8[0].X - 2;
            pointerAY = somePoints8[0].Y - 32;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = somePoints8[somePoints8.Count - 1].X - 2;
            pointerBY = somePoints8[somePoints8.Count - 1].Y + 32;
            pointerB = new PointF(pointerBX, pointerBY);

            pointOffsetAX1 = pointerA.X - 4;
            pointOffsetAY1 = pointerA.Y + 2;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X - 4;
            pointOffsetBY1 = pointerB.Y - 2;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var somePoints11 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            for (int y = 0; y < somePoints11.Count; y++)
            {
                tempArray12.Add(somePoints11[y]);
            }*/
            pointerAX = somePoints8[0].X - 2;
            pointerAY = somePoints8[0].Y - 32;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = somePoints8[somePoints8.Count - 1].X - 2;
            pointerBY = somePoints8[somePoints8.Count - 1].Y + 32;

            var differY = (int)Math.Abs(somePoints8[somePoints8.Count - 1].Y - somePoints8[0].Y);

            pointerAX = somePoints8[0].X - 12;
            pointerAY = somePoints8[0].Y - (differY/2);
            pointerA = new PointF(pointerAX, pointerAY);
            var tempArray12 = new List<PointF>();
            tempArray12.Add(somePoints7[0]);

            tempArray12.Add(pointerA);

            tempArray12.Add(somePoints7[somePoints7.Count - 1]);
            for (int y = 0; y < tempArray0.Count; y++)
            {
                tempArray12.Add(tempArray0[y]);
            }
            //THRUSTER FIRE

     


            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);




            //TRUSTER PANELS / FINS
            //TRUSTER PANELS / FINS
            //TRUSTER PANELS / FINS
            //TRUSTER PANELS / FINS
            texture = new TextureBrush(dgreyBackgroundWep0);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;


            var someListForThrusterPanels = new List<PointF>();
            someListForThrusterPanels.Add(tempArray7[21]);
            someListForThrusterPanels.Add(tempArray7[0]);
            someListForThrusterPanels.Add(tempArray7[1]);
            someListForThrusterPanels.Add(tempArray7[2]);
            someListForThrusterPanels.Add(tempArray7[3]);
            someListForThrusterPanels.Add(tempArray7[4]);
            someListForThrusterPanels.Add(tempArray7[5]);
            someListForThrusterPanels.Add(tempArray7[6]);
            //someListForThrusterPanels.Add(somePoints9[1]);
            //someListForThrusterPanels.Add(tempArray7[2]);
            someListForThrusterPanels.Add(somePoints9[4]);
            someListForThrusterPanels.Add(somePoints9[2]);
                      
            graphics.FillPolygon(texture, someListForThrusterPanels.ToArray());
            graphics.DrawPolygon(blackPen0, someListForThrusterPanels.ToArray());



            texture = new TextureBrush(dgreyBackgroundWep0);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            //TRUSTER PANELS / FINS
            someListForThrusterPanels = new List<PointF>();
            someListForThrusterPanels.Add(tempArray7[6]);
            someListForThrusterPanels.Add(tempArray7[7]);
            someListForThrusterPanels.Add(tempArray7[8]);
            someListForThrusterPanels.Add(tempArray7[9]);
            someListForThrusterPanels.Add(tempArray7[10]);
            someListForThrusterPanels.Add(somePoints9[9]);
            someListForThrusterPanels.Add(somePoints9[7]);

            graphics.FillPolygon(texture, someListForThrusterPanels.ToArray());
            graphics.DrawPolygon(blackPen0, someListForThrusterPanels.ToArray());




            //THRUSTER FIRE
            var lightOrangeBrush = SetImageOpacity(lightOrange, 0.15f);
            texture888 = new TextureBrush(lightOrangeBrush);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, tempArray12.ToArray());
            //THRUSTER FIRE




            differY = (int)Math.Abs(tempArray0[tempArray0.Count - 1].Y - tempArray0[0].Y);
            var differX = (int)Math.Abs(somePoints7[somePoints7.Count / 2].X - tempArray0[tempArray0.Count/2].X);



            pointerAX = tempArray0[0].X - (differX / 2);
            pointerAY = tempArray0[0].Y + (differY / 2) - 8;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = tempArray0[0].X - (differX / 2);
            pointerBY = tempArray0[tempArray0.Count - 1].Y - (differY / 2) + 8;
            pointerB = new PointF(pointerBX, pointerBY);




















            differY = (int)Math.Abs(somePoints8[somePoints8.Count - 1].Y - somePoints8[0].Y);

            pointerAX = somePoints8[0].X - 0;
            pointerAY = somePoints8[0].Y - (differY / 2);
            pointerA = new PointF(pointerAX, pointerAY);

            tempArray12 = new List<PointF>();




            System.Drawing.PointF pointnow = new System.Drawing.PointF(somePoints7[0].X - 0, somePoints7[0].Y - 18);
            somePoints7[0] = pointnow;
            tempArray12.Add(somePoints7[0]);


            tempArray12.Add(pointerA);

            pointnow = new System.Drawing.PointF(somePoints7[somePoints7.Count - 1].X - 0, somePoints7[somePoints7.Count - 1].Y + 18);
            somePoints7[somePoints7.Count - 1] = pointnow;
            tempArray12.Add(somePoints7[somePoints7.Count - 1]);


            //THRUSTER FIRE
            var lightBlueBrush = SetImageOpacity(lightBlue, 0.75f);
            texture888 = new TextureBrush(lightBlueBrush);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, tempArray12.ToArray());
            //THRUSTER FIRE


            var heightVertical = Math.Abs(Math.Abs(somePoints7[0].Y) - Math.Abs(somePoints7[somePoints7.Count - 1].Y));
            var widthHor = Math.Abs(Math.Abs(pointerA.X) - Math.Abs(somePoints7[somePoints7.Count - 1].X)) * 0.5f;

            RectangleF rectF = new RectangleF(somePoints7[somePoints7.Count - 1].X- ((widthHor+4) *0.5f), somePoints7[somePoints7.Count - 1].Y, widthHor, heightVertical);


            graphics.FillEllipse(texture888, rectF);



            //tempArray12 = new List<PointF>();
            //var tempPointForFireTop = new PointF(tempArray0[0].X, tempArray0[0].Y + (differY / 2) - 8);
            //var tempPointForFireBottom = new PointF(tempArray0[tempArray0.Count - 1].X, tempArray0[tempArray0.Count - 1].Y - (differY / 2) + 8);

            //tempArray12.Add(tempPointForFireTop);
            //tempArray12.Add(pointerA);
            //tempArray12.Add(tempPointForFireBottom);

            /*pointOffsetAX1 = pointerA.X + 18;
            pointOffsetAY1 = pointerA.Y - 1;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X + 18;
            pointOffsetBY1 = pointerB.Y + 1;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var somePoints13 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);




            //THRUSTER FIRE
            var lightBlueBrush = SetImageOpacity(lightBlue, 0.75f);
            texture888 = new TextureBrush(lightBlueBrush);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, somePoints13.ToArray());
            //THRUSTER FIRE*/


            /*
            pointOffsetAX1 = pointerA.X - 4;
            pointOffsetAY1 = pointerA.Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X - 4;
            pointOffsetBY1 = pointerB.Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            somePoints13 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);
            */


            /*
            //THRUSTER FIRE
            lightBlueBrush = SetImageOpacity(lightBlue, 0.75f);
            texture888 = new TextureBrush(lightBlueBrush);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, somePoints13.ToArray());
            //THRUSTER FIRE*/










            texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            //TRUSTER PANELS / FINS
            someListForThrusterPanels = new List<PointF>();
            someListForThrusterPanels.Add(tempArray7[15]);
            someListForThrusterPanels.Add(tempArray7[16]);
            someListForThrusterPanels.Add(tempArray7[17]);
            someListForThrusterPanels.Add(tempArray7[18]);
            someListForThrusterPanels.Add(tempArray7[19]);
            someListForThrusterPanels.Add(tempArray7[20]);
            someListForThrusterPanels.Add(tempArray7[21]);
            //someListForThrusterPanels.Add(somePoints9[1]);
            //someListForThrusterPanels.Add(tempArray7[2]);
            someListForThrusterPanels.Add(somePoints8[1]);
            someListForThrusterPanels.Add(somePoints8[4]);
            graphics.FillPolygon(texture, someListForThrusterPanels.ToArray());
            graphics.DrawPolygon(blackPen0, someListForThrusterPanels.ToArray());


            //TRUSTER PANELS / FINS
            texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            someListForThrusterPanels = new List<PointF>();
       
            pointOffsetAX1 = tempArray7[10].X + 2;
            pointOffsetAY1 = tempArray7[10].Y - 3;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = somePoints8[10].X - 2;
            pointOffsetBY1 = somePoints8[10].Y - 3;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var somePoints10 = DrawBezier(0.1f, tempArray7[10], pointOffsetA, pointOffsetB, somePoints8[10]);

            for (int y = 0; y < somePoints10.Count; y++)
            {
                someListForThrusterPanels.Add(somePoints10[y]);
            }
            someListForThrusterPanels.Add(somePoints8[10]);

            pointOffsetAX1 = tempArray7[15].X - 2;
            pointOffsetAY1 = tempArray7[15].Y - 1;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = somePoints8[7].X + 12;
            pointOffsetBY1 = somePoints8[7].Y - 1;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            //TRUSTER PANELS / FINS
            var someY = somePoints8[7].Y + 8;
            somePoints8[7] = new PointF(somePoints8[7].X, someY);
            someListForThrusterPanels.Add(somePoints8[7]);

            someListForThrusterPanels.Add(tempArray7[15]);
            someListForThrusterPanels.Add(tempArray7[14]);
            someListForThrusterPanels.Add(tempArray7[13]);
            someListForThrusterPanels.Add(tempArray7[12]);
            someListForThrusterPanels.Add(tempArray7[11]);
            someListForThrusterPanels.Add(tempArray7[10]);

            graphics.FillPolygon(texture, someListForThrusterPanels.ToArray());
            graphics.DrawPolygon(blackPen0, someListForThrusterPanels.ToArray());
            //TRUSTER PANELS / FINS









            /*graphPather0 = new GraphicsPath();
             graphPather0.AddLines(tempArray12.ToArray());
             col0 = Color.FromArgb(200, 255, 25, 25);
             blackPen0 = new Pen(col0, 2);
             graphics.DrawPath(blackPen0, graphPather0);*/
            /*pointerAX = somePoints8[0].X - 8;
            pointerAY = somePoints8[0].Y - 28;
            pointerA = new PointF(pointerAX, pointerAY);

            pointerBX = somePoints8[somePoints8.Count - 1].X - 8;
            pointerBY = somePoints8[somePoints8.Count - 1].Y + 28;
            pointerB = new PointF(pointerBX, pointerBY);

            pointOffsetAX1 = pointerA.X + 18;
            pointOffsetAY1 = pointerA.Y + 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = pointerB.X + 18;
            pointOffsetBY1 = pointerB.Y - 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            var somePoints12 = DrawBezier(0.1f, pointerA, pointOffsetA, pointOffsetB, pointerB);

            graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints12.ToArray());
            col0 = Color.FromArgb(200, 255, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);*/
















            /*orangeBackgroundWep = SetImageOpacity(orangeBackgroundWep, 1);
            TextureBrush texture888 = new TextureBrush(orangeBackgroundWep);
            texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            graphics.FillPolygon(texture888, tempArray8.ToArray());

            graphPath = new GraphicsPath();
            graphPath.AddLines(tempArray8.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 1);
            graphics.DrawPath(blackPen0, graphPath);

            graphPath = new GraphicsPath();
            graphPath.AddLines(tempArray6.ToArray());
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 1);
            graphics.DrawPath(blackPen0, graphPath);
            */

            /*graphPath = new GraphicsPath();
            //graphPath.AddLines(somePoints1.ToArray());

            pointOffsetAX1 = someOtherPoints[2].X + 12.5f;
            pointOffsetAY1 = someOtherPoints[2].Y +1;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = someOtherPoints[3].X + 12.5f;
            pointOffsetBY1 = someOtherPoints[3].Y -1;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);


            //BEZIER THAT IS TO THE COMPLETE RIGHT EDGE OF THE ENGINE.
            var somePoints2 = DrawBezier(0.1f, someOtherPoints[2], pointOffsetA, pointOffsetB, someOtherPoints[3]);

            graphPath = new GraphicsPath();
            graphPath.AddLines(somePoints2.ToArray());

            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPath);*/



            /*


            diffX = (int)Math.Abs(someOtherPoints[2].Y - someOtherPoints[3].Y);
            offsetX = (int)Math.Abs(someOtherPoints[2].X);

            texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            recter0 = new Rectangle(offsetX - (24 / 2) + 5, 64 - (diffX / 2), 16, diffX);
            graphics.FillEllipse(texture, recter0);


            texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            diffX = (int)Math.Abs(someOtherPoints[1].Y - someOtherPoints[4].Y);
            offsetX = (int)Math.Abs(someOtherPoints[1].X);

            pointOffsetAX1 = someOtherPoints[1].X + 12.5f;
            pointOffsetAY1 = someOtherPoints[1].Y - 4;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = someOtherPoints[4].X + 12.5f;
            pointOffsetBY1 = someOtherPoints[4].Y + 4;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);

            //BEZIER THAT IS TO THE COMPLETE LEFT EDGE OF THE ENGINE PART.
            var somePoints4 = DrawBezier(0.1f, someOtherPoints[1], pointOffsetA, pointOffsetB, someOtherPoints[4]);

            var graphPather0 = new GraphicsPath();
            graphPather0.AddLines(somePoints4.ToArray());

            for (int y = 0; y < somePoints4.Count; y++)
            {
                tempArray5.Add(somePoints4[y]);
            }
            ////////////////////////////////
            ////////////////////////////////
            ////////////////////////////////
            ////////////////////////////////
            List<PointF> listOfSomeEngineParts = new List<PointF>(); 

            for (int y = (somePoints4.Count-1); y >= somePoints4.Count / 2 ; y--)
            {
                var someX = somePoints4[y].X + 15;
                var someY = somePoints4[y].Y - 10;

                listOfSomeEngineParts.Add(new PointF(someX,someY));
            }

            var graphPathEngineParts = new GraphicsPath();
            graphPathEngineParts.AddLines(listOfSomeEngineParts.ToArray());
            col0 = Color.FromArgb(200, 255, 25, 25);
            blackPen0 = new Pen(col0, 1);
            graphics.DrawPath(blackPen0, graphPathEngineParts);

            ////////////////////////////////
            ////////////////////////////////
            ////////////////////////////////
            ////////////////////////////////













            //LINK TO REACTOR BODY
            //texture = new TextureBrush(dgreyBackgroundWep);
            //texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            //graphics.FillPolygon(texture, tempArray5.ToArray());
            //LINK TO REACTOR BODY



            //var graphPather1 = new GraphicsPath();
            //graphPather1.AddLines(tempArray5.ToArray());
            //col0 = Color.FromArgb(200, 255, 25, 25);
            //blackPen0 = new Pen(col0, 2);
            //graphics.DrawPath(blackPen0, graphPather1);


            //THRUSTER CIRCUITRY
            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 1);
            graphics.DrawPath(blackPen0, graphPather);
            //THRUSTER CIRCUITRY

            //col0 = Color.FromArgb(35, 35, 35, 35);
            //blackPen0 = new Pen(col0, 3);
            //graphics.DrawPath(blackPen0, graphPath);

            //col0 = Color.FromArgb(50, 25, 25, 25);
            //blackPen0 = new Pen(col0, 2);
            //graphics.DrawPath(blackPen0, graphPath);

            //col0 = Color.FromArgb(95, 25, 25, 25);
            //blackPen0 = new Pen(col0, 1);
            //graphics.DrawPath(blackPen0, graphPath);

            //left of body right before after the rivets
            col0 = Color.FromArgb(200, 25, 35, 35);
            blackPen0 = new Pen(col0, 3);
            graphics.DrawPath(blackPen0, graphPather0);

            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPather0);

            col0 = Color.FromArgb(200, 25, 25, 25);
            blackPen0 = new Pen(col0, 1);
            graphics.DrawPath(blackPen0, graphPather0);
            //left of body right before after the rivets















            //THRUSTER FIRE
            var topX = somePoints1[0].X - 2;
            var topY = somePoints1[0].Y;
            var somePtTop = new PointF(topX, topY);

            var bottomX = somePoints1[somePoints1.Count-1].X - 2;
            var bottomY = somePoints1[somePoints1.Count - 1].Y;
            var somePtBottom = new PointF(bottomX, bottomY);

            diffY = (int)Math.Abs(somePoints1[0].Y - somePoints1[somePoints1.Count - 1].Y);

            var midX = somePoints1[0].X - 18;
            var midY = somePoints1[0].Y - (diffY/2);
            var somePtMid = new PointF(midX, midY);
            orangeBackgroundWep = SetImageOpacity(orangeBackgroundWep, 0.45f);
            TextureBrush texture8888 = new TextureBrush(orangeBackgroundWep);
            texture8888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;       

            int diff = (int)Math.Abs(somePoints1[0].Y - somePoints1[somePoints1.Count-1].Y);
            pointOffsetAX1 = somePtTop.X + 9.5f;
            pointOffsetAY1 = somePtTop.Y + 1.5f;
            pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

            pointOffsetBX1 = somePtBottom.X + 9.5f;
            pointOffsetBY1 = somePtBottom.Y - 1.5f;
            pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);
            var somePoints3 = DrawBezier(0.01f, somePtTop, pointOffsetA, pointOffsetB, somePtBottom);
            somePoints3.Add(somePtMid);
            graphics.FillPolygon(texture8888, somePoints3.ToArray());
            //THRUSTER FIRE












            //////////////////////////////////////////////
            List<PointF> listOfExtent = new List<PointF>();
            for (int y = 0; y < somePoints4.Count; y++)
            {
                listOfExtent.Add(somePoints4[y]);
            }
            listOfExtent.Sort((x, y) =>
            {
                int compare = x.X.CompareTo(y.X);
                if (compare != 0)
                {
                    return compare;
                }
                return x.Y.CompareTo(y.Y);
            });

            var somePointA = listOfExtent[0];


            listOfExtent.Sort((x, y) =>
            {
                int compare = x.X.CompareTo(y.X);
                if (compare != 0)
                {
                    return compare;
                }
                return y.Y.CompareTo(x.Y);
            });

            var somePointB = listOfExtent[0];



            listOfExtent = new List<PointF>();
            for (int y = 0; y < somePoints2.Count; y++)
            {
                listOfExtent.Add(somePoints2[y]);
            }

            listOfExtent.Sort((x, y) =>
            {
                int compare = x.X.CompareTo(y.X);
                if (compare != 0)
                {
                    return compare;
                }
                return x.Y.CompareTo(y.Y);
            });

            var somePointC = listOfExtent[0];


            listOfExtent.Sort((x, y) =>
            {
                int compare = x.X.CompareTo(y.X);
                if (compare != 0)
                {
                    return compare;
                }
                return y.Y.CompareTo(x.Y);
            });

            var somePointD = listOfExtent[0];

            var someDistX = (int)Math.Abs(somePoints4[0].X - somePoints2[0].X) + 12;

            var somePointAX = somePointA.X + (someDistX / 2) + 12;
            var somePointAY = somePointA.Y + 8;
            somePointA = new PointF(somePointAX, somePointAY);

            var somePointBX = somePointB.X + (someDistX / 2) + 12;
            var somePointBY = somePointB.Y - 8;
            somePointB = new PointF(somePointBX, somePointBY);

            var somePointCX = somePointC.X - (someDistX / 2);
            var somePointCY = somePointC.Y + 8;
            somePointC = new PointF(somePointCX, somePointCY);

            var somePointDX = somePointD.X - (someDistX / 2);
            var somePointDY = somePointD.Y - 8;
            somePointD = new PointF(somePointDX, somePointDY);

            if (somePointD.Y < somePointB.Y)
            {
                somePointB.Y = somePointD.Y;
            }
            else
            {
                somePointD.Y = somePointB.Y;
            }

            if (somePointA.Y > somePointC.Y)
            {
                somePointC.Y = somePointA.Y;
            }
            else
            {
                somePointA.Y = somePointC.Y;
            }










            if (randForReactorPropsScrews == 1)
            {
                for (int y = 1; y < somePoints4.Count-1;y++)
                {
                    var someRectForScrewProps = new Rectangle((int)somePoints4[y].X+3, (int)somePoints4[y].Y-2, 3, 3);

                    texture = new TextureBrush(greyBackgroundWep);
                    texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    graphics.FillEllipse(texture, someRectForScrewProps);

                    var col1 = Color.FromArgb(255, 25, 25, 25);
                    var blackPen1 = new Pen(col1, 1);
                    graphics.DrawEllipse(blackPen1, someRectForScrewProps);

                    var screwPropCenter = Center(someRectForScrewProps); ;// somePoints4[y];// Center(someRectForScrewProps);

                    var screwPropTopAX = screwPropCenter.X;
                    var screwPropTopAY = screwPropCenter.Y - 2;
                    var screwPropTopA = new PointF(screwPropTopAX, screwPropTopAY);

                    var screwPropTopBX = screwPropCenter.X;
                    var screwPropTopBY = screwPropCenter.Y + 2;
                    var screwPropTopB = new PointF(screwPropTopBX, screwPropTopBY);

                    var lister = new List<PointF>();
                    lister.Add(screwPropTopA);
                    lister.Add(screwPropTopB);

                    GraphicsPath graphPatherScrews = new GraphicsPath();
                    graphPatherScrews.AddLines(lister.ToArray());
                    col1 = Color.FromArgb(150, 25, 25, 25);
                    blackPen1 = new Pen(col1, 1);
                    graphics.DrawPath(blackPen1, graphPatherScrews);

                    screwPropTopB.Y -= 2;
                    screwPropTopB.X += 2;

                    screwPropTopA.Y += 2;
                    screwPropTopA.X -= 2;

                    lister = new List<PointF>();
                    lister.Add(screwPropTopA);
                    lister.Add(screwPropTopB);

                    graphPatherScrews = new GraphicsPath();
                    graphPatherScrews.AddLines(lister.ToArray());
                    col1 = Color.FromArgb(150, 25, 25, 25);
                    blackPen1 = new Pen(col1, 1);
                    graphics.DrawPath(blackPen1, graphPatherScrews);
                }

                for (int y = 2; y < somePoints2.Count - 2; y++)
                {
                    var someRectForScrewProps = new Rectangle((int)somePoints2[y].X - 4, (int)somePoints2[y].Y - 2, 3, 3);

                    texture = new TextureBrush(greyBackgroundWep);
                    texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    graphics.FillEllipse(texture, someRectForScrewProps);

                    var col1 = Color.FromArgb(150, 25, 25, 25);
                    var blackPen1 = new Pen(col1, 1);
                    graphics.DrawEllipse(blackPen1, someRectForScrewProps);

                    var screwPropCenter = Center(someRectForScrewProps); ;// somePoints4[y];// Center(someRectForScrewProps);

                    var screwPropTopAX = screwPropCenter.X;
                    var screwPropTopAY = screwPropCenter.Y - 2;
                    var screwPropTopA = new PointF(screwPropTopAX, screwPropTopAY);

                    var screwPropTopBX = screwPropCenter.X;
                    var screwPropTopBY = screwPropCenter.Y + 2;
                    var screwPropTopB = new PointF(screwPropTopBX, screwPropTopBY);

                    var lister = new List<PointF>();
                    lister.Add(screwPropTopA);
                    lister.Add(screwPropTopB);

                    GraphicsPath graphPatherScrews = new GraphicsPath();
                    graphPatherScrews.AddLines(lister.ToArray());
                    col1 = Color.FromArgb(150, 25, 25, 25);
                    blackPen1 = new Pen(col1, 1);
                    graphics.DrawPath(blackPen1, graphPatherScrews);

                    screwPropTopB.Y -= 2;
                    screwPropTopB.X += 2;

                    screwPropTopA.Y += 2;
                    screwPropTopA.X -= 2;

                    lister = new List<PointF>();
                    lister.Add(screwPropTopA);
                    lister.Add(screwPropTopB);

                    graphPatherScrews = new GraphicsPath();
                    graphPatherScrews.AddLines(lister.ToArray());
                    col1 = Color.FromArgb(150, 25, 25, 25);
                    blackPen1 = new Pen(col1, 1);
                    graphics.DrawPath(blackPen1, graphPatherScrews);
                }
            }




            //GENERATOR OR TANK
            if (resultForTank == 1)
            {
                var someOffsetTankAX = somePointA.X + 0;
                var someOffsetTankAY= somePointA.Y + 7;
                var someOffsetTankA = new PointF(someOffsetTankAX, someOffsetTankAY);

                var someOffsetTankBX = somePointB.X + 0;
                var someOffsetTankBY = somePointB.Y - 7;
                var someOffsetTankB = new PointF(someOffsetTankBX, someOffsetTankBY);

                pointOffsetAX1 = someOffsetTankA.X + 1.35f;
                pointOffsetAY1 = someOffsetTankA.Y + 1.5f;
                pointOffsetA = new PointF(pointOffsetAX1, pointOffsetAY1);

                pointOffsetBX1 = someOffsetTankB.X + 1.35f;
                pointOffsetBY1 = someOffsetTankB.Y - 1.5f;
                pointOffsetB = new PointF(pointOffsetBX1, pointOffsetBY1);
                List<PointF> someOtherPts0 = DrawBezier(0.01f, someOffsetTankA, pointOffsetA, pointOffsetB, someOffsetTankB);

                //graphPath = new GraphicsPath();
                //graphPath.AddLines(someOtherPts0.ToArray());
                //col0 = Color.FromArgb(175, 255, 10, 10);
                //blackPen0 = new Pen(col0, 1);
                //.DrawPath(blackPen0, graphPath);


                var someOffsetTankCX = somePointC.X - 0;
                var someOffsetTankCY = somePointC.Y + 7;
                var someOffsetTankC = new PointF(someOffsetTankCX, someOffsetTankCY);

                var someOffsetTankDX = somePointD.X - 0;
                var someOffsetTankDY = somePointD.Y - 7;
                var someOffsetTankD = new PointF(someOffsetTankDX, someOffsetTankDY);
                



                var pointOffsetCX1 = someOffsetTankC.X + 1.35f;
                var pointOffsetCY1 = someOffsetTankC.Y + 1.5f;
                var pointOffsetC = new PointF(pointOffsetCX1, pointOffsetCY1);

                var pointOffsetDX1 = someOffsetTankD.X + 1.35f;
                var pointOffsetDY1 = someOffsetTankD.Y - 1.5f;
                var pointOffsetD = new PointF(pointOffsetDX1, pointOffsetDY1);

                List<PointF> someOtherPts1 = DrawBezier(0.01f, someOffsetTankC, pointOffsetC, pointOffsetD, someOffsetTankD);

                for (int y = someOtherPts1.Count - 1; y >= 0; y--)
                {
                    someOtherPts0.Add(someOtherPts1[y]);
                }


                //diffX = (int)Math.Abs(someOffsetTankA.X - someOffsetTankC.X);
                //diffY = (int)Math.Abs(someOffsetTankC.Y - someOffsetTankD.Y);
                //var someRectForTank = new Rectangle((int)someOffsetTankC.X+1, (int)someOffsetTankC.Y+1, diffX, diffY-2);

                //col0 = Color.FromArgb(255, 25, 25, 25);
                //blackPen0 = new Pen(col0, 3);
                //graphics.DrawRectangle(blackPen0, someRectForTank);




                graphics.FillPolygon(texture1, someOtherPts0.ToArray());

                col0 = Color.FromArgb(185, 25, 25, 25);
                blackPen0 = new Pen(col0, 2);
                graphics.DrawPolygon(blackPen0, someOtherPts0.ToArray());
                //GENERATOR OR TANK


       




                if (resultForTankGeneratorPipe == 1)
                {
                    var pointBottomer = somePoints4[somePoints4.Count - 1];
                    var pointTopper = somePoints4[0];
                    var diffYer = (int)Math.Abs(pointTopper.Y - pointBottomer.Y);

                    //REACTOR TRUSTER CONNECTOR
                    listOfExtent = new List<PointF>();
                    for (int y = 0; y < somePoints0.Count; y++)
                    {
                        listOfExtent.Add(somePoints0[y]);
                    }
                    listOfExtent.Sort((x, y) =>
                    {
                        int compare = y.X.CompareTo(x.X);
                        if (compare != 0)
                        {
                            return compare;
                        }
                        return x.Y.CompareTo(y.Y);
                    });



                    var someDistXX = (int)Math.Abs(listOfExtent[0].X - Center(recter1).X);
                    var someDistYY = (int)Math.Abs(somePoints0[0].Y - somePoints0[somePoints0.Count - 1].Y);



                    TextureBrush texture6 = new TextureBrush(dgreyBackgroundWep);
                    texture6.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                    //Rectangle recter6 = new Rectangle((int)(listOfExtent[0].X) + (someDistXX / 2), (int)Center(recter1).Y, 8, 8);
                    Rectangle recter6 = new Rectangle((int)somePoints4[0].X-2, (int)somePoints4[0].Y - (diffYer / 2), 8, 8);

                    int leftEdgeX = recter6.X - (recter6.Width / 2);
                    int rightEdgeX = recter6.X + (recter6.Width / 2);

                    int topEdgeY = recter6.Y - recter6.Height / 2;
                    int bottomEdgeY = (recter6.Y) + (recter6.Height / 2);

                    List<PointF> pointLister = new List<PointF>();
                    pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                    pointLister.Add(new PointF(leftEdgeX - 1, topEdgeY + 2));
                    pointLister.Add(new PointF(leftEdgeX, topEdgeY));
                    pointLister.Add(new PointF(rightEdgeX, topEdgeY));
                    pointLister.Add(new PointF(rightEdgeX + 2, topEdgeY + 2));
                    pointLister.Add(new PointF(rightEdgeX + 2, bottomEdgeY - 2));
                    pointLister.Add(new PointF(rightEdgeX, bottomEdgeY));
                    pointLister.Add(new PointF(leftEdgeX, bottomEdgeY));



                    someRand = GetRandomNumber(0, 360);

                    //copperPipeBackground = rotateImage(copperPipeBackground, someRand);

                    //Bitmap resized = new Bitmap(copperPipeBackground, new Size(copperPipeBackground.Width / 2, copperPipeBackground.Height / 2));

                    texture = new TextureBrush(copperPipeBackground);
                    texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    graphics.FillPolygon(texture6, pointLister.ToArray());
                    graphics.FillPolygon(texture, pointLister.ToArray());


                    pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                    GraphicsPath graphPath006 = new GraphicsPath();
                    graphPath006.AddLines(pointLister.ToArray());

                    Color col006 = Color.FromArgb(115, 10, 10, 10);
                    Pen blackPen006 = new Pen(col006, 2);
                    graphics.DrawPath(blackPen006, graphPath006);
                    //REACTOR TRUSTER CONNECTOR

                    //REACTOR BODY CONNECTOR
                    int someHeight = (int)Math.Abs(someOffsetTankC.Y - someOffsetTankD.Y);
                    int someWidth = (int)Math.Abs(someOffsetTankA.Y - someOffsetTankC.Y);
                    TextureBrush texture66 = new TextureBrush(dgreyBackgroundWep);
                    texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                    Rectangle recter66 = new Rectangle((int)(someOffsetTankA.X - (someWidth / 2))-14, (int)someOffsetTankA.Y + (someHeight / 2) - 5, 8, (someHeight / 2));

                    int leftEdgeX66 = recter66.X;
                    int rightEdgeX66 = recter66.X + recter66.Width;

                    int topEdgeY66 = recter66.Y;
                    int bottomEdgeY66 = recter66.Y + recter66.Height;

                    List<PointF> pointLister66 = new List<PointF>();
                    pointLister66.Add(new PointF(leftEdgeX66 - 1, bottomEdgeY66 - 2));
                    pointLister66.Add(new PointF(leftEdgeX66 - 1, topEdgeY66 + 2));
                    pointLister66.Add(new PointF(leftEdgeX66, topEdgeY66));
                    pointLister66.Add(new PointF(rightEdgeX66, topEdgeY66));
                    pointLister66.Add(new PointF(rightEdgeX66 + 2, topEdgeY66 + 2));
                    pointLister66.Add(new PointF(rightEdgeX66 + 2, bottomEdgeY66 - 2));
                    pointLister66.Add(new PointF(rightEdgeX66, bottomEdgeY66));
                    pointLister66.Add(new PointF(leftEdgeX66, bottomEdgeY66));


                    someRand = GetRandomNumber(0, 360);

                    //copperPipeBackground = rotateImage(copperPipeBackground, someRand);

                    //resized = new Bitmap(copperPipeBackground, new Size(copperPipeBackground.Width / 2, copperPipeBackground.Height / 2));

                    texture = new TextureBrush(copperPipeBackground);
                    texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    graphics.FillPolygon(texture6, pointLister66.ToArray());
                    graphics.FillPolygon(texture, pointLister66.ToArray());


                    pointLister66.Add(new PointF(leftEdgeX66 - 1, bottomEdgeY66 - 2));
                    GraphicsPath graphPath0066 = new GraphicsPath();
                    graphPath0066.AddLines(pointLister66.ToArray());

                    Color col0066 = Color.FromArgb(115, 10, 10, 10);
                    Pen blackPen0066 = new Pen(col0066, 2);
                    graphics.DrawPath(blackPen0066, graphPath0066);
                    //REACTOR BODY CONNECTOR

                    //REACTOR TRUSTER CONNECTOR ENTRANCE
                    Color col007 = Color.FromArgb(115, 10, 10, 10);
                    Pen blackPen007 = new Pen(col007, 1);
                    Rectangle recter77 = new Rectangle((int)somePoints4[0].X - 5, (int)somePoints4[0].Y - (diffYer/2)-3, 7, 7); //+ (recter6.Height / 2)

                    TextureBrush texture7 = new TextureBrush(dgreyBackgroundWep);
                    texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    //graphics.FillEllipse(Brushes.gre, recter7);
                    //REACTOR TRUSTER CONNECTOR ENTRANCE

                    //REACTOR BODY CONNECTOR ENTRANCE
                    Rectangle recter777 = new Rectangle((int)(Center(recter66).X - 3), (int)Center(recter66).Y - 4, 7, 7);
                    TextureBrush texture777 = new TextureBrush(dgreyBackgroundWep);
                    texture777.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                    blackPen0066 = new Pen(col0066, 1);

                    //REACTOR BODY CONNECTOR ENTRANCE

                    //REACTOR PIPES
                    Color colPipeDark = Color.FromArgb(150, 25, 25, 25);
                    //Color colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                    Color colPipeContour = Color.FromArgb(150, 35, 35, 35);

                    Pen blackPenPipe = new Pen(colPipeDark, 7);
                    Pen pipeContour = new Pen(colPipeContour, 5);
                    Pen whitePenPipe = new Pen(colPipeFuel, 3);

                    int totalWidth = (int)Math.Abs((int)Math.Abs(Center(recter77).X) - (int)Math.Abs(Center(recter777).X));
                    int totalHeight = (int)Math.Abs((int)Math.Abs(Center(recter77).Y) - (int)Math.Abs(Center(recter777).Y));

                    int randomer666 = GetRandomNumber(2, 15);
                    int randomer777 = GetRandomNumber(2, 15);
                    int randomer888 = GetRandomNumber(5, 35);
                    int randomer999 = GetRandomNumber(5, 35);

                    PointF test00 = new PointF(recter77.X + randomer666, recter77.Y + randomer888);
                    PointF test01 = new PointF(centerPointReactorBody.X - randomer777, Center(recter777).Y + randomer999);

                    DrawBezierDirect(graphics, blackPenPipe, 0.01f, Center(recter77), test00, test01, Center(recter777));
                    DrawBezierDirect(graphics, pipeContour, 0.01f, Center(recter77), test00, test01, Center(recter777));
                    DrawBezierDirect(graphics, whitePenPipe, 0.01f, Center(recter77), test00, test01, Center(recter777));
                    //REACTOR PIPES
                    graphics.FillEllipse(texture7, recter77);
                    graphics.DrawEllipse(blackPen007, recter77);
                    graphics.FillEllipse(texture777, recter777);
                    graphics.DrawEllipse(blackPen0066, recter777);
                }
            }*/
            //exportedToFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            firstImage0.Save(Program.VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG + @"\" + i + ".png", System.Drawing.Imaging.ImageFormat.Png); //"C:\\Users\\steve\\OneDrive\\Desktop\\testXML\\newImage"
        }

        public List<PointF> MakeReactorBody(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, int resultForRandom)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];
            float cx = MidX(bounds);
            float cy = MidY(bounds);

            /*vertexList.Add(new PointF(cx - 45 - rand5, cy + 20 - rand6));
            vertexList.Add(new PointF(cx - 35 + rand7, cy + 30 - rand8));
            vertexList.Add(new PointF(cx + 25 - rand3, cy + 30 - rand4));
            vertexList.Add(new PointF(cx + 25 - rand3, cy - 30 + rand4));
            vertexList.Add(new PointF(cx - 35 + rand7, cy - 30 + rand8));
            vertexList.Add(new PointF(cx - 45 - rand5, cy - 20 + rand6));*/

            if (resultForRandom == 0)
            {

                vertexList.Add(new PointF(cx - 30 - rand5, cy + 25 - rand6));
                vertexList.Add(new PointF(cx - 25 + rand7, cy + 35 - rand8));
                vertexList.Add(new PointF(cx + 15 - rand3, cy + 35 - rand4));
                vertexList.Add(new PointF(cx + 15 - rand3, cy - 35 + rand4));
                vertexList.Add(new PointF(cx - 25 + rand7, cy - 35 + rand8));
                vertexList.Add(new PointF(cx - 30 - rand5, cy - 25 + rand6));

            }
            else
            {
                vertexList.Add(new PointF(cx - 30 - rand5, cy + 25 + (rand6 / 3)));
                vertexList.Add(new PointF(cx - 25 + rand7, cy + 35 - rand8));
                vertexList.Add(new PointF(cx + 15 - rand3, cy + 35 - rand4));
                vertexList.Add(new PointF(cx + 15 - rand3, cy - 35 + rand4));
                vertexList.Add(new PointF(cx - 25 + rand7, cy - 35 + rand8));
                vertexList.Add(new PointF(cx - 30 - rand5, cy - 25 - (rand6 / 3)));

                /*//vertexList.Add(new PointF(cx - 35 + rand7, cy - 30 + rand8));
                vertexList.Add(new PointF(cx - 45 - rand5, cy - 20 + rand6));
                //vertexList.Add(new PointF(cx - 60 - rand5, cy - 20 - rand6));
                //vertexList.Add(new PointF(cx - 60 - rand5, cy + 20 + rand6));
                vertexList.Add(new PointF(cx - 45 - rand5, cy + 20 - rand6));
                vertexList.Add(new PointF(cx - 35 + rand7, cy + 30 - rand8));
                vertexList.Add(new PointF(cx + 25 - rand3, cy + 30 - rand4));
                vertexList.Add(new PointF(cx + 25 - rand3, cy - 30 + rand4));  */
            }













            /*if (resultForRandom == 0)
            {
                vertexList.Add(new PointF(cx - 20 + rand7, cy - 30 + rand8));
                vertexList.Add(new PointF(cx - 40 - rand5, cy - 20 + rand6));
                vertexList.Add(new PointF(cx - 40 - rand5, cy + 20 - rand6));
                vertexList.Add(new PointF(cx - 20 + rand7, cy + 30 - rand8));
                vertexList.Add(new PointF(cx + 20 - rand3, cy + 30 - rand4));
                vertexList.Add(new PointF(cx + 30 + rand1, cy + 20 - rand2));
                vertexList.Add(new PointF(cx + 30 + rand1, cy - 20 + rand2));
                vertexList.Add(new PointF(cx + 20 - rand3, cy - 30 + rand4));
            }
            else
            {
                vertexList.Add(new PointF(cx - 20 + rand7, cy - 30 + rand8));
                vertexList.Add(new PointF(cx - 40 - rand5, cy - 20 - rand6));
                vertexList.Add(new PointF(cx - 40 - rand5, cy + 20 + rand6));
                vertexList.Add(new PointF(cx - 20 + rand7, cy + 30 - rand8));
                vertexList.Add(new PointF(cx + 20 - rand3, cy + 30 - rand4));
                vertexList.Add(new PointF(cx + 30 + rand1, cy + 20 - rand2));
                vertexList.Add(new PointF(cx + 30 + rand1, cy - 20 + rand2));
                vertexList.Add(new PointF(cx + 20 - rand3, cy - 30 + rand4));
            }*/

            return vertexList;
        }

        /*public List<PointF> MakeReactorTruster(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, float someY, int resultForRandom)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];
            float cx = MidX(bounds);
            float cy = MidY(bounds);


            if (resultForRandom == 0)
            {
                vertexList.Add(new PointF(cx + 12, cy + (someY - 3) - rand1));
                vertexList.Add(new PointF(cx + 8 - rand5, cy + (someY) - rand1));
                vertexList.Add(new PointF(cx - 5 - rand5, cy + (someY) - rand1));
                vertexList.Add(new PointF(cx - 5 - rand5, cy - (someY) + rand1));
                //vertexList.Add(new PointF(cx + 8, cy - (someY) + rand1));
                vertexList.Add(new PointF(cx + 8 - rand5, cy - (someY) + rand1));
                vertexList.Add(new PointF(cx + 12, cy - (someY - 3) + rand1));
            }
            else
            {
                vertexList.Add(new PointF(cx + 12, cy + (someY - 3) + rand1));
                vertexList.Add(new PointF(cx + 8 - rand5, cy + (someY) + rand1));
                vertexList.Add(new PointF(cx - 5 - rand5, cy + (someY) + rand1));
                vertexList.Add(new PointF(cx - 5 - rand5, cy - (someY) - rand1));
                //vertexList.Add(new PointF(cx + 8, cy - (someY) + rand1));
                vertexList.Add(new PointF(cx + 8 - rand5, cy - (someY) - rand1));
                vertexList.Add(new PointF(cx + 12, cy - (someY - 3) - rand1));
            }
            return vertexList;
        }*/

        object syncLock = new object();
        public int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public int MidX(Rectangle rect)
        {
            return rect.Left + rect.Width / 2;
        }
        public int MidY(Rectangle rect)
        {
            return rect.Top + rect.Height / 2;
        }
        public float MidX(RectangleF rect)
        {
            return rect.Left + rect.Width / 2;
        }
        public float MidY(RectangleF rect)
        {
            return rect.Top + rect.Height / 2;
        }
        public PointF Center(RectangleF rect)
        {
            var midX = MidX(rect);
            var midY = MidY(rect);

            return new PointF(midX, midY);
        }

        private static float X(float t,
            float x0, float x1, float x2, float x3)
        {
            return (float)(
                x0 * Math.Pow((1 - t), 3) +
                x1 * 3 * t * Math.Pow((1 - t), 2) +
                x2 * 3 * Math.Pow(t, 2) * (1 - t) +
                x3 * Math.Pow(t, 3)
            );
        }
        private static float Y(float t,
            float y0, float y1, float y2, float y3)
        {
            return (float)(
                y0 * Math.Pow((1 - t), 3) +
                y1 * 3 * t * Math.Pow((1 - t), 2) +
                y2 * 3 * Math.Pow(t, 2) * (1 - t) +
                y3 * Math.Pow(t, 3)
            );
        }


        //http://csharphelper.com/blog/2014/12/draw-a-bezier-curve-by-hand-in-c/
        public List<PointF> DrawBezier(float dt, PointF pt0, PointF pt1, PointF pt2, PointF pt3)
        {
            // Draw the curve.
            List<PointF> points = new List<PointF>();
            for (float t = 0.0f; t < 1.0; t += dt)
            {
                points.Add(new PointF(
                    X(t, pt0.X, pt1.X, pt2.X, pt3.X),
                    Y(t, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));
            }

            // Connect to the final point.
            points.Add(new PointF(
                X(1.0f, pt0.X, pt1.X, pt2.X, pt3.X),
                Y(1.0f, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));

            return points;
            // Draw the curve.
            //gr.DrawLines(the_pen, points.ToArray());

            // Draw lines connecting the control points.
            //gr.DrawLine(Pens.Red, pt0, pt1);
            //gr.DrawLine(Pens.Green, pt1, pt2);
            //gr.DrawLine(Pens.Blue, pt2, pt3);
        }


        public void DrawBezierDirect(Graphics gr,Pen the_pen, float dt, PointF pt0, PointF pt1, PointF pt2, PointF pt3)
        {
            // Draw the curve.
            List<PointF> points = new List<PointF>();
            for (float t = 0.0f; t < 1.0; t += dt)
            {
                points.Add(new PointF(
                    X(t, pt0.X, pt1.X, pt2.X, pt3.X),
                    Y(t, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));
            }

            // Connect to the final point.
            points.Add(new PointF(
                X(1.0f, pt0.X, pt1.X, pt2.X, pt3.X),
                Y(1.0f, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));

            //return points;
            // Draw the curve.
            gr.DrawLines(the_pen, points.ToArray());

            // Draw lines connecting the control points.
            //gr.DrawLine(Pens.Red, pt0, pt1);
            //gr.DrawLine(Pens.Green, pt1, pt2);
            //gr.DrawLine(Pens.Blue, pt2, pt3);
        }








        //https://social.msdn.microsoft.com/Forums/en-US/2d3c907c-b2ae-4ae8-b589-3fd6b7dc308e/how-can-i-rotate-a-image-or-rectangle-in-every-angel-from-0-to-360?forum=csharplanguage
        private Image rotateImage(Image b, float angle)
        {
            int maxside = (int)(Math.Sqrt((b.Width * b.Width) + (b.Height * b.Height)));
            //create a new empty bitmap to hold rotated image

            Bitmap returnBitmap = new Bitmap(maxside, maxside);

            //make a graphics object from the empty bitmap

            Graphics g = Graphics.FromImage(returnBitmap);

            //move rotation point to center of image

            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object

            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;

        }





        //https://stackoverflow.com/questions/4779027/changing-the-opacity-of-a-bitmap-image
        public Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
