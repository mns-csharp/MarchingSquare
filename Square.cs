using System;
using System.Collections.Generic;

namespace G__Marching_Sqaure
{
    public class Square
    {
        public Point A { get; set; } //bottom left point
        public Point B { get; set; } //bottom right point
        public Point C { get; set; } //top right point
        public Point D { get; set; } //top left point

        public double A_data { get; set; } //bottom left data
        public double B_data { get; set; } //bottom right data
        public double C_data { get; set; } //top roght data
        public double D_data { get; set; } //top left data

        public Square()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            D = new Point();
        }

        public LineShapes GetCaseId(double threshold)
        {
            int caseId = 0;

            if (A_data >= threshold)
            {
                caseId |= 1;
            }

            if (B_data >= threshold)
            {
                caseId |= 2;
            }

            if (C_data >= threshold)
            {
                caseId |= 4;
            }

            if (D_data >= threshold)
            {
                caseId |= 8;
            }

            return (LineShapes)caseId;
        }

        public List<Line> GetLines(double Threshold)
        {
            List<Line> linesList = new List<Line>();

            LineShapes caseId = GetCaseId(Threshold);

            if (caseId == LineShapes.Empty)
            {
                /*do nothing*/
            }

            if (caseId == LineShapes.All)
            {
                /*do nothing*/
            }

            if ((caseId == LineShapes.BottomLeft) || (caseId == LineShapes.AllButButtomLeft))
            {
                var p = InterpolateHorizonal(B, A, B_data, A_data);
                var q = InterpolateVertical(D, A, D_data, A_data);
                Line line = new Line(p, q);
                linesList.Add(line);
            }

            /*2==13*/
            if ((caseId == LineShapes.BottomRight) || (caseId == LineShapes.AllButButtomRight)) //B
            {
                var p = InterpolateHorizonal(A, B, A_data, B_data);
                var q = InterpolateVertical(C, B, C_data, B_data);
                Line line = new Line(p, q);

                linesList.Add(line);
            }

            /*3==12*/
            if ((caseId == LineShapes.Bottom) || (caseId == LineShapes.Top))
            {
                // interpolate vertical
                var p = InterpolateVertical(A, D, A_data, D_data);
                var q = InterpolateVertical(C, B, C_data, B_data);
                Line line = new Line(p, q);
                linesList.Add(line);
            }

            /*4==11*/
            if ((caseId == LineShapes.TopRight) || (caseId == LineShapes.AllButTopRight))
            {
                var p = InterpolateHorizonal(D, C, D_data, C_data);
                var q = InterpolateVertical(B, C, B_data, C_data);
                Line line = new Line(p, q);
                linesList.Add(line);
            }

            /*6==9*/
            if ((caseId == LineShapes.Right) || (caseId == LineShapes.Left))
            {
                var p = InterpolateHorizonal(A, B, A_data, B_data);
                var q = InterpolateHorizonal(C, D, C_data, D_data);
                Line line = new Line(p, q);

                linesList.Add(line);
            }

            /*7==8*/
            if ((caseId == LineShapes.AllButTopLeft) || (caseId == LineShapes.TopLeft))
            {
                var p = InterpolateHorizonal(C, D, C_data, D_data);
                var q = InterpolateVertical(A, D, A_data, D_data);
                Line line = new Line(p, q);
                linesList.Add(line);
            }

            /*ambiguous case*/
            if (caseId == LineShapes.TopRightBottomLeft)
            {
                var p1 = InterpolateHorizonal(A, B, A_data, B_data);
                var q1 = InterpolateVertical(C, B, C_data, B_data);
                Line line1 = new Line(p1, q1);

                var p2 = InterpolateHorizonal(C, D, C_data, D_data);
                var q2 = InterpolateVertical(A, D, A_data, D_data);
                Line line2 = new Line(p2, q2);

                linesList.Add(line1);
                linesList.Add(line2);
            }

            if (caseId == LineShapes.TopLeftBottomRight)
            {
                var p1 = InterpolateHorizonal(B, A, B_data, A_data);
                var q1 = InterpolateVertical(D, A, D_data, A_data);
                Line line1 = new Line(p1, q1);

                var p2 = InterpolateHorizonal(D, C, D_data, C_data);
                var q2 = InterpolateVertical(B, C, B_data, C_data);
                Line line2 = new Line(p2, q2);

                linesList.Add(line1);
                linesList.Add(line2);
            }

            return linesList;
        }

        private static Point InterpolateVertical(Point point, Point point1, double data, double data1)
        {
            double qX = point.X;
            double qY = point.Y + (point1.Y - point.Y) * ((1 - data) / (data1 - data));
            Point q = new Point(qX, qY);
            return q;
        }


        private static Point InterpolateHorizonal(Point start, Point end, double startForce, double endForce)
        {
            double pX = start.X + (end.X - start.X) * ((1 - startForce) / (endForce - startForce));
            double pY = start.Y;
            Point p = new Point(pX, pY);
            return p;
        }
    }

    public enum LineShapes
    {
        Empty = 0,
        //  ○----○
        //  |    |
        //  |    |
        //  ○----○

        BottomLeft = 1,
        //  ○----○
        //  |    |
        //  |    |
        //  ●----○

        BottomRight = 2,
        //  ○----○
        //  |    |
        //  |    |
        //  ○----●

        Bottom = 3,
        //  ○----○
        //  |    |
        //  |    |
        //  ●----●

        TopRight = 4,
        //  ○----●
        //  |    |
        //  |    |
        //  ○----○

        TopRightBottomLeft = 5,
        //  ○----●
        //  |    |
        //  |    |
        //  ●----○

        Right = 6,
        //  ○----●
        //  |    |
        //  |    |
        //  ○----●

        AllButTopLeft = 7,
        //  ○----●
        //  |    |
        //  |    |
        //  ●----●

        TopLeft = 8,
        //  ●----○
        //  |    |
        //  |    |
        //  ○----○

        Left = 9,
        //  ●----○
        //  |    |
        //  |    |
        //  ●----○

        TopLeftBottomRight = 10,
        //  ●----○
        //  |    |
        //  |    |
        //  ○----●

        AllButTopRight = 11,
        //  ●----○
        //  |    |
        //  |    |
        //  ●----●

        Top = 12,
        //  ●----●
        //  |    |
        //  |    |
        //  ○----○

        AllButButtomRight = 13,
        //  ●----●
        //  |    |
        //  |    |
        //  ●----○

        AllButButtomLeft = 14,
        //  ●----●
        //  |    |
        //  |    |
        //  ○----●

        All = 15,
        //  ●----●
        //  |    |
        //  |    |
        //  ●----●
    }
}