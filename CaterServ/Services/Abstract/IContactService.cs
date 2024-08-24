using CaterServ.Dtos.ContactDtos;

namespace CaterServ.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<ResultContactDto> GetContactById(string id);

        Task UpdateContact(UpdateContactDto updateContact);
        Task DeleteContact(string id);
        Task CreateContact(CreateContactDto createContact);
    }
}
