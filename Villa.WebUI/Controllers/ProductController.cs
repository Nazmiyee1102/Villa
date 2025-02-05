using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Dto.Dtos.ProductDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.TGetListAsync();
            var messageList = _mapper.Map<List<ResultProductDto>>(values);
            return View(messageList);
        }

        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            ModelState.Clear();
            var newProduct = _mapper.Map<Product>(createProductDto);
            var validator = new ProductValidators();
            var result = validator.Validate(newProduct);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _productService.TCreateAsync(newProduct);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            var product = await _productService.TGetByIdAsync(id);
            var productDto = _mapper.Map<UpdateProductDto>(product);
            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductDetails(ObjectId id)
        {
            var product = await _productService.TGetByIdAsync(id);
            var productDto = _mapper.Map<ResultProductDto>(product);
            return View(productDto);
        }

    }
}
