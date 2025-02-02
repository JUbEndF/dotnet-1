﻿using System;
using System.Collections.Generic;

namespace Lab1.Model
{
    public class Triangle : Figure
    {

        public Point VertexA { get; init; }
        public Point VertexB { get; init; }
        public Point VertexC { get; init; }

        public Triangle()
        {

        }

        public Triangle(Point vertexA, Point vertexB, Point vertexC)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            VertexC = vertexC;
        }

        private double SideAB => VertexA.Distance(VertexB);

        private double SideAC => VertexA.Distance(VertexC);

        private double SideCB => VertexC.Distance(VertexB);

        public override Rectangle FramingRectangle()
        {
            double maxX = VertexA.X, maxY = VertexA.Y,
                minX = VertexC.X, minY = VertexC.Y;
            if (maxX < VertexB.X || maxX < VertexC.X)
                if (VertexC.X < VertexB.X) maxX = VertexB.X; else maxX = VertexC.X;
            if (maxY < VertexB.Y || maxY < VertexC.Y)
                if (VertexC.Y < VertexB.Y) maxY = VertexB.Y; else maxY = VertexC.Y;
            if (minX > VertexB.X || minX > VertexA.X)
                if (VertexA.X > VertexB.X) minX = VertexB.X; else minX = VertexA.X;
            if (minY > VertexB.X || minY > VertexA.X)
                if (VertexA.X > VertexB.X) minY = VertexB.X; else minY = VertexA.X;
            return new(new Point(minX, minY), new Point(maxX, maxY));
        }

        public override double Perimeter() => SideAB + SideAC + SideCB;

        public override double Area()
        {
            var per = Perimeter() / 2;
            return Math.Sqrt(per * (per - SideAB) * (per - SideAC) * (per - SideCB));
        }

        public override string ToString() => $" A:{VertexA}, B:{VertexB}, C:{VertexC},: {SideAB}, {SideAC}, {SideCB}";

        public override bool Equals(object? obj)
        {
            if (obj is Triangle triangleObj)
                return Equals(triangleObj);
            else
                return false;
        }

        public override bool Equals(Figure? obj)
        {
            if (obj is not Triangle triangleObj)
                return false;
            HashSet<Point> my = new()
            {
                VertexA,
                VertexB,
                VertexC
            };
            HashSet<Point> externalObject = new()
            {
                triangleObj.VertexA,
                triangleObj.VertexB,
                triangleObj.VertexC
            };
            return my.Equals(externalObject);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point, Point>(VertexA, VertexB, VertexC);
        }
    }
}
