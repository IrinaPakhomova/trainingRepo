
namespace Company.Shop.RentArea
{
    public class Rent
    {
        public string NameArea {get; set;}
        public decimal Price { get; set; }

        public Rent(string nameArea, decimal price)
        {
            NameArea = nameArea;
            Price = price;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Rent rent = (Rent)obj;
            return ((this.NameArea == rent.NameArea) && (this.Price == rent.Price));
        }

        public override string ToString()
        {
            return "Помещение: " + this.NameArea + ";  Аренда: " + this.Price ;
        }
    }
}
