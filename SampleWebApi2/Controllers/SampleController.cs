using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_CRUD.Models;
using WebApi_CRUD.Repository;

namespace WebApi_CRUD.Controllers
{
    [Route("api/v1/mySampleApp")]
    public class SampleController : ApiController
    {
        public ISampleCRUD _sampleCRUD;

        List<Sample> sampleList = new List<Sample>();

        [HttpGet]
        public IHttpActionResult GetSample()
        {
            _sampleCRUD = new SampleCRUD(sampleList);

            try
            {
                var list = _sampleCRUD.GetSample();
                if(list != null)
                {
                    return Ok(list);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        [HttpGet]
        [Route("api/v1/mySampleApp/{id}")]
        public IHttpActionResult GetSampleById(string id)
        {
            _sampleCRUD = new SampleCRUD(sampleList);
            try
            {
                var result = _sampleCRUD.GetSampleById(id);
                if(result!=null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        [HttpPost]        
        public IHttpActionResult CreateSampleData([FromBody] Sample sampleData)
        {
            _sampleCRUD = new SampleCRUD(sampleList);
            try
            {
                if(sampleData==null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _sampleCRUD.CreateSample(sampleData);

                return Created(new Uri($"api/v1/mySampleApp/{sampleData.Id}",UriKind.RelativeOrAbsolute),sampleData);
               
            }
            catch (Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
        }
        [HttpPatch]
        [Route("api/v1/mySampleApp/{id}")]
        public IHttpActionResult UpdateSample(string id,[FromBody] Sample sampleData)
        {
            _sampleCRUD = new SampleCRUD(sampleList);

            try
            {
                if (sampleData == null)
                {
                    return BadRequest();

                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _sampleCRUD.UpdateSample(id, sampleData);
                return Created(new Uri($"api/v1/mySampleApp/{sampleData.Id}", UriKind.RelativeOrAbsolute), sampleData);
            }
            catch(Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }
                       
        }
        [HttpDelete]
        [Route("api/v1/mySampleApp/{id}")]
        public IHttpActionResult DeleteSample(string id)
        {
            _sampleCRUD = new SampleCRUD(sampleList);
            try
            {
               
                _sampleCRUD.DeleteSample(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Here we need log the error properly 
                throw ex;
            }

        }
    }
}
