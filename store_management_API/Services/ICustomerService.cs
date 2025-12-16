using store_management_WebAPI.DTOs;

namespace store_management_WebAPI.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAllAsync();
        Task<CustomerResponse?> GetByIdAsync(int id);
        Task<CustomerResponse> AddAsync(CustomerRequest request);
        Task<bool> UpdateAsync(int id, CustomerRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
