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
    public class engine_cruise
    {

        string DesktopFolderLoc = "";


        Random getrandom = new Random();
        public void createPNG(int newWidth, int newHeight, int i, string extraPower, int isBasic, int resultForRandom, int resultForRandomPropsFin, int randForReactorPropsScrews, int resultForRandomPropsArmor)
        {

            DesktopFolderLoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            Image firstImage0 = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\GREY.png");
            //Image firstImage0 = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKBLUEE.png");
            Image whiteBackgroundWep = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\WHITE.png");

            Image greyBackgroundWep = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\GREY.png");
            Image dgreyBackgroundWep = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKGREY.png");
            Image orangeBackgroundWep = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\ORANGE.png");
            Image blueBackgroundWep = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKBLUE.png");

            //ArmorPlating
            if (resultForRandomPropsArmor == 1)
            {
                whiteBackgroundWep = Image.FromFile(@"LAYERS\PNG\ArmorPlatingPale.png");
            }
            else
            {
                whiteBackgroundWep = Image.FromFile(@"LAYERS\PNG\WHITE.png");
            }





            var graphics = Graphics.FromImage(firstImage0);
            var target = new Bitmap(24, 24, PixelFormat.Format32bppArgb);





            //REACTOR BODY
            Rectangle recter0 = new Rectangle(76, 52, newWidth, newHeight);

            int randomer1 = GetRandomNumber(0, 5);
            int randomer2 = GetRandomNumber(5, 10);
            int randomer3 = GetRandomNumber(0, 5);
            int randomer4 = GetRandomNumber(5, 10);

            int randomer5 = GetRandomNumber(0, 5);
            int randomer6 = GetRandomNumber(3, 7);
            int randomer7 = GetRandomNumber(0, 5);
            int randomer8 = GetRandomNumber(3, 7);

            var someOtherPoints = MakeReactorBodyBOTTOM(randomer1, randomer2, randomer3, randomer4, randomer5, randomer6, randomer7, randomer8, recter0);

            TextureBrush texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            graphics.FillPolygon(texture, someOtherPoints.ToArray());

            someOtherPoints.Add(someOtherPoints[0]);
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddLines(someOtherPoints.ToArray());

            Color col0 = Color.FromArgb(115, 10, 10, 10);
            Pen blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPath);

            Color col1 = Color.FromArgb(100, 25, 25, 25);
            Pen blackPen1 = new Pen(col1, 2);
            graphics.DrawPath(blackPen1, graphPath);







            var someOtherPoints2 = MakeReactorBodyTOP(randomer1, randomer2, randomer3, randomer4, randomer5, randomer6, randomer7, randomer8, recter0);

            graphics.FillPolygon(texture, someOtherPoints2.ToArray());

            someOtherPoints2.Add(someOtherPoints2[0]);
            GraphicsPath graphPath2 = new GraphicsPath();
            graphPath2.AddLines(someOtherPoints2.ToArray());

            Color col2 = Color.FromArgb(115, 10, 10, 10);
            Pen blackPen2 = new Pen(col2, 2);
            graphics.DrawPath(blackPen2, graphPath2);

            Color col3 = Color.FromArgb(100, 25, 25, 25);
            Pen blackPen3 = new Pen(col3, 2);
            graphics.DrawPath(blackPen3, graphPath2);
            //REACTOR BODY




















            //MakeReactorBodyMIDDLE
            var someOtherPoints5 = MakeReactorBodyMIDDLE(randomer1, randomer2, randomer3, randomer4, randomer5, randomer6, randomer7, randomer8, recter0);

            texture = new TextureBrush(whiteBackgroundWep);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            graphics.FillPolygon(texture, someOtherPoints5.ToArray());

            someOtherPoints5.Add(someOtherPoints5[0]);
            graphPath = new GraphicsPath();
            graphPath.AddLines(someOtherPoints5.ToArray());

            col0 = Color.FromArgb(115, 10, 10, 10);
            blackPen0 = new Pen(col0, 2);
            graphics.DrawPath(blackPen0, graphPath);

            col1 = Color.FromArgb(100, 25, 25, 25);
            blackPen1 = new Pen(col1, 2);
            graphics.DrawPath(blackPen1, graphPath);
            //MakeReactorBodyMIDDLE

























            //if (isBasic == 1)
            {
                //REACTOR FUEL GAUGE BOTTOM
                var tester = someOtherPoints;

                tester.Sort((x, y) =>
                {
                    int compare = x.X.CompareTo(y.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return x.Y.CompareTo(y.Y);
                });

                var pointA = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = y.X.CompareTo(x.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return x.Y.CompareTo(y.Y);
                });

                var pointB = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = y.X.CompareTo(x.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return y.Y.CompareTo(x.Y);
                });

                var pointC = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = x.X.CompareTo(y.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return y.Y.CompareTo(x.Y);
                });

                var pointD = tester[0];

                if (pointB.Y < pointA.Y)
                {
                    pointB.Y = pointA.Y;
                }
                else
                {
                    pointA.Y = pointB.Y;
                }

                if (pointC.Y < pointD.Y)
                {
                    pointD.Y = pointC.Y;
                }
                else
                {
                    pointC.Y = pointD.Y;
                }

                int randomer001 = GetRandomNumber(10, 25);
                int randomer002 = GetRandomNumber(10, 25);
                int randomer003 = GetRandomNumber(2, 5);
                int randomer004 = GetRandomNumber(5, 15);

                pointC.X -= randomer002;
                pointB.X -= randomer002;
                pointA.X += randomer001;
                pointD.X += randomer001;

                pointA.Y += randomer003 + 3;
                pointB.Y += randomer003 + 3;
                pointC.Y -= randomer003 - 3;
                pointD.Y -= randomer003 - 3;

                int offSetY001 = 0;
                int offSetY002 = 0;
                int offSetY003 = 0;
                int offSetY004 = 0;

                int randomer0001 = 0;// GetRandomNumber(5, 10);


                if ((int)Math.Abs(pointD.Y - pointA.Y) <= 4)
                {
                    pointD.Y += 4;
                    pointA.Y -= 4;
                }

                if ((int)Math.Abs(pointB.Y - pointC.Y) <= 4)
                {
                    pointB.Y -= 4;
                    pointC.Y += 4;
                }

                int someTesterer = (int)Math.Abs(pointD.Y - pointA.Y) / 2;
                if (someTesterer > 10)
                {
                    randomer0001 = GetRandomNumber(5, 9);
                    offSetY001 = randomer0001;
                }
                else if (someTesterer > 5 && someTesterer <= 10)
                {
                    randomer0001 = GetRandomNumber(2, 4);
                    offSetY001 = randomer0001;
                }
                else
                {
                    offSetY001 = randomer0001;
                    // Math.Abs(pointD.Y- pointA.Y);
                }

                PointF pointE = pointC;
                pointE.X += 5;
                pointE.Y -= offSetY001;

                PointF pointF = pointB;
                pointF.X += 5;
                pointF.Y += offSetY001;

                PointF pointG = pointA;
                pointG.X -= 5;
                pointG.Y += offSetY001;

                PointF pointH = pointD;
                pointH.X -= 5;
                pointH.Y -= offSetY001;

                var somePointers = new List<PointF>();
                somePointers.Add(pointC);
                somePointers.Add(pointE);
                somePointers.Add(pointF);
                somePointers.Add(pointB);
                somePointers.Add(pointA);
                somePointers.Add(pointG);
                somePointers.Add(pointH);
                somePointers.Add(pointD);

                Image LIGHTVIOLET = null;// = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTVIOLET.png");
                Color colPipeFuel = Color.FromArgb(255, 0, 0, 0);
                if (extraPower == "energy")
                {
                    if (resultForRandom == 0)
                    {
                        colPipeFuel = Color.FromArgb(200, 0, 0, 205);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKBLUE.png");
                    }
                    else if (resultForRandom == 1)
                    {
                        colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTVIOLET.png");
                    }
                    else
                    {
                        colPipeFuel = Color.FromArgb(200, 35, 35, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTRED.png");
                    }

                }
                else if (extraPower == "fuel")
                {
                    if (resultForRandom == 0)
                    {
                        colPipeFuel = Color.FromArgb(200, 0, 0, 205);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKBLUE.png");
                    }
                    else if (resultForRandom == 1)
                    {
                        colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTVIOLET.png");
                    }
                    else
                    {
                        colPipeFuel = Color.FromArgb(200, 35, 35, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTRED.png");
                    }
                }
                else
                {
                    if (resultForRandom == 0)
                    {
                        colPipeFuel = Color.FromArgb(200, 0, 0, 205);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\DARKBLUE.png");
                    }
                    else if (resultForRandom == 1)
                    {
                        colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTVIOLET.png");
                    }
                    else
                    {
                        colPipeFuel = Color.FromArgb(200, 35, 35, 128);
                        LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTRED.png");
                    }
                }








                TextureBrush texture1 = new TextureBrush(LIGHTVIOLET);
                graphics.FillPolygon(texture1, somePointers.ToArray());

                somePointers.Add(pointC);
                GraphicsPath graphPath001 = new GraphicsPath();
                graphPath001.AddLines(somePointers.ToArray());

                Color col002 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen002 = new Pen(col002, 2);
                graphics.DrawPath(blackPen002, graphPath001);

                int centerXBottom = (int)Math.Abs(pointC.X - pointA.X);
                int centerYBottom = (int)Math.Abs(pointB.Y - pointD.Y);
                PointF pointCenterBottom = new PointF(pointA.X + (centerXBottom / 2), pointB.Y + (centerYBottom / 2));
                //REACTOR FUEL GAUGE BOTTOM

                //REACTOR BODY CONNECTOR BOTTOM
                int someHeight = (int)Math.Floor(Math.Abs(pointA.Y - pointC.Y));
                TextureBrush texture66 = new TextureBrush(greyBackgroundWep);
                texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                Rectangle recter66 = new Rectangle((int)(pointCenterBottom.X - 4), (int)(pointCenterBottom.Y - ((someHeight) / 2)), 8, someHeight);

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

                graphics.FillPolygon(texture66, pointLister66.ToArray());

                pointLister66.Add(new PointF(leftEdgeX66 - 1, bottomEdgeY66 - 2));
                GraphicsPath graphPath0066 = new GraphicsPath();
                graphPath0066.AddLines(pointLister66.ToArray());

                Color col0066 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen0066 = new Pen(col0066, 2);
                graphics.DrawPath(blackPen0066, graphPath0066);
                //REACTOR BODY CONNECTOR BOTTOM






                int centerXTop0 = (int)Math.Abs(pointC.X - pointA.X);
                int centerYTop0 = (int)Math.Abs(pointB.Y - pointD.Y);
                PointF pointCenterTop0 = new PointF(pointA.X + (centerXTop0 / 2), pointB.Y + (centerYTop0 / 2));
                //REACTOR FUEL GAUGE TOP


                //REACTOR BODY CONNECTOR TOP
                someHeight = (int)Math.Floor(Math.Abs(pointA.Y - pointC.Y));
                //texture66 = new TextureBrush(greyBackgroundWep);
                //texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                var recter1 = new Rectangle((int)(someOtherPoints[1].X - 23), (int)(pointCenterTop0.Y - ((someHeight) / 2)), newWidth, newHeight);








                int pointcenterb = recter0.Bottom + (recter0.Height / 2);

                //REACTOR THRUSTER BOTTOM
                //Rectangle recter1 = new Rectangle((int)(someOtherPoints[1].X - 23), (int)(pointCenterBottom.Y - ((someHeight) / 2)), newWidth, newHeight);

                int randomer11 = GetRandomNumber(2, 3);
                int randomer22 = GetRandomNumber(2, 3);
                int randomer33 = GetRandomNumber(2, 3);
                int randomer44 = GetRandomNumber(2, 3);

                int randomer55 = GetRandomNumber(2, 3);
                int randomer66 = GetRandomNumber(0, 0);
                int randomer77 = GetRandomNumber(2, 3);
                int randomer88 = GetRandomNumber(0, 0);

                var someOtherPoints1 = MakeReactorTrusterBOTTOM(randomer11, randomer22, randomer33, randomer44, randomer55, randomer66, randomer77, randomer88, recter1, (int)(pointCenterBottom.Y - ((someHeight) / 2)), recter0);

                TextureBrush texture0 = new TextureBrush(whiteBackgroundWep);
                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillPolygon(texture0, someOtherPoints1.ToArray());

                someOtherPoints1.Add(someOtherPoints1[0]);
                GraphicsPath graphPath1 = new GraphicsPath();
                graphPath1.AddLines(someOtherPoints1.ToArray());

                col2 = Color.FromArgb(115, 10, 10, 10);
                blackPen2 = new Pen(col2, 2);
                graphics.DrawPath(blackPen2, graphPath1);

                col3 = Color.FromArgb(100, 25, 25, 25);
                blackPen3 = new Pen(col3, 2);
                graphics.DrawPath(blackPen3, graphPath1);

                PointF centerPointReactorThrusterBOTTOM = Center(recter1);
                //REACTOR THRUSTER BOTTOM
















                //REACTOR TRUSTER CONNECTOR BOTTOM
                TextureBrush texture6 = new TextureBrush(greyBackgroundWep);
                texture6.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                Rectangle recter6 = new Rectangle((int)(centerPointReactorThrusterBOTTOM.X - 4), (int)(pointCenterBottom.Y - ((someHeight) / 2)), 8, 8);

                PointF centerPointReactorThrusterBOTTOMForPIPE = Center(recter6);

                int leftEdgeX = recter6.X;
                int rightEdgeX = recter6.X + recter6.Width;

                int topEdgeY = recter6.Y;
                int bottomEdgeY = recter6.Y + recter6.Height;

                List<PointF> pointLister = new List<PointF>();
                pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                pointLister.Add(new PointF(leftEdgeX - 1, topEdgeY + 2));
                pointLister.Add(new PointF(leftEdgeX, topEdgeY));
                pointLister.Add(new PointF(rightEdgeX, topEdgeY));
                pointLister.Add(new PointF(rightEdgeX + 2, topEdgeY + 2));
                pointLister.Add(new PointF(rightEdgeX + 2, bottomEdgeY - 2));
                pointLister.Add(new PointF(rightEdgeX, bottomEdgeY));
                pointLister.Add(new PointF(leftEdgeX, bottomEdgeY));

                graphics.FillPolygon(texture6, pointLister.ToArray());

                pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                GraphicsPath graphPath006 = new GraphicsPath();
                graphPath006.AddLines(pointLister.ToArray());

                Color col006 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen006 = new Pen(col006, 2);
                graphics.DrawPath(blackPen006, graphPath006);
                //REACTOR TRUSTER CONNECTOR BOTTOM


                //REACTOR PIPES
                Color colPipeDark = Color.FromArgb(150, 25, 25, 25);
                //Color colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                Color colPipeContour = Color.FromArgb(150, 35, 35, 35);

                Pen blackPenPipe = new Pen(colPipeDark, 7);
                Pen pipeContour = new Pen(colPipeContour, 5);
                Pen whitePenPipe = new Pen(colPipeFuel, 3);

                int totalWidth = (int)Math.Abs((int)Math.Abs(centerPointReactorThrusterBOTTOMForPIPE.X) - (int)Math.Abs(centerPointReactorThrusterBOTTOMForPIPE.X));
                int totalHeight = (int)Math.Abs((int)Math.Abs(centerPointReactorThrusterBOTTOMForPIPE.Y) - (int)Math.Abs(centerPointReactorThrusterBOTTOMForPIPE.Y));

                int randomer666 = GetRandomNumber(2, 15);
                int randomer777 = GetRandomNumber(2, 15);
                int randomer888 = GetRandomNumber(5, 35);
                int randomer999 = GetRandomNumber(5, 35);

                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                PointF test00 = new PointF(centerPointReactorThrusterBOTTOMForPIPE.X + randomer666, centerPointReactorThrusterBOTTOMForPIPE.Y + randomer888);
                PointF test01 = new PointF(pointCenterBottom.X - randomer777, pointCenterBottom.Y + randomer999);

                DrawBezier(graphics, blackPenPipe, 0.01f, centerPointReactorThrusterBOTTOMForPIPE, test00, test01, pointCenterBottom);
                DrawBezier(graphics, pipeContour, 0.01f, centerPointReactorThrusterBOTTOMForPIPE, test00, test01, pointCenterBottom);
                DrawBezier(graphics, whitePenPipe, 0.01f, centerPointReactorThrusterBOTTOMForPIPE, test00, test01, pointCenterBottom);
                //REACTOR PIPES




                //REACTOR TRUSTER CONNECTOR ENTRANCE
                Color col007 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen007 = new Pen(col007, 1);
                Rectangle recter77 = new Rectangle((int)(centerPointReactorThrusterBOTTOMForPIPE.X - 3), (int)(pointCenterBottom.Y - ((someHeight) / 2)), 7, 7);

                TextureBrush texture7 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture7, recter77);
                graphics.DrawEllipse(blackPen007, recter77);
                //graphics.FillEllipse(Brushes.gre, recter7);
                //REACTOR TRUSTER CONNECTOR ENTRANCE





                //REACTOR BODY CONNECTOR ENTRANCE
                Rectangle recter777 = new Rectangle((int)(pointCenterBottom.X - 3), (int)pointCenterBottom.Y - 4, 7, 7);
                TextureBrush texture777 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture777, recter777);
                graphics.DrawEllipse(blackPen007, recter777);
                //REACTOR BODY CONNECTOR ENTRANCE BOTTOM






                //THRUSTER FIRE BOTTOM
                TextureBrush texture888 = new TextureBrush(orangeBackgroundWep);
                texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                int diff = (int)Math.Abs(someOtherPoints1[0].Y - someOtherPoints1[2].Y);

                List<PointF> pointList888 = new List<PointF>();

                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterBOTTOM.Y - 8 - (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterBOTTOM.Y - 8 + (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1 - 19, (int)centerPointReactorThrusterBOTTOM.Y - 8));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterBOTTOM.Y - 8 - (diff / 2)));
                graphics.FillPolygon(texture888, pointList888.ToArray());













                //REACTOR THRUSTER MIDDLE

                int pointcenter = recter0.Bottom + (recter0.Height / 2);

              
                Rectangle recter1m = new Rectangle((int)(someOtherPoints[1].X - 42), (int)(pointcenter - ((someHeight) / 2)), newWidth, newHeight);

                int randomer11m = GetRandomNumber(5, 9);
                int randomer22m = GetRandomNumber(5, 9);
                int randomer33m = GetRandomNumber(5, 9);
                int randomer44m = GetRandomNumber(5, 9);

                int randomer55m = GetRandomNumber(5, 9);
                int randomer66m = GetRandomNumber(0, 0);
                int randomer77m = GetRandomNumber(5, 9);
                int randomer88m = GetRandomNumber(0, 0);

                int randomer111m = GetRandomNumber(0, 9);

                var someOtherPoints1m = MakeReactorTrusterMIDDLE(randomer111m, randomer22m, randomer33m, randomer44m, randomer55m, randomer66m, randomer77m, randomer88m, recter1m, (int)(pointcenter - ((someHeight) / 2)), recter0);

                TextureBrush texture0m = new TextureBrush(whiteBackgroundWep);
                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillPolygon(texture0m, someOtherPoints1m.ToArray());

                someOtherPoints1m.Add(someOtherPoints1m[0]);
                GraphicsPath graphPath1m = new GraphicsPath();
                graphPath1m.AddLines(someOtherPoints1m.ToArray());

                col2 = Color.FromArgb(115, 10, 10, 10);
                blackPen2 = new Pen(col2, 2);
                graphics.DrawPath(blackPen2, graphPath1m);

                col3 = Color.FromArgb(100, 25, 25, 25);
                blackPen3 = new Pen(col3, 2);
                graphics.DrawPath(blackPen3, graphPath1m);

                PointF centerPointReactorThrusterMIDDLE = Center(recter0);
                //REACTOR THRUSTER MIDDLE







                //THRUSTER FIRE MIDDLE
                texture888 = new TextureBrush(orangeBackgroundWep);
                texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                diff = (int)Math.Abs(someOtherPoints1m[0].Y - someOtherPoints1m[2].Y);

                var pointList8888 = new List<PointF>();

                pointList8888.Add(new PointF(someOtherPoints1m[1].X - 1, (int)centerPointReactorThrusterMIDDLE.Y - (diff / 2)));
                pointList8888.Add(new PointF(someOtherPoints1m[1].X - 1, (int)centerPointReactorThrusterMIDDLE.Y  + (diff / 2)));
                pointList8888.Add(new PointF(someOtherPoints1m[1].X - 1 - 19, (int)centerPointReactorThrusterMIDDLE.Y));
                pointList8888.Add(new PointF(someOtherPoints1m[1].X - 1, (int)centerPointReactorThrusterMIDDLE.Y- (diff / 2)));
                graphics.FillPolygon(texture888, pointList8888.ToArray());
                //THRUSTER FIRE MIDDLE















                //REACTOR FUEL GAUGE TOP
                tester = someOtherPoints2;

                tester.Sort((x, y) =>
                {
                    int compare = x.X.CompareTo(y.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return x.Y.CompareTo(y.Y);
                });

                pointA = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = y.X.CompareTo(x.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return x.Y.CompareTo(y.Y);
                });

                pointB = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = y.X.CompareTo(x.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return y.Y.CompareTo(x.Y);
                });

                pointC = tester[0];

                tester.Sort((x, y) =>
                {
                    int compare = x.X.CompareTo(y.X);
                    if (compare != 0)
                    {
                        return compare;
                    }
                    return y.Y.CompareTo(x.Y);
                });

                pointD = tester[0];

                if (pointB.Y < pointA.Y)
                {
                    pointB.Y = pointA.Y;
                }
                else
                {
                    pointA.Y = pointB.Y;
                }

                if (pointC.Y < pointD.Y)
                {
                    pointD.Y = pointC.Y;
                }
                else
                {
                    pointC.Y = pointD.Y;
                }

                //randomer001 = GetRandomNumber(10, 25);
                //randomer002 = GetRandomNumber(10, 25);
                //randomer003 = GetRandomNumber(2, 5);
                //randomer004 = GetRandomNumber(5, 15);

                pointC.X -= randomer002;
                pointB.X -= randomer002;
                pointA.X += randomer001;
                pointD.X += randomer001;

                pointA.Y += randomer003 - 3;
                pointB.Y += randomer003 - 3;
                pointC.Y -= randomer003 + 3;
                pointD.Y -= randomer003 + 3;

                offSetY001 = 0;
                offSetY002 = 0;
                offSetY003 = 0;
                offSetY004 = 0;

                //randomer0001 = 0;// GetRandomNumber(5, 10);


                if ((int)Math.Abs(pointD.Y - pointA.Y) <= 4)
                {
                    pointD.Y += 4;
                    pointA.Y -= 4;
                }

                if ((int)Math.Abs(pointB.Y - pointC.Y) <= 4)
                {
                    pointB.Y -= 4;
                    pointC.Y += 4;
                }

                someTesterer = (int)Math.Abs(pointD.Y - pointA.Y) / 2;
                if (someTesterer > 10)
                {
                    //randomer0001 = GetRandomNumber(5, 9);
                    offSetY001 = randomer0001;
                }
                else if (someTesterer > 5 && someTesterer <= 10)
                {
                    //randomer0001 = GetRandomNumber(2, 4);
                    offSetY001 = randomer0001;
                }
                else
                {
                    offSetY001 = randomer0001;
                    // Math.Abs(pointD.Y- pointA.Y);
                }

                pointE = pointC;
                pointE.X += 5;
                pointE.Y -= offSetY001;

                pointF = pointB;
                pointF.X += 5;
                pointF.Y += offSetY001;

                pointG = pointA;
                pointG.X -= 5;
                pointG.Y += offSetY001;

                pointH = pointD;
                pointH.X -= 5;
                pointH.Y -= offSetY001;

                somePointers = new List<PointF>();
                somePointers.Add(pointC);
                somePointers.Add(pointE);
                somePointers.Add(pointF);
                somePointers.Add(pointB);
                somePointers.Add(pointA);
                somePointers.Add(pointG);
                somePointers.Add(pointH);
                somePointers.Add(pointD);

                //LIGHTVIOLET = Image.FromFile(DesktopFolderLoc + @"\LAYERS\PNG\LIGHTVIOLET.png");
                texture1 = new TextureBrush(LIGHTVIOLET);
                graphics.FillPolygon(texture1, somePointers.ToArray());

                somePointers.Add(pointC);
                graphPath001 = new GraphicsPath();
                graphPath001.AddLines(somePointers.ToArray());



                col002 = Color.FromArgb(115, 10, 10, 10);
                blackPen002 = new Pen(col002, 2);
                graphics.DrawPath(blackPen002, graphPath001);

                int centerXTop = (int)Math.Abs(pointC.X - pointA.X);
                int centerYTop = (int)Math.Abs(pointB.Y - pointD.Y);
                PointF pointCenterTop = new PointF(pointA.X + (centerXTop / 2), pointB.Y + (centerYTop / 2));
                //REACTOR FUEL GAUGE TOP


                //REACTOR BODY CONNECTOR TOP
                someHeight = (int)Math.Floor(Math.Abs(pointA.Y - pointC.Y));
                texture66 = new TextureBrush(greyBackgroundWep);
                texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                recter66 = new Rectangle((int)(pointCenterTop.X - 4), (int)(pointCenterTop.Y - ((someHeight) / 2)), 8, someHeight);

                leftEdgeX66 = recter66.X;
                rightEdgeX66 = recter66.X + recter66.Width;

                topEdgeY66 = recter66.Y;
                bottomEdgeY66 = recter66.Y + recter66.Height;

                pointLister66 = new List<PointF>();
                pointLister66.Add(new PointF(leftEdgeX66 - 1, bottomEdgeY66 - 2));
                pointLister66.Add(new PointF(leftEdgeX66 - 1, topEdgeY66 + 2));
                pointLister66.Add(new PointF(leftEdgeX66, topEdgeY66));
                pointLister66.Add(new PointF(rightEdgeX66, topEdgeY66));
                pointLister66.Add(new PointF(rightEdgeX66 + 2, topEdgeY66 + 2));
                pointLister66.Add(new PointF(rightEdgeX66 + 2, bottomEdgeY66 - 2));
                pointLister66.Add(new PointF(rightEdgeX66, bottomEdgeY66));
                pointLister66.Add(new PointF(leftEdgeX66, bottomEdgeY66));

                graphics.FillPolygon(texture66, pointLister66.ToArray());

                pointLister66.Add(new PointF(leftEdgeX66 - 1, bottomEdgeY66 - 2));
                graphPath0066 = new GraphicsPath();
                graphPath0066.AddLines(pointLister66.ToArray());

                col0066 = Color.FromArgb(115, 10, 10, 10);
                blackPen0066 = new Pen(col0066, 2);
                graphics.DrawPath(blackPen0066, graphPath0066);
                //REACTOR BODY CONNECTOR TOP






                centerXTop0 = (int)Math.Abs(pointC.X - pointA.X);
                centerYTop0 = (int)Math.Abs(pointB.Y - pointD.Y);
                pointCenterTop0 = new PointF(pointA.X + (centerXTop0 / 2), pointB.Y + (centerYTop0 / 2));
                //REACTOR FUEL GAUGE TOP


                //REACTOR BODY CONNECTOR TOP
                someHeight = (int)Math.Floor(Math.Abs(pointA.Y - pointC.Y));
                //texture66 = new TextureBrush(greyBackgroundWep);
                //texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                recter1 = new Rectangle((int)(someOtherPoints2[1].X - 23), (int)(pointCenterTop0.Y - ((someHeight) / 2)), newWidth, newHeight);

                //REACTOR THRUSTER TOP
                //recter1 = new Rectangle((int)(someOtherPoints2[1].X - 23), (int)(pointCenterTop.Y - ((someHeight) / 2)), newWidth, newHeight);

                //int randomer11 = GetRandomNumber(5, 10);
                //int randomer22 = GetRandomNumber(3, 5);
                //int randomer33 = GetRandomNumber(3, 5);
                //int randomer44 = GetRandomNumber(3, 5);

                //int randomer55 = GetRandomNumber(3, 5);
                //int randomer66 = GetRandomNumber(0, 0);
                //int randomer77 = GetRandomNumber(3, 5);
                //int randomer88 = GetRandomNumber(0, 0);

                someOtherPoints1 = MakeReactorTrusterTOP(randomer11, randomer22, randomer33, randomer44, randomer55, randomer66, randomer77, randomer88, recter1, (int)(pointCenterTop.Y - ((someHeight) / 2)),recter0);

                texture0 = new TextureBrush(whiteBackgroundWep);
                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillPolygon(texture0, someOtherPoints1.ToArray());

                someOtherPoints1.Add(someOtherPoints1[0]);
                graphPath1 = new GraphicsPath();
                graphPath1.AddLines(someOtherPoints1.ToArray());

                col2 = Color.FromArgb(115, 10, 10, 10);
                blackPen2 = new Pen(col2, 2);
                graphics.DrawPath(blackPen2, graphPath1);

                col3 = Color.FromArgb(100, 25, 25, 25);
                blackPen3 = new Pen(col3, 2);
                graphics.DrawPath(blackPen3, graphPath1);

                PointF centerPointReactorThrusterTOP = Center(recter1);
                //REACTOR THRUSTER TOP




                //REACTOR TRUSTER CONNECTOR TOP
                texture6 = new TextureBrush(greyBackgroundWep);
                texture6.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                recter6 = new Rectangle((int)(centerPointReactorThrusterTOP.X - 4), (int)(pointCenterTop.Y - ((someHeight) / 2)), 8, 8);

                PointF centerPointReactorThrusterTOPForPIPE = Center(recter6);

                leftEdgeX = recter6.X;
                rightEdgeX = recter6.X + recter6.Width;

                topEdgeY = recter6.Y;
                bottomEdgeY = recter6.Y + recter6.Height;

                pointLister = new List<PointF>();
                pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                pointLister.Add(new PointF(leftEdgeX - 1, topEdgeY + 2));
                pointLister.Add(new PointF(leftEdgeX, topEdgeY));
                pointLister.Add(new PointF(rightEdgeX, topEdgeY));
                pointLister.Add(new PointF(rightEdgeX + 2, topEdgeY + 2));
                pointLister.Add(new PointF(rightEdgeX + 2, bottomEdgeY - 2));
                pointLister.Add(new PointF(rightEdgeX, bottomEdgeY));
                pointLister.Add(new PointF(leftEdgeX, bottomEdgeY));

                graphics.FillPolygon(texture6, pointLister.ToArray());

                pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                graphPath006 = new GraphicsPath();
                graphPath006.AddLines(pointLister.ToArray());

                col006 = Color.FromArgb(115, 10, 10, 10);
                blackPen006 = new Pen(col006, 2);
                graphics.DrawPath(blackPen006, graphPath006);
                //REACTOR TRUSTER CONNECTOR TOP




                //REACTOR PIPES
                colPipeDark = Color.FromArgb(150, 25, 25, 25);
                //colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                colPipeContour = Color.FromArgb(150, 35, 35, 35);

                blackPenPipe = new Pen(colPipeDark, 7);
                pipeContour = new Pen(colPipeContour, 5);
                whitePenPipe = new Pen(colPipeFuel, 3);

                totalWidth = (int)Math.Abs((int)Math.Abs(centerPointReactorThrusterTOPForPIPE.X) - (int)Math.Abs(centerPointReactorThrusterTOPForPIPE.X));
                totalHeight = (int)Math.Abs((int)Math.Abs(centerPointReactorThrusterTOPForPIPE.Y) - (int)Math.Abs(centerPointReactorThrusterTOPForPIPE.Y));

                //int randomer666 = GetRandomNumber(2, 15);
                //int randomer777 = GetRandomNumber(2, 15);
                //int randomer888 = GetRandomNumber(5, 35);
                //int randomer999 = GetRandomNumber(5, 35);

                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                test00 = new PointF(centerPointReactorThrusterTOPForPIPE.X + randomer666, centerPointReactorThrusterTOPForPIPE.Y - randomer888);
                test01 = new PointF(pointCenterTop.X - randomer777, pointCenterTop.Y - randomer999);

                DrawBezier(graphics, blackPenPipe, 0.01f, centerPointReactorThrusterTOPForPIPE, test00, test01, pointCenterTop);
                DrawBezier(graphics, pipeContour, 0.01f, centerPointReactorThrusterTOPForPIPE, test00, test01, pointCenterTop);
                DrawBezier(graphics, whitePenPipe, 0.01f, centerPointReactorThrusterTOPForPIPE, test00, test01, pointCenterTop);
                //REACTOR PIPES


                //REACTOR TRUSTER CONNECTOR ENTRANCE
                col007 = Color.FromArgb(115, 10, 10, 10);
                blackPen007 = new Pen(col007, 1);
                recter77 = new Rectangle((int)(centerPointReactorThrusterTOPForPIPE.X - 3), (int)centerPointReactorThrusterTOPForPIPE.Y - 4, 7, 7);

                texture7 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture7, recter77);
                graphics.DrawEllipse(blackPen007, recter77);
                //graphics.FillEllipse(Brushes.gre, recter7);
                //REACTOR TRUSTER CONNECTOR ENTRANCE

                //REACTOR BODY CONNECTOR ENTRANCE
                recter777 = new Rectangle((int)(pointCenterTop.X - 3), (int)pointCenterTop.Y - 4, 7, 7);
                texture777 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture777, recter777);
                graphics.DrawEllipse(blackPen007, recter777);
                //REACTOR BODY CONNECTOR ENTRANCE

                //THRUSTER FIRE TOP
                texture888 = new TextureBrush(orangeBackgroundWep);
                texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                diff = (int)Math.Abs(someOtherPoints1[0].Y - someOtherPoints1[2].Y);

                pointList888 = new List<PointF>();

                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterTOP.Y - 8 - (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterTOP.Y - 8 + (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1 - 19, (int)centerPointReactorThrusterTOP.Y - 8));
                pointList888.Add(new PointF(someOtherPoints1[1].X - 1, (int)centerPointReactorThrusterTOP.Y - 8 - (diff / 2)));
                graphics.FillPolygon(texture888, pointList888.ToArray());
            }

            firstImage0.Save(Program.VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES + @"\" + i + ".png", System.Drawing.Imaging.ImageFormat.Png); //"C:\\Users\\steve\\OneDrive\\Desktop\\testXML\\newImage"
        }




        public List<PointF> MakeReactorBodyMIDDLE(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(bounds);



            vertexList.Add(new PointF(cx - 40 - rand5, cy + 15 - 2));
            vertexList.Add(new PointF(cx - 40 - rand5, cy - 15 + 2));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10, cy - 15 + 2));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10 + 3, cy - 15 + 2 + 3));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10 + 3, cy + 15 - 2 - 3));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10, cy + 15 - 2));







            /*
            vertexList.Add(new PointF(cx - 40 - rand5, cy + 15 - rand8));
            vertexList.Add(new PointF(cx - 40 - rand5, cy - 15 + rand8));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10, cy - 15 + rand8));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10+3, cy - 15 + rand8 + 3));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10+3, cy + 15 - rand8 - 3));
            vertexList.Add(new PointF(cx + 20 + rand1 + 10, cy + 15 - rand8));
            */


            /*//vertexList.Add(new PointF(cx - 40 - rand5, cy + 3));
            vertexList.Add(new PointF(cx - 40 - rand5, cy + 10));
            //vertexList.Add(new PointF(cx - 40- rand5, cy + 10-3));
            //vertexList.Add(new PointF(cx - 40- rand5, cy - 10-3));
            vertexList.Add(new PointF(cx - 40 - rand5, cy - 10));
            vertexList.Add(new PointF(cx + 20, cy - 10));
            vertexList.Add(new PointF(cx + 20, cy - 10+3));
            vertexList.Add(new PointF(cx + 20, cy + 10));
            vertexList.Add(new PointF(cx + 20, cy + 10 - 3));
            //vertexList.Add(new PointF(cx + 30 + rand1, cy + 3));*/



            //vertexList.Add(new PointF(cx - 40 - rand5, cy + 15));
            /*vertexList.Add(new PointF(cx - 40 - rand5, cy + 30 - rand6));
            vertexList.Add(new PointF(cx - 20 + rand7, cy + 40 - rand8));
            vertexList.Add(new PointF(cx + 20 - rand3, cy + 40 - rand4));
            vertexList.Add(new PointF(cx + 30 + rand1, cy + 35 - rand2));
            //vertexList.Add(new PointF(cx + 30 + rand1, cy + 15));*/

            //vertexList.Add(new PointF(cx - 40 - rand5, cy - 15));
            /*vertexList.Add(new PointF(cx - 40 - rand5, cy - 30 + rand6));
            vertexList.Add(new PointF(cx - 20 + rand7, cy - 40 + rand8));
            vertexList.Add(new PointF(cx + 20 - rand3, cy - 40 + rand4));
            vertexList.Add(new PointF(cx + 30 + rand1, cy - 35 + rand2));
            //vertexList.Add(new PointF(cx + 30 + rand1, cy - 15));*/




            return vertexList;
        }


        public List<PointF> MakeReactorBodyBOTTOM(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];


            int leftx = 20;
            int rightx = 20;

            float cx = MidX(bounds);
            float cy = MidY(bounds);
            vertexList.Add(new PointF(cx - leftx - rand5, cy + 15));
            vertexList.Add(new PointF(cx - leftx - rand5, cy + 30 - rand6));
            vertexList.Add(new PointF(cx - 20 + rand7, cy + 40 - rand8));
            vertexList.Add(new PointF(cx + 20 - rand3, cy + 40 - rand4));
            vertexList.Add(new PointF(cx + rightx + rand1, cy + 35 - rand2));
            vertexList.Add(new PointF(cx + rightx + rand1, cy + 15));
            return vertexList;
        }



        public List<PointF> MakeReactorBodyTOP(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(bounds);

            int leftx = 20;
            int rightx = 20;



            vertexList.Add(new PointF(cx - leftx - rand5, cy - 15));
            vertexList.Add(new PointF(cx - leftx - rand5, cy - 30 + rand6));
            vertexList.Add(new PointF(cx - 20 + rand7, cy - 40 + rand8));
            vertexList.Add(new PointF(cx + 20 - rand3, cy - 40 + rand4));
            vertexList.Add(new PointF(cx + rightx + rand1, cy - 35 + rand2));
            vertexList.Add(new PointF(cx + rightx + rand1, cy - 15));

            return vertexList;
        }


        public List<PointF> MakeReactorTrusterBOTTOM(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, float someY, Rectangle rect0)
        {
            /*List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(bounds);
            int offset0 = 5;
            int offset = 7;

            vertexList.Add(new PointF(cx, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy - (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy - (cy - someY - offset0) - offset));*/

            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(bounds);

            int offset0 = 0;
            int offset = 0;

            /*
            vertexList.Add(new PointF(cx, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy - (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy - (cy - someY - offset0) - offset));
            */
            /*
            vertexList.Add(new PointF(cx - 5, cy + 8 + rand1 + someY));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1 + someY));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1 + someY));
            vertexList.Add(new PointF(cx + 10, cy - 5 + someY));
            vertexList.Add(new PointF(cx + 10, cy + 5 + someY));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1 + someY));
            */

            /*vertexList.Add(new PointF(cx - 5, cy + 8 + rand1));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1));
            vertexList.Add(new PointF(cx + 10, cy - 5));
            vertexList.Add(new PointF(cx + 10, cy + 5));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1));
            */



            rand1 = 0;

            vertexList.Add(new PointF(cx - 5, cy + 8 + rand1 - 7));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1 - 7));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1 - 7));
            vertexList.Add(new PointF(cx + 10, cy - 5 - 7));
            vertexList.Add(new PointF(cx + 10, cy + 5 - 7));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1 - 7));




            return vertexList;
        }


        public List<PointF> MakeReactorTrusterTOP(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, float someY, Rectangle rect0)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];


            float cx = MidX(bounds);
            float cy = MidY(bounds);

            int offset0 = 0;
            int offset = 0;

            /*
            vertexList.Add(new PointF(cx, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy - (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy - (cy - someY - offset0) - offset));*/

            /*vertexList.Add(new PointF(cx - 5, cy + 8 + rand1 + someY));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1 + someY));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1 + someY));
            vertexList.Add(new PointF(cx + 10, cy - 5 + someY));
            vertexList.Add(new PointF(cx + 10, cy + 5 + someY));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1 + someY));
            */

            rand1 = 0;
            vertexList.Add(new PointF(cx - 5, cy + 8 + rand1 - 7));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1 - 7));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1 - 7));
            vertexList.Add(new PointF(cx + 10, cy - 5 - 7));
            vertexList.Add(new PointF(cx + 10, cy + 5 - 7));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1 - 7));



            return vertexList;
        }




        public List<PointF> MakeReactorTrusterMIDDLE(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, float someY, Rectangle rect0)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(rect0);

            /*vertexList.Add(new PointF(cx, cy - (cy - someY - 6) - rand1 - 8));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - (cy - someY - 6) - rand1 - 8));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + (cy - someY - 6) + rand1 - 8));
            vertexList.Add(new PointF(cx, cy + (cy - someY - 6) + rand1 - 8));
            vertexList.Add(new PointF(cx + 5 + rand3, cy + (cy - someY - 6) - 8));
            vertexList.Add(new PointF(cx + 10, cy + (cy - someY - 6) - 8));
            vertexList.Add(new PointF(cx + 10, cy - (cy - someY - 6) - 8));
            vertexList.Add(new PointF(cx + 5 + rand3, cy - (cy - someY - 6) - 8));*/

            /*
            vertexList.Add(new PointF(cx, cy - rand1 - 8));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - rand1 - 8));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + rand1 - 8));
            vertexList.Add(new PointF(cx, cy  + rand1 - 8));
            vertexList.Add(new PointF(cx + 5 + rand3, cy  - 8));
            vertexList.Add(new PointF(cx + 10, cy  - 8));
            vertexList.Add(new PointF(cx + 10, cy  - 8));
            vertexList.Add(new PointF(cx + 5 + rand3, cy  - 8));*/



            
            vertexList.Add(new PointF(cx - 5, cy + 8 + rand1));
            vertexList.Add(new PointF(cx - 5, cy - 8 - rand1));
            vertexList.Add(new PointF(cx + 7, cy - 8 - rand1));
            vertexList.Add(new PointF(cx + 10, cy - 5));
            vertexList.Add(new PointF(cx + 10, cy + 5));
            vertexList.Add(new PointF(cx + 7, cy + 8 + rand1));
            


            /*
            int offset0 = 7;
            int offset = 5;


            vertexList.Add(new PointF(cx, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy - (cy - someY - offset0) - rand1 - offset));
            vertexList.Add(new PointF(cx - 5 - rand5, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx, cy + (cy - someY - offset0) + rand1 - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy + (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 10, cy - (cy - someY - offset0) - offset));
            vertexList.Add(new PointF(cx + 5 + rand3, cy - (cy - someY - offset0) - offset));

            */


            return vertexList;
        }










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
        public static void DrawBezier(Graphics gr, Pen the_pen, float dt, PointF pt0, PointF pt1, PointF pt2, PointF pt3)
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

            // Draw the curve.
            gr.DrawLines(the_pen, points.ToArray());

            // Draw lines connecting the control points.
            //gr.DrawLine(Pens.Red, pt0, pt1);
            //gr.DrawLine(Pens.Green, pt1, pt2);
            //gr.DrawLine(Pens.Blue, pt2, pt3);
        }
    }
}
