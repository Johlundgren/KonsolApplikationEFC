using KonsolApplikationEFC.Entities;
using KonsolApplikationEFC.Repositories;

namespace KonsolApplikationEFC.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }


    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        var adressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        adressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city});

        return adressEntity;
    }

    public AddressEntity GetAddressBy(string streetName, string postalCode, string city)
    {
        var adressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return adressEntity;
    }

    public AddressEntity GetAddressById(int id)
    {
        var adressEntity = _addressRepository.Get(x => x.Id == id);
        return adressEntity;
    }

    public IEnumerable<AddressEntity> GetAllAddresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    public AddressEntity UpdateAddress(AddressEntity adressEntity)
    {
        var updatedAdressEntity = _addressRepository.Update(x => x.Id == adressEntity.Id, adressEntity);
        return updatedAdressEntity;
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }
}
