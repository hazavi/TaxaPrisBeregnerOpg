namespace Taxaopg.Services
{
    // Services/TaxiPriceCalculator.cs
    public class TaxiPriceCalculator
    {
        public decimal CalculatePrice(string taxiType, DateTime date, double distance)
        {
            decimal basePrice;
            decimal pricePerKm;

            if (taxiType == "Almindelige (Dagtimer)")
            {
                basePrice = 37.0M;
                pricePerKm = 12.75M;

            }
            else if (taxiType == "Almindelige (Aften/Nat/Weekend)")
            {
                basePrice = 47.0M;
                pricePerKm = 16M;

            }
            else if(taxiType == "MiniBus (Dagtimer)")
            {
                basePrice = 77.0M;
                pricePerKm = 17M;

            }
            else if(taxiType == "MiniBus (Aften/Nat/Weekend)")
            {
                basePrice = 87M;
                pricePerKm = 19M;

            }
            else
            {
                throw new ArgumentException("Fejl", nameof(taxiType));
            }

            decimal totalPrice = basePrice + (decimal)distance * pricePerKm;

            return totalPrice;
        }


    }

}
