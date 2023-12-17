using Business.DTOs.Requests.Products;
using Business.DTOs.Responses.Products;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService 
    {
        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest createProductRequest);
        Task<IPaginate<GetListProductResponse>> GetListProductAsync(PageRequest pageRequest);
        Task<PermanentDeleteProductResponse> PermanentDeleteProductAsync(PermanentDeleteProductRequest permanentDeleteProductRequest);
        Task<SoftDeleteProductResponse> SoftDeleteProductAsync(SoftDeleteProductRequest softDeleteProductRequest);
        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest updateProductRequest);
    }
}
