using G__Marching_Sqaure;
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
        List<Line> lines = new List<Line>();

        double caseId = GetCaseId(Threshold);

        if (caseId == 0 || caseId == 15)
        { }

        if (caseId == 1 || caseId == 14 || caseId == 10)
        {
            double pX = (A.X + B.X) / 2.0;
            double pY = B.Y;
            double qX = D.X;
            double qY = (A.Y + D.Y) / 2.0;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        if (caseId == 2 || caseId == 13 || caseId == 5)
        {
            double pX = (A.X + B.X) / 2.0;
            double pY = A.Y;
            double qX = C.X;
            double qY = (A.Y + D.Y) / 2.0;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        if (caseId == 3 || caseId == 12)
        {
            double pX = A.X;
            double pY = (A.Y + D.Y) / 2.0;
            double qX = C.X;
            double qY = (B.Y + C.Y) / 2.0;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        if (caseId == 4 || caseId == 11 || caseId == 10)
        {
            double pX = (C.X + D.X) / 2.0;
            double pY = D.Y;
            double qX = B.X;
            double qY = (B.Y + C.Y) / 2.0;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        if (caseId == 6 || caseId == 9)
        {
            double pX = (A.X + B.X) / 2.0;
            double pY = A.Y;
            double qX = (C.X + D.X) / 2.0;
            double qY = C.Y;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        if (caseId == 7 || caseId == 8 || caseId == 5)
        {
            double pX = (C.X + D.X) / 2.0;
            double pY = C.Y;
            double qX = A.X;
            double qY = (A.Y + D.Y) / 2.0;

            Line line = new Line(pX, pY, qX, qY);

            lines.Add(line);
        }
        return lines;

    }
}