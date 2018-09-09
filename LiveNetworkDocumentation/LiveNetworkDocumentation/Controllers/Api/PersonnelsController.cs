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
        public IHttpActionResult GetPersonnel()
        {
            var personnelDtosList = _db.KhadamatMashiniPersonnels.ToList().Select(Mapper.Map<KhadamatMashiniPersonnel, PersonnelDto>);
            return Ok(personnelDtosList);
        }

        // GET      Api/Personnels/id       Read one
        public IHttpActionResult GetPersonnel(int id)
        {
            var personnel = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnel == null)
                return NotFound();
                    
//            var personnelDto = new PersonnelDto();
//            Mapper.Map(personnel, personnelDto);
//            return personnelDto;

            return Ok(Mapper.Map<KhadamatMashiniPersonnel, PersonnelDto>(personnel));
        }

        // POST     Api/Personnels/         Create a personnel
        [HttpPost]
        public IHttpActionResult CreatePersonnel(PersonnelDto personnelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var personnel = Mapper.Map<PersonnelDto, KhadamatMashiniPersonnel>(personnelDto);
            _db.KhadamatMashiniPersonnels.Add(personnel);
            _db.SaveChanges();
            personnelDto.Id = personnel.Id;     // assign generated id by DB for personnel to Dto object
            return Created(new Uri(Request.RequestUri + "/" + personnel.Id), personnelDto);
        }

        // PUT      Api/Personnels/id       Update a personnel
        [HttpPut]
        public IHttpActionResult UpdatePersonnel(int id, PersonnelDto personnelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var personnelInDb = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnelInDb == null)
                return NotFound();

            Mapper.Map(personnelDto, personnelInDb);
            _db.SaveChanges();

            return Ok();
        }


        // DELETE   Api/Personnels/id         Delete a personnel
        [HttpDelete]
        public IHttpActionResult DeletePersonnel(int id)
        {
            var personnelInDb = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnelInDb == null)
                return NotFound();

            _db.KhadamatMashiniPersonnels.Remove(personnelInDb);
            _db.SaveChanges();

            return Ok();
        }
    }
}
