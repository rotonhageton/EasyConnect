using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyConnect;

namespace EasyConnectTestyJednostkowe
{
    [TestClass]
    public class EasyConnectTestyJednostkowe
    {
        [TestMethod]
        public void TestOdpowiedniejDlug�ciNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "123456789";
            long ContactNoMax = 9;

            //dzia�anie
            if (long.Parse(ContactNo) == ContactNoMax)
            { 
                //Numer telefonu jest odpowiedniej d�ugo�ci
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

            //dzia�anie
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

            //dzia�anie
            if (long.Parse(ContactNo) == ContactNoMax)
            {
                //Numer telefonu jest zbyt d�ugi
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }
    }
}
