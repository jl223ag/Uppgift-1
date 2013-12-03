using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tri
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isIsoscelesTest() // test av isosceles (likbent triangel)
        {
            Triangle tri = new Triangle(3.0, 3.0, 1.0);
            Assert.IsTrue(tri.isIsosceles());
        }
        
        [TestMethod]
        public void isIsoscelesTest2() // att isosceles inte är oliksidig
        {
            Triangle tri = new Triangle(2.0, 1.0, 3.0);
            Assert.IsFalse(tri.isIsosceles());
        }

        [TestMethod]
        public void isIsoscelesTest3() // att isosceles inte är liksidig
        {
            Triangle tri = new Triangle(5.0, 5.0, 5.0);
            Assert.IsFalse(tri.isIsosceles());
        }

        [TestMethod]
        public void isEquilateralTest() // test av equilateral (liksidig)
        {
            Triangle tri = new Triangle(5.0, 5.0, 5.0);
            Assert.IsTrue(tri.isEquilateral());
        }

        [TestMethod]
        public void isEquilateralTest2() // att eq inte är likbent
        {
            Triangle tri = new Triangle(3.0, 5.0, 5.0);
            Assert.IsFalse(tri.isEquilateral());
        }
        
        [TestMethod]
        public void isEquilateralTest3() // att eq inte är oliksidig
        {
            Triangle tri = new Triangle(2.0, 1.0, 3.0);
            Assert.IsFalse(tri.isEquilateral());            
        }

        [TestMethod]
        public void isScaleneTest() // test scalene (inga lika sidor)
        {
            Triangle tri = new Triangle(5.0, 4.0, 3.0);
            Assert.IsTrue(tri.isScalene());
        }

        [TestMethod]
        public void isScaleneTest2() // att scalene inte är liksidig
        {
            Triangle tri = new Triangle(5.0, 5.0, 5.0); 
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void isScaleneTest3() // att scalene inte är likbent
        {
            Triangle tri = new Triangle(2.0, 2.0, 8.0);
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void negativeNumbers()
        {
            Triangle tri = new Triangle(-5, -5, -10);
            Assert.IsTrue(tri.isIsosceles());
        }

        [TestMethod]
        public void oneNegative()
        {
            Triangle tri = new Triangle(44, 44, -33);
            Assert.IsTrue(tri.isIsosceles());
        }
        
        [TestMethod]
        public void pointTest() // test av Point - likbent
        {
            Triangle tri = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
            Assert.IsTrue(tri.isIsosceles());
        }
        
        [TestMethod]
        public void pointTest2() // alla kordinater på samma punkt bildar ingen triangel
        {            
            Triangle tri = new Triangle(new Point(0, 20), new Point(0, 20), new Point(0, 20));
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void pointTest3() // test med fyra points
        {
            Point[] point = new Point[4];
            point[0] = new Point(0, 0);
            point[1] = new Point(0, 10);
            point[2] = new Point(20, 10);
            point[3] = new Point(20, 0);
            Triangle tri = new Triangle(point);

            Assert.IsTrue(tri.isIsosceles());
        }

        [TestMethod]
        public void differentNumbers1() // test av array med ett nummer
        {
            double[] one = new double[] { 20.0 };
            Triangle tri = new Triangle(one);
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void differentNumbers2() // två nummer
        {
            double[] two = new double[] { 5.5, 5.5 };
            Triangle tri = new Triangle(two);
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void differentNumbers3() // många nummer
        {
            double[] many = new double[] { 1.2, 1.3, 1.8, 1.8, 1.3, 1.2}; // kan stoppa in hur många sidor jag vill bara sålänge det inte är mer än 3 unika
            Triangle tri = new Triangle(many);
            Assert.IsFalse(tri.isEquilateral());
        }
    }
}