using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tri
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isIsoscelesTest() // likbenthet
        {
            double[] number = new double[3];
            Triangle tri1 = new Triangle(3.0, 3.0, 1.0);
            Assert.IsTrue(tri1.isIsosceles() && !tri1.isEquilateral() && !tri1.isScalene()); // likbent - pass

            tri1 = new Triangle(2.0, 1.0, 3.0); // inga lika sidor ger false - pass
            Assert.IsFalse(tri1.isIsosceles() && !tri1.isEquilateral() && !tri1.isScalene());
        }

        [TestMethod]
        public void isEquilateralTest() // inga lika sidor
        {
            Triangle tri2 = new Triangle(5.0, 2.0, 1.0);
            Assert.IsTrue(tri2.isEquilateral() && !tri2.isScalene() && !tri2.isIsosceles()); // inga lika sidor - pass

            tri2 = new Triangle(20.0, 20.0, 5.0);
            Assert.IsFalse(tri2.isEquilateral() && !tri2.isScalene() && !tri2.isIsosceles()); // 2 lika sidor ger false - pass
        }

        [TestMethod]
        public void isScaleneTest() // liksidig
        {
            Triangle tri3 = new Triangle(-5.0, -5.0, -5.0); // liksidig (också med negativa tal) - pass
            Assert.IsTrue(tri3.isScalene() && !tri3.isIsosceles() && !tri3.isEquilateral());

            tri3 = new Triangle(7.0, 7.0, -7.0); // en negativ sida ger false - pass
            Assert.IsFalse(tri3.isScalene() && !tri3.isIsosceles() && !tri3.isEquilateral());

            tri3 = new Triangle(1.0, 2.0, 2.0); // inte likbent ger false - pass
            Assert.IsFalse(tri3.isScalene() && !tri3.isIsosceles() && !tri3.isEquilateral());    
        }

        [TestMethod]
        public void pointTest() // test av kordinaterna (jag kanske har missuppfattat detta då alla mina tester blev fail, jag tolkade det som kortinaterna Point(x,y) i ett kordinatsystem)
        {
            Triangle tri4 = new Triangle(new Point(0, 0), new Point(3, 0), new Point(3, 4)); // likbent - fail (har inga lika sidor)
            Assert.IsTrue(tri4.isIsosceles() && !tri4.isEquilateral() && !tri4.isScalene());

            tri4 = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.IsFalse(tri4.isScalene() && !tri4.isEquilateral() && !tri4.isIsosceles()); // liksidig när den borde varit likbent - fail

            tri4 = new Triangle(new Point(0, 20), new Point(0, 20), new Point(0, 20));
            Assert.IsTrue(tri4.isScalene() && !tri4.isEquilateral() && !tri4.isIsosceles()); // 3 kordinater på samma punkt bildar en liksidig triangel - fail
        }

        [TestMethod]
        public void differentNumbers() // antal nummer
        {
            double[] one = new double[] { 20.0 };
            Triangle tri5 = new Triangle(one);
            Assert.IsTrue(tri5.isScalene()); // liksidig med bara ett tal - fail

            double[] two = new double[] { 5.5, 5.5 };
            tri5 = new Triangle(two);
            Assert.IsTrue(tri5.isScalene()); // liksidig med bara två tal - fail

            double[] many = new double[] { 1.2, 1.3, 1.8, 1.5 };
            tri5 = new Triangle(many);
            Assert.IsFalse(tri5.isIsosceles() || tri5.isEquilateral() || tri5.isScalene()); // false vid för många tal - pass
        }

        //[TestMethod]
        //public void stringsTest() // gick ej
        //{
        //    string[] someStrings = { "hej", "tja", "yo" };
        //    Triangle tri6 = new Triangle(someStrings);
        //    Assert.IsTrue(tri6.isScalene() || tri6.isEquilateral() || tri6.isIsosceles());
        //}
    }
}