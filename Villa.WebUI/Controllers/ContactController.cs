using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.TGetListAsync();
            var contactList = _mapper.Map<List<ResultContactDto>>(values);
            return View(contactList);
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            ModelState.Clear();
            var newContact = _mapper.Map<Contact>(createContactDto);
            var validator = new ContactValidators();
            var result = validator.Validate(newContact);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _contactService.TCreateAsync(newContact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateContact(ObjectId id)//id ye göre getirme
        {
            var value = await _contactService.TGetByIdAsync(id);
            var contact = _mapper.Map<UpdateContactDto>(value);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(contact);
            return RedirectToAction("Index");
        }
    }
}
