using System.Collections.Generic;

namespace Company.Shop.RentArea
{
    interface IServiceRent
    {
        void AddRent(Rent rent);
        List<Rent> getAllRent();
        decimal countValueAllRent();
        bool ExistRent(Rent newRent);
    }
}
