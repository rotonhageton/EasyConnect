using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyConnect;

namespace EasyConnectTestyJednostkowe
{
    [TestClass]
    public class EasyConnectTestyJednostkowe
    {
        [TestMethod]
        public void TestOdpowiedniejDlugœciNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "123456789";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            { 
                //Numer telefonu jest odpowiedniej d³ugoœci
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }

        [TestMethod]
        public void TestZbytKrotkiegoNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "8437";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            {
                //Numer telefonu jest zbyt krotki
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }

        [TestMethod]
        public void TestZbytDlugiegooNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "84374432312";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            {
                //Numer telefonu jest zbyt d³ugi
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }
    }
}
