using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Products;
using Business.DTOs.Responses.Products;
using Business.Helpers.Products;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = Entities.Concrete.Product;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductHelper _productHelper;

        public ProductManager(IProductRepository productRepository, IMapper mapper, IProductHelper productHelper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productHelper = productHelper;
        }

        public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest createProductRequest)
        {
            var idOfDuplicateDraft=await _productHelper.DuplicateDraft(createProductRequest.DraftId);
            createProductRequest.DraftId = idOfDuplicateDraft;

            var product = _mapper.Map<Product>(createProductRequest);
            var createdProduct= await _productRepository.AddAsync(product);
            return _mapper.Map<CreateProductResponse>(createdProduct);  
        }

        public async Task<IPaginate<GetListProductResponse>> GetListProductAsync(PageRequest pageRequest)
        {
            var products = await _productRepository.GetListAsync(index:pageRequest.PageIndex,size:pageRequest.PageSize);   
            return _mapper.Map<Paginate<GetListProductResponse>>(products);
        }

        public async Task<PermanentDeleteProductResponse> PermanentDeleteProductAsync(PermanentDeleteProductRequest permanentDeleteProductRequest)
        {
            var selectedProduct = await _productRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteProductRequest.Id));
            var deletedProduct = await _productRepository.DeleteAsync(selectedProduct,permanent:true);
            return _mapper.Map<PermanentDeleteProductResponse>(deletedProduct);

        }

        public async Task<SoftDeleteProductResponse> SoftDeleteProductAsync(SoftDeleteProductRequest softDeleteProductRequest)
        {
            var selectedProduct = await _productRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteProductRequest.Id));
            var hidedProduct = await _productRepository.DeleteAsync(selectedProduct, permanent: false);
            return _mapper.Map<SoftDeleteProductResponse>(hidedProduct);
        }

        public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest updateProductRequest)
        {
            var requestedProduct = await _productRepository.GetAsync(t => t.Id == Guid.Parse(updateProductRequest.Id));
            requestedProduct = _mapper.Map(updateProductRequest, requestedProduct);
            var updatedProduct = await _productRepository.UpdateAsync(requestedProduct);
            return _mapper.Map<UpdateProductResponse>(updatedProduct);
        }
    }
}
