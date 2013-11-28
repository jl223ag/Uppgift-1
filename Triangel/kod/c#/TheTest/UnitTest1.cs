using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tri
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isIsoscelesTest() // test av likbent triangel
        {
            Triangle tri = new Triangle(3.0, 3.0, 1.0);
            Assert.IsTrue(tri.isIsosceles());

            tri = new Triangle(2.0, 1.0, 3.0);
            Assert.IsFalse(tri.isIsosceles());

            tri = new Triangle(5.0, 5.0, 5.0);
            Assert.IsFalse(tri.isIsosceles());
        }

        [TestMethod]
        public void isEquilateralTest() // test av triangel med inga lika sidor
        {
            Triangle tri = new Triangle(5.0, 2.0, 6.0);
            Assert.IsTrue(tri.isEquilateral());

            tri = new Triangle(5.0, 5.0, 6.0);
            Assert.IsFalse(tri.isEquilateral());

            tri = new Triangle(20.0, 20.0, 20.0);
            Assert.IsFalse(tri.isEquilateral());
            
        }

        [TestMethod]
        public void isScaleneTest() // test av liksidig triangel
        {
            Triangle tri = new Triangle(5.0, 5.0, 5.0);
            Assert.IsTrue(tri.isScalene());

            tri = new Triangle(5.0, 7.0, 8.0);
            Assert.IsFalse(tri.isScalene());

            tri = new Triangle(2.0, 2.0, 8.0);
            Assert.IsFalse(tri.isScalene());             
        }

        [TestMethod]
        public void negativeNumbers()
        {
            Triangle tri = new Triangle(-5, -5, -5);
            Assert.IsTrue(tri.isScalene());
        }

        [TestMethod]
        public void oneNegative()
        {
            Triangle tri = new Triangle(44, 22, -33);
            Assert.IsTrue(tri.isEquilateral());
        }

        [TestMethod]
        public void pointTest1() // inga lika sidor
        {
            Triangle tri = new Triangle(new Point(0, 0), new Point(3, 0), new Point(3, 4));
            Assert.IsTrue(tri.isEquilateral());
        }
        
        [TestMethod]
        public void pointTest2() // likbent
        {
            Triangle tri = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.IsTrue(tri.isIsosceles());
        }
        
        [TestMethod]
        public void pointTest3() // alla kordinater på samma punkt, bildar ingen triangel varför alla borde vara false
        {            
            Triangle tri = new Triangle(new Point(0, 20), new Point(0, 20), new Point(0, 20));
            Assert.IsFalse(tri.isIsosceles());
            Assert.IsFalse(tri.isScalene());
            Assert.IsFalse(tri.isEquilateral());
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