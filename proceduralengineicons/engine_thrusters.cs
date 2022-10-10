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
        public void createPNG(int newWidth, int newHeight, int i, string extraPower, int isBasic, int resultForRandom,int resultForRandomPropsFin,int randForReactorPropsScrews,int resultForRandomPropsArmor)
        {
            var DesktopFolderLoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string projectPath = @"LAYERS\PNG\";

            //SC_Utilities someUtilities = new SC_Utilities();
            Image firstImage0 = Image.FromFile(@"LAYERS\PNG\LIGHTBLUE.png");
            //Image firstImage0 = Image.FromFile(@"LAYERS\PNG\DARKBLUEE.png");
            Image whiteBackgroundWep = null;
            Image greyBackgroundWep = Image.FromFile(@"LAYERS\PNG\GREY.png");
            Image dgreyBackgroundWep = Image.FromFile(@"LAYERS\PNG\DARKGREY.png");
            Image orangeBackgroundWep = Image.FromFile(@"LAYERS\PNG\ORANGE.png");

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

            var someOtherPoints = MakeReactorBody(randomer1, randomer2, randomer3, randomer4, randomer5, randomer6, randomer7, randomer8, recter0, resultForRandom);

            PointF centerPointReactorBody = Center(recter0);
            //REACTOR BODY

            List<PointF> listOfExtent = new List<PointF>();
            for (int y = 0; y < someOtherPoints.Count; y++)
            {
                listOfExtent.Add(someOtherPoints[y]);
            }
            //REACTOR BODY PROPS




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

            listOfExtent.Sort((x, y) =>
            {
                int compare = y.X.CompareTo(x.X);
                if (compare != 0)
                {
                    return compare;
                }
                return y.Y.CompareTo(x.Y);
            });

            var somePointC = listOfExtent[0];


            listOfExtent.Sort((x, y) =>
            {
                int compare = y.X.CompareTo(x.X);
                if (compare != 0)
                {
                    return compare;
                }
                return x.Y.CompareTo(y.Y);
            });
            var somePointD = listOfExtent[0];

            if (resultForRandomPropsFin == 1)
            {            
                //var someDist = someUtilities.GetDistance();

                var someDistX = (int)Math.Abs(somePointA.X - somePointD.X);
                var someDistY = (int)Math.Abs(somePointA.Y - somePointB.Y);


                var halfWayLeftX = (someDistX / 2);
                var halfWayLeftY = (someDistY / 2);
                var someOffsetForPropsY = 0;

                if (resultForRandom == 0)
                {
                    someOffsetForPropsY = 36;
                }
                else
                {
                    someOffsetForPropsY = 24;
                }
                
                Rectangle rectForProps = new Rectangle((int)centerPointReactorBody.X - (halfWayLeftX), (int)centerPointReactorBody.Y - (someDistY / 2) - (someOffsetForPropsY / 2), (halfWayLeftX), someDistY + (someOffsetForPropsY));

                Color colForExtents = Color.FromArgb(115, 10, 10, 10);
                Pen blackPenForExtents = new Pen(colForExtents, 2);
                //graphics.DrawRectangle(blackPenForExtents, rectForProps);

                TextureBrush textForProps = new TextureBrush(whiteBackgroundWep);
                textForProps.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                //graphics.FillRectangle(textForProps, rectForProps);
                //graphics.DrawRectangle(blackPenForExtents, rectForProps);

                //graphics.FillEllipse(textForProps, rectForProps);
                //graphics.DrawEllipse(blackPenForExtents, rectForProps);

                rectForProps = new Rectangle((int)centerPointReactorBody.X, (int)centerPointReactorBody.Y - (someDistY / 2) - (someOffsetForPropsY / 2), (halfWayLeftX / 2)+8, someDistY + (someOffsetForPropsY));

                graphics.FillEllipse(textForProps, rectForProps);

                graphics.DrawEllipse(blackPenForExtents, rectForProps);
            }

            //REACTOR BODY
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
            //REACTOR BODY

            //somePointA.X + 3

            //Console.WriteLine(randForReactorPropsScrews);
            if (randForReactorPropsScrews == 1)
            {
                var someRectForScrewProps = new Rectangle((int)somePointA.X + 3, (int)somePointA.Y + 3, 8, 8);

                texture = new TextureBrush(greyBackgroundWep);
                texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillEllipse(texture, someRectForScrewProps);

                col1 = Color.FromArgb(125, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawEllipse(blackPen1, someRectForScrewProps);

                var screwPropCenter = Center(someRectForScrewProps);

                var screwPropTopAX = screwPropCenter.X;
                var screwPropTopAY = screwPropCenter.Y - 3;
                var screwPropTopA = new PointF(screwPropTopAX, screwPropTopAY);

                var screwPropTopBX = screwPropCenter.X;
                var screwPropTopBY = screwPropCenter.Y + 3;
                var screwPropTopB = new PointF(screwPropTopBX, screwPropTopBY);

                var lister = new List<PointF>();
                lister.Add(screwPropTopA);
                lister.Add(screwPropTopB);

                GraphicsPath graphPatherScrews = new GraphicsPath();
                graphPatherScrews.AddLines(lister.ToArray());
                col1 = Color.FromArgb(150, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawPath(blackPen1, graphPatherScrews);

                screwPropTopB.Y -= 3;
                screwPropTopB.X += 3;

                screwPropTopA.Y += 3;
                screwPropTopA.X -= 3;

                lister = new List<PointF>();
                lister.Add(screwPropTopA);
                lister.Add(screwPropTopB);

                graphPatherScrews = new GraphicsPath();
                graphPatherScrews.AddLines(lister.ToArray());
                col1 = Color.FromArgb(150, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawPath(blackPen1, graphPatherScrews);

                someRectForScrewProps = new Rectangle((int)somePointB.X + 3, (int)somePointB.Y - 3 - 8, 8, 8);

                texture = new TextureBrush(greyBackgroundWep);
                texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillEllipse(texture, someRectForScrewProps);

                col1 = Color.FromArgb(125, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawEllipse(blackPen1, someRectForScrewProps);

                screwPropCenter = Center(someRectForScrewProps);

                screwPropTopAX = screwPropCenter.X;
                screwPropTopAY = screwPropCenter.Y - 3;
                screwPropTopA = new PointF(screwPropTopAX, screwPropTopAY);

                screwPropTopBX = screwPropCenter.X;
                screwPropTopBY = screwPropCenter.Y + 3;
                screwPropTopB = new PointF(screwPropTopBX, screwPropTopBY);

                lister = new List<PointF>();
                lister.Add(screwPropTopA);
                lister.Add(screwPropTopB);

                graphPatherScrews = new GraphicsPath();
                graphPatherScrews.AddLines(lister.ToArray());
                col1 = Color.FromArgb(150, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawPath(blackPen1, graphPatherScrews);

                screwPropTopB.Y -= 3;
                screwPropTopB.X += 3;

                screwPropTopA.Y += 3;
                screwPropTopA.X -= 3;

                lister = new List<PointF>();
                lister.Add(screwPropTopA);
                lister.Add(screwPropTopB);

                graphPatherScrews = new GraphicsPath();
                graphPatherScrews.AddLines(lister.ToArray());
                col1 = Color.FromArgb(150, 25, 25, 25);
                blackPen1 = new Pen(col1, 1);
                graphics.DrawPath(blackPen1, graphPatherScrews);
            }























            /*var someListOfExtent = new List<PointF>();
            someListOfExtent.Add(somePointA);
            someListOfExtent.Add(somePointB);
            someListOfExtent.Add(somePointC);
            someListOfExtent.Add(somePointD);
            GraphicsPath graphPathForExtents = new GraphicsPath();
            graphPathForExtents.AddLines(someListOfExtent.ToArray());

            Color colForExtents = Color.FromArgb(115, 255, 10, 10);
            Pen blackPenForExtents = new Pen(colForExtents, 2);
            graphics.DrawPath(blackPenForExtents, graphPathForExtents);
            */








            //firstImage0.Save("C:\\Users\\steve\\OneDrive\\Desktop\\testXML\\newImage" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);






















            if (isBasic == 0)
            {
                //REACTOR FUEL GAUGE
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

                PointF aa = pointA;
                PointF cc = pointC;
                int randomer001 = GetRandomNumber(15, 25);
                int randomer002 = GetRandomNumber(15, 25);
                int randomer003 = GetRandomNumber(2, 5);
                int randomer004 = GetRandomNumber(5, 15);

                pointC.X -= randomer002 - 5;
                pointB.X -= randomer002 - 5;
                


                pointA.X += randomer001 + 5;
                pointD.X += randomer001 + 5;
                pointA.Y += randomer003;
                pointB.Y += randomer003;
                pointC.Y -= randomer003;
                pointD.Y -= randomer003;

                int offSetY001 = 0;
                int offSetY002 = 0;
                int offSetY003 = 0;
                int offSetY004 = 0;

                int randomer0001 = 0;// GetRandomNumber(5, 10);
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
                    offSetY001 = someTesterer;// Math.Abs(pointD.Y- pointA.Y);
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

                Image LIGHTVIOLET = null;// = Image.FromFile(@"LAYERS\PNG\LIGHTVIOLET.png");
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
                //REACTOR FUEL GAUGE

                //REACTOR BODY CONNECTOR
                int someHeight = (int)Math.Abs(pointA.Y - pointC.Y);
                TextureBrush texture66 = new TextureBrush(greyBackgroundWep);
                texture66.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                Rectangle recter66 = new Rectangle((int)(pointCenterBottom.X - 4), (int)pointCenterBottom.Y - (someHeight / 2), 8, someHeight);

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
                //REACTOR BODY CONNECTOR

                //int someMidX = MidX(recter0);
                //int someMidY = MidY(recter0);

                //Console.WriteLine(someMidY);
                //int someDiff = Math.Abs((int)centerPointReactorBody.Y - someMidY);
                someHeight = (int)Math.Abs(someOtherPoints[1].Y - someOtherPoints[0].Y);

                //REACTOR THRUSTER
                Rectangle recter1 = new Rectangle((int)(someOtherPoints[1].X - 25), (int)centerPointReactorBody.Y - (int)(someHeight / 2), newWidth, someHeight); //- (someHeight / 2)
                                                                                                                                                                  //TextureBrush texture0 = new TextureBrush(whiteBackgroundWep);
                                                                                                                                                                  //texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                                                                                                                                                                  //graphics.FillRectangle(texture0,recter1);
                int randomer11 = GetRandomNumber(3, 7);
                int randomer22 = GetRandomNumber(3, 5);
                int randomer33 = GetRandomNumber(3, 5);
                int randomer44 = GetRandomNumber(3, 5);

                int randomer55 = GetRandomNumber(3, 5);
                int randomer66 = GetRandomNumber(0, 0);
                int randomer77 = GetRandomNumber(3, 5);
                int randomer88 = GetRandomNumber(0, 0);

                var someOtherPoints1 = MakeReactorTruster(randomer11, randomer22, randomer33, randomer44, randomer55, randomer66, randomer77, randomer88, recter1, (someHeight / 2), resultForRandom);

                TextureBrush texture0 = new TextureBrush(whiteBackgroundWep);
                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillPolygon(texture0, someOtherPoints1.ToArray());

                someOtherPoints1.Add(someOtherPoints1[0]);
                GraphicsPath graphPath1 = new GraphicsPath();
                graphPath1.AddLines(someOtherPoints1.ToArray());

                Color col2 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen2 = new Pen(col2, 2);
                graphics.DrawPath(blackPen2, graphPath1);

                Color col3 = Color.FromArgb(100, 25, 25, 25);
                Pen blackPen3 = new Pen(col3, 2);
                graphics.DrawPath(blackPen3, graphPath1);

                PointF centerPointReactorThruster = Center(recter1);
                //REACTOR THRUSTER






                //REACTOR TRUSTER CONNECTOR
                TextureBrush texture6 = new TextureBrush(greyBackgroundWep);
                texture6.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                Rectangle recter6 = new Rectangle((int)(centerPointReactorThruster.X), (int)centerPointReactorThruster.Y, 8, 8);

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

                graphics.FillPolygon(texture6, pointLister.ToArray());

                pointLister.Add(new PointF(leftEdgeX - 1, bottomEdgeY - 2));
                GraphicsPath graphPath006 = new GraphicsPath();
                graphPath006.AddLines(pointLister.ToArray());

                Color col006 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen006 = new Pen(col006, 2);
                graphics.DrawPath(blackPen006, graphPath006);
                //REACTOR TRUSTER CONNECTOR

                //REACTOR PIPES
                Color colPipeDark = Color.FromArgb(150, 25, 25, 25);
                //Color colPipeFuel = Color.FromArgb(200, 115, 0, 128);
                Color colPipeContour = Color.FromArgb(150, 35, 35, 35);

                Pen blackPenPipe = new Pen(colPipeDark, 7);
                Pen pipeContour = new Pen(colPipeContour, 5);
                Pen whitePenPipe = new Pen(colPipeFuel, 3);

                int totalWidth = (int)Math.Abs((int)Math.Abs(centerPointReactorThruster.X) - (int)Math.Abs(centerPointReactorBody.X));
                int totalHeight = (int)Math.Abs((int)Math.Abs(centerPointReactorThruster.Y) - (int)Math.Abs(centerPointReactorBody.Y));

                int randomer666 = GetRandomNumber(2, 15);
                int randomer777 = GetRandomNumber(2, 15);
                int randomer888 = GetRandomNumber(5, 35);
                int randomer999 = GetRandomNumber(5, 35);

                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                PointF test00 = new PointF(centerPointReactorThruster.X + randomer666, centerPointReactorThruster.Y + randomer888);
                PointF test01 = new PointF(centerPointReactorBody.X - randomer777, centerPointReactorBody.Y + randomer999);

                DrawBezier(graphics, blackPenPipe, 0.01f, centerPointReactorThruster, test00, test01, Center(recter66));
                DrawBezier(graphics, pipeContour, 0.01f, centerPointReactorThruster, test00, test01, Center(recter66));
                DrawBezier(graphics, whitePenPipe, 0.01f, centerPointReactorThruster, test00, test01, Center(recter66));
                //REACTOR PIPES

                //REACTOR TRUSTER CONNECTOR ENTRANCE
                Color col007 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen007 = new Pen(col007, 1);
                Rectangle recter77 = new Rectangle((int)centerPointReactorThruster.X - 3, (int)centerPointReactorThruster.Y - 2, 7, 7); //+ (recter6.Height / 2)

                TextureBrush texture7 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture7, recter77);
                graphics.DrawEllipse(blackPen007, recter77);
                //graphics.FillEllipse(Brushes.gre, recter7);
                //REACTOR TRUSTER CONNECTOR ENTRANCE

                //REACTOR BODY CONNECTOR ENTRANCE
                Rectangle recter777 = new Rectangle((int)(Center(recter66).X - 3), (int)Center(recter66).Y - 2, 7, 7);
                TextureBrush texture777 = new TextureBrush(dgreyBackgroundWep);
                texture7.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                graphics.FillEllipse(texture777, recter777);
                graphics.DrawEllipse(blackPen007, recter777);
                //REACTOR BODY CONNECTOR ENTRANCE

                //THRUSTER FIRE
                TextureBrush texture888 = new TextureBrush(orangeBackgroundWep);
                texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                int diff = (int)Math.Abs(someOtherPoints1[2].Y - someOtherPoints1[3].Y);


                List<PointF> pointList888 = new List<PointF>();

                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y - (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y + (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1 - 15, centerPointReactorThruster.Y));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y - (diff / 2)));
                graphics.FillPolygon(texture888, pointList888.ToArray());
            }
            else
            {


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
                PointF aa = pointA;
                PointF cc = pointC;
                int randomer001 = GetRandomNumber(10, 25);
                int randomer002 = GetRandomNumber(10, 25);
                int randomer003 = GetRandomNumber(2, 5);
                int randomer004 = GetRandomNumber(5, 15);

                pointC.X -= randomer002;
                pointB.X -= randomer002;
                pointA.X += randomer001;
                pointD.X += randomer001;
                pointA.Y += randomer003;
                pointB.Y += randomer003;
                pointC.Y -= randomer003;
                pointD.Y -= randomer003;

                int offSetY001 = 0;
                //int offSetY002 = 0;
                //int offSetY003 = 0;
                //int offSetY004 = 0;

                int randomer0001 = 0;// GetRandomNumber(5, 10);
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
                    offSetY001 = someTesterer;// Math.Abs(pointD.Y- pointA.Y);
                }



                PointF pointE = pointC;
                //pointE.X += 5;
                //pointE.Y -= offSetY001;

                PointF pointF = pointB;
                //pointF.X += 5;
                //pointF.Y += offSetY001;

                //GraphicsPath graphPath999 = new GraphicsPath();
                //List<PointF> testing = new List<PointF>();
                //testing.Add(someOtherPoints[1]);
                //testing.Add(someOtherPoints[0]);
                //graphPath999.AddLines(testing.ToArray());
                //Color col999 = Color.FromArgb(100, 255, 25, 25);
                //Pen blackPen999 = new Pen(col999, 2);
                //graphics.DrawPath(blackPen999, graphPath999);




                int someHeight = (int)Math.Abs(someOtherPoints[0].Y - someOtherPoints[1].Y);

                //REACTOR THRUSTER
                Rectangle recter1 = new Rectangle((int)(someOtherPoints[1].X - 25), (int)centerPointReactorBody.Y - (int)(someHeight / 2), newWidth, someHeight); 
                
                //TextureBrush texture0 = new TextureBrush(whiteBackgroundWep);
                //texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;                                                                                                                                                             //graphics.FillRectangle(texture0,recter1)
                int randomer11 = GetRandomNumber(3, 7);
                int randomer22 = GetRandomNumber(3, 5);
                int randomer33 = GetRandomNumber(3, 5);
                int randomer44 = GetRandomNumber(3, 5);

                int randomer55 = GetRandomNumber(3, 5);
                int randomer66 = GetRandomNumber(0, 0);
                int randomer77 = GetRandomNumber(3, 5);
                int randomer88 = GetRandomNumber(0, 0);

                var someOtherPoints1 = MakeReactorTruster(randomer11, randomer22, randomer33, randomer44, randomer55, randomer66, randomer77, randomer88, recter1, (someHeight / 2), resultForRandom);

                TextureBrush texture0 = new TextureBrush(whiteBackgroundWep);
                texture0.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                graphics.FillPolygon(texture0, someOtherPoints1.ToArray());

                someOtherPoints1.Add(someOtherPoints1[0]);
                GraphicsPath graphPath1 = new GraphicsPath();
                graphPath1.AddLines(someOtherPoints1.ToArray());

                Color col2 = Color.FromArgb(115, 10, 10, 10);
                Pen blackPen2 = new Pen(col2, 2);
                graphics.DrawPath(blackPen2, graphPath1);

                Color col3 = Color.FromArgb(100, 25, 25, 25);
                Pen blackPen3 = new Pen(col3, 2);
                graphics.DrawPath(blackPen3, graphPath1);

                PointF centerPointReactorThruster = Center(recter1);
                //REACTOR THRUSTER




                //THRUSTER FIRE
                TextureBrush texture888 = new TextureBrush(orangeBackgroundWep);
                texture888.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

                int diff = (int)Math.Abs(someOtherPoints1[2].Y - someOtherPoints1[3].Y);

                List<PointF> pointList888 = new List<PointF>();

                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y - (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y + (diff / 2)));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1 - 15, centerPointReactorThruster.Y));
                pointList888.Add(new PointF(someOtherPoints1[2].X - 1, centerPointReactorThruster.Y - (diff / 2)));
                graphics.FillPolygon(texture888, pointList888.ToArray());
                
            }
            firstImage0.Save(Program.VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES + @"\" + i + ".png", System.Drawing.Imaging.ImageFormat.Png); //"C:\\Users\\steve\\OneDrive\\Desktop\\testXML\\newImage"

        }
        public List<PointF> MakeReactorBody(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds,int resultForRandom)
        {
            List<PointF> vertexList = new List<PointF>();
            //PointF[] vertexArray = new PointF[8];

            float cx = MidX(bounds);
            float cy = MidY(bounds);





            if (resultForRandom == 0)
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
            }

            return vertexList;
        }

        public List<PointF> MakeReactorTruster(int rand1, int rand2, int rand3, int rand4, int rand5, int rand6, int rand7, int rand8, Rectangle bounds, float someY,int resultForRandom)
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
