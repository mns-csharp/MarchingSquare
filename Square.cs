﻿using G__Marching_Sqaure;
using System.Collections.Generic;

public class Square
{
    public Point A { get; set; }//bottom left point
    public Point B { get; set; }//bottom right point
    public Point C { get; set; }//top right point
    public Point D { get; set; }//top left point

    public double A_data { get; set; }//bottom left data
    public double B_data { get; set; }//bottom right data
    public double C_data { get; set; }//top roght data
    public double D_data { get; set; }//top left data

    public Square()
    {
        A = new Point();
        B = new Point();
        C = new Point();
        D = new Point();
    }

    private double GetCaseId(double threshold)
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

        return caseId;
    }

    public List<Line> GetLines(double Threshold)
    {
        List<Line> linesList = new List<Line>();

        double caseId = GetCaseId(Threshold);

        if (caseId == 0) {/*do nothing*/ }
        if (caseId == 15) {/*do nothing*/ }

        if ((caseId == 1) || (caseId == 14))
        {
            double pX = B.X + (A.X - B.X) * ((1 - B_data) / (A_data - B_data));
            double pY = B.Y;
            Point p = new Point(pX, pY);

            double qX = D.X;
            double qY = D.Y + (A.Y - D.Y) * ((1 - D_data) / (A_data - D_data));
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }
        /*2==13*/
        if ((caseId == 2) || (caseId == 13))//B
        {
            double pX = A.X + (B.X - A.X) * ((1 - A_data) / (B_data - A_data));
            double pY = A.Y;
            Point p = new Point(pX, pY);

            double qX = C.X;
            double qY = C.Y + (B.Y - C.Y) * ((1 - C_data) / (B_data - C_data));
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }
        /*3==12*/
        if ((caseId == 3) || (caseId == 12))
        {
            double pX = A.X;
            double pY = A.Y + (D.Y - A.Y) * ((1 - A_data) / (D_data - A_data));
            Point p = new Point(pX, pY);

            double qX = C.X;
            double qY = C.Y + (B.Y - C.Y) * ((1 - C_data) / (B_data - C_data));
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }
        /*4==11*/
        if ((caseId == 4) || (caseId == 11))
        {
            double pX = D.X + (C.X - D.X) * ((1 - D_data) / (C_data - D_data));
            double pY = D.Y;
            Point p = new Point(pX, pY);

            double qX = B.X;
            double qY = B.Y + (C.Y - B.Y) * ((1 - B_data) / (C_data - B_data));
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }
        /*6==9*/
        if ((caseId == 6) || (caseId == 9))
        {
            double pX = A.X + (B.X - A.X) * ((1 - A_data) / (B_data - A_data));
            double pY = A.Y;
            Point p = new Point(pX, pY);

            double qX = C.X + (D.X - C.X) * ((1 - C_data) / (D_data - C_data));
            double qY = C.Y;
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }

        /*7==8*/
        if ((caseId == 7) || (caseId == 8))
        {
            double pX = C.X + (D.X - C.X) * ((1 - C_data) / (D_data - C_data));
            double pY = C.Y;
            Point p = new Point(pX, pY);

            double qX = A.X;
            double qY = A.Y + (D.Y - A.Y) * ((1 - A_data) / (D_data - A_data));
            Point q = new Point(qX, qY);

            Line line = new Line(p, q);

            linesList.Add(line);
        }

        /*ambiguous case*/
        if (caseId == 5)
        {
            double pX1 = A.X + (B.X - A.X) * ((1 - A_data) / (B_data - A_data));
            double pY1 = A.Y;
            Point p1 = new Point(pX1, pY1);
            double qX1 = C.X;
            double qY1 = C.Y + (B.Y - C.Y) * ((1 - C_data) / (B_data - C_data));
            Point q1 = new Point(qX1, qY1);
            Line line1 = new Line(p1, q1);

            double pX2 = C.X + (D.X - C.X) * ((1 - C_data) / (D_data - C_data));
            double pY2 = C.Y;
            Point p2 = new Point(pX2, pY2);
            double qX2 = A.X;
            double qY2 = A.Y + (D.Y - A.Y) * ((1 - A_data) / (D_data - A_data));
            Point q2 = new Point(qX2, qY2);
            Line line2 = new Line(p2, q2);

            linesList.Add(line1);
            linesList.Add(line2);
        }
        if (caseId == 10)
        {
            double pX1 = B.X + (A.X - B.X) * ((1 - B_data) / (A_data - B_data));
            double pY1 = B.Y;
            Point p1 = new Point(pX1, pY1);
            double qX1 = D.X;
            double qY1 = D.Y + (A.Y - D.Y) * ((1 - D_data) / (A_data - D_data));
            Point q1 = new Point(qX1, qY1);
            Line line1 = new Line(p1, q1);

            double pX2 = D.X + (C.X - D.X) * ((1 - D_data) / (C_data - D_data));
            double pY2 = D.Y;
            Point p2 = new Point(pX2, pY2);
            double qX2 = B.X;
            double qY2 = B.Y + (C.Y - B.Y) * ((1 - B_data) / (C_data - B_data));
            Point q2 = new Point(qX2, qY2);
            Line line2 = new Line(p2, q2);

            linesList.Add(line1);
            linesList.Add(line2);
        }

        return linesList;
    }
}