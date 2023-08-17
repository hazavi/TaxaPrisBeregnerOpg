namespace Taxaopg.Services
{
    public class TaxiPriceCalculator
    {
        private const decimal Cykel = 30.0M;
        private const decimal Opbæring = 30.0M;
        private const decimal Liftvogn = 30.0M;
        private const decimal FraLufthavn = 15.0M;
        private const decimal Bro1 = 350.0M;
        private const decimal Bro2 = 540.0M;


        public decimal CalculatePrice(string taxiType, DateTime date, double distance, bool cykel, bool opbæring, bool liftvogn, bool fraLufhavn, bool bro1, bool bro2, int minutes)
        {
            decimal startPris;
            decimal prisPrKM;
            decimal minutPris;

            if (taxiType == "Almindelige (Dagtimer)")
            {
                startPris = 37.0M;
                prisPrKM = 12.75M;
                minutPris = 5.75M;
            }
            else if (taxiType == "Almindelige (Aften/Nat/Weekend)")
            {
                startPris = 47.0M;
                prisPrKM = 16M;
                minutPris = 7.0M;
            }
            else if (taxiType == "MiniBus (Dagtimer)")
            {
                startPris = 77.0M;
                prisPrKM = 17M;
                minutPris = 5.75M;
            }
            else if (taxiType == "MiniBus (Aften/Nat/Weekend)")
            {
                startPris = 87M;
                prisPrKM = 19M;
                minutPris = 7.0M;
            }
            else
            {
                throw new ArgumentException("Fejl", nameof(taxiType));
            }

            decimal totalPris = startPris + (decimal)distance * prisPrKM;

            if (cykel)
            {
                totalPris += Cykel; // Additional fee for bikes
            }

            if (opbæring)
            {
                totalPris += Opbæring; 
            }

            if (liftvogn)
            {
                totalPris += Liftvogn; 
            }

            if (fraLufhavn)
            {
                totalPris += FraLufthavn; // Additional fee for airport pickup
            }

            if (bro1)
            {
                totalPris += Bro1; // Additional fee for bridges
            } 

            if (bro2)
            {
                totalPris += Bro2; // Additional fee for bridges
            }

            totalPris += minutPris * minutes; // Add minute-based pricing

            return totalPris;
        }
    }
}
