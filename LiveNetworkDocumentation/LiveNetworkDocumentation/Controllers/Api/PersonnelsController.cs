using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LiveNetworkDocumentation.Dtos;
using LiveNetworkDocumentation.Models;

namespace LiveNetworkDocumentation.Controllers.Api
{
    public class PersonnelsController : ApiController
    {
        private LiveNetworkDocumentationEntities _db;

        public PersonnelsController()
        {
            _db = new LiveNetworkDocumentationEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            _db = new LiveNetworkDocumentationEntities();
        }


        // GET      Api/Personnels/         Read All
        public IEnumerable<PersonnelDto> GetPersonnel()
        {
            return _db.KhadamatMashiniPersonnels.ToList().Select(Mapper.Map<KhadamatMashiniPersonnel, PersonnelDto>);
        }

        // GET      Api/Personnels/id       Read one
        public PersonnelDto GetPersonnel(int id)
        {
            var personnel = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
                    
//            var personnelDto = new PersonnelDto();
//            Mapper.Map(personnel, personnelDto);
//            return personnelDto;

            return Mapper.Map<KhadamatMashiniPersonnel, PersonnelDto>(personnel);
        }

        // POST     Api/Personnels/         Create a personnel
        [HttpPost]
        public PersonnelDto CreatePersonnel(PersonnelDto personnelDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var personnel = Mapper.Map<PersonnelDto, KhadamatMashiniPersonnel>(personnelDto);
            _db.KhadamatMashiniPersonnels.Add(personnel);
            _db.SaveChanges();
            personnelDto.Id = personnel.Id;     // assign generated id by DB for personnel to Dto object
            return personnelDto;
        }

        // PUT      Api/Personnels/id       Update a personnel
        [HttpPut]
        public PersonnelDto UpdatePersonnel(int id, PersonnelDto personnelDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);                
            }

            var personnelInDb = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnelInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(personnelDto, personnelInDb);
            _db.SaveChanges();
            return personnelDto;
        }


        // DELETE   Api/Personnels/id         Delete a personnel
        [HttpDelete]
        public void DeletePersonnel(int id)
        {
            var personnelInDb = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnelInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.KhadamatMashiniPersonnels.Remove(personnelInDb);
            _db.SaveChanges();
        }
    }
}
